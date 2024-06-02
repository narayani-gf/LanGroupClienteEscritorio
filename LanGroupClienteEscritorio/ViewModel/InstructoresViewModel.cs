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
            List<Colaborador> colaboradores = await ColaboradorServicio.ObtenerInstructores();

            if(colaboradores != null )
            {
                instructores = new ObservableCollection<Colaborador>();
                foreach (Colaborador instructor in colaboradores)
                {
                    instructores.Add(instructor);
                }
            }          
        }
    }
}
