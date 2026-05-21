using System;

namespace DTO
{
    // =====================================================
    // DOANH THU
    // =====================================================
    public class DoanhThuViewModel
    {
        public string ThoiGian { get; set; } = string.Empty;
        public int SoHoaDon { get; set; }
        public decimal DoanhThu { get; set; }
    }

    public class TongQuanDoanhThuViewModel
    {
        public decimal TongDoanhThu { get; set; }
        public int SoHoaDon { get; set; }

        public decimal TrungBinhHoaDon
        {
            get
            {
                if (SoHoaDon <= 0) return 0;
                return TongDoanhThu / SoHoaDon;
            }
        }
    }

    // =====================================================
    // TOP BÁN CHẠY
    // =====================================================
    public class TopSanPhamBanChayViewModel
    {
        public int Hang { get; set; }
        public string MaSP { get; set; } = string.Empty;
        public string TenSP { get; set; } = string.Empty;
        public string TenHang { get; set; } = string.Empty;
        public int SoLuongBan { get; set; }
        public decimal DoanhThu { get; set; }
    }

    // =====================================================
    // DASHBOARD - 4 Ô TỔNG QUAN
    // =====================================================
    public class DashboardTongQuanViewModel
    {
        public decimal DoanhThuThangNay { get; set; }
        public int DonHangHomNay { get; set; }
        public int TongKhachHang { get; set; }
        public int SanPhamSapHet { get; set; }
    }

    // =====================================================
    // DASHBOARD - CẢNH BÁO TỒN KHO
    // =====================================================
    public class CanhBaoTonKhoDashboardViewModel
    {
        public string MaSP { get; set; } = string.Empty;
        public string TenSP { get; set; } = string.Empty;
        public int TonKho { get; set; }
        public string MucCanhBao { get; set; } = string.Empty;
    }

    // =====================================================
    // DASHBOARD - BẢO HÀNH SẮP HẾT
    // =====================================================
    public class BaoHanhSapHetDashboardViewModel
    {
        public string MaPhieuBH { get; set; } = string.Empty;
        public string TenKhachHang { get; set; } = string.Empty;
        public string TenSP { get; set; } = string.Empty;
        public DateTime NgayHetHanBH { get; set; }
        public string TrangThai { get; set; } = string.Empty;
    }

    // =====================================================
    // DASHBOARD - HOẠT ĐỘNG GẦN ĐÂY
    // =====================================================
    public class HoatDongGanDayViewModel
    {
        public DateTime ThoiGian { get; set; }
        public string LoaiHoatDong { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;
        public decimal GiaTri { get; set; }
    }
}