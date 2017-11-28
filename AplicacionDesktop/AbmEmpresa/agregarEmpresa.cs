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
        private char _evento;
        private int _idEmpresa;
        private filtrarEmpresa _listarEmpresas;

        public static agregarEmpresa Crear(filtrarEmpresa ListarEmpresas, char evento, string idEmpresa)
        {
            var abm = new agregarEmpresa(ListarEmpresas, evento)
            {
                _idEmpresa = Convert.ToInt32(idEmpresa)
            };
            abm.CargarEmpresa();
            return abm;
        }

        public agregarEmpresa(filtrarEmpresa listarEmpresas, char evento)
        {
            InitializeComponent();
            _listarEmpresas = listarEmpresas;
        }


        private void CargarEmpresa()
        {
            var con = new Conexion()
            {
                query = string.Format("SELECT * FROM ONEFORALL.EMPRESAS WHERE EMP_ID = {0}", _idEmpresa)
            };
            con.leer();
            con.leerReader();

            cuit.Text = con.lector.GetString(1);
            razonSocial.Text = con.lector.GetString(2);
            int idDireccion = con.lector.GetInt32(3);
            int idRubro = con.lector.GetInt32(4);
            Int16 checkHabilitada = con.lector.GetInt16(5);

            con.cerrarConexion();

            con = new Conexion()
            {
                query = string.Format("SELECT * FROM ONEFORALL.DIRECCIONES WHERE DIR_ID = {0}", idDireccion)
            };
            con.leer();
            con.leerReader();

            direccion.Text = con.lector.GetString(1);
            codPostal.Text = con.lector.GetString(2);
            piso.Text = con.lector.IsDBNull(3) ? "" : con.lector.GetString(3);
            departamento.Text = con.lector.IsDBNull(4) ? "" : con.lector.GetString(4);
            localidad.Text = con.lector.GetString(5);


            con.cerrarConexion();

            con = new Conexion()
            {
                query = string.Format("SELECT * FROM ONEFORALL.RUBROS WHERE RUB_ID = {0}", idRubro)
            };
            con.leer();
            con.leerReader();

            rubro.Text = con.lector.GetString(1);
        }
        public agregarEmpresa(MenuEmpresas menu)
        {
            InitializeComponent();
            menuEmpresas = menu;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            menuEmpresas.Show();
            this.Hide();
        }
        private void AgregarEmpresa(int direccionId,int rubroid)
        {
            string insert = string.Format("INSERT INTO ONEFORALL.EMPRESAS VALUES ('{0}', '{1}', '{2}', {3}, '{4}', '{5}')",
                _idEmpresa, cuit.Text, razonSocial.Text,direccionId, rubroid, '0');

            var con = new Conexion()
            {
                query = insert
            };
            con.ejecutar();
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            if (_evento == 'E')
            {
                CargarEmpresa();
            }
            else
            {
                limpiar();
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            _listarEmpresas.Show();
            this.Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                errorCampos();
                int direccionId = ObtenerDireccion();
                int rubroId = ObtenerRubro();
                AgregarEmpresa(direccionId,rubroId);
                _listarEmpresas.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                var con2 = new Conexion()
                {
                    query = string.Format("INSERT INTO ONEFORALL.DIRECCIONES VALUES('{0}', '{1}', {2}, {3}, '{4}')",
                    direccion.Text, codPostal.Text,
                    string.IsNullOrEmpty(piso.Text) ? "null" : "'" + piso.Text + "'",
                    string.IsNullOrEmpty(departamento.Text) ? "null" : "'" + departamento.Text + "'",
                    localidad.Text)
                };
                con2.ejecutar();

                con2.query = ConsultaDireccion();
                con2.leer();
                con2.leerReader();
                idDireccion = con2.lector.GetInt32(0);
                con2.cerrarConexion();
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
            if (con.leerReader())
                idRubro = con.lector.GetInt32(0);
            else
            {
                var con2 = new Conexion()
                {
                    query = string.Format("INSERT INTO ONEFORALL.RUBROS VALUES('{0}')",
                    rubro.Text)
                };
                con2.ejecutar();

                con2.query = ConsultaRubro();
                con2.leer();
                con2.leerReader();
                idRubro = con2.lector.GetInt32(0);
                con2.cerrarConexion();
            }
            con.cerrarConexion();
            return idRubro;
        }

        private string ConsultaDireccion()
        {
            string consulta = string.Format("SELECT DIR_ID FROM ONEFORALL.DIRECCIONES " +
                "WHERE DIR_DIRECCION = '{0}'" +
                "AND DIR_CODIGO_POSTAL = '{1}'" +
                "AND DIR_LOCALIDAD = '{2}'", direccion.Text, codPostal.Text, localidad.Text);

            if (!string.IsNullOrEmpty(piso.Text))
                consulta += string.Format("AND DIR_PISO = '{0}'", piso.Text);

            if (!string.IsNullOrEmpty(departamento.Text))
                consulta += string.Format("AND DIR_DEPARTAMENTO = '{0}'", departamento.Text);
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
            String errores = null;
            int asd;
            if (String.IsNullOrWhiteSpace(razonSocial.Text)) errores += "- El campo 'razonSocial' no puede estar vacío \n";
            if (String.IsNullOrWhiteSpace(cuit.Text)) errores += "- El campo 'cuit' no puede estar vacío\n";
            if (String.IsNullOrWhiteSpace(direccion.Text)) errores += "- El campo 'direccion' no puede estar vacío\n";
            if (String.IsNullOrWhiteSpace(rubro.Text)) errores += "- El campo 'rubro' no puede estar vacío\n";
            if (String.IsNullOrWhiteSpace(localidad.Text)) errores += "- El campo 'localidad' no puede estar vacío\n";
            if (String.IsNullOrWhiteSpace(codPostal.Text)) errores += "- El campo 'codPostal' no puede estar vacío\n";
            
            if (!int.TryParse(cuit.Text, out asd)) errores += "- El 'cuit' debe ser numérico \n";
            
            return errores;
        }

        public void limpiar()
        {
            razonSocial.Clear();
            cuit.Clear();
            direccion.Clear();
            //rubro.Clear();
            localidad.Clear();
            codPostal.Clear();
            piso.Clear();
            departamento.Clear();

        }
    }
}
