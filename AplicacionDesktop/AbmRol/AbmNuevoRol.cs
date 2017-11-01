using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmRol
{
    public partial class AbmNuevoRol : Form
    {
        private AbmListadoRol abmListadoRol;

        public AbmNuevoRol()
        {
            InitializeComponent();
        }

        public AbmNuevoRol(AbmListadoRol abmListadoRol)
        {
            InitializeComponent();
            this.abmListadoRol = abmListadoRol;
        }

        public void CargarRol(string text)
        {
            string funcionalidad;
            Conexion con = new Conexion();
            Conexion con2 = new Conexion();
            con.query = "SELECT FUNC_DESCRIPCION FROM ONEFORALL.FUNCIONALIDADES";
            con.leer();
            int i = 0;
            while (con.leerReader())
            {
                funcionalidad = con.lector.GetString(0);
                chlbFunc.Items.Add(funcionalidad);

                con2.query = "SELECT 1 FROM ONEFORALL.ROL_X_FUNCIONALIDAD RF " +
                                "JOIN ONEFORALL.FUNCIONALIDADES F ON F.FUNC_ID = RF.FUNCX_ID " +
                                "AND F.FUNC_DESCRIPCION = '" + funcionalidad + "' " +
                                "JOIN ONEFORALL.ROLES R ON RF.ROLX_ID = R.ROL_ID " +
                                "WHERE R.ROL_NOMBRE = '" + text + "'";
                con2.leer();
                if (con2.leerReader())
                {
                    chlbFunc.SetItemChecked(i, true);
                }
                con2.cerrarConexion();
                i++;
            }
            con.cerrarConexion();
        }
    }
}
