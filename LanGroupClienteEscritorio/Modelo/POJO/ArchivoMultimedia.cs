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
            Id = id;
            IdPublicacion = idPublicacion;
            Nombre = nombre;
            Mime = mime;
            Tamanio = tamanio;
            EnBaseDatos = enBaseDatos;
            Archivo = archivo;
        }
    }
}
