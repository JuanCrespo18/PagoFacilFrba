using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.RegistroPago
{
    public partial class RegistroPago : Form
    {
        private MenuPrincipal _menuPrincipal;

        public RegistroPago(MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            _menuPrincipal = menuPrincipal;
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            new AbmFactura.ListarFacturas(this).Show();
            this.Hide();
        }

        public void CargarFactura(string numeroFactura)
        {
            bool contiene = false;
            foreach(DataGridViewRow factura in dgvFacturas.Rows)
            {
                if(factura.Cells["Numero"].Value.ToString() == numeroFactura)
                    contiene = true;
            }

            if (contiene)
                throw new Exception("Esa factura ya ha sido seleccionada");

            var con = new Conexion();
            con.query = string.Format("SELECT FACT_ID, FACT_CLIE, FACT_EMP, FACT_VENCIMIENTO, FACT_TOTAL FROM ONEFORALL.VISTALISTARFACTURAS " +
                "WHERE FACT_ID = {0}", numeroFactura);
            con.leer();
            con.leerReader();

            dgvFacturas.Rows.Add(new Object[] {con.lector.GetDecimal(0), con.lector.GetString(1), con.lector.GetString(2),
                                   con.lector.GetDateTime(3), con.lector.GetDecimal(4)});

            con.cerrarConexion();
        }

        private void cmdQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFacturas.SelectedRows.Count == 0)
                    throw new Exception("Seleccione la factura a quitar");

                dgvFacturas.Rows.RemoveAt(dgvFacturas.SelectedRows[0].Index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quitar Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdLimpiarFacturas_Click(object sender, EventArgs e)
        {
            dgvFacturas.Rows.Clear();
        }

        private void cmdPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFacturas.RowCount == 0)
                    throw new Exception("Debe agregar facturas para registrar el pago");
                if (cboMetodosPago.SelectedIndex == -1)
                    throw new Exception("Debe seleccionar un método de pago");

                foreach(DataGridViewRow factura in dgvFacturas.Rows)
                {
                    var con = new Conexion();

                    con.query = string.Format("SELECT FACT_CLIE_ID FROM ONEFORALL.FACTURAS WHERE FACT_ID = {0}", factura.Cells["Numero"].Value.ToString());
                    con.leer();
                    con.leerReader();
                    int idCliente = con.lector.GetInt32(0);
                    con.cerrarConexion();

                    con.query = string.Format("INSERT INTO ONEFORALL.PAGOS VALUES ('{0}', {1}, '{2}', {3}, {4}, {5})",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        factura.Cells["Total"].Value.ToString().Replace(',', '.'),
                        cboMetodosPago.SelectedItem.ToString(),
                        idCliente,
                        SesionUsuario.user.id, 
                        SesionUsuario.user.sucursal); 
                    con.ejecutar();
                }
                MessageBox.Show("Pago realizado con éxito", "Devolver facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pagar facturas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdMenu_Click(object sender, EventArgs e)
        {
            _menuPrincipal.Show();
            this.Close();
        }
    }
}
