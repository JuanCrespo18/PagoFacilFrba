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
        private MenuListadoEstadistico menuListadoEstadistico;

        public Reporte1(MenuListadoEstadistico menuEstadistico)
        {
            InitializeComponent();
            menuListadoEstadistico = menuEstadistico;
            Correr_Reporte();
            
        }

        private void Correr_Reporte()
        {
            dgvReporte.Rows.Clear();
            string query =  "select b.EMP_NOMBRE	,count(FACT_EMP_ID)/(select count(1)from ONEFORALL.FACTURAS)*100 as Porcentaje from ONEFORALL.FACTURAS";
            query +=        "join ONEFORALL.EMPRESAS b on FACT_EMP_ID=EMP_ID";
            query +=        "group by b.EMP_NOMBRE";
            var con = new Conexion()
            {
                query = query
            };
            con.leer();
            if (!con.leerReader())
            {
                MessageBox.Show("La busqueda no produjo ningún resultado", "Fecha no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                dgvReporte.Rows.Add(new Object[] { con.lector.GetString(0), con.lector.GetInt32(1) });

                while (con.leerReader())
                {
                    dgvReporte.Rows.Add(new Object[] { con.lector.GetString(0), con.lector.GetInt32(1) });

                }
                dgvReporte.Sort(dgvReporte.Columns[0], ListSortDirection.Ascending);

            }
            con.cerrarConexion();
        }
        private void dgvReporte_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Reporte1_Load(object sender, EventArgs e)
        {

        }

    }
}
