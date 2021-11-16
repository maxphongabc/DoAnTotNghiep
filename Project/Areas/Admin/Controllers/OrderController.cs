using System;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
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
    public class OrderController : BaseController
    {
        private readonly ProjectDPContext _context;
        private readonly IOrder _iorder;
        private readonly INotyfService _notyf;
        public OrderController(ProjectDPContext context, IOrder iorder,INotyfService notyf)
        {
            _notyf = notyf;
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
            var order = _iorder.ListOrderAdmin_1();
            return View(order.ToPagedList(pageNumber,pageSize));
        }
        public IActionResult Index2(int? size, int? page)
        {
            ViewBag.currentSize = size;

            page = page ?? 1; //if (page == null) page = 1;

            int pageSize = (size ?? 10);
            int pageNumber = (page ?? 1);
            var order = _iorder.ListOrderAdmin_2();
            return View(order.ToPagedList(pageNumber, pageSize));
        }
        public IActionResult Index3(int? size, int? page)
        {
            ViewBag.currentSize = size;

            page = page ?? 1; //if (page == null) page = 1;

            int pageSize = (size ?? 10);
            int pageNumber = (page ?? 1);
            var order = _iorder.ListOrderAdmin_3();
            return View(order.ToPagedList(pageNumber, pageSize));
        }
        public IActionResult Index4(int? size, int? page)
        {
            ViewBag.currentSize = size;

            page = page ?? 1; //if (page == null) page = 1;

            int pageSize = (size ?? 10);
            int pageNumber = (page ?? 1);
            var order = _iorder.ListOrderAdmin_4();
            return View(order.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Order/Details/5
        public async Task <IActionResult> Details(int id)
        {
            var order = _iorder.Details_Order(id);
            var order_Details =await _context.order_Details
                .Include(x => x.product)
                .AsNoTracking()
                .Where(x => x.OrderId == order.OrderId)
                .OrderBy(x => x.OrderId)
                .ToListAsync();
            ViewBag.CTHD = order_Details;
            return PartialView(order);
        }
        // GET: Admin/Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order =await _context.order.AsNoTracking().Include(x => x.user).FirstOrDefaultAsync(x => x.Id==id);
            ViewData["TransactStatusId"] = new SelectList(_context.TransactStatuses, "Id", "Name", order.TransactStatusId);
            if (order == null)
            {
                return NotFound();
            }
            return PartialView(order);
        }

        // POST: Admin/Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderModel orderModel)
        {
            if (id != orderModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var order = await _context.order.AsNoTracking().Include(x => x.user).FirstOrDefaultAsync(x => x.Id == id);
                    ProductModel product = new ProductModel();
                    var order_Details = _context.order_Details
                    .Include(x => x.product)
                    .AsNoTracking()
                    .Where(x => x.OrderId == order.Id)
                    .OrderBy(x => x.OrderId)
                    .ToList();
                    ViewData["TransactStatusId"] = new SelectList(_context.TransactStatuses, "Id", "Name", order.TransactStatusId);
                    if (order != null)
                    {
                        order.TransactStatusId = orderModel.TransactStatusId;
                        if(order.TransactStatusId==3)
                        {
                            order.ShipDateOn = DateTime.Now;
                        }    
                        if(order.TransactStatusId==4)
                        {
                            foreach(var item in order_Details)
                            {
                                product = GetProduct(item.ProductId);
                                product.Quantity = product.Quantity + item.Quantity;
                            }    
                            order.ShipDateOn = null;
                            _context.Update(product);
                        }    
                    }
         

                    _context.Update(order);
                        await _context.SaveChangesAsync();
                    _notyf.Success("Cập nhật trạng thái đơn hàng thành công", 3);

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
            return PartialView("Edit", orderModel);
        }
        public ProductModel GetProduct(int id)
        {
            var product = _context.products.Find(id);
            return product;
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

            return PartialView(orderModel);
        }

        // POST: Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderModel = await _context.order.FindAsync(id);
            orderModel.TransactStatusId = 5;
            _context.order.Update(orderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderModelExists(int id)
        {
            return _context.order.Any(e => e.Id == id);
        }
    }
}
