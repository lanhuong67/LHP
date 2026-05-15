using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public class LichSuNhapViewModel
    {
        public string MaPN { get; set; }
        public DateTime NgayNhap { get; set; }
        public string TenNCC { get; set; }
        public string TenNhanVien { get; set; }
        public int SoSanPham { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }

        // ====================================================
        // VŨ KHÍ BÍ MẬT: Báo cho WinForms biết cấm vẽ cột này ra giao diện
        // Nhưng dữ liệu bên dưới RAM thì vẫn giữ nguyên để dùng cho nút [Chi tiết]
        // ====================================================
        [Browsable(false)]
        public string GhiChu { get; set; }
    }

    public class LoHangViewModel
    {
        public string MaLo { get; set; }        // Tự ghép từ Mã Phiếu + Mã SP
        public string TenSP { get; set; }
        public string MaPN { get; set; }
        public DateTime NgayNhap { get; set; }
        public int SoLuongNhap { get; set; }
        public int SoLuongDaBan { get; set; }

        // Code tự động tính số lượng còn lại
        public int ConLai => SoLuongNhap - SoLuongDaBan;

        // Code tự động xét trạng thái lô
        public string TrangThai => ConLai == 0 ? "Đã bán hết" : "Còn hàng";
    }
}