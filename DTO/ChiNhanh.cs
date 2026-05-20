using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("ChiNhanh")]
    public class ChiNhanh
    {
        [Key]
        [StringLength(20)]
        public string MaChiNhanh { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string TenChiNhanh { get; set; } = string.Empty;

        [StringLength(50)]
        public string ThanhPho { get; set; } = string.Empty;

        [StringLength(50)]
        public string QuanHuyen { get; set; } = string.Empty;

        [StringLength(255)]
        public string DiaChi { get; set; } = string.Empty;

        [StringLength(50)]
        public string QuanLy { get; set; } = string.Empty;

        [StringLength(15)]
        public string SDT { get; set; } = string.Empty;

        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(50)]
        public string TrangThai { get; set; } = "Đang hoạt động";

        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();
    }
}