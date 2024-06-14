using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Servicio;
using LanGroupClienteEscritorio.Utils;

namespace LanGroupClienteEscritorio.Vista
{
    /// <summary>
    /// Lógica de interacción para GUIRegisterView.xaml
    /// </summary>
    public partial class GUIRegistrarCuenta : Page
    {
        private string IdUsuario;
        private Colaborador Colaborador;
        private string rutaIcono;

        public GUIRegistrarCuenta()
        {
            InitializeComponent();
        }

        public GUIRegistrarCuenta(string idUsuario)
        {
            InitializeComponent();
            IdUsuario = idUsuario;
            lblTitulo.Content = "Modificar cuenta";
            btnCrearCuenta.Content = "Modificar cuenta";
            lbContrasenia.Visibility = Visibility.Hidden;
            txtbContrasenia.Visibility = Visibility.Hidden;
            lblErrorContrasenia.Visibility = Visibility.Hidden;
            lbConfirmarContrasenia.Visibility = Visibility.Hidden;
            txtbConfirmarContrasenia.Visibility = Visibility.Hidden;
            lbConfirmarContrasenia.Visibility = Visibility.Hidden;
            RecuperarColaborador(idUsuario);
        }

        public async void RecuperarColaborador(string idUsuario)
        {
            var (colaborador, codigo) = await ColaboradorServicio.ObtenerColaboradorPorId(idUsuario);
            Colaborador = colaborador;
            txtbUsuario.Text = colaborador.Usuario;
            txtbCorreo.Text = colaborador.Correo;
            txtbNombre.Text = colaborador.Nombre;
            txtbApellido.Text = colaborador.Apellido;
            txtbDescripcion.Text = colaborador.Descripcion;
            rutaIcono = colaborador.Icono;
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Utils.AdministrarNavegacion.MostrarMenuPrincipal();
        }

        private void LblCambiarIcono_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;

                string relativeFolderPath = @"Vista\Recursos\Imagenes\Perfiles";

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.FullName;
                string targetFolder = Path.Combine(projectDirectory, relativeFolderPath);


                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }

                string fileName = Path.GetFileName(selectedFilePath);

                string newFilePath = Path.Combine(targetFolder, fileName);

                try
                {
                    File.Copy(selectedFilePath, newFilePath, true);

                    rutaIcono = Path.Combine(relativeFolderPath, fileName).Replace('\\', '/'); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar la imagen: {ex.Message}");
                }
            }
        }

        private void BtnCrearCuenta_Click(object sender, RoutedEventArgs e)
        {
            if (IdUsuario == null)
            {
                // Crear un nuevo Colaborador
                Colaborador = new Colaborador
                {
                    Usuario = txtbUsuario.Text,
                    Correo = txtbCorreo.Text,
                    Nombre = txtbNombre.Text,
                    Apellido = txtbApellido.Text,
                    Descripcion = txtbDescripcion.Text,
                    Contrasenia = txtbContrasenia.Text,
                    Icono = rutaIcono
                };

                Response response = await ColaboradorServicio.RegistrarColaborador(Colaborador);

                if (response.Codigo == (int)HttpStatusCode.OK)
                {
                    var auth = new Auth()
                    {
                        Correo = txtbCorreo.Text,
                        Contrasenia = txtbContrasenia.Text,
                    };

                    IniciarSesion(auth);
                }
            }
            else
            {
                Colaborador.Id = IdUsuario;
                Colaborador.Usuario = txtbUsuario.Text;
                Colaborador.Correo = txtbCorreo.Text;
                Colaborador.Nombre = txtbNombre.Text;
                Colaborador.Apellido = txtbApellido.Text;
                Colaborador.Descripcion = txtbDescripcion.Text;
                Colaborador.Icono = rutaIcono;

                Response response = await ColaboradorServicio.ModificarColaborador(Colaborador, IdUsuario);

                MessageBox.Show("Cuenta modificada exitosamente.");
            }
        }

        private async void IniciarSesion(Auth auth)
        {
            Response response = await AuthServicio.IniciarSesion(auth);

            switch (response.Codigo)
            {
                case (int)HttpStatusCode.OK:
                    GuardarToken(response.Jwt);
                    int codigo = await GuardarSingletonAsync();

                    if ((int)HttpStatusCode.OK == codigo)
                        SeleccionarIdioma();
                    else
                    {
                        MessageBox.Show("Ocurrió un problema con el servidor. Intenta más tarde.");
                    }
                    break;
                case (int)HttpStatusCode.Unauthorized:
                    MessageBox.Show("Verifica tus credenciales.");
                    break;
                default:
                    MessageBox.Show("Ocurrió un problema con el servidor. Intenta más tarde.");
                    break;
            }
        }

        private void GuardarToken(string jwt)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            KeyValueConfigurationElement token = configuration.AppSettings.Settings["TOKEN"];
            token.Value = jwt;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        private async Task<int> GuardarSingletonAsync()
        {
            var (colaborador, codigo) = await ColaboradorServicio.ObtenerColaborador(txtbCorreo.Text);
            SesionSingleton.Instance.SetColaborador(colaborador);
            return codigo;
        }

        public void SeleccionarIdioma()
        {
            GUISeleccionarIdioma gUISeleccionarIdioma = new GUISeleccionarIdioma();
            NavigationService.Navigate(gUISeleccionarIdioma);
        }

        private void TxtbDescripcion_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtbDescripcion.Text.Length > 0)
            {
                lblMensajeDescripcion.Visibility = Visibility.Collapsed;
            }
            else
            {
                lblMensajeDescripcion.Visibility = Visibility.Visible;
            }
        }
    }
}
