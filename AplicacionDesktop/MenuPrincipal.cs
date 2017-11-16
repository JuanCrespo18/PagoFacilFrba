using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void cmdRoles_Click_1(object sender, EventArgs e)
        {
            new AbmRol.ListarRoles(this).Show();
            this.Hide();
        }

        private void cmdClientes_Click(object sender, EventArgs e)
        {
            new AbmCliente.ListarClientes(this).Show();
            this.Hide();
        }

        private void cmdFacturas_Click(object sender, EventArgs e)
        {
            new AbmFactura.ListarFacturas(this).Show();
            this.Hide();
        }
    }
}
