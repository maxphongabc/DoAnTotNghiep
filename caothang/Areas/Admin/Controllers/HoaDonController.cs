using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Controllers
{
    public class HoaDonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
