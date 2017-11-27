using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class Reporte2 : Form
    {
        private MenuListadoEstadistico _menuListadoEstadistico;
        private string _anio;
        private string _trimestre;

        public Reporte2(MenuListadoEstadistico menuListadoEstadistico, string anio, string trimestre)
        {
            InitializeComponent();
            _menuListadoEstadistico = menuListadoEstadistico;
            _anio = anio;
            _trimestre = trimestre;
            CargarReporte();
        }

        private void CargarReporte()
        {
            var con = new Conexion();
            con.query = string.Format("SELECT TOP 5 REND_EMP_ID, EMP_NOMBRE, SUM(REND_TOTAL_RENDICION) FROM ONEFORALL.RENDICIONES R " +
                "INNER JOIN ONEFORALL.EMPRESAS E ON R.REND_EMP_ID = E.EMP_ID " +
                "WHERE YEAR(REND_FECHA) = {0} " +
                "AND MONTH(REND_FECHA) / 4 = ({1} - 1) " +
                "GROUP BY REND_EMP_ID, EMP_NOMBRE " +
                "ORDER BY 3 DESC", _anio, _trimestre);

            con.leer();

            if (con.leerReader())
            {
                dgvEmpresas.Rows.Add(con.lector.GetInt32(0), con.lector.GetString(1), con.lector.GetDecimal(2));
                while (con.leerReader())
                {
                    dgvEmpresas.Rows.Add(con.lector.GetInt32(0), con.lector.GetString(1), con.lector.GetDecimal(2));
                }
            }
            con.cerrarConexion();
        }

        private void cmdMenuEstadisticas_Click(object sender, EventArgs e)
        {
            _menuListadoEstadistico.Show();
            this.Close();
        }
    }
}
