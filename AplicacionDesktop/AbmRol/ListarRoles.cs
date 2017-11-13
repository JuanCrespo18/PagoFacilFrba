using System;
using System.Data;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmRol
{
    public partial class ListarRoles : Form
    {
        private AltaRol abmNuevoRol;
        private int _idRolSeleccionado;
        private MenuPrincipal _menuPrincipal;
        
        public ListarRoles(MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            CargarRoles();
            _menuPrincipal = menuPrincipal;
        }

        public void CargarRoles()
        {
            cboRoles.Items.Clear();
            Conexion con = new Conexion();
            con.query = "SELECT ROL_NOMBRE FROM ONEFORALL.ROLES";

            con.leer();
            while (con.leerReader())
            {
                cboRoles.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

            cmdModificarRol.Enabled = false;
        }

        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboRoles.Text))
            {
                cmdModificarRol.Enabled = true;
            }

            var con = new Conexion()
            {
                query = string.Format("SELECT ROL_ID FROM ONEFORALL.ROLES WHERE ROL_NOMBRE = '{0}'", cboRoles.Text)
            };
            con.leer();
            con.leerReader();
            _idRolSeleccionado = con.lector.GetInt32(0);
            con.cerrarConexion();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            this.abmNuevoRol = new AltaRol(this);
            abmNuevoRol.CargarRol(cboRoles.Text, _idRolSeleccionado);
            abmNuevoRol.Show();
            this.Hide();
        }

        private void cmdNuevoRol_Click(object sender, EventArgs e)
        {
            this.abmNuevoRol = new AltaRol(this);
            abmNuevoRol.CargarRol("", 0);
            abmNuevoRol.Show();
            this.Hide();
        }

        internal void ValidarRolNuevo(string rolNuevo)
        {
            if(cboRoles.Items.Contains(rolNuevo))
            {
                throw new Exception("Ese rol ya existe");
            }
        }

        private void cmdMenu_Click(object sender, EventArgs e)
        {
            _menuPrincipal.Show();
            this.Close();
        }
    }
}
