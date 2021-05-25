using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace caothang.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiTietHoaDonModel",
                columns: table => new
                {
                    MaCTHD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHD = table.Column<int>(nullable: false),
                    MaSP = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDonModel", x => x.MaCTHD);
                });

            migrationBuilder.CreateTable(
                name: "DangNhapModel",
                columns: table => new
                {
                    TaiKhoan = table.Column<string>(nullable: false),
                    MatKhau = table.Column<string>(nullable: true),
                    PhanQuyen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangNhapModel", x => x.TaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonModel",
                columns: table => new
                {
                    MaHD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKH = table.Column<int>(nullable: false),
                    MaSP = table.Column<int>(nullable: false),
                    TenSP = table.Column<string>(nullable: true),
                    NgayLapHD = table.Column<DateTime>(nullable: false),
                    NgayNhanHang = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonModel", x => x.MaHD);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangModel",
                columns: table => new
                {
                    MaKH = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTenKH = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    DienThoai = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangModel", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPhamModel",
                columns: table => new
                {
                    MaLSP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiSP = table.Column<string>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPhamModel", x => x.MaLSP);
                });

            migrationBuilder.CreateTable(
                name: "NhanVienModel",
                columns: table => new
                {
                    MaNV = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTenNV = table.Column<string>(nullable: true),
                    GioiTinh = table.Column<string>(nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    DiaChi = table.Column<string>(nullable: true),
                    DienThoai = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVienModel", x => x.MaNV);
                });

            migrationBuilder.CreateTable(
                name: "SanPhamModel",
                columns: table => new
                {
                    MaSP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLSP = table.Column<int>(nullable: false),
                    TenSP = table.Column<string>(nullable: true),
                    HinhAnh = table.Column<string>(nullable: true),
                    DonGia = table.Column<decimal>(nullable: false),
                    ChiTietSP = table.Column<string>(nullable: true),
                    TrangThai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamModel", x => x.MaSP);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDonModel");

            migrationBuilder.DropTable(
                name: "DangNhapModel");

            migrationBuilder.DropTable(
                name: "HoaDonModel");

            migrationBuilder.DropTable(
                name: "KhachHangModel");

            migrationBuilder.DropTable(
                name: "LoaiSanPhamModel");

            migrationBuilder.DropTable(
                name: "NhanVienModel");

            migrationBuilder.DropTable(
                name: "SanPhamModel");
        }
    }
}
