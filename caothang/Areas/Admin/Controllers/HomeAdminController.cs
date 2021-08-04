using caothang.Data;
using caothang.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace caothang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : BaseController
    {
        private readonly DPContext _context;
        public HomeAdminController(DPContext context)
        {
            _context = context;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (Request.QueryString.Value.IndexOf("count") < 0)
            {
                ViewBag.ListProduct = _context.products.ToList();
            }
            if (Request.QueryString.Value.IndexOf("countn") < 0)
            {
                ViewBag.ListUser = _context.user.ToList();
            }
            if (Request.QueryString.Value.IndexOf("countnn") < 0)
            {
                ViewBag.ListInvoice = _context.invoice.ToList();
            }
            base.OnActionExecuted(context);
        }
        public IActionResult Index(string count,string countn,string countnn,int total)
        {
            
            if (count == null)
            {
                ViewBag.ListProduct = (from p in _context.products
                                       where p.Name.IndexOf(count) >= 0 && p.Status == true
                                       select p).ToList(); 
            }
            if(countn==null)
            {
                ViewBag.ListUser = (from p in _context.user
                                    where p.FullName.IndexOf(countn) >= 0 && p.Status==true
                                    select p).ToList();
            }
            if(countnn==null)
            {
                ViewBag.ListInvoice = (from p in _context.invoice
                                       where p.Description.IndexOf(countnn) >= 0 && p.Status == true
                                       select p).ToList();
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            var urlAdmin = Url.RouteUrl(new { controller = "User", action = "Login", area = "Admin" });
            return Redirect(urlAdmin);
        }
    }
}
