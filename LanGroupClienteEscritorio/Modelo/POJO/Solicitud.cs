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
    public class Solicitud
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("colaboradorid")]
        public string IdColaborador { get; set; }

        [JsonProperty("idiomaid")]
        public string IdIdioma { get; set; }

        [JsonProperty("constancia")]
        public byte[] Constancia { get; set; }

        [JsonProperty("contenido")]
        public string Contenido { get; set; }

        [JsonProperty("motivo")]
        public string Motivo { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        public Solicitud()
        {
        }

        public Solicitud(string id, string idColaborador, string idIdioma, byte[] constancia, string contenido, string motivo, string estado)
        {
            Id = id;
            IdColaborador = idColaborador;
            IdIdioma = idIdioma;
            Constancia = constancia;
            Contenido = contenido;
            Motivo = motivo;
            Estado = estado;
        }
    }
}
