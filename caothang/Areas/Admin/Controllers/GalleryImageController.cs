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
    public class GalleryImageController : Controller
    {
        private readonly DPContext _context;

        public GalleryImageController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/GalleryImage
        public async Task<IActionResult> Index()
        {
            return View(await _context.galleryImages.ToListAsync());
        }

        // GET: Admin/GalleryImage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryImageModel = await _context.galleryImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (galleryImageModel == null)
            {
                return NotFound();
            }

            return View(galleryImageModel);
        }

        // GET: Admin/GalleryImage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/GalleryImage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,ImageFirst,ImageSecond,ImageThird,CreatedOn,UpdatedOn,Status")] GalleryImageModel galleryImageModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(galleryImageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(galleryImageModel);
        }

        // GET: Admin/GalleryImage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryImageModel = await _context.galleryImages.FindAsync(id);
            if (galleryImageModel == null)
            {
                return NotFound();
            }
            return View(galleryImageModel);
        }

        // POST: Admin/GalleryImage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,ImageFirst,ImageSecond,ImageThird,CreatedOn,UpdatedOn,Status")] GalleryImageModel galleryImageModel)
        {
            if (id != galleryImageModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(galleryImageModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GalleryImageModelExists(galleryImageModel.Id))
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
            return View(galleryImageModel);
        }

        // GET: Admin/GalleryImage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryImageModel = await _context.galleryImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (galleryImageModel == null)
            {
                return NotFound();
            }

            return View(galleryImageModel);
        }

        // POST: Admin/GalleryImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var galleryImageModel = await _context.galleryImages.FindAsync(id);
            _context.galleryImages.Remove(galleryImageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GalleryImageModelExists(int id)
        {
            return _context.galleryImages.Any(e => e.Id == id);
        }
    }
}
