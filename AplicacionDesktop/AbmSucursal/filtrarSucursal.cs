using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class filtrarSucursal : Form
    {
        MenuSucursales MenuSucursales;
        public filtrarSucursal(MenuSucursales menu)
        {
            InitializeComponent();
            MenuSucursales = menu;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MenuSucursales.Show();
            this.Hide();
        }
    }
}
