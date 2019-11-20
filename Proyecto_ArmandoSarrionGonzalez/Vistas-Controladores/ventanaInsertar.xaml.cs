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
    /// Lógica de interacción para ventanaInsertar.xaml
    /// </summary>
    public partial class ventanaInsertar : Window
    {
        Modelos.DAOOperacionesDocBD objModelo = new Modelos.DAOOperacionesDocBD();

        public int tomo, pagina, seccion;

        public ventanaInsertar()
        {
            InitializeComponent();
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
                if (sender == btnFechaSalida)
                {
                    //Creamos un objeto de la clase calendario 
                    ventanaCalendario objCalendario = new ventanaCalendario();

                    // Mostramos el calendario
                    objCalendario.ShowDialog();

                    tbxFechaSalida.Text = objCalendario.fecha;

                }
            }
        }

        private void BtnInsertar_Click(object sender, RoutedEventArgs e)
        {
            if(sender == btnInsertarDocumento)
            {
                Entidades.DTODocumento objDocumento = new Entidades.DTODocumento();

                objDocumento.identificador = Convert.ToInt32(tbxIdentificador.Text);
                objDocumento.contenido = tbxContenido.Text;
                objDocumento.fechaLlegada = Convert.ToDateTime(tbxFechaLlegada.Text);
                objDocumento.fechaSalida = Convert.ToDateTime(tbxFechaSalida.Text);
                objDocumento.juzgado = cbxPertenencia.SelectedItem.ToString();
                objDocumento.tipo = cbxTipoDocumento.SelectedItem.ToString();

                if (cbxTipoRemitente.SelectedItem.ToString().Equals("Persona"))
                {
                    ventanaSeleccionRemitente objSeleccion = new ventanaSeleccionRemitente(1);

                    objSeleccion.ShowDialog();

                    objDocumento.remitente = objSeleccion.nombre;

                    int idPersona = objModelo.consultarIdRemitente(objDocumento.remitente, 1);

                    objModelo.insertarDocumento(objDocumento, 1, idPersona);
                }
                else
                {
                    if (cbxTipoRemitente.SelectedItem.ToString().Equals("Organismo"))
                    {
                        ventanaSeleccionRemitente objSeleccion = new ventanaSeleccionRemitente(2);

                        objSeleccion.ShowDialog();

                        objDocumento.remitente = objSeleccion.nombre;

                        int idOrganismo = objModelo.consultarIdRemitente(objDocumento.remitente, 2);

                        objModelo.insertarDocumento(objDocumento, 2, idOrganismo);
                    }
                }             

            }
            else
            {
                if(sender == btnInsertarOrganismo)
                {
                    Entidades.DTOOrganismo objOrganismo = new Entidades.DTOOrganismo();

                    objOrganismo.nombre = tbxNombreOrganismo.Text;
                    objOrganismo.identificador = Convert.ToInt32(tbxIdentificadorOrganismo.Text);
                    objOrganismo.direccion = tbxDireccionOrganismo.Text;
                    objOrganismo.telefono1 = Convert.ToInt32(tbxTelefono1Org.Text);
                    objOrganismo.telefono2 = Convert.ToInt32(tbxTelefono2Org.Text);
                    objOrganismo.fax = Convert.ToInt32(tbxFaxOrg.Text);
                    objOrganismo.correo = tbxCorreoOrganismo.Text;

                    String mensajeOrganismo = objModelo.insertarOrganismo(objOrganismo);

                    MessageBox.Show(mensajeOrganismo, "Organismo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if(sender == btnInsertarPersona)
                    {
                        Entidades.DTOPersona objPersona = new Entidades.DTOPersona();

                        objPersona.identificador = Convert.ToInt32(tbxIdentificadorPersona.Text);
                        objPersona.correo = tbxCorreo.Text;
                        objPersona.direccion = tbxDireccion.Text;
                        objPersona.dni = tbxDni.Text;
                        objPersona.fax = Convert.ToInt32(tbxFaxPersona.Text);
                        objPersona.nombre = tbxNombre.Text;
                        objPersona.primerapellido = tbxPrimerApellido.Text;
                        objPersona.segundoapellido = tbxSegundoApellido.Text;
                        objPersona.telefono1 = Convert.ToInt32(tbxTelefono1.Text);
                        objPersona.telefono2 = Convert.ToInt32(tbxTelefono2.Text);

                        if (cbxTipoPersona.SelectedIndex == 0)
                        {
                            objPersona.tipo = "int";
                        }
                        else
                        {
                            if (cbxTipoPersona.SelectedIndex == 1)
                            {
                                objPersona.tipo = "insc";

                                ventanaPersonaInscrita objInscrito = new ventanaPersonaInscrita();

                                objInscrito.ShowDialog();

                                objPersona.tomo = objInscrito.tomo;
                                objPersona.pagina = objInscrito.pagina;
                                objPersona.seccion = objInscrito.seccion;
                            }
                        }
                        

                         String mensajePersona = objModelo.insertarPersona(objPersona);

                        MessageBox.Show(mensajePersona, "Persona", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
