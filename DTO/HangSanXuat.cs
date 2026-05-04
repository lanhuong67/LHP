using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("HangSanXuat")]
    public class HangSanXuat
    {
        [Key]
        [StringLength(20)]
        public string MaHang { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string TenHang { get; set; } = string.Empty;

        // Các cột mở rộng từ giao diện
        [StringLength(100)]
        public string? QuocGia { get; set; }

        [StringLength(500)]
        public string? MoTa { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; } = "Đang hợp tác";

        // Mối quan hệ 1-N: 1 Hãng có nhiều Sản phẩm
        public virtual ICollection<SanPham>? SanPhams { get; set; }
    }
}