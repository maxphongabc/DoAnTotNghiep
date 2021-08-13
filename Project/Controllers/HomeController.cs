
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Common.Data;
using Common.Model;
using System.Collections.Generic;
using System;
using Common.Encryptor;
using Project.Models;

namespace Project.Controllers
{
    public class HomeController : Controller
    {

        private readonly DPContext _context;
        public HomeController(DPContext context)
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
        public ActionResult Category(int id,int page =1,int pageSize=1)
        {
            int totalRecord = 0;
            var model = ListByCateId(id, ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        public ProductModel GetProduct(int id)
        {
            var product = _context.products.Find(id);
            return product;
        }
        public List<ProductViewModel> ListByCateId(int id, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = _context.products.Where(x => x.CategoryId == id).Count();
            var model = (from a in _context.products
                         join b in _context.categories
                         on a.CategoryId equals b.Id
                         where a.CategoryId == id
                         select new
                         {
                             Id = a.Id,
                             Name = a.Name,
                             CategoryId = a.CategoryId,
                             Description = a.Desciption,
                             Image = a.Image,
                             Price = a.Price,
                             Quantity = a.Quantity
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             Id = x.Id,
                             Image = x.Image,
                             Catename = x.Name,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreatedOn).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
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

    }
}
