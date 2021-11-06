using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;


namespace Project.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    if (HttpContext.Session.GetString("Admin") == null)
        //    {
        //        context.Result = new RedirectToRouteResult(new
        //        RouteValueDictionary(new { controller = "Account", action = "login", Area = "Admin" }));
        //    }
        //    base.OnActionExecuted(context);
        //}
    }
}
