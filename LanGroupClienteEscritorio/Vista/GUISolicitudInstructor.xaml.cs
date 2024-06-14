using LanGroupClienteEscritorio.ClienteGrpc;
using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Servicio;
using LanGroupClienteEscritorio.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace LanGroupClienteEscritorio.Vista
{
    /* =========================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                       ==
     * == Fecha de actualización: 13/06/2024                                  ==
     * == Descripción: Logica de interacción para GUISolicitudInstructor.xaml ==
     * =========================================================================
     */
    public partial class GUISolicitudInstructor : Page
    {
        private Colaborador Usuario;
        private Solicitud Solicitud;
        private string RutaArchivo;

        public GUISolicitudInstructor()
        {
            InitializeComponent();
        } 

        public async void IniciarVentanaColaborador(Colaborador usuario)
        {
            bool tieneSolicitudPendiente = await TieneSolicitudPendiente(usuario);

            if(!tieneSolicitudPendiente)
            {
                Usuario = usuario;
                Solicitud = new Solicitud();
                CargarComboBox();
            }
            else
            {
                MessageBox.Show("Ya tiene una solicitud pendiente.", "Solicitud", MessageBoxButton.OK, MessageBoxImage.Information);
                GUIMenuPrincipal gUIMenuPrincipal = new GUIMenuPrincipal();
                NavigationService.Navigate(gUIMenuPrincipal);
            }
            
        }

        public void IniciarVentanaAdministrador(Colaborador usuario, Solicitud solicitud, string usuarioSolicitante)
        {
            Usuario = usuario;
            ModificarVisibilidadObjetos();
            CargarDatosSolicitud(solicitud, usuarioSolicitante);
        }

        private void ModificarVisibilidadObjetos()
        {
            labelSolicitarRol.Visibility = Visibility.Hidden;
            labelSolicitudDe.Visibility = Visibility.Visible;
            labelConstancia.Visibility = Visibility.Visible;
            buttonAgregarConstancia.Visibility = Visibility.Hidden;
            buttonDescargar.Visibility = Visibility.Visible;
            buttonGuardar.Visibility = Visibility.Hidden;
            comboBoxIdioma.Visibility = Visibility.Hidden;
            labelSeleccionarIdioma.Content = "Idioma";
            labelIdioma.Visibility = Visibility.Visible;
            textBoxRazon.IsReadOnly = true;
            textBoxTipoContenido.IsReadOnly = true;
        }

        private async void CargarDatosSolicitud(Solicitud solicitud, string usuarioSolicitante)
        {
            Solicitud = solicitud;
            labelSolicitudDe.Content = "Solicitud de " + usuarioSolicitante;
            labelNombreArchivo.Content = Solicitud.NombreArchivo;
            (Idioma idiomaSolicitud, int codigo) = await IdiomaServicio.ObtenerIdiomaPorId(solicitud.Idioma.Id);
            labelIdioma.Content = idiomaSolicitud.Nombre;
            textBoxRazon.Text = solicitud.Motivo;
            textBoxTipoContenido.Text = solicitud.Contenido;
        }

        private async void CargarComboBox()
        {
            (List<Idioma> idiomas, int codigo) = await IdiomaServicio.ObtenerIdiomas();

            foreach(Idioma idioma in idiomas)
            {
                comboBoxIdioma.Items.Add(idioma);
            }
            
            comboBoxIdioma.SelectedIndex = 0;
        }

        private void AgregarConstancia(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Documentos (*.pdf)|*.pdf";
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                if(openFileDialog.FileName != string.Empty)
                {
                    FileInfo file = new FileInfo(openFileDialog.FileName);
                    string nombreArchivo = file.Name;
                    labelNombreArchivo.Content = nombreArchivo;
                    byte[] bytesArchivo = File.ReadAllBytes(openFileDialog.FileName);
                    Solicitud.Constancia = bytesArchivo;
                    Solicitud.NombreArchivo = nombreArchivo;
                    RutaArchivo = file.FullName;
                }
                else
                {
                    Solicitud.Constancia = null;
                    MessageBox.Show("Debe seleccionar un archivo.", "Archivo no seleccionado", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private async void GuardarSolicitud(object sender, RoutedEventArgs e)
        {
            LimpiarErrores();
            if (CamposValidos())
            {
                string nombreArchivo = labelNombreArchivo.Content.ToString();
                string rutaArchivo = RutaArchivo;

                ClienteGrpc.Grpc grpc = new ClienteGrpc.Grpc();
                bool subidaExitosa = await grpc.SubirConstancia(nombreArchivo, rutaArchivo);

                //if (subidaExitosa)
                //{
                    Solicitud.IdColaborador = Usuario.Id;
                    Idioma idioma = comboBoxIdioma.SelectedItem as Idioma;
                    Solicitud.IdIdioma = idioma.Id;
                    Solicitud.Motivo = textBoxRazon.Text;
                    Solicitud.Contenido = textBoxTipoContenido.Text;
                    Solicitud.Estado = "Pendiente";

                    int codigo = await SolicitudServicio.GuardarSolicitud(Solicitud);

                    if (codigo == 200)
                    {
                        MessageBox.Show("Se subió la solicitud con éxito.", "Solicitud enviada", MessageBoxButton.OK);
                        GUIMenuPrincipal gUIMenuPrincipal = new GUIMenuPrincipal();
                        NavigationService.Navigate(gUIMenuPrincipal);
                    }
                    else
                    {
                        MostrarMensajeError();
                    }
                //}
                //else
                //{
                //    MessageBox.Show("No se pudo subir la constancia.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //}
            }
        }

        private async void Regresar(object sender, MouseButtonEventArgs e)
        {
            (Rol rol, int codigo) = await RolServicio.ObtenerRolPorId(Usuario.IdRol);

            if(rol != null && codigo == 200)
            {
                if(rol.Nombre.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                {
                    GUIInstructores guiInstructores = new GUIInstructores();
                    guiInstructores.IniciarVentanaAgregarInstructor(Usuario);
                    NavigationService.Navigate(guiInstructores);
                }
                else
                {
                    GUIMenuPrincipal gUIMenuPrincipal = new GUIMenuPrincipal();
                    NavigationService.Navigate(gUIMenuPrincipal);
                }
            }
        }

        private bool CamposValidos()
        {
            bool validos = true;

            if(String.IsNullOrEmpty(textBoxRazon.Text)) 
            { 
                validos = false;
                labelErrorRazon.Content = "No se puede dejar vacío.";
                textBoxRazon.BorderBrush = Brushes.Red;
            }

            if (String.IsNullOrEmpty(textBoxTipoContenido.Text))
            {
                validos = false;
                labelErrorTipoContenido.Content = "No se puede dejar vacío.";
                textBoxTipoContenido.BorderBrush = Brushes.Red;
            }

            if (Solicitud.Constancia == null)
            {
                validos = false;
                labelErrorConstancia.Content = "Debe de subir una constancia.";
            }

            return validos;
        }

        private void LimpiarErrores()
        {
            labelErrorRazon.Content = String.Empty;
            textBoxRazon.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
            labelErrorTipoContenido.Content = String.Empty;
            textBoxTipoContenido.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
            labelErrorConstancia.Content= String.Empty;
        }

        private void MostrarMensajeError()
        {
            MessageBox.Show("Algo salió mal.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async Task<bool> TieneSolicitudPendiente(Colaborador colaborador)
        {
            bool tieneSolicitudPendiente;
            (Solicitud solicitud, int codigo) = await SolicitudServicio.ObtenerSolicitudPorIdUsuario(colaborador.Id);
            if (solicitud != null && solicitud.Estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
            {
                tieneSolicitudPendiente = true;
            }
            else
            {
                tieneSolicitudPendiente = false;
            }

            return tieneSolicitudPendiente;
        }

        private async void DescargarConstancia(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (DialogResult.OK == folderBrowserDialog.ShowDialog())
            {
                if (folderBrowserDialog.SelectedPath != string.Empty)
                {
                    ClienteGrpc.Grpc grpc = new ClienteGrpc.Grpc();
                    await grpc.DescargarConstancia(Solicitud.NombreArchivo, folderBrowserDialog.SelectedPath);
                    MessageBox.Show("La solicitud ha sido descargada en " + folderBrowserDialog.SelectedPath + ".", "Solicitud descargada", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una carpeta de destino.", "Carpeta no seleccionada", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}