using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Devoluciones
{
    public partial class Devoluciones : Form
    {
        private MenuPrincipal _menuPrincipal;
        private string _rol;

        public Devoluciones(MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            _menuPrincipal = menuPrincipal;

            var con = new Conexion();
            con.query = string.Format("SELECT ROL_NOMBRE FROM ONEFORALL.ROLES WHERE ROL_ID = {0}", SesionUsuario.user.rol);
            con.leer();
            if (con.leerReader())
            {
                _rol = con.lector.GetString(0);
                if (_rol == "Administrador")
                    rdbRendicion.Enabled = true;
                else if (_rol == "Cobrador")
                    rdbPago.Enabled = true;
            }
        }

        private void rdbPago_CheckedChanged(object sender, EventArgs e)
        {
            //TODO: AGREGAR VALIDACION PARA ROL QUE PERMITE DEVOLVER PAGOS O RENDICIONES.
            if(rdbPago.Checked)
            {
                dgvFacturas.Columns["Fecha"].HeaderText = "FechaPago";
                dgvFacturas.Columns["Total"].HeaderText = "TotalPago";
            }
            else
            {
                dgvFacturas.Columns["Fecha"].HeaderText = "FechaRendicion";
                dgvFacturas.Columns["Total"].HeaderText = "TotalRendicion";
            }
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbPago.Enabled == false && rdbRendicion.Enabled == false)
                    throw new Exception("Usted no tiene permisos para realizar devoluciones. Solo pueden hacerlo los cobradores y administradores");

                char tipoDev;
                if (rdbPago.Checked)
                    tipoDev = 'P';
                else
                    tipoDev = 'R';

                rdbPago.Enabled = false;
                rdbRendicion.Enabled = false;

                new AbmFactura.ListarFacturas(this, tipoDev).Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Devoluciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarFactura(string numeroFactura)
        {
            bool contiene = false;
            foreach (DataGridViewRow factura in dgvFacturas.Rows)
            {
                if (factura.Cells["Numero"].Value.ToString() == numeroFactura)
                    contiene = true;
            }

            if (contiene)
                throw new Exception("Esa factura ya ha sido seleccionada");

            var con = new Conexion();

            if(rdbPago.Checked)
            {
                con.query = string.Format("SELECT FACT_ID, FACT_CLIE, FACT_EMP, PAGO_FECHA_PAGO, PAGO_TOTAL FROM ONEFORALL.VISTALISTARFACTURAS V " +
                    "INNER JOIN ONEFORALL.PAGOS P ON V.FACT_PAGO_ID = P.PAGO_ID " +
                    "WHERE FACT_ID = {0}", numeroFactura);
            }
            else
            {
                con.query = string.Format("SELECT FACT_ID, FACT_CLIE, FACT_EMP, REND_FECHA, REND_TOTAL_RENDICION FROM ONEFORALL.VISTALISTARFACTURAS V " +
                    "INNER JOIN ONEFORALL.RENDICIONES R ON V.FACT_REND_ID = R.REND_ID " +
                    "WHERE FACT_ID = {0}", numeroFactura);
            }

            con.leer();
            con.leerReader();

            dgvFacturas.Rows.Add(new Object[] {con.lector.GetDecimal(0), con.lector.GetString(1), con.lector.GetString(2),
                                   con.lector.GetDateTime(3), con.lector.GetDecimal(4)});

            con.cerrarConexion();
        }

        private void cmdLimpiarFacturas_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            dgvFacturas.Rows.Clear();
            if (_rol == "Administrador")
                rdbRendicion.Enabled = true;
            else if (_rol == "Cobrador")
                rdbPago.Enabled = true;
        }

        private void cmdQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFacturas.SelectedRows.Count == 0)
                    throw new Exception("Seleccione la factura a quitar");

                dgvFacturas.Rows.RemoveAt(dgvFacturas.SelectedRows[0].Index);

                if (dgvFacturas.Rows.Count == 0)
                {
                    if (_rol == "Administrador")
                        rdbRendicion.Enabled = true;
                    else if (_rol == "Cobrador")
                        rdbPago.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Quitar Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFacturas.RowCount == 0)
                    throw new Exception("Debe agregar facturas para devolver");

                foreach (DataGridViewRow factura in dgvFacturas.Rows)
                {
                    var con = new Conexion();

                    con.query = "UPDATE ONEFORALL.FACTURAS ";

                    if (rdbPago.Checked)
                        con.query += "SET FACT_PAGO_ID = NULL ";
                    else
                        con.query += "SET FACT_REND_ID = NULL ";

                    con.query += string.Format("WHERE FACT_ID = {0}", factura.Cells["Numero"].Value.ToString());
                    con.ejecutar();
                }
                MessageBox.Show("Devoluciones realizadas con éxito", "Devolver facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Devolver facturas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdMenu_Click(object sender, EventArgs e)
        {
            _menuPrincipal.Show();
            this.Close();
        }
    }
}
