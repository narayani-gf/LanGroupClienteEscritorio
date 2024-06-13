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
    * == Fecha de actualización: 13/06/2024                                ==
    * == Descripción:                                                      ==
    * =======================================================================
    */
    public class Solicitud
    {
        [JsonProperty("solicitudId")]
        public string Id { get; set; }

        [JsonProperty("constancia")]
        public byte[] Constancia { get; set; }

        [JsonProperty("nombrearchivo")]
        public string NombreArchivo { get; set; }

        [JsonProperty("contenido")]
        public string Contenido { get; set; }

        [JsonProperty("motivo")]
        public string Motivo { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("colaboradorid")]
        public string IdColaborador { get; set; }

        [JsonProperty("idiomaid")]
        public string IdIdioma { get; set; }

        [JsonProperty("colaborador")]
        public Colaborador Colaborador { get; set; }

        [JsonProperty("idioma")]
        public Idioma Idioma { get; set; }

        public Solicitud()
        {
        }

        public Solicitud(string id, byte[] constancia, string nombreArchivo, string contenido, string motivo, string estado, string idColaborador, string idIdioma, Colaborador colaborador, Idioma idioma)
        {
            Id = id;
            Constancia = constancia;
            NombreArchivo = nombreArchivo;
            Contenido = contenido;
            Motivo = motivo;
            Estado = estado;
            IdColaborador = idColaborador;
            IdIdioma = idIdioma;
            Colaborador = colaborador;
            Idioma = idioma;
        }
    }
}