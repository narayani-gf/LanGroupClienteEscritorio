using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Modelo.POJO
{
    internal class ColaboradorRequest
    {
        [JsonProperty("rolid")]
        public string RolId { get; set; }
        public ColaboradorRequest() { }
    }
}
