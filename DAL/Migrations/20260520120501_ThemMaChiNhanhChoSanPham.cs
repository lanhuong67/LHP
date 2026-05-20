using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ThemMaChiNhanhChoSanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaChiNhanh",
                table: "SanPham",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaChiNhanh",
                table: "SanPham",
                column: "MaChiNhanh");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_ChiNhanh_MaChiNhanh",
                table: "SanPham",
                column: "MaChiNhanh",
                principalTable: "ChiNhanh",
                principalColumn: "MaChiNhanh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_ChiNhanh_MaChiNhanh",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_MaChiNhanh",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "MaChiNhanh",
                table: "SanPham");
        }
    }
}
