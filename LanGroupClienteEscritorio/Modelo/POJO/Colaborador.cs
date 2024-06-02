using Newtonsoft.Json;

namespace LanGroupClienteEscritorio.Modelo.POJO
{
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 01/06/2024                                 ==
     * == Descripción:                                                      ==
     * =======================================================================
     */
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
            Id = id;
            Usuario = usuario;
            Correo = correo;
            Contrasenia = contrasenia;
            Nombre = nombre;
            Apellido = apellido;
            Descripcion = descripcion;
            IdRol = idRol;
            Icono = icono;
        }
    }
}
