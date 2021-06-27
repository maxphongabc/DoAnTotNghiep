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
using Newtonsoft.Json.Linq;
using System.IO;
using Microsoft.AspNetCore.Authorization;

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
        // GET: Admin/SanPham
        public async Task<IActionResult> Index(string Search)
        {
            GetUser();
            if (Search != null)
            {
                ViewBag.ListLSP = _context.LoaiSanPhams.ToList();
                var sanpham = _context.SanPhams.Where(sp => sp.TenSP.Contains(Search)).ToList();
                return View("Index", sanpham);
            }
            var db = _context.SanPhams.Where(u => u.TrangThai == true).Include(s => s.LoaiSanPham);
            return View(await db.ToListAsync());
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

       

        // GET: Admin/SanPham/Edit/5
        public async Task<IActionResult> AddAndEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.LIstLSP = _context.LoaiSanPhams.Where(lsp => lsp.TrangThai == true).ToList();
                return View(new SanPhamModel());
            }
            else
            {
                var sanphammodel = await _context.SanPhams.FindAsync(id);
                if (sanphammodel == null)
                {
                    return NotFound();
                }
                ViewBag.ListLSP = _context.LoaiSanPhams.Where(lsp => lsp.TrangThai == true).ToList();
                ViewData["MaSP"] = new SelectList(_context.SanPhams, "MaSP", "TenSP", sanphammodel.MaSP);
                return View(sanphammodel);
            }
        }
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAndEdit(int id, [Bind("MaSP,TenSP,HinhAnh,DonGia,MoTa,MaLSP,TrangThai")] SanPhamModel sanPhamModel,IFormFile ful)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/img",
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
                    SetMessage("Thêm sản phẩm thành công", "Message");
                }
                else
                {
                    try
                    {
                        await _context.SaveChangesAsync();
                        if (ful != null)
                        {
                            var path = Path.Combine(
                                Directory.GetCurrentDirectory(), "wwwroot/img",
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
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "AddAndEdit", sanPhamModel) });
            
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