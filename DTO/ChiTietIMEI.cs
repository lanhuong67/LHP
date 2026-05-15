using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("ChiTietIMEI")]
    public class ChiTietIMEI
    {
        [Key]
        [StringLength(50)]
        public string IMEI { get; set; } = string.Empty; // Mã IMEI là khóa chính luôn (vì nó là duy nhất trên thế giới)

        [Required]
        [StringLength(20)]
        public string MaSP { get; set; } = string.Empty;

        [ForeignKey("MaSP")]
        public virtual SanPham? SanPham { get; set; }

        [StringLength(20)]
        public string MaPN { get; set; } = string.Empty; // Lưu lại để biết cái máy này nhập từ lô hàng nào

        [ForeignKey("MaPN")]
        public virtual PhieuNhap? PhieuNhap { get; set; }

        // Trạng thái: "Trong kho", "Đã bán", "Bảo hành", "Lỗi trả NCC"
        [StringLength(50)]
        public string TrangThai { get; set; } = "Trong kho";
    }
}