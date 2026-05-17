using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class TaoBangBaoHanh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuBaoHanh",
                columns: table => new
                {
                    MaPhieuBH = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaHD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaSP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayTiepNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayBatDauBH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHanBH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DieuKienBaoHanh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TinhTrangMay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaNVTiepNhan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuBaoHanh", x => x.MaPhieuBH);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuBaoHanh");
        }
    }
}
