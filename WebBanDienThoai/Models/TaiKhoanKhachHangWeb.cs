using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanDienThoai.Models
{
    [Table("TaiKhoanKhachHang")]
    public class TaiKhoanKhachHangWeb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTaiKhoan { get; set; }

        [Required]
        [StringLength(20)]
        public string MaKH { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string SDT { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string MatKhauHash { get; set; } = string.Empty;

        [Column("NgayTao")]
        public DateTime NgayDangKy { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string TrangThai { get; set; } = "Hoạt động";

        public virtual KhachHangWeb? KhachHang { get; set; }
    }
}