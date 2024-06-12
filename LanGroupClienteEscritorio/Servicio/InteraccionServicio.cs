using LanGroupClienteEscritorio.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Servicio
{
    public class InteraccionServicio
    {
        private static readonly string URL = string.Concat(Properties.Resources.API_URL, "interacciones");
        private static string TOKEN = SesionSingleton.Instance.Token;

        private static void GuardarToken(string jwt)
        {
            SesionSingleton.Instance.SetToken(jwt);
        }
    }
}
