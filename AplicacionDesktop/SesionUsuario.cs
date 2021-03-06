﻿using System;
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
        public List<string> funcionalidades { get; set; }
        
        public static SesionUsuario user
        {get{
                if (usuario == null){ usuario = new SesionUsuario();}
                usuario.funcionalidades = new List<string>();
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

        public void cargarFuncionalidadesRol() {

            var con = new Conexion();

            con.query = "SELECT DISTINCT(fun.FUNC_DESCRIPCION) " +
            "FROM ONEFORALL.USUARIOS u JOIN ONEFORALL.USUARIO_X_ROL uxr " +
            "on " + id + " = uxr.USERX_ID " +
            "JOIN ONEFORALL.ROLES rol ON rol.ROL_ID = "+ rol +" " +
            "and rol.ROL_ACTIVO = 1 JOIN ONEFORALL.ROL_X_FUNCIONALIDAD rxf " +
            "ON rxf.ROL_ID = rol.ROL_ID JOIN ONEFORALL.FUNCIONALIDADES fun " +
            "ON fun.FUNC_ID = rxf.FUNC_ID";
            con.leer();
            if (!con.leerReader())
            {
                throw new Exception("Error carga de funcionalidades");
            }
            else
            {
                this.funcionalidades.Add(con.lector.GetString(0));
                while (con.leerReader())
                {
                    this.funcionalidades.Add(con.lector.GetString(0));
                }
            }
            con.cerrarConexion();

        }

        public bool tieneRolesActivos()
        {
            var query = String.Format("SELECT COUNT(*) FROM ONEFORALL.USUARIO_X_ROL u JOIN ONEFORALL.ROLES r ON r.ROL_ID = u.ROLX_ID WHERE u.USERX_ID = {0} AND r.ROL_ACTIVO = 1", SesionUsuario.usuario.id);
            var con = new Conexion() { query = query };
            con.leer();
            con.leerReader();
            if (con.lector.GetInt32(0) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
