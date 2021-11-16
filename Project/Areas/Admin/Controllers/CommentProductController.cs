using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common.Data;
using Common.Model;
using Common.Service.Interface;
using X.PagedList;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentProductController : BaseController
    {
        private readonly ProjectDPContext _context;
        private readonly IProduct _iproduct;
        private readonly INotyfService _notyf;

        public CommentProductController(ProjectDPContext context,IProduct iproduct, INotyfService notyf)
        {
            _context = context;
            _iproduct = iproduct;
            _notyf = notyf;
        }

        // GET: Admin/CommentProduct
        public IActionResult Index(int? size, int? page)
        {
            var comment = _iproduct.ListCommentAdmin();
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            // 2. Nếu page = null thì đặt lại là 1.
            page = page ?? 1; //if (page == null) page = 1;

            // 4. Tạo kích thước trang (pageSize), mặc định là 5.
            int pageSize = (size ?? 10);

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);
            return View(comment.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/CommentProduct/Details/5
        public IActionResult Details(int? id)
        {
            var cmt = _iproduct.CommentId(id);
            return View(cmt);
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
            var cmt = _context.commentsproduct.Find(id);
            cmt.Status = !cmt.Status;
            _context.SaveChanges();
            return cmt.Status;
        }
        // GET: Admin/CommentProduct/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            CommentProduct cmt = await _context.commentsproduct.FindAsync(id);

            if (cmt == null)
            {
                _notyf.Error("Không có bình luận nào để xóa", 5);
            }
            else
            {           
                _context.commentsproduct.Remove(cmt);
                await _context.SaveChangesAsync();
                _notyf.Success("Xóa bình luận thành công", 5);
            }
            return RedirectToAction("Index");
        }

        // POST: Admin/CommentProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commentProduct = await _context.commentsproduct.FindAsync(id);
            _context.commentsproduct.Remove(commentProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentProductExists(int id)
        {
            return _context.commentsproduct.Any(e => e.Id == id);
        }
    }
}
