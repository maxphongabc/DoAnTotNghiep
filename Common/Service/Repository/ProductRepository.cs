using Common.Data;
using Common.Model;
using Common.Service.Interface;
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
        public List<string> ListName(string keyword)
        {
            return _context.products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }
        public ProductModel ViewDetail(int id)
        {
            return _context.products.Find(id);
        }
    }
}
