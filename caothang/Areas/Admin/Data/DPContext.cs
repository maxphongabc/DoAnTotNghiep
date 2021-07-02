using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using caothang.Areas.Admin.Models;
using caothang.Areas.Admin.Data;

namespace caothang.Data
{
    public class DPContext : DbContext
    {
        public DPContext(DbContextOptions<DPContext> options)
            : base(options)
        {
        }

        public DbSet<caothang.Areas.Admin.Models.ChiTietHoaDonModel> ChiTietHoaDons { get; set; }

        public DbSet<caothang.Areas.Admin.Models.HoaDonModel> HoaDons { get; set; }

        public DbSet<caothang.Areas.Admin.Models.LoaiSanPhamModel> LoaiSanPhams{ get; set; }

        public DbSet<caothang.Areas.Admin.Models.NguoiDungModel> NguoiDungs { get; set; }

        public DbSet<caothang.Areas.Admin.Models.PhanQuyenModel> PhanQuyens { get; set; }

        public DbSet<caothang.Areas.Admin.Models.SanPhamModel> SanPhams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
