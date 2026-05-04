using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("PhieuNhap")]
    public class PhieuNhap
    {
        [Key]
        [StringLength(20)]
        public string MaPN { get; set; } = string.Empty;

        public DateTime NgayNhap { get; set; } = DateTime.Now;

        // --- CÁC KHÓA NGOẠI MỚI THÊM ---
        [StringLength(20)]
        public string MaChiNhanh { get; set; } = string.Empty;

        [ForeignKey("MaChiNhanh")]
        public virtual ChiNhanh? ChiNhanh { get; set; }

        [StringLength(20)]
        public string MaNV { get; set; } = string.Empty;

        [ForeignKey("MaNV")]
        public virtual NhanVien? NhanVien { get; set; }
        // -------------------------------

        [StringLength(20)]
        public string MaNCC { get; set; } = string.Empty;

        [ForeignKey("MaNCC")]
        public virtual NhaCungCap? NhaCungCap { get; set; }

        [StringLength(50)]
        public string SoHoaDonNCC { get; set; } = string.Empty;

        public string GhiChu { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,0)")]
        public decimal TongTien { get; set; } = 0;

        [StringLength(50)]
        public string TrangThai { get; set; } = "Hoàn thành";

        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();
    }
}