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
            CargarDataGrid(false);
        }

        public void IniciarVentanaEliminarInstructor(string rolUsuario)
        {
            this.rolUsuario = rolUsuario;
            ModificarVisibilidadObjetos();
            CargarDataGrid(true);
        }

        private void AceptarSolicitud(object sender, RoutedEventArgs e)
        {

        }

        private void RechazarSolicitud(object sender, RoutedEventArgs e)
        {

        }

        private void VerSolicitud(object sender, RoutedEventArgs e)
        {
            GUISolicitudInstructor guiSolicitudInstructor = new GUISolicitudInstructor();
            guiSolicitudInstructor.IniciarVentana(rolUsuario, 0);//dataGridUsuarios.SelectedItem.idUsuario);
            NavigationService.Navigate(guiSolicitudInstructor);
        }

        private void EliminarInstructor(object sender, RoutedEventArgs e)
        {

        }

        private void Regresar(object sender, MouseButtonEventArgs e)
        {

        }

        private void ModificarVisibilidadObjetos()
        {
            labelEliminarInstructor.Visibility = Visibility.Visible;
            buttonAceptar.Visibility = Visibility.Hidden;
            buttonRechazar.Visibility = Visibility.Hidden;
            buttonVerSolicitud.Visibility = Visibility.Hidden;
            buttonEliminar.Visibility = Visibility.Visible;
        }

        private void CargarDataGrid(bool esEliminacion)
        {
            if (esEliminacion)
            {

            }
            else
            {

            }
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Utils.AdministrarNavegacion.RegresarPaginaPrincipal();
        }
    }
}
