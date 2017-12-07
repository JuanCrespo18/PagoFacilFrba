using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Login
{
    public partial class ElegirSucursalYRol : Form
    {
        public ElegirSucursalYRol()
        {
            InitializeComponent();
            CargarCombos();
        }

        private void CargarCombos()
        {
            cboRoles.Items.Clear();
            cboSucursales.Items.Clear();
            Conexion con = new Conexion();
            con.query = string.Format("SELECT ROL_NOMBRE FROM ONEFORALL.ROLES R " +
                "INNER JOIN ONEFORALL.USUARIO_X_ROL UR ON R.ROL_ID = UR.ROLX_ID " +
                "WHERE USERX_ID = {0} AND R.ROL_ACTIVO = 1", SesionUsuario.user.id);

            con.leer();
            while (con.leerReader())
            {
                cboRoles.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

            con.query = string.Format("SELECT SUC_NOMBRE FROM ONEFORALL.sucursales S " +
                "INNER JOIN ONEFORALL.USUARIO_X_SUCURSAL US ON S.SUC_ID = US.SUCX_ID " +
                "WHERE USERX_ID = {0}", SesionUsuario.user.id);
            con.leer();
            while (con.leerReader())
            {
                cboSucursales.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

            if (cboSucursales.Items.Count == 1)
            {
                cboSucursales.Enabled = false;
                cboSucursales.SelectedIndex = 0;
            }
            if (cboRoles.Items.Count == 1)
            {
                cboRoles.Enabled = false;
                cboRoles.SelectedIndex = 0;
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboRoles.SelectedIndex == -1 || cboSucursales.SelectedIndex == -1)
                    throw new Exception("Por favor seleccione rol y empresa");

                var con = new Conexion();
                con.query = string.Format("SELECT ROL_ID FROM ONEFORALL.ROLES WHERE ROL_NOMBRE = '{0}'", cboRoles.SelectedItem.ToString());
                con.leer();
                con.leerReader();
                SesionUsuario.user.rol = con.lector.GetInt32(0);
                con.cerrarConexion();

                con.query = string.Format("SELECT SUC_ID FROM ONEFORALL.SUCURSALES WHERE SUC_NOMBRE = '{0}'", cboSucursales.SelectedItem.ToString());
                con.leer();
                con.leerReader();
                SesionUsuario.user.sucursal = con.lector.GetInt32(0);
                con.cerrarConexion();

                SesionUsuario.usuario.cargarFuncionalidadesRol(); 

                new MenuPrincipal().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Elegir rol y empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
