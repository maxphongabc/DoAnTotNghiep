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
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace caothang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NguoiDungController : Controller
    {
        private readonly DPContext _context;
       
        public NguoiDungController(DPContext context)
        {
            _context = context;

        }

        // GET: Admin/NguoiDung
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.NguoiDungs.Include(n => n.PhanQuyens);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/NguoiDung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _context.NguoiDungs
                .Include(n => n.PhanQuyens)
                .FirstOrDefaultAsync(m => m.MaND == id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            return View(nguoiDungModel);
        }

        // GET: Admin/NguoiDung/Create
        public IActionResult Create()
        {
            ViewData["MaQuyen"] = new SelectList(_context.Set<PhanQuyenModel>(), "MaQuyen", "TenQuyen");
            return View();
        }

        // POST: Admin/NguoiDung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaND,HoTen,DiaChi,DienThoai,Email,TaiKhoan,MatKhau,TrangThai,MaQuyen")] NguoiDungModel nguoiDungModel,IFormFile ful)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoiDungModel);
                await _context.SaveChangesAsync();
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img",
                    nguoiDungModel.MaND + "." + ful.FileName.Split('.')[ful.FileName.Split('.').Length - 1]);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ful.CopyToAsync(stream);
                }
                nguoiDungModel.HinhAnh = nguoiDungModel.MaND + "." + ful.FileName.Split('.')[ful.FileName.Split('.').Length - 1];
                await _context.SaveChangesAsync();
                var nguoidung = _context.NguoiDungs.Where(sp => sp.MaND == nguoiDungModel.MaND).Include(s => s.MaQuyen).FirstOrDefault();

                return RedirectToAction(nameof(Index));
            }
            ViewData["MaQuyen"] = new SelectList(_context.Set<PhanQuyenModel>(), "MaQuyen", "TenQuyen", nguoiDungModel.MaQuyen);
            return View(nguoiDungModel);
        }

        // GET: Admin/NguoiDung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _context.NguoiDungs.FindAsync(id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }
            ViewData["MaQuyen"] = new SelectList(_context.Set<PhanQuyenModel>(), "MaQuyen", "TenQuyen", nguoiDungModel.MaQuyen);
            return View(nguoiDungModel);
        }

        // POST: Admin/NguoiDung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaND,HoTen,DiaChi,DienThoai,Email,TaiKhoan,MatKhau,TrangThai,MaQuyen")] NguoiDungModel nguoiDungModel)
        {
            if (id != nguoiDungModel.MaND)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoiDungModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoiDungModelExists(nguoiDungModel.MaND))
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
            ViewData["MaQuyen"] = new SelectList(_context.Set<PhanQuyenModel>(), "MaQuyen", "TenQuyen", nguoiDungModel.MaQuyen);
            return View(nguoiDungModel);
        }

        // GET: Admin/NguoiDung/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _context.NguoiDungs
                .Include(n => n.PhanQuyens)
                .FirstOrDefaultAsync(m => m.MaND == id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            return View(nguoiDungModel);
        }

        // POST: Admin/NguoiDung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguoiDungModel = await _context.NguoiDungs.FindAsync(id);
            _context.NguoiDungs.Remove(nguoiDungModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoiDungModelExists(int id)
        {
            return _context.NguoiDungs.Any(e => e.MaND == id);
        }
        public IActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DangNhap(NguoiDungModel member)
        {
                //Encryptor.Encryptor.MD5Hash(member.MatKhau);
                if (member.TaiKhoan != null && member.MatKhau != null)
                {
                member.MatKhau = Encryptor.Encryptor.MD5Hash(member.MatKhau);
                    var r = _context.NguoiDungs.Where(m => m.TaiKhoan == member.TaiKhoan && m.MatKhau == (member.MatKhau)).ToList();
                    if (r.Count == 0)
                    {
                        return View("DangNhap");
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

                            var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Index", area = "" });
                            return Redirect(urlAdmin);

                        }
                    }
                }
            return View();
        }
    }
}
