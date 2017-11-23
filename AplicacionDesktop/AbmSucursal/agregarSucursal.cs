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
                    string insertarDir = "INSERT INTO ONEFORALL.DIRECCIONES VALUES(" + direccion.Text +","+ codPostal.Text;
                    string insertarSuc = "INSERT INTO ONEFORALL.SUCURSALES VALUES(";

                    var con = new Conexion();

                    if (string.IsNullOrEmpty(piso.Text)) {
                        insertarDir += ", null";
                    }
                    else {
                        insertarDir += "," + piso.Text;
                    }
                    if (string.IsNullOrEmpty(departamento.Text))
                    {
                        insertarDir += ",null";
                    }
                    else {
                        insertarDir += "," + departamento.Text;
                    }

                   


                }
                catch (Exception){
                    MessageBox.Show("Ya existe una sucursal con el mismo Codigo Postal", "Agregar Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else {
                MessageBox.Show("No se llenaron los campos obligatorios", "Agregar Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

    }
}
