using System.Configuration;
using System.IO;
using System;

namespace LanGroupClienteEscritorio.Utils
{
    public static class Logger
    {
        private static string logPath;

        static Logger()
        {
            // Obtiene la ruta relativa desde el app.config
            var relativePath = ConfigurationManager.AppSettings["logPath"];

            // Construye la ruta completa usando el directorio de inicio de la aplicación
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            logPath = Path.Combine(basePath, relativePath);
        }

        public static void Log(Exception ex)
        {
            try
            {
                // Crea el directorio si no existe
                var logDirectory = Path.GetDirectoryName(logPath);
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                // Escribe la excepción en el archivo log.txt
                using (StreamWriter writer = new StreamWriter(logPath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {ex.Message}");
                    writer.WriteLine(ex.StackTrace);
                }
            }
            catch (Exception logEx)
            {
                // Manejo de excepciones del logger, si es necesario
                Console.WriteLine($"Failed to log exception: {logEx.Message}");
            }
        }
    }
}