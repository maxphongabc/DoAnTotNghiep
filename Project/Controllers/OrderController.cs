using Common.Data;
using Common.Model;
using Common.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult OrderHistory()
        {
            string session = HttpContext.Session.GetString(USER);
            if (session == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
                return Redirect(urlAdmin);
            }
            UserModel user = JsonConvert.DeserializeObject<UserModel>(session);
            if (user.Id != 0)
            {
                var order = _iorder.ListOrder(user.Id);
                return View(order);
            }
            return View();

        }
        public  IActionResult OrderDetailsHistory(int id)
        {
            string session = HttpContext.Session.GetString(USER);
            if (session == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
                return Redirect(urlAdmin);
            }
            UserModel user = JsonConvert.DeserializeObject<UserModel>(session);
            OrderModel order = new OrderModel();
            Order_DetailsModel od = new Order_DetailsModel();
            user.Id = order.UserId;
            ViewBag.Total = order.Total;
            if (order.Id == od.OrderId)
            {
                var order_details = _iorder.ListOrder_Details(id);
                return View(order_details);
            }
            else return View();
        }
    }
}
