using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class TaoBangSanPhamVaHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangSanXuat",
                columns: table => new
                {
                    MaHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangSanXuat", x => x.MaHang);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaHang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GiaNhap = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    TonKho = table.Column<int>(type: "int", nullable: false),
                    CauHinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_SanPham_HangSanXuat_MaHang",
                        column: x => x.MaHang,
                        principalTable: "HangSanXuat",
                        principalColumn: "MaHang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaHang",
                table: "SanPham",
                column: "MaHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "HangSanXuat");
        }
    }
}
