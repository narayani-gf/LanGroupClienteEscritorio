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
    public class Publicacion
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("colaboradorid")]
        public string IdColaborador { get; set; }

        [JsonProperty("grupoid")]
        public string IdGrupo { get; set; }

        [JsonProperty("titulo")]
        public string Titulo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        public Publicacion()
        {
        }

        public Publicacion(string id, string idColaborador, string idGrupo, string titulo, string descripcion, DateTime fecha)
        {
            Id = id;
            IdColaborador = idColaborador;
            IdGrupo = idGrupo;
            Titulo = titulo;
            Descripcion = descripcion;
            Fecha = fecha;
        }
    }
}
