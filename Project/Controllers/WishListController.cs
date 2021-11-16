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
using X.PagedList;

namespace Project.Controllers
{
    public class WishListController : Controller
    {
        private readonly ProjectDPContext _context;
        private readonly IWishList _iwh;
        public WishListController(ProjectDPContext context,IWishList iwh)
        {
            _context = context;
            _iwh = iwh;
        }
        public IActionResult Index(int? size, int? page)
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
                var order = _iwh.ListAll(user.Id);
                ViewBag.page = page;
                ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại
                int pageSize = (size ?? 10);
                int pageNumber = (page ?? 1);
                return View(order.ToPagedList(pageNumber,pageSize));
            }
            return View();
        }
        public const string USER = "user";
        [HttpPost]
        public async Task <IActionResult> AddWishList(int id)
        {
            var sessionUser = HttpContext.Session.GetString(USER);
            if (sessionUser == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
                return Redirect(urlAdmin);
            }            
            UserModel user = JsonConvert.DeserializeObject<UserModel>(sessionUser);
            var wh = _context.wistlists.Where(x => x.ProductId == id && x.UserId ==user.Id ).FirstOrDefault();
            WishListModel wishList = new WishListModel();
            if (wh==null)
            {
                wishList.ProductId = id;
                wishList.UserId = user.Id;
                wishList.CreateOn = DateTime.UtcNow;
                _context.wistlists.Add(wishList);
                await _context.SaveChangesAsync();
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            WishListModel wh = await _context.wistlists.FindAsync(id);

            if (wh == null)
            {
                TempData["Error"] = "Không có sản phẩm để xóa!";
            }
            else
            {
                _context.wistlists.Remove(wh);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}