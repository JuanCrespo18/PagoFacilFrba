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
            if (!SesionUsuario.usuario.funcionalidades.Exists(f => f.Equals("Agregar Sucursal")))
                btnAgregar.Enabled = false;
        }

        private void btnMenuPral_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuPrincipal.Show();
        }
        private void btnBuscarEditar_Click(object sender, EventArgs e)
        {
            new AbmSucursal.filtrarSucursal(this).Show();
            this.Hide();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AbmSucursal.agregarSucursal(this).Show();
            this.Hide();
        }
    }
}
