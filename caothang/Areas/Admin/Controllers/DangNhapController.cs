using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using caothang.Areas.Admin.Models;
using caothang.Data;

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

        // GET: Admin/DangNhap
        public async Task<IActionResult> Index()
        {
            return View(await _context.DangNhapModel.ToListAsync());
        }

    
}
    }
