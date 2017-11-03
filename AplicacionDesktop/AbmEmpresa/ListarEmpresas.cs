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
    public partial class ListarEmpresas : Form
    {
        private MenuPrincipal _menuPrincipal;
        private CrearEditarEmpresa _crearEditarEmpresa;

        public ListarEmpresas(MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            _menuPrincipal = menuPrincipal;
            cmdEditar.Text = "Agregar";
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            BuscarEmpresas();
        }

        private void BuscarEmpresas()
        {
            dgvEmpresas.Rows.Clear();

            string query = "SELECT EMP_CUIT,EMP_NOMBRE,DIR_DIRECCION,RUB_DESCRIPCION,EMP_ACTIVA FROM ONEFORALL.Empresas  "+
	                        "LEFT JOIN ONEFORALL.RUBROS ON EMP_RUB_ID = RUB_ID"+
                            "LEFT JOIN ONEFORALL.DIRECCIONES ON DIR_ID = EMP_DIR_ID"+
	                        "WHERE 1 = 1";

            if (!string.IsNullOrEmpty(txtCuit.Text))
                query += string.Format("AND EMP_CUIT LIKE '%{0}%'", txtCuit.Text);

            if (!string.IsNullOrEmpty(txtNombreEmp.Text))
                query += string.Format("AND EMP_NOMBRE LIKE '%{0}%'", txtNombreEmp.Text);

            if (!string.IsNullOrEmpty(txtRubro.Text))
                query += string.Format("AND RUB_DESCRIPCION LIKE '%{0}%'", txtRubro.Text);

            var con = new Conexion()
            {
                query = query
            };
            con.leer();
            if (!con.leerReader())
            {
                cmdEditar.Text = "Agregar";
                MessageBox.Show("La busqueda no produjo ningún resultado", "Filtrar Empresas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                dgvEmpresas.Rows.Add(new Object[] {con.lector.GetInt32(0), con.lector.GetString(1), con.lector.GetString(2),
                                   con.lector.GetDateTime(3), con.lector.GetString(5), con.lector.GetString(6), con.lector.GetBoolean(7)});

                while (con.leerReader())
                {
                    dgvEmpresas.Rows.Add(new Object[] {con.lector.GetInt32(0), con.lector.GetString(1), con.lector.GetString(2),
                                   con.lector.GetDateTime(3), con.lector.GetString(5), con.lector.GetString(6), con.lector.GetBoolean(7)});

                }
                dgvEmpresas.Sort(dgvEmpresas.Columns[0], ListSortDirection.Ascending);
                cmdEditar.Text = "Editar";
            }
        }

        private void cmdLimpiarEmp_Click(object sender, EventArgs e)
        {
            dgvEmpresas.Rows.Clear();
            txtCuit.Clear();
            txtRubro.Clear();
            txtNombreEmp.Clear();
            cmdEditar.Text = "Agregar";
        }

        private void cmdMenu_Click(object sender, EventArgs e)
        {
            _menuPrincipal.Show();
            this.Close();
        }

        private void dgvEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdEditar.Text = "Editar";
        }

        private void cmdEditar_Click(object sender, EventArgs e)
        {
            if (cmdEditar.Text == "Agregar")
            {
                _crearEditarEmpresa = new CrearEditarEmpresa(this, cmdEditar.Text[0]);
            }
            else
                _crearEditarEmpresa = CrearEditarEmpresa.Crear(this, cmdEditar.Text[0], dgvEmpresas.SelectedRows[0].Cells["Id"].Value.ToString());

            _crearEditarEmpresa.Show();
            this.Hide();
        }

        public void Actualizar()
        {
            BuscarEmpresas();
        }
    }
}
