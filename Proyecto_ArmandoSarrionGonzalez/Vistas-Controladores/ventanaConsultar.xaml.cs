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
    /// Lógica de interacción para ventanaConsultar.xaml
    /// </summary>
    public partial class ventanaConsultar : Window
    {
        public ventanaConsultar()
        {
            InitializeComponent();
        }

        public ventanaConsultar(string fechaSeleccionada, int botonPulsado)
        {
            InitializeComponent();

            if(botonPulsado == 1)
            {
                tbxFechaLlegada.Text = fechaSeleccionada;
            }
            else
            {
                if(botonPulsado == 2)
                {
                    tbxFechaSalida.Text = fechaSeleccionada;
                }
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }


        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if(sender == btnConsultarDoc)
            {
                
            }
            else
            {
                if(sender == btnConsultarPersona)
                {

                }
                else
                {
                    if(sender == btnConsultarOrg)
                    {

                    }
                }
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void BtnFecha_Click(object sender, RoutedEventArgs e)
        {
            

            // Comprobamos que botón ha pulsado el usuario 
            if (sender == btnFechaLlegada)
            {
                //Creamos un objeto de la clase calendario 
                ventanaCalendario objCalendario = new ventanaCalendario();

                // Mostramos el calendario
                objCalendario.ShowDialog();

                tbxFechaLlegada.Text = objCalendario.fecha;

            }
            else
            {
                if(sender == btnFechaSalida)
                {
                    //Creamos un objeto de la clase calendario 
                    ventanaCalendario objCalendario = new ventanaCalendario();

                    // Mostramos el calendario
                    objCalendario.ShowDialog();

                    tbxFechaSalida.Text = objCalendario.fecha;
                    
                }
            }
        }

    }
}
