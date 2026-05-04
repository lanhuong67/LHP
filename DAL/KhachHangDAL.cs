using DTO;
using System.Collections.Generic;
using System.Linq;
using System;
namespace DAL
{
    public class KhachHangDAL
    {
        private AppDbContext _db = new AppDbContext();

        public List<KhachHang> GetAll()
        {
            return _db.KhachHangs.ToList();
        }

        public bool Them(KhachHang kh)
        {
            try
            {
                _db.KhachHangs.Add(kh);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Thay vì MessageBox, ta NÉM lỗi này lên tầng GUI để GUI hiện thông báo
                throw new Exception("Lỗi Database khi Thêm Khách Hàng: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        public bool Sua(KhachHang khUpdate)
        {
            try
            {
                var kh = _db.KhachHangs.FirstOrDefault(k => k.MaKH == khUpdate.MaKH);
                if (kh != null)
                {
                    kh.HoTen = khUpdate.HoTen;
                    kh.SDT = khUpdate.SDT;
                    kh.DiaChi = khUpdate.DiaChi;
                    // Không sửa SoLanMua và TongChiTieu ở đây, việc đó để Trigger lo!

                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        // Mình viết sẵn hàm Xóa cho bạn luôn
        public bool Xoa(string maKH)
        {
            try
            {
                var kh = _db.KhachHangs.FirstOrDefault(k => k.MaKH == maKH);
                if (kh != null)
                {
                    _db.KhachHangs.Remove(kh);
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; } // Sẽ lỗi nếu khách này đã có Hóa đơn (dính khóa ngoại)
        }
    }
}