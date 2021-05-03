using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class DangNhap
    {
        [Key]
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public bool PhanQuyen { get; set; }
    }
}
