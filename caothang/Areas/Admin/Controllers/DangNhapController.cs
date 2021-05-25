using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using caothang.Areas.Admin.Models;
using caothang.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace caothang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DangNhapController : Controller
    {
        private readonly caothangContext _context;

        public DangNhapController(caothangContext context)
        {
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("TaiKhoan,MatKhau")] DangNhapModel member)
        {
            if (member.TaiKhoan != null && member.MatKhau != null)
            {
                var r = _context.DangNhapModel.Where(m => m.TaiKhoan == member.TaiKhoan && m.MatKhau == (member.MatKhau)).ToList(); ;
                //var y = StringProcessing.CreateMD5Hash("aa");


                //if (r.Count == 0 || r[0].PhanQuyen == true)
                //{
                //    SetMessage("Sai tài khoản hoặc mật khẩu", "Message");
                //    return View("loginIndex");
                //}
                //else
                //{
                //    if (r[0].PhanQuyen == false)
                //    {
                //        var str = JsonConvert.SerializeObject(member);
                //        HttpContext.Session.SetString("TaiKhoan", str);

                //        var urlAdmin = Url.RouteUrl(new { controller = "HomeAdmin", action = "Index", area = "ADmin" });
                //        return Redirect(urlAdmin);
                //    }
                //}
            }
            return View();
        }
        public void SetMessage(string Message, string type)
        {
            TempData["AlertMessage"] = Message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

        private bool DangNhapModelExists(string id)
        {
            return _context.DangNhapModel.Any(e => e.TaiKhoan == id);
        }
    }
}
