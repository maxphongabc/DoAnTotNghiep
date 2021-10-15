using Common.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Areas.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProductControllers : ControllerBase
    {
        private readonly ProjectDPContext _context;
        public ApiProductControllers(ProjectDPContext context)
        {
            _context = context;
        }
      
    }
}
