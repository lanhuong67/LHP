using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanDienThoai.Models
{
    [Table("KhachHang")]
    public class KhachHangWeb
    {
        [Key]
        [StringLength(20)]
        public string MaKH { get; set; } = string.Empty;

        [StringLength(100)]
        public string HoTen { get; set; } = string.Empty;

        [StringLength(15)]
        public string SDT { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,0)")]
        public decimal TongChiTieu { get; set; } = 0;

        public int SoLanMua { get; set; } = 0;
    }
}