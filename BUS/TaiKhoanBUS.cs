using DAL;
using DTO;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private TaiKhoanDAL _dal = new TaiKhoanDAL();

        public TaiKhoan Login(string user, string pass)
        {
            // Kiểm tra rỗng trước khi gọi xuống Database
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                return null;

            return _dal.KiemTraDangNhap(user, pass);
        }
    }
}