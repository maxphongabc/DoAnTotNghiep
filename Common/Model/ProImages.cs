using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class ProImages
    {
        public List<IFormFile> Images { get; set; }
        public ProductModel Product { get; set; }
    }
}
