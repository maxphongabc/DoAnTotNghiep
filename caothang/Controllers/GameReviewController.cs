using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Controllers
{
    public class GameReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
