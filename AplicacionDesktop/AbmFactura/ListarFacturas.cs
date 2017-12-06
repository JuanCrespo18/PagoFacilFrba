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
        private RegistroPago.RegistroPago _registroPago;
        private Devoluciones.Devoluciones _devoluciones;
        private char _evento;
        private char _tipoDev;

        public ListarFacturas(MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            CargarEmpresas();
            _menuPrincipal = menuPrincipal;
            cmdEditar.Text = "Agregar";
            _evento = 'E';
            cmdCancelar.Hide();
        }

        public ListarFacturas(RegistroPago.RegistroPago registroPago)
        {
            InitializeComponent();
            CargarEmpresas();
            _registroPago = registroPago;
            _evento = 'P';
            cmdEditar.Text = "Seleccionar";
            cmdMenu.Hide();
            cmdCancelar.Show();
        }

        public ListarFacturas(Devoluciones.Devoluciones devoluciones, char tipoDev)
        {
            InitializeComponent();
            CargarEmpresas();
            _devoluciones = devoluciones;
            _evento = 'D';
            _tipoDev = tipoDev;
            cmdEditar.Text = "Seleccionar";
            cmdMenu.Hide();
            cmdCancelar.Hide();
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
            Limpiar();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            dgvFacturas.Rows.Clear();

            string query = "SELECT * FROM ONEFORALL.VistaListarFacturas WHERE 1 = 1 ";

            if (!string.IsNullOrEmpty(txtCliente.Text))
                query += string.Format("AND FACT_CLIE = '{0}'", txtCliente.Text);

            if (cboEmpresas.SelectedIndex != -1)
                query += string.Format("AND FACT_EMP = '{0}'", cboEmpresas.SelectedItem.ToString());

            if (!string.IsNullOrEmpty(txtNumeroFactura.Text))
                query += string.Format("AND FACT_ID = {0}", txtNumeroFactura.Text);

            if (_evento == 'P')
                query += "AND FACT_REND_ID IS NULL AND FACT_PAGO_ID IS NULL AND FACT_ACTIVA = 1 AND EMP_ACTIVA = 1";

            if(_evento == 'D')
            {
                if (_tipoDev == 'P')
                    query += "AND FACT_REND_ID IS NULL AND FACT_PAGO_ID IS NOT NULL";
                else
                    query += "AND FACT_REND_ID IS NOT NULL";
            }

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
                                   con.lector.GetDateTime(3), con.lector.GetDateTime(4), con.lector.GetDecimal(7),
                                    !con.lector.IsDBNull(6),
                                    !con.lector.IsDBNull(5),
                                    con.lector.GetBoolean(8)});

                while (con.leerReader())
                {
                    dgvFacturas.Rows.Add(new Object[] {con.lector.GetDecimal(0), con.lector.GetString(1), con.lector.GetString(2),
                                   con.lector.GetDateTime(3), con.lector.GetDateTime(4), con.lector.GetDecimal(7),
                                    !con.lector.IsDBNull(6),
                                    !con.lector.IsDBNull(5),
                                    con.lector.GetBoolean(8)});
                }
                dgvFacturas.Sort(dgvFacturas.Columns[0], ListSortDirection.Ascending);

                if (cmdEditar.Text != "Seleccionar")
                    cmdEditar.Text = "Editar";
            }

            if (cmdEditar.Text.Equals("Editar"))
                if (!SesionUsuario.usuario.funcionalidades.Exists(f => f.Equals("Modificar Factura")))
                {
                    cmdEditar.Enabled = false;
                }

            con.cerrarConexion();
        }

        private void cmdEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if(_evento == 'E')
                {
                    if (cmdEditar.Text == "Agregar")
                        _altaFactura = new AltaFactura(this, 'A');
                    else
                    {
                        if (Convert.ToBoolean(dgvFacturas.SelectedRows[0].Cells["Pago"].Value))
                            throw new Exception("Esa pagada ya se encuentra pagada, no se puede editar");

                        _altaFactura = AltaFactura.Crear(this, 'E', dgvFacturas.SelectedRows[0].Cells["Numero"].Value.ToString());
                    }
                    _altaFactura.Show();
                    this.Hide();
                }
                else 
                {
                    if (dgvFacturas.SelectedRows.Count == 0)
                        throw new Exception("Seleccione una factura en la grilla");
                    if (_evento == 'P')
                    {
                        _registroPago.CargarFactura(dgvFacturas.SelectedRows[0].Cells["Numero"].Value.ToString());
                        _registroPago.Show();
                        this.Close();
                    }
                    else
                    {
                        _devoluciones.CargarFactura(dgvFacturas.SelectedRows[0].Cells["Numero"].Value.ToString());
                        _devoluciones.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Listar Facturas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void Limpiar()
        {
            txtCliente.Clear();
            cboEmpresas.SelectedIndex = -1;
            txtNumeroFactura.Clear();
            if(cmdEditar.Text == "Editar")
                cmdEditar.Text = "Agregar";
            dgvFacturas.Rows.Clear();
        }

        private void cmdMenu_Click(object sender, EventArgs e)
        {
            _menuPrincipal.Show();
            this.Close();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            _registroPago.Show();
            this.Close();
        }
    }
}
