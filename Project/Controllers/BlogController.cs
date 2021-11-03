using Common.Data;
using Common.Model;
using Common.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using X.PagedList;

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
            if (blog == null)
            {
                return NotFound();
            }
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
       
    }
}
