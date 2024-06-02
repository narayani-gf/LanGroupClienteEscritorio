using LanGroupClienteEscritorio.Modelo.POJO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Servicio
{
    public class RolServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "roles");
        private static readonly string TOKEN = ConfigurationManager.AppSettings["TOKEN"];

        public static async Task<List<Rol>> ObtenerRoles()
        {
            List<Rol> roles = null;

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
                            roles = JsonConvert.DeserializeObject<List<Rol>>(json);
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    roles = null;
                }
                catch (JsonException ex)
                {
                    roles = null;
                }
            }

            return roles;
        }
    }
}
