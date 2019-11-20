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
    /// Lógica de interacción para ventanaSeleccionRemitente.xaml
    /// </summary>
    public partial class ventanaSeleccionRemitente : Window
    {
        public string nombre { get; set; }

        public ventanaSeleccionRemitente()
        {
            InitializeComponent();
        }

        public ventanaSeleccionRemitente(int id)
        {
            InitializeComponent();

            Modelos.DAOOperacionesDocBD objModelo = new Modelos.DAOOperacionesDocBD();

            List<string> nombres = new List<string>();

            nombres = objModelo.consultaNombresRemitentes(id);

            foreach(string nombre in nombres)
            {
                cbxNombres.Items.Add(nombre);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            nombre = cbxNombres.SelectedItem.ToString();
            this.Hide();
        }
    }
}
