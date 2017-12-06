using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class AltaCliente : Form
    {
        private char _evento;
        private int _idCliente;
        private ListarClientes _listarClientes;

        public static AltaCliente Crear(ListarClientes listarClientes, char evento, string idCliente)
        {
            var abm =  new AltaCliente(listarClientes, evento)
            {
                _idCliente = Convert.ToInt32(idCliente)
            };
            abm.CargarCliente();
            return abm;
        }

        public AltaCliente(ListarClientes listarClientes, char evento)
        {
            InitializeComponent();
            _evento = evento;
            _listarClientes = listarClientes;
            if (_evento == 'E')
                cmdLimpiar.Text = "Restaurar";
            dtpFecNac.MaxDate = DateTime.Today;
        }

        private void CargarCliente()
        {
            var con = new Conexion()
            {
                query = string.Format("SELECT * FROM ONEFORALL.CLIENTES WHERE CLIE_ID = {0}", _idCliente)
            };
            con.leer();
            con.leerReader();

            txtNombre.Text = con.lector.GetString(1);
            txtApellido.Text = con.lector.GetString(2);
            dtpFecNac.Value = con.lector.GetDateTime(3);
            int direccion = con.lector.GetInt32(4);
            txtDni.Text = con.lector.GetString(5);
            txtMail.Text = con.lector.GetString(6);
            chkActivo.Checked = con.lector.GetBoolean(7);
            txtTel.Text = con.lector.IsDBNull(8)? "": con.lector.GetString(8);

            con.cerrarConexion();

            con = new Conexion()
            {
                query = string.Format("SELECT * FROM ONEFORALL.DIRECCIONES WHERE DIR_ID = {0}", direccion)
            };
            con.leer();
            con.leerReader();

            txtDirDireccion.Text = con.lector.GetString(1);
            txtDirCodPostal.Text = con.lector.GetString(2);
            txtDirPiso.Text = con.lector.IsDBNull(3) ? "" : con.lector.GetString(3);
            txtDirDepto.Text = con.lector.IsDBNull(4) ? "" : con.lector.GetString(4);
            txtDirLocalidad.Text = con.lector.GetString(5);
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            if (_evento == 'E')
            {
                CargarCliente();
            }
            else
            {
                txtApellido.Clear();
                txtDirCodPostal.Clear();
                txtDirDepto.Clear();
                txtDirDireccion.Clear();
                txtDirLocalidad.Clear();
                txtDni.Clear();
                txtMail.Clear();
                txtNombre.Clear();
                txtDirPiso.Clear();
                txtTel.Clear();
                dtpFecNac.Value = new DateTime(1995,1,1);
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            _listarClientes.Show();
            this.Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCamposNoNulos();
                ValidarMailExistente();
                int direccionId = ObtenerDireccion();
                if (_evento == 'A')
                    AgregarCliente(direccionId);
                else
                    ActualizarCliente(direccionId);

                _listarClientes.Actualizar();
                _listarClientes.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarMailExistente()
        {
            var con = new Conexion();
            con.query = string.Format("SELECT * FROM ONEFORALL.CLIENTES WHERE CLIE_MAIL = '{0}'", txtMail.Text);
            con.leer();
            if (con.leerReader())
            {
                con.cerrarConexion();
                throw new Exception("Ya existe un cliente con ese mail");
            }
            else
                con.cerrarConexion();
        }

        private void ValidarCamposNoNulos()
        {
            List<string> camposNulos = new List<string>();

            if (string.IsNullOrEmpty(txtNombre.Text))
                camposNulos.Add("Nombre");
            if (string.IsNullOrEmpty(txtApellido.Text))
                camposNulos.Add("Apellido");
            if (string.IsNullOrEmpty(txtDni.Text))
                camposNulos.Add("DNI");
            if (string.IsNullOrEmpty(txtMail.Text))
                camposNulos.Add("Mail");
            if (string.IsNullOrEmpty(txtDirDireccion.Text))
                camposNulos.Add("Calle y Numero");
            if (string.IsNullOrEmpty(txtDirCodPostal.Text))
                camposNulos.Add("Codigo Postal");
            if (string.IsNullOrEmpty(txtDirLocalidad.Text))
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
                    txtDirDireccion.Text, txtDirCodPostal.Text,
                    string.IsNullOrEmpty(txtDirPiso.Text) ? "null" : "'" + txtDirPiso.Text + "'",
                    string.IsNullOrEmpty(txtDirDepto.Text) ? "null" : "'" + txtDirDepto.Text + "'",
                    txtDirLocalidad.Text)
                };
                con2.ejecutar();

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
                "AND DIR_LOCALIDAD = '{2}'", txtDirDireccion.Text, txtDirCodPostal.Text, txtDirLocalidad.Text);

            if (!string.IsNullOrEmpty(txtDirPiso.Text))
                consulta += string.Format("AND DIR_PISO = '{0}'", txtDirPiso.Text);

            if (!string.IsNullOrEmpty(txtDirDepto.Text))
                consulta += string.Format("AND DIR_DEPARTAMENTO = '{0}'", txtDirDepto.Text);
            return consulta;
        }

        private void ActualizarCliente(int direccionId)
        {
            var con = new Conexion()
            {
                query = string.Format("UPDATE ONEFORALL.CLIENTES " +
                "SET CLIE_NOMBRE = '{0}', " +
                "CLIE_APELLIDO = '{1}', " +
                "CLIE_FECHA_NACIMIENTO = '{2}', " +
                "CLIE_DIR_ID = {3}, " +
                "CLIE_DNI = '{4}', " +
                "CLIE_MAIL = '{5}', " +
                "CLIE_ACTIVO = {6}, " +
                "CLIE_TELEFONO = {7} " +
                "WHERE CLIE_ID = {8}",
                txtNombre.Text, txtApellido.Text, dtpFecNac.Value.ToString("yyyy-MM-dd HH:mm:ss"), direccionId, txtDni.Text, txtMail.Text, Convert.ToInt16(chkActivo.Checked),
                string.IsNullOrEmpty(txtTel.Text) ? "null" : "'" + txtTel.Text + "'",
                _idCliente)
            };
            con.ejecutar();
        }

        private void AgregarCliente(int direccionId)
        {
            string insert = string.Format("INSERT INTO ONEFORALL.CLIENTES VALUES ('{0}', '{1}', '{2}', {3}, '{4}', '{5}', {6}, {7})",
                txtNombre.Text, txtApellido.Text, dtpFecNac.Value.ToString("yyyy-MM-dd HH:mm:ss"), direccionId, txtDni.Text, txtMail.Text, Convert.ToInt16(chkActivo.Checked),
                string.IsNullOrEmpty(txtTel.Text) ? "null" : "'" + txtTel.Text + "'");

            var con = new Conexion()
            {
                query = insert
            };
            con.ejecutar();
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }
    }
}
