using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Servicio;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LanGroupClienteEscritorio.Vista
{
    public partial class GUIRecuperarContraseña : Page
    {
        public GUIRecuperarContraseña()
        {
            InitializeComponent();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Utils.AdministrarNavegacion.MostrarMenuPrincipal();
        }

        private async void btnRecuperarContrasenia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nuevaContraseña = txtTitulo.Text;


                if (string.IsNullOrWhiteSpace(nuevaContraseña) || nuevaContraseña != txtConfirmarContraseña.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden o están vacías.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string email = "dms19-@hotmail.com";

                Response response = await ColaboradorServicio.ActualizarContrasena(email, nuevaContraseña);

                if (response.Codigo == 200)
                {
                    MessageBox.Show("Contraseña actualizada con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al actualizar la contraseña.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
