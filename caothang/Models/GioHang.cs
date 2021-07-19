using caothang.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Models
{
    public class GioHang
    {
        public ProductModel Product { get; set; }
        public int Quanlity { get; set; }
        public int Total { get; set; }
    }
}
