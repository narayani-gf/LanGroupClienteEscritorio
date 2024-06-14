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
    public class CorreoServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "email/verificacion");
        private static readonly string TOKEN = ConfigurationManager.AppSettings["TOKEN"];

        public static async Task<bool> EnviarCorreo(string to, string subject, string text)
        {
            var requestBody = new
            {
                to = to,
                subject = subject,
                text = text
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {

                try
                {
                    HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(URL, content);

                    return httpResponseMessage.IsSuccessStatusCode;
                }
                catch (HttpRequestException ex)
                {
                    // Manejar excepciones de HTTP
                    Console.WriteLine($"Error HTTP: {ex.Message}");
                    return false;
                }
                catch (JsonException ex)
                {
                    // Manejar excepciones de JSON
                    Console.WriteLine($"Error JSON: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
