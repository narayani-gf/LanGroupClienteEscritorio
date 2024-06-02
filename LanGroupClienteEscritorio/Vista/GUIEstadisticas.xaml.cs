using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace LanGroupClienteEscritorio.Vista
{
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 02/06/2024                                ==
     * == Descripción: Logica de interacción para GUIEstadisticas.xaml      ==
     * =======================================================================
     */
    public partial class GUIEstadisticas : Page
    {
        private Response Usuario;
        public GUIEstadisticas()
        {
            InitializeComponent();
        }

        public void IniciarVentana(Response usuario)
        {
            Usuario = usuario;
            cargarBarChart();
        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
            Utils.AdministrarNavegacion.MostrarMenuPrincipal();
        }

        private void cargarBarChart()
        {
            EstadisticasViewModel estadisticasViewModel = new EstadisticasViewModel(Usuario.Correo);

            if(estadisticasViewModel.Estadisticas != null)
            {
                columnSeriesPublicaciones.ItemsSource = estadisticasViewModel.Estadisticas;
            }
            else
            {
                barChartPublicaciones.Visibility = Visibility.Hidden;
                labelSinPublicaciones.Visibility= Visibility.Visible;
            }
        }
    }
}
