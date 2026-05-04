using DTO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore; // Thêm thư viện này để dùng .Include()

namespace DAL
{
    public class SanPhamDAL
    {
        private AppDbContext _db = new AppDbContext();

        public List<SanPham> GetAll()
        {
            // Dùng Include để lấy luôn thông tin Tên Hãng đi kèm với Sản phẩm
            return _db.SanPhams.Include(s => s.HangSanXuat).ToList();
        }

        public List<HangSanXuat> GetAllHang()
        {
            return _db.HangSanXuats.ToList();
        }

        public bool Them(SanPham sp)
        {
            try { _db.SanPhams.Add(sp); _db.SaveChanges(); return true; } catch { return false; }
        }

        public bool Sua(SanPham spUpdate)
        {
            try
            {
                var sp = _db.SanPhams.FirstOrDefault(s => s.MaSP == spUpdate.MaSP);
                if (sp != null)
                {
                    sp.TenSP = spUpdate.TenSP;
                    sp.MaHang = spUpdate.MaHang;
                    sp.GiaNhap = spUpdate.GiaNhap;
                    sp.GiaBan = spUpdate.GiaBan;
                    sp.CauHinh = spUpdate.CauHinh;
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public bool Xoa(string maSP)
        {
            try
            {
                var sp = _db.SanPhams.FirstOrDefault(s => s.MaSP == maSP);
                if (sp != null) { _db.SanPhams.Remove(sp); _db.SaveChanges(); return true; }
                return false;
            }
            catch { return false; }
        }
    }
}