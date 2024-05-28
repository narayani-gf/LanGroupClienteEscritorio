using Newtonsoft.Json;
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
        [JsonProperty("id")]
        private string id { get; set; }

        [JsonProperty("colaboradorid")]
        private string idColaborador { get; set; }

        [JsonProperty("publicacionid")]
        private string idPublicacion { get; set; }

        [JsonProperty("valoracion")]
        private int valoracion { get; set; }

        [JsonProperty("comentario")]
        private string comentario { get; set; }

        [JsonProperty("fecha")]
        private DateTime fecha { get; set; }

        public Interaccion()
        {
        }

        public Interaccion(string id, string idColaborador, string idPublicacion, int valoracion, string comentario, DateTime fecha)
        {
            this.id = id;
            this.idColaborador = idColaborador;
            this.idPublicacion = idPublicacion;
            this.valoracion = valoracion;
            this.comentario = comentario;
            this.fecha = fecha;
        }
    }
}
