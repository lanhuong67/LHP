using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        [StringLength(20)]
        public string MaKH { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; } = string.Empty;

        [StringLength(15)]
        public string? SDT { get; set; }

        [StringLength(255)]
        public string? DiaChi { get; set; }

        // Chuẩn bị sẵn cho Trigger (Mặc định = 0)
        public int SoLanMua { get; set; } = 0;

        [Column(TypeName = "decimal(18,0)")]
        public decimal TongChiTieu { get; set; } = 0;
    }
}