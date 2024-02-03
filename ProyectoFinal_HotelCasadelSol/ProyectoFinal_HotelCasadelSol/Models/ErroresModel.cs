using ProyectoFinal_HotelCasadelSol.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Json;

namespace ProyectoFinal_HotelCasadelSol.Models
{
    public class ErroresModel
    {
        public void RegistrarError(ErroresEnt error)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(error);
                string url = "https://localhost:44348/api/RegistrarError";
                HttpResponseMessage respuesta = client.PostAsync(url, body).GetAwaiter().GetResult();
            }
        }
    }
}