using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBanDienThoai.Migrations
{
    public partial class CapNhatBangTaiKhoanKhachHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Nếu bảng chưa có thì tạo mới.
            // Lưu ý: MaTaiKhoan KHÔNG dùng IDENTITY để tránh lỗi bảng đã có identity khác.
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'TaiKhoanKhachHang', N'U') IS NULL
BEGIN
    CREATE TABLE TaiKhoanKhachHang
    (
        MaTaiKhoan INT NOT NULL,
        MaKH NVARCHAR(20) NOT NULL,
        SDT NVARCHAR(20) NOT NULL,
        MatKhauHash NVARCHAR(255) NOT NULL,
        NgayDangKy DATETIME2 NOT NULL DEFAULT GETDATE(),
        TrangThai BIT NOT NULL DEFAULT 1,
        CONSTRAINT PK_TaiKhoanKhachHang PRIMARY KEY (MaTaiKhoan)
    )
END
");

            // Nếu bảng đã có nhưng thiếu MaTaiKhoan thì thêm dạng INT thường, KHÔNG IDENTITY.
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'TaiKhoanKhachHang', N'U') IS NOT NULL
AND COL_LENGTH('TaiKhoanKhachHang', 'MaTaiKhoan') IS NULL
BEGIN
    ALTER TABLE TaiKhoanKhachHang
    ADD MaTaiKhoan INT NOT NULL CONSTRAINT DF_TaiKhoanKhachHang_MaTaiKhoan DEFAULT 0
END
");

            // Nếu bảng có dữ liệu cũ và MaTaiKhoan đang là 0 thì đánh số lại.
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'TaiKhoanKhachHang', N'U') IS NOT NULL
AND COL_LENGTH('TaiKhoanKhachHang', 'MaTaiKhoan') IS NOT NULL
BEGIN
    ;WITH CTE AS
    (
        SELECT 
            MaTaiKhoan,
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS STT
        FROM TaiKhoanKhachHang
        WHERE MaTaiKhoan = 0
    )
    UPDATE CTE
    SET MaTaiKhoan = STT
END
");

            // Nếu thiếu MaKH thì thêm.
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'TaiKhoanKhachHang', N'U') IS NOT NULL
AND COL_LENGTH('TaiKhoanKhachHang', 'MaKH') IS NULL
BEGIN
    ALTER TABLE TaiKhoanKhachHang
    ADD MaKH NVARCHAR(20) NOT NULL DEFAULT ''
END
");

            // Nếu thiếu SDT thì thêm.
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'TaiKhoanKhachHang', N'U') IS NOT NULL
AND COL_LENGTH('TaiKhoanKhachHang', 'SDT') IS NULL
BEGIN
    ALTER TABLE TaiKhoanKhachHang
    ADD SDT NVARCHAR(20) NOT NULL DEFAULT ''
END
");

            // Nếu thiếu MatKhauHash thì thêm.
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'TaiKhoanKhachHang', N'U') IS NOT NULL
AND COL_LENGTH('TaiKhoanKhachHang', 'MatKhauHash') IS NULL
BEGIN
    ALTER TABLE TaiKhoanKhachHang
    ADD MatKhauHash NVARCHAR(255) NOT NULL DEFAULT ''
END
");

            // Nếu thiếu NgayDangKy thì thêm.
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'TaiKhoanKhachHang', N'U') IS NOT NULL
AND COL_LENGTH('TaiKhoanKhachHang', 'NgayDangKy') IS NULL
BEGIN
    ALTER TABLE TaiKhoanKhachHang
    ADD NgayDangKy DATETIME2 NOT NULL DEFAULT GETDATE()
END
");

            // Nếu thiếu TrangThai thì thêm.
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'TaiKhoanKhachHang', N'U') IS NOT NULL
AND COL_LENGTH('TaiKhoanKhachHang', 'TrangThai') IS NULL
BEGIN
    ALTER TABLE TaiKhoanKhachHang
    ADD TrangThai BIT NOT NULL DEFAULT 1
END
");

            // Không tạo PK nếu bảng đã có khóa chính cũ.
            // Chỉ tạo PK MaTaiKhoan khi bảng chưa có PK nào.
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'TaiKhoanKhachHang', N'U') IS NOT NULL
AND COL_LENGTH('TaiKhoanKhachHang', 'MaTaiKhoan') IS NOT NULL
AND NOT EXISTS (
    SELECT 1
    FROM sys.key_constraints
    WHERE type = 'PK'
      AND parent_object_id = OBJECT_ID(N'TaiKhoanKhachHang')
)
BEGIN
    ALTER TABLE TaiKhoanKhachHang
    ADD CONSTRAINT PK_TaiKhoanKhachHang PRIMARY KEY (MaTaiKhoan)
END
");

            // Không tạo unique index SDT để tránh lỗi nếu dữ liệu cũ đang bị trùng.
            // Controller đã tự kiểm tra SDT trước khi đăng ký.
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Không rollback cấu trúc bảng cũ để tránh mất dữ liệu.
        }
    }
}