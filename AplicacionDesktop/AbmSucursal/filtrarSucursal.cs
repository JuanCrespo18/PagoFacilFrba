using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class filtrarSucursal : Form
    {
        MenuSucursales MenuSucursales;
        public filtrarSucursal(MenuSucursales menu)
        {
            InitializeComponent();
            MenuSucursales = menu;
            listaSucursales.Columns.Add("", "Nombre");
            listaSucursales.Columns.Add("", "Direccion");
            listaSucursales.Columns.Add("", "Cod Postal");
            listaSucursales.Columns.Add("", "Localidad");
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MenuSucursales.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender,EventArgs e)
        {
            this.listaSucursales.DataSource = null;
            this.listaSucursales.Rows.Clear();

            string squery = "SELECT * FROM ONEFORALL.VW_SUCURSALES WHERE 1 = 1";

            if(!string.IsNullOrEmpty(nombre.Text))
            {
                squery += " and NOMBRE LIKE '%"+ nombre.Text +"%'";
            }
            if (!string.IsNullOrEmpty(direccion.Text))
            {
                squery += " and DIRECCION LIKE '%" + direccion.Text + "%'";
            }
            if (!string.IsNullOrEmpty(codPostal.Text))
            {
                squery += " and CP = '" + codPostal.Text + "'";
            }
            var con = new Conexion(){query = squery};
            con.leer();

            if (!con.leerReader())
            {
                MessageBox.Show("No se encontro ninguna Sucursal", "Filtro Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                listaSucursales.Rows.Add(con.lector.GetString(0), con.lector.GetString(1), con.lector.GetString(2), con.lector.GetString(3));
                while (con.leerReader())
                {
                    listaSucursales.Rows.Add(con.lector.GetString(0), con.lector.GetString(1), con.lector.GetString(2), con.lector.GetString(3));
                }
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e) {
            nombre.Text = "";
            direccion.Text = "";
            codPostal.Text = "";
        }
    }
}
