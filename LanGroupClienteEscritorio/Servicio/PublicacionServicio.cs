using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Servicio
{
    public class PublicacionServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "publicaciones");

        public static async Task<List<Publicacion>> ObtenerPublicacionesPorColaborador(string usuario)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            using(var httpCliente = new HttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = await httpCliente.GetAsync(URL + $"/colaborador?={usuario}");

                    if (httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            publicaciones = JsonConvert.DeserializeObject<List<Publicacion>>(json);
                        }

                    }
                    else
                    {
                        publicaciones = null;
                    }
                }
                catch (HttpRequestException ex)
                {
                    publicaciones = null;
                }
                catch(JsonException ex)
                {
                    publicaciones = null;
                }
            }

            return publicaciones;
        }
    }
}
