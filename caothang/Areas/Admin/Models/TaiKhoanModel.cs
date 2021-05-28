using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class TaiKhoanModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        [StringLength(maximumLength: 200, ErrorMessage = "Độ dài không phù hợp", MinimumLength = 8)]
        [Display(Name="Tài Khoản")]
        public string TaiKhoan { get; set; }
        [StringLength(maximumLength: 200, ErrorMessage = "Độ dài không phù hợp", MinimumLength = 8)]
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }
        public string Img { get; set; }
        public bool PhanQuyen { get; set; }
        [ForeignKey("PhanQuyen")]
        public bool TrangThai { get; set; }
        public TaiKhoanModel()
        {
            TrangThai = true;
        }
    }
}
