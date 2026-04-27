using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class TaiKhoan
    {
        [Key] // Xác định khóa chính cho SQL
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; } // "Admin" hoặc "Staff"
    }
}