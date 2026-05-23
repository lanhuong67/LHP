using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("TaiKhoanKhachHang")]
    public class TaiKhoanKhachHang
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string MaKH { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string SDT { get; set; } = string.Empty;

        [Required]
        public string MatKhauHash { get; set; } = string.Empty;

        [StringLength(50)]
        public string TrangThai { get; set; } = "Hoạt động";

        public DateTime NgayTao { get; set; } = DateTime.Now;

        public DateTime? LanDangNhapCuoi { get; set; }

        public virtual KhachHang? KhachHang { get; set; }
    }
}