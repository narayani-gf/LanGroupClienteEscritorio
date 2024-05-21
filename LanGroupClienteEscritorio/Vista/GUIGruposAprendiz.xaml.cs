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
    /// <summary>
    /// Lógica de interacción para GUIGruposAprendiz.xaml
    /// </summary>
    public partial class GUIGruposAprendiz : Page
    {
        public GUIGruposAprendiz()
        {
            InitializeComponent();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Utils.AdministrarNavegacion.RegresarPaginaPrincipal();
        }
    }
}
