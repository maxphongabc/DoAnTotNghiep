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
    public class TaiKhoanController : Controller
    {
        private readonly caothangContext _context;

        public TaiKhoanController(caothangContext context)
        {
            _context = context;
        }

        // GET: Admin/TaiKhoan
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaiKhoanModel.ToListAsync());
        }

        // GET: Admin/TaiKhoan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoanModel = await _context.TaiKhoanModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taiKhoanModel == null)
            {
                return NotFound();
            }

            return View(taiKhoanModel);
        }

        // GET: Admin/TaiKhoan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TaiKhoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaiKhoan,MatKhau,Img,PhanQuyen,TrangThai")] TaiKhoanModel taiKhoanModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taiKhoanModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taiKhoanModel);
        }

        // GET: Admin/TaiKhoan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoanModel = await _context.TaiKhoanModel.FindAsync(id);
            if (taiKhoanModel == null)
            {
                return NotFound();
            }
            return View(taiKhoanModel);
        }

        // POST: Admin/TaiKhoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaiKhoan,MatKhau,Img,PhanQuyen,TrangThai")] TaiKhoanModel taiKhoanModel)
        {
            if (id != taiKhoanModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taiKhoanModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaiKhoanModelExists(taiKhoanModel.Id))
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
            return View(taiKhoanModel);
        }

        // GET: Admin/TaiKhoan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoanModel = await _context.TaiKhoanModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taiKhoanModel == null)
            {
                return NotFound();
            }

            return View(taiKhoanModel);
        }

        // POST: Admin/TaiKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taiKhoanModel = await _context.TaiKhoanModel.FindAsync(id);
            _context.TaiKhoanModel.Remove(taiKhoanModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaiKhoanModelExists(int id)
        {
            return _context.TaiKhoanModel.Any(e => e.Id == id);
        }
    }
}
