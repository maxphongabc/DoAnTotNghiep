using Common.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.VIewModel;
using Common.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Controllers
{
    public class ProductController:Controller
    {
        private readonly ProjectDPContext _context;
        public ProductController(ProjectDPContext context)
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
                    Id= product.Id,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Image = product.Image,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Description = product.Description,
                    Status = product.Status
                    //Gallery = product.productGalleries.Select(p => new ProductGallery()
                    //{
                    //    Id = p.Id,
                    //    Url = p.Url
                    //}).ToList()
                 

                }).FirstOrDefaultAsync();
            

        }
        public List<ProductModel> ListRelatedProduct(int id)
        {
            var product = _context.products.Find(id);
            return _context.products.Where(x => x.Id != id && x.CategoryId == product.CategoryId).ToList();
        }
        [HttpGet]
        public async Task <IActionResult> ProductByCategory(string slug)
        {
            CategoryModel category = await _context.categories.Where(x => x.Slug == slug).FirstOrDefaultAsync();
            if (category == null) return RedirectToAction("Index");

            var products = _context.products.OrderByDescending(x => x.Id)
                                            .Where(x => x.CategoryId == category.Id);
            ViewBag.CategoryName = category.Name;
            return View(await products.ToListAsync());
        }
        public void ListCategory()
        {
            ProductModel product = new ProductModel();
            ViewData["CategoryId"] = new SelectList(_context.categories.Where(p => p.Status == true), "Id", "Name", product.CategoryId);
        }
    }
}
