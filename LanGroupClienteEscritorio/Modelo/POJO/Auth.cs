using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LanGroupClienteEscritorio.Modelo
{
    public class Auth
    {
        [JsonProperty("correo")]
        public string Correo { get; set; }
        [JsonProperty("contrasenia")]
        public string Contrasenia { get; set; }
    }
}
