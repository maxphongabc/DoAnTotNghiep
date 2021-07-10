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

        public IActionResult AddCart(int id)
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

        public IActionResult DeleteCart(int id)
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
    }
}
