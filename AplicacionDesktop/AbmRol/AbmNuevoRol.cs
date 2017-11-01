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

        public void CargarRol(string nombreRol)
        {
            txtRol.Text = nombreRol;
            txtRol.ReadOnly = true;
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

                con2.query = string.Format("SELECT 1 FROM ONEFORALL.ROL_X_FUNCIONALIDAD RF " +
                                "JOIN ONEFORALL.FUNCIONALIDADES F ON F.FUNC_ID = RF.FUNCX_ID " +
                                "AND F.FUNC_DESCRIPCION = '{0}' " +
                                "JOIN ONEFORALL.ROLES R ON RF.ROLX_ID = R.ROL_ID " +
                                "WHERE R.ROL_NOMBRE = '{1}'", funcionalidad, nombreRol);
                con2.leer();
                if (con2.leerReader())
                {
                    chlbFunc.SetItemChecked(i, true);
                }
                con2.cerrarConexion();
                i++;
            }
            con.cerrarConexion();

            Conexion con3 = new Conexion()
            {
                query = string.Format("SELECT ROL_ACTIVO FROM ONEFORALL.ROLES WHERE ROL_NOMBRE = '{0}'", nombreRol)
            };
            con3.leer();
            while(con3.leerReader())
            {
                bool habilitado = con3.lector.GetBoolean(0);
                chkHabilitado.Checked = habilitado;
            }
            con3.cerrarConexion();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
