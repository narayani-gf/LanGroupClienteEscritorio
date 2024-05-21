using LanGroupClienteEscritorio.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Windows;
using System.Windows.Controls;


namespace LanGroupClienteEscritorio.Utils
{
    public class AdministrarNavegacion
    {
        public static void RegresarPaginaPrincipal()
        {
            GUIAnadirInteraccion gUIAnadirInteraccion = new GUIAnadirInteraccion();
            NavigationService.GetNavigationService(gUIAnadirInteraccion);
        }

    }
}
