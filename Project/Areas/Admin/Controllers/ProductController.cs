using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Common.Data;
using Common.Model;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using X.PagedList;
using System.Linq.Dynamic.Core;
using Common.Service.Interface;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseController
    {
        private readonly ProjectDPContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IProduct _iproduct;
        public ProductController(ProjectDPContext context, IWebHostEnvironment webHostEnvironment,IProduct iproduct)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
            _iproduct = iproduct;
        }

        [HttpGet]
        // GET: /Link/
        public IActionResult Index(int? size, int? page, string Search,string sort)
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
            var links = from l in _context.products
                        where l.Status==true
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
                links = links.Where(x => x.Name.Contains(Search));
                //ViewBag.totalSpSearch = links.Count();
                ViewBag.posts = links.ToPagedList(pageNumber, pageSize);
            }         

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            //return View();
            return View(links.OrderByDescending(x => x.CreatedOn).ToPagedList(pageNumber, pageSize));
        }
        public IActionResult TrashBin(int? size, int? page, string Search, string sort)
        {
            ViewBag.searchValue = Search;
            ViewBag.page = page;
            // 1. Tạo list pageSize để người dùng có thể chọn xem để phân trang
            // Bạn có thể thêm bớt tùy ý --- dammio.com
            var links = from l in _context.products
                        where l.Status == false
                        select l;
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
                //ViewBag.totalSpSearch = links.Count();
                ViewBag.posts = links.ToPagedList(pageNumber, pageSize);
            }

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            //return View();
            return View(links.OrderByDescending(x => x.CreatedOn).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public JsonResult ListName(string q)
        {
            var data = _iproduct.ListName(q);
            return Json(new
            {
                data = data,
                status = true
            });
        }
        [HttpGet]
        public JsonResult ListNametb(string q)
        {
            var data = _iproduct.ListName(q);
            return Json(new
            {
                data = data,
                status = false
            });
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
            var product = _context.products.Find(id);
            product.Status = !product.Status;
            _context.SaveChanges();
            return product.Status;
        }
        // GET: Admin/Product/Details/5
        public IActionResult Details(string slug)
        {
            if (slug == null)
            {
                return NotFound();
            }

            var productModel = _iproduct.DetailProduct(slug);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // GET: Admin/Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModel product)
        {
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Name", product.CategoryId);

            if (ModelState.IsValid)
            {
                product.CreatedOn = DateTime.Now;
                product.Status = true;
                product.Slug = product.Name.ToLower().Replace(" ", "-");

                var slug = await _context.products.FirstOrDefaultAsync(x => x.Slug == product.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Sản phẩm đã có.");
                    return View(product);
                }

                string imageName = "noimage.jpg";
                if (product.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(webHostEnvironment.WebRootPath, "img/sanpham");
                    imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                }

                product.Image = imageName;

                _context.Add(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Thêm sản phẩm thành công!";

                return RedirectToAction("Index");
            }

            return View(product);
        }
        // GET: Admin/Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ProductModel product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Name", product.CategoryId);


            return View(product);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductModel product)
        {
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Name", product.CategoryId);


            if (ModelState.IsValid)
            {
                product.CreatedOn = product.CreatedOn;
                product.Status = true;
                product.Slug = product.Name.ToLower().Replace(" ", "-");

                var slug = await _context.products.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Slug == product.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Sản phẩm đã có.");
                    return View(product);
                }

                if (product.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(webHostEnvironment.WebRootPath, "img/sanpham");
                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    product.Image = imageName;
                }

                _context.Update(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Chỉnh sửa sản phẩm thành công!";

                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            ProductModel product = await _context.products.FindAsync(id);

            if (product == null)
            {
                TempData["Error"] = "Không có sản phẩm để xóa!";
            }
            else
            {
                //if (!string.Equals(product.Image, "noimage.jpg"))
                //{
                //    string uploadsDir = Path.Combine(webHostEnvironment.WebRootPath, "img/sanpham");
                //    //string oldImagePath = Path.Combine(uploadsDir, product.Image);
                //    //if (System.IO.File.Exists(oldImagePath))
                //    //{
                //    //    System.IO.File.Delete(oldImagePath);
                //    //}
                //}
                _context.products.Remove(product);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Đã xóa sản phẩm thành công!";
            }

            return RedirectToAction("Index");
        }

        // POST: Admin/Product/Delete/5
        private bool ProductModelExists(int id)
        {
            return _context.products.Any(e => e.Id == id);
        }
    }
}
