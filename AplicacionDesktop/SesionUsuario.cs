using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba
{
    class SesionUsuario
    {
        public static SesionUsuario usuario;
        public int id { get; set; }
        public int rol { get; set; }
        public String username { get; set; }
        public int sucursal { get; set; }
        
        public static SesionUsuario user
        {get{
                if (usuario == null){ usuario = new SesionUsuario();}
                return usuario;
            }
        }

        private SesionUsuario() { }

        public static void CargarSucursalYRol()
        {
            var con = new Conexion();
            con.query = string.Format("SELECT ROL_ID, SUCX_ID FROM ONEFORALL.USUARIO_X_ROL UR " +
                "INNER JOIN ONEFORALL.USUARIO_X_SUCURSAL US ON UR.USERX_ID = US.USERX_ID " +
                "INNER JOIN ONEFORALL.ROLES R ON UR.ROLX_ID = R.ROL_ID " +
                "WHERE UR.USERX_ID = {0} " +
                "AND ROL_ACTIVO = 1", user.id);
            con.leer();
            if(con.leerReader())
            {
                user.rol = con.lector.GetInt32(0);
                user.sucursal = con.lector.GetInt32(1);
            }
            con.cerrarConexion();
        }
    }
}
