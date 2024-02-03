using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal_HotelCasadelSol.Entities
{
    public class UsuariosEnt
    {
        public long UsuarioID { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public byte Edad { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
        public string ConfirmarContraseña { get; set; }
        public byte UsuarioRol { get; set; }
        public long UsuarioError { get; set; }
        public long UsuarioReserva { get; set; }
        public bool Estado { get; set; }
        public string Token { get; set; }
    }
}