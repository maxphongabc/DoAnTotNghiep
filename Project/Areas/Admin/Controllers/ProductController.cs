using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Common.Data;
using Common.Model;
using Microsoft.AspNetCore.Hosting;
using X.PagedList;
using Common.VIewModel;
using Common.Service.Interface;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ProjectDPContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProduct _iproduct;

        public ProductController(ProjectDPContext context,IWebHostEnvironment webHostEnvironment,IProduct iproduct)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _iproduct = iproduct;
        }
        public async Task<IActionResult> Index(int p=1)
        {
            int pageSize = 6;
            var products = _context.products.OrderByDescending(x => x.Id)
                                            .Include(x => x.category)
                                            .Skip((p - 1) * pageSize)
                                            .Take(pageSize);

            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.products.Count() / pageSize);

            return View(await products.ToListAsync());
        }
       
        // GET: Admin/Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.products
                .Include(p => p.category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // GET: Admin/Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.categories.Where(sp=>sp.Status==true), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewData["CategoryId"] = new SelectList(_context.categories.Where(p => p.Status == true), "Id", "Name", product.CategoryId);
            if (ModelState.IsValid)
            {
                try
                {
                    product.Slug = product.Name.ToLower().Replace(" ", "-");
                    var slug = await _context.products.FirstOrDefaultAsync(x => x.Slug == product.Slug);
                    if (slug != null)
                    {
                        ModelState.AddModelError("", "The product already exists.");
                        return View(product);
                    }
                    if (product.ImageUpload != null)
                    {
                        string folder = "img/sanpham/";
                        product.Image = await UploadImage(folder, product.ImageUpload);
                    }
                  
                    await _iproduct.AddNewProduct(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch { throw; }
            }
            return View();
        }
        // GET: Admin/Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ProductModel product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.CategoryId = new SelectList(_context.categories.OrderBy(x => x.Name), "Id", "Name", product.CategoryId);

            return View(product);
        }

        // POST /admin/products/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            ViewBag.CategoryId = new SelectList(_context.categories.OrderBy(x => x.Name), "Id", "Name", product.CategoryId);

            if (ModelState.IsValid)
            {
                product.Slug = product.Name.ToLower().Replace(" ", "-");

                var slug = await _context.products.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Slug == product.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The product already exists.");
                    return View(product);
                }

                if (product.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "img/sanpham");

                    if (!string.Equals(product.Image, "noimage.png"))
                    {
                        string oldImagePath = Path.Combine(uploadsDir, product.Image);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    product.Image = imageName;
                }

                _context.Update(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The product has been edited!";

                return RedirectToAction("Index");
            }

            return View(product);
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        // GET: Admin/Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.products
                .Include(p => p.category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productModel = await _context.products.FindAsync(id);
            _context.products.Remove(productModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductModelExists(int id)
        {
            return _context.products.Any(e => e.Id == id);
        }     
        
    }
}
