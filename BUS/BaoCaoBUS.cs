using DAL;
using DTO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class BaoCaoBUS
    {
        private BaoCaoDAL _dal = new BaoCaoDAL();

        public List<DoanhThuViewModel> GetDoanhThuTheoNgay(string maCN, DateTime tuNgay, DateTime denNgay)
        {
            return _dal.GetDoanhThuTheoNgay(maCN, tuNgay, denNgay);
        }

        public List<DoanhThuViewModel> GetDoanhThuTheoThang(string maCN, int nam)
        {
            return _dal.GetDoanhThuTheoThang(maCN, nam);
        }

        public List<DoanhThuViewModel> GetDoanhThuTheoNam(string maCN)
        {
            return _dal.GetDoanhThuTheoNam(maCN);
        }

        public TongQuanDoanhThuViewModel TinhTongQuan(List<DoanhThuViewModel> ds)
        {
            return _dal.TinhTongQuan(ds);
        }

        public List<TopSanPhamBanChayViewModel> GetTopSanPhamBanChay(string maCN, DateTime? tuNgay, DateTime? denNgay, int top = 10)
        {
            return _dal.GetTopSanPhamBanChay(maCN, tuNgay, denNgay, top);
        }

        public DashboardTongQuanViewModel GetDashboardTongQuan(string maCN)
        {
            return _dal.GetDashboardTongQuan(maCN);
        }

        public List<CanhBaoTonKhoDashboardViewModel> GetCanhBaoTonKhoDashboard(string maCN, int take = 5)
        {
            return _dal.GetCanhBaoTonKhoDashboard(maCN, take);
        }

        public List<BaoHanhSapHetDashboardViewModel> GetBaoHanhSapHetDashboard(string maCN, int soNgay = 30, int take = 5)
        {
            return _dal.GetBaoHanhSapHetDashboard(maCN, soNgay, take);
        }

        public List<HoatDongGanDayViewModel> GetHoatDongGanDayDashboard(string maCN, int take = 5)
        {
            return _dal.GetHoatDongGanDayDashboard(maCN, take);
        }
    }
}