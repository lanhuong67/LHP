using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class SanPhamBUS
    {
        private SanPhamDAL _dal = new SanPhamDAL();

        public List<SanPham> GetAll() => _dal.GetAll();
        public List<HangSanXuat> GetAllHang() => _dal.GetAllHang(); // Lấy danh sách hãng cho ComboBox
        public bool Them(SanPham sp) => _dal.Them(sp);
        public bool Sua(SanPham sp) => _dal.Sua(sp);
        public bool Xoa(string maSP) => _dal.Xoa(maSP);
    }
}