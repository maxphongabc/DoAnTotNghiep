
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Common.Data;
using Common.Model;
using System.Collections.Generic;
using Common.VIewModel;

namespace Project.Controllers
{
    public class DetailController : Controller
    {
        private readonly ProjectDPContext _context;
        public DetailController(ProjectDPContext context)
        {
            _context = context;
        }

        public async Task<ViewResult> Details(int id)
        {
            var data = await GetSpById(id);
            ViewBag.ListRelatedProduct = ListRelatedProduct(id);
            return View(data);
        }
        
        public async Task<Product> GetSpById(int id)
        {
            return await _context.products.Where(x => x.Id == id)
                .Select(product => new Product()
                {
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Image = product.Image,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Description = product.Description,
                    Status = product.Status,
                    Gallery=product.productGalleries.Select(p=> new ProductGallery()
                    {
                        Id=p.Id,
                        Url=p.Url
                    }).ToList()
                    
                }).FirstOrDefaultAsync();
        }
        public List<ProductModel> ListRelatedProduct(int id)
        {
            var product = _context.products.Find(id);
            return _context.products.Where(x => x.Id != id && x.CategoryId == product.CategoryId).ToList();
        }
    }
}
