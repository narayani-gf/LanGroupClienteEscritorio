﻿using Grpc.Core;
using LanGroupClienteEscritorio.Modelo;
using LanGroupClienteEscritorio.Modelo.POJO;
//using LanGroupClienteEscritorio.proto;
using LanGroupClienteEscritorio.Servicio;
using LanGroupClienteEscritorio.Utils;
using LanGroupClienteEscritorio.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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
     * == Fecha de actualización: 02/05/2024                                  ==
     * == Descripción: Logica de interacción para GUISolicitudInstructor.xaml ==
     * =========================================================================
     */
    public partial class GUISolicitudInstructor : Page
    {
        private Response Usuario;
        private Solicitud Solicitud;

        private static readonly int GRPC_PORT = 3300;
        private static readonly string GRPC_URL = "http://localhost:" + GRPC_PORT;

        public GUISolicitudInstructor()
        {
            InitializeComponent();
        } 

        public void IniciarVentanaColaborador(Response usuario)
        {
            Usuario = usuario;
            Solicitud = new Solicitud();
            CargarComboBox();
        }

        public void IniciarVentanaAdministrador(Response usuario, Solicitud solicitud, string usuarioSolicitante)
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
            labelSeleccionarIdioma.Visibility = Visibility.Hidden;
            labelIdioma.Visibility = Visibility.Visible;
            textBoxRazon.IsReadOnly = true;
            textBoxTipoContenido.IsReadOnly = true;
        }

        private async void CargarDatosSolicitud(Solicitud solicitud, string usuarioSolicitante)
        {
            Solicitud = solicitud;
            labelSolicitudDe.Content = "Solicitud de " + usuarioSolicitante;
            labelNombreArchivo.Content = "";
            (Idioma idiomaSolicitud, int codigo) = await IdiomaServicio.ObtenerIdiomaPorId(solicitud.IdIdioma);
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

        private async void AgregarConstancia(object sender, RoutedEventArgs e)
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
                }
                else
                {
                    Solicitud.Constancia = null;
                    MessageBox.Show("Debe seleccionar un archivo.", "Archivo no seleccionado", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void DescargarConstancia(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (DialogResult.OK == folderBrowserDialog.ShowDialog())
            {
                if (folderBrowserDialog.SelectedPath != string.Empty)
                {
                    //TODO obtener desde la api                
                    //ClienteGrpc clienteGrpc = new ClienteGrpc(GRPC_URL);
                    //await clienteGrpc.DescargarConstancia("uploads/", folderBrowserDialog.SelectedPath);

                    File.WriteAllBytes(folderBrowserDialog.SelectedPath + ".pdf", Solicitud.Constancia);

                    MessageBox.Show("La solicitud ha sido descargada en " + folderBrowserDialog.SelectedPath + ".", "Solicitud descargada", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una carpeta de destino.", "Carpeta no seleccionada", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        private async void GuardarSolicitud(object sender, RoutedEventArgs e)
        {
            LimpiarErrores();
            if (CamposValidos())
            {
                //ClienteGrpc clienteGrpc = new ClienteGrpc(GRPC_URL);
                //await clienteGrpc.SubirConstancia("uploads/" + labelNombreArchivo.Content, bytesArchivo);
                int codigo = await SolicitudServicio.GuardarSolicitud(Solicitud);

                if(codigo == 200)
                {
                    MessageBox.Show("Se subió la solicitud con éxito.", "Solicitud enviada", MessageBoxButton.OK);
                }
                else
                {
                    MostrarMensajeError();
                }
            }
        }

        private void Regresar(object sender, MouseButtonEventArgs e)
        {            
            if (Usuario.Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                GUIInstructores guiInstructores = new GUIInstructores();
                guiInstructores.IniciarVentanaAgregarInstructor(Usuario);
                NavigationService.Navigate(guiInstructores);
            }
            else
            {
                AdministrarNavegacion.MostrarMenuPrincipal();
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
            labelErrorProfesion.Content = String.Empty;
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
    }
}
