using PagoAgilFrba.Dto;
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
        List<EmpresaDto> empresas { set; get; }

        public filtrarEmpresa(MenuEmpresas menu)
        {
            InitializeComponent();
            this.empresas = new List<EmpresaDto>();
            menuEmpresas = menu;
            cargarRubros();
            listaEmpresas.Columns.Add("id", "id");
            listaEmpresas.Columns.Add("", "Razon Social");
            listaEmpresas.Columns.Add("", "Cuit");
            listaEmpresas.Columns.Add("", "Rubro");
            listaEmpresas.Columns.Add("", "Direccion");
            listaEmpresas.Columns.Add("", "Cod postal");
            listaEmpresas.Columns.Add("", "Localidad");
            listaEmpresas.Columns.Add("activa", "Habilitada");
        }

        private void cargarRubros()
        {
            rubro.Items.Clear();
            var squery = "SELECT DISTINCT(RUB_DESCRIPCION) FROM ONEFORALL.RUBROS";
            var con = new Conexion() { query = squery };
            con.leer();
            while (con.leerReader())
            {
                rubro.Items.Add(con.lector.GetString(0));
            }

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

            string squery = string.Format("SELECT e.EMP_ID,e.EMP_NOMBRE, e.EMP_CUIT, e.EMP_RUB_ID, r.RUB_DESCRIPCION,d.DIR_ID, d.DIR_DIRECCION,d.DIR_CODIGO_POSTAL,d.DIR_PISO,d.DIR_DEPARTAMENTO,d.DIR_LOCALIDAD,e.EMP_ACTIVA from ONEFORALL.EMPRESAS e JOIN ONEFORALL.RUBROS r ON e.EMP_RUB_ID = r.RUB_ID JOIN ONEFORALL.DIRECCIONES d ON d.DIR_ID = e.EMP_DIR_ID WHERE 1=1 ");

            if (!string.IsNullOrEmpty(razonSocial.Text))
            {
                squery += " and e.EMP_NOMBRE LIKE '%" + razonSocial.Text + "%' ";
            }

            if (tieneCuitIncompleto()) {
                MessageBox.Show("El Cuit debe estar completo", "filtrar Empresas",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(cuit1.Text) && !string.IsNullOrEmpty(cuit2.Text) & !string.IsNullOrEmpty(cuit3.Text))
            {
                squery += " and e.EMP_CUIT = '" + cuit1.Text +"-"+cuit2.Text+"-"+cuit3.Text+"' ";
            }
            if (rubro.SelectedItem != null && !string.IsNullOrEmpty(rubro.SelectedItem.ToString())) {

                squery += " and r.RUB_DESCRIPCION LIKE '%" + rubro.SelectedItem.ToString() + "%'";
            }

            var con = new Conexion(){query = squery};
            con.leer();

            if (!con.leerReader())
            {
                MessageBox.Show("No se encontro ninguna Empresa", "Filtro Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {

                listaEmpresas.Rows.Add(con.lector.GetInt32(0),
                                        con.lector.GetString(1),
                                        con.lector.GetString(2),
                                        con.lector.GetString(4),
                                        con.lector.GetString(6),
                                        con.lector.GetString(7),
                                        con.lector.GetString(10),
                                        con.lector.GetBoolean(11));
                while (con.leerReader())
                {

                    listaEmpresas.Rows.Add(con.lector.GetInt32(0),
                                        con.lector.GetString(1),
                                        con.lector.GetString(2),
                                        con.lector.GetString(4),
                                        con.lector.GetString(6),
                                        con.lector.GetString(7),
                                        con.lector.GetString(10),
                                        con.lector.GetBoolean(11));
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
            if (!SesionUsuario.usuario.funcionalidades.Exists(f => f.Equals("Modificar Empresa")))
                botonColumnaModificar.Visible = false;

            listaEmpresas.Columns.Add(botonColumnaModificar);
        }

        private void listaEmpresa_celda_Click(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == listaEmpresas.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                String idEmpresa = listaEmpresas.Rows[e.RowIndex].Cells["id"].Value.ToString();

                new editarEmpresa(idEmpresa, this).ShowDialog();
                return;
            }
        }

       private void btnLimpiar_Click(object sender, EventArgs e) {
                razonSocial.Clear();
                cuit1.Clear();
                rubro.SelectedItem = null;
                listaEmpresas.Rows.Clear();
        }

        public void refresh() {
            this.btnBuscar_Click(null,null);
        }

        public void rubro_SelectedIndexChanged(object sender, EventArgs e) {

            

        }

        private bool tieneCuitIncompleto()
        {
            if (!string.IsNullOrEmpty(cuit1.Text)) {
                if (string.IsNullOrEmpty(cuit2.Text) || string.IsNullOrEmpty(cuit3.Text))
                    return true;
            }
            if (!string.IsNullOrEmpty(cuit2.Text))
            {
                if (string.IsNullOrEmpty(cuit1.Text) || string.IsNullOrEmpty(cuit3.Text))
                    return true;
            }
            if (!string.IsNullOrEmpty(cuit3.Text))
            {
                if (string.IsNullOrEmpty(cuit1.Text) || string.IsNullOrEmpty(cuit2.Text))
                    return true;
            }
            return false;
        }

        private void onlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
