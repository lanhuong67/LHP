using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("NhaCungCap")]
    public class NhaCungCap
    {
        [Key]
        [StringLength(20)]
        public string MaNCC { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string TenNCC { get; set; } = string.Empty;

        [StringLength(20)]
        public string SoDienThoai { get; set; } = string.Empty;

        [StringLength(255)]
        public string DiaChi { get; set; } = string.Empty;

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Một nhà cung cấp có thể có nhiều phiếu nhập
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();
    }
}