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
    * == Fecha de actualización: 01/06/2024                                ==
    * == Descripción:                                                      ==
    * =======================================================================
    */
    public class Interaccion
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("colaboradorid")]
        public string IdColaborador { get; set; }

        [JsonProperty("publicacionid")]
        public string IdPublicacion { get; set; }

        [JsonProperty("valoracion")]
        public int Valoracion { get; set; }

        [JsonProperty("comentario")]
        public string Comentario { get; set; }

        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        public Interaccion()
        {
        }

        public Interaccion(string id, string idColaborador, string idPublicacion, int valoracion, string comentario, DateTime fecha)
        {
            Id = id;
            IdColaborador = idColaborador;
            IdPublicacion = idPublicacion;
            Valoracion = valoracion;
            Comentario = comentario;
            Fecha = fecha;
        }
    }
}
