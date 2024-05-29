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
    public class Idioma
    {
        [JsonProperty("id")]
        public string id {  get; set; }

        [JsonProperty("nombre")]
        public string nombre { get; set; }

        public Idioma()
        {
        }

        public Idioma(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
