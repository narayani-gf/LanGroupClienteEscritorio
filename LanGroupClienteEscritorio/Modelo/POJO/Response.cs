using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Modelo.POJO

{
    public class Response
    {
        [JsonProperty("correo")]
        public string Correo { get; set; }

        [JsonProperty("usuario")]
        public string Usuario { get; set;}

        [JsonProperty("rol")]
        public string Rol {  get; set; }

        [JsonProperty("jwt")]
        public string Jwt { get; set; }

        [JsonProperty("codigo")]
        public int Codigo { get; set; }
    }
}
