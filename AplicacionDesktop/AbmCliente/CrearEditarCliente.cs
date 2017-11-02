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
    public partial class CrearEditarCliente : Form
    {
        private char _evento;
        private int _idCliente;

        public static CrearEditarCliente Crear(char evento, string idCliente)
        {
            var abm =  new CrearEditarCliente(evento)
            {
                _idCliente = Convert.ToInt32(idCliente)
            };
            abm.CargarCliente();
            return abm;
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

            txtDirCalle.Text = con.lector.GetString(1);
            txtDirCodPostal.Text = con.lector.GetString(2);
        }

        public CrearEditarCliente(char evento)
        {
            InitializeComponent();
            _evento = evento;
        }

        private void btnLim_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtDirCodPostal.Clear();
            txtDirDepto.Clear();
            txtDirCalle.Clear();
            txtDirLoc.Clear();
            txtDirPais.Clear();
            txtDni.Clear();
            txtMail.Clear();
            txtPais.Clear();
            txtNombre.Clear();
            txtDirPiso.Clear();
            txtTel.Clear();
            dtpFecNac.Value = DateTime.Now;
        }
    }
}
