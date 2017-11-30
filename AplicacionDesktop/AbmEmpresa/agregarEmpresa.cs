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
    public partial class agregarEmpresa : Form
    {
        MenuEmpresas menuEmpresas;
        

        private void CargarRubros()
        {
            rubro.Items.Clear();
            Conexion con = new Conexion();
            con.query = "SELECT RUB_DESCRIPCION FROM ONEFORALL.RUBROS";

            con.leer();
            while (con.leerReader())
            {
                rubro.Items.Add(con.lector.GetString(0));
            }
            con.cerrarConexion();

        }

        public agregarEmpresa(MenuEmpresas menu)
        {
            InitializeComponent();
            CargarRubros();
            menuEmpresas = menu;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            menuEmpresas.Show();
            this.Hide();
        }
        private void AgregarEmpresa(int direccionId,int rubroid)
        {
            string insert = string.Format("INSERT INTO ONEFORALL.EMPRESAS VALUES ('{0}', '{1}', {2}, {3}, {4}, {5})",
                cuit.Text, razonSocial.Text, direccionId, rubroid, diaRendicion.Text, Convert.ToInt16(activa.Checked));

            var con = new Conexion()
            {
                query = insert
            };
            con.ejecutar();
        }


         private int ObtenerDireccion()
            {
            int idDireccion;
            string consulta = ConsultaDireccion();

            var con = new Conexion()
            {
                query = consulta
            };
            con.leer();
            if (con.leerReader())
                idDireccion = con.lector.GetInt32(0);
            else
            {
                con.cerrarConexion();
                con.query = string.Format("INSERT INTO ONEFORALL.DIRECCIONES VALUES('{0}', '{1}', {2}, {3}, '{4}')",
                    direccion.Text, codPostal.Text,
                    string.IsNullOrEmpty(piso.Text) ? "null" : "'" + piso.Text + "'",
                    string.IsNullOrEmpty(departamento.Text) ? "null" : "'" + departamento.Text + "'",
                    localidad.Text);
                con.ejecutar();

                con.query = ConsultaDireccion();
                con.leer();
                con.leerReader();
                idDireccion = con.lector.GetInt32(0);
            }
            con.cerrarConexion();
            return idDireccion;
        }
        private int ObtenerRubro()
            {
            int idRubro;
            string consulta = ConsultaRubro();

            var con = new Conexion()
            {
                query = consulta
            };
            con.leer();
            con.leerReader();
            idRubro = con.lector.GetInt32(0);
            con.cerrarConexion();
            return idRubro;
        }

        private string ConsultaDireccion()
        {
            string consulta = string.Format("SELECT DIR_ID FROM ONEFORALL.DIRECCIONES " +
                "WHERE DIR_DIRECCION = '{0}' " +
                "AND DIR_CODIGO_POSTAL = '{1}' " +
                "AND DIR_LOCALIDAD = '{2}' ", direccion.Text, codPostal.Text, localidad.Text);

            if (!string.IsNullOrEmpty(piso.Text))
                consulta += string.Format("AND DIR_PISO = '{0}' ", piso.Text);

            if (!string.IsNullOrEmpty(departamento.Text))
                consulta += string.Format("AND DIR_DEPARTAMENTO = '{0}' ", departamento.Text);
            return consulta;
        }
        private string ConsultaRubro()
        {
            string consulta = string.Format("SELECT RUB_ID FROM ONEFORALL.RUBROS " +
                "WHERE RUB_DESCRIPCION = '{0}'",rubro.Text);

            return consulta;
        }

        public  string errorCampos()
        {    // Validacion de campos
            String errores = "";
            int asd;
            if (String.IsNullOrWhiteSpace(razonSocial.Text)) errores += "- El campo 'Razon Social' no puede estar vacío \n";
            if (String.IsNullOrWhiteSpace(cuit.Text)) errores += "- El campo 'Cuit' no puede estar vacío\n";
            if (String.IsNullOrWhiteSpace(direccion.Text)) errores += "- El campo 'Direccion' no puede estar vacío\n";
            if (String.IsNullOrWhiteSpace(rubro.Text)) errores += "- El campo 'Rubro' no puede estar vacío\n";
            if (String.IsNullOrWhiteSpace(localidad.Text)) errores += "- El campo 'Localidad' no puede estar vacío\n";
            if (String.IsNullOrWhiteSpace(codPostal.Text)) errores += "- El campo 'Codigo Postal' no puede estar vacío\n";
            if (String.IsNullOrWhiteSpace(diaRendicion.Text)) errores += "- El campo 'Dia Rendicion' no puede estar vacío\n";
            else if (Convert.ToInt32(diaRendicion.Text) > 28 || Convert.ToInt32(diaRendicion.Text) < 1)
                errores += "- El dia de rendicion debe estar entre el 1 y el 28\n";


            if (!int.TryParse(cuit.Text, out asd)) errores += "- El 'cuit' debe ser numérico \n";
            
            return errores;
        }

        public void limpiar()
        {
            razonSocial.Clear();
            cuit.Clear();
            direccion.Clear();
            rubro.SelectedIndex = -1;
            localidad.Clear();
            codPostal.Clear();
            piso.Clear();
            departamento.Clear();
            diaRendicion.Clear();
            activa.Checked = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void bntAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string errores = errorCampos();
                if (!string.IsNullOrEmpty(errores))
                {
                    throw new Exception(errores);
                }
                int direccionId = ObtenerDireccion();
                int rubroId = ObtenerRubro();
                AgregarEmpresa(direccionId, rubroId);
                menuEmpresas.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
