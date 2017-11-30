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
    public partial class MenuEmpresas : Form
    {
        MenuPrincipal menuPrincipal;

        public MenuEmpresas(MenuPrincipal menu)
        {
            InitializeComponent();
            menuPrincipal = menu;
            if (!SesionUsuario.usuario.funcionalidades.Exists(f => f.Equals("Agregar Empresas")))
                btnAgregar.Enabled = false;
        }

        private void MenuEmpresas_Load(object sender, EventArgs e)
        {

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AbmEmpresa.agregarEmpresa(this).Show();
            this.Hide();
        }
        private void btnBuscarEditar_Click(object sender, EventArgs e)
        {
            new AbmEmpresa.filtrarEmpresa(this).Show();
            this.Hide();
        }

        private void btnMenuPral_Click(object sender, EventArgs e)
        {
            menuPrincipal.Show();
            this.Hide();
        }
    }
}
