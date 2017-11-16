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
        private ListarFacturas _listarFacturas;
        private char _evento;
        private string _numeroFactura;

        public AltaFactura(ListarFacturas listarFacturas, char evento)
        {
            InitializeComponent();
            CargarEmpresas();
            _listarFacturas = listarFacturas;
            _evento = evento;
        }

        public static AltaFactura Crear(ListarFacturas listarFacturas, char evento, string numeroFactura)
        {
            var abm = new AltaFactura(listarFacturas, evento)
            {
                _numeroFactura = numeroFactura
            };
            abm.CargarFactura();
            return abm;
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

            cboEmpresas.SelectedIndex = cboEmpresas.Items.IndexOf(empresa);
            txtNumeroFactura.ReadOnly = true;

            con.cerrarConexion();

            con.query = string.Format("SELECT FACT_CLIE_ID FROM ONEFORALL.FACTURAS WHERE FACT_ID = {0}", _numeroFactura);
            con.leer();
            con.leerReader();
            _idCliente = con.lector.GetInt32(0).ToString();
            con.cerrarConexion();

            dgvItems.Rows.Clear();
            con.query = string.Format("SELECT ITEM_CANTIDAD, ITEM_MONTO FROM ONEFORALL.ITEMS WHERE ITEM_FACT_ID = {0}", _numeroFactura);
            con.leer();
            if (con.leerReader())
            { 
                dgvItems.Rows.Add(new Object[] {con.lector.GetDecimal(0), con.lector.GetDecimal(1)});

                while (con.leerReader())
                {
                    dgvItems.Rows.Add(new Object[] { con.lector.GetDecimal(0), con.lector.GetDecimal(1) });
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

                if(_evento == 'A')
                {
                    var con = new Conexion();

                    con.query = string.Format("SELECT EMP_ID FROM ONEFORALL.EMPRESAS WHERE EMP_NOMBRE = '{0}'", cboEmpresas.SelectedItem.ToString());
                    con.leer();
                    con.leerReader();
                    int empresa = con.lector.GetInt32(0);
                    con.cerrarConexion();

                    con.query = string.Format("INSERT INTO ONEFORALL.FACTURAS VALUES ({0}, {1}, {2}, '{3}', '{4}', NULL, NULL, {5})",
                        txtNumeroFactura.Text, _idCliente, empresa,
                        dtpVto.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtpAlta.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                        txtTotal.Text);
                    con.ejecutar();

                    for (int i = 0; i < dgvItems.RowCount - 1; i++)
                    {
                        int cantidad = Convert.ToInt32(dgvItems.Rows[i].Cells["Cantidad"].Value);
                        int monto = Convert.ToInt32(dgvItems.Rows[i].Cells["Monto"].Value);
                        con.query = string.Format("INSERT INTO ONEFORALL.ITEMS VALUES ({0}, {1}, {2})", txtNumeroFactura.Text, cantidad, monto);
                        con.ejecutar();
                    }
                }
                else
                {
                    throw new NotImplementedException();
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
