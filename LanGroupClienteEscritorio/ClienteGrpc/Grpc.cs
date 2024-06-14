using Grpc.Net.Client;
using System;
using Google.Protobuf;
using System.Threading.Tasks;
using Grpc.Core;
using System.IO;
using static ArchivosService;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace LanGroupClienteEscritorio.ClienteGrpc
{
    internal class Grpc
    {
        public static readonly GrpcChannel Canal = GrpcChannel.ForAddress(Properties.Resources.GRPC_URL);
        public static ArchivosServiceClient Cliente = new ArchivosServiceClient(Canal);

        public Grpc()
        {
            
        }

        public async Task DescargarVideo(string nombreArchivo)
        {
            try
            {
                using (var llamada = Cliente.descargarVideo(new DescargarArchivoRequest
                { 
                    Nombre = nombreArchivo 
                }))
                {
                    var writeStream = new MemoryStream();
                    await foreach (var response in llamada.ResponseStream.ReadAllAsync())
                    {
                        File.WriteAllBytes(nombreArchivo, response.Archivo.ToByteArray());
                    }
                }
            }
            catch (RpcException e)
            {
                Console.WriteLine($"Error al descargar el archivo: {e.GetType().FullName}: {e.Message}");
            }
        }

        public async Task SubirVideo(string nombreArchivo, byte[] bytesArchivo)
        {
            try
            {
                using (var llamada = Cliente.subirVideo())
                {
                    await llamada.RequestStream.WriteAsync(new DescargarArchivoResponse
                    {
                        Nombre = nombreArchivo,
                        Archivo = ByteString.CopyFrom(bytesArchivo)
                    });
                    await llamada.RequestStream.CompleteAsync();
                }
            }
            catch (RpcException e)
            {
                Console.WriteLine($"Error al subir el archivo: {e.GetType().FullName}: {e.Message}");
            }
        }

        public async Task<MemoryStream> DescargarConstancia(string nombreArchivo, string destino)
        {
            var writeStream = new MemoryStream();
            try
            {
                using var llamada = Cliente.descargarConstancia(new DescargarArchivoRequest
                {
                    Nombre = nombreArchivo
                });

                Console.WriteLine($"Recibiendo el archivo: {nombreArchivo}");

                var ruta = Path.Combine(destino, nombreArchivo);
                using var fileStream = new FileStream(ruta, FileMode.Create);
                
                await foreach (var response in llamada.ResponseStream.ReadAllAsync())
                {
                    if(response.Archivo != null)
                    {
                        var archivo = response.Archivo.Memory;
                        await fileStream.WriteAsync(archivo.ToArray(), 0, archivo.Length);
                    }
                }

                Console.WriteLine($"Archivo guardado en: {ruta}");
            }
            catch (RpcException e)
            {
                Console.WriteLine($"Error al descargar la constancia: {e.GetType().FullName}: {e.Message}");
                writeStream = null;
            }

            return writeStream;
        }

        public async Task<bool> SubirConstancia(string nombreArchivo, string rutaArchivo)
        {
            bool resultado = false;
            try
            {
                using (var llamada = Cliente.subirConstancia())
                {
                    using (var fileStream = File.OpenRead(rutaArchivo))
                    {
                        var buffer = new byte[1024];
                        int bytesRead;
                        while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await llamada.RequestStream.WriteAsync(new DescargarArchivoResponse
                            {
                                Nombre = nombreArchivo,
                                Archivo = ByteString.CopyFrom(buffer, 0, bytesRead)
                            });
                        }
                    }
                    await llamada.RequestStream.CompleteAsync();
                    resultado = true;
                }
            }
            catch (RpcException e)
            {
                Console.WriteLine($"Error al subir la constancia: {e.GetType().FullName}: {e.Message}");
                resultado = false;
            }

            return resultado;
        }

    }
}
