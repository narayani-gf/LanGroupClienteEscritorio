using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Servicio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LanGroupClienteEscritorio.Vista
{
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 12/06/2024                                ==
     * == Descripción: Logica de interacción para GUIInstructores.xaml      ==
     * =======================================================================
     */
    public partial class GUIInstructores : Page
    {
        private Colaborador Usuario;

        public GUIInstructores()
        {
            InitializeComponent();
        }

        public void IniciarVentanaAgregarInstructor(Colaborador usuario)
        {
            Usuario = usuario;
            CargarDataGridAgregacionAsync();
        }

        public void IniciarVentanaEliminarInstructor(Colaborador usuario)
        {
            Usuario = usuario;
            ModificarVisibilidadObjetos();
            CargarDataGridEliminacionAsync();
        }

        private async void AceptarSolicitud(object sender, RoutedEventArgs e)
        {
            if(dataGridAgregarInstructor.SelectedItem != null)
            { 
                Colaborador colaboradorSeleccionado = dataGridAgregarInstructor.SelectedItem as Colaborador;
                if(MessageBoxResult.Yes == MessageBox.Show("“¿Seguro que deseas agregar como instructor a " + colaboradorSeleccionado.Usuario + "?", "Aceptar solicitud", MessageBoxButton.YesNo, MessageBoxImage.Question))
                {
                    int codigo = await ColaboradorServicio.AsignarRolAColaborador(colaboradorSeleccionado, "Instructor");               

                    if(codigo == 200)
                    {
                        (Solicitud solicitud, int codigoSolicitudes) = await SolicitudServicio.ObtenerSolicitudPorIdUsuario(colaboradorSeleccionado.Id);

                        if(solicitud != null)
                        {
                            codigo = await SolicitudServicio.CambiarEstadoSolicitud(solicitud, "Aceptado");

                            if (codigo == 200)
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
                    (Solicitud solicitud, int codigoSolicitud) = await SolicitudServicio.ObtenerSolicitudPorIdUsuario(colaboradorSeleccionado.Id);

                    if(solicitud != null)
                    {
                        int codigo = await SolicitudServicio.CambiarEstadoSolicitud(solicitud, "Rechazado");

                        if (codigo == 200)
                        {
                            MessageBox.Show("Se rechazó a " + colaboradorSeleccionado.Usuario + " como instructor.", "Solicitud Rechazada", MessageBoxButton.OK);
                        }
                        else
                        {
                            MostrarMensajeError();
                        }
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
                (Solicitud solicitud, int codigoSolicitud) = await SolicitudServicio.ObtenerSolicitudPorIdUsuario(colaboradorSeleccionado.Id);

                if(solicitud != null)
                {
                    GUISolicitudInstructor guiSolicitudInstructor = new GUISolicitudInstructor();
                    guiSolicitudInstructor.IniciarVentanaAdministrador(Usuario, solicitud, colaboradorSeleccionado.Usuario);
                    NavigationService.Navigate(guiSolicitudInstructor);
                }
                else
                {
                    MostrarMensajeError();
                }
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
                    int codigo = await ColaboradorServicio.AsignarRolAColaborador(colaboradorSeleccionado, "Aprendiz");
                    if (codigo == 200)
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

        private async void CargarDataGridAgregacionAsync()
        {
            (List<Solicitud> solicitudes, int codigoSolicitudes) = await SolicitudServicio.ObtenerSolicitudes();

            if(solicitudes != null && solicitudes.Count > 0)
            {
                List<Solicitud> solicitudesPendientes = new List<Solicitud>();
                foreach(Solicitud solicitud in solicitudes)
                {
                    if(solicitud.Estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                    {
                        solicitudesPendientes.Add(solicitud);
                    }
                }

                if (solicitudesPendientes.Count > 0)
                {
                    (List<Colaborador> colaboradores, int codigo) = await ColaboradorServicio.ObtenerColaboradores();

                    if(colaboradores != null)
                    {
                        ObservableCollection<Colaborador> colaboradoresConSolicitudPendiente = new ObservableCollection<Colaborador>();

                        for(int i = 0; i < solicitudesPendientes.Count; i++)
                        {
                            foreach(Colaborador colaborador in colaboradores)
                            {
                                if (solicitudesPendientes[i].IdColaborador.Equals(colaborador.Id))
                                {
                                    colaboradoresConSolicitudPendiente.Add(colaborador);
                                }
                            }
                        }

                        dataGridAgregarInstructor.ItemsSource = colaboradoresConSolicitudPendiente;
                    }
                }
                else
                {
                    imagenDataGrid.Visibility = Visibility.Hidden;
                    dataGridAgregarInstructor.Visibility = Visibility.Hidden;
                    labelMensaje.Content = "No hay solicitudes pendientes.";
                    labelMensaje.Visibility = Visibility.Visible;
                }
            }
            else
            {
                imagenDataGrid.Visibility = Visibility.Hidden;
                dataGridAgregarInstructor.Visibility = Visibility.Hidden;
                labelMensaje.Content = "No hay solicitudes pendientes.";
                labelMensaje.Visibility = Visibility.Visible;
            }
        }

        private async void CargarDataGridEliminacionAsync()
        {
            (List<Colaborador> instructoresApi, int codigo) = await ColaboradorServicio.ObtenerInstructores();

            if(instructoresApi != null && instructoresApi.Count > 0)
            {
                ObservableCollection<Colaborador> instructores = new ObservableCollection<Colaborador>();
                foreach(Colaborador instructor in instructoresApi)
                {
                    instructores.Add(instructor);
                }

                if (instructores.Count > 0)
                {
                    dataGridEliminarInstructor.ItemsSource = instructores;
                }                
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
            GUIAdministrarInstructores gUIAdministrarInstructores = new GUIAdministrarInstructores();
            gUIAdministrarInstructores.IniciarVentana(Usuario);
            NavigationService.Navigate(gUIAdministrarInstructores);
        }
    }
}
