using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Common.Data;
using Common.Model;
using X.PagedList;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : BaseController
    {
        private readonly ProjectDPContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BlogController(ProjectDPContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Blog
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
            items.Add(new SelectListItem { Text = "200", Value = "200" });
            // 1.1. Giữ trạng thái kích thước trang được chọn trên DropDownList
            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }
            var links = from l in _context.blogs
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
                links = links.Where(x => x.Title.Contains(Search));
            }
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));
        }
        // GET: Admin/Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogModel = await _context.blogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogModel == null)
            {
                return NotFound();
            }

            return View(blogModel);
        }

        // GET: Admin/Blog/Create
        public IActionResult Create()
        {
            ViewData["Category_PostId"] = new SelectList(_context.category_Posts, "Id", "Name");
            return View();
        }

        // POST: Admin/Blog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogModel blog)
        {
            ViewData["Category_PostId"] = new SelectList(_context.category_Posts, "Id", "Name");
            string a = HttpContext.Session.GetString("Admin");
            UserModel user = JsonConvert.DeserializeObject<UserModel>(a);
            if (ModelState.IsValid)
            {
                blog.PostedDate = DateTime.Now;
                blog.Status = true;
                blog.Slug = blog.Title.ToLower().Replace(" ", "-");
                blog.UserId = user.Id;
                var slug = await _context.products.FirstOrDefaultAsync(x => x.Slug == blog.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Tiêu đề bài viết đã có.");
                    return View(blog);
                }

                string imageName = "noimage.jpg";
                if (blog.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(webHostEnvironment.WebRootPath, "img/blogs");
                    imageName = Guid.NewGuid().ToString() + "_" + blog.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await blog.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                }
                blog.Image = imageName;
                _context.Add(blog);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Thêm bài viết thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Admin/Blog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogModel = await _context.blogs.FindAsync(id);
            if (blogModel == null)
            {
                return NotFound();
            }
            ViewData["Category_PostId"] = new SelectList(_context.category_Posts, "Id", "Name");
            return View(blogModel);
        }

        // POST: Admin/Blog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogModel blogModel)
        {
            ViewData["Category_PostId"] = new SelectList(_context.category_Posts, "Id", "Name");
            if (id != blogModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    blogModel.PostedDate = blogModel.PostedDate;
                    blogModel.Status = true;
                    blogModel.Slug = blogModel.Title.ToLower().Replace(" ", "-");
                    _context.Update(blogModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogModelExists(blogModel.Id))
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
            return View(blogModel);
        }

        // GET: Admin/Blog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogModel = await _context.blogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogModel == null)
            {
                return NotFound();
            }

            return View(blogModel);
        }

        // POST: Admin/Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogModel = await _context.blogs.FindAsync(id);
            _context.blogs.Remove(blogModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogModelExists(int id)
        {
            return _context.blogs.Any(e => e.Id == id);
        }
    }
}
