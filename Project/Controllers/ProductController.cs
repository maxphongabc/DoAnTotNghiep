using Common.Data;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
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
        public ProductController(ProjectDPContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? size, int? page)
        {
            ViewBag.page = page;

            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại
            int pageSize = (size ?? 5);
            int pageNumber = (page ?? 1);
            return View(ListAll().ToPagedList(pageNumber,pageSize));
        }
        public IActionResult Details(string slug)
        {
            var product = DetailProduct(slug);
            ProductModel cate = _context.products.Where(x => x.Slug == slug).FirstOrDefault();
            ViewBag.ListRelatedBlog = ListRelatedProduct(cate.Id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public async Task<IActionResult> ProductByCategory(string slug,int? size,int? page)
        {
            ViewBag.page = page;
           
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại
            int pageSize = (size ?? 5);
            int pageNumber = (page ?? 1);
            CategoryModel category = await _context.categories.Where(x => x.Slug == slug).FirstOrDefaultAsync();
            if (category == null) return RedirectToAction("Index");

            var products = _context.products.OrderByDescending(x => x.Id)
                                            .Where(x => x.CategoryId == category.Id);
            ViewBag.CategoryName = category.Name;         
            return View(await products.ToPagedListAsync(pageNumber, pageSize));
        }
        public List<ProductViewModel> ListProductCate(string slug)
        {
            var product = (from p in _context.products
                           join c in _context.categories on p.CategoryId equals c.Id
                           where c.Slug == slug
                           select new ProductViewModel
                           {
                               ProductId = p.Id,
                               Name = p.Name,
                               Slug = p.Slug,
                               CategoryId = c.Id,
                               Image = p.Image,
                               Description = p.Description,
                               System = p.System,
                               Price = p.Price,
                               Quantity = p.Quantity,
                               Model = p.Model,
                               NameCate = c.Name,
                               SlugCate = c.Slug
                           });
            return product.ToList();
        }
        public ProductViewModel DetailProduct(string slug)
        {
            var product = (from p in _context.products
                           join c in _context.categories on p.CategoryId equals c.Id
                           where c.Slug == slug
                           select new ProductViewModel
                           {
                               ProductId = p.Id,
                               Name = p.Name,
                               Slug = p.Slug,
                               CategoryId = c.Id,
                               Image = p.Image,
                               Description = p.Description,
                               System = p.System,
                               Price = p.Price,
                               Quantity = p.Quantity,
                               Model = p.Model,
                               NameCate = c.Name,
                               SlugCate = c.Slug
                           });
            return product.FirstOrDefault();
        }
        public List<ProductViewModel> ListAll()
        {

            var product = (from p in _context.products
                           join c in _context.categories on p.CategoryId equals c.Id
                           select new ProductViewModel
                           {
                               ProductId = p.Id,
                               Name = p.Name,
                               Slug = p.Slug,
                               CategoryId = c.Id,
                               Image = p.Image,
                               Description = p.Description,
                               System = p.System,
                               Price = p.Price,
                               Quantity = p.Quantity,
                               Model = p.Model,
                               NameCate = c.Name,
                               SlugCate = c.Slug
                           });
            return product.ToList();
        }
        public List<ProductModel> ListRelatedProduct(int id)
        {
            var product = _context.products.Find(id);
            return _context.products.Where(x => x.Id != id && x.CategoryId == product.CategoryId).ToList();
        }
    }
}
