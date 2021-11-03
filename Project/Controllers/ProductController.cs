using Common.Data;
using Common.Model;
using Common.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            }
            return RedirectToAction("Details", "Product", new { Slug = product.Slug });
        }
    }
}
