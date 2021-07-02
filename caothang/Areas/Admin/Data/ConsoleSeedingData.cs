using caothang.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Data
{
    public static class ConsoleSeedingData
    {
       
        public static void Seed (this ModelBuilder modelBuiler)
        {
            modelBuiler.Entity<PhanQuyenModel>().HasData(
                new PhanQuyenModel { MaQuyen = 1, TenQuyen = "Admin", TrangThai = true },
                new PhanQuyenModel { MaQuyen = 2, TenQuyen = "User", TrangThai = true }
                );
            modelBuiler.Entity<LoaiSanPhamModel>().HasData(
                new LoaiSanPhamModel { MaLSP=1,TenLoaiSP="PlayStation",TrangThai=true},
                new LoaiSanPhamModel { MaLSP=2,TenLoaiSP="Xbox",TrangThai=true},
                new LoaiSanPhamModel { MaLSP=3,TenLoaiSP="Nintendo",TrangThai=true}
                );
            modelBuiler.Entity<NguoiDungModel>().HasData(
                new NguoiDungModel { MaND=1,HoTen="Võ Thành Duy",DiaChi="115 Trần Xuân Soạn",DienThoai="0393030574",Email="Duyvo049@gmail.com",HinhAnh="user-1",TaiKhoan="vothanhduy",MatKhau= "25f9e794323b453885f5181f1b624d0b",TrangThai=true,MaQuyen=1 },
                new NguoiDungModel { MaND = 2, HoTen = "Lê Xuân Lộc", DiaChi = "115 Trần Xuân Soạn", DienThoai = "0393030574", Email = "leloc603@gmail.com", HinhAnh = "user-2", TaiKhoan = "lexuanloc", MatKhau = "25f9e794323b453885f5181f1b624d0b", TrangThai = true, MaQuyen = 2 }
                );
            modelBuiler.Entity<SanPhamModel>().HasData(
                new SanPhamModel { MaSP = 1, MaLSP = 1, TenSP = "PS4 Pro 2nd hand", HinhAnh = " PS4 Pro 2nd hand.jpg", DonGia = 299, SoLuong = 50, MoTa = "Đẹp", TrangThai = true },
                new SanPhamModel { MaSP = 2, MaLSP = 1, TenSP = "Sony PS4 Slim Days Of Play 2019 Limited Edition", HinhAnh = "Sony PS4 Slim Days Of Play 2019 Limited Edition.jpg", DonGia = 39, SoLuong = 50, MoTa = "Đẹp", TrangThai = true },
                new SanPhamModel { MaSP = 3, MaLSP = 1, TenSP = "Máy PS4 Slim 1TB", HinhAnh = "Máy PS4 Slim 1TB.jpg", DonGia = 39, SoLuong = 50, MoTa = "Đẹp", TrangThai = true },
                new SanPhamModel { MaSP = 4, MaLSP = 1, TenSP = "Máy PS4 Pro The Last Of Us 2 Limited Edition", HinhAnh = "Máy PS4 Pro The Last Of Us 2 Limited Edition.jpg", DonGia = 39, SoLuong = 50, MoTa = "Đẹp", TrangThai = true },
                new SanPhamModel { MaSP = 5, MaLSP = 2, TenSP = "Xbox Series S", HinhAnh = " Xbox Series S.jpg", DonGia = 299, SoLuong = 50, MoTa = "Đẹp", TrangThai = true },
                new SanPhamModel { MaSP = 6, MaLSP = 2, TenSP = "Xbox Series X", HinhAnh = " Xbox Series X.jpg", DonGia = 299, SoLuong = 50, MoTa = "Đẹp", TrangThai = true },                 
                new SanPhamModel { MaSP = 7, MaLSP = 2, TenSP = "Xbox Wireless Adapter for Windows 10", HinhAnh = " Xbox Wireless Adapter for Windows 10.jpg", DonGia = 299, SoLuong = 50, MoTa = "Đẹp", TrangThai = true },
                new SanPhamModel { MaSP = 8, MaLSP = 2, TenSP = "Tay Cầm Xbox One S Wireless Minecraft Creeper", HinhAnh = " Tay Cầm Xbox One S Wireless Minecraft Creeper.jpg", DonGia = 299, SoLuong = 50, MoTa = "Đẹp", TrangThai = true },
                new SanPhamModel { MaSP = 9, MaLSP = 3, TenSP = "Nintendo Switch - Mario Red & Blue Edition", HinhAnh = "Nintendo Switch - Mario Red & Blue Edition.jpg", DonGia = 299, SoLuong = 50, MoTa = "Đẹp", TrangThai = true },
                new SanPhamModel { MaSP = 10, MaLSP = 3, TenSP = "Nintendo Switch - Monster Hunter Rise Edition", HinhAnh = " Nintendo Switch - Monster Hunter Rise Edition.jpg", DonGia = 299, SoLuong = 50, MoTa = "Đẹp", TrangThai = true },
                new SanPhamModel { MaSP = 11, MaLSP = 3, TenSP = "Máy Nintendo Switch Lite - Màu Turquoise", HinhAnh = " Máy Nintendo Switch Lite - Màu Turquoise.jpg", DonGia = 299, SoLuong = 50, MoTa = "Đẹp", TrangThai = true },
                new SanPhamModel { MaSP = 12, MaLSP = 3, TenSP = "Máy Nintendo Switch Fortnite Special Edition", HinhAnh = " Máy Nintendo Switch Fortnite Special Edition.jpg", DonGia = 299, SoLuong = 50, MoTa = "Đẹp", TrangThai = true }
                );
        }
    }
}
