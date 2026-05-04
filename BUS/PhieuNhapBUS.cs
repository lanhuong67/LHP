using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class PhieuNhapBUS
    {
        private PhieuNhapDAL _dal = new PhieuNhapDAL();

        public List<NhaCungCap> GetAllNhaCungCap() => _dal.GetAllNhaCungCap();
        public List<ChiNhanh> GetAllChiNhanh() => _dal.GetAllChiNhanh();
        public bool TaoPhieuNhap(PhieuNhap pn, List<ChiTietPhieuNhap> ds) => _dal.TaoPhieuNhap(pn, ds);
    }
}