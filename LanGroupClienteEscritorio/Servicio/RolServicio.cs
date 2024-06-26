﻿using LanGroupClienteEscritorio.Modelo.POJO;
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
using System.Web.Security;

namespace LanGroupClienteEscritorio.Servicio
{
    public class RolServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "roles");
        private static string TOKEN = SesionSingleton.Instance.Token;

        public static async Task<(List<Rol>, int)> ObtenerRoles()
        {
            List<Rol> roles = null;
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
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            roles = JsonConvert.DeserializeObject<List<Rol>>(json);
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
                    roles = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
                catch (JsonException ex)
                {
                    Logger.Log(ex);
                    roles = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return (roles, codigo);
        }

        public static async Task<(Rol, int)> ObtenerRolPorId(string idRol)
        {
            Rol rol = null;
            int codigo = 500;

            using (var httpCliente = new HttpClient())
            {
                try
                {
                    var httpMensaje = new HttpRequestMessage()
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(URL + $"/{idRol}")
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
                            rol = JsonConvert.DeserializeObject<Rol>(json);
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
                    rol = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
                catch (JsonException ex)
                {
                    Logger.Log(ex);
                    rol = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return (rol, codigo);
        }

        private static void GuardarToken(string jwt)
        {
            SesionSingleton.Instance.SetToken(jwt);
        }
    }
}
