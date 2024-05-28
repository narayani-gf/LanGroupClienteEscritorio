using Newtonsoft.Json;

namespace LanGroupClienteEscritorio.Modelo.POJO
{
    /* =======================================================================
     * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
     * == Fecha de actualización: 27/05/2024                                ==
     * == Descripción:                                                      ==
     * =======================================================================
     */
    internal class Colaborador
    {
        [JsonProperty("id")] 
        private string id { get; set; }

        [JsonProperty("usuario")] 
        private string usuario { get; set; }

        [JsonProperty("correo")] 
        private string correo { get; set; }

        [JsonProperty("contrasenia")] 
        private string contrasenia { get; set; }

        [JsonProperty("nombre")] 
        private string nombre { get; set; }

        [JsonProperty("apellido")] 
        private string apellido { get; set; }

        [JsonProperty("descripcion")] 
        private string descripcion { get; set;}

        [JsonProperty("rolid")]
        private string idRol { get; set; }

        [JsonProperty("icono")]
        private string icono { get; set; }

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
