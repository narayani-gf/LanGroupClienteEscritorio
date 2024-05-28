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
    internal class Publicacion
    {
        [JsonProperty("id")]
        private string id { get; set; }

        [JsonProperty("colaboradorid")]
        private string idColaborador { get; set; }

        [JsonProperty("grupoid")]
        private string idGrupo { get; set; }

        [JsonProperty("titulo")]
        private string titulo { get; set; }

        [JsonProperty("descripcion")]
        private string descripcion { get; set; }

        [JsonProperty("fecha")]
        private DateTime fecha { get; set; }

        public Publicacion()
        {
        }

        public Publicacion(string id, string idColaborador, string idGrupo, string titulo, string descripcion, DateTime fecha)
        {
            this.id = id;
            this.idColaborador = idColaborador;
            this.idGrupo = idGrupo;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fecha = fecha;
        }
    }
}
