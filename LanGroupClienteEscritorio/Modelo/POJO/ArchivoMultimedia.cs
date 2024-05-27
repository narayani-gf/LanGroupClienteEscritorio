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
    internal class ArchivoMultimedia
    {
        private string idArchivoMultimedia { get; set; }
        private string idPublicacion { get; set; }
        private string nombre { get; set; }
        private string mime { get; set; }
        private int tamanio { get; set; }
        private bool enBaseDatos { get; set; }

        private string rutaArchivo { get; set; }
    }
}
