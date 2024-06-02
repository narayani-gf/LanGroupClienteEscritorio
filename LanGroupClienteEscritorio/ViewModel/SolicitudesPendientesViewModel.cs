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
     * == Fecha de actualización: 02/06/2024                                ==
     * == Descripción: Clase para mostrar las solicitudes pendientes en el  ==
     * ==              datagrid.                                            ==
     * =======================================================================
     */
    internal class SolicitudesPendientesViewModel
    {
        public ObservableCollection<Colaborador> ColaboradoresConSolicitudPendiente { get; set; }

        public SolicitudesPendientesViewModel() 
        {
            ObtenerSolicitudesPendientes();
        }

        private async void ObtenerSolicitudesPendientes()
        {
            (List<Solicitud> solicitudes, int codigoSolicitudes) = await SolicitudServicio.ObtenerSolicitudes();

            if(solicitudes != null)
            {
                List<Solicitud> solicitudesPendientes = new List<Solicitud>();
                foreach (Solicitud solicitud in solicitudes)
                {
                    if (solicitud.Estado.Equals("pendiente", StringComparison.OrdinalIgnoreCase))
                    {
                        solicitudesPendientes.Add(solicitud);
                    }
                }

                (List<Colaborador> colaboradores, int codigoColaboradores) = await ColaboradorServicio.ObtenerColaboradores();
                ColaboradoresConSolicitudPendiente = new ObservableCollection<Colaborador>();

                if(colaboradores != null)
                {
                    foreach (Colaborador colaborador in colaboradores)
                    {
                        foreach (Solicitud solicitudPendiente in solicitudesPendientes)
                        {
                            if (colaborador.Id.Equals(solicitudPendiente.IdColaborador, StringComparison.OrdinalIgnoreCase))
                            {
                                ColaboradoresConSolicitudPendiente.Add(colaborador);
                            }
                        }
                    }
                }               
            }          
        }
    }
}
