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

//-----------------------------------------------------------------------------------------------------------------------------------
// Armando Sarrión González
// Clase encargada del inicio de sesión del usuario
//-----------------------------------------------------------------------------------------------------------------------------------

namespace Proyecto_ArmandoSarrionGonzalez
{
    public partial class ventanaLogin : Window
    {

        // Lista con los usuarios registrados en la base de datos
        List<Entidades.DTOUsuario> lUsuarios = new List<Entidades.DTOUsuario>();

        // Objeto de las clase que vamos a necesitar
        Modelos.DAOOperacionesInicioSesion objInicio = new Modelos.DAOOperacionesInicioSesion();       
        
        public ventanaLogin()
        {
            InitializeComponent();         
        }

        // Evento asignado al click sobre el botón aceptar
        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            // Vaciamos la lista
            lUsuarios.Clear();

            // Recogemos los datos de todos los usuario
            lUsuarios = objInicio.leerDatos();
           
            // Comprobamos que la lista no esté vacía
            if(lUsuarios.Count > 0)
            {
                string usuarioIntroducido = tbxUsuario.Text;

                // Variable booleana que indicará la coincidencia de usuarios
                bool valido = false;

                // Comparamos los items de la lista con el nombre de usuario y contraseña introducidos por el usuario
                foreach (Entidades.DTOUsuario usuario in lUsuarios)
                {
                    // Desencriptamos la contraseña
                    string contraseña = desEncriptar(usuario.contraseña);

                    // Si el usuario y la contraseña coinciden, dejamos al usuario acceder a la aplicación
                    if ((usuario.nombre.Equals(usuarioIntroducido)) && (contraseña.Equals(tbxContrasenia.Password)))
                    {
                        valido = true;
                    }
                }

                // Comprobamos si el usuario puede iniciar sesión
                if (valido)
                {
                    Vistas_Controladores.ventanaPrincipal objPrincipal = new Vistas_Controladores.ventanaPrincipal(usuarioIntroducido);
                    objPrincipal.Show();
                    this.Close();
                }
                else
                {
                    mensajes("Error de inicio de sesión", "Para iniciar sesión debe estar registrado");
                }
            }
            else
            {
                
            }
        }

        // Evento asignado al click sobre el botón cancelar
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        // Método encargado de desencriptar la contraseña
        public string desEncriptar(string cadena)
        {
            string resultado;
            byte[] desencriptar =
            Convert.FromBase64String(cadena);
            resultado = System.Text.Encoding.Unicode.GetString(desencriptar, 0, desencriptar.ToArray().Length);
            resultado = System.Text.Encoding.Unicode.GetString(desencriptar);
            return resultado;
        }

        // Método para centralizar mensajes
        public void mensajes(string titulo, string mensaje)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
