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
     * == Fecha de actualización: 02/06/2024                                ==
     * == Descripción: Clase para mostrar las publicaciones en el bar chart ==
     * =======================================================================
     */
    internal class EstadisticasViewModel
    {
        //TODO cargar las publicaciones del usuario de la sesión
        public List<Estadisticas> Estadisticas { get; set; }

        public string Correo { get; set; }

        public List<Publicacion> Publicaciones { get; set; }
        
        public EstadisticasViewModel(string correo) 
        {
            Correo = correo;
            ObtenerPublicaciones();
        }

        private async void ObtenerPublicaciones()
        {
            Colaborador colaborador = await ColaboradorServicio.ObtenerColaboradorPorCorreo(Correo);

            if(colaborador != null)
            {
                Publicaciones = await PublicacionServicio.ObtenerPublicacionesPorColaborador(colaborador.Id);
                if (Publicaciones != null)
                {
                    if (Publicaciones.Count() > 0)
                    {
                        List<int> publicacionesPorMes = ContarPublicacionesPorMes(Publicaciones);
                        List<string> meses = EnlistarMeses();
                        Estadisticas estadistica;
                        Estadisticas = new List<Estadisticas>();

                        for (int i = 0; i < 12; i++)
                        {
                            estadistica = new Estadisticas(publicacionesPorMes[i], meses[i]);
                            Estadisticas.Add(estadistica);
                        }
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
