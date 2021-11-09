using Common.Data;
using Common.Service.Interface;
using Common.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Common.Service.Repository
{
    public class WishListRepository:IWishList
    {
        private readonly ProjectDPContext _context;
        public WishListRepository(ProjectDPContext context)
        {
            _context = context;
        }
        public List<ProductViewModel> ListAll(int id)
        {
            var wishlist = (from wh in _context.wistlists
                            join p in _context.products on wh.ProductId equals p.Id
                            join u in _context.user on wh.UserId equals u.Id
                            where u.Id == id
                            select new ProductViewModel
                            {
                                Name = p.Name,
                                ProductId=p.Id,
                                WishListId=wh.Id,
                                Image = p.Image,
                                Price = p.Price
                            });
            return wishlist.ToList();
        }
    }
}
