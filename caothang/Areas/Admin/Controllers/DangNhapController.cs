using caothang.Areas.Admin.Models;
using caothang.Common;
using caothang.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;


namespace caothang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DangNhapController : Controller
    {
        private readonly DPContext _context;
        public DangNhapController(DPContext context)
        {
            _context = context;

        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult DangNhap( NguoiDungModel member)
        {
            if (member.TaiKhoan != null && member.MatKhau != null)
            {
                var r = _context.NguoiDungs.Where(m => m.TaiKhoan == member.TaiKhoan && m.MatKhau == (member.MatKhau)).ToList();
                //var y = StringProcessing.CreateMD5Hash("aa");
                if (r.Count == 0)
                {
                    return View("login");
                }
                else
                {

                    if (r[0].MaQuyen == 1)
                    {
                        var str = JsonConvert.SerializeObject(member);
                        HttpContext.Session.SetString("user", str);

                        var urlAdmin = Url.RouteUrl(new { controller = "HomeAdmin", action = "Index", area = "Admin" });
                        return Redirect(urlAdmin);
                    }
                    else
                    {
                        var str = JsonConvert.SerializeObject(member);
                        HttpContext.Session.SetString("user", str);

                        var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Index"});
                        return Redirect(urlAdmin);
                    }    
                }
            }

            return View();

        }
        public NguoiDungModel GetByID(string taikhoan)
        {
            return _context.NguoiDungs.SingleOrDefault(x => x.TaiKhoan == taikhoan);
        }

       

    }

}
