using Newtonsoft.Json;

namespace LanGroupClienteEscritorio.Modelo.POJO
{
    public class Colaborador
    {
        [JsonProperty("colaboradorId")] 
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
    }
}
