using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ThemBangChamSocKhachHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChamSocKhachHang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKH = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenKH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LoaiChamSoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayHen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaNVPhuTrach = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NguonPhatSinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaNguon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GhiChuKetQua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayXuLy = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamSocKhachHang", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamSocKhachHang");
        }
    }
}
