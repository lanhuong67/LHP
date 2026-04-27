using DTO;
using System.Linq;

namespace DAL
{
    public class TaiKhoanDAL
    {
        private AppDbContext _db = new AppDbContext();

        public TaiKhoan KiemTraDangNhap(string user, string pass)
        {
            // Sử dụng LINQ để tìm tài khoản khớp username và password
            return _db.TaiKhoans.FirstOrDefault(tk => tk.TenDangNhap == user && tk.MatKhau == pass);
        }
    }
}