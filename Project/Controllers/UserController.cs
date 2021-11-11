using Common.Data;
using Common.Encryptor;
using Common.Model;
using Common.Service.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        private readonly ProjectDPContext _context;
        private readonly IUser _iuser;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserController(ProjectDPContext context,IUser iuser, IWebHostEnvironment webHostEnvironment)
        {
            _iuser = iuser;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            string session = HttpContext.Session.GetString("user");
            if (session == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
                return Redirect(urlAdmin);
            }
            UserModel user = JsonConvert.DeserializeObject<UserModel>(session);
            if (user != null)
            {
                var profile = _iuser.ProfileUser(user.Id);
                return View(profile);
            }
            return View();
        }
        [HttpGet]
        public IActionResult DMK()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DMK(RegisterViewModel model)
        {
            string session = HttpContext.Session.GetString("user");
            if (session == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
                return Redirect(urlAdmin);
            }
            UserModel user = JsonConvert.DeserializeObject<UserModel>(session);
            if (user != null)
            {
                if (Encryptor.MD5Hash(model.PassWord) == user.PassWord)
                {

                    string pass = Encryptor.MD5Hash(model.ConfirmPassword);
                    user.PassWord = pass;
                    _context.Update(user);
                    _context.SaveChanges();
                    TempData["Success"] = "Chỉnh sửa thành công!";
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ModelState.AddModelError("", "Mật khẩu cũ không đúng");
                return View(model);
            }           
            return View();
        }
       
    }
}
