using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        [StringLength(20)]
        public string MaSP { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string TenSP { get; set; } = string.Empty;

        // Khóa ngoại liên kết với bảng HangSanXuat
        [Required]
        [StringLength(20)]
        public string MaHang { get; set; } = string.Empty;

        [ForeignKey("MaHang")]
        public virtual HangSanXuat? HangSanXuat { get; set; }

        // Kiểu decimal cho tiền tệ
        [Column(TypeName = "decimal(18,0)")]
        public decimal GiaNhap { get; set; } = 0;

        [Column(TypeName = "decimal(18,0)")]
        public decimal GiaBan { get; set; } = 0;

        public int TonKho { get; set; } = 0;

        public string? CauHinh { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; } = "Đang kinh doanh";
    }
}