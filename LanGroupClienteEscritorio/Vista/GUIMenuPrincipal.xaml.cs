using LanGroupClienteEscritorio.Modelo;
using LanGroupClienteEscritorio.Utils;
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
    /// Interaction logic for GUIMenuPrincipal.xaml
    /// </summary>
    public partial class GUIMenuPrincipal : Page
    {
        public GUIMenuPrincipal()
        {
            InitializeComponent();
            List<Publicacion> publicaciones = ObtenerPublicaciones();
            PublicacionesListBox.ItemsSource = publicaciones;
            SetColaborador();
        }

        private List<Publicacion> ObtenerPublicaciones()
        {
            return new List<Publicacion>
            {
                new Publicacion
                {
                    Titulo = "Publicacion 1",
                    Colaborador = "a",
                    Id = "asd",
                    Grupo = "b",
                    Descripcion = "c",
                    Fecha = DateTime.Now,
                    Valoracion = 4,
                    Interacciones = new List<Interaccion>
                    {
                        new Interaccion
                        {
                            Colaborador = "autor",
                            Fecha = DateTime.Now,
                            Valoracion = 5,
                            Comentario = "Comentario sadf",
                        }
                    }
                },
            };
        }

        private void SetColaborador()
        {
            txtbMensajeSaludo.Text = SesionSingleton.Instance.Colaborador.Nombre.ToString() + " " + SesionSingleton.Instance.Colaborador.Apellido.ToString();
        }

        private void BtnPublicaciones_Click(object sender, RoutedEventArgs e)
        {
            AdministrarNavegacion.MostrarMenuPrincipal();
        }

        private void BtnIdiomas_Click(object sender, RoutedEventArgs e)
        {
            GUISeleccionarIdioma gUISeleccionarIdiomas = new GUISeleccionarIdioma();
            NavigationService.Navigate(gUISeleccionarIdiomas);
        }

        private void BtnInstructor_Click(object sender, RoutedEventArgs e)
        {
            GUISolicitudInstructor gUIInstructor = new GUISolicitudInstructor();
            NavigationService.Navigate(gUIInstructor);
        }

        private void BtnGrupos_Click(object sender, RoutedEventArgs e)
        {
            GUIGruposAprendiz gUIGruposAprendiz = new GUIGruposAprendiz();
            NavigationService.Navigate(gUIGruposAprendiz);
        }

        private void BtnEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            GUIEstadisticas gUIEstadisticas = new GUIEstadisticas();
            NavigationService.Navigate(gUIEstadisticas);
        }

        private void BtnAdministrarInstructor_Click(object sender, RoutedEventArgs e)
        {
            GUIInstructores gUIInstructores = new GUIInstructores();
            NavigationService.Navigate(gUIInstructores);
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            GUIInstructores gUIInstructores = new GUIInstructores();
            NavigationService.Navigate(gUIInstructores);
        }
    }
}   