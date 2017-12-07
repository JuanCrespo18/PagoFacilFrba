using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmFactura
{
    public partial class AltaFactura : Form
    {
        private string _idCliente;
        private ListarFacturas _listarFacturas;
        private char _evento;
        private string _numeroFactura;
        private List<string> _items;

        public AltaFactura(ListarFacturas listarFacturas, char evento)
        {
            InitializeComponent();
            dtpAlta.MaxDate = DateTime.Today;
            CargarEmpresas();
            _listarFacturas = listarFacturas;
            _evento = evento;
            txtTotal.Enabled = false;
        }

        public static AltaFactura Crear(ListarFacturas listarFacturas, char evento, string numeroFactura)
        {
            var abm = new AltaFactura(listarFacturas, evento)
            {
                _numeroFactura = numeroFactura
            };
            abm.CargarFactura();
            abm._items = abm.ObtenerItemsActuales();
            return abm;
        }

        private List<string> ObtenerItemsActuales()
        {
            var items = new List<string>();
            for (int i = 0; i < dgvItems.RowCount; i++)
            {
                items.Add(dgvItems.Rows[i].Cells["Id"].Value.ToString());
            }
            return items;
        }

        public void AgregarItem(string cantidad, string monto)
        {
            if (_evento == 'E')
            {
                var con = new Conexion()
                {
                    query = string.Format("INSERT INTO ONEFORALL.ITEMS VALUES ({0}, {1}, {2})", _numeroFactura, cantidad, monto.Replace(',','.'))
                };
                con.ejecutar();
                CargarFactura();
            }
            else
            {
                dgvItems.Rows.Add(new Object[] { 0, cantidad, monto });
            }

            decimal total = 0;
            foreach (DataGridViewRow item in dgvItems.Rows)
            {
                total += Convert.ToDecimal(item.Cells["Monto"].Value.ToString().Replace('.', ','));
            }
            txtTotal.Text = total.ToString();

            if(_evento == 'E')
            {
                var con = new Conexion();
                con.query = string.Format("UPDATE ONEFORALL.FACTURAS SET FACT_TOTAL = {0} WHERE FACT_ID = {1}", txtTotal.Text.Replace(',', '.'), _numeroFactura);
                con.ejecutar();
            }
        }

        private void CargarFactura()
        {
            var con = new Conexion()
            {
                query = string.Format("SELECT * FROM ONEFORALL.VISTALISTARFACTURAS WHERE FACT_ID = {0}", _numeroFactura)
            };
            con.leer();
            con.leerReader();

            txtNumeroFactura.Text = _numeroFactura;
            txtCliente.Text = con.lector.GetString(1);
            string empresa = con.lector.GetString(2);
            dtpVto.Value = con.lector.GetDateTime(3);
            dtpAlta.Value = con.lector.GetDateTime(4);
            txtTotal.Text = con.lector.GetDecimal(7).ToString();
            chkHabilitada.Checked = con.lector.GetBoolean(8);

            cboEmpresas.SelectedIndex = cboEmpresas.Items.IndexOf(empresa);
            txtNumeroFactura.ReadOnly = true;

            con.cerrarConexion();

            con.query = string.Format("SELECT FACT_CLIE_ID FROM ONEFORALL.FACTURAS WHERE FACT_ID = {0}", _numeroFactura);
            con.leer();
            con.leerReader();
            _idCliente = con.lector.GetInt32(0).ToString();
            con.cerrarConexion();

            dgvItems.Rows.Clear();
            con.query = string.Format("SELECT ITEM_ID, ITEM_CANTIDAD, ITEM_MONTO FROM ONEFORALL.ITEMS WHERE ITEM_FACT_ID = {0}", _numeroFactura);
            con.leer();
            if (con.leerReader())
            { 
                dgvItems.Rows.Add(new Object[] { con.lector.GetInt32(0), con.lector.GetDecimal(1), con.lector.GetDecimal(2)});

                while (con.leerReader())
                {
                    dgvItems.Rows.Add(new Object[] { con.lector.GetInt32(0), con.lector.GetDecimal(1), con.lector.GetDecimal(2) });
                }
            }
            con.cerrarConexion();
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
            if (_evento == 'A')
            {
                txtCliente.Text = string.Empty;
                txtNumeroFactura.Text = string.Empty;
                txtTotal.Text = string.Empty;
                cboEmpresas.ResetText();
                dtpAlta.ResetText();
                dtpVto.ResetText();
                dgvItems.Rows.Clear();
            }
            else
                CargarFactura();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Validaciones();

                var con = new Conexion();

                con.query = string.Format("SELECT EMP_ID FROM ONEFORALL.EMPRESAS WHERE EMP_NOMBRE = '{0}'", cboEmpresas.SelectedItem.ToString());
                con.leer();
                con.leerReader();
                int empresa = con.lector.GetInt32(0);
                con.cerrarConexion();

                string total = txtTotal.Text.Replace(',', '.');

                if (_evento == 'A')
                {
                    con.query = string.Format("INSERT INTO ONEFORALL.FACTURAS VALUES ({0}, {1}, {2}, CONVERT(DATETIME,'{3}',120), CONVERT(DATETIME,'{4}',120), NULL, NULL, {5}, {6})",
                        txtNumeroFactura.Text, _idCliente, empresa,
                        dtpVto.Value.ToString("yyyy-MM-dd HH:mm:ss"),dtpAlta.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                        total, Convert.ToInt16(chkHabilitada.Checked));
                    con.ejecutar();

                    for (int i = 0; i < dgvItems.RowCount; i++)
                    {
                        int cantidad = Convert.ToInt32(dgvItems.Rows[i].Cells["Cantidad"].Value);
                        decimal monto = Convert.ToDecimal(dgvItems.Rows[i].Cells["Monto"].Value.ToString().Replace('.',','));
                        con.query = string.Format("INSERT INTO ONEFORALL.ITEMS VALUES ({0}, {1}, {2})", txtNumeroFactura.Text, cantidad, monto.ToString().Replace(',','.'));
                        con.ejecutar();
                    }
                }
                else
                {
                    con.query = string.Format("UPDATE ONEFORALL.FACTURAS " +
                                "SET FACT_CLIE_ID = {0}, " +
                                "FACT_EMP_ID = {1}, " +
                                "FACT_VENCIMIENTO = CONVERT(DATETIME,'{2}',120), " +
                                "FACT_ALTA = CONVERT(DATETIME,'{3}',120), " +
                                "FACT_ACTIVA = {4} " +
                                "WHERE FACT_ID = {5}",
                                _idCliente, empresa,
                                dtpVto.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtpAlta.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                                Convert.ToInt16(chkHabilitada.Checked),
                                _numeroFactura);
                    con.ejecutar();
                }
                _listarFacturas.Limpiar();
                MessageBox.Show("Operación realizada con éxito", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _listarFacturas.Show();
                this.Close();
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

            if (dtpAlta.Value > dtpVto.Value)
                throw new Exception("La fecha de vencimiento no puede ser anterior a la del alta de la factura");

            try
            {
                Convert.ToDecimal(txtNumeroFactura.Text);
            }
            catch (Exception)
            {
                throw new Exception("El numero de factura ingresado es incorrecto, recuerde que debe contener solo números");
            }

            if (dgvItems.RowCount == 0)
                throw new Exception("La factura debe contener al menos un item");

            for (int i = 0; i < dgvItems.RowCount; i++)
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

        private void cmdAgregarItem_Click(object sender, EventArgs e)
        {
            new AgregarItem(this).Show();
        }

        private void cmdEliminarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItems.SelectedRows.Count == 0)
                    throw new Exception("Elija un item para eliminar");

                if (_evento == 'E')
                {
                    var con = new Conexion();
                    con.query = string.Format("DELETE FROM ONEFORALL.ITEMS WHERE ITEM_ID = {0}", dgvItems.SelectedRows[0].Cells["Id"].Value.ToString());
                    con.ejecutar();

                    CargarFactura();
                }
                else
                {
                    dgvItems.Rows.RemoveAt(dgvItems.SelectedRows[0].Index);
                }

                decimal total = 0;
                foreach (DataGridViewRow item in dgvItems.Rows)
                {
                    total += Convert.ToDecimal(item.Cells["Monto"].Value.ToString().Replace('.', ','));
                }
                txtTotal.Text = total.ToString();

                if(_evento == 'E')
                {
                    var con = new Conexion();
                    con.query = string.Format("UPDATE ONEFORALL.FACTURAS SET FACT_TOTAL = {0} WHERE FACT_ID = {1}", txtTotal.Text.Replace(',', '.'), _numeroFactura);
                    con.ejecutar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eliminar Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            _listarFacturas.Show();
            this.Close();
        }
    }
}
