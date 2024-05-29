using LanGroupClienteEscritorio.Modelo.POJO;
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
     * == Fecha de actualización: 29/05/2024                                ==
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
            obtenerInstructores();
        }

        private async void obtenerInstructores()
        {
            List<Colaborador> colaboradoresApi = await ColaboradorServicio.obtenerInstructores();

            if( colaboradoresApi != null )
            {
                instructores = new ObservableCollection<Colaborador>();
                foreach (Colaborador instructor in colaboradoresApi)
                {
                    instructores.Add(instructor);
                }
            }          
        }
    }
}
