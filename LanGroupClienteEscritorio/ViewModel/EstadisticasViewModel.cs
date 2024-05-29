using LanGroupClienteEscritorio.Modelo;
using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.ViewModel
{
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 29/05/2024                                ==
     * == Descripción: Clase para mostrar las publicaciones en el bar chart ==
     * =======================================================================
     */
    internal class EstadisticasViewModel
    {
        //TODO cargar las publicaciones del usuario de la sesión
        public List<Estadisticas> estadisticas { get; set; }

        public string usuario { get; set; }

        public List<Publicacion> publicaciones { get; set; }
        
        public EstadisticasViewModel() 
        {
            //ObtenerPublicaciones();
            estadisticas = new List<Estadisticas>()
            {
                new Estadisticas{ totalPublicaciones=10, mes="Enero" },
                new Estadisticas{ totalPublicaciones= 15, mes="Febrero"},
                new Estadisticas{ totalPublicaciones= 5, mes="Marzo"},
                new Estadisticas{ totalPublicaciones=20, mes="Abril"},
                new Estadisticas{ totalPublicaciones=1, mes="Mayo"}
            };
        }

        private async void ObtenerPublicaciones()
        {
            publicaciones = await PublicacionServicio.ObtenerPublicacionesPorColaborador(usuario);
            if (publicaciones != null)
            {
                List<int> publicacionesPorMes = ContarPublicacionesPorMes(publicaciones);
                estadisticas = new List<Estadisticas>()
                {
                    new Estadisticas{totalPublicaciones=publicacionesPorMes[0], mes="Enero"},
                    new Estadisticas{totalPublicaciones=publicacionesPorMes[1], mes="Febrero"},
                    new Estadisticas{totalPublicaciones=publicacionesPorMes[2], mes="Marzo"},
                    new Estadisticas{totalPublicaciones=publicacionesPorMes[3], mes="Abril"},
                    new Estadisticas{totalPublicaciones=publicacionesPorMes[4], mes="Mayo"},
                    new Estadisticas{totalPublicaciones=publicacionesPorMes[5], mes="Junio"},
                    new Estadisticas{totalPublicaciones=publicacionesPorMes[6], mes="Julio"},
                    new Estadisticas{totalPublicaciones=publicacionesPorMes[7], mes="Agosto"},
                    new Estadisticas{totalPublicaciones=publicacionesPorMes[8], mes="Septiembre"},
                    new Estadisticas{totalPublicaciones=publicacionesPorMes[9], mes="Octubre"},
                    new Estadisticas{totalPublicaciones=publicacionesPorMes[10], mes="Noviembre"},
                    new Estadisticas{totalPublicaciones=publicacionesPorMes[11], mes="Diciembre"}
                };
            }
        }

        private List<int> ContarPublicacionesPorMes(List<Publicacion> publicaciones)
        {
            List<DateTime> fechas = new List<DateTime>();

            foreach (Publicacion publicacion in publicaciones)
            {
                fechas.Add(publicacion.fecha);
            }

            List<int> publicacionesPorMes = new List<int>();

            for(int i = 0; i < 12; i++)
            {
                publicacionesPorMes.Add(fechas.Count(fecha => fecha.Month == i + 1));
            }

            return publicacionesPorMes;
        }
    }
}
