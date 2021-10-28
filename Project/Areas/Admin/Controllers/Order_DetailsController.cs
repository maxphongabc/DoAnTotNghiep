using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Common.Data;
using Common.Model;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Order_DetailsController : Controller
    {
        private readonly ProjectDPContext _context;

        public Order_DetailsController(ProjectDPContext context)
        {
            _context = context;
        }

        // GET: Admin/Order_Details
        public async Task<IActionResult> Index()
        {
            var projectDPContext = _context.order_Details.Include(o => o.product);
            return View(await projectDPContext.ToListAsync());
        }

        // GET: Admin/Order_Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_DetailsModel = await _context.order_Details
                .Include(o => o.product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order_DetailsModel == null)
            {
                return NotFound();
            }

            return View(order_DetailsModel);
        }   
        // POST: Admin/Order_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,InvoiceId,Quantity,Price,CreatedOn,Status")] Order_DetailsModel order_DetailsModel)
        {
            if (id != order_DetailsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order_DetailsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Order_DetailsModelExists(order_DetailsModel.Id))
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
            ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id", order_DetailsModel.ProductId);
            return View(order_DetailsModel);
        }

        // GET: Admin/Order_Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_DetailsModel = await _context.order_Details
                .Include(o => o.product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order_DetailsModel == null)
            {
                return NotFound();
            }

            return View(order_DetailsModel);
        }

        // POST: Admin/Order_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order_DetailsModel = await _context.order_Details.FindAsync(id);
            _context.order_Details.Remove(order_DetailsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Order_DetailsModelExists(int id)
        {
            return _context.order_Details.Any(e => e.Id == id);
        }
    }
}
