using LanGroupClienteEscritorio.Modelo.POJO;
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
     * == Fecha de actualización: 28/05/2024                                ==
     * == Descripción: Clase para mostrar a los instructores activos en el  ==
     * ==              datagrid.                                            ==
     * =======================================================================
     */
    internal class InstructoresViewModel
    {
        //TODO cargar los instructores activos
        public ObservableCollection<Colaborador> instructores { get; set; }

        public InstructoresViewModel() 
        { 
            
        }
    }
}
