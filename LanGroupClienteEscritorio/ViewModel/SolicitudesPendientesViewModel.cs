using LanGroupClienteEscritorio.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.ViewModel
{
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 28/05/2024                                ==
     * == Descripción: Clase para mostrar las solicitudes pendientes en el  ==
     * ==              datagrid.                                            ==
     * =======================================================================
     */
    internal class SolicitudesPendientesViewModel
    {
        //TODO cargar las solicitudes con estado pendiente
        public ObservableCollection<Solicitud> solicitudesPendientes { get; set; }

        public SolicitudesPendientesViewModel() 
        {
        
        }
    }
}
