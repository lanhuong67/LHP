using System;

namespace DTO
{
    /// <summary>
    /// Số liệu tổng quan hiển thị trên Dashboard (4 cards)
    /// </summary>
    public class TongQuanDashboard
    {
        public decimal DoanhThuThangHienTai { get; set; }
        public decimal DoanhThuThangTruoc { get; set; }
        public int DonHangHomNay { get; set; }
        public int DonHangHomQua { get; set; }
        public int TongKhachHang { get; set; }
        public int KhachHangMoiThang { get; set; }
        public int SanPhamSapHetHang { get; set; }
    }

    /// <summary>
    /// Doanh thu theo từng tháng (dùng cho biểu đồ cột)
    /// </summary>
    public class DoanhThuTheoThang
    {
        public int Thang { get; set; }
        public decimal DoanhThu { get; set; }
    }

    /// <summary>
    /// Sản phẩm bán chạy (top N)
    /// </summary>
    public class SanPhamBanChay
    {
        public int Rank { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuongBan { get; set; }
        public decimal DoanhThu { get; set; }
    }

    /// <summary>
    /// Thông tin tồn kho sản phẩm sắp hết hàng
    /// </summary>
    public class SanPhamTonKho
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuongTon { get; set; }
        public string TrangThai { get; set; }
    }

    /// <summary>
    /// Bảo hành sắp hết hạn (cần chăm sóc KH)
    /// </summary>
    public class BaoHanhSapHet
    {
        public string MaPhieuBH { get; set; }
        public string TenKhachHang { get; set; }
        public string SDT { get; set; }
        public string TenSP { get; set; }
        public DateTime NgayHetHan { get; set; }
        public int SoNgayCon { get; set; }
    }
}