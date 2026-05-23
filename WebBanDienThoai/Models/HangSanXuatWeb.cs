using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanDienThoai.Models
{
    [Table("HangSanXuat")]
    public class HangSanXuatWeb
    {
        [Key]
        [StringLength(20)]
        public string MaHang { get; set; } = string.Empty;

        [StringLength(100)]
        public string TenHang { get; set; } = string.Empty;

        [StringLength(50)]
        public string TrangThai { get; set; } = string.Empty;

        public virtual ICollection<SanPhamWeb> SanPhams { get; set; } = new List<SanPhamWeb>();
    }
}