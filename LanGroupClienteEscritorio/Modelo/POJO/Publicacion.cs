using LanGroupClienteEscritorio.Modelo.POJO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Modelo
{
    public class Publicacion
    {
        private List<Interaccion> interacciones;

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

        public float Valoracion {  get; set; }

        public string Colaborador { get; set; }
        public string Grupo { get; set; }

        public List<Interaccion> Interacciones { get; set; }
      
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
