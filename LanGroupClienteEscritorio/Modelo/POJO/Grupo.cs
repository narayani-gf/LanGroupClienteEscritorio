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
    internal class Grupo
    {
        private string idGrupo { get; set; }
        private string idIdioma { get; set; }
        private string nombre { get; set; }
        private string descripcion { get; set; }
        private string icono { get; set; }

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
