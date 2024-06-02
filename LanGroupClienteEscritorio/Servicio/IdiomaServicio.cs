using LanGroupClienteEscritorio.Modelo.POJO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Servicio
{
    internal class IdiomaServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "idiomas");
        private static readonly string TOKEN = ConfigurationManager.AppSettings["TOKEN"];

        public static async Task<Idioma> ObtenerIdiomaPorId(string idIdioma)
        {
            Idioma idioma = null;
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
                    }
                    else
                    {
                        idioma = null;
                    }
                }
                catch (HttpRequestException ex)
                {
                    idioma = null;
                }
                catch (JsonException ex)
                {
                    idioma = null;
                }
            }

            return idioma;
        }

        public static async Task<List<Idioma>> ObtenerIdiomas()
        {
            List<Idioma> idiomas = null;

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

                    }
                    else
                    {
                        idiomas = null;
                    }
                }
                catch (HttpRequestException ex)
                {
                    idiomas = null;
                }
                catch (JsonException ex)
                {
                    idiomas = null;
                }
            }

            return idiomas;
        }
    }
}
