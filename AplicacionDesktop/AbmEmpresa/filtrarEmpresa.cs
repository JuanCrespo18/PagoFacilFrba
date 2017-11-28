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
    public partial class filtrarEmpresa : Form
    {
        MenuEmpresas menuEmpresas;

        public filtrarEmpresa(MenuEmpresas menu)
        {
            InitializeComponent();
            menuEmpresas = menu;
            listaEmpresas.Columns.Add("id", "id");
            listaEmpresas.Columns.Add("", "Cuit");
            listaEmpresas.Columns.Add("", "Razon Social");
            listaEmpresas.Columns.Add("", "Dir_id");
            listaEmpresas.Columns.Add("", "Rub_id");
            listaEmpresas.Columns.Add("activa", "Habilitada");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            menuEmpresas.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender,EventArgs e)
        {
            this.listaEmpresas.DataSource = null;
            this.listaEmpresas.Rows.Clear();

            string squery = "SELECT * FROM ONEFORALL.EMPRESAS WHERE 1 = 1";

            if (!string.IsNullOrEmpty(razonSocial.Text))
            {
                squery += " and EMP_NOMBRE LIKE '%" + razonSocial.Text + "%'";
            }
            if (!string.IsNullOrEmpty(cuit.Text))
            {
                squery += " and EMP_CUIT LIKE '%" + cuit.Text + "%'";
            }

            //rubro.GetItemText;
            //if (!string.IsNullOrEmpty(rubro.GetItemText)
            //{
            //    squery += " and EMP_RUB_ID = '" + rubro.GetItemText + "'";
            //}
            var con = new Conexion(){query = squery};
            con.leer();

            if (!con.leerReader())
            {
                MessageBox.Show("No se encontro ninguna Empresa", "Filtro Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                listaEmpresas.Rows.Add(con.lector.GetInt32(0), con.lector.GetString(1), con.lector.GetString(2), con.lector.GetString(3), con.lector.GetString(6),con.lector.GetBoolean(7));
                while (con.leerReader())
                {
                    listaEmpresas.Rows.Add(con.lector.GetInt32(0), con.lector.GetString(1), con.lector.GetString(2), con.lector.GetString(3), con.lector.GetString(6),con.lector.GetBoolean(7));
                }
            }
            CargarColumnaModificacion();
            listaEmpresas.Columns["id"].Visible = false;
            listaEmpresas.Columns["activa"].Visible = false;
            listaEmpresas.AllowUserToAddRows = false;
        }

        private void CargarColumnaModificacion()
        {
            if (listaEmpresas.Columns.Contains("Modificar"))
                listaEmpresas.Columns.Remove("Modificar");
            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            listaEmpresas.Columns.Add(botonColumnaModificar);
        }

        private void listaSucursales_celda_Click(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == listaEmpresas.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                String _idEmpresa = listaEmpresas.Rows[e.RowIndex].Cells["id"].Value.ToString();
                new editarEmpresa(_idEmpresa, this).ShowDialog();
                return;
            }
        }

       private void btnLimpiar_Click(object sender, EventArgs e) {
                razonSocial.Clear();
                cuit.Clear();
        }

        public void refresh() {
            this.btnBuscar_Click(null,null);
        }

    }
}
