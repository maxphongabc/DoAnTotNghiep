using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class SanPhamModel
    {
        [Key]
        [Display(Name = "Mã sản phẩm")]
        public int MaSP { get; set; }
        public int MaLSP { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name = "Tên sản phẩm")]
        [StringLength(maximumLength: 80, ErrorMessage = "Tên sản phẩm quá dài")]
        public string TenSP { get; set; }
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name = "Đơn giá")]
        public decimal DonGia { get; set; }
        [Required(ErrorMessage ="Không được bỏ trống" )]
        [Display(Name ="Số lượng" )]
        public int SoLuong { get; set; }
        
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [Display(Name = "Trạng Thái")]
        public bool TrangThai { get; set; }
        public SanPhamModel()
        {
            TrangThai = true;
        }
        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name = "Mã loại sản phẩm")]
        
        [ForeignKey("MaLSP")]
        public virtual LoaiSanPhamModel malsp { get; set; }
        public ICollection<ChiTietHoaDonModel> chiTietHoaDons { get; set; }
    }
}
