using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanDienThoai.Models
{
    [Table("SanPham")]
    public class SanPhamWeb
    {
        [Key]
        [StringLength(20)]
        public string MaSP { get; set; } = string.Empty;

        [StringLength(100)]
        public string TenSP { get; set; } = string.Empty;

        [StringLength(20)]
        public string MaHang { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,0)")]
        public decimal GiaNhap { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal GiaBan { get; set; }

        public int TonKho { get; set; }

        public string CauHinh { get; set; } = string.Empty;

        [StringLength(50)]
        public string TrangThai { get; set; } = string.Empty;

        [StringLength(20)]
        public string MaChiNhanh { get; set; } = string.Empty;

        [ForeignKey("MaHang")]
        public virtual HangSanXuatWeb? HangSanXuat { get; set; }

        [ForeignKey("MaChiNhanh")]
        public virtual ChiNhanhWeb? ChiNhanh { get; set; }
    }
}