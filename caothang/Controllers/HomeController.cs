using caothang.Areas.Admin.Encryptor;
using caothang.Areas.Admin.Models;
using caothang.Data;
using caothang.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace caothang.Controllers
{
    public class HomeController : Controller
    {

        private readonly DPContext _context;
        public HomeController(DPContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.ListSPPlayStation = _context.products.Where(sp => sp.Status == true && sp.CategoryId == 1).OrderBy(sp => sp.Id).ToList();
            ViewBag.ListSPXbox = _context.products.Where(sp => sp.Status == true && sp.CategoryId == 2).OrderBy(sp => sp.Id).ToList();
            ViewBag.ListSPNintendo = _context.products.Where(sp => sp.Status == true && sp.CategoryId == 3).OrderBy(sp => sp.Id).ToList();
            ViewBag.All = _context.products.Where(sp => sp.Status == true).ToList();
            return View();
        }
        public ProductModel GetProduct(int id)
        {
            var product = _context.products.Find(id);
            return product;
        }
        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel member)
        {
            //Encryptor.Encryptor.MD5Hash(member.MatKhau);
            if (member.UserName != null && member.PassWord != null)
            {
                member.PassWord = Encryptor.Decrypt(member.PassWord);
                var r = _context.user.Where(m => m.UserName == member.UserName && m.PassWord == (member.PassWord)).ToList();
                if (r.Count == 0)
                {
                    return View("Login");
                }
                else
                {
                    if (r[0].RolesId == 1)
                    {
                        var str = JsonConvert.SerializeObject(member);
                        HttpContext.Session.SetString("user", str);

                        var urlAdmin = Url.RouteUrl(new { controller = "HomeAdmin", action = "Index", area = "Admin" });
                        return Redirect(urlAdmin);
                    }
                    else
                    {
                        var str = JsonConvert.SerializeObject(member);
                        HttpContext.Session.SetString("user", str);

                        var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Index" });
                        return Redirect(urlAdmin);

                    }
                }
            }
            return View();
        }
    }
}
