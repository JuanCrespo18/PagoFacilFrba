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
    public partial class ListarFacturas : Form
    {
        private MenuPrincipal _menuPrincipal;
        private AltaFactura _altaFactura;

        public ListarFacturas(MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            CargarEmpresas();
            _menuPrincipal = menuPrincipal;
            cmdEditar.Text = "Agregar";
        }

        private void cmdBuscarCliente_Click(object sender, EventArgs e)
        {
            new AbmCliente.ListarClientes(this).Show();
            this.Hide();
        }

        public void CargarCliente(string idCliente, string cliente)
        {
            txtCliente.Text = cliente;
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
            txtCliente.Clear();
            cboEmpresas.SelectedIndex = -1;
            cmdEditar.Text = "Agregar";
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            dgvFacturas.Rows.Clear();

            string query = "SELECT * FROM ONEFORALL.VistaListarFacturas WHERE FACT_REND_ID IS NULL AND FACT_PAGO_ID IS NULL ";

            if (!string.IsNullOrEmpty(txtCliente.Text))
                query += string.Format("AND FACT_CLIE = '{0}'", txtCliente.Text);

            if (cboEmpresas.SelectedIndex != -1)
                query += string.Format("AND FACT_EMP = '{0}'", cboEmpresas.SelectedItem.ToString());

            var con = new Conexion()
            {
                query = query
            };
            con.leer();
            if (!con.leerReader())
            {
                cmdEditar.Text = "Agregar";
                MessageBox.Show("La busqueda no produjo ningún resultado", "Filtrar facturas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                dgvFacturas.Rows.Add(new Object[] {con.lector.GetDecimal(0), con.lector.GetString(1), con.lector.GetString(2),
                                   con.lector.GetDateTime(3), con.lector.GetDateTime(4), con.lector.GetDecimal(7)});

                while (con.leerReader())
                {
                    dgvFacturas.Rows.Add(new Object[] {con.lector.GetDecimal(0), con.lector.GetString(1), con.lector.GetString(2),
                                   con.lector.GetDateTime(3), con.lector.GetDateTime(4), con.lector.GetDecimal(7)});

                }
                dgvFacturas.Sort(dgvFacturas.Columns[0], ListSortDirection.Ascending);

                if (cmdEditar.Text != "Seleccionar")
                    cmdEditar.Text = "Editar";
            }
            con.cerrarConexion();
        }

        private void cmdEditar_Click(object sender, EventArgs e)
        {
            if (cmdEditar.Text == "Agregar")
                _altaFactura = new AltaFactura(this, 'A');
            else
                _altaFactura = AltaFactura.Crear(this, 'E', dgvFacturas.SelectedRows[0].Cells["Numero"].Value.ToString());

            _altaFactura.Show();
            this.Hide();
        }
    }
}
