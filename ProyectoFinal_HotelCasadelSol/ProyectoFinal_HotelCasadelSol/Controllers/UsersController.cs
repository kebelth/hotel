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
    
    public class UsersController : Controller
    {
        ErroresModel errorModel = new ErroresModel();
        UsuariosModel usuarioModel = new UsuariosModel();

        [HttpPost]
        public ActionResult ValidarCorreo(string validarCorreo)
        {
            return Json(usuarioModel.ValidarCorreo(validarCorreo), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [FiltroSesion]
        public ActionResult DisponibilidadHabitaciones()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                RegistarError(ex, ControllerContext);
                return RedirectToAction("Index", "Home");
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
