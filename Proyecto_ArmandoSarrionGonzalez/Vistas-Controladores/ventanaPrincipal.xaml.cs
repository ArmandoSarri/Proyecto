using Microsoft.Win32;
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

//--------------------------------------------------------------------------------------------------------------------------------------
// Armando Sarrión González
// Clase principal de la aplicación
//--------------------------------------------------------------------------------------------------------------------------------------

namespace Proyecto_ArmandoSarrionGonzalez.Vistas_Controladores
{
    public partial class ventanaPrincipal : Window
    {
        // Usuario que ha iniciado sesion
        string usuario;

        ventanaInsertar objInsertar = null;

        ventanaConsultar objConsultar = null;

        public ventanaPrincipal(string usuarioNombre)
        {
            InitializeComponent();

            usuario = usuarioNombre;

        }

        // Evento load de la ventana
        private void VentanaPrincipal1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MiConsulta_Click(object sender, RoutedEventArgs e)
        {
            objConsultar = new ventanaConsultar();
            objConsultar.ShowDialog();
        }

        private void MiAgregar_Click(object sender, RoutedEventArgs e)
        {
            objInsertar = new ventanaInsertar();
            objInsertar.ShowDialog();
        }

        private void MiAyuda_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MiSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnSello_Click(object sender, RoutedEventArgs e)
        {
            // Abrimos el explorador de archivos para que el usuario escoja una imagen
            OpenFileDialog ofdImagen = new OpenFileDialog();

            BitmapImage b = new BitmapImage();

            ofdImagen.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";

            if(ofdImagen.ShowDialog() == true)
            {
                b.BeginInit();
                b.UriSource = new Uri(ofdImagen.FileName);
                b.EndInit();

                imgSello.Source = b;
            }
        }

        private void BtnColor_Click(object sender, RoutedEventArgs e)
        {
            ventanaColor color = new ventanaColor();

            color.Owner = this;

            if ((bool)color.ShowDialog())
            {
                this.gridPrincipal.Background = new SolidColorBrush(color.SelectedColor);
            }
        }

        private void BtnCerrarConfig_Click(object sender, RoutedEventArgs e)
        {
            // Ocultamos los tres botones
            btnColor.Visibility = Visibility.Hidden;
            btnSello.Visibility = Visibility.Hidden;
            btnCerrarConfig.Visibility = Visibility.Hidden;
        }

        private void MiConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            // Mostramos los tres botones
            btnColor.Visibility = Visibility.Visible;
            btnSello.Visibility = Visibility.Visible;
            btnCerrarConfig.Visibility = Visibility.Visible;
        }
    }
}
