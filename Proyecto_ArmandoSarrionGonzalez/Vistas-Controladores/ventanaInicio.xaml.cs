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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_ArmandoSarrionGonzalez
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        // Evento load del formulario
        private void VentanaPrincipal1_Loaded(object sender, RoutedEventArgs e)
        {
            //Creamos una animación
            var animacionImagen = new DoubleAnimation();

            // Propiedades de la animación
            animacionImagen.From = 1;
            animacionImagen.To = 0;

            // Hacemos que la animación se repita infinitamente
            animacionImagen.AutoReverse = true;
            animacionImagen.RepeatBehavior = RepeatBehavior.Forever;

            // Asignamos la animación a la imágen
            imgBienvenido.BeginAnimation(Image.OpacityProperty, animacionImagen);
        }

        // Click sobre el botón de iniciar sesión
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Creamos un objeto del formulario hijo encargado de pedir los datos al usuario para el Log In
            ventanaLogin objLogin = new ventanaLogin();

            // Usamos el objeto para lanzar el formulario hijo
            objLogin.Show();
            //this.Close();
        }

        // Click sobre el botón de registro
        private void BtnRegistro_Click(object sender, RoutedEventArgs e)
        {
            // Creamos un objeto del formulario hijo encargado del registro
            ventanaRegistro objRegistro = new ventanaRegistro();

            // Usamos el objeto para lanzar el formulario hijo
            objRegistro.Show();
            //this.Close();
        }
    }
}
