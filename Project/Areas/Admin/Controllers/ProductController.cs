using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Common.Service;
using Common.Data;
using Common.Model;
using Microsoft.AspNetCore.Hosting;
using X.PagedList;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseController
    {
        private readonly DPContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Index(int ? page)
        {
            var pageNumber = page ?? 1;
            ViewBag.products = _context.products.ToList().ToPagedList(pageNumber, 5);
            return View();
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

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModel productModel,IFormFile ful)
        {
            productModel.Status = true;
            if(ModelState.IsValid)
            {
                _context.Add(productModel);
                await _context.SaveChangesAsync();
                var path = Path.Combine(
                  Directory.GetCurrentDirectory(), "wwwroot/img/sanpham",
                  + productModel.Id + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ful.CopyToAsync(stream);
                }
                productModel.Image = productModel.Id + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                productModel = new ProductModel()
                    {
                        Name = productModel.Name,
                        CreatedOn = DateTime.Now,
                        Desciption = productModel.Desciption,
                        CategoryId = productModel.CategoryId,
                        Image=productModel.Image,
                        Quantity = productModel.Quantity,
                        Price = productModel.Price,
                        Status = productModel.Status
                    };
                await _context.products.AddAsync(productModel);
                    await _context.SaveChangesAsync();
            }
            ViewData["CategoryId"] = new SelectList(_context.categories.Where(p=>p.Status==true), "Id", "Name", productModel.CategoryId);
            return View(productModel);
        }


        // GET: Admin/Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.products.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Id", productModel.CategoryId);
            return View(productModel);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId,Image,Quantity,Price,UpdatedOn,Status")] ProductModel productModel,IFormFile ful)
        {
            productModel.UpdatedOn = DateTime.Now;
            if (id != productModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productModel);
                    if(ful !=null)
                    {
                        var path = Path.Combine(
                       Directory.GetCurrentDirectory(), "wwwroot/img/sanpham", productModel.Image);
                        System.IO.File.Delete(path);
                        path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/img/sanpham",
                        "phim-" + productModel.Id + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await ful.CopyToAsync(stream);
                        }
                        productModel.Image = productModel.Id + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                    }
                    _context.Update(productModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductModelExists(productModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Id", productModel.CategoryId);
            return View(productModel);
        }
        private string UploadFile(IFormFile file)
        {
            string filename = null;
            if(filename!=null)
            {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                filename = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filepath = Path.Combine(uploadDir, filename);
                using (var fileStream= new FileStream(filepath,FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return filename;
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
        public async Task<int> AddNewProduct(ProductModel model)
        {
            var newProduct = new ProductModel()
            {
                Name = model.Name,
                CreatedOn = DateTime.UtcNow,
                Desciption = model.Desciption,
                Image = model.Image,
                CategoryId = model.CategoryId,
                Quantity = model.Quantity,
                Price = model.Price,
                Status = model.Status
            };      
            await _context.products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.Id;
        }
        
    }
}
