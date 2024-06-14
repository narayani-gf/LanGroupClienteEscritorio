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
    /// Lógica de interacción para GUIEnviarCorreo.xaml
    /// </summary>
    public partial class GUIEnviarCorreo : Page
    {
        private string codigoGenerado;
        public GUIEnviarCorreo()
        {
            InitializeComponent();
        }

        private async void BtnEnviarCorreo_Click(object sender, RoutedEventArgs e)
        {
            string correo = txtCorreo.Text;
            codigoGenerado = GenerarCodigo();

            string subject = "Código de verificación";
            string text = $"Tu código de verificación es: {codigoGenerado}";

            bool exito = await CorreoServicio.EnviarCorreo(correo, subject, text);

            if (exito)
            {
                MessageBox.Show("Correo enviado. Revisa tu bandeja de entrada.");
            }
            else
            {
                MessageBox.Show("Error al enviar el correo." + exito);
            }
        }

        private string GenerarCodigo()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private void BtnComprobarCodigo_Click(object sender, RoutedEventArgs e)
        {
            string codigoIngresado = txtCodigo.Text;

            if (codigoIngresado == codigoGenerado)
            {
                MessageBox.Show("Código correcto.");
                GUIRecuperarContraseña gUIRecuperarContraseña = new GUIRecuperarContraseña();
                NavigationService.Navigate(gUIRecuperarContraseña);
            }
            else
            {
                MessageBox.Show("Código incorrecto. Intenta de nuevo.");
            }
        }
    }
}
