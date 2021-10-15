using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    if(HttpContext.Session.GetString("Admin")==null)
        //    {
        //        context.Result = new RedirectToRouteResult(new
        //        RouteValueDictionary(new { controller = "Account", action = "login", Area = "Admin" }));
        //    }
        //    base.OnActionExecuted(context);
        //}
        protected void SetAlert(string message,string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
            if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
        }
    }
}
