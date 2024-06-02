using Newtonsoft.Json;

namespace LanGroupClienteEscritorio.Modelo
{
    public class Colaborador
    {
        [JsonProperty("id")] 
        public string Id { get; set; }

        [JsonProperty("usuario")] 
        public string Usuario { get; set; }

        [JsonProperty("correo")] 
        public string Correo { get; set; }

        [JsonProperty("contrasenia")] 
        public string Contrasenia { get; set; }

        [JsonProperty("nombre")] 
        public string Nombre { get; set; }

        [JsonProperty("apellido")] 
        public string Apellido { get; set; }

        [JsonProperty("descripcion")] 
        public string Descripcion { get; set;}

        [JsonProperty("rolid")]
        public string IdRol { get; set; }

        [JsonProperty("icono")]
        public string Icono { get; set; }

        public Colaborador()
        {

        }

        public Colaborador(string id, string usuario, string correo, string contrasenia, string nombre, string apellido, string descripcion, string idRol, string icono)
        {
            this.Id = id;
            this.Usuario = usuario;
            this.Correo = correo;
            this.Contrasenia = contrasenia;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Descripcion = descripcion;
            this.IdRol = idRol;
            this.Icono = icono;
        }
    }
}
