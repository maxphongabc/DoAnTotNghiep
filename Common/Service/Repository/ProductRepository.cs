using Common.Data;
using Common.Model;
using Common.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Repository
{
    public class ProductRepository:IProduct
    {
        private readonly DPContext _context;
        public ProductRepository(DPContext context)
        {
            _context = context;
        }
        public List<ProductModel> ListRelatedProduct(int id)
        {
            var product = _context.products.Find(id);
            return _context.products.Where(x => x.Id != id && x.CategoryId == product.CategoryId).ToList();
        }
    }
}
