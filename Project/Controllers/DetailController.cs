
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Common.Data;
using Common.Model;
using Common.Service;
using System.Collections.Generic;

namespace Project.Controllers
{
    public class DetailController : Controller
    {
        private readonly DPContext _context;
        public DetailController(DPContext context)
        {
            _context = context;
        }

        public async Task<ViewResult> Details(int id)
        {
            var data = await GetSpById(id);
            ViewBag.ListRelatedProduct = ListRelatedProduct(id);
            return View(data);
        }
        
        public async Task<ProductModel> GetSpById(int id)
        {
            return await _context.products.Where(x => x.Id == id)
                .Select(product => new ProductModel()
                {
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Image = product.Image,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Desciption = product.Desciption,
                    Status = product.Status

                }).FirstOrDefaultAsync();
        }
        public List<ProductModel> ListRelatedProduct(int id)
        {
            var product = _context.products.Find(id);
            return _context.products.Where(x => x.Id != id && x.CategoryId == product.CategoryId).ToList();
        }
    }
}
