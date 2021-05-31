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
                name: "PhanQuyenModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyenModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonModel",
                columns: table => new
                {
                    MaHD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaND = table.Column<int>(nullable: false),
                    MaSP = table.Column<int>(nullable: false),
                    TenSP = table.Column<string>(nullable: false),
                    NgayLapHD = table.Column<string>(nullable: true),
                    NgayNhanHang = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false),
                    ChiTietHoaDonModelMaCTHD = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonModel", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HoaDonModel_ChiTietHoaDonModel_ChiTietHoaDonModelMaCTHD",
                        column: x => x.ChiTietHoaDonModelMaCTHD,
                        principalTable: "ChiTietHoaDonModel",
                        principalColumn: "MaCTHD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPhamModel",
                columns: table => new
                {
                    MaLSP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiSP = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false),
                    ChiTietHoaDonModelMaCTHD = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPhamModel", x => x.MaLSP);
                    table.ForeignKey(
                        name: "FK_LoaiSanPhamModel_ChiTietHoaDonModel_ChiTietHoaDonModelMaCTHD",
                        column: x => x.ChiTietHoaDonModelMaCTHD,
                        principalTable: "ChiTietHoaDonModel",
                        principalColumn: "MaCTHD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoanModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoan = table.Column<string>(maxLength: 200, nullable: false),
                    MatKhau = table.Column<string>(maxLength: 200, nullable: true),
                    Img = table.Column<string>(nullable: true),
                    PhanQuyen = table.Column<bool>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false),
                    PhanQuyenModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoanModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaiKhoanModel_PhanQuyenModel_PhanQuyenModelId",
                        column: x => x.PhanQuyenModelId,
                        principalTable: "PhanQuyenModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SanPhamModel",
                columns: table => new
                {
                    MaSP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSP = table.Column<string>(maxLength: 80, nullable: false),
                    HinhAnh = table.Column<string>(nullable: true),
                    DonGia = table.Column<double>(nullable: false),
                    MoTa = table.Column<string>(nullable: true),
                    MaLSP = table.Column<int>(nullable: false),
                    LoaiSanPhamMaLSP = table.Column<int>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamModel", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_SanPhamModel_LoaiSanPhamModel_LoaiSanPhamMaLSP",
                        column: x => x.LoaiSanPhamMaLSP,
                        principalTable: "LoaiSanPhamModel",
                        principalColumn: "MaLSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdminModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 300, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 300, nullable: false),
                    DienThoai = table.Column<string>(maxLength: 10, nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminModel_TaiKhoanModel_IdUser",
                        column: x => x.IdUser,
                        principalTable: "TaiKhoanModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungModel",
                columns: table => new
                {
                    MaND = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(maxLength: 50, nullable: false),
                    GioiTinh = table.Column<bool>(nullable: false),
                    DiaChi = table.Column<string>(maxLength: 300, nullable: false),
                    DienThoai = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(maxLength: 300, nullable: true),
                    IdNguoiDung = table.Column<int>(nullable: false),
                    IdNnguoiDung = table.Column<int>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungModel", x => x.MaND);
                    table.ForeignKey(
                        name: "FK_NguoiDungModel_TaiKhoanModel_IdNnguoiDung",
                        column: x => x.IdNnguoiDung,
                        principalTable: "TaiKhoanModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminModel_IdUser",
                table: "AdminModel",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonModel_ChiTietHoaDonModelMaCTHD",
                table: "HoaDonModel",
                column: "ChiTietHoaDonModelMaCTHD");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPhamModel_ChiTietHoaDonModelMaCTHD",
                table: "LoaiSanPhamModel",
                column: "ChiTietHoaDonModelMaCTHD");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungModel_IdNnguoiDung",
                table: "NguoiDungModel",
                column: "IdNnguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamModel_LoaiSanPhamMaLSP",
                table: "SanPhamModel",
                column: "LoaiSanPhamMaLSP");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoanModel_PhanQuyenModelId",
                table: "TaiKhoanModel",
                column: "PhanQuyenModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminModel");

            migrationBuilder.DropTable(
                name: "HoaDonModel");

            migrationBuilder.DropTable(
                name: "NguoiDungModel");

            migrationBuilder.DropTable(
                name: "SanPhamModel");

            migrationBuilder.DropTable(
                name: "TaiKhoanModel");

            migrationBuilder.DropTable(
                name: "LoaiSanPhamModel");

            migrationBuilder.DropTable(
                name: "PhanQuyenModel");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDonModel");
        }
    }
}
