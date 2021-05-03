using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class LoaiSanPham
    {
        [Key]
        public int MlSP { get; set; }
        public string TenLoaiSP { get; set; }
        public int TrangThai { get; set; }
    }
}
