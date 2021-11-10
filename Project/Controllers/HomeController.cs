
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
        public HomeController(ProjectDPContext context, IUser iuser, ISendMailService sendMail)
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
            ViewBag.Blog = _context.blogs.Where(b => b.Status == true).ToList();
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
        public async Task<IActionResult> Register(RegisterViewModel member)
        {
            if (ModelState.IsValid)
            {
                if (_iuser.CheckUserName(member.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                    return View(member);
                }
                if (_iuser.CheckEmail(member.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                    return View(member);
                }
                if (_iuser.CheckPhone(member.Phone))
                {
                    ModelState.AddModelError("", "Số điện thoại này đã có người sủ dụng !");
                    return View(member);
                }
                if (member.PassWord == member.ConfirmPassword)
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
                        Subject = "Tạo tài khoản mới thành công",
                        Body = "<p><strong>Xin chào</strong></p>" + "<p>Chúc mừng thành viên mới.</p>" + user.FullName + ""
                    };
                    await sendMailService.SendMail(content);
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Đăng ký thành công!";
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu không trùng");
                    return View(member);
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Index" });
            return Redirect(urlAdmin);
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
                    ModelState.AddModelError("", "Tài khoản và mật khẩu không đúng");
                    return View(member);
                }
                else if (result[0].RolesId == 2)
                {
                    var str = JsonConvert.SerializeObject(result[0]);
                    HttpContext.Session.SetString("user", str);
                    var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Index" });
                    return Redirect(urlAdmin);
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
