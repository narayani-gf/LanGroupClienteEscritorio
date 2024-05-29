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
    * == Fecha de actualización: 28/05/2024                                ==
    * == Descripción:                                                      ==
    * =======================================================================
    */
    public class Grupo
    {
        [JsonProperty("id")]
        public string idGrupo { get; set; }

        [JsonProperty("idiomaid")]
        public string idIdioma { get; set; }

        [JsonProperty("nombre")]
        public string nombre { get; set; }

        [JsonProperty("descripcion")]
        public string descripcion { get; set; }

        [JsonProperty("icono")]
        public string icono { get; set; }

        public Grupo()
        {
        }

        public Grupo(string idGrupo, string idIdioma, string nombre, string descripcion, string icono)
        {
            this.idGrupo = idGrupo;
            this.idIdioma = idIdioma;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.icono = icono;
        }
    }
}
