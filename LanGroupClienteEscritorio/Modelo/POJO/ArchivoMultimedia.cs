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
    }
}
