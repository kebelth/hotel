using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProyectoFinal_HotelCasadelSol.App_Start
{
    public class FiltroSesion : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Session.Count == 0)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Home"},
                    { "action", "IniciarSesion"}
                });
            }
            base.OnActionExecuted(filterContext);
        }
    }
}
//Aún falta usar este filtro en la página que se requiera, como por ejemplo la de reserva