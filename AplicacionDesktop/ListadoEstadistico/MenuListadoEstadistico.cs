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
        private Reporte1 Reporte1;
        private Reporte3 Reporte3;
        private Reporte4 Reporte4;

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_Anio.Text) || string.IsNullOrEmpty(textBox_Trimestre.Text))
                    throw new Exception("Debe ingresar año y trimestre");

                if (list_Reporte.Text == "Porcentaje de facturas cobradas por empresa")
                {
                    this.Reporte1 = new Reporte1(this);
                    Reporte1.Show();
                    this.Hide();
                }
                //if(list_Reporte.Text=="Empresas con mayor monto rendido")

                if(list_Reporte.Text=="Clientes con mas pagos")
                {
                    this.Reporte3 = new Reporte3(this, textBox_Anio.Text, textBox_Trimestre.Text);
                    Reporte3.Show();
                    this.Hide();
                }

                if (list_Reporte.Text == "Clientes con mayor porcentaje de facturas pagadas (clientes cumplidores)")
                {
                    this.Reporte4 = new Reporte4(this, textBox_Anio.Text, textBox_Trimestre.Text);
                    Reporte4.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
