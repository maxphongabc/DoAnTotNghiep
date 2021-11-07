using Common.Data;
using Common.Model;
using Common.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Project.Infratructure;
using X.PagedList;
using Newtonsoft.Json;

namespace Project.Controllers
{
    public class BlogController : Controller
    {
        private readonly ProjectDPContext _context;
        private readonly IBlog _iblog;
        public BlogController(ProjectDPContext context,IBlog iblog)
        {
            _context = context;
            _iblog = iblog;
        }
        public IActionResult Index(int? size, int? page)
        {
            ViewBag.page = page;

            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại
            int pageSize = (size ?? 5);
            int pageNumber = (page ?? 1);
            var blog = _iblog.ListAll();
            return View(blog.ToPagedList(pageNumber, pageSize));
        }
        public IActionResult Details(string slug)
        {

            var blog = _iblog.DetailsBlog(slug);
            BlogModel cate = _context.blogs.Where(x => x.Slug == slug).FirstOrDefault();
            ViewBag.ListRelatedBlog = _iblog.ListRelatedBlog(cate.Id);
            ViewBag.BlogId = cate.Id;
            if (blog == null)
            {
                return NotFound();
            }
            ViewBag.Comment = _iblog.ListComment(cate.Id);
            return View(blog);
        }
        public IActionResult BlogByCate(string slug, int? size, int? page)
        {
            ViewBag.page = page;

            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại
            int pageSize = (size ?? 5);
            int pageNumber = (page ?? 1);
            var blog = _iblog.ListBlogCate(slug);
            Category_PostModel cate = _context.category_Posts.Where(x => x.Slug == slug).FirstOrDefault();
            ViewBag.Namecate = cate.Name;
            if (blog == null)
            {
                return NotFound();
            }
            ViewBag.Name = cate.Name;
            return View(blog.ToPagedList(pageNumber, pageSize));
        }
        public const string USER = "user";
        [HttpPost]
        public IActionResult AddComment(int BlogId, string Comment)
        {
            var sessionUser = HttpContext.Session.GetString(USER);
            if (sessionUser == null)
            {
                var urlAdmin = Url.RouteUrl(new { controller = "Home", action = "Login" });
                return Redirect(urlAdmin);
            }
            CommentBlogModel cmt = new CommentBlogModel();
            UserModel user = JsonConvert.DeserializeObject<UserModel>(sessionUser);
            var blog = _context.blogs.Where(x => x.Id == BlogId).FirstOrDefault();

            if (user != null && blog != null)
            {
                cmt.CreateOn = DateTime.Now;
                cmt.BlogId = BlogId;
                cmt.UserId = user.Id;
                cmt.Content = Comment;
                cmt.Status = true;
                _context.commentBlogs.Add(cmt);
                _context.SaveChanges();
            }
            return RedirectToAction("Details", "Blog", new { Slug = blog.Slug });
        }

    }
}
