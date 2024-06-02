using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LanGroupClienteEscritorio.Modelo;
using Newtonsoft.Json;

namespace LanGroupClienteEscritorio.Servicio
{
    public class PublicacionServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "publicaciones");

        public static async Task<(List<Publicacion>, int)> RecuperarPublicaciones()
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            int codigo = 500;

            using (var httpCliente = new HttpClient())
            {
                try
                {
                    var httpMensaje = new HttpRequestMessage()
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(URL)
                    };

                    HttpResponseMessage httpResponseMessage = await httpCliente.SendAsync(httpMensaje);

                    if (httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            publicaciones = JsonConvert.DeserializeObject<List<Publicacion>>(json);
                        }

                        codigo = (int)httpResponseMessage.StatusCode;
                    }
                    else
                    {
                        codigo = (int)HttpStatusCode.InternalServerError;
                    }
                }
                catch (HttpRequestException ex)
                {
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
                catch (JsonException ex)
                {
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return (publicaciones, codigo);
        }
    }
}
