using Common.Data;
using Common.Model;
using Common.Service.Interface;
using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Repository
{
    public class BlogRepository: IBlog
    {
        private readonly ProjectDPContext _context;
        public BlogRepository(ProjectDPContext context)
        {
            _context = context;
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
                            UserImage = u.Avarta,
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
        public List<CommentBlogViewModel> ListComment(int blogsId)
        {
            var comment = (from c in _context.commentBlogs
                           join b in _context.blogs on c.BlogId equals b.Id
                           join u in _context.user on c.UserId equals u.Id
                           where b.Id == blogsId
                           select new CommentBlogViewModel
                           {
                               BlogsId = b.Id,
                               CommentId = c.Id,
                               CreateOn = c.CreateOn,
                               UserId = u.Id,
                               UserImage = u.Avarta,
                               UserName = u.UserName,
                               Image = b.Image,
                               Content = c.Content
                           });
            return comment.ToList();
        }
    }
}
