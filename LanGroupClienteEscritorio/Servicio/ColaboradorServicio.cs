using LanGroupClienteEscritorio.Modelo.POJO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Servicio
{
    public class ColaboradorServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "colaboradores");

        public static async Task<List<Colaborador>> obtenerInstructores()
        {
            List<Colaborador> instructores = null;
            string rol="Instructor";
            using (var httpCliente = new HttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = await httpCliente.GetAsync(URL + $"?rol={rol}");

                    if(httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            instructores = new List<Colaborador>();
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            instructores = JsonConvert.DeserializeObject<List<Colaborador>>(json);
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    instructores = null;
                }
                catch (JsonException ex)
                {
                    instructores = null;
                }
            }

            return instructores;
        }

        public static async Task<List<Colaborador>> obtenerColaboradores()
        {
            List<Colaborador> colaboradores = null;
            using (var httpCliente = new HttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = await httpCliente.GetAsync(URL);
                    if(httpResponseMessage != null)
                    {
                        if(httpResponseMessage.IsSuccessStatusCode)
                        {
                            colaboradores = new List<Colaborador>();
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            colaboradores = JsonConvert.DeserializeObject<List<Colaborador>>(json);
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    colaboradores = null;
                }
                catch(JsonException ex)
                {
                    colaboradores = null;
                }
            }

            return colaboradores;
        }
    }
}
