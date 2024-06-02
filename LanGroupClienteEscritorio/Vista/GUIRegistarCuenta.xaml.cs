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
    /// <summary>
    /// Lógica de interacción para GUIRegisterView.xaml
    /// </summary>
    public partial class GUIRegistrarCuenta : Page
    {
        public GUIRegistrarCuenta()
        {
            InitializeComponent();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Utils.AdministrarNavegacion.MostrarMenuPrincipal();
        }

        private void LblCambiarIcono_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void BtnCrearCuenta_Click(object sender, RoutedEventArgs e)
        {
            GUISeleccionarIdioma gUISeleccionarIdioma = new GUISeleccionarIdioma();
            NavigationService.Navigate(gUISeleccionarIdioma);
        }

        private void TxtbDescripcion_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtbDescripcion.Text.Length > 0)
            {
                lblMensajeDescripcion.Visibility = Visibility.Collapsed;
            }
            else
            {
                lblMensajeDescripcion.Visibility = Visibility.Visible;
            }
        }
    }
}
