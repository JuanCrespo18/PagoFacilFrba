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
    public partial class AltaFactura : Form
    {
        private string _idCliente;
        private MenuPrincipal _menuPrincipal;

        public AltaFactura(MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            CargarEmpresas();
            this._menuPrincipal = menuPrincipal;
        }

        private void cmdBuscarCliente_Click(object sender, EventArgs e)
        {
            new AbmCliente.ListarClientes(this).Show();
            this.Hide();
        }

        public void CargarCliente(string idCliente, string cliente)
        {
            _idCliente = idCliente;
            txtCliente.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(cliente.ToLower());;
        }

        private void CargarEmpresas()
        {
            cboEmpresas.Items.Clear();
            Conexion con = new Conexion();
            con.query = "SELECT EMP_NOMBRE FROM ONEFORALL.EMPRESAS";

            con.leer();
            while (con.leerReader())
            {
                cboEmpresas.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            txtCliente.Text = string.Empty;
            txtNumeroFactura.Text = string.Empty;
            txtTotal.Text = string.Empty;
            cboEmpresas.ResetText();
            dtpAlta.ResetText();
            dtpVto.ResetText();
            dgvItems.Rows.Clear();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Validaciones();

                var con = new Conexion();

                con.query = string.Format("INSERT INTO ONEFORALL.FACTURAS VALUES ({0}, {1}, '{2}', '{3}', NULL, NULL, {4})",
                    txtNumeroFactura.Text, _idCliente, dtpVto.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtpAlta.Value.ToString("yyyy-MM-dd HH:mm:ss"), txtTotal.Text);
                con.ejecutar();

                for (int i = 0; i < dgvItems.RowCount - 1; i++)
                {
                    int cantidad = Convert.ToInt32(dgvItems.Rows[i].Cells["Cantidad"].Value);
                    int monto = Convert.ToInt32(dgvItems.Rows[i].Cells["Monto"].Value);
                    con.query = string.Format("INSERT INTO ONEFORALL.ITEMS VALUES ({0}, {1}, {2})", txtNumeroFactura.Text, cantidad, monto);
                    con.ejecutar();
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY"))
                    MessageBox.Show("La factura con ese número ya se encuentra en la base", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Validaciones()
        {
            if (string.IsNullOrEmpty(txtCliente.Text))
                throw new Exception("Debe elegir un cliente");

            if (cboEmpresas.SelectedIndex == -1)
                throw new Exception("Debe elegir una empresa");

            if (string.IsNullOrEmpty(txtNumeroFactura.Text))
                throw new Exception("Debe ingresar el numero de la factura");

            if (string.IsNullOrEmpty(txtTotal.Text))
                throw new Exception("Debe ingresar el total");
            
            try
            {
                Convert.ToDecimal(txtTotal.Text);
            }
            catch (Exception)
            {
                throw new Exception("El total ingresado es incorrecto, recuerde que debe ser un número decimal");
            }

            try
            {
                Convert.ToDecimal(txtNumeroFactura.Text);
            }
            catch (Exception)
            {
                throw new Exception("El numero de factura ingresado es incorrecto, recuerde que debe contener solo números");
            }

            if (dgvItems.Rows.Count == 1)
                throw new Exception("La factura debe contener al menos un item");

            for (int i = 0; i < dgvItems.Rows.Count - 1; i++)
            {
                for (int x = 0; x < dgvItems.Rows[i].Cells.Count; x++)
                {
                    if (dgvItems.Rows[i].Cells[x].Value == null || dgvItems.Rows[i].Cells[x].Value == DBNull.Value || String.IsNullOrWhiteSpace(dgvItems.Rows[i].Cells[x].Value.ToString()))
                    {
                        throw new Exception("Debe completar todas los valores de cada item");
                    }
                }
            }
        }
    }
}
