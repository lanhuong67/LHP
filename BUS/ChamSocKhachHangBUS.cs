using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class ChamSocKhachHangBUS
    {
        private ChamSocKhachHangDAL _dal = new ChamSocKhachHangDAL();

        public List<ChamSocKHViewModel> GetAll()
        {
            return _dal.GetAll();
        }

        public List<ChamSocKHViewModel> TimKiem(string tuKhoa, string loai, string trangThai)
        {
            return _dal.TimKiem(tuKhoa, loai, trangThai);
        }

        public ChamSocThongKeViewModel GetThongKe()
        {
            return _dal.GetThongKe();
        }

        public bool Them(ChamSocKhachHang cs)
        {
            return _dal.Them(cs);
        }

        public bool DanhDauDaXuLy(int id, string ghiChuKetQua)
        {
            return _dal.DanhDauDaXuLy(id, ghiChuKetQua);
        }

        public bool CapNhatTrangThai(int id, string trangThai)
        {
            return _dal.CapNhatTrangThai(id, trangThai);
        }

        public List<KhachHangChamSocViewModel> TimKhachHang(string tuKhoa)
        {
            return _dal.TimKhachHang(tuKhoa);
        }
    }
}