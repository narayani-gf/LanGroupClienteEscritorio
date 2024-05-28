using LanGroupClienteEscritorio.Modelos;
using LanGroupClienteEscritorio.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
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

        private async void IniciarSesion(Auth auth)
        {
            Response authResponse = await AuthServicio.IniciarSesion(auth);
            switch(authResponse.Codigo)
            {
                case (int)HttpStatusCode.OK:
                    GuardarToken(authResponse.Jwt);
                    GUIAnadirInteraccion gUIAnadirInteraccion = new GUIAnadirInteraccion();
                    NavigationService.Navigate(gUIAnadirInteraccion);
                    break;
                case (int)HttpStatusCode.Unauthorized:
                    Console.Write("401");
                    break;
                default:
                    Console.WriteLine("500");
                    break;
            }
        }

        private void GuardarToken(string jwt)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            KeyValueConfigurationElement token = configuration.AppSettings.Settings["TOKEN"];
            token.Value = jwt;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
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
            var auth = new Auth()
            {
                Correo = txtUsername.Text,
                Contrasenia = txtContraseña.Text
            };

            IniciarSesion(auth);

           
        }
    }
}
