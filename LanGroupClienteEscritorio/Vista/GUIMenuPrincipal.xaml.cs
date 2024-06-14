using LanGroupClienteEscritorio.Modelo;
using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Servicio;
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
            CambiarVisibilidadBotones();
        }

        private List<Publicacion> ObtenerPublicaciones()
        {
            return new List<Publicacion>
            {
                new Publicacion
                {
                    Titulo = "Publicacion 1",
                    //Colaborador = "a",
                    Id = "asd",
                    //Grupo = "b",
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
            txtbMensajeSaludo.Text = "¡Hola " + SesionSingleton.Instance.Colaborador.Nombre.ToString() + " " + SesionSingleton.Instance.Colaborador.Apellido.ToString() + "!";
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
            gUIInstructor.IniciarVentanaColaborador(SesionSingleton.Instance.Colaborador);
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
            gUIEstadisticas.IniciarVentana(SesionSingleton.Instance.Colaborador);
            NavigationService.Navigate(gUIEstadisticas);
        }

        private void BtnAdministrarInstructor_Click(object sender, RoutedEventArgs e)
        {
            GUIAdministrarInstructores gUIAdministrarInstructores = new GUIAdministrarInstructores();
            gUIAdministrarInstructores.IniciarVentana(SesionSingleton.Instance.Colaborador);
            NavigationService.Navigate(gUIAdministrarInstructores);
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void CambiarVisibilidadBotones()
        {
            (List<Rol> roles, int codigo) = await RolServicio.ObtenerRoles();

            if(roles != null && codigo >= 200 && codigo < 300)
            {
                foreach(Rol rol in roles)
                {
                    if(rol.Id.Equals(SesionSingleton.Instance.Colaborador.IdRol, StringComparison.OrdinalIgnoreCase))
                    {
                        if (rol.Nombre.Equals("Aprendiz", StringComparison.OrdinalIgnoreCase))
                        {
                            buttonAdministrarInstructores.Visibility = Visibility.Hidden;
                            break;
                        }

                        if(rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase) || rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                        {
                            buttonQuieroSerInstructor.Visibility = Visibility.Hidden;
                        }
                    }
                }
            }
        }
    }
}   