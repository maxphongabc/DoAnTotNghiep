using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using caothang.Areas.Admin.Models;

namespace caothang.Data
{
    public class caothangContext : DbContext
    {
        public caothangContext (DbContextOptions<caothangContext> options)
            : base(options)
        {
        }

        public DbSet<caothang.Areas.Admin.Models.SanPhamModel> SanPhamModel { get; set; }

        public DbSet<caothang.Areas.Admin.Models.DangNhapModel> DangNhapModel { get; set; }

        public DbSet<caothang.Areas.Admin.Models.NhanVienModel> NhanVienModel { get; set; }

        public DbSet<caothang.Areas.Admin.Models.LoaiSanPhamModel> LoaiSanPhamModel { get; set; }

        public DbSet<caothang.Areas.Admin.Models.KhachHangModel> KhachHangModel { get; set; }

        public DbSet<caothang.Areas.Admin.Models.HoaDonModel> HoaDonModel { get; set; }

        public DbSet<caothang.Areas.Admin.Models.ChiTietHoaDonModel> ChiTietHoaDonModel { get; set; }
    }
}
