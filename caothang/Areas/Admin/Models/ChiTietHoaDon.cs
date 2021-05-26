using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int MaHD { get; set; }
        [Key]
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
    }
}
