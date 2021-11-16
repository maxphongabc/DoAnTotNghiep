using AspNetCoreHero.ToastNotification.Abstractions;
using Common.Data;
using Common.Encryptor;
using Common.Model;
using Common.Service.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        private readonly ProjectDPContext _context;
        private readonly IUser _iuser;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly INotyfService _notyf;
        public UserController(ProjectDPContext context,IUser iuser, IWebHostEnvironment webHostEnvironment,INotyfService notyf)
        {
            _iuser = iuser;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _notyf = notyf;
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
        public async Task<IActionResult> DMK(RegisterViewModel model)
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
                    await _context.SaveChangesAsync();
                    _notyf.Success("Đổi mật khẩu thành công", 5);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                _notyf.Error("Mật khẩu không đúng", 5);
                return View(model);
            }           
            return View();
        }
        [HttpGet]
        public IActionResult EditMember()
        {
            string session = HttpContext.Session.GetString("user");
            if (session == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
                return Redirect(urlAdmin);
            }
            UserModel user = JsonConvert.DeserializeObject<UserModel>(session);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditMember(UserModel member)
        {
            string session = HttpContext.Session.GetString("user");
            if (session == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
                return Redirect(urlAdmin);
            }
            UserModel user = JsonConvert.DeserializeObject<UserModel>(session);
            var email = await _context.user.Where(x => x.Id != user.Id).FirstOrDefaultAsync(x => x.Email == member.Email);
            var phone = await _context.user.Where(x => x.Id != user.Id).FirstOrDefaultAsync(x => x.Phone == member.Phone);
            if (user!=null)
            {
                if(email!=null)
                {
                    _notyf.Error("Email này đã có người sử dụng", 5);
                    return View(member);
                }   
                else if(phone!=null)
                {
                    _notyf.Error("SĐT này đã có người sử dụng", 5);
                    return View(member);
                }
                
                user.Phone = member.Phone;
                user.Address = member.Address;
                user.Email = member.Email;
                if (member.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "img/user");
                    string imageName = Guid.NewGuid().ToString() + "_" + member.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await member.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    member.Avarta = imageName;
                }
                user.Avarta = member.Avarta;
                _context.Update(user);
               await _context.SaveChangesAsync();
                _notyf.Success("Chỉnh sửa thành công", 3);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }
       
    }
}
