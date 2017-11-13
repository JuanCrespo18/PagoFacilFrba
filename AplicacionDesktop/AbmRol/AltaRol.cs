using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmRol
{
    public partial class AltaRol : Form
    {
        private ListarRoles _abmListadoRol;
        private List<string> _funcionalidades = new List<string>();
        private List<string> _funcionalidadesNuevas = new List<string>();
        private List<string> _funcionalidadesQuitadas = new List<string>();
        private int _idRol;
        private bool _habilitado;
        private char _evento;

        public AltaRol()
        {
            InitializeComponent();
        }

        public AltaRol(ListarRoles abmListadoRol)
        {
            InitializeComponent();
            this._abmListadoRol = abmListadoRol;
        }

        public void CargarRol(string nombreRol, int idRol)
        {
            _idRol = idRol;
            txtRol.Text = nombreRol;

            if (!string.IsNullOrEmpty(nombreRol))
            {
                txtRol.ReadOnly = true;
                _evento = 'M';
            }
            else
                _evento = 'A';
                

            string funcionalidad;
            Conexion con = new Conexion();
            Conexion con2 = new Conexion();
            con.query = "SELECT FUNC_DESCRIPCION FROM ONEFORALL.FUNCIONALIDADES";
            con.leer();
            int i = 0;
            while (con.leerReader())
            {
                funcionalidad = con.lector.GetString(0);
                chlbFunc.Items.Add(funcionalidad);

                con2.query = string.Format("SELECT 1 FROM ONEFORALL.ROL_X_FUNCIONALIDAD RF " +
                                "JOIN ONEFORALL.FUNCIONALIDADES F ON F.FUNC_ID = RF.FUNCX_ID " +
                                "AND F.FUNC_DESCRIPCION = '{0}' " +
                                "AND RF.ROLX_ID = {1}", funcionalidad, _idRol);
                con2.leer();
                if (con2.leerReader())
                {
                    chlbFunc.SetItemChecked(i, true);
                    _funcionalidades.Add(chlbFunc.Items[i].ToString());
                }
                con2.cerrarConexion();
                i++;
            }
            con.cerrarConexion();

            Conexion con3 = new Conexion()
            {
                query = string.Format("SELECT ROL_ACTIVO FROM ONEFORALL.ROLES WHERE ROL_NOMBRE = '{0}'", nombreRol)
            };
            con3.leer();
            while(con3.leerReader())
            {
                _habilitado = con3.lector.GetBoolean(0);
                chkActivo.Checked = _habilitado;
            }
            con3.cerrarConexion();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_evento == 'A')
                {
                    ValidarNombreRol();

                    var con = new Conexion()
                    {
                        query = string.Format("INSERT INTO ONEFORALL.ROLES VALUES ('{0}', {1})", txtRol.Text, Convert.ToInt32(chkActivo.Checked))
                    };
                    con.ejecutar();
                    con.cerrarConexion();

                    con = new Conexion()
                    {
                        query = string.Format("SELECT ROL_ID FROM ONEFORALL.ROLES WHERE ROL_NOMBRE = '{0}'", txtRol.Text)
                    };
                    con.leer();
                    con.leerReader();
                    _idRol = con.lector.GetInt32(0);
                    con.cerrarConexion();
                }
                _funcionalidadesNuevas.RemoveAll(x => _funcionalidades.Contains(x));
                _funcionalidadesQuitadas.RemoveAll(x => !_funcionalidades.Contains(x));

                if (_funcionalidadesNuevas.Count != 0)
                {
                    var funcNuevas = _funcionalidadesNuevas.Select(x => x = "'" + x + "'").ToList<string>();
                    List<int> idsFuncNuevas = new List<int>();
                    var con = new Conexion()
                    {
                        query = string.Format("SELECT FUNC_ID FROM ONEFORALL.FUNCIONALIDADES WHERE FUNC_DESCRIPCION IN ({0})", string.Join(",", funcNuevas))
                    };
                    con.leer();
                    while (con.leerReader())
                    {
                        idsFuncNuevas.Add(con.lector.GetInt32(0));
                    }
                    con.cerrarConexion();

                    var insertar = idsFuncNuevas.Select(x => string.Format("({0},{1})", x, _idRol)).ToList();

                    con = new Conexion()
                    {
                        query = string.Format("INSERT INTO ONEFORALL.ROL_X_FUNCIONALIDAD VALUES {0}", string.Join(",", insertar))
                    };
                    con.ejecutar();
                    con.cerrarConexion();
                    _funcionalidadesNuevas.ForEach(x => _funcionalidades.Add(x));
                }

                if (_funcionalidadesQuitadas.Count != 0)
                {
                    var funcQuitadas = _funcionalidadesQuitadas.Select(x => x = "'" + x + "'").ToList<string>();
                    List<int> idsFuncQuitadas = new List<int>();
                    var con = new Conexion()
                    {
                        query = string.Format("SELECT FUNC_ID FROM ONEFORALL.FUNCIONALIDADES WHERE FUNC_DESCRIPCION IN ({0})", string.Join(",", funcQuitadas))
                    };
                    con.leer();
                    while (con.leerReader())
                    {
                        idsFuncQuitadas.Add(con.lector.GetInt32(0));
                    }
                    con.cerrarConexion();

                    con = new Conexion()
                    {
                        query = string.Format("DELETE FROM ONEFORALL.ROL_X_FUNCIONALIDAD WHERE ROLX_ID = {0} AND FUNCX_ID IN ({1})", _idRol, string.Join(",", idsFuncQuitadas))
                    };
                    con.ejecutar();
                    con.cerrarConexion();
                    _funcionalidadesQuitadas.ForEach(x => _funcionalidades.Remove(x));
                }

                if (_habilitado != chkActivo.Checked)
                {
                    var con = new Conexion()
                    {
                        query = string.Format("UPDATE ONEFORALL.ROLES SET ROL_ACTIVO = {0} WHERE ROL_ID = {1}", Convert.ToInt32(chkActivo.Checked), _idRol)
                    };
                    con.ejecutar();
                    con.cerrarConexion();

                    if (!chkActivo.Checked)
                    {
                        con = new Conexion()
                        {
                            query = string.Format("DELETE FROM ONEFORALL.USUARIO_X_ROL WHERE ROL_ID = {0}", _idRol)
                        };
                    con.ejecutar();
                    con.cerrarConexion();
                    }
                }
                if (_evento == 'A')
                {
                    MessageBox.Show("Rol creado correctamente", "Crear Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (_habilitado == chkActivo.Checked && _funcionalidadesQuitadas.Count == 0 && _funcionalidadesNuevas.Count == 0)
                    MessageBox.Show("No se realizaron cambios", "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Rol modificado correctamente", "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _funcionalidadesNuevas.Clear();
                _funcionalidadesQuitadas.Clear();

                _abmListadoRol.CargarRoles();
                _abmListadoRol.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _evento == 'A'? "Crear Rol":"Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarNombreRol()
        {
            if (string.IsNullOrEmpty(txtRol.Text))
            {
                throw new Exception("Debe ingresar nombre del rol");
            }
            this._abmListadoRol.ValidarRolNuevo(txtRol.Text);
        }

        private void chlbFunc_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var func = chlbFunc.SelectedItem;
            if(func != null)
            {
                if (!chlbFunc.CheckedItems.Contains(func))
                {
                    _funcionalidadesNuevas.Add(func.ToString());
                    _funcionalidadesQuitadas.Remove(func.ToString());
                }
                else
                {
                    _funcionalidadesQuitadas.Add(func.ToString());
                    _funcionalidadesNuevas.Remove(func.ToString());
                }
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            _abmListadoRol.Show();
            this.Close();
        }
    }
}
