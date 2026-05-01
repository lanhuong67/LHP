using DTO;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class NhanVienDAL
    {
        private AppDbContext _db = new AppDbContext();

        // Đổi tên hàm thành Login cho khớp với FormDangNhap
        public NhanVien? Login(string user, string pass)
        {
            return _db.NhanViens.FirstOrDefault(nv => nv.TenDangNhap == user && nv.MatKhau == pass);
        }

        public List<NhanVien> GetAllNhanVien()
        {
            return _db.NhanViens.ToList();
        }

        public bool ThemNhanVien(NhanVien nv)
        {
            try
            {
                _db.NhanViens.Add(nv);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // 4. Nghiệp vụ Cập nhật nhân viên
        public bool SuaNhanVien(NhanVien nvUpdate)
        {
            try
            {
                // Tìm nhân viên cũ trong Database dựa trên MaNV
                var nvCu = _db.NhanViens.FirstOrDefault(n => n.MaNV == nvUpdate.MaNV);

                if (nvCu != null)
                {
                    // Cập nhật các thông tin mới (Không cập nhật MaNV vì nó là khóa chính)
                    nvCu.HoTen = nvUpdate.HoTen;
                    nvCu.SDT = nvUpdate.SDT;
                    nvCu.Email = nvUpdate.Email;
                    nvCu.VaiTro = nvUpdate.VaiTro;
                    nvCu.TenDangNhap = nvUpdate.TenDangNhap;
                    nvCu.MatKhau = nvUpdate.MatKhau;

                    // Lưu thay đổi xuống SQL Server
                    _db.SaveChanges();
                    return true;
                }
                return false; // Trả về false nếu không tìm thấy nhân viên
            }
            catch
            {
                return false; // Bắt lỗi nếu có trục trặc (ví dụ: đứt mạng)
            }
        }
    }
}