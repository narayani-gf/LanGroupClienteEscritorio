using LanGroupClienteEscritorio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Utils
{
    internal class SesionSingleton
    {
        private static SesionSingleton instance;

        public Colaborador Colaborador {  get; private set; }

        public static SesionSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SesionSingleton();
                }

                return instance;
            }
        }

        public void SetColaborador(Colaborador colaborador)
        {
            Colaborador = colaborador;
        }
    }
}
