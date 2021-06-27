﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using caothang.Data;

namespace caothang.Migrations
{
    [DbContext(typeof(caothangContext))]
    partial class caothangContextModelSnapshot : ModelSnapshot
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

                    b.HasKey("MaCTHD");

                    b.ToTable("ChiTietHoaDonModel");
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.HoaDonModel", b =>
                {
                    b.Property<int>("MaHD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChiTietHoaDonModelMaCTHD")
                        .HasColumnType("int");

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

                    b.HasIndex("ChiTietHoaDonModelMaCTHD");

                    b.HasIndex("NguoiDungsMaND");

                    b.HasIndex("SanPhamsMaSP");

                    b.ToTable("HoaDonModel");
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.LoaiSanPhamModel", b =>
                {
                    b.Property<int>("MaLSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChiTietHoaDonModelMaCTHD")
                        .HasColumnType("int");

                    b.Property<string>("TenLoaiSP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaLSP");

                    b.HasIndex("ChiTietHoaDonModelMaCTHD");

                    b.ToTable("LoaiSanPhamModel");
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

                    b.ToTable("NguoiDungModel");
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

                    b.ToTable("PhanQuyenModel");
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.SanPhamModel", b =>
                {
                    b.Property<int>("MaSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LoaiSanPhamMaLSP")
                        .HasColumnType("int");

                    b.Property<int>("MaLSP")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<int?>("chiTietHoaDonModelsMaCTHD")
                        .HasColumnType("int");

                    b.HasKey("MaSP");

                    b.HasIndex("LoaiSanPhamMaLSP");

                    b.HasIndex("chiTietHoaDonModelsMaCTHD");

                    b.ToTable("SanPhamModel");
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.HoaDonModel", b =>
                {
                    b.HasOne("caothang.Areas.Admin.Models.ChiTietHoaDonModel", null)
                        .WithMany("hoaDonModels")
                        .HasForeignKey("ChiTietHoaDonModelMaCTHD");

                    b.HasOne("caothang.Areas.Admin.Models.NguoiDungModel", "NguoiDungs")
                        .WithMany("hoaDonModels")
                        .HasForeignKey("NguoiDungsMaND");

                    b.HasOne("caothang.Areas.Admin.Models.SanPhamModel", "SanPhams")
                        .WithMany()
                        .HasForeignKey("SanPhamsMaSP");
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.LoaiSanPhamModel", b =>
                {
                    b.HasOne("caothang.Areas.Admin.Models.ChiTietHoaDonModel", null)
                        .WithMany("loaiSanPhamModels")
                        .HasForeignKey("ChiTietHoaDonModelMaCTHD");
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.NguoiDungModel", b =>
                {
                    b.HasOne("caothang.Areas.Admin.Models.PhanQuyenModel", "PhanQuyenModels")
                        .WithMany("nguoiDungModels")
                        .HasForeignKey("MaQuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("caothang.Areas.Admin.Models.SanPhamModel", b =>
                {
                    b.HasOne("caothang.Areas.Admin.Models.LoaiSanPhamModel", "LoaiSanPham")
                        .WithMany()
                        .HasForeignKey("LoaiSanPhamMaLSP");

                    b.HasOne("caothang.Areas.Admin.Models.ChiTietHoaDonModel", "chiTietHoaDonModels")
                        .WithMany("sanPhamModels")
                        .HasForeignKey("chiTietHoaDonModelsMaCTHD");
                });
#pragma warning restore 612, 618
        }
    }
}
