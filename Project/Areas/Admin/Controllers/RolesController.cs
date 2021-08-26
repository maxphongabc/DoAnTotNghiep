using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Data;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : BaseController
    {
        private readonly ProjectDPContext _context;

        public RolesController(ProjectDPContext context)
        {
            _context = context;
        }

        // GET: Admin/Roles
        public async Task<IActionResult> Index()
        {
            return View(await _context.roles.ToListAsync());
        }

        // GET: Admin/Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesModel = await _context.roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolesModel == null)
            {
                return NotFound();
            }

            return View(rolesModel);
        }

        // GET: Admin/Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status")] RolesModel rolesModel)
        {
            if (ModelState.IsValid)
            {
                if(CheckName(rolesModel.Name))
                {
                    ModelState.AddModelError("", "Tên quyền này đã có");
                }    
                _context.Add(rolesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rolesModel);
        }

        // GET: Admin/Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesModel = await _context.roles.FindAsync(id);
            if (rolesModel == null)
            {
                return NotFound();
            }
            return View(rolesModel);
        }

        // POST: Admin/Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status")] RolesModel rolesModel)
        {
            if (id != rolesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesModelExists(rolesModel.Id))
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
            return View(rolesModel);
        }

        // GET: Admin/Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesModel = await _context.roles
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
            var rolesModel = await _context.roles.FindAsync(id);
            _context.roles.Remove(rolesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolesModelExists(int id)
        {
            return _context.roles.Any(e => e.Id == id);
        }
        public bool CheckName(string name)
        {
            return _context.roles.Count(x => x.Name == name) > 0;
        }
    }
}
