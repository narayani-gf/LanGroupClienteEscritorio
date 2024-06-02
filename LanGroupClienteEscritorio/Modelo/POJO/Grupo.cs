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
    public class Grupo
    {
        [JsonProperty("id")]
        public string IdGrupo { get; set; }

        [JsonProperty("idiomaid")]
        public string IdIdioma { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("icono")]
        public string Icono { get; set; }

        public Grupo()
        {
        }

        public Grupo(string idGrupo, string idIdioma, string nombre, string descripcion, string icono)
        {
            IdGrupo = idGrupo;
            IdIdioma = idIdioma;
            Nombre = nombre;
            Descripcion = descripcion;
            Icono = icono;
        }
    }
}
