using LanGroupClienteEscritorio.Modelo;
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
    }
}