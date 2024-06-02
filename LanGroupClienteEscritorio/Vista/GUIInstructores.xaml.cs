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
     * == Fecha de actualización: 23/05/2024                                ==
     * == Descripción: Logica de interacción para GUIInstructores.xaml      ==
     * =======================================================================
     */
    public partial class GUIInstructores : Page
    {
        private string rolUsuario;

        public GUIInstructores()
        {
            InitializeComponent();
        }

        public void IniciarVentanaAgregarInstructor(string rolUsuario)
        {
            this.rolUsuario = rolUsuario;
            CargarDataGridAgregacion();
        }

        public void IniciarVentanaEliminarInstructor(string rolUsuario)
        {
            this.rolUsuario = rolUsuario;
            ModificarVisibilidadObjetos();
            CargarDataGridEliminacion();
        }

        private void AceptarSolicitud(object sender, RoutedEventArgs e)
        {
            if(dataGridCreditPolicies.SelectedItem != null)
            { 
                if(MessageBoxResult.Yes == MessageBox.Show("“¿Seguro que deseas agregar como instructor a " /* + dataGridUsuarios.SelectedItem.Usuario */ + "?", "Aceptar solicitud", MessageBoxButton.YesNo, MessageBoxImage.Question))
                {

                }
            }
            else
            {
                MostrarMensajeInstructorNoSeleccionado();
            }
        }

        private void RechazarSolicitud(object sender, RoutedEventArgs e)
        {
            if (dataGridCreditPolicies.SelectedItem != null)
            {
                if(MessageBoxResult.Yes == MessageBox.Show("“¿Seguro que deseas rechazar como instructor a " /* + dataGridUsuarios.SelectedItem.Usuario */ + "?", "Rechazar solicitud", MessageBoxButton.YesNo, MessageBoxImage.Question))
                {

                }
            }
            else
            {
                MostrarMensajeInstructorNoSeleccionado();
            }
        }

        private void VerSolicitud(object sender, RoutedEventArgs e)
        {
            if(dataGridCreditPolicies.SelectedItem != null)
            {
                GUISolicitudInstructor guiSolicitudInstructor = new GUISolicitudInstructor();
                guiSolicitudInstructor.IniciarVentanaAdministrador(rolUsuario, 0);//dataGridUsuarios.SelectedItem.idUsuario);
                NavigationService.Navigate(guiSolicitudInstructor);
            }
            else
            {
                MostrarMensajeInstructorNoSeleccionado();
            }            
        }

        private void EliminarInstructor(object sender, RoutedEventArgs e)
        {
            if(dataGridCreditPolicies.SelectedItem != null)
            {
                if(MessageBoxResult.Yes == MessageBox.Show("“¿Seguro que deseas eliminar como instructor a " /* + dataGridUsuarios.SelectedItem.Usuario */ + "?", "Eliminar instructor", MessageBoxButton.YesNo, MessageBoxImage.Question))
                {

                }
            }
            else
            {
                MostrarMensajeInstructorNoSeleccionado();
            }
        }

        private void ModificarVisibilidadObjetos()
        {
            labelEliminarInstructor.Visibility = Visibility.Visible;
            labelAgregarInstructor.Visibility = Visibility.Hidden;
            buttonAceptar.Visibility = Visibility.Hidden;
            buttonRechazar.Visibility = Visibility.Hidden;
            buttonVerSolicitud.Visibility = Visibility.Hidden;
            buttonEliminar.Visibility = Visibility.Visible;
            imagenDataGrid.Visibility = Visibility.Hidden;
            dataGridCreditPolicies.Visibility = Visibility.Hidden;
            dataGridEliminarInstructor.Visibility= Visibility.Visible;
        }

        private void CargarDataGridAgregacion()
        {
            //TODO cargar los usuarios con solicitudes pendientes, si no hay pendientes mostrar el mensaje
            if (true)
            {

            }
            else
            {
                imagenDataGrid.Visibility = Visibility.Hidden;
                dataGridCreditPolicies.Visibility = Visibility.Hidden;
                labelMensaje.Content = "No hay solicitudes pendientes.";
                labelMensaje.Visibility = Visibility.Visible;
            }
        }

        private void CargarDataGridEliminacion()
        {
            //TODO cargar los usuarios que cuenten con rol de instructor, si no hay instructores activos, mostrar mensaje
            if(true)
            {

            }
            else
            {
                labelMensaje.Content = "No hay instructores activos.";
                labelMensaje.Visibility = Visibility.Visible;
            }
        }

        private void MostrarMensajeInstructorNoSeleccionado()
        {
            MessageBox.Show("Debes seleccionar a un instructor.", "Instructor no seleccionado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
            Utils.AdministrarNavegacion.MostrarMenuPrincipal();
        }
    }
}
