using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Servicio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace LanGroupClienteEscritorio.ViewModel
{
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 29/05/2024                                ==
     * == Descripción: Clase para mostrar las solicitudes pendientes en el  ==
     * ==              datagrid.                                            ==
     * =======================================================================
     */
    internal class SolicitudesPendientesViewModel
    {
        public ObservableCollection<Colaborador> colaboradoresConSolicitudPendiente { get; set; }

        public SolicitudesPendientesViewModel() 
        {
            ObtenerSolicitudesPendientes();
        }

        private async void ObtenerSolicitudesPendientes()
        {
            colaboradoresConSolicitudPendiente = null;
            List<Solicitud> solicitudes = await SolicitudServicio.ObtenerSolicitudes();

            if(solicitudes != null)
            {
                List<Solicitud> solicitudesPendientes = new List<Solicitud>();
                foreach (Solicitud solicitud in solicitudes)
                {
                    if (solicitud.estado.Equals("pendiente", StringComparison.OrdinalIgnoreCase))
                    {
                        solicitudesPendientes.Add(solicitud);
                    }
                }

                List<Colaborador> colaboradores = await ColaboradorServicio.ObtenerColaboradores();
                colaboradoresConSolicitudPendiente = new ObservableCollection<Colaborador>();

                foreach(Colaborador colaborador in colaboradores)
                {
                    for(int i = 0; i < solicitudesPendientes.Count; i++)
                    {
                        if (colaborador.id.Equals(solicitudesPendientes[i].idColaborador, StringComparison.OrdinalIgnoreCase))
                        {
                            colaboradoresConSolicitudPendiente.Add(colaborador);
                        }
                    }
                }
            }          
        }
    }
}
