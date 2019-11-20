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
    /// Lógica de interacción para ventanaPersonaInscrita.xaml
    /// </summary>
    public partial class ventanaPersonaInscrita : Window
    {
        public int tomo { get; set; }

        public int pagina { get; set; }
        
        public int seccion { get; set;}

        public ventanaPersonaInscrita()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ventanaInsertar objPersona = new ventanaInsertar();

                tomo = Convert.ToInt32(tbxTomo.Text);
                pagina = Convert.ToInt32(tbxPagina.Text);
                seccion = Convert.ToInt32(tbxSeccion.Text);

                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
