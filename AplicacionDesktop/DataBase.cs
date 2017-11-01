using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba
{
    public class Conexion
    {
        private string connectionString = "Data Source=JUAN-HP\\SQLSERVER2017;Initial Catalog=GD2C2017;Persist Security Info=True;User ID=gd;Password=gestiondedatos";
        public string query = "";
        public SqlCommand command;
        public SqlConnection cnx;
        public SqlDataReader lector;

        public Conexion()
        {
            //"Data Source=localhost\\SQLSERVER2008;Initial Catalog=SQLAZO;User ID=gd;Password=gd2014";
            this.cnx = new SqlConnection(this.connectionString);
        }

        public void comandear()
        {
            command = new SqlCommand(query, cnx);
        }

        public void abrirConexion()
        {
            cnx.Open();
        }
        public void cerrarConexion()
        {
            cnx.Close();
        }
        /*Ejecuta un query que no devuleve datos(UPDATE, INSERT, DELETE, etc)*/
        public void ejecutarNoQuery()
        {
            this.abrirConexion();
            comandear();
            command.ExecuteNonQuery();
            this.cerrarConexion();
        }

        /*Ejecuta un query que devuelva datos(SELECT)*/
        /*Despues de ejecutar este metodo y terminar de usar el Reader*/
        /*SIEMPRE utilizar cerrarConexion */
        public void ejecutarQuery()
        {
            this.abrirConexion();
            comandear();
            lector = command.ExecuteReader();
        }

        public bool leerReader()
        {
            return lector.Read();
        }

    }
}
