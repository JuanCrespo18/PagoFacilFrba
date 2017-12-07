using PagoAgilFrba.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class editarEmpresa : Form
    {
        private Dto.EmpresaDto empresa;
        private filtrarEmpresa menuPadre;
    
        public editarEmpresa(String _idEmpresa ,filtrarEmpresa parent)
        {
            InitializeComponent();
            cargarRubros();
            this.cargarEmpresa(Convert.ToInt32(_idEmpresa));
            this.menuPadre = parent;
        }

        private void cargarRubros()
        {
            rubro.Items.Clear();
            var squery = "SELECT DISTINCT(RUB_DESCRIPCION) FROM ONEFORALL.RUBROS";
            var con = new Conexion() { query = squery };
            con.leer();
            while (con.leerReader())
            {
                rubro.Items.Add(con.lector.GetString(0));
            }
        }

        public void cargarEmpresa(int _idEmpresa)
        {
            var query = "SELECT * FROM ONEFORALL.EMPRESAS WHERE EMP_ID = " + Convert.ToString(_idEmpresa) + ";";
            var con = new Conexion() { query = query};
            con.leer();
            if (!con.leerReader())
            {
                MessageBox.Show("Error al cargar la empresa", "editar empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                String[] cuitCompleto = con.lector.GetString(1).Split('-');
                cuit1.Text = cuitCompleto[0];
                cuit2.Text = cuitCompleto[1];
                cuit3.Text = cuitCompleto[2];
                razonSocial.Text = con.lector.GetString(2);
                int idDireccion = con.lector.GetInt32(3);
                int idRubro = con.lector.GetInt32(4);
                int dia_rendicion = con.lector.GetInt32(5);
                checkHabilitada.Checked = con.lector.GetBoolean(6);

                con.cerrarConexion();

                con.query = string.Format("SELECT * FROM ONEFORALL.DIRECCIONES WHERE DIR_ID = {0}", idDireccion);

                con.leer();
                con.leerReader();

                direccion.Text = con.lector.GetString(1);
                codPostal.Text = con.lector.GetString(2);
                piso.Text = con.lector.IsDBNull(3) ? "" : con.lector.GetString(3);
                departamento.Text = con.lector.IsDBNull(4) ? "" : con.lector.GetString(4);
                localidad.Text = con.lector.GetString(5);
                con.cerrarConexion();
                con.query = string.Format("SELECT * FROM ONEFORALL.RUBROS WHERE RUB_ID = {0}", idRubro);
                con.leer();
                con.leerReader();
                rubro.Text = con.lector.GetString(1);
                diaRendicion.Text = dia_rendicion.ToString();

                empresa = new EmpresaDto(_idEmpresa, razonSocial.Text, cuit1.Text+"-"+cuit2.Text+"-"+cuit3.Text, rubro.Text, direccion.Text, localidad.Text, codPostal.Text, piso.Text, departamento.Text,checkHabilitada.Checked, diaRendicion.Text);

            }
            con.cerrarConexion();
        }

        private bool hayObligatoriosvacios()
        {
            if (
                String.IsNullOrWhiteSpace(razonSocial.Text)||
                String.IsNullOrWhiteSpace(cuit1.Text)||
                String.IsNullOrWhiteSpace(cuit2.Text) ||
                String.IsNullOrWhiteSpace(cuit3.Text) ||
                String.IsNullOrWhiteSpace(direccion.Text)||
                String.IsNullOrWhiteSpace(rubro.Text)||
                String.IsNullOrWhiteSpace(localidad.Text)||
                String.IsNullOrWhiteSpace(codPostal.Text) ||
                String.IsNullOrWhiteSpace(diaRendicion.Text)
                ) return true;
            return false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var dir_id = 0;
            var rub_id = 0;

            if (!hayObligatoriosvacios())
            {
                if(Convert.ToInt32(diaRendicion.Text) > 28 || Convert.ToInt32(diaRendicion.Text) < 1)
                {
                    MessageBox.Show("El día de rendición debe estar entre 1 y 28", "Empresa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var empresaModificada = new EmpresaDto(empresa.id, razonSocial.Text, cuit1.Text + "-" + cuit2.Text + "-" + cuit3.Text, rubro.Text, direccion.Text, localidad.Text, codPostal.Text, piso.Text, departamento.Text, checkHabilitada.Checked, diaRendicion.Text);

                if (!empresaModificada.equals(empresa))
                {

                    var query = "SELECT EMP_DIR_ID FROM ONEFORALL.EMPRESAS WHERE EMP_ID = " + empresa.id;

                    var con = new Conexion() { query = query };

                    con.leer();

                    if (!con.leerReader())
                    {
                        MessageBox.Show("No se encontro ninguna Sucursal", "Editar Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        menuPadre.Show();
                        this.Hide();
                    }
                    else
                    {
                        dir_id = con.lector.GetInt32(0);
                    }

                    con.cerrarConexion();

                    
                    var update = "UPDATE ONEFORALL.DIRECCIONES SET ";
                    update += " DIR_DIRECCION = '" + direccion.Text + "', ";
                    update += " DIR_CODIGO_POSTAL = '" + codPostal.Text + "',";
                    if (!string.IsNullOrEmpty(piso.Text))
                    {
                        update += "DIR_PISO = '" + piso.Text + "',";
                    }
                    if (!string.IsNullOrEmpty(departamento.Text))
                    {
                        update += "DIR_DEPARTAMENTO = '" + departamento.Text + "',";
                    }
                    update += "DIR_LOCALIDAD = '" + localidad.Text + "' WHERE DIR_ID = " + dir_id + " ;";
                    con.query = update;
                    con.ejecutar();


                    con.query = "SELECT RUB_ID FROM ONEFORALL.RUBROS WHERE RUB_DESCRIPCION = '"+ rubro.SelectedItem +"'";
                    con.leer();

                    if (con.leerReader())
                    {
                        rub_id = con.lector.GetInt32(0);
                    }
                    con.cerrarConexion();

                    if (empresa.activa != empresaModificada.activa && !empresaModificada.activa)
                    {
                        var cant = 0;
                        con.query = string.Format("SELECT COUNT(*) FROM ONEFORALL.FACTURAS F JOIN ONEFORALL.PAGOS P ON F.FACT_PAGO_ID = P.PAGO_ID LEFT JOIN ONEFORALL.RENDICIONES R ON F.FACT_REND_ID = R.REND_ID WHERE F.FACT_EMP_ID = {0} AND F.FACT_REND_ID IS NULL", empresa.id);
                        con.leer();

                        if (con.leerReader()) {
                            cant = con.lector.GetInt32(0);
                        }
                        if (cant > 0) {
                            MessageBox.Show("No puede desactivar porque tiene facturas pendientes de rendicion","Editar Empresa",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                            return;
                        }
                        con.cerrarConexion();
                    }

                    var upEmp = "UPDATE ONEFORALL.EMPRESAS SET ";
                    upEmp += "EMP_CUIT = '" + cuit1.Text + "-" + cuit2.Text + "-" + cuit3.Text + "', ";
                    upEmp += "EMP_NOMBRE = '" + razonSocial.Text +"', ";
                    upEmp += "EMP_RUB_ID = " + rub_id + ", ";
                    upEmp += "EMP_DIA_REND = " + diaRendicion.Text + ", ";
                    upEmp += "EMP_ACTIVA = " + Convert.ToInt32(checkHabilitada.Checked);
                    upEmp += " WHERE EMP_ID = " + empresa.id;

                    con.query = upEmp;
                    con.ejecutar();
                    MessageBox.Show("Se realizaron los cambios correctamente", "Editar Empresa", MessageBoxButtons.OK);
                }

                menuPadre.Show();
                menuPadre.refresh();
                this.Hide();
            }
            else {
                MessageBox.Show("No se completaron los campos obligatorios", "editar Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e) 
        {
            menuPadre.Show();
            this.Hide();
        }

        private void diaRendicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
