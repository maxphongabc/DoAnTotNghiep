using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class ChiTietHoaDonModel
    {
        [Key]
        [Display(Name ="Mã CTHD")]
        public int MaCTHD { get; set; }
        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Mã HD")]
        public int MaHD { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name ="Mã SP")]
        public int MaSP { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name ="Số lượng")]
        public int SoLuong { get; set; }
        public ICollection<HoaDonModel> hoaDonModels { get; set; }
        public ICollection<LoaiSanPhamModel> loaiSanPhamModels { get; set; }
    }
}
