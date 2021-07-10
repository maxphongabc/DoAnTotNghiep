using caothang.Areas.Admin.Models;
using caothang.Data;
using caothang.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace caothang.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly DPContext _context;
        public HomeController(DPContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index(string Search)
        {
            //GetUser();
            var link = from l in _context.products select l;
            if (!String.IsNullOrEmpty(Search))
            {
                link = link.Where(s => s.Name.Contains(Search));
            }
            ViewBag.ListSPPlayStation = _context.products.Where(sp => sp.Status == true && sp.CategoryId == 1).OrderBy(sp => sp.Id).ToList();
            //ViewBag.ListSPXbox = _context.SanPhams.Where(sp => sp.TrangThai == true && sp.MaLSP == 2).OrderBy(sp => sp.MaSP).ToList();
            //ViewBag.ListSPNintendo = _context.SanPhams.Where(sp => sp.TrangThai == true && sp.MaLSP == 3).OrderBy(sp => sp.MaSP).ToList();
            return View(link);
        }
        //public void GetUser()
        //{
        //    if (HttpContext.Session.GetString("user") != null)
        //    {
        //        JObject us = JObject.Parse(HttpContext.Session.GetString("user"));
        //        NguoiDungModel ND = new NguoiDungModel();
        //        ND.TaiKhoan = us.SelectToken("TaiKhoan").ToString();
        //        ND.MatKhau = us.SelectToken("MatKhau").ToString();
        //        ViewBag.ND = _context.NguoiDungs.Where(nd => nd.TaiKhoan == ND.TaiKhoan).ToList();
        //    }
        //}
        public IActionResult LoaiSP(int? page)
        {
           // GetUser();
            var ListSP = _context.products.Where(sp => sp.Status == true).ToList();
            var listLSP = _context.categories.Where(lsp => lsp.Status == true).OrderBy(lsp => lsp.Id).ToList();
            var pageSize = 9;
            var PageNumber = page == null || page <= 0 ? 1 : page.Value;
            if (listLSP == null)
            {
                return NotFound();
            }
            ViewBag.SP = ListSP.ToPagedList(PageNumber, pageSize);
            return View(listLSP);
        }
        public IActionResult ThemGioHang(int id)
        {
            var cart = HttpContext.Session.GetString("CartSession");//get key cart
            if (cart == null)
            {
                var product = GetProduct(id);
                List<GioHang> listCart = new List<GioHang>()
                {
                    new GioHang
                    {
                        Product=product,
                        Quality=1
                    }
                };
                HttpContext.Session.SetString("CartSession", JsonConvert.SerializeObject(listCart));
            }
            else
            {
                List<GioHang> dataCart = JsonConvert.DeserializeObject<List<GioHang>>(cart);
                bool check = true;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Product.Id == id)
                    {
                        dataCart[i].Quality++;
                        check = false;
                    }
                }
                if (check)
                {
                    dataCart.Add(new GioHang
                    {
                        Product = GetProduct(id),
                        Quality = 1
                    });
                }
                HttpContext.Session.SetString("CartSession", JsonConvert.SerializeObject(dataCart));

                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult GioHang()
        {
            //GetUser();
            var giohang = HttpContext.Session.GetString("CartSession");
            if (giohang != null)
            {
                List<GioHang> gioHangs = JsonConvert.DeserializeObject<List<GioHang>>(giohang);
                if (gioHangs.Count > 0)
                {
                    ViewBag.giohang = gioHangs;
                    return View();
                }
            }
            return View();
        }
        public IActionResult XoaGioHang(int id)
        {
            var giohang = HttpContext.Session.GetString("CartSession");
            if (giohang != null)
            {
                List<GioHang> dataCart = JsonConvert.DeserializeObject<List<GioHang>>(giohang);

                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Product.Id == id)
                    {
                        dataCart.RemoveAt(i);
                    }
                }
                HttpContext.Session.SetString("CartSession", JsonConvert.SerializeObject(dataCart));
                HttpContext.Session.Remove("CartSession");
                return RedirectToAction(nameof(giohang));
            }
            return RedirectToAction(nameof(giohang));
        }
        public ProductModel GetProduct(int id)
        {
            var product = _context.products.Find(id);
            return product;
        }
    }
}
