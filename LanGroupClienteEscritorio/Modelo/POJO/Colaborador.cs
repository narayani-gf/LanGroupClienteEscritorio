using Newtonsoft.Json;

namespace LanGroupClienteEscritorio.Modelo.POJO
{
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 27/05/2024                                ==
     * == Descripción:                                                      ==
     * =======================================================================
     */
    public class Colaborador
    {
        [JsonProperty("id")] 
        public string id { get; set; }

        [JsonProperty("usuario")] 
        public string usuario { get; set; }

        [JsonProperty("correo")] 
        public string correo { get; set; }

        [JsonProperty("contrasenia")] 
        public string contrasenia { get; set; }

        [JsonProperty("nombre")] 
        public string nombre { get; set; }

        [JsonProperty("apellido")] 
        public string apellido { get; set; }

        [JsonProperty("descripcion")]
        public string descripcion { get; set;}

        [JsonProperty("rolid")]
        public string idRol { get; set; }

        [JsonProperty("icono")]
        public string icono { get; set; }

        public Colaborador()
        {

        }

        public Colaborador(string id, string usuario, string correo, string contrasenia, string nombre, string apellido, string descripcion, string idRol, string icono)
        {
            this.id = id;
            this.usuario = usuario;
            this.correo = correo;
            this.contrasenia = contrasenia;
            this.nombre = nombre;
            this.apellido = apellido;
            this.descripcion = descripcion;
            this.idRol = idRol;
            this.icono = icono;
        }
    }
}
