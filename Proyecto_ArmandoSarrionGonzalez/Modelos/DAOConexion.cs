using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_ArmandoSarrionGonzalez.Modelos
{
    public class DAOConexion
    {
        static string cadenaConexion = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;

        public SqlConnection conexion = new SqlConnection(cadenaConexion);

      
        // Método encargado de abrir la conexión con la base de datos
        public void abrirConexion()
        {           

            // Abrimos la conexión
            conexion.Open();
        }

        // Método encargado de cerrar la conexión con la base de datos
        public void cerrarConexion()
        {

            // Cerramos la conexión
            conexion.Close();
        }
    }
}
