using caothang.Data;
using caothang.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize("Admin")]
    public class HomeAdminController : Controller
    {
        private readonly DPContext _context;
        public HomeAdminController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            GetUser();
            return View();
        }
        public void GetUser()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                JObject us = JObject.Parse(HttpContext.Session.GetString("user"));
                NguoiDungModel ND = new NguoiDungModel();
                ND.TaiKhoan = us.SelectToken("TaiKhoan").ToString();
                ND.MatKhau = us.SelectToken("MatKhau").ToString();
                ViewBag.ND = _context.NguoiDungs.Where(nd => nd.TaiKhoan == ND.MatKhau).ToList();
            }
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("DangNhap", "NguoiDung");
        }
    }
}
