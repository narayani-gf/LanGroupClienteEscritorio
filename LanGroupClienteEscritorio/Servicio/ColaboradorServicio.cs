using LanGroupClienteEscritorio.Modelo.POJO;
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

        public static async Task<List<Colaborador>> ObtenerInstructores()
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

        public static async Task<List<Colaborador>> ObtenerColaboradores()
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

        public static async Task<Response> AsignarRolAColaborador(Colaborador colaborador, string nombreRol)
        {
            Response response = new Response();
            using (var httpCliente = new HttpClient())
            {
                try
                {
                    List<Rol> roles = await RolServicio.ObtenerRoles();
                    
                    foreach(Rol rol in roles)
                    {
                        if (rol.Nombre.Equals(nombreRol, StringComparison.OrdinalIgnoreCase))
                        {
                            colaborador.IdRol = rol.Id;
                        }
                    }

                    var httpMensaje = new HttpRequestMessage()
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(colaborador), Encoding.UTF8, "application/json"),
                        Method = HttpMethod.Put,
                        RequestUri = new Uri(URL)
                    };
                  
                    HttpResponseMessage httpResponseMessage = await httpCliente.SendAsync(httpMensaje);

                    if (httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            response.Codigo = (int)HttpStatusCode.OK;
                        }
                    }
                    else
                    {
                        response.Codigo = (int)HttpStatusCode.InternalServerError;
                    }
                }
                catch (HttpRequestException ex)
                {
                    response.Codigo = (int)HttpStatusCode.InternalServerError;
                }
                catch(JsonException e)
                {
                    response.Codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return response;
        }
      
        public static async Task<(Colaborador, int)> ObtenerColaborador(string correo)
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
