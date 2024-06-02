using LanGroupClienteEscritorio.ViewModel;
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
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 01/06/2024                                ==
     * == Descripción: Logica de interacción para GUIEstadisticas.xaml      ==
     * =======================================================================
     */
    public partial class GUIEstadisticas : Page
    {
        private string rolUsuario;
        public GUIEstadisticas()
        {
            InitializeComponent();
        }

        public void IniciarVentana(string rolUsuario)
        {
            this.rolUsuario = rolUsuario;
            cargarBarChart();
        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
            Utils.AdministrarNavegacion.RegresarPaginaPrincipal();
        }

        private void cargarBarChart()
        {
            EstadisticasViewModel estadisticasViewModel = new EstadisticasViewModel();

            if(estadisticasViewModel.estadisticas != null)
            {
                columnSeriesPublicaciones.ItemsSource = estadisticasViewModel.estadisticas;
            }
            else
            {
                barChartPublicaciones.Visibility = Visibility.Hidden;
                labelSinPublicaciones.Visibility= Visibility.Visible;
            }
        }
    }
}
