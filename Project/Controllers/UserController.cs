using Common.Data;
using Common.Encryptor;
using Common.Model;
using Common.Service.Interface;
using Common.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
using System;
using System.IO;
using System.Threading.Tasks;

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
        //[HttpGet]
        //public  IActionResult ChangeImage()
        //{
        //    string session = HttpContext.Session.GetString("user");
        //    if (session == null)
        //    {
        //        var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
        //        return Redirect(urlAdmin);
        //    }
        //    UserModel user = JsonConvert.DeserializeObject<UserModel>(session);
        //    if (user != null)
        //    {
        //        return View(user);
        //    }
        //    return View();
        //}
        //[HttpPost]
        //public async Task <IActionResult> ChangeImage(UserModel model)
        //{
        //    string session = HttpContext.Session.GetString("user");
        //    if (session == null)
        //    {
        //        var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
        //        return Redirect(urlAdmin);
        //    }
        //    UserModel user = JsonConvert.DeserializeObject<UserModel>(session);
        //    if (user != null)
        //    {
                
        //        if (model.ImageUpload != null)
        //        {
        //            model.Status = true;
        //            model.RolesId = 2;
        //            string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "img/user");

        //            //if (!string.Equals(model.Avarta, "noimage.png"))
        //            //{
        //            //    string oldImagePath = Path.Combine(uploadsDir, model.Avarta);
        //            //    if (System.IO.File.Exists(oldImagePath))
        //            //    {
        //            //        System.IO.File.Delete(oldImagePath);
        //            //    }
        //            //}
        //            string imageName = Guid.NewGuid().ToString() + "_" + model.ImageUpload.FileName;
        //            string filePath = Path.Combine(uploadsDir, imageName);
        //            FileStream fs = new FileStream(filePath, FileMode.Create);
        //            await model.ImageUpload.CopyToAsync(fs);
        //            fs.Close();
        //            model.Avarta = imageName;
        //        }
        //        _context.Update(model);
        //        await _context.SaveChangesAsync();
        //        TempData["Success"] = "Chỉnh sửa thành công!";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(model);
        //}
    }
}
