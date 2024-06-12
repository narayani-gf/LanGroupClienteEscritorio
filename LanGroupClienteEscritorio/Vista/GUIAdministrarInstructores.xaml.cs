using LanGroupClienteEscritorio.Modelo.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LanGroupClienteEscritorio.Vista
{
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 12/06/2024                                ==
     * == Descripción: Logica de interacción para                           ==
     * ==              GUIAdministrarInstructores.xaml                      ==
     * =======================================================================
     */
    public partial class GUIAdministrarInstructores : Page
    {
        Colaborador Usuario;

        public GUIAdministrarInstructores()
        {
            InitializeComponent();
        }

        public void IniciarVentana(Colaborador usuario)
        {
            Usuario = usuario;
        }

        private void IrEliminarInstructores(object sender, RoutedEventArgs e)
        {
            GUIInstructores gUIInstructores = new GUIInstructores();
            gUIInstructores.IniciarVentanaEliminarInstructor(Usuario);
            NavigationService.Navigate(gUIInstructores);
        }

        private void IrAgregarInstructores(object sender, RoutedEventArgs e)
        {
            GUIInstructores gUIInstructores = new GUIInstructores();
            gUIInstructores.IniciarVentanaAgregarInstructor(Usuario);
            NavigationService.Navigate(gUIInstructores);
        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
            GUIMenuPrincipal gUIMenuPrincipal = new GUIMenuPrincipal();
            NavigationService.Navigate(gUIMenuPrincipal);
        }
    }
}
