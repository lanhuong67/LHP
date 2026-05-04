using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CapNhatChiNhanhVaLichSu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaChiNhanh",
                table: "PhieuNhap",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaNV",
                table: "PhieuNhap",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SoLuongDaBan",
                table: "ChiTietPhieuNhap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ChiNhanh",
                columns: table => new
                {
                    MaChiNhanh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenChiNhanh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiNhanh", x => x.MaChiNhanh);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_MaChiNhanh",
                table: "PhieuNhap",
                column: "MaChiNhanh");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_MaNV",
                table: "PhieuNhap",
                column: "MaNV");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhap_ChiNhanh_MaChiNhanh",
                table: "PhieuNhap",
                column: "MaChiNhanh",
                principalTable: "ChiNhanh",
                principalColumn: "MaChiNhanh",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhap_NhanVien_MaNV",
                table: "PhieuNhap",
                column: "MaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhap_ChiNhanh_MaChiNhanh",
                table: "PhieuNhap");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhap_NhanVien_MaNV",
                table: "PhieuNhap");

            migrationBuilder.DropTable(
                name: "ChiNhanh");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhap_MaChiNhanh",
                table: "PhieuNhap");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhap_MaNV",
                table: "PhieuNhap");

            migrationBuilder.DropColumn(
                name: "MaChiNhanh",
                table: "PhieuNhap");

            migrationBuilder.DropColumn(
                name: "MaNV",
                table: "PhieuNhap");

            migrationBuilder.DropColumn(
                name: "SoLuongDaBan",
                table: "ChiTietPhieuNhap");
        }
    }
}
