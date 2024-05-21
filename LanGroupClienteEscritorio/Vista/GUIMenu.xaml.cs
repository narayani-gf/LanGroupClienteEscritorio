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
    /// Lógica de interacción para GUIMenu.xaml
    /// </summary>
    public partial class GUIMenu : Page
    {
        public GUIMenu()
        {
            InitializeComponent();
        }

        private void BtnPublicaciones_Click(object sender, RoutedEventArgs e)
        {
            GUIAnadirInteraccion gUIAnadirInteraccion= new GUIAnadirInteraccion();
            NavigationService.Navigate(gUIAnadirInteraccion);
        }

        private void BtnIdiomas_Click(object sender, RoutedEventArgs e)
        {
            GUISeleccionarIdioma gUISeleccionarIdiomas = new GUISeleccionarIdioma();
            NavigationService.Navigate(gUISeleccionarIdiomas);
        }

        private void BtnInstructor_Click(object sender, RoutedEventArgs e)
        {
            GUISolicitudInstructor gUIInstructor = new GUISolicitudInstructor();
            NavigationService.Navigate(gUIInstructor);
        }

        private void BtnGrupos_Click(object sender, RoutedEventArgs e)
        {
            GUIGruposAprendiz gUIGruposAprendiz = new GUIGruposAprendiz();
            NavigationService.Navigate(gUIGruposAprendiz);
        }

        private void BtnEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            GUIEstadisticas gUIEstadisticas = new GUIEstadisticas();
            NavigationService.Navigate(gUIEstadisticas);
        }

        private void BtnAdministrarInstructor_Click(object sender, RoutedEventArgs e)
        {
            GUIInstructores gUIInstructores = new GUIInstructores();
            NavigationService.Navigate(gUIInstructores);
        }
    }
}
