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
        public bool XoaNhanVien(string maNV)
        {
            try
            {
                // 1. Tìm nhân viên có mã tương ứng trong Database
                var nv = _db.NhanViens.FirstOrDefault(n => n.MaNV == maNV);

                // 2. Nếu tìm thấy thì tiến hành xóa
                if (nv != null)
                {
                    _db.NhanViens.Remove(nv);
                    _db.SaveChanges(); // Chốt lưu xuống SQL Server
                    return true;
                }
                return false; // Không tìm thấy nhân viên
            }
            catch
            {
                // Nếu chạy vào đây (báo lỗi Exception) thường là do dính Khóa Ngoại.
                // Tức là nhân viên này đã từng lập Phiếu nhập hoặc Hóa đơn, SQL Server sẽ chặn không cho xóa để bảo toàn lịch sử giao dịch.
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