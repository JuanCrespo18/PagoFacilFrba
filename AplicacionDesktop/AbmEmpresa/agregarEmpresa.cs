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
    public partial class agregarEmpresa : Form
    {
        MenuEmpresas menuEmpresas;
        public agregarEmpresa(MenuEmpresas menu)
        {
            InitializeComponent();
            menuEmpresas = menu;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            menuEmpresas.Show();
            this.Hide();
        }
    }
}
