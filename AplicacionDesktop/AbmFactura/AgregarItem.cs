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
    public partial class AgregarItem : Form
    {
        private AltaFactura _altaFactura;
        
        public AgregarItem(AltaFactura altaFactura)
        {
            InitializeComponent();
            _altaFactura = altaFactura;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCantidad.Text) || string.IsNullOrEmpty(txtMonto.Text))
                    throw new Exception("Por favor complete los dos campos");

                string monto = txtMonto.Text.Replace(',', '.');

                _altaFactura.AgregarItem(txtCantidad.Text, monto);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Agregar Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
