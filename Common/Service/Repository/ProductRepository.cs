using Common.Data;
using Common.Model;
using Common.Service.Interface;
using Common.VIewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Repository
{
    public class ProductRepository:IProduct
    {
        private readonly ProjectDPContext _context = null;
        private readonly IConfiguration _iconfiguration;
        public ProductRepository(ProjectDPContext context,IConfiguration configuration)
        {
            _context = context;
            _iconfiguration = configuration;
        }
        public async Task<int> AddNewProduct(Product product)
        {
            var newProudct = new ProductModel()
            {
                Name = product.Name,
                Slug = product.Name.ToLower().Replace(" ", "-"),
                Description = product.Description,
                CategoryId = product.CategoryId,
                Quantity = product.Quantity,
                Price = product.Price,
                PriceOld = product.PriceOld,
                Image = product.Image,
                Status = true,
                CreatedOn = DateTime.Now
            };     
            await _context.products.AddAsync(newProudct);
            await _context.SaveChangesAsync();
            return newProudct.Id;
        }

        public async Task<int> UpdateProduct(int id, ProductModel model)
        {
            var product = new ProductModel()
            {
                Name = model.Name,
                Slug = model.Name.ToLower().Replace(" ", "-"),
                Description = model.Description,
                CategoryId = model.CategoryId,
                Quantity = model.Quantity,
                Price = model.Price,
                PriceOld = model.PriceOld,
                Image = model.Image,
                Status = true,
                CreatedOn = model.CreatedOn,
                UpdatedOn = DateTime.Now
            };
             _context.products.Update(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}
