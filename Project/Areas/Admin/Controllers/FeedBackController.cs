﻿using Common.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeedBackController : BaseController
    {
        private readonly ProjectDPContext _context;

        public FeedBackController(ProjectDPContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.feedbacks.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fb = await _context.feedbacks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fb == null)
            {
                return NotFound();
            }

            return View(fb);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesModel = await _context.feedbacks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolesModel == null)
            {
                return NotFound();
            }

            return View(rolesModel);
        }

        // POST: Admin/Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fb = await _context.feedbacks.FindAsync(id);
            _context.feedbacks.Remove(fb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = ChangeStatuss(id);
            return Json(new
            {
                status = result
            });
        }
        public bool ChangeStatuss(int id)
        {
            var cmt = _context.feedbacks.Find(id);
            cmt.Status = !cmt.Status;
            _context.SaveChanges();
            return cmt.Status;
        }
    }
}
