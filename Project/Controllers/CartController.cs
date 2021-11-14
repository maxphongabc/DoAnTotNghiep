using Common.Data;
using Common.Model;
using Common.Service.Interface;
using Common.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Infratructure;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class CartController : Controller
    {
        private readonly ProjectDPContext _context;
        private readonly ISendMailService sendMailService;
        public CartController(ProjectDPContext context,ISendMailService sendMail)
        {
            _context = context;
            sendMailService = sendMail;
        }
        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Price * x.Quantity)
            };

            return View(cartVM);
        }

        public async Task<IActionResult> AddCart(int id)
        {
            ProductModel product = await _context.products.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", cart);

            if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
                return View();

            return ViewComponent("SmallCart");

        }
        public const string USER = "user";

        public IActionResult Decrease(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(x => x.ProductId == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            return Json(true);
        }
        public IActionResult Plus(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();
            var prooduct = _context.products.Where(x => x.Id == id).FirstOrDefault();
            if(cartItem!= null)
            {
                cartItem.Quantity += 1;
                if(cartItem.Quantity>=prooduct.Quantity)
                {
                    return Json(false);
                }
            }
            HttpContext.Session.SetJson("Cart", cart);

            if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
                return Json(true);

            return ViewComponent("SmallCart");

        }
        public IActionResult Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(x => x.ProductId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            return Json(true);
        }

        public ProductModel GetProduct(int id)
        {
            var product = _context.products.Find(id);
            return product;
        }
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");
            if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
                return Redirect(Request.Headers["Referer"].ToString());

            return Ok();
        }
        [HttpGet]
        public IActionResult CheckOut()
        {
            var sessionUser = HttpContext.Session.GetString(USER);
            if (sessionUser == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
                return Redirect(urlAdmin);
            }
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVM = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Price * x.Quantity)
            };
            return View(cartVM);
        }
    
        
        [HttpPost]
        public async Task <IActionResult> CheckOut(string description,string shipname)
        {
            ProductModel product = new ProductModel();
            string a = HttpContext.Session.GetString(USER);
            UserModel user = JsonConvert.DeserializeObject<UserModel>(a);
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVM = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Price * x.Quantity)
            };
            OrderModel order = new OrderModel();
            order.Description = description;
            order.ShipAdress = user.Address;
            order.ShipEmail = user.Email;
            order.ShipPhone = user.Phone;
            order.Status = true;
            order.TransactStatusId = 1;
            order.ShipName = shipname;
            order.CreatedOn = DateTime.Now;
            order.UserId = user.Id;
            _context.order.Add(order);
            _context.SaveChanges();
            foreach (var item in cart)
            {
                product = GetProduct(item.ProductId);
                Order_DetailsModel details = new Order_DetailsModel();
                details.OrderId = order.Id;
                details.CreatedOn = DateTime.Now;
                details.Price = item.Price;
                details.ProductId = item.ProductId;
                details.Quantity = item.Quantity;
                product.Quantity = product.Quantity - details.Quantity;
                _context.order_Details.Add(details);
                order.Total += details.Price * details.Quantity;
                _context.Update(product);
            }
            
            MailContent content = new MailContent
            {
                To = user.Email,
                Subject = "Đơn hàng mới từ FlipMart" + "#"+order.Id,
                Body = "<p><strong>Xin chào</strong></p>" + user.FullName + "<p>Cảm ơn bạn đã quan tâm sản phẩm của chúng tôi.Đơn hàng của bạn sẽ được xử lý ngay.</p>"
            };
            await sendMailService.SendMail(content);

            _context.Update(order);
            _context.SaveChanges();
            HttpContext.Session.Remove("Cart");
            var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Index" });
            return Redirect(urlAdmin);
        }
    }
}
