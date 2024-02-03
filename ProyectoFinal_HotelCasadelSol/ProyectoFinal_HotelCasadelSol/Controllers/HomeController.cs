using ProyectoFinal_HotelCasadelSol.App_Start;
using ProyectoFinal_HotelCasadelSol.Entities;
using ProyectoFinal_HotelCasadelSol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal_HotelCasadelSol.Controllers
{
    public class HomeController : Controller
    {

        UsuariosModel usuarioModel = new UsuariosModel();
        ErroresModel errorModel = new ErroresModel();
        
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                RegistarError(ex, ControllerContext);
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult About()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                RegistarError(ex, ControllerContext);
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Contact()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                RegistarError(ex, ControllerContext);
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult IniciarSesion()
        {
            try
            {
                Session.Clear(); 
                return View();
            }
            catch (Exception ex)
            {
                RegistarError(ex, ControllerContext);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult IniciarSesion(UsuariosEnt usuario)
        {
            try
            {
                var resultado = usuarioModel.ValidarUsuario(usuario);

                if(resultado != null)
                {
                    Session["Correo"] = resultado.Correo;
                    Session["Consecutivo"] = resultado.UsuarioID;
                    Session["Nombre"] = resultado.Nombre;
                    Session["Rol"] = resultado.UsuarioRol;
                    Session["Token"] = resultado.Token;
                    return View("Index");
                } 
                else
                {
                    ViewBag.mensaje = "Usuario o contraseña incorrectos, por favor intente de nuevo";
                    return View("IniciarSesion");
                }

            } 
            catch (Exception ex)
            {
                RegistarError(ex, ControllerContext);
                return View("IniciarSesion");
            }
        }

        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                RegistarError(ex, ControllerContext);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(UsuariosEnt usuario)
        {
            try
            {
                if (usuarioModel.RegistrarUsuario(usuario) > 0)
                    return View("IniciarSesion");
                else
                {
                    ViewBag.mensaje = "Ocurrió un error al registrar tu cuenta, intenta de nuevo.";
                    return View("RegistrarUsuario");
                }

            }
            catch (Exception ex)
            {
                RegistarError(ex, ControllerContext);
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult RecuperarCuenta()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                RegistarError(ex, ControllerContext);
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult RecuperarCuenta(UsuariosEnt usuario)
        {
           try
            {
                usuarioModel.RecuperarCuenta(usuario);
                return View("IniciarSesion");
            }
            catch (Exception ex)
            {
                RegistarError(ex, ControllerContext);
                return View("Index");
            }
            
        }

        [HttpGet]
        public ActionResult Habitaciones()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                RegistarError(ex, ControllerContext);
                return View();
            }
        }

        [HttpGet]
        [FiltroSesion]
        public ActionResult CerrarSesion()
        {
            try
            {
                Session.Clear();
                return View("Index");
            }
            catch (Exception ex)
            {
                RegistarError(ex, ControllerContext);
                return View("Index");
            }
        }

        private void RegistarError(Exception ex, ControllerContext ubicacion)
        {
            ErroresEnt registro = new ErroresEnt();
            registro.Origen = ubicacion.RouteData.Values["controller"].ToString() + "-" + ubicacion.RouteData.Values["action"].ToString();
            registro.Mensaje = ex.Message;
            registro.Codigo = ex.HResult;
            registro.Fecha = System.DateTime.Now;
            errorModel.RegistrarError(registro);
        }
    }
}