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
        public string MaHD { get; set; } = string.Empty; // Tham chiếu đến Hóa đơn gốc

        [StringLength(50)]
        public string MaSP { get; set; } = string.Empty;

        public DateTime NgayTiepNhan { get; set; } = DateTime.Now;
        public DateTime NgayBatDauBH { get; set; }
        public DateTime NgayHetHanBH { get; set; }

        [StringLength(100)]
        public string DieuKienBaoHanh { get; set; } = string.Empty;

        public string TinhTrangMay { get; set; } = string.Empty; // Ghi chú lúc nhận máy

        [StringLength(50)]
        public string TrangThai { get; set; } = "Đang xử lý"; // Đang xử lý, Đã xong, Từ chối...

        [StringLength(20)]
        public string MaNVTiepNhan { get; set; } = string.Empty;
    }

    // Class dùng để hiển thị lưới Sản phẩm Bảo Hành (Phần B2 trên giao diện)
    public class SanPhamBaoHanhViewModel
    {
        public bool Chon { get; set; } // Cột Checkbox
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public string Imei { get; set; }
    }
}