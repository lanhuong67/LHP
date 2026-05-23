using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanDienThoai.Models
{
    [Table("HoaDon")]
    public class HoaDonWeb
    {
        [Key]
        [StringLength(50)]
        public string MaHD { get; set; } = string.Empty;

        public DateTime NgayLap { get; set; } = DateTime.Now;

        [StringLength(20)]
        public string MaNV { get; set; } = "WEB";

        [StringLength(15)]
        public string SDTKhachHang { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,0)")]
        public decimal TongTien { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; } = "Chờ xử lý";

        [StringLength(20)]
        public string MaChiNhanh { get; set; } = string.Empty;

        public string LyDoHuy { get; set; } = string.Empty;

        [StringLength(50)]
        public string HinhThucNhanHang { get; set; } = string.Empty;

        [StringLength(255)]
        public string DiaChiGiaoHang { get; set; } = string.Empty;

        [StringLength(500)]
        public string GhiChuDonHang { get; set; } = string.Empty;

        [StringLength(50)]
        public string PhuongThucThanhToan { get; set; } = "Thanh toán khi nhận hàng";

        [StringLength(50)]
        public string TrangThaiThanhToan { get; set; } = "Chưa thanh toán";

        [Column(TypeName = "decimal(18,0)")]
        public decimal TongTienGoc { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal GiamGia { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal ThanhTienSauGiam { get; set; }

        public virtual ICollection<ChiTietHoaDonWeb> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDonWeb>();
    }
}