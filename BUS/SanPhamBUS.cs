using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class SanPhamBUS
    {
        private SanPhamDAL _dal = new SanPhamDAL();

        public List<SanPham> GetAll()
        {
            return _dal.GetAll();
        }

        public List<HangSanXuat> GetAllHang()
        {
            return _dal.GetAllHang();
        }

        public List<SanPham> GetByBranch(string maCN)
        {
            return _dal.GetByBranch(maCN);
        }

        public bool Them(SanPham sp)
        {
            return _dal.Them(sp);
        }

        public bool Sua(SanPham sp)
        {
            return _dal.Sua(sp);
        }

        public bool Xoa(string maSP)
        {
            string thongBao;
            return _dal.Xoa(maSP, out thongBao);
        }

        public bool Xoa(string maSP, out string thongBao)
        {
            return _dal.Xoa(maSP, out thongBao);
        }
    }
}