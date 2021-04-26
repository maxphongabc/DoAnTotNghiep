using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Controllers
{
    public class LoaiSPController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
