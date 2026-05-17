using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class HoaDonBUS
    {
        private HoaDonDAL _dal = new HoaDonDAL();

        public List<string> GetImeiTonKho(string maSP)
        {
            return _dal.GetImeiTonKho(maSP);
        }

        public bool TaoHoaDon(HoaDon hd, List<ChiTietHoaDon> dsChiTiet)
        {
            return _dal.TaoHoaDon(hd, dsChiTiet);
        }

        public List<HoaDonViewModel> GetDanhSachHoaDon()
        {
            return _dal.GetDanhSachHoaDon();
        }

        public List<ChiTietHoaDonViewModel> GetChiTietHoaDon(string maHD)
        {
            return _dal.GetChiTietHoaDon(maHD);
        }

        public bool HuyHoaDonThongTu78(string maHD, string lyDo, string maNhanVienHuy)
        {
            return _dal.HuyHoaDonThongTu78(maHD, lyDo, maNhanVienHuy);
        }
    }
}