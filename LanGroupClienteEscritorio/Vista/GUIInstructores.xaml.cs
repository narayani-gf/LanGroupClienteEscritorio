using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Modelos;
using LanGroupClienteEscritorio.Servicio;
using LanGroupClienteEscritorio.ViewModel;
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
     * == Fecha de actualización: 02/06/2024                                ==
     * == Descripción: Logica de interacción para GUIInstructores.xaml      ==
     * =======================================================================
     */
    public partial class GUIInstructores : Page
    {
        private string IdUsuario;
        private string RolUsuario;

        public GUIInstructores()
        {
            InitializeComponent();
        }

        public void IniciarVentanaAgregarInstructor(string idUsuario, string rolUsuario)
        {
            IdUsuario = idUsuario;
            RolUsuario = rolUsuario;
            CargarDataGridAgregacion();
        }

        public void IniciarVentanaEliminarInstructor(string idUsuario, string rolUsaurio)
        {
            IdUsuario = idUsuario;
            RolUsuario= rolUsaurio;
            ModificarVisibilidadObjetos();
            CargarDataGridEliminacion();
        }

        private async void AceptarSolicitud(object sender, RoutedEventArgs e)
        {
            if(dataGridAgregarInstructor.SelectedItem != null)
            { 
                Colaborador colaboradorSeleccionado = dataGridAgregarInstructor.SelectedItem as Colaborador;
                if(MessageBoxResult.Yes == MessageBox.Show("“¿Seguro que deseas agregar como instructor a " + colaboradorSeleccionado.Usuario + "?", "Aceptar solicitud", MessageBoxButton.YesNo, MessageBoxImage.Question))
                {
                    Response responseColaborador = new Response();
                    responseColaborador = await ColaboradorServicio.AsignarRolAColaborador(colaboradorSeleccionado, "Instructor");               

                    if(responseColaborador.Codigo == 200)
                    {
                        Response responseSolicitud = new Response();
                        Solicitud solicitud = await SolicitudServicio.ObtenerSolicitudPorIdUsuario(colaboradorSeleccionado.Id);
                        responseSolicitud = await SolicitudServicio.CambiarEstadoSolicitud(solicitud, "Aceptado");

                        if(responseSolicitud.Codigo == 200)
                        {
                            MessageBox.Show("Se agregó a " + colaboradorSeleccionado.Usuario + " como instructor.", "Solicitud Aceptada", MessageBoxButton.OK);
                        }
                        else
                        {
                            MostrarMensajeError();
                        }
                    }
                    else
                    {
                        MostrarMensajeError();
                    }
                }
            }
            else
            {
                MostrarMensajeInstructorNoSeleccionado();
            }
        }

        private async void RechazarSolicitud(object sender, RoutedEventArgs e)
        {
            if (dataGridAgregarInstructor.SelectedItem != null)
            {
                Colaborador colaboradorSeleccionado = dataGridAgregarInstructor.SelectedItem as Colaborador;
                if (MessageBoxResult.Yes == MessageBox.Show("“¿Seguro que deseas rechazar como instructor a " + colaboradorSeleccionado.Usuario + "?", "Rechazar solicitud", MessageBoxButton.YesNo, MessageBoxImage.Question))
                {
                    Response responseSolicitud = new Response();
                    Solicitud solicitud = await SolicitudServicio.ObtenerSolicitudPorIdUsuario(colaboradorSeleccionado.Id);
                    responseSolicitud = await SolicitudServicio.CambiarEstadoSolicitud(solicitud, "Rechazado");

                    if(responseSolicitud.Codigo == 200)
                    {
                        MessageBox.Show("Se rechazó a " + colaboradorSeleccionado.Usuario + " como instructor.", "Solicitud Rechazada", MessageBoxButton.OK);
                    }
                    else
                    {
                        MostrarMensajeError();
                    }
                }
            }
            else
            {
                MostrarMensajeInstructorNoSeleccionado();
            }
        }

        private async void VerSolicitud(object sender, RoutedEventArgs e)
        {
            if(dataGridAgregarInstructor.SelectedItem != null)
            {
                Colaborador colaboradorSeleccionado = dataGridAgregarInstructor.SelectedItem as Colaborador;
                Solicitud solicitud = await SolicitudServicio.ObtenerSolicitudPorIdUsuario(colaboradorSeleccionado.Id);

                GUISolicitudInstructor guiSolicitudInstructor = new GUISolicitudInstructor();
                guiSolicitudInstructor.IniciarVentanaAdministrador(IdUsuario, RolUsuario, solicitud, colaboradorSeleccionado.Usuario);
                NavigationService.Navigate(guiSolicitudInstructor);
            }
            else
            {
                MostrarMensajeInstructorNoSeleccionado();
            }            
        }

        private async void EliminarInstructor(object sender, RoutedEventArgs e)
        {
            if(dataGridEliminarInstructor.SelectedItem != null)
            {
                Colaborador colaboradorSeleccionado = dataGridEliminarInstructor.SelectedItem as Colaborador;
                if(MessageBoxResult.Yes == MessageBox.Show("“¿Seguro que deseas eliminar como instructor a " + colaboradorSeleccionado.Usuario + "?", "Eliminar instructor", MessageBoxButton.YesNo, MessageBoxImage.Question))
                {
                    Response responseColaborador = new Response();
                    responseColaborador = await ColaboradorServicio.AsignarRolAColaborador(colaboradorSeleccionado, "Aprendiz");
                    if (responseColaborador.Codigo == 200)
                    {
                        MessageBox.Show("Se eliminó como instructor a " + colaboradorSeleccionado.Usuario, "Instructor eliminado", MessageBoxButton.OK);
                    }
                    else
                    {
                        MostrarMensajeError();
                    }
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
            dataGridAgregarInstructor.Visibility = Visibility.Hidden;
            dataGridEliminarInstructor.Visibility= Visibility.Visible;
        }

        private void CargarDataGridAgregacion()
        {
            SolicitudesPendientesViewModel solicitudesPendientes = new SolicitudesPendientesViewModel();

            if (solicitudesPendientes.ColaboradoresConSolicitudPendiente != null)
            {
                dataGridAgregarInstructor.ItemsSource = solicitudesPendientes.ColaboradoresConSolicitudPendiente;
            }
            else
            {
                imagenDataGrid.Visibility = Visibility.Hidden;
                dataGridAgregarInstructor.Visibility = Visibility.Hidden;
                labelMensaje.Content = "No hay solicitudes pendientes.";
                labelMensaje.Visibility = Visibility.Visible;
            }
        }

        private void CargarDataGridEliminacion()
        {
            InstructoresViewModel instructores = new InstructoresViewModel();

            if (instructores.Instructores != null)
            {
                dataGridEliminarInstructor.ItemsSource = instructores.Instructores;
            }
            else
            {
                imagenDataGrid.Visibility = Visibility.Hidden;
                dataGridEliminarInstructor.Visibility = Visibility.Hidden; 
                labelMensaje.Content = "No hay instructores activos.";
                labelMensaje.Visibility = Visibility.Visible;
            }
        }

        private void MostrarMensajeInstructorNoSeleccionado()
        {
            MessageBox.Show("Debes seleccionar a un instructor.", "Instructor no seleccionado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void MostrarMensajeError()
        {
            MessageBox.Show("Algo salió mal.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
            Utils.AdministrarNavegacion.MostrarMenuPrincipal();
        }
    }
}
