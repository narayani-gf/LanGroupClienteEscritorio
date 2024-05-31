using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Modelos;
using LanGroupClienteEscritorio.Servicio;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LanGroupClienteEscritorio.Vista
{
    /* =========================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                       ==
     * == Fecha de actualización: 29/05/2024                                  ==
     * == Descripción: Logica de interacción para GUISolicitudInstructor.xaml ==
     * =========================================================================
     */
    public partial class GUISolicitudInstructor : Page
    {
        private string idUsuario;
        private string rolUsuario;
        Solicitud solicitud;

        public GUISolicitudInstructor()
        {
            InitializeComponent();
        } 

        public void IniciarVentanaColaborador(string idUsuario, string rolUsuario)
        {
            this.idUsuario = idUsuario;
            this.rolUsuario = rolUsuario;
        }

        public void IniciarVentanaAdministrador(string idUsuario, string rolUsuario, Solicitud solicitud, string usuarioSolicitante)
        {
            this.idUsuario = idUsuario;
            this.rolUsuario= rolUsuario;
            ModificarVisibilidadObjetos();
            CargarDatosSolicitud(solicitud, usuarioSolicitante);
        }

        private void ModificarVisibilidadObjetos()
        {
            labelSolicitarRol.Visibility = Visibility.Hidden;
            labelSolicitudDe.Visibility = Visibility.Visible;
            labelConstancia.Visibility = Visibility.Visible;
            buttonAgregarConstancia.Visibility = Visibility.Hidden;
            buttonDescargar.Visibility = Visibility.Visible;
            buttonGuardar.Visibility = Visibility.Hidden;
            comboBoxIdioma.Visibility = Visibility.Hidden;
            labelSeleccionarIdioma.Visibility = Visibility.Hidden;
            labelIdioma.Visibility = Visibility.Visible;
            textBoxRazon.IsReadOnly = true;
            textBoxTipoContenido.IsReadOnly = true;
        }

        private async void CargarDatosSolicitud(Solicitud solicitud, string usuarioSolicitante)
        {
            this.solicitud = solicitud;
            //TODO obtener los datos de la solicitud del usuario que el administrador está revisando.
            labelSolicitudDe.Content = "Solicitud de " + usuarioSolicitante;
            labelNombreArchivo.Content = "TODO";
            Idioma idiomaSolicitud = await IdiomaServicio.ObtenerIdiomaPorId(solicitud.idIdioma);
            labelIdioma.Content = idiomaSolicitud.nombre;
            textBoxRazon.Text = solicitud.motivo;
            textBoxTipoContenido.Text = solicitud.contenido;
        }

        private void AgregarConstancia(object sender, RoutedEventArgs e)
        {
            //TODO subir archivo
        }

        private void DescargarConstancia(object sender, RoutedEventArgs e)
        {
            //TODO obtener el archivo que subio el usuario
        }

        private async void GuardarSolicitud(object sender, RoutedEventArgs e)
        {
            limpiarErrores();
            if (CamposValidos())
            {
                Response response = await SolicitudServicio.GuardarSolicitud(solicitud);

                if(response.Codigo == 200)
                {
                    MessageBox.Show("Se subió la solicitud con éxito.", "Solicitud enviada", MessageBoxButton.OK);
                }
                else
                {
                    MostrarMensajeError();
                }
            }
        }

        private void Regresar(object sender, MouseButtonEventArgs e)
        {            
            if (rolUsuario.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                GUIInstructores guiInstructores = new GUIInstructores();
                guiInstructores.IniciarVentanaAgregarInstructor(idUsuario, rolUsuario);
                NavigationService.Navigate(guiInstructores);
            }
            else
            {
                Utils.AdministrarNavegacion.RegresarPaginaPrincipal();
            }

        }

        private bool CamposValidos()
        {
            bool validos = true;

            if(String.IsNullOrEmpty(textBoxRazon.Text)) 
            { 
                validos = false;
                labelErrorRazon.Content = "No se puede dejar vacío.";
                textBoxRazon.BorderBrush = Brushes.Red;
            }

            if (String.IsNullOrEmpty(textBoxTipoContenido.Text))
            {
                validos = false;
                labelErrorTipoContenido.Content = "No se puede dejar vacío.";
                textBoxTipoContenido.BorderBrush = Brushes.Red;
            }

            if (String.IsNullOrEmpty(labelNombreArchivo.Content.ToString()))
            {
                validos = false;
                labelErrorConstancia.Content = "Debe de subir una constancia.";
            }

            return validos;
        }

        private void limpiarErrores()
        {
            labelErrorProfesion.Content = String.Empty;
            labelErrorRazon.Content = String.Empty;
            textBoxRazon.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
            labelErrorTipoContenido.Content = String.Empty;
            textBoxTipoContenido.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
            labelErrorConstancia.Content= String.Empty;
        }

        private void MostrarMensajeError()
        {
            MessageBox.Show("Algo salió mal.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
