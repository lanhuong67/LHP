using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ThemChiNhanhChoNhanVien_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaChiNhanh",
                table: "NhanVien",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaChiNhanh",
                table: "NhanVien",
                column: "MaChiNhanh");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_ChiNhanh_MaChiNhanh",
                table: "NhanVien",
                column: "MaChiNhanh",
                principalTable: "ChiNhanh",
                principalColumn: "MaChiNhanh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_ChiNhanh_MaChiNhanh",
                table: "NhanVien");

            migrationBuilder.DropIndex(
                name: "IX_NhanVien_MaChiNhanh",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "MaChiNhanh",
                table: "NhanVien");
        }
    }
}
