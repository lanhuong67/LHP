using System;
using DTO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SanPhamDAL
    {
        private AppDbContext _db = new AppDbContext();

        public List<SanPham> GetAll()
        {
            // Lấy toàn bộ sản phẩm kèm thông tin hãng
            return _db.SanPhams
                .Include(s => s.HangSanXuat)
                .ToList();
        }

        public List<SanPham> GetByBranch(string maCN)
        {
            // Lấy sản phẩm theo chi nhánh kèm thông tin hãng
            return _db.SanPhams
                .Include(s => s.HangSanXuat)
                .Where(s => s.MaChiNhanh == maCN)
                .ToList();
        }

        public List<HangSanXuat> GetAllHang()
        {
            return _db.HangSanXuats.ToList();
        }

        public bool Them(SanPham sp)
        {
            try
            {
                _db.SanPhams.Add(sp);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
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
                    sp.TrangThai = spUpdate.TrangThai;
                    sp.MaChiNhanh = spUpdate.MaChiNhanh;

                    _db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public bool Xoa(string maSP)
        {
            try
            {
                var sp = _db.SanPhams.FirstOrDefault(s => s.MaSP == maSP);

                if (sp != null)
                {
                    _db.SanPhams.Remove(sp);
                    _db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}