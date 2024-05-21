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
    /// Lógica de interacción para GUIIniciarSesion.xaml
    /// </summary>
    public partial class GUIIniciarSesion : Page
    {
        public GUIIniciarSesion()
        {
            InitializeComponent();
        }

        private void LblRegistrarCuenta_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GUIRegistrarCuenta gUIRegistrarCuenta = new GUIRegistrarCuenta();
            NavigationService.Navigate(gUIRegistrarCuenta);
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GUIRecuperarContraseña gUIRecuperarContraseña = new GUIRecuperarContraseña();
            NavigationService.Navigate(gUIRecuperarContraseña);
        }

        private void BtnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
           GUIAnadirInteraccion gUIAnadirInteraccion = new GUIAnadirInteraccion();
           NavigationService.Navigate(gUIAnadirInteraccion);
        }
    }
}
