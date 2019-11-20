using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

//----------------------------------------------------------------------------------------------------------------------------
// Armando Sarrión González
// Controlador de la ventana de registro de usuario
//----------------------------------------------------------------------------------------------------------------------------

namespace Proyecto_ArmandoSarrionGonzalez
{
    public partial class ventanaRegistro : Window
    {
        public ventanaRegistro()
        {
            InitializeComponent();
            
        }

        // Objetos de las diferentes clases que vamos a utilizar
        Modelos.DAOOperacionesInicioSesion objInicio = new Modelos.DAOOperacionesInicioSesion();

        
        // Variable con la contraseña
        string contraseña;

        // Evento asignado al click sobre el botón aceptar
        private void BtnAceptarRegistro_Click(object sender, RoutedEventArgs e)
        {
            // Comprobamos que los datos introducidos son válidos
            if(validar() == true)
            {
                // Obtenemos la contraseña que ha introducido el usuario
                contraseña = tbxContraseniaRegistro.Text;

                // Ciframos la contraseña
                contraseña = encriptar(contraseña);

                // Creamos un objeto al que añadiremos los datos introducidos
                Entidades.DTOUsuario objUsuario = new Entidades.DTOUsuario();

                objUsuario.nombre = tbxUsuarioRegistro.Text;
                objUsuario.contraseña = contraseña;
                objUsuario.fechaRegistro = DateTime.Today;

                // Introducimos los datos en la base de datos
                objInicio.insertarDatos(objUsuario);

                // Mensaje al usuario
                mensajes("Registro realizado con exito", "Registro");
              
            }
        }

        // Evento asignado al click sobre el botón cancelar
        private void BtnCancelarRegistro_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow ventanaInicio = new MainWindow();
            ventanaInicio.Show();
        }

        // Método encargado de la validación de los datos introducidos por el usuario
        public bool validar()
        {
            // Variable booleana que indicará la valided de los datos
            bool valido = false;

            // Comprobamos que ha introducido datos
            if((tbxUsuarioRegistro.Text.Length > 0) && (tbxContraseniaRegistro.Text.Length > 0) && (tbxRepContraseniaRegistro.Text.Length > 0))
            {
                // Comprobamos que la longitud de los datos es la correcta
                if (tbxUsuarioRegistro.Text.Length <= 40)
                {
                    if (tbxContraseniaRegistro.Text.Length <= 40)
                    {
                        // Comprobamos que las dos contraseñas introducidas sean iguales
                        if (tbxRepContraseniaRegistro.Text == tbxContraseniaRegistro.Text)
                        {
                            // La validación es correcta
                            valido = true;
                        }
                        else
                        {
                            labErrorRepContraseniaRegistro.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        labErrorContraseniaRegistro.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    labErrorUsuarioRegistro.Visibility = Visibility.Visible;
                }
            }
            else
            {
                mensajes("Debe completar todos los campos", "Error");
            }
            
            // Devolvemos la respuesta
            return valido;
        }

        // Método encargado de encriptar cualquier cadena que reciba
        public string encriptar(string cadena)
        {
            string resultado;
            byte[] encriptacion = System.Text.Encoding.Unicode.GetBytes(cadena);
            resultado = Convert.ToBase64String(encriptacion);
            return resultado;
        }

        // Método que centraliza los mensajes de la clase
        public void mensajes(string titulo, string mensaje)
        {
            MessageBox.Show(titulo, mensaje, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        
    }
}
