using Grpc.Net.Client;
using System;
using Google.Protobuf;
using System.Threading.Tasks;
using Grpc.Core;
using System.IO;
using static ArchivosService.ArchivosService;

namespace LanGroupClienteEscritorio.proto
{
    internal class ClienteGrpc
    {
        private readonly ArchivosServiceClient Cliente;
        private GrpcChannel Canal;
        public ClienteGrpc(string url)
        {
            Canal = GrpcChannel.ForAddress(url);
            Cliente = new ArchivosServiceClient(Canal);
        }

        public async Task DescargarVideo(string nombreArchivo)
        {
            try
            {
                using (var llamada = Cliente.descargarVideo(new ArchivosService.DescargarArchivoRequest { Nombre = nombreArchivo }))
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
                Console.WriteLine($"Error al descargar el archivo: {e}");
            }
            finally
            {
                Canal.ShutdownAsync().Wait();
            }
        }

        public async Task SubirVideo(string nombreArchivo, byte[] bytesArchivo)
        {
            try
            {
                using (var call = Cliente.subirVideo())
                {
                    await call.RequestStream.WriteAsync(new ArchivosService.DescargarArchivoResponse
                    {
                        Nombre = nombreArchivo,
                        Archivo = ByteString.CopyFrom(bytesArchivo)
                    });
                    await call.RequestStream.CompleteAsync();
                }
            }
            catch (RpcException e)
            {
                Console.WriteLine($"Error al subir el archivo: {e}");
            }
            finally
            {
                Canal.ShutdownAsync().Wait();
            }
        }

        public async Task DescargarConstancia(string nombreArchivo, string destino)
        {
            try
            {
                using (var call = Cliente.descargarConstancia(new ArchivosService.DescargarArchivoRequest { Nombre = nombreArchivo }))
                {
                    await foreach (var response in call.ResponseStream.ReadAllAsync())
                    {
                        FileInfo fileInfo = new FileInfo(nombreArchivo);
                        string nombre = fileInfo.Name;
                        string extension = fileInfo.Extension;

                        File.WriteAllBytes(destino + nombre + extension, response.Archivo.ToByteArray());
                    }
                }
            }
            catch (RpcException e)
            {
                Console.WriteLine($"Error al descargar el archivo: {e}");
            }
            finally
            {
                Canal.ShutdownAsync().Wait();
            }
        }

        public async Task SubirConstancia(string nombreArchivo, byte[] bytesArchivo)
        {
            try
            {
                using (var call = Cliente.subirConstancia())
                {
                    await call.RequestStream.WriteAsync(new ArchivosService.DescargarArchivoResponse
                    {
                        Nombre = nombreArchivo,
                        Archivo = ByteString.CopyFrom(bytesArchivo)
                    });
                    await call.RequestStream.CompleteAsync();
                }
            }
            catch (RpcException e)
            {
                Console.WriteLine($"Error al subir el archivo: {e}");
            }
            finally
            {
                Canal.ShutdownAsync().Wait();
            }
        }

    }
}
