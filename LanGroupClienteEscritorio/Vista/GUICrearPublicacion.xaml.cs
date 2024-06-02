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
	/// Interaction logic for GUICrearPublicacion.xaml
	/// </summary>
	public partial class GUICrearPublicacion : Page
	{
		public GUICrearPublicacion()
		{
			InitializeComponent();
		}

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Utils.AdministrarNavegacion.MostrarMenuPrincipal();
        }
    }
}
