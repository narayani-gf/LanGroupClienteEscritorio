using LanGroupClienteEscritorio.Modelo;
using LanGroupClienteEscritorio.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Servicio
{
    public class PublicacionServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "publicaciones");
        private static string TOKEN = SesionSingleton.Instance.Token;

        public static async Task<(List<Publicacion>, int)> ObtenerPublicacionesPorColaborador(string idUsuario)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            int codigo = 500;
            using(var httpCliente = new HttpClient())
            {
                try
                {
                    var httpMensaje = new HttpRequestMessage()
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(URL + $"/?colaborador={idUsuario}")
                    };

                    httpMensaje.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TOKEN);

                    HttpResponseMessage httpResponseMessage = await httpCliente.SendAsync(httpMensaje);

                    if (httpResponseMessage != null)
                    {
                        if (httpResponseMessage.Headers.Contains("Set-Authorization"))
                        {
                            IEnumerable<string> valores;

                            if (httpResponseMessage.Headers.TryGetValues("Set-Authorization", out valores))
                            {
                                string nuevoToken = valores.FirstOrDefault();
                                if (!string.IsNullOrEmpty(nuevoToken))
                                {
                                    GuardarToken(nuevoToken);
                                    TOKEN = nuevoToken;
                                }
                            }
                        }

                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            publicaciones = JsonConvert.DeserializeObject<List<Publicacion>>(json);
                        }

                        codigo = (int) httpResponseMessage.StatusCode;
                    }
                    else
                    {
                        publicaciones = null;
                        codigo = (int)HttpStatusCode.InternalServerError;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Logger.Log(ex);
                    publicaciones = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
                catch (JsonException ex)
                {
                    Logger.Log(ex);
                    publicaciones = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return (publicaciones, codigo);
        }

        private static void GuardarToken(string jwt)
        {
            SesionSingleton.Instance.SetToken(jwt);
        }
    }
}
