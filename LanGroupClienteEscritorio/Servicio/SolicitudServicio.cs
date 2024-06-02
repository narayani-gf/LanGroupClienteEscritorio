using LanGroupClienteEscritorio.Modelo.POJO;
using LanGroupClienteEscritorio.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Servicio
{
    internal class SolicitudServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "solicitudes");

        public static async Task<List<Solicitud>> ObtenerSolicitudes()
        {
            List<Solicitud> solicitudes = null;

            using (var httpCliente = new HttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = await httpCliente.GetAsync(URL);

                    if (httpResponseMessage != null)
                    {
                        if(httpResponseMessage.IsSuccessStatusCode)
                        {
                            solicitudes = new List<Solicitud>();
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            solicitudes = JsonConvert.DeserializeObject<List<Solicitud>>(json);
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    solicitudes = null;
                }catch(JsonException ex)
                {
                    solicitudes = null;
                }
            }

            return solicitudes;
        }

        public static async Task<Solicitud> ObtenerSolicitudPorIdUsuario(string idUsuario)
        {
            Solicitud solicitud = null;

            using (var httpCliente = new HttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponseMessage = await httpCliente.GetAsync(URL + $"?colaboradorid={idUsuario}");

                    if(httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            solicitud = new Solicitud();
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            solicitud = JsonConvert.DeserializeObject<Solicitud>(json);
                        }
                    }
                }
                catch(HttpRequestException ex)
                {
                    solicitud = null;
                }
                catch(JsonException ex)
                {
                    solicitud = null;
                }
            }

            return solicitud;
        }

        public static async Task<Response> CambiarEstadoSolicitud(Solicitud solicitud, string estado)
        {
            Response response = new Response();
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
                catch (JsonException ex)
                {
                    response.Codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return response;
        }

        public static async Task<Response> GuardarSolicitud(Solicitud solicitud)
        {
            Response response = new Response();
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
                catch (JsonException ex)
                {
                    response.Codigo = (int)HttpStatusCode.InternalServerError;
                }
            }

            return response;
        }
    }
}
