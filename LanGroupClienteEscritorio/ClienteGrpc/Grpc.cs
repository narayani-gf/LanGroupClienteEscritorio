using Grpc.Net.Client;
using System;
using Google.Protobuf;
using System.Threading.Tasks;
using Grpc.Core;
using System.IO;
using static ArchivosService;

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
                using (var call = Cliente.subirVideo())
                {
                    await call.RequestStream.WriteAsync(new DescargarArchivoResponse
                    {
                        Nombre = nombreArchivo,
                        Archivo = ByteString.CopyFrom(bytesArchivo)
                    });
                    await call.RequestStream.CompleteAsync();
                }
            }
            catch (RpcException e)
            {
                Console.WriteLine($"Error al subir el archivo: {e.GetType().FullName}: {e.Message}");
            }
        }

        public async Task<bool> DescargarConstancia(string nombreArchivo, string destino)
        {
            bool resultado = false;
            try
            {
                using (var call = Cliente.descargarConstancia(new DescargarArchivoRequest
                { 
                    Nombre = nombreArchivo 
                }))
                {
                    await foreach (var response in call.ResponseStream.ReadAllAsync())
                    {
                        FileInfo fileInfo = new FileInfo(nombreArchivo);
                        string nombre = fileInfo.Name;
                        string extension = fileInfo.Extension;

                        File.WriteAllBytes(destino + nombre + extension, response.Archivo.ToByteArray());
                        resultado = true;
                    }
                }
            }
            catch (RpcException e)
            {
                Console.WriteLine($"Error al descargar la constancia: {e.GetType().FullName}: {e.Message}");
                resultado = false;
            }

            return resultado;
        }

        public static async Task<bool> SubirConstancia(string nombreArchivo, byte[] bytesArchivo)
        {
            bool resultado = false;
            try
            {
                using (var call = Cliente.subirConstancia())
                {
                    await call.RequestStream.WriteAsync(new DescargarArchivoResponse
                    {
                        Nombre = nombreArchivo,
                        Archivo = ByteString.CopyFrom(bytesArchivo)
                    });
                    await call.RequestStream.CompleteAsync();
                    resultado = true;
                }
            }
            catch (RpcException e)
            {
                Console.WriteLine($"Error al subir la constancia: {e.GetType().FullName}: {e.Message}");
                resultado= false;
            }

            return resultado;
        }

    }
}
