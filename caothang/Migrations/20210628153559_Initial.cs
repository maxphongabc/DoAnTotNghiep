using Microsoft.EntityFrameworkCore.Migrations;

namespace caothang.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiSanPhams",
                columns: table => new
                {
                    MaLSP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiSP = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPhams", x => x.MaLSP);
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyens",
                columns: table => new
                {
                    MaQuyen = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(nullable: false),
                    TrangThai = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyens", x => x.MaQuyen);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    MaSP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSP = table.Column<string>(maxLength: 80, nullable: false),
                    HinhAnh = table.Column<string>(nullable: true),
                    DonGia = table.Column<decimal>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    MoTa = table.Column<string>(nullable: true),
                    TrangThai = table.Column<bool>(nullable: false),
                    MaLSP = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiSanPhams_MaLSP",
                        column: x => x.MaLSP,
                        principalTable: "LoaiSanPhams",
                        principalColumn: "MaLSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    MaND = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(maxLength: 300, nullable: false),
                    DienThoai = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(maxLength: 300, nullable: true),
                    HinhAnh = table.Column<string>(nullable: true),
                    TaiKhoan = table.Column<string>(maxLength: 200, nullable: false),
                    MatKhau = table.Column<string>(maxLength: 200, nullable: true),
                    TrangThai = table.Column<bool>(nullable: false),
                    MaQuyen = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.MaND);
                    table.ForeignKey(
                        name: "FK_NguoiDungs_PhanQuyens_MaQuyen",
                        column: x => x.MaQuyen,
                        principalTable: "PhanQuyens",
                        principalColumn: "MaQuyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
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
                    SanPhamsMaSP = table.Column<int>(nullable: true),
                    NguoiDungsMaND = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HoaDons_NguoiDungs_NguoiDungsMaND",
                        column: x => x.NguoiDungsMaND,
                        principalTable: "NguoiDungs",
                        principalColumn: "MaND",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDons_SanPhams_SanPhamsMaSP",
                        column: x => x.SanPhamsMaSP,
                        principalTable: "SanPhams",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    MaCTHD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHD = table.Column<int>(nullable: false),
                    hoadonsMaHD = table.Column<int>(nullable: true),
                    MaSP = table.Column<int>(nullable: false),
                    sanphamsMaSP = table.Column<int>(nullable: true),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => x.MaCTHD);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_hoadonsMaHD",
                        column: x => x.hoadonsMaHD,
                        principalTable: "HoaDons",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_SanPhams_sanphamsMaSP",
                        column: x => x.sanphamsMaSP,
                        principalTable: "SanPhams",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_hoadonsMaHD",
                table: "ChiTietHoaDons",
                column: "hoadonsMaHD");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_sanphamsMaSP",
                table: "ChiTietHoaDons",
                column: "sanphamsMaSP");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_NguoiDungsMaND",
                table: "HoaDons",
                column: "NguoiDungsMaND");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_SanPhamsMaSP",
                table: "HoaDons",
                column: "SanPhamsMaSP");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDungs_MaQuyen",
                table: "NguoiDungs",
                column: "MaQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_MaLSP",
                table: "SanPhams",
                column: "MaLSP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "PhanQuyens");

            migrationBuilder.DropTable(
                name: "LoaiSanPhams");
        }
    }
}
