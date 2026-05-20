using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ThemMaChiNhanhChoHoaDon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaChiNhanh",
                table: "HoaDon",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaChiNhanh",
                table: "HoaDon",
                column: "MaChiNhanh");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_ChiNhanh_MaChiNhanh",
                table: "HoaDon",
                column: "MaChiNhanh",
                principalTable: "ChiNhanh",
                principalColumn: "MaChiNhanh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_ChiNhanh_MaChiNhanh",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_MaChiNhanh",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "MaChiNhanh",
                table: "HoaDon");
        }
    }
}
