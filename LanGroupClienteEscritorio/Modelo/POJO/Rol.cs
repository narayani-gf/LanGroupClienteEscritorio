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
    internal class Rol
    {
        [JsonProperty("id")]
        private string id { get; set; }

        [JsonProperty("nombre")]
        private string nombre { get; set; }

        public Rol()
        {
        }

        public Rol(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
