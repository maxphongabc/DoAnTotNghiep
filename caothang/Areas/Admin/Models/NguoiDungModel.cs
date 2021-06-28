using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class NguoiDungModel
    {
        [Key]
        [Display(Name = "Mã ND")]
        public int MaND { get; set; }
        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [StringLength(maximumLength: 50, ErrorMessage = "Tên của bạn quá ngắn ", MinimumLength = 8)]
        [Display(Name = "Họ Và Tên")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [StringLength(maximumLength: 300, ErrorMessage = "Địa chỉ không được quá 300 kí tự", MinimumLength = 8)]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [Display(Name = "Số Điện Thoại")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 10, ErrorMessage = "Độ dài không phù hợp", MinimumLength = 10)]
        public string DienThoai { get; set; }
        [EmailAddress(ErrorMessage = "Không được bỏ trống")]
        [StringLength(maximumLength: 300, MinimumLength = 8)]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        [Display(Name ="Hình Ảnh")]
        public string HinhAnh { get; set; }
        [Required(ErrorMessage = "Nhập Đầy Đủ Thông Tin")]
        [StringLength(maximumLength: 200, ErrorMessage = "Độ dài không phù hợp", MinimumLength = 8)]
        [Display(Name = "Tài Khoản")]
        public string TaiKhoan { get; set; }
        [StringLength(maximumLength: 200, ErrorMessage = "Độ dài không phù hợp", MinimumLength = 8)]
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }
        [Display(Name = "Trạng Thái")]
        public bool TrangThai { get; set; }
        public int MaQuyen { get; set; }
        public NguoiDungModel()
        {
            TrangThai = true;
        }
        [ForeignKey("MaQuyen")]
        public virtual PhanQuyenModel PhanQuyens { get; set; }
        public ICollection<HoaDonModel> hoaDons { get; set; }
    }
}
