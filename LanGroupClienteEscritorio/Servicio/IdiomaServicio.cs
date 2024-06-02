using LanGroupClienteEscritorio.Modelo.POJO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Servicio
{
    internal class IdiomaServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "idiomas");

        public static async Task<Idioma> ObtenerIdiomaPorId(string idIdioma)
        {
            Idioma idioma = null;
            using (var httpCliente = new HttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = await httpCliente.GetAsync(URL + $"/{idIdioma}");

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
                    HttpResponseMessage httpResponseMessage = await httpCliente.GetAsync(URL);
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
