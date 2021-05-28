using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class AdminModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [StringLength(maximumLength: 50, ErrorMessage = "Mật Khẩu Dài Hơn 8 Ký Tự", MinimumLength = 8)]
        [Display(Name = "Họ Và Tên")]
        public string HoTen { get; set; }

        [EmailAddress(ErrorMessage = "Vui Lòng Nhập Vào E-Mail Hợp Lệ")]
        [StringLength(maximumLength: 300, MinimumLength = 8)]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [StringLength(maximumLength: 300, ErrorMessage = "Địa chỉ không được quá 300 kí tự", MinimumLength = 8)]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [Display(Name = "Số Điện Thoại")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 10, ErrorMessage = "Độ dài không phù hợp", MinimumLength = 10)]
        public string DienThoai { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual TaiKhoanModel taikhoan { get; set; }
        public bool Status { get; set; }

        public AdminModel()
        {
            Status = true;
        }
    }
}
