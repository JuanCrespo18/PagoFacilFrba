using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmFactura
{
    public partial class AltaFactura : Form
    {
        private string _idCliente;
        private MenuPrincipal _menuPrincipal;

        public AltaFactura(MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            this._menuPrincipal = menuPrincipal;
        }

        private void cmdBuscarCliente_Click(object sender, EventArgs e)
        {
            new AbmCliente.ListarClientes(this).Show();
            this.Hide();
        }

        public void CargarCliente(string idCliente, string cliente)
        {
            _idCliente = idCliente;
            txtCliente.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(cliente.ToLower());;
        }

        private void CargarEmpresas()
        {
            cboEmpresas.Items.Clear();
            Conexion con = new Conexion();
            con.query = "SELECT EMP_NOMBRE FROM ONEFORALL.EMPRESAS";

            con.leer();
            while (con.leerReader())
            {
                cboEmpresas.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

        }
    }
}
