﻿
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Common.Data;
using Common.Model;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : BaseController
    {
        private readonly ProjectDPContext _context;
        private readonly INotyfService _notyf;
        public HomeAdminController(ProjectDPContext context,INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
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
                ViewBag.ListOrder = _context.order.ToList();
            }
            base.OnActionExecuted(context);
        }
        public IActionResult Index(string count,string countn,string countnn,int total)
        {
            _notyf.Success("Ok nhá");
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
                ViewBag.ListOrder = (from p in _context.order
                                       where p.Description.IndexOf(countnn) >= 0 && p.Status == true
                                       select p).ToList();
            }

  
            ViewBag.SumOrder = _context.order.Where(x=>x.Status==true &&x.TransactStatusId==3).Sum(x=>x.Total);
            //ViewBag.Product = _context.order_Details.Where(x=> x.ProductId ).Sum(x => x.Total);
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Admin");
            var urlAdmin = Url.RouteUrl(new { controller = "Account", action = "LogOut", area = "Admin" });
            return Redirect(urlAdmin);
        }
    }
}
