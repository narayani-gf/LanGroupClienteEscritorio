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
        private string id { get; set; }

        [JsonProperty("colaboradorid")]
        private string idColaborador { get; set; }

        [JsonProperty("idiomaid")]
        private string idIdioma { get; set; }

        [JsonProperty("constancia")]
        private byte[] constancia { get; set; }

        [JsonProperty("contenido")]
        private string contenido { get; set; }

        [JsonProperty("motivo")]
        private string motivo { get; set; }

        [JsonProperty("estado")]
        private string estado { get; set; }

        [JsonProperty("profesion")]
        private string profesion { get; set; }

        public Solicitud()
        {
        }

        public Solicitud(string id, string idColaborador, string idIdioma, byte[] constancia, string contenido, string motivo, string estado, string profesion)
        {
            this.id = id;
            this.idColaborador = idColaborador;
            this.idIdioma = idIdioma;
            this.constancia = constancia;
            this.contenido = contenido;
            this.motivo = motivo;
            this.estado = estado;
            this.profesion = profesion;
        }
    }
}
