using Common.Data;
using Common.Model;
using Common.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        private readonly ProjectDPContext _context;
        private readonly IUser _iuser;
        public UserController(ProjectDPContext context,IUser iuser)
        {
            _iuser = iuser;
            _context = context;
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
    }
}
