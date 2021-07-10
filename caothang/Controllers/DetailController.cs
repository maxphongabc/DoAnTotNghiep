using caothang.Areas.Admin.Models;
using caothang.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Controllers
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
                    Status = product.Status,
                    GalleryImage = product.GalleryImage.Select(sp => new GalleryImageModel()
                    {

                    }).ToList(),

                }).FirstOrDefaultAsync();

        }
    }
}
