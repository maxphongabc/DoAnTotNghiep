using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Common.Data;
using Common.Model;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using X.PagedList;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ProjectDPContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(ProjectDPContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Product
        public IActionResult Index(string Search, int page = 1, int pageSize = 5)
        {
            ViewBag.Search = Search;
            var model = ListAllPaging(Search, page, pageSize);
            return View(model);

        }
        public IEnumerable<ProductModel> ListAllPaging(string Search, int page, int pageSize)
        {
            IQueryable<ProductModel> model = _context.products;
            if (!string.IsNullOrEmpty(Search))
            {
                model = model.Where(x => x.Name.Contains(Search) || x.category.Name.Contains(Search));
            }

            return model.OrderByDescending(x => x.CreatedOn).ToPagedList(page, pageSize);
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
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Name");
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Slug,CategoryId,Description,Quantity,Price,PriceOld,Image,MoreImage,CreatedOn,UpdatedOn,Status")] ProductModel productModel)
        {
            if(ModelState.IsValid)
            {
                productModel.CreatedOn = DateTime.Now;
                productModel.Status = true;
                productModel.Slug = productModel.Name.ToLower().Replace(" ", "-");

                var slug = await _context.products.FirstOrDefaultAsync(x => x.Slug == productModel.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The product already exists.");
                    return View(productModel);
                }

                string imageName = "noimage.jpg";
                if (productModel.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(webHostEnvironment.WebRootPath, "img/sanpham");
                    imageName = Guid.NewGuid().ToString() + "_" + productModel.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await productModel.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                }

                productModel.Image = imageName;

                _context.Add(productModel);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The product has been added!";

                return RedirectToAction("Index");
            }

            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Name", productModel.CategoryId);
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Slug,CategoryId,Description,Quantity,Price,PriceOld,Image,MoreImage,CreatedOn,UpdatedOn,Status")] ProductModel productModel)
        {
            if (id != productModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
