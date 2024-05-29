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
    public class ArchivoMultimedia
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("publicacionid")]
        public string idPublicacion { get; set; }

        [JsonProperty("nombre")]
        public string nombre { get; set; }

        [JsonProperty("mime")]
        public string mime { get; set; }

        [JsonProperty("tamanio")]
        public int tamanio { get; set; }

        [JsonProperty("indb")]
        public bool enBaseDatos { get; set; }

        [JsonProperty("archivo")]
        public byte[] archivo { get; set; }

        public ArchivoMultimedia()
        {
        }

        public ArchivoMultimedia(string id, string idPublicacion, string nombre, string mime, int tamanio, bool enBaseDatos, byte[] archivo)
        {
            this.id = id;
            this.idPublicacion = idPublicacion;
            this.nombre = nombre;
            this.mime = mime;
            this.tamanio = tamanio;
            this.enBaseDatos = enBaseDatos;
            this.archivo = archivo;
        }
    }
}
