
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Data;
using Common.Model;
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
        public UserController(ProjectDPContext context)
        {
            _context = context;
        }

        // GET: Admin/User
        public ActionResult Index(int? size, int? page, string Search)
        {

            ViewBag.searchValue = Search;
            ViewBag.page = page;
            // 1. Tạo list pageSize để người dùng có thể chọn xem để phân trang
            // Bạn có thể thêm bớt tùy ý --- dammio.com
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "10", Value = "10" });
            items.Add(new SelectListItem { Text = "20", Value = "20" });
            items.Add(new SelectListItem { Text = "25", Value = "25" });
            items.Add(new SelectListItem { Text = "50", Value = "50" });
            items.Add(new SelectListItem { Text = "100", Value = "100" });
            // 1.1. Giữ trạng thái kích thước trang được chọn trên DropDownList
            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }
            var links = from l in _context.user
                        select l;
            // 1.2. Tạo các biến ViewBag
            ViewBag.size = items; // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            // 2. Nếu page = null thì đặt lại là 1.
            page = page ?? 1; //if (page == null) page = 1;

            // 4. Tạo kích thước trang (pageSize), mặc định là 5.
            int pageSize = (size ?? 5);

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            if (!string.IsNullOrEmpty(Search))
            {
                links = links.Where(x => x.FullName.Contains(Search)||x.UserName.Contains(Search));
            }
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));
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
            TempData["Success"] = "Đã xóa sản phẩm thành công!";
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
       
    }
}
