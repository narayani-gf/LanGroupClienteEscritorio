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
    internal class Idioma
    {
        private string idIdioma {  get; set; }
        private string nombre { get; set; }

        public Idioma()
        {
        }

        public Idioma(string idIdioma, string nombre)
        {
            this.idIdioma = idIdioma;
            this.nombre = nombre;
        }
    }
}
