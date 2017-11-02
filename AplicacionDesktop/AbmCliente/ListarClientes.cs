using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class ListarClientes : Form
    {
        private MenuPrincipal _menuPrincipal;
        private CrearEditarCliente _crearEditarCliente;

        public ListarClientes(MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            _menuPrincipal = menuPrincipal;
            cmdEditar.Text = "Agregar";
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            BuscarClientes();
        }

        private void BuscarClientes()
        {
            dgvClientes.Rows.Clear();

            string query = "SELECT * FROM ONEFORALL.CLIENTES WHERE 1 = 1";

            if (!string.IsNullOrEmpty(txtApellido.Text))
                query += string.Format("AND CLIE_APELLIDO LIKE '%{0}%'", txtApellido.Text);

            if (!string.IsNullOrEmpty(txtNombre.Text))
                query += string.Format("AND CLIE_NOMBRE LIKE '%{0}%'", txtNombre.Text);

            if (!string.IsNullOrEmpty(txtDni.Text))
                query += string.Format("AND CLIE_DNI LIKE '%{0}%'", txtDni.Text);

            var con = new Conexion()
            {
                query = query
            };
            con.leer();
            if (!con.leerReader())
            {
                cmdEditar.Text = "Agregar";
                MessageBox.Show("La busqueda no produjo ningún resultado", "Filtrar clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                dgvClientes.Rows.Add(new Object[] {con.lector.GetInt32(0), con.lector.GetString(1), con.lector.GetString(2),
                                   con.lector.GetDateTime(3), con.lector.GetString(5), con.lector.GetString(6), con.lector.GetBoolean(7)});

                while (con.leerReader())
                {
                    dgvClientes.Rows.Add(new Object[] {con.lector.GetInt32(0), con.lector.GetString(1), con.lector.GetString(2),
                                   con.lector.GetDateTime(3), con.lector.GetString(5), con.lector.GetString(6), con.lector.GetBoolean(7)});

                }
                dgvClientes.Sort(dgvClientes.Columns[0], ListSortDirection.Ascending);
                cmdEditar.Text = "Editar";
            }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            dgvClientes.Rows.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtNombre.Clear();
            cmdEditar.Text = "Agregar";
        }

        private void cmdMenu_Click(object sender, EventArgs e)
        {
            _menuPrincipal.Show();
            this.Close();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdEditar.Text = "Editar";
        }

        private void cmdEditar_Click(object sender, EventArgs e)
        {
            if (cmdEditar.Text == "Agregar")
            {
                _crearEditarCliente = new CrearEditarCliente(this, cmdEditar.Text[0]);
            }
            else
                _crearEditarCliente = CrearEditarCliente.Crear(this, cmdEditar.Text[0], dgvClientes.SelectedRows[0].Cells["Id"].Value.ToString());

            _crearEditarCliente.Show();
            this.Hide();
        }

        public void Actualizar()
        {
            BuscarClientes();
        }
    }
}
