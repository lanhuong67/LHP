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

        // ========================================================
        // HÀM MỚI: TÌM KHÁCH HÀNG THEO SỐ ĐIỆN THOẠI
        // Phục vụ cho tính năng gợi ý tên tự động bên Hóa Đơn
        // ========================================================
        public KhachHang TimKhachHangTheoSDT(string sdt)
        {
            try
            {
                // Tìm khách hàng đầu tiên khớp với số điện thoại truyền vào
                return _db.KhachHangs.FirstOrDefault(kh => kh.SDT == sdt);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm số điện thoại: " + ex.Message);
            }
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
            catch { return false; }
        }
    }
}