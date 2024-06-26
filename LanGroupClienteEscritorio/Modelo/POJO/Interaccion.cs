﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Modelo
{
    public class Interaccion
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("colaboradorid")]
        public string IdColaborador { get; set; }

        [JsonProperty("publicacionid")]
        public string IdPublicacion { get; set; }

        [JsonProperty("valoracion")]
        public int Valoracion { get; set; }

        [JsonProperty("comentario")]
        public string Comentario { get; set; }

        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        public string Colaborador { get; set; }


        public Interaccion()
        {
        }
    }
}
