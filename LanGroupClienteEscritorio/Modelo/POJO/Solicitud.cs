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
    public class Solicitud
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("colaboradorid")]
        public string idColaborador { get; set; }

        [JsonProperty("idiomaid")]
        public string idIdioma { get; set; }

        [JsonProperty("constancia")]
        public byte[] constancia { get; set; }

        [JsonProperty("contenido")]
        public string contenido { get; set; }

        [JsonProperty("motivo")]
        public string motivo { get; set; }

        [JsonProperty("estado")]
        public string estado { get; set; }

        public Solicitud()
        {
        }

        public Solicitud(string id, string idColaborador, string idIdioma, byte[] constancia, string contenido, string motivo, string estado)
        {
            this.id = id;
            this.idColaborador = idColaborador;
            this.idIdioma = idIdioma;
            this.constancia = constancia;
            this.contenido = contenido;
            this.motivo = motivo;
            this.estado = estado;
        }
    }
}
