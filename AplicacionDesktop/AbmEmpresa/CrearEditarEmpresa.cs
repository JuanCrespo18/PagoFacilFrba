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
    public partial class CrearEditarEmpresa : Form
    {
        private char _evento;
        private int _idEmpresa;
        private ListarEmpresas _listarEmpresas;

        public static CrearEditarEmpresa Crear(ListarEmpresas listarEmpresas, char evento, string idEmpresa)
        {
            var abm =  new CrearEditarEmpresa(listarEmpresas, evento)
            {
                _idEmpresa = Convert.ToInt32(idEmpresa)
            };
            abm.CargarEmpresa();
            return abm;
        }

        public CrearEditarEmpresa(ListarEmpresas listarEmpresas, char evento)
        {
            InitializeComponent();
            _evento = evento;
            _listarEmpresas = listarEmpresas;
            if (_evento == 'E')
                cmdLimpiarEmp.Text = "Restaurar";
        }

        private void CargarEmpresa()
        {
            var con = new Conexion()
            {
                query = string.Format("SELECT * FROM ONEFORALL.Empresas WHERE CLIE_ID = {0}", _idEmpresa)
            };
            con.leer();
            con.leerReader();

            txtNombreEmp.Text = con.lector.GetString(1);
            txtCuitEmp.Text = con.lector.GetString(2);
            dtpFecNacEmp.Value = con.lector.GetDateTime(3);
            int direccion = con.lector.GetInt32(4);
            txtRubro.Text = con.lector.GetString(5);
            txtMail.Text = con.lector.GetString(6);
            chkActivo.Checked = con.lector.GetBoolean(7);
            txtTelEmp.Text = con.lector.IsDBNull(8)? "": con.lector.GetString(8);

            con.cerrarConexion();

            con = new Conexion()
            {
                query = string.Format("SELECT * FROM ONEFORALL.DIRECCIONES WHERE DIR_ID = {0}", direccion)
            };
            con.leer();
            con.leerReader();

            txtDirDireccionEmp.Text = con.lector.GetString(1);
            txtDirCodPostalEmp.Text = con.lector.GetString(2);
            txtDirPisoEmp.Text = con.lector.IsDBNull(3) ? "" : con.lector.GetString(3);
            txtDirDeptoEmp.Text = con.lector.IsDBNull(4) ? "" : con.lector.GetString(4);
            txtDirLocalidadEmp.Text = con.lector.GetString(5);
        }

        private void cmdLimpiarEmp_Click(object sender, EventArgs e)
        {
            if (_evento == 'E')
            {
                CargarEmpresa();
            }
            else
            {
                txtCuitEmp.Clear();
                txtDirCodPostalEmp.Clear();
                txtDirDeptoEmp.Clear();
                txtDirDireccionEmp.Clear();
                txtDirLocalidadEmp.Clear();
                txtRubro.Clear();
                txtNombreEmp.Clear();
                txtDirPisoEmp.Clear();
                txtTelEmp.Clear();
                dtpFecNacEmp.Value = new DateTime(1995,1,1);
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            _listarEmpresas.Show();
            this.Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCamposNoNulos();
                int direccionId = ObtenerDireccion();
                if (_evento == 'A')
                    AgregarEmpresa(direccionId);
                else
                    ActualizarEmpresa(direccionId);

                _listarEmpresas.Actualizar();
                _listarEmpresas.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarCamposNoNulos()
        {
            List<string> camposNulos = new List<string>();

            if (string.IsNullOrEmpty(txtNombreEmp.Text))
                camposNulos.Add("Nombre");
            if (string.IsNullOrEmpty(txtCuitEmp.Text))
                camposNulos.Add("Cuit");
            if (string.IsNullOrEmpty(txtRubro.Text))
                camposNulos.Add("Rubro");
            if (string.IsNullOrEmpty(txtDirDireccionEmp.Text))
                camposNulos.Add("Calle y Numero");
            if (string.IsNullOrEmpty(txtDirCodPostalEmp.Text))
                camposNulos.Add("Codigo Postal");
            if (string.IsNullOrEmpty(txtDirLocalidadEmp.Text))
                camposNulos.Add("Localidad");

            if (camposNulos.Count > 0)
                throw new Exception(string.Format("Los siguientes campos no pueden estar vacios: {0}", string.Join(", ", camposNulos)));
        }

        private int ObtenerDireccion()
        {
            int direccion;
            string consulta = ConsultaDireccion();

            var con = new Conexion()
            {
                query = consulta
            };
            con.leer();
            if (con.leerReader())
                direccion = con.lector.GetInt32(0);
            else
            {
                var con2 = new Conexion()
                {
                    query = string.Format("INSERT INTO ONEFORALL.DIRECCIONES VALUES('{0}', '{1}', {2}, {3}, '{4}')",
                    txtDirDireccionEmp.Text, txtDirCodPostalEmp.Text,
                    string.IsNullOrEmpty(txtDirPisoEmp.Text) ? "null" : "'" + txtDirPisoEmp.Text + "'",
                    string.IsNullOrEmpty(txtDirDeptoEmp.Text) ? "null" : "'" + txtDirDeptoEmp.Text + "'",
                    txtDirLocalidadEmp.Text)
                };
                con2.ejecutar();
                con2.cerrarConexion();

                con2.query = ConsultaDireccion();
                con2.leer();
                con2.leerReader();
                direccion = con2.lector.GetInt32(0);
                con2.cerrarConexion();
            }
            con.cerrarConexion();
            return direccion;
        }

        private string ConsultaDireccion()
        {
            string consulta = string.Format("SELECT DIR_ID FROM ONEFORALL.DIRECCIONES " +
                "WHERE DIR_DIRECCION = '{0}'" +
                "AND DIR_CODIGO_POSTAL = '{1}'" +
                "AND DIR_LOCALIDAD = '{2}'", txtDirDireccionEmp.Text, txtDirCodPostalEmp.Text, txtDirLocalidadEmp.Text);

            if (!string.IsNullOrEmpty(txtDirPisoEmp.Text))
                consulta += string.Format("AND DIR_PISO = '{0}'", txtDirPisoEmp.Text);

            if (!string.IsNullOrEmpty(txtDirDeptoEmp.Text))
                consulta += string.Format("AND DIR_DEPARTAMENTO = '{0}'", txtDirDeptoEmp.Text);
            return consulta;
        }

        private void ActualizarEmpresa(int direccionId)
        {
            var con = new Conexion()
            {
                query = string.Format("UPDATE ONEFORALL.Empresas " +
                "SET CLIE_NOMBRE = '{0}', " +
                "CLIE_APELLIDO = '{1}', " +
                "CLIE_FECHA_NACIMIENTO = '{2}', " +
                "CLIE_DIR_ID = {3}, " +
                "CLIE_DNI = '{4}', " +
                "CLIE_MAIL = '{5}', " +
                "CLIE_ACTIVO = {6}, " +
                "CLIE_TELEFONO = {7} " +
                "WHERE CLIE_ID = {8}",
                txtNombreEmp.Text, txtCuitEmp.Text, dtpFecNacEmp.Value.ToString("yyyy-MM-dd HH:mm:ss"), direccionId, txtRubro.Text, txtMail.Text, Convert.ToInt16(chkActivo.Checked),
                string.IsNullOrEmpty(txtTelEmp.Text) ? "null" : "'" + txtTelEmp.Text + "'",
                _idEmpresa)
            };
            con.ejecutar();
            con.cerrarConexion();
        }

        private void AgregarEmpresa(int direccionId)
        {
            string insert = string.Format("INSERT INTO ONEFORALL.Empresas VALUES ('{0}', '{1}', '{2}', {3}, '{4}', '{5}', {6}, {7})",
                txtNombreEmp.Text, txtCuitEmp.Text, dtpFecNacEmp.Value.ToString("yyyy-MM-dd HH:mm:ss"), direccionId, txtRubro.Text, txtMail.Text, Convert.ToInt16(chkActivo.Checked),
                string.IsNullOrEmpty(txtTelEmp.Text) ? "null" : "'" + txtTelEmp.Text + "'");

            var con = new Conexion()
            {
                query = insert
            };
            con.ejecutar();
            con.cerrarConexion();
        }
    }
}
