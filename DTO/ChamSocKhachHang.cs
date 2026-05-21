using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("ChamSocKhachHang")]
    public class ChamSocKhachHang
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string MaKH { get; set; } = string.Empty;

        [StringLength(100)]
        public string TenKH { get; set; } = string.Empty;

        [StringLength(15)]
        public string SDT { get; set; } = string.Empty;

        [StringLength(100)]
        public string LoaiChamSoc { get; set; } = string.Empty;

        public string NoiDung { get; set; } = string.Empty;

        public DateTime NgayHen { get; set; } = DateTime.Today;

        [StringLength(50)]
        public string TrangThai { get; set; } = "Chưa xử lý";

        [StringLength(20)]
        public string MaNVPhuTrach { get; set; } = string.Empty;

        [StringLength(100)]
        public string NguonPhatSinh { get; set; } = string.Empty;

        [StringLength(50)]
        public string MaNguon { get; set; } = string.Empty;

        // =====================================================
        // THÊM MỚI: Chi nhánh phát sinh lịch chăm sóc
        // Ví dụ: Q1, CN01, CN02...
        // =====================================================
        [StringLength(20)]
        public string MaChiNhanhPhatSinh { get; set; } = string.Empty;

        public string GhiChuKetQua { get; set; } = string.Empty;

        public DateTime NgayTao { get; set; } = DateTime.Now;

        public DateTime? NgayXuLy { get; set; }
    }

    public class ChamSocKHViewModel
    {
        public int Id { get; set; }
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string LoaiChamSoc { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayHen { get; set; }
        public string TrangThai { get; set; }
        public string MaNVPhuTrach { get; set; }
        public string NguonPhatSinh { get; set; }
        public string MaNguon { get; set; }

        // =====================================================
        // THÊM MỚI: Dùng để hiển thị chi nhánh trên DataGridView
        // =====================================================
        public string MaChiNhanhPhatSinh { get; set; }
        public string TenChiNhanhPhatSinh { get; set; }

        public DateTime? NgayXuLy { get; set; }
    }

    public class ChamSocThongKeViewModel
    {
        public int NhacHomNay { get; set; }
        public int BaoHanhSapHetHan { get; set; }
        public int ChuaLienHeLai { get; set; }
        public int DaXuLyTuanNay { get; set; }
    }

    public class KhachHangChamSocViewModel
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
    }
}