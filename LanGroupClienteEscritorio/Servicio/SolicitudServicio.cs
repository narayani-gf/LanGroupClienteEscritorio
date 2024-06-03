using LanGroupClienteEscritorio.Modelo;
using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Servicio
{
    internal class SolicitudServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "solicitudes");
        private static readonly string TOKEN = ConfigurationManager.AppSettings["TOKEN"];

        public static async Task<(List<Solicitud>, int)> ObtenerSolicitudes()
        {
            List<Solicitud> solicitudes = null;
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
                        if(httpResponseMessage.IsSuccessStatusCode)
                        {
                            solicitudes = new List<Solicitud>();
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            solicitudes = JsonConvert.DeserializeObject<List<Solicitud>>(json);
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
                    solicitudes = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
                catch(JsonException ex)
                {
                    Logger.Log(ex);
                    solicitudes = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return (solicitudes, codigo);
        }

        public static async Task<(Solicitud, int)> ObtenerSolicitudPorIdUsuario(string idUsuario)
        {
            Solicitud solicitud = null;
            int codigo = 500;

            using (var httpCliente = new HttpClient())
            {
                try
                {
                    var httpMensaje = new HttpRequestMessage()
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(URL + $"/?colaboradorid={idUsuario}")
                    };

                    httpMensaje.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TOKEN);

                    HttpResponseMessage httpResponseMessage = await httpCliente.SendAsync(httpMensaje);

                    if(httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            solicitud = new Solicitud();
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            solicitud = JsonConvert.DeserializeObject<Solicitud>(json);
                        }

                        codigo = (int)httpResponseMessage.StatusCode;
                    }
                    else
                    {
                        codigo = (int)HttpStatusCode.InternalServerError;
                    }
                }
                catch(HttpRequestException ex)
                {
                    Logger.Log(ex);
                    solicitud = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
                catch(JsonException ex)
                {
                    Logger.Log(ex);
                    solicitud = null;
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return (solicitud, codigo);
        }

        public static async Task<int> CambiarEstadoSolicitud(Solicitud solicitud, string estado)
        {
            int codigo = 500;
            using (var httpCliente = new HttpClient())
            {
                try
                {
                    solicitud.Estado = estado;
                    var httpMensaje = new HttpRequestMessage()
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(solicitud), Encoding.UTF8, "application/json"),
                        Method = HttpMethod.Put,
                        RequestUri = new Uri(URL)
                    };

                    httpMensaje.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TOKEN);

                    HttpResponseMessage httpResponseMessage = await httpCliente.SendAsync(httpMensaje);

                    if (httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            codigo = (int)HttpStatusCode.OK;
                        }
                    }
                    else
                    {
                        codigo = (int)HttpStatusCode.InternalServerError;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Logger.Log(ex);
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
                catch (JsonException ex)
                {
                    Logger.Log(ex);
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return codigo;
        }

        public static async Task<int> GuardarSolicitud(Solicitud solicitud)
        {
            int codigo = 500;
            using (var httpCliente = new HttpClient())
            {
                try
                {
                    var httpMensaje = new HttpRequestMessage()
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(solicitud), Encoding.UTF8, "application/json"),
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(URL)
                    };

                    httpMensaje.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TOKEN);

                    HttpResponseMessage httpResponseMessage = await httpCliente.SendAsync(httpMensaje);

                    if (httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            codigo = (int)HttpStatusCode.OK;
                        }
                    }
                    else
                    {
                        codigo = (int)HttpStatusCode.InternalServerError;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Logger.Log(ex);
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
                catch (JsonException ex)
                {
                    Logger.Log(ex);
                    codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return codigo;
        }
    }
}
