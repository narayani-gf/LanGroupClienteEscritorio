﻿using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Servicio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.ViewModel
{
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 02/06/2024                                ==
     * == Descripción: Clase para mostrar a los idiomas en el combobox.     ==
     * =======================================================================
     */

    internal class IdiomasViewModel
    {
        public ObservableCollection<Idioma> Idiomas { get; set; }

        public IdiomasViewModel() 
        {
            ObtenerIdiomas();
        }

        private async void ObtenerIdiomas()
        {
            List<Idioma> idiomasApi = await IdiomaServicio.ObtenerIdiomas();

            if(idiomas != null)
            {
                idiomas = new ObservableCollection<Idioma>();

                foreach(Idioma idioma in idiomasApi)
                {
                    idiomas.Add(idioma);
                }
            }
        }
    }
}
