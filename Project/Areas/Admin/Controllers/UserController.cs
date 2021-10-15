
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Data;
using Common.Model;
using Common.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : BaseController
    {
        private readonly ProjectDPContext _context;
        private readonly IUser _iuser;
        public UserController(ProjectDPContext context,IUser iuser)
        {
            _context = context;
            _iuser = iuser;
        }

        // GET: Admin/User
        public ActionResult Index(string Search, int page = 1, int pageSize = 2)
        {
            //var model = ListAllPaging(Search, page, pageSize);
            ViewBag.Search = Search;    
            var model = ListAllPaging(Search, page, pageSize);
            return View(model);

        }
        public IEnumerable<UserModel> ListAllPaging(string Search, int page, int pageSize)
        {
            IQueryable<UserModel> model = _context.user;
            if (!string.IsNullOrEmpty(Search))
            {
                model = model.Where(x => x.FullName.Contains(Search) || x.UserName.Contains(Search));
            }

            return model.OrderByDescending(x => x.CreatedOn).ToPagedList(page, pageSize);
        }
        // GET: Admin/User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.user
                .Include(u => u.roles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: Admin/User/Create
        public IActionResult Create()
        {
            ViewData["RolesId"] = new SelectList(_context.roles, "Id", "Name");
            return View();
        }

        // POST: Admin/User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RolesId,FullName,Address,Phone,Email,DateOfBirth,Avarta,UserName,PassWord,CreatedOn,UpdatedOn,Status")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
               
            }
            ViewData["RolesId"] = new SelectList(_context.roles, "Id", "Name", userModel.RolesId);
            return View(userModel);
        }

        // GET: Admin/User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.user.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            ViewData["RolesId"] = new SelectList(_context.roles, "Id", "Id", userModel.RolesId);
            return View(userModel);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RolesId,FullName,Address,Phone,Email,DateOfBirth,Avarta,UserName,PassWord,CreatedOn,UpdatedOn,Status")] UserModel userModel)
        {
            if (id != userModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.Id))
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
            ViewData["RolesId"] = new SelectList(_context.roles, "Id", "Id", userModel.RolesId);
            return View(userModel);
        }

        // GET: Admin/User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.user
                .Include(u => u.roles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModel = await _context.user.FindAsync(id);
            _context.user.Remove(userModel);
            SetAlert("Thêm thành công", "success");
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(int id)
        {
            return _context.user.Any(e => e.Id == id);
        }
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result= ChangeStatuss(id);
            return Json(new
            {
                status = result
            });
        }
        public bool ChangeStatuss(int id)
        {
            var user = _context.user.Find(id);
            user.Status = !user.Status;
            _context.SaveChanges();
            return user.Status;
        }
        [HttpGet]
        public JsonResult ListName(string q)
        {
            var data = _iuser.ListName(q);
            return Json(new
            {
                data = data,
                status = true
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
           _iuser.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
