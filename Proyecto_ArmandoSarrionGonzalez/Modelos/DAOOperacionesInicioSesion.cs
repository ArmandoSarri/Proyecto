using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-------------------------------------------------------------------------------------------------------------------------------------------
// Armando Sarrión González
// Clase encargada de las operaciones realizadas sobre la base de datos tanto en el registro como en el inicio de sesión del usuario
//-------------------------------------------------------------------------------------------------------------------------------------------

namespace Proyecto_ArmandoSarrionGonzalez.Modelos
{
    class DAOOperacionesInicioSesion
    {

        // Lista de objetos que almacenará los datos necesarios
        List<Entidades.DTOUsuario> lUsuarios = new List<Entidades.DTOUsuario>();

        // Objeto de la clase que realiza la conexión a la base de datos
        DAOConexion objConexion = new DAOConexion();

        // Método encargado de leer la información del usuario de la base de datos
        public List<Entidades.DTOUsuario> leerDatos()
        {

            // Abrimos la conexión con la base de datos
            objConexion.abrirConexion();

            // Creamos un lector
            SqlDataReader lector;

            // Creamos un comando
            SqlCommand comando = new SqlCommand();

            // Le asignamos la conexión
            comando.Connection = objConexion.conexion;

            // Le asignamos la instrucción SQL
            comando.CommandText = "select Nombre, Contrasenia, Fecha_Creacion from usuario";

            // Ejecutamos el comando y recogemos los datos leidos
            lector = comando.ExecuteReader();

            // Si el lector ha leido datos 
            if (lector.HasRows)
            {
                // Leemos todas las filas de la tabla 
                while (lector.Read())
                {
                    // Guardamos los datos leidos en la lista
                    Entidades.DTOUsuario objUsuario = new Entidades.DTOUsuario();

                    objUsuario.nombre = lector.GetString(0);
                    objUsuario.contraseña = lector.GetString(1);
                    objUsuario.fechaRegistro = lector.GetDateTime(2);

                    lUsuarios.Add(objUsuario);
                }
            }

            // Cerramos el lector
            lector.Close();

            // Cerramos la conexión
            objConexion.cerrarConexion();

            // Devolvemos la lista
            return lUsuarios;
        }

        // Método encargado de insertar en la base de datos
        public void insertarDatos(Entidades.DTOUsuario objUsuario)
        {
            // Abrimos la conexión con la base de datos
            objConexion.abrirConexion();

            // Creamos un comando
            SqlCommand comandoInsert = new SqlCommand();

            // Definimos los parametros
            SqlParameter parametroNombre, parametroContraseña, parametroFecha;

            // Le asignamos la conexión
            comandoInsert.Connection = objConexion.conexion;

            // Le establecemos la orden SQL
            comandoInsert.CommandText = "insert into Usuario values (@nombre, @contraseña, @fecha)";

            // Asignamos al parametro su tipo de dato
            parametroNombre = new SqlParameter("nombre", System.Data.SqlDbType.VarChar);
            parametroContraseña = new SqlParameter("contraseña", System.Data.SqlDbType.VarChar);
            parametroFecha = new SqlParameter("fecha", System.Data.SqlDbType.DateTime);

            // Damos valores a los parametros
            parametroNombre.Value = objUsuario.nombre;
            parametroContraseña.Value = objUsuario.contraseña;
            parametroFecha.Value = objUsuario.fechaRegistro;

            // Añadimos los parametros al comando
            comandoInsert.Parameters.Add(parametroNombre);
            comandoInsert.Parameters.Add(parametroContraseña);
            comandoInsert.Parameters.Add(parametroFecha);

            // Ejecutamos el comando
            comandoInsert.ExecuteNonQuery();

            // Cerramos la conexión
            objConexion.cerrarConexion();

        }
    }
}
