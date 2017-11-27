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
    public partial class Reporte3 : Form
    {
        private MenuListadoEstadistico _menuListadoEstadistico;
        private string _anio;
        private string _trimestre;

        public Reporte3(MenuListadoEstadistico menuListadoEstadistico, string anio, string trimestre)
        {
            InitializeComponent();
            _menuListadoEstadistico = menuListadoEstadistico;
            _anio = anio;
            _trimestre = trimestre;
            CargarReporte();
        }

        public void CargarReporte()
        {
            var con = new Conexion();
            con.query = string.Format("SELECT TOP 5 PAGO_CLIE_ID, CLIE_NOMBRE, CLIE_APELLIDO, COUNT(DISTINCT(PAGO_ID)) FROM ONEFORALL.PAGOS P " +
                "INNER JOIN ONEFORALL.CLIENTES C ON P.PAGO_CLIE_ID = C.CLIE_ID " +
                "WHERE YEAR(PAGO_FECHA_PAGO) = {0} " +
                "AND MONTH(PAGO_FECHA_PAGO) / 4 = ({1} - 1)" +
                "GROUP BY PAGO_CLIE_ID, CLIE_NOMBRE, CLIE_APELLIDO " +
                "ORDER BY 4 DESC", _anio, _trimestre);

            con.leer();

            if (con.leerReader())
            {
                dgvClientes.Rows.Add(con.lector.GetInt32(0), con.lector.GetString(1), con.lector.GetString(2), con.lector.GetInt32(3));
                while (con.leerReader())
                {
                    dgvClientes.Rows.Add(con.lector.GetInt32(0), con.lector.GetString(1), con.lector.GetString(2), con.lector.GetInt32(3));
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
