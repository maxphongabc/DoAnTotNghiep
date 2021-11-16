using Common.Data;
using Common.Model;
using Common.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Project.Controllers
{
    public class OrderController : Controller
    {
        private readonly ProjectDPContext _context;
        private readonly IOrder _iorder;
        
        public OrderController(ProjectDPContext context,IOrder iorder)
        {
            _context = context;
            _iorder = iorder;
        }    
        public IActionResult Index()
        {
            return View();
        }
        public const string USER = "user";
        public async Task <IActionResult> OrderHistory(int? size, int? page)
        {
            string session = HttpContext.Session.GetString(USER);
            if (session == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
                return Redirect(urlAdmin);
            }
            UserModel user = JsonConvert.DeserializeObject<UserModel>(session);
            ViewBag.currentSize = size;

            page = page ?? 1; 

            int pageSize = (size ?? 10);
            int pageNumber = (page ?? 1);
            if (user.Id != 0)
            {
                var order = _iorder.ListOrder(user.Id);
                return View(await order.ToPagedListAsync(pageNumber, pageSize));
            }
            
            return View();

        }
        public async Task <IActionResult> OrderDetailsHistory(int id)
        {
            string session = HttpContext.Session.GetString(USER);
            if (session == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
                return Redirect(urlAdmin);
            }
            UserModel user = JsonConvert.DeserializeObject<UserModel>(session);
            var order = await _context.order.Include(x => x.user)
                                            .Include(x => x.TransactStatus)
                                             .FirstOrDefaultAsync(x => x.Id == id);
            if(user.Id == order.UserId)
            {
                var CTHD = _context.order_Details.Include(x => x.product)
                                                  .AsNoTracking()
                                                  .Where(x => x.OrderId == order.Id)
                                                  .OrderBy(x => x.Id)
                                                  .ToList();
                ViewBag.CTHD = CTHD;
                return View(order);
            }
            return NotFound();
            //OrderModel order = new OrderModel();
            //Order_DetailsModel od = new Order_DetailsModel();
            //user.Id = order.UserId;
            //if (order.Id == od.OrderId)
            //{
            //    var order_details = _iorder.ListOrder_Details(id);
            //    return View(order_details);
            //}

            //else return View();
        }
        public ProductModel GetProduct(int id)
        {
            var product = _context.products.Find(id);
            return product;
        }
        [HttpPost]
        public async Task<IActionResult> Cancel(int id)
        {
            string session = HttpContext.Session.GetString(USER);
            if (session == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
                return Redirect(urlAdmin);
            }
            UserModel user = JsonConvert.DeserializeObject<UserModel>(session);
            ProductModel product = new ProductModel();
            var order = _context.order.Find(id);
            var order_Details = _context.order_Details
                    .Include(x => x.product)
                    .AsNoTracking()
                    .Where(x => x.OrderId == order.Id)
                    .OrderBy(x => x.OrderId)
                    .ToList();
            if (order != null && user != null)
            {
                order.TransactStatusId = 4;
                foreach(var item in order_Details)
                {
                    product = GetProduct(item.ProductId);
                    product.Quantity = product.Quantity + item.Quantity;
                }    
                _context.Update(order);
                await _context.SaveChangesAsync();
                return Json(true);
            }
            return Json(false);
        }
    }
}
