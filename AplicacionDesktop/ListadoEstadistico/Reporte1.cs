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

    public partial class Reporte1 : Form
    {
        private MenuListadoEstadistico _menuListadoEstadistico;
        private string _anio;
        private string _trimestre;

        public Reporte1(MenuListadoEstadistico menuListadoEstadistico, string anio, string trimestre)
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
            con.query = string.Format("select TOP 5 b.EMP_NOMBRE, count(FACT_EMP_ID)/(select count(1)from ONEFORALL.FACTURAS a WHERE FACT_PAGO_ID in (Select PAGO_ID from ONEFORALL.PAGOS " +
                "WHERE YEAR(PAGO_FECHA_PAGO) = {0} and MONTH(PAGO_FECHA_PAGO)/4 = ({1}-1) ))*100 as Porcentaje from ONEFORALL.FACTURAS "+
                "join ONEFORALL.EMPRESAS b on FACT_EMP_ID=EMP_ID " +
                "join ONEFORALL.PAGOS c on FACT_PAGO_ID = PAGO_ID "+
                "WHERE YEAR(PAGO_FECHA_PAGO) = {0} " +
                "AND MONTH(PAGO_FECHA_PAGO)/4 = ({1} - 1) " +
                "GROUP BY b.EMP_NOMBRE " +
                "ORDER BY 2", _anio, _trimestre);

            con.leer();

            if (con.leerReader())
            {
                dgvReporte.Rows.Add(con.lector.GetString(0), con.lector.GetInt32(1));
                while (con.leerReader())
                {
                    dgvReporte.Rows.Add(con.lector.GetString(0), con.lector.GetInt32(1));
                }
            }
            con.cerrarConexion();
        }
        private void dgvReporte_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Reporte1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmdMenuEstadisticas_Click(object sender, EventArgs e)
        {
            _menuListadoEstadistico.Show();
            this.Close();
        }

    }
}
