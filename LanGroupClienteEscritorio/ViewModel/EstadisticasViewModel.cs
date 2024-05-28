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
        public List<Estadisticas> estadisticas { get; set; }
        
        public EstadisticasViewModel(int idUsuario) 
            
        {
            estadisticas = new List<Estadisticas>();
            obtenerTotalPublicacionesPorPromedio(idUsuario);
        }

        private void obtenerTotalPublicacionesPorPromedio(int idUsuario)
        {
            //TODO obtener de bd el total de publicaciones por promedio (5 listas, una por promedio)
        }
    }
}
