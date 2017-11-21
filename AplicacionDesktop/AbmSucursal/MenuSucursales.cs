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
    public partial class MenuSucursales : Form
    {
        private MenuPrincipal menuPrincipal;

        public MenuSucursales(MenuPrincipal menu)
        {
            InitializeComponent();
            menuPrincipal = menu;
        }

        private void btnMenuPral_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuPrincipal.Show();
        }
        private void btnBuscarEditar_Click(object sender, EventArgs e)
        {
            new AbmSucursal.filtrarSucursal().Show();
            this.Hide();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AbmSucursal.agregarSucursal().Show();
            this.Hide();
        }
    }
}
