using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class SanPhamModel
    {
        [Key]
        public int MaSP { get; set; }
        public int MaLSP { get; set; }
        public string TenSP { get; set; }
        public string HinhAnh { get; set; }
        public decimal DonGia { get; set; }
        public string ChiTietSP { get; set; }
        public int TrangThai { get; set; }
    }
}
