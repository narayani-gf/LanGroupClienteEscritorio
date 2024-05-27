using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanGroupClienteEscritorio.Modelo.POJO
{
        /* =======================================================================
         * == Autor(es): Froylan De Jesus Alvarez Rodriguez                     ==
         * == Fecha de actualización: 27/05/2024                                ==
         * == Descripción:                                                      ==
         * =======================================================================
         */
    internal class Colaborador
    {
        private string idUsuario { get; set; }
        private string usuario { get; set; }
        private string correo { get; set; }
        private string contrasenia { get; set; }
        private string nombre { get; set; }
        private string apellido { get; set; }
        private string descripcion { get; set;}
        private string idRol { get; set; }
        private string icono { get; set; }

        public Colaborador()
        {

        }

        public Colaborador(string idUsuario, string usuario, string correo, string contrasenia, string nombre, string apellido, string descripcion, string idRol, string icono)
        {
            this.idUsuario = idUsuario;
            this.usuario = usuario;
            this.correo = correo;
            this.contrasenia = contrasenia;
            this.nombre = nombre;
            this.apellido = apellido;
            this.descripcion = descripcion;
            this.idRol = idRol;
            this.icono = icono;
        }
    }
}
