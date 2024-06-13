using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Servicio
{
    public class ColaboradorServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "colaboradores");
        private static string TOKEN = SesionSingleton.Instance.Token;

        public static async Task<(List<Colaborador>, int)> ObtenerInstructores()
        {
            List<Colaborador> instructores = null;
            int codigo = 500;
            string rol="Instructor";
            using (var httpCliente = new HttpClient())
            {
                try
                {
                    var httpMensaje = new HttpRequestMessage()
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(URL + $"?rol={rol}")
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
                            instructores = new List<Colaborador>();
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            instructores = JsonConvert.DeserializeObject<List<Colaborador>>(json);
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
                    Logger.Log(ex);
                    instructores = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
                catch (JsonException ex)
                {
                    Logger.Log(ex);
                    instructores = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return (instructores, codigo);
        }

        public static async Task<(List<Colaborador>, int)> ObtenerColaboradores()
        {
            List<Colaborador> colaboradores = null;
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
                            colaboradores = new List<Colaborador>();
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            colaboradores = JsonConvert.DeserializeObject<List<Colaborador>>(json);
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
                    Logger.Log(ex);
                    colaboradores = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
                catch(JsonException ex)
                {
                    Logger.Log(ex);
                    colaboradores = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return (colaboradores, codigo);
        }

        public static async Task<int> AsignarRolAColaborador(Colaborador colaborador, string nombreRol)
        {
            Console.WriteLine(colaborador.Id);
            int codigo = 500;
            using (var httpCliente = new HttpClient())
            {
                try
                {
                    (List<Rol> roles, int codigoRoles) = await RolServicio.ObtenerRoles();

                    if(roles != null)
                    {
                        foreach (Rol rol in roles)
                        {
                            if (rol.Nombre.Equals(nombreRol, StringComparison.OrdinalIgnoreCase))
                            {
                                colaborador.IdRol = rol.Id;
                                break;
                            }
                        }

                        var httpMensaje = new HttpRequestMessage()
                        {
                            Content = new StringContent(JsonConvert.SerializeObject(new ColaboradorRequest { RolId = colaborador.IdRol}), Encoding.UTF8, "application/json"),
                            Method = HttpMethod.Put,
                            RequestUri = new Uri(URL + $"/{colaborador.Id}")
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
                                codigo = (int)httpResponseMessage.StatusCode;
                            }
                        }
                        else
                        {
                            codigo = (int)HttpStatusCode.InternalServerError;
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    Logger.Log(ex);
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
                catch(JsonException ex)
                {
                    Logger.Log(ex);
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return codigo;
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

        private static void GuardarToken(string jwt)
        {
            SesionSingleton.Instance.SetToken(jwt);
        }
    }
}