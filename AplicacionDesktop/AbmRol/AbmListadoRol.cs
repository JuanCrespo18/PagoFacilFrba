using System;
using System.Data;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmRol
{
    public partial class AbmListadoRol : Form
    {
        private AbmNuevoRol abmNuevoRol;
        
        public AbmListadoRol()
        {
            InitializeComponent();
            this.abmNuevoRol = new AbmNuevoRol(this);

            Conexion con = new Conexion();
            con.query = "SELECT ROL_NOMBRE FROM ONEFORALL.ROLES";
            
            con.leer();
            while (con.leerReader())
            {
                cboRoles.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

            cmdModificar.Enabled = false;
        }

        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboRoles.Text))
            {
                cmdModificar.Enabled = true;
            }
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            abmNuevoRol.CargarRol(cboRoles.Text);
            abmNuevoRol.Show();
            this.Hide();
        }
    }
}
