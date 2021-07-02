﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using caothang.Data;

namespace caothang.Migrations
{
    [DbContext(typeof(DPContext))]
    partial class DPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("caothang.Areas.Admin.Models.ChiTietHoaDonModel", b =>
                {
                    b.Property<int>("MaCTHD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaHD")
                        .HasColumnType("int");

                    b.Property<int>("MaSP")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int?>("hoadonsMaHD")
                        .HasColumnType("int");

                    b.Property<int?>("sanphamsMaSP")
                        .HasColumnType("int");

                    b.HasKey("MaCTHD");

                    b.HasIndex("hoadonsMaHD");

                    b.HasIndex("sanphamsMaSP");

                    b.ToTable("ChiTietHoaDons");
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.HoaDonModel", b =>
                {
                    b.Property<int>("MaHD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaND")
                        .HasColumnType("int");

                    b.Property<int>("MaSP")
                        .HasColumnType("int");

                    b.Property<string>("NgayLapHD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NgayNhanHang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NguoiDungsMaND")
                        .HasColumnType("int");

                    b.Property<int?>("SanPhamsMaSP")
                        .HasColumnType("int");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaHD");

                    b.HasIndex("NguoiDungsMaND");

                    b.HasIndex("SanPhamsMaSP");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.LoaiSanPhamModel", b =>
                {
                    b.Property<int>("MaLSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenLoaiSP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaLSP");

                    b.ToTable("LoaiSanPhams");

                    b.HasData(
                        new
                        {
                            MaLSP = 1,
                            TenLoaiSP = "PlayStation",
                            TrangThai = true
                        },
                        new
                        {
                            MaLSP = 2,
                            TenLoaiSP = "Xbox",
                            TrangThai = true
                        },
                        new
                        {
                            MaLSP = 3,
                            TenLoaiSP = "Nintendo",
                            TrangThai = true
                        });
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.NguoiDungModel", b =>
                {
                    b.Property<int>("MaND")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("DienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("MaQuyen")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("TaiKhoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaND");

                    b.HasIndex("MaQuyen");

                    b.ToTable("NguoiDungs");

                    b.HasData(
                        new
                        {
                            MaND = 1,
                            DiaChi = "115 Trần Xuân Soạn",
                            DienThoai = "0393030574",
                            Email = "Duyvo049@gmail.com",
                            HinhAnh = "user-1",
                            HoTen = "Võ Thành Duy",
                            MaQuyen = 1,
                            MatKhau = "25f9e794323b453885f5181f1b624d0b",
                            TaiKhoan = "vothanhduy",
                            TrangThai = true
                        },
                        new
                        {
                            MaND = 2,
                            DiaChi = "115 Trần Xuân Soạn",
                            DienThoai = "0393030574",
                            Email = "leloc603@gmail.com",
                            HinhAnh = "user-2",
                            HoTen = "Lê Xuân Lộc",
                            MaQuyen = 2,
                            MatKhau = "25f9e794323b453885f5181f1b624d0b",
                            TaiKhoan = "lexuanloc",
                            TrangThai = true
                        });
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.PhanQuyenModel", b =>
                {
                    b.Property<int>("MaQuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenQuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaQuyen");

                    b.ToTable("PhanQuyens");

                    b.HasData(
                        new
                        {
                            MaQuyen = 1,
                            TenQuyen = "Admin",
                            TrangThai = true
                        },
                        new
                        {
                            MaQuyen = 2,
                            TenQuyen = "User",
                            TrangThai = true
                        });
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.SanPhamModel", b =>
                {
                    b.Property<int>("MaSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DonGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaLSP")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaSP");

                    b.HasIndex("MaLSP");

                    b.ToTable("SanPhams");

                    b.HasData(
                        new
                        {
                            MaSP = 1,
                            DonGia = 299m,
                            HinhAnh = " PS4 Pro 2nd hand.jpg",
                            MaLSP = 1,
                            MoTa = "Đẹp",
                            SoLuong = 50,
                            TenSP = "PS4 Pro 2nd hand",
                            TrangThai = true
                        },
                        new
                        {
                            MaSP = 2,
                            DonGia = 39m,
                            HinhAnh = "Sony PS4 Slim Days Of Play 2019 Limited Edition.jpg",
                            MaLSP = 1,
                            MoTa = "Đẹp",
                            SoLuong = 50,
                            TenSP = "Sony PS4 Slim Days Of Play 2019 Limited Edition",
                            TrangThai = true
                        },
                        new
                        {
                            MaSP = 3,
                            DonGia = 39m,
                            HinhAnh = "Máy PS4 Slim 1TB.jpg",
                            MaLSP = 1,
                            MoTa = "Đẹp",
                            SoLuong = 50,
                            TenSP = "Máy PS4 Slim 1TB",
                            TrangThai = true
                        },
                        new
                        {
                            MaSP = 4,
                            DonGia = 39m,
                            HinhAnh = "Máy PS4 Pro The Last Of Us 2 Limited Edition.jpg",
                            MaLSP = 1,
                            MoTa = "Đẹp",
                            SoLuong = 50,
                            TenSP = "Máy PS4 Pro The Last Of Us 2 Limited Edition",
                            TrangThai = true
                        },
                        new
                        {
                            MaSP = 5,
                            DonGia = 299m,
                            HinhAnh = " Xbox Series S.jpg",
                            MaLSP = 2,
                            MoTa = "Đẹp",
                            SoLuong = 50,
                            TenSP = "Xbox Series S",
                            TrangThai = true
                        },
                        new
                        {
                            MaSP = 6,
                            DonGia = 299m,
                            HinhAnh = " Xbox Series X.jpg",
                            MaLSP = 2,
                            MoTa = "Đẹp",
                            SoLuong = 50,
                            TenSP = "Xbox Series X",
                            TrangThai = true
                        },
                        new
                        {
                            MaSP = 7,
                            DonGia = 299m,
                            HinhAnh = " Xbox Wireless Adapter for Windows 10.jpg",
                            MaLSP = 2,
                            MoTa = "Đẹp",
                            SoLuong = 50,
                            TenSP = "Xbox Wireless Adapter for Windows 10",
                            TrangThai = true
                        },
                        new
                        {
                            MaSP = 8,
                            DonGia = 299m,
                            HinhAnh = " Tay Cầm Xbox One S Wireless Minecraft Creeper.jpg",
                            MaLSP = 2,
                            MoTa = "Đẹp",
                            SoLuong = 50,
                            TenSP = "Tay Cầm Xbox One S Wireless Minecraft Creeper",
                            TrangThai = true
                        },
                        new
                        {
                            MaSP = 9,
                            DonGia = 299m,
                            HinhAnh = "Nintendo Switch - Mario Red & Blue Edition.jpg",
                            MaLSP = 3,
                            MoTa = "Đẹp",
                            SoLuong = 50,
                            TenSP = "Nintendo Switch - Mario Red & Blue Edition",
                            TrangThai = true
                        },
                        new
                        {
                            MaSP = 10,
                            DonGia = 299m,
                            HinhAnh = " Nintendo Switch - Monster Hunter Rise Edition.jpg",
                            MaLSP = 3,
                            MoTa = "Đẹp",
                            SoLuong = 50,
                            TenSP = "Nintendo Switch - Monster Hunter Rise Edition",
                            TrangThai = true
                        },
                        new
                        {
                            MaSP = 11,
                            DonGia = 299m,
                            HinhAnh = " Máy Nintendo Switch Lite - Màu Turquoise.jpg",
                            MaLSP = 3,
                            MoTa = "Đẹp",
                            SoLuong = 50,
                            TenSP = "Máy Nintendo Switch Lite - Màu Turquoise",
                            TrangThai = true
                        },
                        new
                        {
                            MaSP = 12,
                            DonGia = 299m,
                            HinhAnh = " Máy Nintendo Switch Fortnite Special Edition.jpg",
                            MaLSP = 3,
                            MoTa = "Đẹp",
                            SoLuong = 50,
                            TenSP = "Máy Nintendo Switch Fortnite Special Edition",
                            TrangThai = true
                        });
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.ChiTietHoaDonModel", b =>
                {
                    b.HasOne("caothang.Areas.Admin.Models.HoaDonModel", "hoadons")
                        .WithMany("chiTietHoaDons")
                        .HasForeignKey("hoadonsMaHD");

                    b.HasOne("caothang.Areas.Admin.Models.SanPhamModel", "sanphams")
                        .WithMany("chiTietHoaDons")
                        .HasForeignKey("sanphamsMaSP");
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.HoaDonModel", b =>
                {
                    b.HasOne("caothang.Areas.Admin.Models.NguoiDungModel", "NguoiDungs")
                        .WithMany("hoaDons")
                        .HasForeignKey("NguoiDungsMaND");

                    b.HasOne("caothang.Areas.Admin.Models.SanPhamModel", "SanPhams")
                        .WithMany()
                        .HasForeignKey("SanPhamsMaSP");
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.NguoiDungModel", b =>
                {
                    b.HasOne("caothang.Areas.Admin.Models.PhanQuyenModel", "PhanQuyens")
                        .WithMany("nguoiDungs")
                        .HasForeignKey("MaQuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.SanPhamModel", b =>
                {
                    b.HasOne("caothang.Areas.Admin.Models.LoaiSanPhamModel", "malsp")
                        .WithMany("sanPhams")
                        .HasForeignKey("MaLSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}