using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class NhanVienBUS
    {
        private NhanVienDAL _nhanVienDAL = new NhanVienDAL();

        public NhanVien? Login(string user, string pass)
        {
            return _nhanVienDAL.Login(user, pass);
        }

        public List<NhanVien> GetAllNhanVien()
        {
            return _nhanVienDAL.GetAllNhanVien();
        }

        public bool ThemNhanVien(NhanVien nv)
        {
            return _nhanVienDAL.ThemNhanVien(nv);
        }

        public bool SuaNhanVien(NhanVien nv)
        {
            return _nhanVienDAL.SuaNhanVien(nv);
        }

        public bool XoaNhanVien(string maNV)
        {
            string thongBao;
            return _nhanVienDAL.XoaNhanVien(maNV, out thongBao);
        }

        public bool XoaNhanVien(string maNV, out string thongBao)
        {
            return _nhanVienDAL.XoaNhanVien(maNV, out thongBao);
        }
    }
}