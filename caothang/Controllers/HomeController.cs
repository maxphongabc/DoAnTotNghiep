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
    //[Authorize]
    public class HomeController : Controller
    {

        private readonly DPContext _context;
        public HomeController(DPContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            GetUser();
            //ViewBag.ListSPPlayStation = _context.SanPhams.Where(sp => sp.TrangThai == true && sp.MaLSP == 1).OrderBy(sp => sp.MaSP).ToList();
            return View();
        }

        public async Task<IActionResult> ChiTietSP(int? id)
        {
            GetUser();
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPhams
                .Include(s => s.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            return View(sanPhamModel);
        }
        public void GetUser()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                JObject us = JObject.Parse(HttpContext.Session.GetString("user"));
                NguoiDungModel ND = new NguoiDungModel();
                ND.TaiKhoan = us.SelectToken("TaiKhoan").ToString();
                ND.MatKhau = us.SelectToken("MatKhau").ToString();
                ViewBag.ND = _context.NguoiDungs.Where(nd => nd.TaiKhoan == ND.TaiKhoan).ToList();
            }
        }
        public IActionResult LoaiSP(int? page)
        {
            GetUser();
            var ListSP = _context.SanPhams.Where(sp => sp.TrangThai == true).ToList();
            var listLSP = _context.LoaiSanPhams.Where(lsp => lsp.TrangThai == true).OrderBy(lsp => lsp.MaLSP).ToList();
            var pageSize = 9;
            var PageNumber = page == null || page <= 0 ? 1 : page.Value;
            if (listLSP == null)
            {
                return NotFound();
            }
            ViewBag.SP = ListSP.ToPagedList(PageNumber, pageSize);
            return View(listLSP);
        }

        //[Route("addcart/{masp:int}")]
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
                        sanpham=product,
                        Quaility=1
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
                    if (dataCart[i].sanpham.MaSP == id)
                    {
                        dataCart[i].Quaility++;
                        check = false;
                    }
                }
                if (check)
                {
                    dataCart.Add(new GioHang
                    {
                        sanpham = GetProduct(id),
                        Quaility = 1
                    });
                }
                HttpContext.Session.SetString("CartSession", JsonConvert.SerializeObject(dataCart));

                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult GioHang()
        {
            GetUser();
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
                    if (dataCart[i].sanpham.MaSP == id)
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
        public SanPhamModel GetProduct(int id)
        {
            var product = _context.SanPhams.Find(id);
            return product;
        }
    }
}
