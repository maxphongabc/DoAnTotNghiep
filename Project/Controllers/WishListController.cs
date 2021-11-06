﻿using Common.Data;
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
        public IActionResult AddWishList(int id)
        {
            var sessionUser = HttpContext.Session.GetString(USER);
            if (sessionUser == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
                return Redirect(urlAdmin);
            }
            WishListModel wh = new WishListModel();
            UserModel user = JsonConvert.DeserializeObject<UserModel>(sessionUser);
            var product = _context.products.Where(x => x.Id == id).FirstOrDefault();
            //var check = _context.wistlists.Where(x => x.ProductId == id).FirstOrDefault(x => x.ProductId == product.Id);
            if (user != null && product != null)
            {
                //if(check !=null)
                //{
                //    ModelState.AddModelError("", "Bạn đã thêm sản phẩm này rồi.");
                //}    
                //else
                wh.ProductId = product.Id;
                wh.UserId = user.Id;
                wh.CreateOn = DateTime.UtcNow;
                _context.wistlists.Add(wh);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
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