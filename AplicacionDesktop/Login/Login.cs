using PagoAgilFrba.Utilidades;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) {

            if (this.username.Text == "")
            {
                MessageBox.Show("Debe ingresar un usuario","Login Usuario");
                return;
            }

            if (this.password.Text == "")
            {
                MessageBox.Show("Debe ingresar una contraseña","Login Usuario");
                return;
            }

            var con = new Conexion();
            con.query = "SELECT * FROM ONEFORALL.USUARIOS WHERE USER_USUARIO = '"+ username.Text +"' AND USER_PASSWORD='"+ HashSha256.hashTo256(password.Text) + "' AND USER_ACTIVO = 1 ;" ;

            con.leer();

            if (con.leerReader())
            {

                MessageBox.Show("Bienvenido " + con.lector.GetString(1) + "!");

                SesionUsuario.user.id = con.lector.GetInt32(0);
                SesionUsuario.user.username = con.lector.GetString(1);

                con.cerrarConexion();
                con.query = "UPDATE ONEFORALL.USUARIOS SET USER_INTENTOS = 0 WHERE USER_ID =" + SesionUsuario.usuario.id;
                con.ejecutar();

                if (!SesionUsuario.usuario.tieneRolesActivos()) {

                    MessageBox.Show("El usuario no posee Roles activos", "Login Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //SesionUsuario.user.cargarFuncionalidadesRol();

                this.Hide();
                con.query = string.Format("SELECT COUNT(*) FROM ONEFORALL.USUARIO_X_ROL WHERE USERX_ID = {0}", SesionUsuario.user.id);
                con.leer();
                if (con.leerReader())
                {
                    if (con.lector.GetInt32(0) > 1)
                    {
                        new ElegirSucursalYRol().Show();
                    }
                    else
                    {
                        con.cerrarConexion();
                        con.query = string.Format("SELECT COUNT(*) FROM ONEFORALL.USUARIO_X_SUCURSAL WHERE USERX_ID = {0}", SesionUsuario.user.id);
                        con.leer();
                        if (con.leerReader())
                        {
                            if (con.lector.GetInt32(0) > 1)
                            {
                                new ElegirSucursalYRol().Show();
                                SesionUsuario.usuario.cargarFuncionalidadesRol();
                            }
                            else
                            {
                                SesionUsuario.CargarSucursalYRol();
                                new MenuPrincipal().ShowDialog();
                            }
                        }
                    }
                    con.cerrarConexion();
                }

            }
            else {

                con.query = "SELECT * FROM ONEFORALL.USUARIOS WHERE USER_USUARIO = '" + username.Text + "';";
                var intentosfallidos = 0;
                con.cerrarConexion();

                con.leer();

                if (con.leerReader())
                {
                    intentosfallidos = con.lector.GetByte(4);

                    if (!con.lector.GetBoolean(3)) {
                        MessageBox.Show("Su usuario se encuentra deshabilitado", "Login Usuario");
                        return;
                    }

                    con.cerrarConexion();
                    con.query = "UPDATE ONEFORALL.USUARIOS SET USER_INTENTOS = USER_INTENTOS + 1 WHERE USER_USUARIO='"+ username.Text +"';";
                    con.ejecutar();

                    if (intentosfallidos >= 3) {
                        con.query = "UPDATE ONEFORALL.USUARIOS SET USER_ACTIVO = 0 WHERE USER_USUARIO='" + username.Text + "';";
                        con.ejecutar();
                    }
                    MessageBox.Show("Ingrese nuevamente la contraseña", "Login Usuario");
                    con.cerrarConexion();
                    return;
                }
                else {
                    MessageBox.Show("El usuario no existe", "Login Usuario");
                    con.cerrarConexion();
                    return;
                }

            }

        }

    }
}
