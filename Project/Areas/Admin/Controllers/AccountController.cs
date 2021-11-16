using System;
using System.Linq;
using AspNetCoreHero.ToastNotification.Abstractions;
using Common.Data;
using Common.Encryptor;
using Common.Model;
using Common.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ProjectDPContext _context;
        private readonly IUser _iuser;
        private readonly INotyfService _notyf;

        public AccountController(ProjectDPContext context,IUser _user,INotyfService notyf)
        {
            _context = context;
            _iuser = _user;
            _notyf = notyf;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel member)
        {
            if (ModelState.IsValid)
            {
                var result = _context.user.Where(s => s.UserName == member.UserName && s.PassWord == Encryptor.MD5Hash(member.PassWord) && s.Status == true).ToList();
                if (result.Count == 0)
                {
                    _notyf.Error("Tài khoản hoặc mật khẩu không đúng",5);
                    return View(member);
                }
                else if (result[0].RolesId == 1)
                {
                    var str = JsonConvert.SerializeObject(result[0]);
                    HttpContext.Session.SetString("Admin", str);
                    var urlAdmin = Url.RouteUrl(new {ares="Admin", controller = "HomeAdmin", action = "Index"  });
                    return Redirect(urlAdmin);
                    _notyf.Success("Đăng nhập thành công", 5);
                }
                else
                {
                    _notyf.Error("Bạn không có quyền truy cập vào đây",5);
                    return View();
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
