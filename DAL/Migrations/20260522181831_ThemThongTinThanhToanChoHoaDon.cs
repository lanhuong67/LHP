using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ThemThongTinThanhToanChoHoaDon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GiamGia",
                table: "HoaDon",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PhuongThucThanhToan",
                table: "HoaDon",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ThanhTienSauGiam",
                table: "HoaDon",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TongTienGoc",
                table: "HoaDon",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TrangThaiThanhToan",
                table: "HoaDon",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiamGia",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "PhuongThucThanhToan",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "ThanhTienSauGiam",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "TongTienGoc",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "TrangThaiThanhToan",
                table: "HoaDon");
        }
    }
}
