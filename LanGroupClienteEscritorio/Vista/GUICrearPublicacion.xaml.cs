using LanGroupClienteEscritorio.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
	public partial class GUICrearPublicacion : Page
	{
        string idPublicacion;
        public GUICrearPublicacion()
		{
			InitializeComponent();
		}

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Utils.AdministrarNavegacion.MostrarMenuPrincipal();
        }

        private async void BtnEliminarPublicacion_Click(object sender, RoutedEventArgs e)
        {
            

            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta publicación?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var response = await PublicacionServicio.EliminarPublicacion(idPublicacion);

                    if (response.Codigo == (int)HttpStatusCode.OK)
                    {
                        MessageBox.Show("Publicación eliminada exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar la publicación: {response.Codigo}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la publicación: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
