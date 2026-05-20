using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        [StringLength(20)]
        public string MaNV { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; } = string.Empty;

        [StringLength(15)]
        public string? SDT { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        [StringLength(50)]
        public string VaiTro { get; set; } = string.Empty; // Đổi lại thành VaiTro cho khớp FormDangNhap

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; } = string.Empty;

        // 1. Lưu mã chi nhánh nơi nhân viên đang làm việc
        [Required]
        [StringLength(20)]
        public string MaChiNhanh { get; set; } = string.Empty;

        // 2. Thuộc tính điều hướng (Navigation Property) kết nối đến bảng ChiNhanh
        [ForeignKey("MaChiNhanh")]
        public virtual ChiNhanh? ChiNhanh { get; set; }
    }
}