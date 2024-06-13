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
    public class Idioma
    {
        [JsonProperty("idiomaId")]
        public string Id {  get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        public Idioma()
        {
        }

        public Idioma(string id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
