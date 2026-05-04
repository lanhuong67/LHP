using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("ChiTietPhieuNhap")]
    public class ChiTietPhieuNhap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCTPN { get; set; }

        [Required]
        [StringLength(20)]
        public string MaPN { get; set; } = string.Empty;

        [ForeignKey("MaPN")]
        public virtual PhieuNhap? PhieuNhap { get; set; }

        [Required]
        [StringLength(20)]
        public string MaSP { get; set; } = string.Empty;

        [ForeignKey("MaSP")]
        public virtual SanPham? SanPham { get; set; }

        public int SoLuong { get; set; } = 0;

        // --- CỘT MỚI THÊM ĐỂ THEO DÕI LÔ ---
        public int SoLuongDaBan { get; set; } = 0;

        [Column(TypeName = "decimal(18,0)")]
        public decimal DonGiaNhap { get; set; } = 0;

        [Column(TypeName = "decimal(18,0)")]
        public decimal ThanhTien { get; set; } = 0;
    }
}