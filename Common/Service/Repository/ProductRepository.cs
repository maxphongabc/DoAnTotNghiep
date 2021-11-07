using Common.Data;
using Common.Model;
using Common.Service.Interface;
using Common.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Repository
{
    public class ProductRepository:IProduct
    {
        private readonly ProjectDPContext _context;
        public ProductRepository(ProjectDPContext context, IConfiguration configuration)
        {
            _context = context;

        }
        public List<ProductViewModel> ListProductCate(string slug)
        {
            var product = (from p in _context.products
                           join c in _context.categories on p.CategoryId equals c.Id
                           where c.Slug == slug
                           select new ProductViewModel
                           {
                               ProductId = p.Id,
                               Name = p.Name,
                               Slug = p.Slug,
                               CategoryId = c.Id,
                               Image = p.Image,
                               Description = p.Description,
                               System = p.System,
                               Price = p.Price,
                               Quantity = p.Quantity,
                               Model = p.Model,
                               NameCate = c.Name,
                               SlugCate = c.Slug
                           });
            return product.ToList();
        }
        public ProductViewModel DetailProduct(string slug)
        {
            var product = (from p in _context.products
                           join c in _context.categories on p.CategoryId equals c.Id
                           where p.Slug == slug
                           select new ProductViewModel
                           {
                               ProductId = p.Id,
                               Name = p.Name,
                               Slug = p.Slug,
                               CategoryId = c.Id,
                               Image = p.Image,
                               Description = p.Description,
                               System = p.System,
                               Price = p.Price,
                               Quantity = p.Quantity,
                               Model = p.Model,
                               NameCate = c.Name,
                               Status=p.Status,
                               SlugCate = c.Slug
                           });
            return product.FirstOrDefault();
        }
        public List<ProductViewModel> ListAll()
        {

            var product = (from p in _context.products
                           join c in _context.categories on p.CategoryId equals c.Id
                           select new ProductViewModel
                           {
                               ProductId = p.Id,
                               Name = p.Name,
                               Slug = p.Slug,
                               CategoryId = c.Id,
                               Image = p.Image,
                               Description = p.Description,
                               System = p.System,
                               Price = p.Price,
                               Quantity = p.Quantity,
                               Model = p.Model,
                               NameCate = c.Name,
                               SlugCate = c.Slug
                           });
            return product.ToList();
        }
        public List<ProductModel> ListRelatedProduct(int id)
        {
            var product = _context.products.Find(id);
            return _context.products.Where(x => x.Id != id && x.CategoryId == product.CategoryId).ToList();
        }
        public List<CommentProductViewModel> ListComment(int productId)
        {
            var comment = (from c in _context.commentsproduct
                           join p in _context.products on c.ProductId equals p.Id
                           join u in _context.user on c.UserId equals u.Id
                           where p.Id == productId
                           select new CommentProductViewModel {
                           ProductId = p.Id,
                           CommentId = c.Id,
                           CreateOn = c.CreateOn,
                           UserId = u.Id,
                           UserImage = u.Avarta,
                           UserName = u.UserName,
                           Image = p.Image,
                           Content = c.Content
                           });
            return comment.ToList();
        }
        public List<CommentProductViewModel> ListCommentAdmin()
        {
            var comment = (from c in _context.commentsproduct
                           orderby c.Id
                           join p in _context.products on c.ProductId equals p.Id
                           join u in _context.user on c.UserId equals u.Id
                           select new CommentProductViewModel
                           {
                               ProductId = p.Id,
                               CommentId = c.Id,
                               CreateOn = c.CreateOn,
                               UserId = u.Id,
                               UserImage = u.Avarta,
                               UserName = u.UserName,
                               ProductName = p.Name,
                               Image = p.Image,
                               Content = c.Content
                           });
            comment.OrderByDescending(x => x.CreateOn);
            return comment.ToList();
        }
        public List<ProductViewModel> ListWishList(int userId)
       {
            var wishlist = (from w in _context.wistlists
                            join p in _context.products on w.ProductId equals p.Id
                            join u in _context.user on w.UserId equals u.Id
                            where u.Id == userId
                            select new ProductViewModel {
                                ProductId = p.Id,
                                UserId = u.Id,
                                Name = p.Name,
                                Image = p.Image                  
                            });
            return wishlist.ToList();
        }
        public List<string> ListName(string keyword)
        {
            return _context.products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }
        public bool CheckName(string name)
        {
            return _context.products.Count(x => x.Name == name) > 0;
        }
        public  CommentProductViewModel CommentId(int? cmtId)
        {
            var comment = (from c in _context.commentsproduct
                           join p in _context.products on c.ProductId equals p.Id
                           join u in _context.user on c.UserId equals u.Id
                           where c.Id == cmtId
                           select new CommentProductViewModel
                           {
                               ProductId = p.Id,
                               CommentId = c.Id,
                               CreateOn = c.CreateOn,
                               UserId = u.Id,
                               UserImage = u.Avarta,
                               ProductName = p.Name,
                               UserName = u.UserName,
                               Image = p.Image,
                               Content = c.Content
                           });
            return comment.FirstOrDefault();
        }
    }
}
