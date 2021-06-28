using caothang.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Models
{
    public class GioHang
    {
        public SanPhamModel sanpham { get; set; }
        public int Quaility { get; set; }
        public int Total { get; set; }

    }
}
