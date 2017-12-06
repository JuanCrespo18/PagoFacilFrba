using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Rendicion
{
    public partial class Rendicion : Form
    {
        private MenuPrincipal _menuPrincipal;
        private int _idEmpresa;
        private int _porcentajeComision = 10;
        
        public Rendicion(MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            CargarEmpresas();
            _menuPrincipal = menuPrincipal;
        }

        private void CargarEmpresas()
        {
            cboEmpresas.Items.Clear();
            Conexion con = new Conexion();
            con.query = "SELECT EMP_NOMBRE FROM ONEFORALL.EMPRESAS";

            con.leer();
            while (con.leerReader())
            {
                cboEmpresas.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

        }

        private void cmdCargarFacturas_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboEmpresas.SelectedIndex == -1)
                    throw new Exception("Seleccione una empresa");

                var con = new Conexion();

                con.query = string.Format("SELECT EMP_ID, EMP_DIA_REND FROM ONEFORALL.EMPRESAS WHERE EMP_NOMBRE = '{0}'", cboEmpresas.SelectedItem.ToString());
                con.leer();
                con.leerReader();
                _idEmpresa = con.lector.GetInt32(0);
                var dia_rendicion = con.lector.GetInt32(1);
                con.cerrarConexion();

                con.query = string.Format("SELECT FACT_ID, CLIE_NOMBRE + ' ' + CLIE_APELLIDO, EMP_NOMBRE, PAGO_FECHA_PAGO, FACT_TOTAL FROM ONEFORALL.FACTURAS F " +
                    "INNER JOIN ONEFORALL.CLIENTES C ON F.FACT_CLIE_ID = C.CLIE_ID " +
                    "INNER JOIN ONEFORALL.PAGOS P ON F.FACT_PAGO_ID = P.PAGO_ID " +
                    "INNER JOIN ONEFORALL.EMPRESAS E ON E.EMP_ID = {2} " +
                    "WHERE FACT_REND_ID IS NULL AND " +
                    "PAGO_FECHA_PAGO < CONVERT(DATETIME,'{1}',101)", cboEmpresas.SelectedItem.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _idEmpresa);
                con.leer();
                if (!con.leerReader())
                {
                    MessageBox.Show("La busqueda no produjo ningún resultado", "Filtrar facturas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    dgvFacturas.Rows.Add(new Object[] {con.lector.GetDecimal(0), con.lector.GetString(1),
                                   con.lector.GetString(2), con.lector.GetDateTime(3), con.lector.GetDecimal(4)});

                    while (con.leerReader())
                    {
                        dgvFacturas.Rows.Add(new Object[] {con.lector.GetDecimal(0), con.lector.GetString(1),
                                   con.lector.GetString(2), con.lector.GetDateTime(3), con.lector.GetDecimal(4)});
                    }
                    dgvFacturas.Sort(dgvFacturas.Columns[0], ListSortDirection.Ascending);
                }
                con.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CargarFacturas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdRendir_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtComision.Text))
                    throw new Exception("Indique un porcentaje de comision");

                _porcentajeComision = Convert.ToInt32(txtComision.Text);

                var con = new Conexion();

                con.query = string.Format("SELECT EMP_DIA_REND FROM ONEFORALL.EMPRESAS WHERE EMP_ID = {0}", _idEmpresa);
                con.leer();
                con.leerReader();
                int fechaRendicion = con.lector.GetInt32(0);
                con.cerrarConexion();

                if (fechaRendicion != DateTime.Now.Day)
                    throw new Exception(string.Format("La empresa seleccionada tiene configurado el día {0} del mes para hacer las rendiciones.", fechaRendicion));

                foreach (DataGridViewRow factura in dgvFacturas.Rows)
                {
                    con.query = string.Format("INSERT INTO ONEFORALL.RENDICIONES VALUES ({0}, {1}, {2}, '{3}')",
                        _idEmpresa,
                        ((decimal)factura.Cells["Total"].Value * _porcentajeComision / 100).ToString().Replace(',', '.'),
                        _porcentajeComision,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    con.ejecutar();

                    con.query = string.Format("UPDATE ONEFORALL.FACTURAS SET FACT_REND_ID = (SELECT MAX(REND_ID) FROM ONEFORALL.RENDICIONES) " +
                        "WHERE FACT_ID = {0}", factura.Cells["Numero"].Value.ToString());
                    con.ejecutar();
                }

                cboEmpresas.SelectedIndex = -1;
                dgvFacturas.Rows.Clear();
                _idEmpresa = 0;

                MessageBox.Show("Operación realizada con éxito", "Rendición", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Rendicion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdMenu_Click(object sender, EventArgs e)
        {
            _menuPrincipal.Show();
            this.Close();
        }

        private void txtComision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
