
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Common.Data;
using Common.Model;
using System;
using Common.Encryptor;
using Project.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using X.PagedList;
using Common.ViewModel;
using Common.Service.Interface;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUser _iuser;
        private readonly ISendMailService sendMailService;
        private readonly ProjectDPContext _context;
        public HomeController(ProjectDPContext context,IUser iuser, ISendMailService sendMail)
        {
            _context = context;
            _iuser = iuser;
            sendMailService = sendMail;
        }
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
            ViewBag.Blog = _context.blogs.Where(b => b.Status == true).Take(4).ToList();
            return View();
        }      
        public ProductModel GetProduct(int id)
        {
            var product = _context.products.Find(id);
            return product;
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(FeedBackModel fb)
        {
            if (ModelState.IsValid)
            {
                fb.Status = true;
                _context.feedbacks.Add(fb);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult FAQ()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel member)
        {
            if(ModelState.IsValid)
            {
                
                if (_iuser.CheckUserName(member.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (_iuser.CheckEmail(member.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else if (_iuser.CheckPhone(member.Phone))
                {
                    ModelState.AddModelError("", "Số điện thoại này đã có người sủ dụng !");
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
                        Avarta = "user-2.png",
                        CreatedOn = DateTime.Now
                    };            
                        MailContent content = new MailContent
                        {
                            To = user.Email,
                            Subject = "Đơn hàng mới" ,
                            Body = "<p><strong>Xin chào</strong></p>" + "<p>Cảm ơn bạn đã quan tâm sản phẩm của chúng tôi.Đơn hàng của bạn sẽ được xử lý ngay.</p>"
                        };
                        await sendMailService.SendMail(content);
                        _context.Add(user);
                        await _context.SaveChangesAsync();
                        TempData["Success"] = "Đăng ký thành công!";
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu không trùng");
                }
            return View("Index");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Index"});
            return Redirect(urlAdmin);
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
                    if (r[0].RolesId == 2)
                    {
                        var str = JsonConvert.SerializeObject(r[0]);
                        HttpContext.Session.SetString("user", str);
                        var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Index"});
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
