using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Modelo.POJO
{
    /* ======================================================================
    * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
    * == Fecha de actualización: 27/05/2024                                ==
    * == Descripción:                                                      ==
    * =======================================================================
    */
    internal class Solicitud
    {
        private string idSolicitud { get; set; }
        private string idUsuarioColaborador { get; set; }
        private string idIdioma { get; set; }
        private string rutaConstancia { get; set; }
        private string contenido { get; set; }
        private string motivo { get; set; }
        private string estado { get; set; }
        private string profesion { get; set; }

        public Solicitud()
        {
        }

        public Solicitud(string idSolicitud, string idUsuarioColaborador, string idIdioma, string rutaConstancia, string contenido, string motivo, string estado, string profesion)
        {
            this.idSolicitud = idSolicitud;
            this.idUsuarioColaborador = idUsuarioColaborador;
            this.idIdioma = idIdioma;
            this.rutaConstancia = rutaConstancia;
            this.contenido = contenido;
            this.motivo = motivo;
            this.estado = estado;
            this.profesion = profesion;
        }
    }
}
