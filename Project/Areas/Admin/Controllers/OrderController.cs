using System.Linq;
using System.Threading.Tasks;
using Common.Data;
using Common.Model;
using Common.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly ProjectDPContext _context;
        private readonly IOrder _iorder;
        public OrderController(ProjectDPContext context, IOrder iorder)
        {
            _context = context;
            _iorder = iorder;
        }

        // GET: Admin/Order
        public IActionResult Index(int? size, int? page)
        {
            ViewBag.currentSize = size; 

            page = page ?? 1; //if (page == null) page = 1;

            int pageSize = (size ?? 10);
            int pageNumber = (page ?? 1);
            var order = _iorder.ListOrderAdmin();
            return View(order.ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.order
                .Include(o => o.user)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        // GET: Admin/Order/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id");
            return View();
        }     

        // GET: Admin/Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.order.FindAsync(id);
            if (orderModel == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id", orderModel.UserId);
            return View(orderModel);
        }

        // POST: Admin/Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Total,ShipName,ShipPhone,ShipEmail,ShipAdress,Description,CreatedOn,UpdatedOn,Status")] OrderModel orderModel)
        {
            if (id != orderModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderModelExists(orderModel.Id))
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
            ViewData["UserId"] = new SelectList(_context.user, "Id", "Id", orderModel.UserId);
            return View(orderModel);
        }
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = ChangeStatuss(id);
            return Json(new
            {
                status = result
            });
        }
        public bool ChangeStatuss(int id)
        {
            var order = _context.order.Find(id);
            order.Status = !order.Status;
            _context.SaveChanges();
            return order.Status;
        }
        // GET: Admin/Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.order
                .Include(o => o.user)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        // POST: Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderModel = await _context.order.FindAsync(id);
            _context.order.Remove(orderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderModelExists(int id)
        {
            return _context.order.Any(e => e.Id == id);
        }
    }
}
