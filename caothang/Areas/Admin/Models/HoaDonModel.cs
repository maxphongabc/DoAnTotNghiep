using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class HoaDonModel
    {
        [Key]
        public int MaHD { get; set; }
        public int MaKH { get; set; }
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public DateTime NgayLapHD { get; set; }
        public DateTime NgayNhanHang { get; set; }
    }
}
