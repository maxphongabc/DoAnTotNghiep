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
    public class InvoiceController : Controller
    {
        private readonly DPContext _context;

        public InvoiceController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Invoice
        public async Task<IActionResult> Index()
        {
            return View(await _context.invoice.ToListAsync());
        }

        // GET: Admin/Invoice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceModel = await _context.invoice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceModel == null)
            {
                return NotFound();
            }

            return View(invoiceModel);
        }

        // GET: Admin/Invoice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Invoice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Total,Description,CreatedOn,UpdatedOn,Status")] InvoiceModel invoiceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceModel);
        }

        // GET: Admin/Invoice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceModel = await _context.invoice.FindAsync(id);
            if (invoiceModel == null)
            {
                return NotFound();
            }
            return View(invoiceModel);
        }

        // POST: Admin/Invoice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Total,Description,CreatedOn,UpdatedOn,Status")] InvoiceModel invoiceModel)
        {
            if (id != invoiceModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceModelExists(invoiceModel.Id))
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
            return View(invoiceModel);
        }

        // GET: Admin/Invoice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceModel = await _context.invoice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceModel == null)
            {
                return NotFound();
            }

            return View(invoiceModel);
        }

        // POST: Admin/Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceModel = await _context.invoice.FindAsync(id);
            _context.invoice.Remove(invoiceModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceModelExists(int id)
        {
            return _context.invoice.Any(e => e.Id == id);
        }
    }
}
