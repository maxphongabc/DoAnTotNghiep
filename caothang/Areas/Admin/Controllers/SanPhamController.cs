using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using caothang.Areas.Admin.Models;
using caothang.Data;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace caothang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private readonly DPContext _context;

        public SanPhamController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/SanPham
        public async Task<IActionResult> Index()
        {
            return View(await _context.SanPhams.ToListAsync());
        }

        // GET: Admin/SanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPhams
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            return View(sanPhamModel);
        }

        // GET: Admin/SanPham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //public IActionResult Create()
        //{
        //    ViewData["MLSP"] = new SelectList(_context.LoaiSanPhams, "Id", "Id");
        //    return View();
        //}
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
        public async Task<IActionResult> Create(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.ListLSP = _context.LoaiSanPhams.Where(lsp => lsp.TrangThai == true).ToList();
                return View(new SanPhamModel());
            }
            else
            {
                var sanphamModel = await _context.SanPhams.FindAsync(id);
                if (sanphamModel == null)
                {
                    return NotFound();
                }
                ViewBag.ListLSP = _context.LoaiSanPhams.Where(lsp => lsp.TrangThai == true).ToList();
                ViewData["MaSP"] = new SelectList(_context.SanPhams, "MaSP", "TenSP", sanphamModel.MaSP);
                return View(sanphamModel);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,[Bind("MaSP,TenSP,HinhAnh,DonGia,SoLuong,MoTa,MLSP,TrangThai")] SanPhamModel sanPhamModel,IFormFile ful)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    //_context.Add(sanPhamModel);
                    //await _context.SaveChangesAsync();
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Admin/ImgPro",
                        sanPhamModel.MaSP + "." + ful.FileName.Split(".")
                        [ful.FileName.Split(".").Length - 1]);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await ful.CopyToAsync(stream);
                    }
                    sanPhamModel.HinhAnh = sanPhamModel.MaSP + "." + ful.FileName.Split(".")
                        [ful.FileName.Split(".").Length - 1];

                    _context.Update(sanPhamModel);
                    await _context.SaveChangesAsync();
                    SetMessage("Thêm sản phẩm thành công", "messages");
                }
                else
                {
                    try
                    {

                        await _context.SaveChangesAsync();
                        if (ful != null)
                        {
                            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Admin/ImgPro",
                        sanPhamModel.MaSP + "." + ful.FileName.Split(".")
                        [ful.FileName.Split(".").Length - 1]);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await ful.CopyToAsync(stream);
                            }
                            sanPhamModel.HinhAnh = sanPhamModel.MaSP + "." + ful.FileName.Split(".")
                                [ful.FileName.Split(".").Length - 1];
                        }
                        _context.Update(sanPhamModel);
                        await _context.SaveChangesAsync();
                        SetMessage("Sửa sản phẩm thành công", "messages");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SanPhamModelExists(sanPhamModel.MaSP))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                ViewBag.ListLSP = _context.LoaiSanPhams.Where(lsp => lsp.TrangThai == true).ToList();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", _context.SanPhams.Where(u => u.TrangThai == true).ToList()) });
            }
            ModelState.AddModelError("", "Thêm mới sản phẩm thất bại");
            ViewBag.ListLSP = _context.LoaiSanPhams.Where(lsp => lsp.TrangThai == true).ToList();
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", sanPhamModel) });

        }

        // GET: Admin/SanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPhams.FindAsync(id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }
            return View(sanPhamModel);
        }

        // POST: Admin/SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSP,TenSP,HinhAnh,DonGia,SoLuong,MoTa,TrangThai")] SanPhamModel sanPhamModel)
        {
            if (id != sanPhamModel.MaSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPhamModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamModelExists(sanPhamModel.MaSP))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sanPhamModel);
        }

        // GET: Admin/SanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPhams
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            return View(sanPhamModel);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPhamModel = await _context.SanPhams.FindAsync(id);
            _context.SanPhams.Remove(sanPhamModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamModelExists(int id)
        {
            return _context.SanPhams.Any(e => e.MaSP == id);
        }
    }
}
