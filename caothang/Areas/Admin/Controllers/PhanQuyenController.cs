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
    public class PhanQuyenController : Controller
    {
        private readonly DPContext _context;

        public PhanQuyenController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/PhanQuyen
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhanQuyens.ToListAsync());
        }

        // GET: Admin/PhanQuyen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanQuyenModel = await _context.PhanQuyens
                .FirstOrDefaultAsync(m => m.MaQuyen == id);
            if (phanQuyenModel == null)
            {
                return NotFound();
            }

            return View(phanQuyenModel);
        }

        // GET: Admin/PhanQuyen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhanQuyen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaQuyen,TenQuyen,TrangThai")] PhanQuyenModel phanQuyenModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phanQuyenModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phanQuyenModel);
        }

        // GET: Admin/PhanQuyen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanQuyenModel = await _context.PhanQuyens.FindAsync(id);
            if (phanQuyenModel == null)
            {
                return NotFound();
            }
            return View(phanQuyenModel);
        }

        // POST: Admin/PhanQuyen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaQuyen,TenQuyen,TrangThai")] PhanQuyenModel phanQuyenModel)
        {
            if (id != phanQuyenModel.MaQuyen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phanQuyenModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanQuyenModelExists(phanQuyenModel.MaQuyen))
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
            return View(phanQuyenModel);
        }

        // GET: Admin/PhanQuyen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanQuyenModel = await _context.PhanQuyens
                .FirstOrDefaultAsync(m => m.MaQuyen == id);
            if (phanQuyenModel == null)
            {
                return NotFound();
            }

            return View(phanQuyenModel);
        }

        // POST: Admin/PhanQuyen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phanQuyenModel = await _context.PhanQuyens.FindAsync(id);
            _context.PhanQuyens.Remove(phanQuyenModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhanQuyenModelExists(int id)
        {
            return _context.PhanQuyens.Any(e => e.MaQuyen == id);
        }
    }
}
