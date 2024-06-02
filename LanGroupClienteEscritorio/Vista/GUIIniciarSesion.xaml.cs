using LanGroupClienteEscritorio.Modelo;
using LanGroupClienteEscritorio.Servicio;
using LanGroupClienteEscritorio.Servicios;
using LanGroupClienteEscritorio.Utils;
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
            Response response = await AuthServicio.IniciarSesion(auth);
            switch(response.Codigo)
            {
                case (int)HttpStatusCode.OK:
                    GuardarToken(response.Jwt);
                    int codigo = await GuardarSingletonAsync();

                    if ((int)HttpStatusCode.OK == codigo)
                        MostrarMenuPrincipal();
                    else
                        MessageBox.Show("Ocurrió un problema con el servidor. Intenta más tarde.");

                    break;
                case (int)HttpStatusCode.Unauthorized:
                    MessageBox.Show("Verifica tus credenciales.");
                    break;
                default:
                    MessageBox.Show("Ocurrió un problema con el servidor. Intenta más tarde.");
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

        private async Task<int> GuardarSingletonAsync()
        {
            var (colaborador, codigo) = await ColaboradorServicio.RecuperarColaborador(txtUsername.Text);
            SesionSingleton.Instance.SetColaborador(colaborador);
            return codigo;
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
                Contrasenia = pwbContraseña.Password,
            };

            IniciarSesion(auth);
        }

        private void MostrarMenuPrincipal()
        {
            GUIMenuPrincipal gUIMenuPrincipal = new GUIMenuPrincipal();
            NavigationService.Navigate(gUIMenuPrincipal);
        }
    }
}
