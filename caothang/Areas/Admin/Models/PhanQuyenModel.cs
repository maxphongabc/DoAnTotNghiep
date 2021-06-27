using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace caothang.Areas.Admin.Models
{
    public class PhanQuyenModel
    {
        [Key]
        [Display(Name = "Mã Quyền")]
        public int MaQuyen { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống")]
        [Display(Name = "Tên Quyền")]
        public string TenQuyen { get; set; }
        [Display(Name = "Trạng thái")]
        public bool TrangThai { get; set; }
        public ICollection<NguoiDungModel> nguoiDungs { get; set; }
        public PhanQuyenModel()
        {
            TrangThai = true;
        }
    }
}
