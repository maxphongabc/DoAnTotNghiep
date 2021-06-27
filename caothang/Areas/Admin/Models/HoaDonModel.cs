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
        [Display(Name = "Mã HD")]
        public int MaHD { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name = "Mã ND")]
        public int MaND { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name = "Mã SP")]
        public int MaSP { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name = "Tên sản phẩm")]
        public string TenSP { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Ngày lập HD")]
        public string NgayLapHD { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Ngày nhận hàng")]
        public string NgayNhanHang { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool TrangThai { get; set; }
        public HoaDonModel()
        {
            TrangThai = true;
        }
        public virtual SanPhamModel SanPhams { get; set; }
        public virtual NguoiDungModel NguoiDungs { get; set; }
        public ICollection<ChiTietHoaDonModel> chiTietHoaDons { get; set; }
    }
}
