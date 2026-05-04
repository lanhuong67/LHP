using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class HangSanXuatDAL
    {
        private AppDbContext _db = new AppDbContext();

        public List<HangSanXuat> GetAll()
        {
            try
            {
                return _db.HangSanXuats.ToList();
            }
            catch (Exception ex)
            {
                // Ném lỗi về tầng trên xử lý hiển thị
                throw new Exception("Lỗi lấy dữ liệu từ Database: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        public bool Them(HangSanXuat hsx)
        {
            try
            {
                _db.HangSanXuats.Add(hsx);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi Database khi Thêm: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        public bool Sua(HangSanXuat hsxUpdate)
        {
            try
            {
                var hsx = _db.HangSanXuats.FirstOrDefault(h => h.MaHang == hsxUpdate.MaHang);
                if (hsx != null)
                {
                    hsx.TenHang = hsxUpdate.TenHang;
                    hsx.QuocGia = hsxUpdate.QuocGia;
                    hsx.MoTa = hsxUpdate.MoTa;
                    hsx.TrangThai = hsxUpdate.TrangThai;

                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi Database khi Sửa: " + ex.Message);
            }
        }

        public bool Xoa(string maHang)
        {
            try
            {
                var hsx = _db.HangSanXuats.FirstOrDefault(h => h.MaHang == maHang);
                if (hsx != null)
                {
                    _db.HangSanXuats.Remove(hsx);
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi Database khi Xóa: " + ex.Message);
            }
        }
    }
}