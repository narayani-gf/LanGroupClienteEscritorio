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
        private string idPublicacion { get; set; }
        private string idColaborador { get; set; }
        private string idGrupo { get; set; }
        private string titulo { get; set; }
        private string descripcion { get; set; }
        private DateTime fecha { get; set; }

        public Publicacion()
        {
        }

        public Publicacion(string idPublicacion, string idColaborador, string idGrupo, string titulo, string descripcion, DateTime fecha)
        {
            this.idPublicacion = idPublicacion;
            this.idColaborador = idColaborador;
            this.idGrupo = idGrupo;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fecha = fecha;
        }
    }
}
