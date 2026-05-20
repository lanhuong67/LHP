using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class HoaDonBUS
    {
        private HoaDonDAL _dal = new HoaDonDAL();

        // Bản cũ: giữ lại để không làm hỏng các code cũ nếu còn gọi 1 tham số
        public List<string> GetImeiTonKho(string maSP)
        {
            return _dal.GetImeiTonKho(maSP);
        }

        // Bản mới: dùng cho đa chi nhánh
        public List<string> GetImeiTonKho(string maSP, string maCN)
        {
            return _dal.GetImeiTonKho(maSP, maCN);
        }

        public bool TaoHoaDon(HoaDon hd, List<ChiTietHoaDon> dsChiTiet)
        {
            return _dal.TaoHoaDon(hd, dsChiTiet);
        }

        public List<HoaDonViewModel> GetDanhSachHoaDon(string maCN)
        {
            return _dal.GetDanhSachHoaDon(maCN);
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