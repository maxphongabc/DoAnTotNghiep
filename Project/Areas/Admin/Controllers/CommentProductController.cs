using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common.Data;
using Common.Model;
using Common.Service.Interface;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentProductController : BaseController
    {
        private readonly ProjectDPContext _context;
        private readonly IProduct _iproduct;

        public CommentProductController(ProjectDPContext context,IProduct iproduct)
        {
            _context = context;
            _iproduct = iproduct;
        }

        // GET: Admin/CommentProduct
        public IActionResult Index()
        {
            var comment = _iproduct.ListCommentAdmin();
            return View(comment);
        }

        // GET: Admin/CommentProduct/Details/5
        public IActionResult Details(int? id)
        {
            var cmt = _iproduct.CommentId(id);
            return View(cmt);
        }
        // GET: Admin/CommentProduct/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            CommentProduct cmt = await _context.commentsproduct.FindAsync(id);

            if (cmt == null)
            {
                TempData["Error"] = "Không có sản phẩm để xóa!";
            }
            else
            {           
                _context.commentsproduct.Remove(cmt);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã xóa sản phẩm thành công!";
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
