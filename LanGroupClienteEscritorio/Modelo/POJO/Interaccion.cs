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
    internal class Interaccion
    {
        private string idInteraccion { get; set; }
        private string idColaborador { get; set; }
        private string idPublicacion { get; set; }
        private int valoracion { get; set; }
        private string comentario { get; set; }
        private DateTime fecha { get; set; }

        public Interaccion()
        {
        }

        public Interaccion(string idInteraccion, string idColaborador, string idPublicacion, int valoracion, string comentario, DateTime fecha)
        {
            this.idInteraccion = idInteraccion;
            this.idColaborador = idColaborador;
            this.idPublicacion = idPublicacion;
            this.valoracion = valoracion;
            this.comentario = comentario;
            this.fecha = fecha;
        }
    }
}
