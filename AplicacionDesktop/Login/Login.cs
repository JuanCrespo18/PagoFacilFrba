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

                con.query  = "SELECT DISTINCT(fun.FUNC_DESCRIPCION) " +
                            "FROM ONEFORALL.USUARIOS u JOIN ONEFORALL.USUARIO_X_ROL uxr " +
                            "on "+ SesionUsuario.usuario.id +" = uxr.USERX_ID " +
                            "JOIN ONEFORALL.ROLES rol ON rol.ROL_ID = uxr.ROLX_ID " +
                            "and rol.ROL_ACTIVO = 1 JOIN ONEFORALL.ROL_X_FUNCIONALIDAD rxf " +
                            "ON rxf.ROL_ID = rol.ROL_ID JOIN ONEFORALL.FUNCIONALIDADES fun " +
                            "ON fun.FUNC_ID = rxf.FUNC_ID";
                con.leer();
                if (!con.leerReader())
                {
                    MessageBox.Show("Ocurrio un error inesperado", "Login Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    SesionUsuario.usuario.funcionalidades.Add(con.lector.GetString(0));
                    while (con.leerReader())
                    {
                    SesionUsuario.usuario.funcionalidades.Add(con.lector.GetString(0));
                    }
                }
                con.cerrarConexion();

                    this.Hide();
                new MenuPrincipal().ShowDialog();

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
