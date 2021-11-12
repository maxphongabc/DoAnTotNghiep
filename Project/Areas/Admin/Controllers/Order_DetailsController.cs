using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Common.Data;
using Common.Service.Interface;
using X.PagedList;
using Common.Model;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Order_DetailsController : BaseController
    {
        private readonly ProjectDPContext _context;
        private readonly IOrder _iorder;

        public Order_DetailsController(ProjectDPContext context,IOrder iorder)
        {
            _context = context;
            _iorder = iorder;
        }

        // GET: Admin/Order_Details
        public IActionResult Index(int id)
        {
            var order_details = _iorder.ListOrder_Details(id);
            return View(order_details.ToPagedList());
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_detail = await _context.order_Details.FindAsync(id);
            if (order_detail == null)
            {
                return NotFound();
            }
            return View(order_detail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,OrderId,CreatedOn,Price,Quantity,Status,Tranfer")] Order_DetailsModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", "Order_Details", new { id = model.Id });
            }
            return View(model);
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
        //[HttpPost]
        //public JsonResult ChangeStatus(int id)
        //{
        //    var result = ChangeStatuss(id);
        //    return Json(new
        //    {
        //        status = result
        //    });
        //}
        //public bool ChangeStatuss(int id)
        //{
        //    var order = _context.order_Details.Find(id);
        //    order.Status = !order.Status;
        //    _context.SaveChanges();
        //    return order.Status;
        //}
    }
}
