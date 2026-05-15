using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class HoaDonBUS
    {
        private HoaDonDAL _dal = new HoaDonDAL();

        // Lấy danh sách IMEI tồn kho đẩy lên GUI
        public List<string> GetImeiTonKho(string maSP)
        {
            return _dal.GetImeiTonKho(maSP);
        }

        // Gọi tạo hóa đơn
        public bool TaoHoaDon(HoaDon hd, List<ChiTietHoaDon> dsChiTiet)
        {
            return _dal.TaoHoaDon(hd, dsChiTiet);
        }

        // Gọi lấy danh sách lịch sử hóa đơn
        public List<HoaDonViewModel> GetDanhSachHoaDon()
        {
            return _dal.GetDanhSachHoaDon();
        }
        public List<ChiTietHoaDonViewModel> GetChiTietHoaDon(string maHD)
        {
            return _dal.GetChiTietHoaDon(maHD);
        }
    }
}