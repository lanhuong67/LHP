using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class KhachHangBUS
    {
        private KhachHangDAL _dal = new KhachHangDAL();

        public List<KhachHang> GetAll() => _dal.GetAll();
        public bool Them(KhachHang kh) => _dal.Them(kh);
        public bool Sua(KhachHang kh) => _dal.Sua(kh);
        public bool Xoa(string maKH) => _dal.Xoa(maKH);

        // ========================================================
        // HÀM MỚI: TÌM KHÁCH HÀNG THEO SỐ ĐIỆN THOẠI
        // Cầu nối giúp giao diện UC_TaoHoaDon gọi được hàm dưới DAL
        // ========================================================
        public KhachHang TimKhachHangTheoSDT(string sdt)
        {
            return _dal.TimKhachHangTheoSDT(sdt);
        }
    }
}