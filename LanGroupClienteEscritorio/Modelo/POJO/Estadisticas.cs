using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Modelo.POJO
{
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 28/05/2024                                ==
     * == Descripción: Clase para mostrar la informacion en la grafica de   ==
     * ==              barras.                                              ==
     * =======================================================================
     */
    internal class Estadisticas
    {
        public int TotalPublicaciones { get; set; }
        public string Mes { get; set; }

        public Estadisticas(int TotalPublicaciones, string Mes)
        {
            this.TotalPublicaciones = TotalPublicaciones;
            this.Mes = Mes;
        }
    }
}
