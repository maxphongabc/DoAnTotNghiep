using System;
using System.Linq;
using Common.Data;
using Common.Encryptor;
using Common.Model;
using Common.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ProjectDPContext _context;
        private readonly IUser _iuser;

        public AccountController(ProjectDPContext context,IUser _user)
        {
            _context = context;
            _iuser = _user;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserModel member,string username,string password)
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
                }
            }          
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Admin");
            var urlAdmin = Url.RouteUrl(new { controller = "Account", action = "Login", area = "Admin" });
            return Redirect(urlAdmin);
        }
        [HttpGet]
        public IActionResult Profile()
        {
            string session = HttpContext.Session.GetString("Admin");
            UserModel user = JsonConvert.DeserializeObject<UserModel>(session);
            if (user != null)
            {
                var profile = _iuser.ProfileUser(user.Id);
                return View(profile);
            }
            return View();
        }
    }
}
