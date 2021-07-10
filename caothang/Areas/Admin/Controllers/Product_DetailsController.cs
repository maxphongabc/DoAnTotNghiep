using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using caothang.Areas.Admin.Models;
using caothang.Data;

namespace caothang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Product_DetailsController : Controller
    {
        private readonly DPContext _context;

        public Product_DetailsController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Product_Details
        public async Task<IActionResult> Index()
        {
            return View(await _context.product_Details.ToListAsync());
        }

        // GET: Admin/Product_Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_DetailsModel = await _context.product_Details
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product_DetailsModel == null)
            {
                return NotFound();
            }

            return View(product_DetailsModel);
        }

        // GET: Admin/Product_Details/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Model,CPU,GPU,Ram,Rom,CreatedOn,UpdatedOn,Status")] Product_DetailsModel product_DetailsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product_DetailsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product_DetailsModel);
        }

        // GET: Admin/Product_Details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_DetailsModel = await _context.product_Details.FindAsync(id);
            if (product_DetailsModel == null)
            {
                return NotFound();
            }
            return View(product_DetailsModel);
        }

        // POST: Admin/Product_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Model,CPU,GPU,Ram,Rom,CreatedOn,UpdatedOn,Status")] Product_DetailsModel product_DetailsModel)
        {
            if (id != product_DetailsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product_DetailsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Product_DetailsModelExists(product_DetailsModel.Id))
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
            return View(product_DetailsModel);
        }

        // GET: Admin/Product_Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_DetailsModel = await _context.product_Details
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product_DetailsModel == null)
            {
                return NotFound();
            }

            return View(product_DetailsModel);
        }

        // POST: Admin/Product_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product_DetailsModel = await _context.product_Details.FindAsync(id);
            _context.product_Details.Remove(product_DetailsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product_DetailsModelExists(int id)
        {
            return _context.product_Details.Any(e => e.Id == id);
        }
    }
}
