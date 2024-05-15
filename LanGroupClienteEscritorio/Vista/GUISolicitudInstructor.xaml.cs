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
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 15/05/2024                                ==
     * == Descripción: Logica de interacción para GUISolicitudInstructor.xaml ==
     * =======================================================================
     */
    public partial class GUISolicitudInstructor : Page
    {
        private string rolUsuario;
        public GUISolicitudInstructor()
        {
            InitializeComponent();
        } 

        public void IniciarVentana(string rolUsuario, int idUsuarioSolicitante)
        {
            this.rolUsuario = rolUsuario;

            if (rolUsuario.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                ModificarVisibilidadObjetos();
                CargarDatosSolicitud(idUsuarioSolicitante);
            }
        }

        private void ModificarVisibilidadObjetos()
        {
            labelSolicitarRol.Visibility = Visibility.Hidden;
            labelSolicitudDe.Visibility = Visibility.Visible;
            labelConstancia.Visibility = Visibility.Visible;
            buttonAgregarConstancia.Visibility = Visibility.Hidden;
            buttonDescargar.Visibility = Visibility.Visible;
            buttonGuardar.Visibility = Visibility.Hidden;
        }

        private void CargarDatosSolicitud(int idUsuarioSolicitante)
        {
            //TODO obtener los datos de la solicitud del usuario que el administrador está revisando.
        }

        private void AgregarConstancia(object sender, RoutedEventArgs e)
        {

        }

        private void DescargarConstancia(object sender, RoutedEventArgs e)
        {

        }

        private void GuardarSolicitud(object sender, RoutedEventArgs e)
        {

        }

        private void Regresar(object sender, MouseButtonEventArgs e)
        {            
            if (rolUsuario.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                GUIInstructores guiInstructores = new GUIInstructores();
                guiInstructores.IniciarVentanaAgregarInstructor(rolUsuario);
                NavigationService.Navigate(guiInstructores);
            }
            else
            {
                //TODO regresar al menu principal
            }

        }
    }
}
