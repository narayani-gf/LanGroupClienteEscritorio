using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Modelo
{
    public class ArchivoMultimedia
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("publicacionid")]
        public string IdPublicacion { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("mime")]
        public string Mime { get; set; }

        [JsonProperty("tamanio")]
        public int Tamanio { get; set; }

        [JsonProperty("indb")]
        public bool EnBaseDatos { get; set; }

        [JsonProperty("archivo")]
        public byte[] Archivo { get; set; }

        public ArchivoMultimedia()
        {
        }

        public ArchivoMultimedia(string id, string idPublicacion, string nombre, string mime, int tamanio, bool enBaseDatos, byte[] archivo)
        {
            this.Id = id;
            this.IdPublicacion = idPublicacion;
            this.Nombre = nombre;
            this.Mime = mime;
            this.Tamanio = tamanio;
            this.EnBaseDatos = enBaseDatos;
            this.Archivo = archivo;
        }
    }
}
