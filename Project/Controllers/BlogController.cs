using Common.Data;
using Common.Model;
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
        public BlogController(ProjectDPContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? size, int? page)
        {
            ViewBag.page = page;

            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại
            int pageSize = (size ?? 5);
            int pageNumber = (page ?? 1);
            var blog = ListAll();
            return View(blog.ToPagedList(pageNumber, pageSize));
        }
        public IActionResult Details(string slug)
        {

            var blog = DetailsBlog(slug);
            BlogModel cate = _context.blogs.Where(x => x.Slug == slug).FirstOrDefault();
            ViewBag.ListRelatedBlog = ListRelatedBlog(cate.Id);
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
            var blog = ListBlogCate(slug);
            Category_PostModel cate = _context.category_Posts.Where(x => x.Slug == slug).FirstOrDefault();
            ViewBag.Namecate = cate.Name;
            if (blog == null)
            {
                return NotFound();
            }
            ViewBag.Name = cate.Name;
            return View(blog.ToPagedList(pageNumber, pageSize));
        }
        public List<BlogViewModel> ListAll()
        {
            var blog = (from b in _context.blogs
                        join c in _context.category_Posts
                        on b.Category_PostId equals c.Id
                        join u in _context.user
                        on b.UserId equals u.Id
                        select new BlogViewModel
                        {
                            Title = b.Title,
                            Slug = b.Slug,
                            Status = b.Status,
                            Brief = b.Brief,
                            Content = b.Content,
                            Image = b.Image,
                            PostedDate = b.PostedDate,
                            UserName = u.UserName,
                            Cate_post = c.Name
                        });
            return blog.ToList();
        }
        
        public BlogViewModel DetailsBlog(string slug)
        {
            var blog = (from b in _context.blogs
                        join c in _context.category_Posts
                        on b.Category_PostId equals c.Id
                        join u in _context.user
                        on b.UserId equals u.Id
                        where b.Slug == slug
                        select new BlogViewModel
                        {
                            Title = b.Title,
                            Slug = b.Slug,
                            SlugCate = c.Slug,
                            Status = b.Status,
                            UserImage = u.Avarta,
                            Brief = b.Brief,
                            Content = b.Content,
                            Image = b.Image,
                            PostedDate = b.PostedDate,
                            UserName = u.UserName,
                            Cate_post = c.Name
                        });
            return blog.FirstOrDefault();
        }
      
        public List<BlogViewModel> ListBlogCate(string slug)
        {
            var blog = (from b in _context.blogs
                        join c in _context.category_Posts
                        on b.Category_PostId equals c.Id
                        join u in _context.user
                        on b.UserId equals u.Id
                        where c.Slug == slug
                        select new BlogViewModel
                        {
                            Title = b.Title,
                            Slug = b.Slug,
                            UserImage=u.Avarta,
                            Status = b.Status,
                            Brief = b.Brief,
                            Content = b.Content,
                            Image = b.Image,
                            PostedDate = b.PostedDate,
                            UserName = u.UserName,
                            Cate_post = c.Name
                        });
            return blog.ToList();
        }
        public List<BlogModel> ListRelatedBlog(int id)
        {
            var blog = _context.blogs.Find(id);
            return _context.blogs.Where(x => x.Id != id && x.Category_PostId == blog.Category_PostId).Take(2).ToList();
        }
    }
}
