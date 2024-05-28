using LanGroupClienteEscritorio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.ViewModel
{
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 28/05/2024                                ==
     * == Descripción:                                                      ==
     * =======================================================================
     */
    internal class EstadisticasViewModel
    {
        //TODO cargar las publicaciones del usuario de la sesión
        public List<Estadisticas> estadisticas { get; set; }
        
        public EstadisticasViewModel() 
        {
            estadisticas = new List<Estadisticas>()
            {
                new Estadisticas{ totalPublicaciones=10, promedio="1 estrella" },
                new Estadisticas{ totalPublicaciones= 15, promedio="2 estrellas"},
                new Estadisticas{ totalPublicaciones= 5, promedio="3 estrellas"},
                new Estadisticas{ totalPublicaciones=20, promedio="4 estrellas"},
                new Estadisticas{ totalPublicaciones=1, promedio="5 estrellas"}
            };
        }
    }
}
