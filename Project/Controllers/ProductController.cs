using Common.Data;
using Common.Model;
using Common.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using X.PagedList;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProjectDPContext _context;
        private readonly IProduct _iproduct;
        public ProductController(ProjectDPContext context,IProduct iproduct)
        {
            _context = context;
            _iproduct = iproduct;
        }
        public IActionResult Index(int? size, int? page)
        {
            var product = _iproduct.ListAll();
            ViewBag.page = page;
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại
            int pageSize = (size ?? 6);
            int pageNumber = (page ?? 1);
            return View(product.ToPagedList(pageNumber,pageSize));
        }
        public IActionResult Details(string slug)
        {
            var product =_iproduct.DetailProduct(slug);
            ProductModel cate = _context.products.Where(x => x.Slug == slug).FirstOrDefault();
            ViewBag.ListRelatedProduct = _iproduct.ListRelatedProduct(cate.Id);
            ViewBag.ProductId = cate.Id;
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Comment = _iproduct.ListComment(cate.Id);
            return View(product);
        }
        public const string USER = "user";
        public async Task<IActionResult> ProductByCategory(string slug,int? size,int? page)
        {
            ViewBag.page = page;
           
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại
            int pageSize = (size ?? 6);
            int pageNumber = (page ?? 1);
            CategoryModel category = await _context.categories.Where(x => x.Slug == slug).FirstOrDefaultAsync();
            if (category == null) return RedirectToAction("Index");

            var products = _iproduct.ListProductCate(slug);
            ViewBag.CategoryName = category.Name;         
            return View(await products.ToPagedListAsync(pageNumber, pageSize));
        }

        [HttpPost]
        public IActionResult AddComment(int ProductId,string Comment)
        {
            var sessionUser = HttpContext.Session.GetString(USER);
            if (sessionUser == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
                return Redirect(urlAdmin);
            }
            CommentProduct cmt = new CommentProduct();
            UserModel user = JsonConvert.DeserializeObject<UserModel>(sessionUser);
            var product = _context.products.Where(x => x.Id == ProductId).FirstOrDefault(); 

            if(user!=null && product!=null)
            {
                cmt.CreateOn = DateTime.Now;
                cmt.ProductId = ProductId;
                cmt.UserId = user.Id;
                cmt.Content = Comment;
                cmt.Status = true;
                _context.commentsproduct.Add(cmt);
                _context.SaveChanges();
                //return Json(true);
            }
            return RedirectToAction("Details", "Product", new { Slug = product.Slug });
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
