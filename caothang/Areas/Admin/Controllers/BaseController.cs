using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(HttpContext.Session.GetString("Admin")==null)
            {
                context.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Login", action = "login", Area = "Admin" }));
            }
            base.OnActionExecuted(context);
        }
    }
}
