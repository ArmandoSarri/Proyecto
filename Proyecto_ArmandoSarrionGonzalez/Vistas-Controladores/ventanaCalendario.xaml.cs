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

namespace Proyecto_ArmandoSarrionGonzalez.Vistas_Controladores
{
    /// <summary>
    /// Lógica de interacción para ventanaCalendario.xaml
    /// </summary>
    public partial class ventanaCalendario : Window
    {

        public String fecha { get; set; }

        public ventanaCalendario()
        {
            InitializeComponent();
        }

        // Evento click sobre el botón aceptar
        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            fecha = tbxFechaSeleccionada.Text;

            // Cerramos la ventana
            this.Hide();
        }
    }
}
