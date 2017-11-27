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
        private int _idEmpresa;
        public editarEmpresa()
        {
            InitializeComponent();
        }
        private void ActualizarEmpresa(int direccionId, int rubroId)
        {
            var con = new Conexion()
            {
                query = string.Format("UPDATE ONEFORALL.EMPRESAS " +
                "SET EMP_CUIT = '{0}', " +
                "EMP_NOMBRE = '{1}', " +
                "EMP_DIR_ID = '{2}', " +
                "EMP_RUB_ID = {3}, " +
                "EMP_ACTIVA = '{4}', " +
                "WHERE EMP_ID = {5}",
                cuit.Text, razonSocial.Text, direccionId, rubroId, Convert.ToInt16(checkHabilitada.Checked),
                _idEmpresa)
            };
            con.ejecutar();
        }
    }

}
