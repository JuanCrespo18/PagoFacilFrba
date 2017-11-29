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
        private int _idEmpresa;
        private EmpresaDto empresa;
        private filtrarEmpresa menuPadre;
    
        public editarEmpresa(String id_empresa,filtrarEmpresa parent)
        {
            InitializeComponent();
            cargarRubros();
            this._idEmpresa = Convert.ToInt32(id_empresa);
            this.cargarEmpresa(_idEmpresa);
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
                int dia_rendicion = con.lector.GetInt32(5);
                checkHabilitada.Checked = con.lector.GetBoolean(6);

                empresa = new EmpresaDto(id_empresa, razonSocial.Text, cuit.Text, idRubro ,idDireccion, con.lector.GetBoolean(6));

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

               // ActualizarEmpresa(idDireccion, idRubro);


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

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (!hayObligatoriosvacios())
            {

                //TODO terminar


                btnCancelar_Click(null, null);
              

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
