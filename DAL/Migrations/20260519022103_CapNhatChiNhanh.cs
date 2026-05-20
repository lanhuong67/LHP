using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CapNhatChiNhanh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ChiNhanh",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuanHuyen",
                table: "ChiNhanh",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuanLy",
                table: "ChiNhanh",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SDT",
                table: "ChiNhanh",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThanhPho",
                table: "ChiNhanh",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "ChiNhanh",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ChiNhanh");

            migrationBuilder.DropColumn(
                name: "QuanHuyen",
                table: "ChiNhanh");

            migrationBuilder.DropColumn(
                name: "QuanLy",
                table: "ChiNhanh");

            migrationBuilder.DropColumn(
                name: "SDT",
                table: "ChiNhanh");

            migrationBuilder.DropColumn(
                name: "ThanhPho",
                table: "ChiNhanh");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiNhanh");
        }
    }
}
