using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Data;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using X.PagedList;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : BaseController
    {
        private readonly ProjectDPContext _context;

        public CategoryController(ProjectDPContext context)
        {
            _context = context;
        }

        // GET: Admin/Category
        public ActionResult Index(int? size, int? page, string Search)
        {

            ViewBag.searchValue = Search;
            ViewBag.page = page;
            // 1. Tạo list pageSize để người dùng có thể chọn xem để phân trang
            // Bạn có thể thêm bớt tùy ý --- dammio.com
            // 1.1. Giữ trạng thái kích thước trang được chọn trên DropDownList
            var links = from l in _context.categories
                        select l;
            // 1.2. Tạo các biến ViewBag
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
                links = links.Where(x => x.Name.Contains(Search));
            }
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));
        }
            // GET: Admin/Category/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
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
            var cate = _context.categories.Find(id);
            cate.Status = !cate.Status;
            _context.SaveChanges();
            return cate.Status;
        }
        // GET: Admin/Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                categoryModel.Status = true;
                categoryModel.Slug = categoryModel.Name.ToLower().Replace(" ", "-");

                var slug = await _context.products.FirstOrDefaultAsync(x => x.Slug == categoryModel.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Thể loại sản phẩm đã có.");
                    return View(categoryModel);
                }
                _context.Add(categoryModel);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Thêm thể loại sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(categoryModel);
        }

        // GET: Admin/Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.categories.FindAsync(id);
            if (categoryModel == null)
            {
                return NotFound();
            }
            return View(categoryModel);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,CategoryModel categoryModel)
        {
            if (id != categoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryModelExists(categoryModel.Id))
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
            return View(categoryModel);
        }

        // GET: Admin/Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryModel = await _context.categories.FindAsync(id);
            _context.categories.Remove(categoryModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryModelExists(int id)
        {
            return _context.categories.Any(e => e.Id == id);
        }
        public bool CheckName(string name)
        {
            return _context.categories.Count(x => x.Name == name) > 0;
        }
        
     
    }

}
