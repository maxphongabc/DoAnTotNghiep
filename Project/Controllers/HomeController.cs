
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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using X.PagedList;

namespace Project.Controllers
{
    public class HomeController : Controller
    {

        private readonly ProjectDPContext _context;
        public HomeController(ProjectDPContext context)
        {
            _context = context;
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
        public IActionResult FAQ()
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
        public IActionResult Search(int? size, int? page, string Search)
        {
            var products = from m in _context.products
                           select m;
            ViewBag.searchValue = Search;
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Name");
            ViewBag.page = page;
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "10", Value = "10" });
            items.Add(new SelectListItem { Text = "20", Value = "20" });
            items.Add(new SelectListItem { Text = "25", Value = "25" });
            items.Add(new SelectListItem { Text = "50", Value = "50" });
            items.Add(new SelectListItem { Text = "100", Value = "100" });
            items.Add(new SelectListItem { Text = "200", Value = "200" });
            // 1.1. Giữ trạng thái kích thước trang được chọn trên DropDownList
            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }
            if (!String.IsNullOrEmpty(Search))
            {
                products = products.Where(s => s.Name.Contains(Search));
            }

            ViewBag.size = items; // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            // 2. Nếu page = null thì đặt lại là 1.
            page = page ?? 1; //if (page == null) page = 1;

            // 4. Tạo kích thước trang (pageSize), mặc định là 5.
            int pageSize = (size ?? 5);

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        }

    }
}
