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
        private int _idEmpresa; 
        private filtrarEmpresa menuPadre;
    
        public editarEmpresa(String id_empresa,filtrarEmpresa parent)
        {
            InitializeComponent();
            this._idEmpresa = Convert.ToInt32(id_empresa);
            this.cargarEmpresa(_idEmpresa);
            this.menuPadre = parent;
        }

        public void cargarEmpresa(int id_empresa)
        {
            var query = "SELECT * FROM ONEFORALL.EMPRESAS WHERE EMP_ID = " + Convert.ToString(id_empresa) + ";";
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
                checkHabilitada.Checked = con.lector.GetBoolean(5);

                con.cerrarConexion();

                con = new Conexion()
                {
                    query = string.Format("SELECT * FROM ONEFORALL.DIRECCIONES WHERE DIR_ID = {0}", idDireccion)
                };
                con.leer();
                con.leerReader();

                direccion.Text = con.lector.GetString(1);
                codPostal.Text = con.lector.GetString(2);
                piso.Text = con.lector.IsDBNull(3) ? "" : con.lector.GetString(3);
                departamento.Text = con.lector.IsDBNull(4) ? "" : con.lector.GetString(4);
                localidad.Text = con.lector.GetString(5);


                con.cerrarConexion();

                con = new Conexion()
                {
                    query = string.Format("SELECT * FROM ONEFORALL.RUBROS WHERE RUB_ID = {0}", idRubro)
                };
                con.leer();
                con.leerReader();

                rubro.Text = con.lector.GetString(1);

                ActualizarEmpresa(idDireccion, idRubro);


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

        private void ActualizarEmpresa(int direccionId,int rubroId)
        {
            var con = new Conexion()
            {
                query = string.Format("UPDATE ONEFORALL.EMPRESAS " +
                "SET EMP_ID = '{0}', " +
                "EMP_CUIT = '{1}', " +
                "EMP_NOMBRE = '{2}', " +
                "EMP_DIR_ID = {3}, " +
                "EMP_RUB_ID = '{4}', " +
                "EMP_ACTIVA = '{5}', " +
                "WHERE EMP_ID = {6}",
                _idEmpresa, cuit.Text, razonSocial.Text, direccionId, rubroId, Convert.ToInt16(checkHabilitada.Checked),
                _idEmpresa)
            };
            con.ejecutar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (!hayObligatoriosvacios())
            {
                
                var select = "SELECT EMP_DIR_ID FROM ONEFORALL.EMPRESAS WHERE EMP_ID = " + _idEmpresa;
                var idDireccion = 0;

                var idRubro = 0;
                var con = new Conexion() { query = select };
                con.leer();

                    if (!con.leerReader())
                    {
                        MessageBox.Show("No se encontro ninguna Empresa", "Editar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        menuPadre.Show();
                        this.Hide();
                    }
                    else
                    {
                        idDireccion = con.lector.GetInt32(0);
                    }
                    con.cerrarConexion();


                    var query =  "SELECT RUB_ID FROM ONEFORALL.RUBROS ";
                     query += "WHERE RUB_DESCRIPCION =" + rubro.Container + " ;";

                    if (!con.leerReader())
                    {
                        MessageBox.Show("No se encontro ninguna Rubro", "Editar Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        menuPadre.Show();
                        this.Hide();
                    }
                    else
                    {
                        idRubro = con.lector.GetInt32(0);
                    }

                    con.cerrarConexion();

                    query = "UPDATE ONEFORALL.DIRECCIONES SET ";
                    query += "DIR_DIRECCION = '" + direccion.Text + "', ";
                    if (!string.IsNullOrEmpty(piso.Text))
                    {
                        query += "DIR_PISO = '" + piso.Text + "',";
                    }
                    if (!string.IsNullOrEmpty(departamento.Text))
                    {
                        query += "DIR_DEPARTAMENTO = '" + departamento.Text + "',";
                    }
                    query += "DIR_LOCALIDAD = '" + localidad.Text + "' WHERE DIR_ID =" + idDireccion + " ;";

                    con.query = query;
                    con.ejecutar();
                    MessageBox.Show("Se realizaron los cambios correctamente", "Editar Empresa", MessageBoxButtons.OK);
               
                    ActualizarEmpresa(idDireccion, idRubro);
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
