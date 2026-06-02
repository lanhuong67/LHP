using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanDienThoai.Models
{
    [Table("ChiNhanh")]
    public class ChiNhanhWeb
    {
        [Key]
        [StringLength(20)]
        public string MaChiNhanh { get; set; } = string.Empty;

        [StringLength(100)]
        public string TenChiNhanh { get; set; } = string.Empty;

        [StringLength(255)]
        public string DiaChi { get; set; } = string.Empty;

        [StringLength(15)]
        public string SDT { get; set; } = string.Empty;

        [StringLength(50)]
        public string TrangThai { get; set; } = "Đang hoạt động";

        public virtual ICollection<SanPhamWeb> SanPhams { get; set; } = new List<SanPhamWeb>();
    }
}