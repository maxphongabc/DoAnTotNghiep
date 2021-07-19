using caothang.Areas.Admin.Models;
using caothang.Data;
using caothang.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace caothang.Controllers
{
    public class CartController : Controller
    {
        private readonly DPContext _context;
        public CartController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Cart()
        {
            return View(GetCartItems());
        }

        public ActionResult AddCart(int id)
        {
            var product = _context.products.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
                return NotFound("Không có sản phẩm");           
            var cart = GetCartItems();
            //check gio hang da co hay chua
            var cartitem = cart.Find(p => p.Product.Id == id);
            if(cartitem != null)
            {
                //neu ton tai tang them 1
                cartitem.Quanlity++;
            }
            else
            {
                //them moi
                cart.Add(new GioHang() { Quanlity = 1, Product = product });
            }
            //luu vao session
            SaveCartSession(cart);
            return RedirectToAction("Index", "Home");

        }
        void SaveCartSession(List<GioHang> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
        public const string CARTKEY = "cart";
        public const string USER = "user";
        // Lấy cart từ Session (danh sách CartItem)
        List<GioHang> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<GioHang>>(jsoncart);
            }
            return new List<GioHang>();
        }
        
        /// Cập nhật
        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart([FromForm] int productid, [FromForm] int quantity)
        {
            // Cập nhật Cart thay đổi số lượng quantity ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.Product.Id == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.Quanlity = quantity;
            }
            SaveCartSession(cart);
            // Trả về mã thành công (không có nội dung gì - chỉ để Ajax gọi)
            return Ok();
        }
        [Route("/removecart/{Id:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] int productid)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.Product.Id == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cart.Remove(cartitem);
            }

            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }
        public ProductModel GetProduct(int id)
        {
            var product = _context.products.Find(id);
            return product;
        }

        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        [HttpPost]
        public IActionResult CheckOut()
        {
            //Kiem tra da dang nhap hay chua đã đăng nhập hay chưa
             var sessionUser = HttpContext.Session.GetString(USER);
            if (sessionUser == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "User", action = "Login", area = "Admin" });
                return Redirect(urlAdmin);
            }
            //Kiem tra gio hang da co gi hay chua
            if (HttpContext.Session.GetString(CARTKEY) == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Index", area = "" });
                return Redirect(urlAdmin);
            }
            int Total = 0;
            ProductModel product = new ProductModel();
            string a = HttpContext.Session.GetString(USER);
            UserModel user = JsonConvert.DeserializeObject<UserModel>(a);         
            InvoiceModel invoice = new InvoiceModel();
            List<GioHang> gh = GetCartItems();
            invoice.CreatedOn = DateTime.Now;
            invoice.Status = true;
            invoice.UserId = user.Id;            
            _context.invoice.Add(invoice);
            _context.SaveChanges();
            foreach(var item in gh)
            {
                Total += item.Total;
                product = GetProduct(item.Product.Id);
                Invoice_DetailsModel details = new Invoice_DetailsModel();
                details.InvoiceId = invoice.Id;
                details.CreatedOn = DateTime.Now;
                details.Price = item.Product.Price;
                details.ProductId = item.Product.Id;
                details.Status = true;
                details.Quantity = item.Quanlity;
                product.Quantity = product.Quantity - details.Quantity;
                _context.invoice_Details.Add(details);
                invoice.Total += details.Price * details.Quantity;
                _context.Update(product);
            }
            _context.Update(invoice);
            _context.SaveChanges();
            return RedirectToAction(nameof(Cart));
        }


    }
}
