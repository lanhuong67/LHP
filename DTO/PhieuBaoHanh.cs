using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("PhieuBaoHanh")]
    public class PhieuBaoHanh
    {
        [Key]
        [StringLength(20)]
        public string MaPhieuBH { get; set; } = string.Empty;

        [StringLength(20)]
        public string MaHD { get; set; } = string.Empty;

        [StringLength(50)]
        public string MaSP { get; set; } = string.Empty;

        [StringLength(50)]
        public string Imei { get; set; } = string.Empty;

        public DateTime NgayTiepNhan { get; set; } = DateTime.Now;
        public DateTime NgayBatDauBH { get; set; }
        public DateTime NgayHetHanBH { get; set; }

        [StringLength(100)]
        public string DieuKienBaoHanh { get; set; } = string.Empty;

        public string TinhTrangMay { get; set; } = string.Empty;

        [StringLength(50)]
        public string TrangThai { get; set; } = "Đang hiệu lực";

        [StringLength(20)]
        public string MaNVTiepNhan { get; set; } = string.Empty;
    }

    public class SanPhamBaoHanhViewModel
    {
        public bool Chon { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public string Imei { get; set; }
    }

    public class TraCuuBaoHanhViewModel
    {
        public string MaPhieuBH { get; set; }
        public string TenKhachHang { get; set; }

        // Thêm dòng này để tra cứu theo SĐT
        public string SDTKhachHang { get; set; }

        public string TenSP { get; set; }
        public DateTime NgayHetHanBH { get; set; }
        public string TrangThai { get; set; }
    }
}