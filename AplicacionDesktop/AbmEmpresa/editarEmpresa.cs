using PagoAgilFrba.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class editarEmpresa : Form
    {
        private EmpresaDto empresa;
        private filtrarEmpresa menuPadre;
    
        public editarEmpresa(String _idEmpresa ,filtrarEmpresa parent)
        {
            InitializeComponent();
            cargarRubros();
            this.cargarEmpresa(Convert.ToInt32(_idEmpresa));
            this.menuPadre = parent;
        }

        private void cargarRubros()
        {
            rubro.Items.Clear();
            var squery = "SELECT DISTINCT(RUB_DESCRIPCION) FROM ONEFORALL.RUBROS";
            var con = new Conexion() { query = squery };
            con.leer();
            while (con.leerReader())
            {
                rubro.Items.Add(con.lector.GetString(0));
            }
        }

        public void cargarEmpresa(int _idEmpresa)
        {
            var query = "SELECT * FROM ONEFORALL.EMPRESAS WHERE EMP_ID = " + Convert.ToString(_idEmpresa) + ";";
            var con = new Conexion() { query = query};
            con.leer();
            if (!con.leerReader())
            {
                MessageBox.Show("Error al cargar la empresa", "editar empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                cuit.Text = con.lector.GetString(1);
                razonSocial.Text = con.lector.GetString(2);
                int idDireccion = con.lector.GetInt32(3);
                int idRubro = con.lector.GetInt32(4);
                int dia_rendicion = con.lector.GetInt32(5);
                checkHabilitada.Checked = con.lector.GetBoolean(6);

                con.cerrarConexion();

                con.query = string.Format("SELECT * FROM ONEFORALL.DIRECCIONES WHERE DIR_ID = {0}", idDireccion);

                con.leer();
                con.leerReader();

                direccion.Text = con.lector.GetString(1);
                codPostal.Text = con.lector.GetString(2);
                piso.Text = con.lector.IsDBNull(3) ? "" : con.lector.GetString(3);
                departamento.Text = con.lector.IsDBNull(4) ? "" : con.lector.GetString(4);
                localidad.Text = con.lector.GetString(5);
                con.cerrarConexion();
                con.query = string.Format("SELECT * FROM ONEFORALL.RUBROS WHERE RUB_ID = {0}", idRubro);
                con.leer();
                con.leerReader();
                rubro.Text = con.lector.GetString(1);

                empresa = new EmpresaDto(_idEmpresa, razonSocial.Text, cuit.Text, rubro.Text, direccion.Text, localidad.Text, codPostal.Text, piso.Text, departamento.Text,checkHabilitada.Checked);

            }
            con.cerrarConexion();
        }

        private bool hayObligatoriosvacios()
        {
            if (
                String.IsNullOrWhiteSpace(razonSocial.Text)||
                String.IsNullOrWhiteSpace(cuit.Text)||
                String.IsNullOrWhiteSpace(direccion.Text)||
                String.IsNullOrWhiteSpace(rubro.Text)||
                String.IsNullOrWhiteSpace(localidad.Text)||
                String.IsNullOrWhiteSpace(codPostal.Text)
                ) return true;
            return false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var dir_id = 0;
            var rub_id = 0;

            if (!hayObligatoriosvacios())
            {
                var empresaModificada = new EmpresaDto(empresa.id, razonSocial.Text, cuit.Text, rubro.Text, direccion.Text, localidad.Text, codPostal.Text, piso.Text, departamento.Text, checkHabilitada.Checked);

                if (!empresaModificada.equals(empresa))
                {

                    var query = "SELECT EMP_DIR_ID FROM ONEFORALL.EMPRESAS WHERE EMP_ID = " + empresa.id;

                    var con = new Conexion() { query = query };

                    con.leer();

                    if (!con.leerReader())
                    {
                        MessageBox.Show("No se encontro ninguna Sucursal", "Editar Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        menuPadre.Show();
                        this.Hide();
                    }
                    else
                    {
                        dir_id = con.lector.GetInt32(0);
                    }

                    con.cerrarConexion();

                    con.query = "UPDATE ONEFORALL.DIRECCIONES SET ";
                    query += "DIR_DIRECCION = '" + direccion.Text + "', ";
                    if (!string.IsNullOrEmpty(piso.Text))
                    {
                        query += "DIR_PISO = '" + piso.Text + "',";
                    }
                    if (!string.IsNullOrEmpty(departamento.Text))
                    {
                        query += "DIR_DEPARTAMENTO = '" + departamento.Text + "',";
                    }
                    query += "DIR_LOCALIDAD = '" + localidad.Text + "' WHERE DIR_ID =" + dir_id + " ;";
                    con.query = query;
                    con.ejecutar();

                    if (empresa.activa != empresaModificada.activa && empresaModificada.activa)
                    {

                        //todo se debe comprobar si hay rendiciones pendientes

                    }



                }

                menuPadre.Show();
                menuPadre.refresh();
                this.Hide();
            }
            else {
                MessageBox.Show("No se completaron los campos obligatorios", "editar Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) 
        {
            menuPadre.Show();
            this.Hide();
        }
    }
}
