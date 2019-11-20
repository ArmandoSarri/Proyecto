using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//--------------------------------------------------------------------------------------------------------------------------------
// Armando Sarrión González
// Clase encargada de realizar la lectura, escritura, modificación y borrado de los datos de la base de datos.
//--------------------------------------------------------------------------------------------------------------------------------

namespace Proyecto_ArmandoSarrionGonzalez.Modelos
{
    class DAOOperacionesDocBD
    {      
        // Objeto de la clase que realiza la conexión a la base de datos
        DAOConexion objConexion = new DAOConexion();
        
       /* public List<Entidades.DTODocumento> consultaDocumentos (string condicion)
        {
            List<Entidades.DTODocumento> listaConsulta = new List<Entidades.DTODocumento>();

            using (var contexto = new ProyectoEntities())
            {
                var consulta = from documento in contexto.Documento
                               where 
                               select new
                               {
                                   documento.id_doc,
                                   documento.fecha_llegada,
                                   documento.fecha_salida,
                                   documento.contenido,
                                   documento.tipo,
                                   documento.pertenencia,
                                   documento.id_organismo,
                                   documento.id_remitente,
                               };

                foreach(var item in consulta)
                {
                    Entidades.DTODocumento objDocumento = new Entidades.DTODocumento();

                    objDocumento.identificador = item.id_doc;
                    objDocumento.fechaLlegada = item.fecha_llegada;
                    objDocumento.fechaSalida = item.fecha_salida;
                    objDocumento.contenido = item.contenido;
                    objDocumento.tipo = item.tipo;
                    objDocumento.juzgado = item.pertenencia;
                    
                    if(item.id_organismo != null)
                    {
                        objDocumento.remitente = consultaRemitente(Convert.ToInt32(item.id_organismo), "org");
                    }
                    else
                    {
                        if(item.id_remitente != null)
                        {
                            objDocumento.remitente = consultaRemitente(Convert.ToInt32(item.id_remitente), "persona");
                        }
                    }

                    listaConsulta.Add(objDocumento);
                }

                return listaConsulta;
            }
        }*/

        public string consultaRemitente(int id, string tabla)
        {
            using (var contexto = new ProyectoEntities())
            {
                string consulta = "";

                if (tabla.Equals("persona"))
                {
                    consulta = (from persona in contexto.Personas
                                    where persona.id_persona == id
                                    select persona.nombre).First();
                }
                else
                {
                    if (tabla.Equals("org"))
                    {
                        consulta = (from organismo in contexto.Organismo
                                        where organismo.id_organismo == id
                                        select organismo.nombre).First();
                    }
                }

                return consulta;
            }
        }

        public List<string> consultaNombresRemitentes(int id)
        {
            using (var contexto = new ProyectoEntities())
            {
                List<string> nombres = new List<string>();

                if(id == 1)
                {
                    var consulta = from persona in contexto.Personas
                               select persona.nombre;

                    foreach(var item in consulta)
                    {
                        nombres.Add(item);
                    }
                }
                else
                {
                    if(id == 2)
                    {
                        var consulta = from organismo in contexto.Organismo
                                       select organismo.nombre;

                        foreach(var item in consulta)
                        {
                            nombres.Add(item);
                        }
                    }
                }

                return nombres;
            }
        }

        public int consultarIdRemitente(string nombre, int id)
        {
            using(var contexto = new ProyectoEntities())
            {
                int respuesta = 0;

                if(id == 1)
                {
                    var consulta = (from persona in contexto.Personas
                                    where persona.nombre.Equals(nombre)
                                    select persona.id_persona).First();

                    respuesta = consulta;
                }
                else
                {
                    if(id == 2)
                    {
                        var consulta = (from organismo in contexto.Organismo
                                        where organismo.nombre.Equals(nombre)
                                        select organismo.id_organismo).First();

                        respuesta = consulta;
                    }                
                }

                return respuesta;
            }
        }

        // Método encargado de insertar en la base de datos
        public String insertarDocumento(Entidades.DTODocumento objDocumento, int id, int idRemitente)
        {
            try
            {

                // Abrimos la conexion
                objConexion.abrirConexion();

                // Creamos un comando
                SqlCommand comandoInsert = new SqlCommand();
                SqlCommand comandoInsert2 = new SqlCommand();

                // Definimos los parametros
                SqlParameter parametroIdentificador, parametroContenido, parametroFechaLlegada, parametroFechaSalida, parametroTipo, parametroJuzgado, parametroRemitentePersona, parametroRemitenteOrganismo;

                // Le asignamos la conexión
                comandoInsert.Connection = objConexion.conexion;
                comandoInsert2.Connection = objConexion.conexion;

                // Le establecemos la orden SQL
                comandoInsert.CommandText = "insert into Documento (id_doc, tipo, contenido, fecha_llegada, fecha_salida, pertenencia, id_remitente) values (@identificador, @tipo, @contenido, @fechallegada, @fechasalida, @pertenencia, @remitentePersona)";
                comandoInsert2.CommandText = "insert into Documento (id_doc, tipo, contenido, fecha_llegada, fecha_salida, pertenencia, id_organismo) values (@identificador, @tipo, @contenido, @fechallegada, @fechasalida, @pertenencia, @remitenteOrganismo)";

                // Asignamos al parametro su tipo de dato
                parametroIdentificador = new SqlParameter("identificador", System.Data.SqlDbType.Int);
                parametroTipo = new SqlParameter("tipo", System.Data.SqlDbType.VarChar);
                parametroContenido = new SqlParameter("contenido", System.Data.SqlDbType.VarChar);
                parametroFechaLlegada = new SqlParameter("fechallegada", System.Data.SqlDbType.DateTime);
                parametroFechaSalida = new SqlParameter("fechasalida", System.Data.SqlDbType.DateTime);
                parametroJuzgado = new SqlParameter("pertenencia", System.Data.SqlDbType.VarChar);
                parametroRemitentePersona = new SqlParameter("remitentePersona", System.Data.SqlDbType.Int);
                parametroRemitenteOrganismo = new SqlParameter("remitenteOrganismo", System.Data.SqlDbType.Int);

                // Damos valores a los parametros
                parametroIdentificador.Value = objDocumento.identificador;
                parametroTipo.Value = objDocumento.tipo;
                parametroContenido.Value = objDocumento.contenido;
                parametroFechaLlegada.Value = objDocumento.fechaLlegada;
                parametroFechaSalida.Value = objDocumento.fechaSalida;
                parametroJuzgado.Value = objDocumento.juzgado;
                parametroRemitentePersona.Value = idRemitente;
                parametroRemitenteOrganismo.Value = idRemitente;

                // Añadimos los parametros al comando
                comandoInsert.Parameters.Add(parametroIdentificador);
                comandoInsert.Parameters.Add(parametroTipo);
                comandoInsert.Parameters.Add(parametroContenido);
                comandoInsert.Parameters.Add(parametroFechaLlegada);
                comandoInsert.Parameters.Add(parametroFechaSalida);
                comandoInsert.Parameters.Add(parametroJuzgado);
                comandoInsert.Parameters.Add(parametroRemitentePersona);

                comandoInsert2.Parameters.Add(parametroIdentificador);
                comandoInsert2.Parameters.Add(parametroTipo);
                comandoInsert2.Parameters.Add(parametroContenido);
                comandoInsert2.Parameters.Add(parametroFechaLlegada);
                comandoInsert2.Parameters.Add(parametroFechaSalida);
                comandoInsert2.Parameters.Add(parametroJuzgado);
                comandoInsert2.Parameters.Add(parametroRemitenteOrganismo);

                if(id == 1)
                {
                    // Ejecutamos el comando
                    comandoInsert.ExecuteNonQuery();
                }
                else
                {
                    if(id == 2)
                    {
                        // Ejecutamos el comando
                        comandoInsert2.ExecuteNonQuery();
                    }
                }

                //Cerramos la conexion
                objConexion.cerrarConexion();

                return "Documento insertado con éxito";

            }

            catch(Exception e)
            {
                //Cerramos la conexion
                objConexion.cerrarConexion();

                return e.Message;
            }

        }

        public String insertarPersona(Entidades.DTOPersona objPersona)
        {
            try
            {

                // Abrimos la conexion
                objConexion.abrirConexion();

                // Creamos un comando
                SqlCommand comandoInsertInscrito = new SqlCommand();
                SqlCommand comandoInsert = new SqlCommand();

                // Definimos los parametros
                SqlParameter parametroIdentificador, parametroNombre, parametroApellido1, parametroApellido2, parametroTelefono1, parametroTelefono2, parametroCorreo, parametroDireccion, parametroFax, parametroTipo, parametroDni, parametroTomo, parametroSeccion, parametroPagina, parametroIdentificadorInscrito;

                // Le asignamos la conexión
                comandoInsertInscrito.Connection = objConexion.conexion;
                comandoInsert.Connection = objConexion.conexion;

                // Le establecemos la orden SQL
                comandoInsert.CommandText = "insert into Personas values (@identificador, @nombre, @apellido1, @apellido2, @telefono1, @telefono2, @direccion, @dni, @fax, @correo, @tipo)";
                comandoInsertInscrito.CommandText = "insert into Persona_Inscrita values (@identificadorInscrito, @tomo, @pagina, @seccion)";

                // Asignamos al parametro su tipo de dato
                parametroIdentificador = new SqlParameter("identificador", System.Data.SqlDbType.Int);
                parametroTipo = new SqlParameter("tipo", System.Data.SqlDbType.VarChar);
                parametroNombre = new SqlParameter("nombre", System.Data.SqlDbType.VarChar);
                parametroApellido1 = new SqlParameter("apellido1", System.Data.SqlDbType.VarChar);
                parametroApellido2 = new SqlParameter("apellido2", System.Data.SqlDbType.VarChar);
                parametroDireccion = new SqlParameter("direccion", System.Data.SqlDbType.VarChar);
                parametroDni = new SqlParameter("dni", System.Data.SqlDbType.VarChar);
                parametroTelefono1 = new SqlParameter("telefono1", System.Data.SqlDbType.Int);
                parametroTelefono2 = new SqlParameter("telefono2", System.Data.SqlDbType.Int);
                parametroFax = new SqlParameter("fax", System.Data.SqlDbType.Int);
                parametroCorreo = new SqlParameter("correo", System.Data.SqlDbType.VarChar);

                parametroTomo = new SqlParameter("tomo", System.Data.SqlDbType.Int);
                parametroPagina = new SqlParameter("pagina", System.Data.SqlDbType.Int);
                parametroSeccion = new SqlParameter("seccion", System.Data.SqlDbType.Int);
                parametroIdentificadorInscrito = new SqlParameter("identificadorInscrito", System.Data.SqlDbType.Int);

                // Damos valores a los parametros
                parametroIdentificador.Value = objPersona.identificador;
                parametroTipo.Value = objPersona.tipo;
                parametroNombre.Value = objPersona.nombre;
                parametroApellido1.Value = objPersona.primerapellido;
                parametroApellido2.Value = objPersona.segundoapellido;
                parametroDireccion.Value = objPersona.direccion;
                parametroDni.Value = objPersona.dni;
                parametroTelefono1.Value = objPersona.telefono1;
                parametroTelefono2.Value = objPersona.telefono2;
                parametroFax.Value = objPersona.fax;
                parametroCorreo.Value = objPersona.correo;

                parametroTomo.Value = objPersona.tomo;
                parametroPagina.Value = objPersona.pagina;
                parametroSeccion.Value = objPersona.seccion;
                parametroIdentificadorInscrito.Value = objPersona.identificador;

                // Añadimos los parametros al comando
                comandoInsert.Parameters.Add(parametroIdentificador);
                comandoInsert.Parameters.Add(parametroTipo);
                comandoInsert.Parameters.Add(parametroNombre);
                comandoInsert.Parameters.Add(parametroApellido1);
                comandoInsert.Parameters.Add(parametroApellido2);
                comandoInsert.Parameters.Add(parametroDireccion);
                comandoInsert.Parameters.Add(parametroDni);
                comandoInsert.Parameters.Add(parametroTelefono1);
                comandoInsert.Parameters.Add(parametroTelefono2);
                comandoInsert.Parameters.Add(parametroFax);
                comandoInsert.Parameters.Add(parametroCorreo);

                comandoInsertInscrito.Parameters.Add(parametroIdentificadorInscrito);
                comandoInsertInscrito.Parameters.Add(parametroTomo);
                comandoInsert.Parameters.Add(parametroPagina);
                comandoInsert.Parameters.Add(parametroSeccion);

                // Ejecutamos el comando
                comandoInsert.ExecuteNonQuery();

                if (objPersona.tipo.Equals("insc"))
                {
                    comandoInsertInscrito.ExecuteNonQuery();
                }

                //Cerramos la conexion
                objConexion.cerrarConexion();

                return "Persona insertada con éxito";

            }

            catch (Exception e)
            {
                //Cerramos la conexion
                objConexion.cerrarConexion();

                return e.Message;
            }

        }

        public String insertarOrganismo(Entidades.DTOOrganismo objOrganismo)
        {
            try
            {

                // Abrimos la conexion
                objConexion.abrirConexion();

                // Creamos un comando
                SqlCommand comandoInsert = new SqlCommand();

                // Definimos los parametros
                SqlParameter parametroIdentificador, parametroNombre, parametroDireccion, parametroFax, parametroCorreo, parametroTelefono1, parametroTelefono2;

                // Le asignamos la conexión
                comandoInsert.Connection = objConexion.conexion;

                // Le establecemos la orden SQL
                comandoInsert.CommandText = "insert into Organismo values (@identificador, @nombre, @telefono1, @telefono2, @direccion, @fax, @correo)";

                // Asignamos al parametro su tipo de dato
                parametroIdentificador = new SqlParameter("identificador", System.Data.SqlDbType.Int);
                parametroNombre = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                parametroDireccion = new SqlParameter("direccion", System.Data.SqlDbType.VarChar);
                parametroFax = new SqlParameter("fax", System.Data.SqlDbType.Int);
                parametroCorreo = new SqlParameter("correo", System.Data.SqlDbType.VarChar);
                parametroTelefono1 = new SqlParameter("telefono1", System.Data.SqlDbType.Int);
                parametroTelefono2 = new SqlParameter("telefono2", System.Data.SqlDbType.Int);

                // Damos valores a los parametros
                parametroIdentificador.Value = objOrganismo.identificador;
                parametroNombre.Value = objOrganismo.nombre;
                parametroDireccion.Value = objOrganismo.direccion;
                parametroFax.Value = objOrganismo.fax;
                parametroCorreo.Value = objOrganismo.correo;
                parametroTelefono1.Value = objOrganismo.telefono1;
                parametroTelefono2.Value = objOrganismo.telefono2;

                // Añadimos los parametros al comando
                comandoInsert.Parameters.Add(parametroIdentificador);
                comandoInsert.Parameters.Add(parametroNombre);
                comandoInsert.Parameters.Add(parametroDireccion);
                comandoInsert.Parameters.Add(parametroFax);
                comandoInsert.Parameters.Add(parametroCorreo);
                comandoInsert.Parameters.Add(parametroTelefono1);
                comandoInsert.Parameters.Add(parametroTelefono2);

                // Ejecutamos el comando
                comandoInsert.ExecuteNonQuery();

                //Cerramos la conexion
                objConexion.cerrarConexion();

                return "Organismo insertado con éxito";

            }

            catch (Exception e)
            {
                //Cerramos la conexion
                objConexion.cerrarConexion();

                return e.Message;
            }

        }

        /*
        // Método encargado de actualizar la base de datos
        public void actualizarDatos(Entidades.DTOArea objArea, string areaActualizar, int tipoActualizacion)
        {
            // Creamos un comando
            SqlCommand comandoUpdate = new SqlCommand();

            // Definimos los parametros
            SqlParameter parametroArea, parametroCabecera, parametroHospital, parametroImagen, parametroAreaAntigua;

            // Le asignamos la conexión
            comandoUpdate.Connection = conexion;

            // Le establecemos la orden SQL
            comandoUpdate.CommandText = "update Areas set descripcion = @area, cabecera = @cabecera, hospital = @hospital, imagen = @imagen where descripcion = @areaAntigua";

            // Asignamos al parametro su tipo de dato
            parametroArea = new SqlParameter("area", System.Data.SqlDbType.VarChar);
            parametroCabecera = new SqlParameter("cabecera", System.Data.SqlDbType.VarChar);
            parametroHospital = new SqlParameter("hospital", System.Data.SqlDbType.VarChar);
            parametroImagen = new SqlParameter("imagen", System.Data.SqlDbType.Image);
            parametroAreaAntigua = new SqlParameter("areaAntigua", System.Data.SqlDbType.VarChar);

            // Damos valores a los parametros
            parametroArea.Value = objArea.descripcion;
            parametroCabecera.Value = objArea.cabecera;
            parametroHospital.Value = objArea.hospital;
            parametroImagen.Value = objArea.imagen;
            parametroAreaAntigua.Value = areaActualizar;

            // Añadimos los parametros al comando
            comandoUpdate.Parameters.Add(parametroArea);
            comandoUpdate.Parameters.Add();
            comandoUpdate.Parameters.Add();
            comandoUpdate.Parameters.Add();
            comandoUpdate.Parameters.Add();

            // Ejecutamos el comando
            comandoUpdate.ExecuteNonQuery();
        }

        
        // Método encargado del borrado en la base de datos
        public void borrarDatos(string area)
        {
            // Creamos un comando
            SqlCommand comandoDelete = new SqlCommand();

            // Definimos los parametros
            SqlParameter parametroArea;

            // Le asignamos la conexión
            comandoDelete.Connection = conexion;

            // Le establecemos la orden SQL
            comandoDelete.CommandText = "delete from Areas where descripcion = @area";

            // Asignamos al parametro su tipo de dato
            parametroArea = new SqlParameter("area", System.Data.SqlDbType.VarChar);

            // Damos valores a los parametros
            parametroArea.Value = area;

            // Añadimos los parametros al comando
            comandoDelete.Parameters.Add(parametroArea);

            // Ejecutamos el comando
            comandoDelete.ExecuteNonQuery();
        }
        */
    }
    
}

