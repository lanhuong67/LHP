using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class NhanVienBUS
    {
        private NhanVienDAL _nhanVienDAL = new NhanVienDAL();

        // Đổi tên hàm thành Login
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
        public bool XoaNhanVien(string maNV)
        {
            // Gọi xuống tầng DAL để thực thi lệnh xóa
            return _nhanVienDAL.XoaNhanVien(maNV);
        }
        public bool SuaNhanVien(NhanVien nv)
        {
            // (Tùy chọn) Bạn có thể thêm các logic kiểm tra ở đây, ví dụ:
            // if(nv.HoTen.Length < 3) return false;
            return _nhanVienDAL.SuaNhanVien(nv);
        }
    }
}