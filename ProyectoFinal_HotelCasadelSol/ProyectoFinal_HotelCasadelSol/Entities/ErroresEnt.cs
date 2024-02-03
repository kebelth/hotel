using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal_HotelCasadelSol.Entities
{
    public class ErroresEnt
    {
        public long ErrorID { get; set; }
        public string Mensaje{ get; set; }
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string Origen { get; set; } 
    }
}