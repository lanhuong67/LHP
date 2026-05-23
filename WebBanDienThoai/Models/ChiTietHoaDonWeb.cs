using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanDienThoai.Models
{
    [Table("ChiTietHoaDon")]
    public class ChiTietHoaDonWeb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string MaHD { get; set; } = string.Empty;

        [StringLength(20)]
        public string MaSP { get; set; } = string.Empty;

        public int SoLuong { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal DonGia { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal ThanhTien { get; set; }

        public string GhiChuImei { get; set; } = string.Empty;

        public virtual HoaDonWeb? HoaDon { get; set; }

        public virtual SanPhamWeb? SanPham { get; set; }
    }
}