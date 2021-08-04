using PagedList;
using Project.Areas.Admin.Models;
using Project.Data;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class ProductRepository
    {
        DPContext _context = null;

        public ProductRepository(DPContext context)
        {
            _context = context;
        }
        public List<ProductModel> ListProductPaging(int categoryId,ref int totalRecord,int pageIndex=1,int pageSize=2)
        {
            totalRecord = _context.products.Where(x => x.CategoryId == categoryId).Count();
            var model = _context.products.Where(x => x.CategoryId == categoryId).OrderByDescending(x => x.CreatedOn).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }
        public IEnumerable<ProductModel> ListAllPaging(string searchString, int page,int pageSize)
        {
            IQueryable<ProductModel> models = _context.products;
            if(!string.IsNullOrEmpty(searchString))
            {
                models = models.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            return models.OrderByDescending(x => x.CreatedOn).ToPagedList(page, pageSize);
        }
        //public List<ProductViewModel> Search(string Keyword,ref int totalRecord,int pageIndex=1,int pageSize=10)
        //{
        //    totalRecord = _context.products.Where(x => x.Name == Keyword).Count();
        //    var model =(from a in _context.products
        //                join b in )
        //}
    }
}
