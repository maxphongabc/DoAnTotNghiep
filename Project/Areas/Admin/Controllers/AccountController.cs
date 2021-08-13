
using System;
using System.Linq;
using Common.Data;
using Common.Encryptor;
using Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly DPContext _context;

        public AccountController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel member)
        {
            if (member.UserName != null && member.PassWord != null)
            {
                member.PassWord = Encryptor.MD5Hash(member.PassWord);
                var r = _context.user.Where(m => m.UserName == member.UserName && m.PassWord == (member.PassWord)).ToList();
                if (r.Count == 0)
                {
                    return View("Login");
                }
                else
                {
                    if (r[0].RolesId == 1)
                    {
                        var str = JsonConvert.SerializeObject(r[0]);
                        HttpContext.Session.SetString("Admin", str);

                        var urlAdmin = Url.RouteUrl(new { controller = "HomeAdmin", action = "Index", area = "Admin" });
                        return Redirect(urlAdmin);
                    }
                    else
                    {
                        var str = JsonConvert.SerializeObject(r[0]);
                        HttpContext.Session.SetString("user", str);
                        var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Index", area = "" });
                        return Redirect(urlAdmin);

                    }
                }
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserModel member)
        {
            member = new UserModel()
            {
                Address = member.Address,
                Email=member.Email,
                DateOfBirth=member.DateOfBirth,
                Phone=member.Phone,
                FullName=member.FullName,
                UserName=member.UserName,
                PassWord=Encryptor.MD5Hash(member.PassWord),
                RolesId=2,
                Status=true,
                CreatedOn=DateTime.Now
            };
            _context.Add(member);
            _context.SaveChanges();
            var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Index", area = "" });
            return Redirect(urlAdmin);
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}
