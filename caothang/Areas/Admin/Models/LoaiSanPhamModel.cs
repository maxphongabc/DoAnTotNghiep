﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class LoaiSanPhamModel
    {
        [Key]
        public int MaLSP { get; set; }
        [Display(Name ="Tên Loại Sản Phẩm")]
        public string TenLoaiSP { get; set; }
        public bool TrangThai { get; set; }
        public LoaiSanPhamModel()
        {
            TrangThai = true;
        }
    }
}
