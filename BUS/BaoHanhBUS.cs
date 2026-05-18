using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class BaoHanhBUS
    {
        private BaoHanhDAL _dal = new BaoHanhDAL();

        public HoaDonViewModel TimHoaDonBaoHanh(string tuKhoa) { return _dal.TimHoaDonBaoHanh(tuKhoa); }
        public List<SanPhamBaoHanhViewModel> GetSanPhamTuHoaDon(string maHD) { return _dal.GetSanPhamTuHoaDon(maHD); }
        public bool TaoPhieuBaoHanh(PhieuBaoHanh pbh) { return _dal.TaoPhieuBaoHanh(pbh); }
        public List<TraCuuBaoHanhViewModel> GetDanhSachBaoHanh() { return _dal.GetDanhSachBaoHanh(); }
        public bool CapNhatTrangThai(string maPhieu, string trangThaiMoi) { return _dal.CapNhatTrangThai(maPhieu, trangThaiMoi); }

        // 🔴 ĐÃ THÊM CẦU NỐI
        public List<string> GetImeiDaBaoHanh(string maHD)
        {
            return _dal.GetImeiDaBaoHanh(maHD);
        }
    }
}