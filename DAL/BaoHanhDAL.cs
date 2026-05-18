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

        public HoaDonViewModel TimHoaDonBaoHanh(string tuKhoa)
        {
            var query = from hd in _db.HoaDons
                        join kh in _db.KhachHangs on hd.SDTKhachHang equals kh.SDT into khGroup
                        from kh in khGroup.DefaultIfEmpty()
                        where (hd.MaHD == tuKhoa || hd.SDTKhachHang == tuKhoa) && hd.TrangThai == "Hoàn thành"
                        orderby hd.NgayLap descending // 🔴 TUYỆT CHIÊU: Luôn ưu tiên bốc hóa đơn mới mua nhất của khách hàng đó lên trước
                        select new HoaDonViewModel
                        {
                            MaHD = hd.MaHD,
                            NgayLap = hd.NgayLap,
                            TenKhachHang = kh != null ? kh.HoTen : "Khách vãng lai",
                            TenNhanVien = hd.SDTKhachHang
                        };
            return query.FirstOrDefault();
        }

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

        public List<TraCuuBaoHanhViewModel> GetDanhSachBaoHanh()
        {
            var query = from p in _db.PhieuBaoHanhs
                        join hd in _db.HoaDons on p.MaHD equals hd.MaHD
                        join kh in _db.KhachHangs on hd.SDTKhachHang equals kh.SDT into khGroup
                        from kh in khGroup.DefaultIfEmpty()
                        join sp in _db.SanPhams on p.MaSP equals sp.MaSP
                        select new TraCuuBaoHanhViewModel
                        {
                            MaPhieuBH = p.MaPhieuBH,
                            TenKhachHang = kh != null ? kh.HoTen : hd.SDTKhachHang,
                            TenSP = sp.TenSP,
                            NgayHetHanBH = p.NgayHetHanBH,
                            TrangThai = p.TrangThai
                        };
            return query.OrderByDescending(x => x.MaPhieuBH).ToList();
        }

        public bool CapNhatTrangThai(string maPhieu, string trangThaiMoi)
        {
            try
            {
                var pbh = _db.PhieuBaoHanhs.Find(maPhieu);
                if (pbh != null)
                {
                    pbh.TrangThai = trangThaiMoi;
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        // 🔴 ĐÃ THÊM HÀM NÀY ĐỂ TÌM CÁC IMEI ĐÃ BỊ BẢO HÀNH
        public List<string> GetImeiDaBaoHanh(string maHD)
        {
            return _db.PhieuBaoHanhs
                      .Where(x => x.MaHD == maHD && !string.IsNullOrEmpty(x.Imei))
                      .Select(x => x.Imei)
                      .ToList();
        }
    }
}