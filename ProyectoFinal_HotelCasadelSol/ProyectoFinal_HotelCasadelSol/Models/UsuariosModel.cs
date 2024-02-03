using ProyectoFinal_HotelCasadelSol.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace ProyectoFinal_HotelCasadelSol.Models
{
    public class UsuariosModel
    {
        public UsuariosEnt ValidarUsuario(UsuariosEnt usuario)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(usuario);
                string url = "https://localhost:44348/api/ValidarUsuario";
                HttpResponseMessage respuesta = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<UsuariosEnt>().Result;

                return null;
            }
        }
        
        public string ValidarCorreo(string validarCorreo)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44348/api/ValidarCorreo?validarCorreo=" + validarCorreo;
                HttpResponseMessage respuesta = client.GetAsync(url).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<string>().Result;

                return "ERROR";
            }
        }

        public int RegistrarUsuario(UsuariosEnt usuario)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(usuario);
                string url = "https://localhost:44348/api/RegistrarUsuario";
                HttpResponseMessage respuesta = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }   
        }

        public void RecuperarCuenta(UsuariosEnt usuario)
        {
            using (var client = new HttpClient()) 
            { 
                JsonContent body = JsonContent.Create(usuario);
                string url = "https://localhost:44348/api/RecuperarCuenta";
                HttpResponseMessage respuesta = client.PostAsync(url, body).GetAwaiter().GetResult();
            }
        }
    }
}