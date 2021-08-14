using Common.Data;
using Common.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service
{
    public class Product
    {
        private readonly DPContext _context;
        private IConfiguration iconfiguration;
        public Product(DPContext context)
        {
            _context = context;
        }
        public List<ProductModel> ListRelatedProduct(int id)
        {
            var product = _context.products.Find(id);
            return _context.products.Where(x => x.Id != id && x.CategoryId == product.CategoryId).ToList();
        }
        public async Task<ProductModel> GetSpById(int id)
        {
            return await _context.products.Where(x => x.Id == id)
                .Select(product => new ProductModel()
                {
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Image = product.Image,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Desciption = product.Desciption,
                    Status = product.Status

                }).FirstOrDefaultAsync();
        }
        public List<ProductViewModel> ListByCateId(int id, ref int totalRecord, int pageIndex = 1,int pageSize = 2)
        {
            totalRecord = _context.products.Where(x => x.CategoryId == id).Count();
            var model = (from a in _context.products
                         join b in _context.categories
                         on a.CategoryId equals b.Id
                         where a.CategoryId == id
                         select new
                         {
                             Id = a.Id,
                             Name = a.Name,
                             CategoryId = a.CategoryId,
                             Description = a.Desciption,
                             Image = a.Image,
                             Price=a.Price,
                             Quantity = a.Quantity
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             Id = x.Id,
                             Image= x.Image,
                             Catename = x.Name,
                             Price=x.Price
                         });
            model.OrderByDescending(x => x.CreatedOn).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
    }
}
