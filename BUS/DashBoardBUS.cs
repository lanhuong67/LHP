using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BUS
{
    /// <summary>
    /// Business layer tổng hợp dữ liệu cho Dashboard
    /// </summary>
    public class DashboardBUS
    {
        private DashboardDAL _dal = new DashboardDAL();

        /// <summary>
        /// Lấy tổng quan số liệu cho Dashboard (cards)
        /// </summary>
        public TongQuanDashboard GetTongQuan(int nam)
        {
            return _dal.GetTongQuan(nam);
        }

        /// <summary>
        /// Lấy doanh thu theo từng tháng trong năm
        /// </summary>
        public List<DoanhThuTheoThang> GetDoanhThuTheoThang(int nam)
        {
            return _dal.GetDoanhThuTheoThang(nam);
        }

        /// <summary>
        /// Lấy top N sản phẩm bán chạy nhất
        /// </summary>
        public List<SanPhamBanChay> GetTopSanPhamBanChay(int nam, int topN = 5)
        {
            return _dal.GetTopSanPhamBanChay(nam, topN);
        }

        /// <summary>
        /// Lấy danh sách sản phẩm sắp hết hàng (tồn kho dưới ngưỡng)
        /// </summary>
        public List<SanPhamTonKho> GetSanPhamSapHetHang(int nguong = 5)
        {
            return _dal.GetSanPhamSapHetHang(nguong);
        }

        /// <summary>
        /// Lấy danh sách bảo hành sắp hết hạn trong N ngày tới
        /// </summary>
        public List<BaoHanhSapHet> GetBaoHanhSapHetHan(int soNgay = 30)
        {
            return _dal.GetBaoHanhSapHetHan(soNgay);
        }

        /// <summary>
        /// Lấy các hoạt động/giao dịch gần đây nhất
        /// </summary>
        public List<string> GetHoatDongGanDay(int soLuong = 10)
        {
            return _dal.GetHoatDongGanDay(soLuong);
        }
    }
}