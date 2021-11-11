using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Common.Data;
using Common.Model;
using X.PagedList;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Category_PostController : BaseController
    {
        private readonly ProjectDPContext _context;

        public Category_PostController(ProjectDPContext context)
        {
            _context = context;
        }

        // GET: Admin/Category_Post
        public IActionResult Index(int? size, int? page, string Search)
        {
            ViewBag.searchValue = Search;
            ViewBag.page = page;

            var links = from l in _context.category_Posts
                        select l;
            // 1.2. Tạo các biến ViewBag
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            // 2. Nếu page = null thì đặt lại là 1.
            page = page ?? 1; //if (page == null) page = 1;

            // 4. Tạo kích thước trang (pageSize), mặc định là 5.
            int pageSize = (size ?? 5);

            int pageNumber = (page ?? 1);
            if (!string.IsNullOrEmpty(Search))
            {
                links = links.Where(x => x.Name.Contains(Search));
            }
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Category_Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category_PostModel = await _context.category_Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category_PostModel == null)
            {
                return NotFound();
            }

            return View(category_PostModel);
        }

        // GET: Admin/Category_Post/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category_Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category_PostModel category_PostModel)
        {
            if (ModelState.IsValid)
            {
                category_PostModel.Status = true;
                category_PostModel.Slug = category_PostModel.Name.ToLower().Replace(" ", "-");

                var slug = await _context.products.FirstOrDefaultAsync(x => x.Slug == category_PostModel.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Thể loại bài viết đã có.");
                    return View(category_PostModel);
                }
                _context.Add(category_PostModel);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Thêm thể loại bài viết thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(category_PostModel);
        }

        // GET: Admin/Category_Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category_PostModel = await _context.category_Posts.FindAsync(id);
            if (category_PostModel == null)
            {
                return NotFound();
            }
            return View(category_PostModel);
        }

        // POST: Admin/Category_Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Slug")] Category_PostModel category_PostModel)
        {
            if (id != category_PostModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    category_PostModel.Status = true;
                    category_PostModel.Slug = category_PostModel.Name.ToLower().Replace(" ", "-");
                    var slug = await _context.category_Posts.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Slug == category_PostModel.Slug);
                    if (slug != null)
                    {
                        ModelState.AddModelError("", "Loại bài viết này đã có.");
                        return View(category_PostModel);
                    }
                    _context.Update(category_PostModel);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "chỉnh sửa thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Category_PostModelExists(category_PostModel.Id))
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
            return View(category_PostModel);
        }

        // GET: Admin/Category_Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category_PostModel = await _context.category_Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category_PostModel == null)
            {
                return NotFound();
            }

            return View(category_PostModel);
        }

        // POST: Admin/Category_Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category_PostModel = await _context.category_Posts.FindAsync(id);
            _context.category_Posts.Remove(category_PostModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Category_PostModelExists(int id)
        {
            return _context.category_Posts.Any(e => e.Id == id);
        }
    }
}
