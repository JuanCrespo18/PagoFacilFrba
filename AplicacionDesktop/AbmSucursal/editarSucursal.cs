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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class editarSucursal : Form
    {
        private int id;
        private SucursalDto sucursalDto;
        private filtrarSucursal menuPadre;
        public editarSucursal(String id_Sucursal,filtrarSucursal parent)
        {
            InitializeComponent();
            this.id = Convert.ToInt32(id_Sucursal);
            this.cargarSucursal(id);
            this.menuPadre = parent;
        }

        public void cargarSucursal(int id_sucursal) {

            var query = "SELECT * FROM ONEFORALL.VW_SUCURSALES WHERE ID = " + Convert.ToString(id_sucursal) + ";";
            var con = new Conexion() { query = query};
            con.leer();
            if (!con.leerReader())
            {
                MessageBox.Show("Error al cargar la sucursal", "editar Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nombre.Text = con.lector.GetString(1);
                direccion.Text = con.lector.GetString(2);
                codPostal.Text = con.lector.GetString(3);
                codPostal.Enabled = false;
                try
                {
                    piso.Text = con.lector.GetString(4);
                }
                catch (System.Exception e) {
                    piso.Text = "";
                }
                try
                {
                    departamento.Text = con.lector.GetString(5);
                }
                catch (System.Exception e)
                {
                    departamento.Text = "";
                }

                localidad.Text = con.lector.GetString(6);
                checkHabilitado.Checked = con.lector.GetBoolean(7);
            }
            sucursalDto = new SucursalDto(id,nombre.Text,direccion.Text,codPostal.Text,piso.Text,departamento.Text,localidad.Text,checkHabilitado.Checked);
            con.cerrarConexion();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (!hayObligatoriosvacios())
            {
                var suc = new SucursalDto(id, nombre.Text, direccion.Text, codPostal.Text, piso.Text, departamento.Text, localidad.Text, checkHabilitado.Checked);
                if (!sucursalDto.equals(suc))
                {
                    var select = "SELECT SUC_DIR_ID FROM ONEFORALL.SUCURSALES WHERE SUC_ID = " + id;
                    var dir_id = 0;
                    var con = new Conexion() { query = select };
                    con.leer();

                    if (!con.leerReader())
                    {
                        MessageBox.Show("No se encontro ninguna Sucursal", "Editar Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        menuPadre.Show();
                        this.Hide();
                    }
                    else
                    {
                        dir_id = con.lector.GetInt32(0);
                    }
                    con.cerrarConexion();
                    con.query = "UPDATE ONEFORALL.SUCURSALES SET SUC_NOMBRE ='" + nombre.Text + "', SUC_ACTIVA = " + Convert.ToInt32(checkHabilitado.Checked) + " WHERE SUC_ID =" + id + ";";
                    con.ejecutar();
                    var query = "UPDATE ONEFORALL.DIRECCIONES SET ";
                    query += "DIR_DIRECCION = '" + direccion.Text + "', ";
                    if (!string.IsNullOrEmpty(piso.Text))
                    {
                        query += "DIR_PISO = '" + piso.Text + "',";
                    }
                    if (!string.IsNullOrEmpty(departamento.Text))
                    {
                        query += "DIR_DEPARTAMENTO = '" + departamento.Text + "',";
                    }
                    query += "DIR_LOCALIDAD = '" + localidad.Text + "' WHERE DIR_ID =" + dir_id + " ;";
                    con.query = query;
                    con.ejecutar();
                    MessageBox.Show("Se realizaron los cambios correctamente", "Editar Sucursal", MessageBoxButtons.OK);
                }
                menuPadre.Show();
                menuPadre.refresh();
                this.Hide();
            }
            else {
                MessageBox.Show("No se completaron los campos obligatorios", "editar Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool hayObligatoriosvacios()
        {
            if (
                string.IsNullOrEmpty(nombre.Text) ||
                string.IsNullOrEmpty(localidad.Text) ||
                string.IsNullOrEmpty(direccion.Text)
                ) return true;
            return false;
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            menuPadre.Show();
            this.Hide();
        }
    }
}
