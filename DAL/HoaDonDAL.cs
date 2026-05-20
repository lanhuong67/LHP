using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class HoaDonDAL
    {
        private AppDbContext _db = new AppDbContext();

        // 1. LẤY DANH SÁCH IMEI SẴN SÀNG BÁN
        // BẢN CŨ: dùng cho các UC cũ nếu vẫn đang gọi GetImeiTonKho(maSP)
        public List<string> GetImeiTonKho(string maSP)
        {
            var query = from imei in _db.ChiTietIMEIs
                        join pn in _db.PhieuNhaps on imei.MaPN equals pn.MaPN
                        where imei.MaSP == maSP
                              && imei.TrangThai == "Trong kho"
                        orderby pn.NgayNhap ascending
                        select imei.IMEI;

            return query.ToList();
        }

        // BẢN MỚI: dùng cho đa chi nhánh, nên ưu tiên dùng khi sửa UC_TaoHoaDon sau này
        public List<string> GetImeiTonKho(string maSP, string maCN)
        {
            var query = from imei in _db.ChiTietIMEIs
                        join pn in _db.PhieuNhaps on imei.MaPN equals pn.MaPN
                        where imei.MaSP == maSP
                              && imei.TrangThai == "Trong kho"
                              && pn.MaChiNhanh == maCN
                        orderby pn.NgayNhap ascending
                        select imei.IMEI;

            return query.ToList();
        }

        // 2. TẠO HÓA ĐƠN & CẬP NHẬT LIÊN KẾT TOÀN DIỆN
        public bool TaoHoaDon(HoaDon hd, List<ChiTietHoaDon> dsChiTiet)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(hd.MaChiNhanh))
                    {
                        throw new Exception("Hóa đơn chưa có mã chi nhánh. Vui lòng kiểm tra UserSession.ChiNhanhDuocChon.");
                    }

                    _db.HoaDons.Add(hd);
                    _db.SaveChanges();

                    foreach (var ct in dsChiTiet)
                    {
                        ct.MaHD = hd.MaHD;
                        _db.ChiTietHoaDons.Add(ct);

                        // A. TRỪ TỒN KHO ĐÚNG CHI NHÁNH
                        var sp = _db.SanPhams.FirstOrDefault(s =>
                            s.MaSP == ct.MaSP &&
                            s.MaChiNhanh == hd.MaChiNhanh
                        );

                        if (sp != null)
                        {
                            sp.TonKho -= ct.SoLuong;
                            if (sp.TonKho < 0) sp.TonKho = 0;
                        }
                        else
                        {
                            throw new Exception($"Không tìm thấy sản phẩm [{ct.MaSP}] trong chi nhánh [{hd.MaChiNhanh}].");
                        }

                        // B. CẬP NHẬT TRẠNG THÁI IMEI VÀ LIÊN KẾT VỚI LÔ HÀNG
                        if (!string.IsNullOrEmpty(ct.GhiChuImei))
                        {
                            var listImei = ct.GhiChuImei
                                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(i => i.Trim())
                                .ToList();

                            var imeisToUpdate = (
                                from imei in _db.ChiTietIMEIs
                                join pn in _db.PhieuNhaps on imei.MaPN equals pn.MaPN
                                where listImei.Contains(imei.IMEI)
                                      && pn.MaChiNhanh == hd.MaChiNhanh
                                select imei
                            ).ToList();

                            foreach (var imei in imeisToUpdate)
                            {
                                imei.TrangThai = "Đã bán";

                                var loHang = _db.ChiTietPhieuNhaps.FirstOrDefault(pn =>
                                    pn.MaPN == imei.MaPN &&
                                    pn.MaSP == imei.MaSP
                                );

                                if (loHang != null)
                                {
                                    loHang.SoLuongDaBan += 1;
                                }
                            }
                        }
                    }

                    // C. CẬP NHẬT KHÁCH HÀNG
                    if (!string.IsNullOrEmpty(hd.SDTKhachHang))
                    {
                        var khachHang = _db.KhachHangs.FirstOrDefault(k => k.SDT == hd.SDTKhachHang);

                        if (khachHang != null)
                        {
                            khachHang.SoLanMua += 1;
                            khachHang.TongChiTieu += hd.TongTien;
                        }
                    }

                    _db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Lỗi khi tạo hóa đơn: " + (ex.InnerException?.Message ?? ex.Message));
                }
            }
        }

        // 3. LẤY DANH SÁCH HÓA ĐƠN THEO CHI NHÁNH
        public List<HoaDonViewModel> GetDanhSachHoaDon(string maCN)
        {
            using (var db = new AppDbContext())
            {
                var query = from hd in db.HoaDons
                            join nv in db.NhanViens on hd.MaNV equals nv.MaNV
                            join kh in db.KhachHangs on hd.SDTKhachHang equals kh.SDT into khGroup
                            from kh in khGroup.DefaultIfEmpty()
                            where hd.MaChiNhanh == maCN
                            select new HoaDonViewModel
                            {
                                MaHD = hd.MaHD,
                                NgayLap = hd.NgayLap,
                                TenNhanVien = nv.HoTen,
                                TenKhachHang = kh != null ? kh.HoTen : "Khách vãng lai",
                                TongTien = hd.TongTien,
                                TrangThai = hd.TrangThai,

                                // Thêm dòng này
                                LyDoHuy = hd.LyDoHuy
                            };

                return query.OrderByDescending(x => x.NgayLap).ToList();
            }
        }

        // 4. XEM CHI TIẾT HÓA ĐƠN
        public List<ChiTietHoaDonViewModel> GetChiTietHoaDon(string maHD)
        {
            var query = from ct in _db.ChiTietHoaDons
                        join sp in _db.SanPhams on ct.MaSP equals sp.MaSP
                        where ct.MaHD == maHD
                        select new ChiTietHoaDonViewModel
                        {
                            TenSP = sp.TenSP,
                            SoLuong = ct.SoLuong,
                            DonGia = ct.DonGia,
                            ThanhTien = ct.ThanhTien,
                            GhiChuImei = ct.GhiChuImei
                        };

            return query.ToList();
        }

        // 5. HỦY HÓA ĐƠN VÀ HOÀN KHO ĐÚNG CHI NHÁNH
        public bool HuyHoaDonThongTu78(string maHD, string lyDo, string maNhanVienHuy)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var hd = _db.HoaDons.FirstOrDefault(x => x.MaHD == maHD);

                    if (hd == null || hd.TrangThai == "Đã hủy")
                        return false;

                    hd.TrangThai = "Đã hủy";
                    hd.LyDoHuy = $"[{DateTime.Now:dd/MM/yyyy HH:mm}] NV {maNhanVienHuy} hủy: {lyDo}";

                    var chiTiets = _db.ChiTietHoaDons
                        .Where(x => x.MaHD == maHD)
                        .ToList();

                    foreach (var ct in chiTiets)
                    {
                        // A. HOÀN TỒN KHO ĐÚNG CHI NHÁNH
                        var sp = _db.SanPhams.FirstOrDefault(s =>
                            s.MaSP == ct.MaSP &&
                            s.MaChiNhanh == hd.MaChiNhanh
                        );

                        if (sp != null)
                        {
                            sp.TonKho += ct.SoLuong;
                        }

                        // B. NHẢ IMEI VỀ TRẠNG THÁI TRONG KHO
                        if (!string.IsNullOrEmpty(ct.GhiChuImei))
                        {
                            var listImei = ct.GhiChuImei
                                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(i => i.Trim())
                                .ToList();

                            var imeisToUpdate = (
                                from imei in _db.ChiTietIMEIs
                                join pn in _db.PhieuNhaps on imei.MaPN equals pn.MaPN
                                where listImei.Contains(imei.IMEI)
                                      && pn.MaChiNhanh == hd.MaChiNhanh
                                select imei
                            ).ToList();

                            foreach (var imei in imeisToUpdate)
                            {
                                imei.TrangThai = "Trong kho";

                                var loHang = _db.ChiTietPhieuNhaps.FirstOrDefault(pn =>
                                    pn.MaPN == imei.MaPN &&
                                    pn.MaSP == imei.MaSP
                                );

                                if (loHang != null)
                                {
                                    loHang.SoLuongDaBan -= 1;

                                    if (loHang.SoLuongDaBan < 0)
                                        loHang.SoLuongDaBan = 0;
                                }
                            }
                        }
                    }

                    _db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Lỗi khi hủy hóa đơn: " + (ex.InnerException?.Message ?? ex.Message));
                }
            }
        }
    }
}