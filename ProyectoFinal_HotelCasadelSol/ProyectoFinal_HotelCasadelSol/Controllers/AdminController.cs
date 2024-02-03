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
    [FiltroSesion]
    public class AdminController : Controller
    {
        ErroresModel errorModel = new ErroresModel();

        [HttpGet]
        public ActionResult PerfilAdmin()
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
