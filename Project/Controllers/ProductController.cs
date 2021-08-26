using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class ProductController
    {
        private readonly ProjectDPContext _context;
        public ProductController(ProjectDPContext context)
        {
            _context = context;
        }

    }
}
