using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class BaoHanhDAL
    {
        private AppDbContext _db = new AppDbContext();

        // 1. Tìm hóa đơn và khách hàng dựa vào Mã HD hoặc SĐT
        public HoaDonViewModel TimHoaDonBaoHanh(string tuKhoa)
        {
            var query = from hd in _db.HoaDons
                        join kh in _db.KhachHangs on hd.SDTKhachHang equals kh.SDT into khGroup
                        from kh in khGroup.DefaultIfEmpty()
                        where (hd.MaHD == tuKhoa || hd.SDTKhachHang == tuKhoa) && hd.TrangThai == "Hoàn thành"
                        select new HoaDonViewModel
                        {
                            MaHD = hd.MaHD,
                            NgayLap = hd.NgayLap,
                            TenKhachHang = kh != null ? kh.HoTen : "Khách vãng lai",
                            // Lợi dụng biến này để truyền SĐT hiển thị lên UI tạm thời
                            TenNhanVien = hd.SDTKhachHang
                        };
            return query.FirstOrDefault(); // Lấy hóa đơn đầu tiên khớp
        }

        // 2. Lấy danh sách sản phẩm của Hóa đơn đó đẩy lên Bảng B2
        public List<SanPhamBaoHanhViewModel> GetSanPhamTuHoaDon(string maHD)
        {
            var query = from ct in _db.ChiTietHoaDons
                        join sp in _db.SanPhams on ct.MaSP equals sp.MaSP
                        where ct.MaHD == maHD
                        select new SanPhamBaoHanhViewModel
                        {
                            Chon = false,
                            MaSP = sp.MaSP,
                            TenSP = sp.TenSP,
                            SoLuong = ct.SoLuong,
                            DonGia = ct.DonGia,
                            Imei = ct.GhiChuImei
                        };
            return query.ToList();
        }

        // 3. Lưu phiếu bảo hành vào Database
        public bool TaoPhieuBaoHanh(PhieuBaoHanh pbh)
        {
            try
            {
                _db.PhieuBaoHanhs.Add(pbh);
                _db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}