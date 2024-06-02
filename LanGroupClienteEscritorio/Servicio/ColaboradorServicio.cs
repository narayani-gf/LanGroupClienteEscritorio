using LanGroupClienteEscritorio.Modelo;
using Newtonsoft.Json;
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
    public class ColaboradorServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "colaboradores");
        private static readonly string TOKEN = ConfigurationManager.AppSettings["TOKEN"];

        public static async Task<(Colaborador, int)> RecuperarColaborador(string correo)
        {
            Colaborador colaborador = new Colaborador();
            int codigo = 500;

            using (var httpCliente = new HttpClient())
            {
                try
                {
                    var httpMensaje = new HttpRequestMessage()
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(URL + "/" + correo)
                    };

                    httpMensaje.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TOKEN);

                    HttpResponseMessage httpResponseMessage = await httpCliente.SendAsync(httpMensaje);

                    if (httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            colaborador = JsonConvert.DeserializeObject<Colaborador>(json);
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

            return (colaborador, codigo);
        }
    }
}
