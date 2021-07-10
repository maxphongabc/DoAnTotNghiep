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
    public class Invoice_DetailsController : Controller
    {
        private readonly DPContext _context;

        public Invoice_DetailsController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Invoice_Details
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.invoice_Details.Include(i => i.product).Include(i => i.user);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/Invoice_Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice_DetailsModel = await _context.invoice_Details
                .Include(i => i.product)
                .Include(i => i.user)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice_DetailsModel == null)
            {
                return NotFound();
            }

            return View(invoice_DetailsModel);
        }

        // GET: Admin/Invoice_Details/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id");
            return View();
        }

        // POST: Admin/Invoice_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,ProductId,UserId,Quantity,Price,CreatedOn,UpdatedOn")] Invoice_DetailsModel invoice_DetailsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice_DetailsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id", invoice_DetailsModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id", invoice_DetailsModel.UserId);
            return View(invoice_DetailsModel);
        }

        // GET: Admin/Invoice_Details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice_DetailsModel = await _context.invoice_Details.FindAsync(id);
            if (invoice_DetailsModel == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id", invoice_DetailsModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id", invoice_DetailsModel.UserId);
            return View(invoice_DetailsModel);
        }

        // POST: Admin/Invoice_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,ProductId,UserId,Quantity,Price,CreatedOn,UpdatedOn")] Invoice_DetailsModel invoice_DetailsModel)
        {
            if (id != invoice_DetailsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice_DetailsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Invoice_DetailsModelExists(invoice_DetailsModel.Id))
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
            ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id", invoice_DetailsModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id", invoice_DetailsModel.UserId);
            return View(invoice_DetailsModel);
        }

        // GET: Admin/Invoice_Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice_DetailsModel = await _context.invoice_Details
                .Include(i => i.product)
                .Include(i => i.user)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice_DetailsModel == null)
            {
                return NotFound();
            }

            return View(invoice_DetailsModel);
        }

        // POST: Admin/Invoice_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice_DetailsModel = await _context.invoice_Details.FindAsync(id);
            _context.invoice_Details.Remove(invoice_DetailsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Invoice_DetailsModelExists(int id)
        {
            return _context.invoice_Details.Any(e => e.Id == id);
        }
    }
}
