using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class DangNhapViewModel
    {
        [Required(ErrorMessage = "Không được bỏ trống")]
        public string TaiKhoan { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        public bool GhiNho { get; set; }
        public string RequestPath { get; set; }
    }
}
