
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Common.Data;
using Common.Encryptor;
using Common.Model;
using Common.Service.Interface;
using Microsoft.AspNetCore.Hosting;
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
        private readonly INotyfService _notyf;
        private readonly IUser _iuser;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserController(ProjectDPContext context,IUser iuser, IWebHostEnvironment webHostEnvironment,INotyfService notyf)
        {
            _iuser = iuser;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _notyf = notyf;
        }

        // GET: Admin/User
        public IActionResult Index(int? size, int? page, string Search)
        {

            ViewBag.searchValue = Search;
            ViewBag.page = page;
            // 1. Tạo list pageSize để người dùng có thể chọn xem để phân trang
            // Bạn có thể thêm bớt tùy ý --- dammio.com
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "10", Value = "10" });
            items.Add(new SelectListItem { Text = "20", Value = "20" });
            // 1.1. Giữ trạng thái kích thước trang được chọn trên DropDownList
            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }
            var links = from l in _context.user
                        where l.Status == true && l.RolesId==2
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
            return View(links.OrderBy(s=>s.CreatedOn).ToPagedList(pageNumber, pageSize));
        }
        public IActionResult TrashBin(int? size, int? page, string Search)
        {

            ViewBag.searchValue = Search;
            ViewBag.page = page;
            // 1. Tạo list pageSize để người dùng có thể chọn xem để phân trang
            // Bạn có thể thêm bớt tùy ý --- dammio.com
           
            var links = from l in _context.user
                        where l.Status==false
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
                links = links.Where(x => x.FullName.Contains(Search) || x.UserName.Contains(Search));
            }
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.OrderBy(s => s.CreatedOn).ToPagedList(pageNumber, pageSize));
        }
        // GET: Admin/User/Details/5
        public IActionResult Details(int id)
        {
            var userModel = _iuser.ProfileUser(id);
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
        public async Task<IActionResult> Create(UserModel userModel)
        {
            ViewData["RolesId"] = new SelectList(_context.roles, "Id", "Name", userModel.RolesId);
            if (ModelState.IsValid)
            {

                if (_iuser.CheckUserName(userModel.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (_iuser.CheckEmail(userModel.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else if (_iuser.CheckPhone(userModel.Phone))
                {
                    ModelState.AddModelError("", "Số điện thoại này đã có người sủ dụng !");
                }
                else
                {
                    userModel.CreatedOn = DateTime.Now;
                    userModel.Status = true;
                    userModel.PassWord = Encryptor.MD5Hash(userModel.PassWord);
                    string imageName = "noimage.jpg";
                    if (userModel.ImageUpload != null)
                    {
                        string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "img/user");
                        imageName = Guid.NewGuid().ToString() + "_" + userModel.ImageUpload.FileName;
                        string filePath = Path.Combine(uploadsDir, imageName);
                        FileStream fs = new FileStream(filePath, FileMode.Create);
                        await userModel.ImageUpload.CopyToAsync(fs);
                        fs.Close();
                    }
                    userModel.Avarta = imageName;
                    _context.Add(userModel);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Đăng ký thành công!";
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ModelState.AddModelError("", "Đăng ký không thành công");
                return View("Create");
            }
            
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
            ViewData["RolesId"] = new SelectList(_context.roles, "Id", "Name");
            return View(userModel);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserModel userModel)
        {
            if (id != userModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                userModel.Status = true;
                userModel.PassWord = Encryptor.MD5Hash(userModel.PassWord);
                ViewData["RolesId"] = new SelectList(_context.roles, "Id", "Name");
                    var username = await _context.user.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.UserName == userModel.UserName);
                    var email = await _context.user.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Email == userModel.Email);
                    var phone = await _context.user.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Phone == userModel.Phone);
                    if (username != null)
                    {
                        ModelState.AddModelError("", "Tài khoản này đã có người dùng.");
                        return View(userModel);
                    }
                    else if (email != null)
                    {
                        ModelState.AddModelError("", "EMail này đã có người dùng.");
                        return View(userModel);
                    }
                    else if (phone != null)
                    {
                        ModelState.AddModelError("", "Số điện thoại này đã có người dùng.");
                        return View(userModel);
                    }

                    if (userModel.ImageUpload != null)
                    {
                        string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "img/user");
                        string imageName = Guid.NewGuid().ToString() + "_" + userModel.ImageUpload.FileName;
                        string filePath = Path.Combine(uploadsDir, imageName);
                        FileStream fs = new FileStream(filePath, FileMode.Create);
                        await userModel.ImageUpload.CopyToAsync(fs);
                        fs.Close();
                    userModel.Avarta = imageName;
                    }
                _context.Update(userModel);
                await _context.SaveChangesAsync();
                _notyf.Success("Chỉnh sửa thành công",3);
                return RedirectToAction(nameof(Index));
            }
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

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModel = await _context.user.FindAsync(id);
            _context.user.Remove(userModel);
            TempData["Success"] = "Đã xóa người dùng thành công!";
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
