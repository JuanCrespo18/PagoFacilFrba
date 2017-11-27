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
    public partial class Reporte4 : Form
    {
        private MenuListadoEstadistico _menuListadoEstadistico;
        private string _anio;
        private string _trimestre;

        public Reporte4(MenuListadoEstadistico menuListadoEstadistico, string anio, string trimestre)
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
            con.query = string.Format("SELECT TOP 5 CLIE_ID, CLIE_NOMBRE, CLIE_APELLIDO, COUNT(DISTINCT(F.FACT_ID)) TotalFacturas, " +
                    "(SELECT COUNT(DISTINCT(FACT_ID)) FROM ONEFORALL.CLIENTES C1 " +
                    "INNER JOIN ONEFORALL.FACTURAS F1 ON C1.CLIE_ID = F1.FACT_CLIE_ID " +
                    "WHERE FACT_PAGO_ID IS NOT NULL " +
                    "AND CLIE_ID = C.CLIE_ID " +
                    "AND YEAR(F1.FACT_ALTA) = {0} " +
                    "AND MONTH(F1.FACT_ALTA) / 4 = ({1} - 1) " +
                    "GROUP BY CLIE_ID) Pagadas, " +
                    "CONVERT(INT, (SELECT COUNT(DISTINCT(FACT_ID)) FROM ONEFORALL.CLIENTES C1 " +
                    "INNER JOIN ONEFORALL.FACTURAS F1 ON C1.CLIE_ID = F1.FACT_CLIE_ID " +
                    "WHERE FACT_PAGO_ID IS NOT NULL " +
                    "AND CLIE_ID = C.CLIE_ID " +
                    "AND YEAR(F1.FACT_ALTA) = {0} " +
                    "AND MONTH(F1.FACT_ALTA) / 4 = ({1} - 1) " +
                    "GROUP BY CLIE_ID) / CONVERT(decimal(4, 2), COUNT(DISTINCT(F.FACT_ID))) * 100) " +
                "FROM ONEFORALL.CLIENTES C " +
                "INNER JOIN ONEFORALL.FACTURAS F ON C.CLIE_ID = F.FACT_CLIE_ID " +
                "WHERE YEAR(F.FACT_ALTA) = {0} " +
                "AND MONTH(F.FACT_ALTA) / 4 = ({1} - 1) " +
                "GROUP BY CLIE_ID, CLIE_NOMBRE, CLIE_APELLIDO " +
                "ORDER BY 6 DESC", _anio, _trimestre);

            con.leer();

            if (con.leerReader())
            {
                dgvClientes.Rows.Add(con.lector.GetInt32(0), con.lector.GetString(1), con.lector.GetString(2), con.lector.GetInt32(3), con.lector.GetInt32(4), con.lector.GetInt32(5));
                while (con.leerReader())
                {
                    dgvClientes.Rows.Add(con.lector.GetInt32(0), con.lector.GetString(1), con.lector.GetString(2), con.lector.GetInt32(3), con.lector.GetInt32(4), con.lector.GetInt32(5));
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
