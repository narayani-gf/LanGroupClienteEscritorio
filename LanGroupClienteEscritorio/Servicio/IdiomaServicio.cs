using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Servicio
{
    internal class IdiomaServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "idiomas");
        private static readonly string TOKEN = ConfigurationManager.AppSettings["TOKEN"];

        public static async Task<(Idioma, int)> ObtenerIdiomaPorId(string idIdioma)
        {
            Idioma idioma = null;
            int codigo = 500;
            using (var httpCliente = new HttpClient())
            {
                try
                {
                    var httpMensaje = new HttpRequestMessage()
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(URL + $"/{idIdioma}")
                    };

                    httpMensaje.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TOKEN);

                    HttpResponseMessage httpResponseMessage = await httpCliente.SendAsync(httpMensaje);

                    if (httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            idioma = JsonConvert.DeserializeObject<Idioma>(json);
                        }

                        codigo = (int)httpResponseMessage.StatusCode;
                    }
                    else
                    {
                        idioma = null;
                        codigo = (int)HttpStatusCode.InternalServerError;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Logger.Log(ex);
                    idioma = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
                catch (JsonException ex)
                {
                    Logger.Log(ex);
                    idioma = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return (idioma, codigo);
        }

        public static async Task<(List<Idioma>, int)> ObtenerIdiomas()
        {
            List<Idioma> idiomas = null;
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

                    httpMensaje.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TOKEN);

                    HttpResponseMessage httpResponseMessage = await httpCliente.SendAsync(httpMensaje);

                    if (httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            idiomas = JsonConvert.DeserializeObject<List<Idioma>>(json);
                        }

                        codigo = (int)httpResponseMessage.StatusCode;
                    }
                    else
                    {
                        idiomas = null;
                        codigo = (int)HttpStatusCode.InternalServerError;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Logger.Log(ex);
                    idiomas = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
                catch (JsonException ex)
                {
                    Logger.Log(ex);
                    idiomas = null;
                    codigo = (int)HttpStatusCode.InternalServerError; codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return (idiomas, codigo);
        }
    }
}
