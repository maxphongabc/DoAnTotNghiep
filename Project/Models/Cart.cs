using Project.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Cart
    {
        public ProductModel Product { get; set; }
        public int Quanlity { get; set; }
        public int Total { get; set; }
    }
}
