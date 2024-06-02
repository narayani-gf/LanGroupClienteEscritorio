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
            ObtenerPublicaciones();
        }

        private async void ObtenerPublicaciones()
        {
            publicaciones = await PublicacionServicio.ObtenerPublicacionesPorColaborador(usuario);
            if (publicaciones != null)
            {
                if(publicaciones.Count() > 0)
                {
                    List<int> publicacionesPorMes = ContarPublicacionesPorMes(publicaciones);
                    List<string> meses = EnlistarMeses();
                    Estadisticas estadistica;
                    estadisticas = new List<Estadisticas>();

                    for(int i = 0; i < 12; i++)
                    {
                        estadistica = new Estadisticas(publicacionesPorMes[i], meses[i]);
                        estadisticas.Add(estadistica);
                    }
                }
                
            }
        }

        private List<int> ContarPublicacionesPorMes(List<Publicacion> publicaciones)
        {
            List<DateTime> fechas = new List<DateTime>();

            foreach (Publicacion publicacion in publicaciones)
            {
                fechas.Add(publicacion.Fecha);
            }

            List<int> publicacionesPorMes = new List<int>();

            for(int i = 0; i < 12; i++)
            {
                publicacionesPorMes.Add(0);
            }

            foreach(DateTime fecha in fechas)
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
