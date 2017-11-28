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
    public partial class agregarSucursal : Form
    {
        MenuSucursales menuSucursal;

        public agregarSucursal(MenuSucursales menu)
        {
            InitializeComponent();
            menuSucursal = menu;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            menuSucursal.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nombre.Text) && !string.IsNullOrEmpty(direccion.Text) && !string.IsNullOrEmpty(codPostal.Text) && !string.IsNullOrEmpty(localidad.Text))
            {
                try
                {
                    string insertarDir = "INSERT INTO ONEFORALL.DIRECCIONES VALUES('" + direccion.Text +"','"+ codPostal.Text+"'";
                    string insertarSuc = "INSERT INTO ONEFORALL.SUCURSALES VALUES(";

                    if (string.IsNullOrEmpty(piso.Text)) {
                        insertarDir += ", null";
                    }
                    else {
                        insertarDir += ", '" + piso.Text+"'";
                    }
                    if (string.IsNullOrEmpty(departamento.Text))
                    {
                        insertarDir += ", null";
                    }
                    else {
                        insertarDir += ", '" + departamento.Text+"'";
                    }
                    insertarDir += ", '" + campoLocalidad.Text + "');" ;
                    var con = new Conexion() { query = insertarDir};
                    con.ejecutar();
                    var select = "SELECT DIR_ID FROM ONEFORALL.DIRECCIONES WHERE DIR_CODIGO_POSTAL = '" + codPostal.Text + "'";
                    con.query = select;
                    con.leer();
                    con.leerReader();
                    var valor = con.lector.GetSqlInt32(0);
                    con.cerrarConexion();
                    insertarSuc += "" + valor + ",'" + nombre.Text +"', 1);";
                    con = new Conexion() { query = insertarSuc };
                    con.ejecutar();
                    MessageBox.Show("Se agrego la sucursal correctamente","Agregar Sucursal",MessageBoxButtons.OK);
                    menuSucursal.Show();
                    this.Hide();
                }
                catch (Exception){
                    MessageBox.Show("Ya existe una sucursal con el mismo Codigo Postal", "Agregar Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else {
                MessageBox.Show("No se llenaron los campos obligatorios", "Agregar Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
