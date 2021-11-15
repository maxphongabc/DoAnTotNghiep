
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Common.Data;
using Common.Model;
using System.Collections.Generic;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : BaseController
    {
        private readonly ProjectDPContext _context;
        public HomeAdminController(ProjectDPContext context)
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
                ViewBag.ListOrder = _context.order.ToList();
            }
            base.OnActionExecuted(context);
        }
        public IActionResult Index(string count, string countn, string countnn, int total)
        {

            if (count == null)
            {
                ViewBag.ListProduct = (from p in _context.products
                                       where p.Name.IndexOf(count) >= 0 && p.Status == true
                                       select p).ToList();
            }
            if (countn == null)
            {
                ViewBag.ListUser = (from p in _context.user
                                    where p.FullName.IndexOf(countn) >= 0 && p.Status == true
                                    select p).ToList();
            }
            if (countnn == null)
            {
                ViewBag.ListOrder = (from p in _context.order
                                     where p.Description.IndexOf(countnn) >= 0 && p.Status == true
                                     select p).ToList();
            }


            ViewBag.SumOrder = _context.order.Where(x => x.Status == true).Sum(x => x.Total);
            var totalorder1 = _context.order.Where(x => x.Status == true && x.TransactStatusId == 3 && x.CreatedOn.Value.Month == 1 && x.CreatedOn.Value.Year == 2021).Sum(x => x.Total);
            var totalorder2 = _context.order.Where(x => x.Status == true && x.TransactStatusId == 3 && x.CreatedOn.Value.Month == 2 && x.CreatedOn.Value.Year == 2021).Sum(x => x.Total);
            var totalorder3 = _context.order.Where(x => x.Status == true && x.TransactStatusId == 3 && x.CreatedOn.Value.Month == 3 && x.CreatedOn.Value.Year == 2021).Sum(x => x.Total);
            var totalorder4 = _context.order.Where(x => x.Status == true && x.TransactStatusId == 3 && x.CreatedOn.Value.Month == 4 && x.CreatedOn.Value.Year == 2021).Sum(x => x.Total);
            var totalorder5 = _context.order.Where(x => x.Status == true && x.TransactStatusId == 3 && x.CreatedOn.Value.Month == 5 && x.CreatedOn.Value.Year == 2021).Sum(x => x.Total);
            var totalorder6 = _context.order.Where(x => x.Status == true && x.TransactStatusId == 3 && x.CreatedOn.Value.Month == 6 && x.CreatedOn.Value.Year == 2021).Sum(x => x.Total);
            var totalorder7 = _context.order.Where(x => x.Status == true && x.TransactStatusId == 3 && x.CreatedOn.Value.Month == 7 && x.CreatedOn.Value.Year == 2021).Sum(x => x.Total);
            var totalorder8 = _context.order.Where(x => x.Status == true && x.TransactStatusId == 3 && x.CreatedOn.Value.Month == 8 && x.CreatedOn.Value.Year == 2021).Sum(x => x.Total);
            var totalorder9 = _context.order.Where(x => x.Status == true && x.TransactStatusId == 3 && x.CreatedOn.Value.Month == 9 && x.CreatedOn.Value.Year == 2021).Sum(x => x.Total);
            var totalorder10 = _context.order.Where(x => x.Status == true && x.TransactStatusId == 3 && x.CreatedOn.Value.Month == 10 && x.CreatedOn.Value.Year == 2021).Sum(x => x.Total);
            var totalorder11 = _context.order.Where(x => x.Status == true && x.TransactStatusId == 3 && x.CreatedOn.Value.Month == 11 && x.CreatedOn.Value.Year == 2021).Sum(x => x.Total);
            var totalorder12 = _context.order.Where(x => x.Status == true && x.TransactStatusId == 3 && x.CreatedOn.Value.Month == 12 && x.CreatedOn.Value.Year == 2021).Sum(x => x.Total);
            List<object> totallist = new List<object>();
            totallist.Add(totalorder1);
            totallist.Add(totalorder2);
            totallist.Add(totalorder3);
            totallist.Add(totalorder4);
            totallist.Add(totalorder5);
            totallist.Add(totalorder6);
            totallist.Add(totalorder7);
            totallist.Add(totalorder8);
            totallist.Add(totalorder9);
            totallist.Add(totalorder10);
            totallist.Add(totalorder11);
            totallist.Add(totalorder12);
            ViewBag.Total = totallist;
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
