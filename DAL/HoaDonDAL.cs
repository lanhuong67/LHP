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

        // ============================================================
        // 1. LẤY DANH SÁCH IMEI TỒN KHO - BẢN CŨ
        // ============================================================
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

        // ============================================================
        // 2. LẤY DANH SÁCH IMEI TỒN KHO THEO CHI NHÁNH
        // ============================================================
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

        // ============================================================
        // 3. TẠO HÓA ĐƠN BÁN TRỰC TIẾP TẠI CỬA HÀNG
        // ============================================================
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

                    if (string.IsNullOrWhiteSpace(hd.PhuongThucThanhToan))
                    {
                        hd.PhuongThucThanhToan = "Tiền mặt";
                    }

                    if (string.IsNullOrWhiteSpace(hd.TrangThaiThanhToan))
                    {
                        hd.TrangThaiThanhToan = "Đã thanh toán";
                    }

                    if (hd.TongTienGoc <= 0)
                    {
                        hd.TongTienGoc = hd.TongTien;
                    }

                    if (hd.GiamGia < 0)
                    {
                        hd.GiamGia = 0;
                    }

                    if (hd.ThanhTienSauGiam <= 0)
                    {
                        hd.ThanhTienSauGiam = hd.TongTienGoc - hd.GiamGia;
                    }

                    if (hd.ThanhTienSauGiam < 0)
                    {
                        hd.ThanhTienSauGiam = 0;
                    }

                    // Giữ TongTien là số tiền cuối cùng để không phá các module cũ.
                    hd.TongTien = hd.ThanhTienSauGiam;

                    _db.HoaDons.Add(hd);
                    _db.SaveChanges();

                    foreach (var ct in dsChiTiet)
                    {
                        ct.MaHD = hd.MaHD;
                        _db.ChiTietHoaDons.Add(ct);

                        var sp = _db.SanPhams.FirstOrDefault(s =>
                            s.MaSP == ct.MaSP &&
                            s.MaChiNhanh == hd.MaChiNhanh
                        );

                        if (sp != null)
                        {
                            sp.TonKho -= ct.SoLuong;

                            if (sp.TonKho < 0)
                                sp.TonKho = 0;
                        }
                        else
                        {
                            throw new Exception($"Không tìm thấy sản phẩm [{ct.MaSP}] trong chi nhánh [{hd.MaChiNhanh}].");
                        }

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
                                      && imei.MaSP == ct.MaSP
                                      && imei.TrangThai == "Trong kho"
                                      && pn.MaChiNhanh == hd.MaChiNhanh
                                select imei
                            ).ToList();

                            if (imeisToUpdate.Count != listImei.Count)
                            {
                                throw new Exception($"Một số IMEI của sản phẩm [{ct.MaSP}] không hợp lệ, không còn trong kho hoặc không thuộc chi nhánh [{hd.MaChiNhanh}].");
                            }

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

        // ============================================================
        // 4. LẤY DANH SÁCH HÓA ĐƠN THEO CHI NHÁNH
        // ============================================================
        public List<HoaDonViewModel> GetDanhSachHoaDon(string maCN)
        {
            using (var db = new AppDbContext())
            {
                var query = from hd in db.HoaDons

                            join nv in db.NhanViens on hd.MaNV equals nv.MaNV into nvGroup
                            from nv in nvGroup.DefaultIfEmpty()

                            join kh in db.KhachHangs on hd.SDTKhachHang equals kh.SDT into khGroup
                            from kh in khGroup.DefaultIfEmpty()

                            where hd.MaChiNhanh == maCN

                            select new HoaDonViewModel
                            {
                                MaHD = hd.MaHD,
                                NgayLap = hd.NgayLap,

                                TenNhanVien = nv != null
                                    ? nv.HoTen
                                    : (
                                        hd.MaHD.StartsWith("HDWEB") && hd.TrangThai == "Chờ xử lý"
                                            ? "Chưa xử lý"
                                            : "Website"
                                      ),

                                TenKhachHang = kh != null ? kh.HoTen : "Khách vãng lai",

                                TongTien = hd.TongTien,
                                TrangThai = hd.TrangThai,
                                LyDoHuy = hd.LyDoHuy,

                                NguonDon = hd.MaHD.StartsWith("HDWEB") ? "Web" : "Cửa hàng",

                                HinhThucNhanHang = hd.HinhThucNhanHang,
                                DiaChiGiaoHang = hd.DiaChiGiaoHang,
                                GhiChuDonHang = hd.GhiChuDonHang,

                                PhuongThucThanhToan = hd.PhuongThucThanhToan,
                                TrangThaiThanhToan = hd.TrangThaiThanhToan,
                                TongTienGoc = hd.TongTienGoc,
                                GiamGia = hd.GiamGia,
                                ThanhTienSauGiam = hd.ThanhTienSauGiam
                            };

                return query.OrderByDescending(x => x.NgayLap).ToList();
            }
        }

        // ============================================================
        // 5. XEM CHI TIẾT HÓA ĐƠN
        // ============================================================
        public List<ChiTietHoaDonViewModel> GetChiTietHoaDon(string maHD)
        {
            var query = from ct in _db.ChiTietHoaDons
                        join sp in _db.SanPhams on ct.MaSP equals sp.MaSP
                        where ct.MaHD == maHD
                        select new ChiTietHoaDonViewModel
                        {
                            MaSP = ct.MaSP,
                            TenSP = sp.TenSP,
                            SoLuong = ct.SoLuong,
                            DonGia = ct.DonGia,
                            ThanhTien = ct.ThanhTien,
                            GhiChuImei = ct.GhiChuImei
                        };

            return query.ToList();
        }

        // ============================================================
        // 6. HỦY HÓA ĐƠN ĐÚNG NGHIỆP VỤ
        // ============================================================
        public bool HuyHoaDonThongTu78(string maHD, string lyDo, string maNhanVienHuy)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var hd = _db.HoaDons.FirstOrDefault(x => x.MaHD == maHD);

                    if (hd == null)
                        return false;

                    if (hd.TrangThai == "Đã hủy")
                        return false;

                    string trangThaiCu = hd.TrangThai;

                    hd.TrangThai = "Đã hủy";
                    hd.LyDoHuy = $"[{DateTime.Now:dd/MM/yyyy HH:mm}] NV {maNhanVienHuy} hủy: {lyDo}";

                    if (trangThaiCu == "Chờ xử lý")
                    {
                        _db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }

                    if (trangThaiCu == "Hoàn thành")
                    {
                        var chiTiets = _db.ChiTietHoaDons
                            .Where(x => x.MaHD == maHD)
                            .ToList();

                        foreach (var ct in chiTiets)
                        {
                            var sp = _db.SanPhams.FirstOrDefault(s =>
                                s.MaSP == ct.MaSP &&
                                s.MaChiNhanh == hd.MaChiNhanh
                            );

                            if (sp != null)
                            {
                                sp.TonKho += ct.SoLuong;
                            }

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

                        if (!string.IsNullOrEmpty(hd.SDTKhachHang))
                        {
                            var khachHang = _db.KhachHangs.FirstOrDefault(k => k.SDT == hd.SDTKhachHang);

                            if (khachHang != null)
                            {
                                khachHang.SoLanMua -= 1;

                                if (khachHang.SoLanMua < 0)
                                    khachHang.SoLanMua = 0;

                                khachHang.TongChiTieu -= hd.TongTien;

                                if (khachHang.TongChiTieu < 0)
                                    khachHang.TongChiTieu = 0;
                            }
                        }

                        _db.SaveChanges();
                        transaction.Commit();
                        return true;
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

        // ============================================================
        // 7. XỬ LÝ ĐƠN WEB: CHỜ XỬ LÝ -> HOÀN THÀNH
        // ============================================================
        public bool XacNhanDonWeb(string maHD, Dictionary<string, List<string>> imeiTheoSanPham, string maNhanVien)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var hd = _db.HoaDons.FirstOrDefault(x => x.MaHD == maHD);

                    if (hd == null)
                        throw new Exception("Không tìm thấy hóa đơn cần xử lý.");

                    if (hd.TrangThai != "Chờ xử lý")
                        throw new Exception("Chỉ có đơn trạng thái 'Chờ xử lý' mới được xác nhận.");

                    if (string.IsNullOrWhiteSpace(hd.MaChiNhanh))
                        throw new Exception("Hóa đơn chưa có mã chi nhánh.");

                    var chiTiets = _db.ChiTietHoaDons
                        .Where(x => x.MaHD == maHD)
                        .ToList();

                    if (chiTiets.Count == 0)
                        throw new Exception("Hóa đơn chưa có chi tiết sản phẩm.");

                    foreach (var ct in chiTiets)
                    {
                        if (!imeiTheoSanPham.ContainsKey(ct.MaSP))
                            throw new Exception($"Chưa chọn IMEI cho sản phẩm [{ct.MaSP}].");

                        var dsImeiChon = imeiTheoSanPham[ct.MaSP]
                            .Where(x => !string.IsNullOrWhiteSpace(x))
                            .Select(x => x.Trim())
                            .Distinct()
                            .ToList();

                        if (dsImeiChon.Count != ct.SoLuong)
                        {
                            throw new Exception($"Sản phẩm [{ct.MaSP}] yêu cầu {ct.SoLuong} IMEI, nhưng đang chọn {dsImeiChon.Count} IMEI.");
                        }

                        var sp = _db.SanPhams.FirstOrDefault(s =>
                            s.MaSP == ct.MaSP &&
                            s.MaChiNhanh == hd.MaChiNhanh
                        );

                        if (sp == null)
                            throw new Exception($"Không tìm thấy sản phẩm [{ct.MaSP}] trong chi nhánh [{hd.MaChiNhanh}].");

                        if (sp.TonKho < ct.SoLuong)
                            throw new Exception($"Sản phẩm [{sp.TenSP}] không đủ tồn kho. Còn {sp.TonKho}, cần {ct.SoLuong}.");

                        var imeisToUpdate = (
                            from imei in _db.ChiTietIMEIs
                            join pn in _db.PhieuNhaps on imei.MaPN equals pn.MaPN
                            where dsImeiChon.Contains(imei.IMEI)
                                  && imei.MaSP == ct.MaSP
                                  && imei.TrangThai == "Trong kho"
                                  && pn.MaChiNhanh == hd.MaChiNhanh
                            select imei
                        ).ToList();

                        if (imeisToUpdate.Count != ct.SoLuong)
                        {
                            throw new Exception($"Danh sách IMEI của sản phẩm [{ct.MaSP}] không hợp lệ hoặc không thuộc chi nhánh [{hd.MaChiNhanh}].");
                        }

                        sp.TonKho -= ct.SoLuong;

                        if (sp.TonKho < 0)
                            sp.TonKho = 0;

                        ct.GhiChuImei = string.Join(", ", dsImeiChon);

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

                    hd.TrangThai = "Hoàn thành";
                    hd.MaNV = string.IsNullOrWhiteSpace(maNhanVien) ? "NV01" : maNhanVien;

                    // Khi nhân viên xác nhận đơn web, xem như đơn đã thanh toán.
                    if (string.IsNullOrWhiteSpace(hd.TrangThaiThanhToan) ||
    hd.TrangThaiThanhToan == "Chưa thanh toán" ||
    hd.TrangThaiThanhToan == "Chờ xác nhận")
                    {
                        hd.TrangThaiThanhToan = "Đã thanh toán";
                    }

                    if (hd.TongTienGoc <= 0)
                    {
                        hd.TongTienGoc = hd.TongTien;
                    }

                    if (hd.ThanhTienSauGiam <= 0)
                    {
                        hd.ThanhTienSauGiam = hd.TongTien;
                    }

                    if (!string.IsNullOrWhiteSpace(hd.SDTKhachHang))
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
                    throw new Exception("Lỗi khi xác nhận đơn web: " + (ex.InnerException?.Message ?? ex.Message));
                }
            }
        }
    }
}