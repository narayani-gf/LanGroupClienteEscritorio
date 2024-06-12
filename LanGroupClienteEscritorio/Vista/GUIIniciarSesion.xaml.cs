using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Servicio;
using LanGroupClienteEscritorio.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
            SetCorreoPredeterminado();
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
            SesionSingleton.Instance.SetToken(jwt);
        }

        private async Task<int> GuardarSingletonAsync()
        {
            var (colaborador, codigo) = await ColaboradorServicio.ObtenerColaborador(txtCorreo.Text);
            SesionSingleton.Instance.SetColaborador(colaborador);
            return codigo;
        }

        private void LblRegistrarCuenta_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MostrarRegistrarCuenta();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MostrarRecuperarContrasenia();
        }

        private void BtnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarInformacion())
            {
                var auth = new Auth()
                {
                    Correo = txtCorreo.Text,
                    Contrasenia = pwbContraseña.Password,
                };

                IniciarSesion(auth);
            }
        }

        private bool VerificarCorreo()
        {
            Regex regex = new Regex( @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regex.IsMatch(txtCorreo.Text);
        }

        private bool VerificarContrasenia()
        {
            Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_])[A-Za-z\d\W_]{8,16}$");
            return regex.IsMatch(pwbContraseña.Password);
        }

        private bool VerificarInformacion()
        {
            bool isValid = true;

            if (!VerificarContrasenia())
            {
                isValid = false;
                lblContraseniaError.Visibility = Visibility.Visible;
            }
            if (!VerificarCorreo() || txtCorreo.Foreground == Brushes.Gray)
            {
                isValid = false;
                lblCorreoError.Visibility = Visibility.Visible;
            }

            return isValid;
        }

        private void TxtCorreo_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtCorreo.Foreground == Brushes.Gray)
            {
                txtCorreo.Text = "";
                txtCorreo.Foreground = Brushes.Black;
                lblCorreoError.Visibility = Visibility.Collapsed;
            }
        }

        private void TxtCorreo_LostFocus(object sender, RoutedEventArgs e)
        {
            SetCorreoPredeterminado();
        }

        private void SetCorreoPredeterminado()
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                txtCorreo.Text = "ejemplo@gmail.com";
                txtCorreo.Foreground = Brushes.Gray;
            }
        }

        private void PwbContraseña_GotFocus(object sender, RoutedEventArgs e)
        {
            lblContraseniaError.Visibility = Visibility.Collapsed;
        }

        private void MostrarMenuPrincipal()
        {
            GUIMenuPrincipal gUIMenuPrincipal = new GUIMenuPrincipal();
            NavigationService.Navigate(gUIMenuPrincipal);
        }

        private void MostrarRecuperarContrasenia()
        {
            GUIRecuperarContraseña gUIRecuperarContraseña = new GUIRecuperarContraseña();
            NavigationService.Navigate(gUIRecuperarContraseña);
        }

        private void MostrarRegistrarCuenta()
        {
            GUIRegistrarCuenta gUIRegistrarCuenta = new GUIRegistrarCuenta();
            NavigationService.Navigate(gUIRegistrarCuenta);
        }
    }
}
