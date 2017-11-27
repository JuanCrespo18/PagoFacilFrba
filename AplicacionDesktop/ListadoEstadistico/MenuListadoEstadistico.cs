using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class MenuListadoEstadistico : Form
    {
        
        MenuPrincipal menuPrincipal;

        public MenuListadoEstadistico(MenuPrincipal menu)
        {
            InitializeComponent();
            menuPrincipal = menu;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnMenuPral_Click(object sender, EventArgs e)
        {
            menuPrincipal.Show();
            this.Hide();
        }
    }

}
