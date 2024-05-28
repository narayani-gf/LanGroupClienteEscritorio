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
    internal class ArchivoMultimedia
    {
        [JsonProperty("id")]
        private string id { get; set; }

        [JsonProperty("publicacionid")]
        private string idPublicacion { get; set; }

        [JsonProperty("nombre")]
        private string nombre { get; set; }

        [JsonProperty("mime")]
        private string mime { get; set; }

        [JsonProperty("tamanio")]
        private int tamanio { get; set; }

        [JsonProperty("indb")]
        private bool enBaseDatos { get; set; }

        [JsonProperty("archivo")]
        private byte[] archivo { get; set; }

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
