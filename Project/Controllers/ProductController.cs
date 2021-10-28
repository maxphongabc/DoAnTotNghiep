using Common.Data;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public ProductController(ProjectDPContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Details(string slug)
        {
            if (slug == null)
            {
                return NotFound();
            }
            
            var productModel = await _context.products
                .Include(p => p.category)
                .FirstOrDefaultAsync(m => m.Slug == slug);
            int id = productModel.Id;
            if (productModel == null)
            {
                return NotFound();
            }
            ViewBag.ListRelatedProduct = ListRelatedProduct(id);
            return View(productModel);
        }
        public List<ProductModel> ListRelatedProduct(int id)
        {
            var product = _context.products.Find(id);
            return _context.products.Where(x => x.Id != id && x.CategoryId == product.CategoryId).ToList();
        }
        [HttpGet]
        public async Task<IActionResult> ProductByCategory(string slug,int? size,int? page)
        {
            ViewBag.page = page;
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "10", Value = "10" });
            items.Add(new SelectListItem { Text = "20", Value = "20" });
            items.Add(new SelectListItem { Text = "25", Value = "25" });
            items.Add(new SelectListItem { Text = "50", Value = "50" });
            items.Add(new SelectListItem { Text = "100", Value = "100" });
            items.Add(new SelectListItem { Text = "200", Value = "200" });
            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }
            ViewBag.size = items; // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại
            int pageSize = (size ?? 5);

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            CategoryModel category = await _context.categories.Where(x => x.Slug == slug).FirstOrDefaultAsync();
            if (category == null) return RedirectToAction("Index");

            var products = _context.products.OrderByDescending(x => x.Id)
                                            .Where(x => x.CategoryId == category.Id);
            ViewBag.CategoryName = category.Name;
            return View(await products.ToPagedListAsync(pageNumber, pageSize));
        }
    }
}
