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

        [StringLength(255)]
        public string DiaChi { get; set; } = string.Empty;

        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();
    }
}