using LanGroupClienteEscritorio.Modelo;
using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Servicio;
using System.Collections.Generic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace LanGroupClienteEscritorio.Vista
{
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 13/06/2024                                ==
     * == Descripción: Logica de interacción para GUIEstadisticas.xaml      ==
     * =======================================================================
     */
    public partial class GUIEstadisticas : Page
    {
        private Colaborador Usuario;
        public GUIEstadisticas()
        {
            InitializeComponent();
        }

        public void IniciarVentana(Colaborador usuario)
        {
            Usuario = usuario;
            cargarBarChart();
        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
            GUIMenuPrincipal gUIMenuPrincipal = new GUIMenuPrincipal();
            NavigationService.Navigate(gUIMenuPrincipal);
        }

        private async void cargarBarChart()
        {
            List<Estadisticas> estadisticas = await ObtenerPublicaciones();

            if(estadisticas != null && estadisticas.Count > 0)
            {
                ObservableCollection<Estadisticas> ocEstadisticas = new ObservableCollection<Estadisticas>();
                foreach(Estadisticas estadistica in estadisticas)
                {
                    ocEstadisticas.Add(estadistica);
                }
                columnSeriesPublicaciones.ItemsSource = ocEstadisticas;                
            }
            else
            {
                barChartPublicaciones.Visibility = Visibility.Hidden;
                labelSinPublicaciones.Visibility= Visibility.Visible;
            }
        }

        private async Task<List<Estadisticas>> ObtenerPublicaciones()
        {
            List<Estadisticas> estadisticas = new List<Estadisticas>();
            (List<Publicacion> publicaciones, int codigo) = await PublicacionServicio.ObtenerPublicacionesPorColaborador(Usuario.Id);
            if (publicaciones != null && publicaciones.Count > 0)
            {
                List<int> publicacionesPorMes = ContarPublicacionesPorMes(publicaciones);
                List<string> meses = EnlistarMeses();
                Estadisticas estadistica;
                    

                for (int i = 0; i < 12; i++)
                {
                    estadistica = new Estadisticas(publicacionesPorMes[i], meses[i]);
                    estadisticas.Add(estadistica);
                }
            }

            return estadisticas;
        }

        private List<int> ContarPublicacionesPorMes(List<Publicacion> publicaciones)
        {
            List<DateTime> fechas = new List<DateTime>();

            foreach (Publicacion publicacion in publicaciones)
            {
                fechas.Add(publicacion.Fecha);
            }

            List<int> publicacionesPorMes = new List<int>();

            for (int i = 0; i < 12; i++)
            {
                publicacionesPorMes.Add(0);
            }

            foreach (DateTime fecha in fechas)
            {
                publicacionesPorMes[fecha.Month - 1] = publicacionesPorMes[fecha.Month - 1] + 1;
            }

            return publicacionesPorMes;
        }

        private List<string> EnlistarMeses()
        {
            List<string> meses = new List<string>
            {
                "Enero",
                "Febrero",
                "Marzo",
                "Abril",
                "Mayo",
                "Junio",
                "Julio",
                "Agosto",
                "Septiembre",
                "Octubre",
                "Noviembre",
                "Diciembre"
            };

            return meses;
        }
    }
}