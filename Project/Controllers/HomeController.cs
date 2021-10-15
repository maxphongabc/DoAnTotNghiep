
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Common.Data;
using Common.Model;
using System;
using Common.Encryptor;
using Project.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Project.Controllers
{
    public class HomeController : Controller
    {

        private readonly ProjectDPContext _context;
        public HomeController(ProjectDPContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            //lay 4 san pham moi nhat
            ViewBag.ListNewProduct = _context.products.OrderByDescending(x => x.CreatedOn).Take(4).ToList();
            //lay list san pham playstation
            ViewBag.ListSPPlayStation = _context.products.Where(sp => sp.Status == true && sp.CategoryId == 1).OrderBy(sp => sp.Id).ToList();
            //lay list sanpham xbox
            ViewBag.ListSPXbox = _context.products.Where(sp => sp.Status == true && sp.CategoryId == 2).OrderBy(sp => sp.Id).ToList();
            //lay list sanpham nintendo
            ViewBag.ListSPNintendo = _context.products.Where(sp => sp.Status == true && sp.CategoryId == 3).OrderBy(sp => sp.Id).ToList();
            //lay tat ca san pham co trong kho
            ViewBag.All = _context.products.Where(sp => sp.Status == true).ToList();
            
            return View();
        }      
        public ProductModel GetProduct(int id)
        {
            var product = _context.products.Find(id);
            return product;
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel member)
        {
            if(ModelState.IsValid)
            {
                
                if (CheckUserName(member.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (CheckEmail(member.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else if (member.PassWord == member.ConfirmPassword)
                {
                    var user = new UserModel()             
                    {
                        Address = member.Address,
                        Email = member.Email,
                        Phone = member.Phone,
                        FullName = member.FullName,
                        UserName = member.UserName,
                        PassWord = Encryptor.MD5Hash(member.PassWord),
                        RolesId = 2,
                        Status = true,
                        CreatedOn = DateTime.Now
                    };
                    var result = Insert(user);
                    if(result>0)
                    {
                        ViewBag.Success = "Đăng Ký thành công";
                        var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Index", area = "" });
                        return Redirect(urlAdmin);
                    }
                    else
                    {
                        ModelState.AddModelError("", " Đăng ký không thành công");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu không trùng");
                }
               
            }
            return View("Register");
        }
        public int Insert(UserModel user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
        public bool CheckUserName(string userName)
        {
            return _context.user.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return _context.user.Count(x => x.Email == email) > 0;
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
        public IActionResult Error()
        {
            return View();
        }
    }
}
