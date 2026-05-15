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

        // 1. LẤY DANH SÁCH IMEI SẴN SÀNG BÁN CỦA 1 SẢN PHẨM
        public List<string> GetImeiTonKho(string maSP)
        {
            // Đã sửa lại thành trạng thái "Trong kho" và thuộc tính "IMEI"
            return _db.ChiTietIMEIs
                      .Where(x => x.MaSP == maSP && x.TrangThai == "Trong kho")
                      .Select(x => x.IMEI)
                      .ToList();
        }

        // 2. TẠO HÓA ĐƠN & CẬP NHẬT LIÊN KẾT TOÀN DIỆN (SẢN PHẨM + LÔ HÀNG + KHÁCH HÀNG)
        public bool TaoHoaDon(HoaDon hd, List<ChiTietHoaDon> dsChiTiet)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.HoaDons.Add(hd);
                    _db.SaveChanges();

                    foreach (var ct in dsChiTiet)
                    {
                        ct.MaHD = hd.MaHD;
                        _db.ChiTietHoaDons.Add(ct);

                        // A. TRỪ TỒN KHO TRONG BẢNG SẢN PHẨM CHUNG
                        var sp = _db.SanPhams.FirstOrDefault(s => s.MaSP == ct.MaSP);
                        if (sp != null)
                        {
                            sp.TonKho -= ct.SoLuong;
                            if (sp.TonKho < 0) sp.TonKho = 0;
                        }

                        // B. CẬP NHẬT TRẠNG THÁI IMEI VÀ LIÊN KẾT VỚI LÔ HÀNG
                        if (!string.IsNullOrEmpty(ct.GhiChuImei))
                        {
                            var listImei = ct.GhiChuImei.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                        .Select(i => i.Trim())
                                                        .ToList();

                            var imeisToUpdate = _db.ChiTietIMEIs.Where(i => listImei.Contains(i.IMEI)).ToList();
                            foreach (var imei in imeisToUpdate)
                            {
                                // B1. Đổi trạng thái máy thành Đã bán
                                imei.TrangThai = "Đã bán";

                                // B2. [LIÊN KẾT LÔ HÀNG] - Tăng số lượng đã bán của lô đó lên 1
                                var loHang = _db.ChiTietPhieuNhaps.FirstOrDefault(pn => pn.MaPN == imei.MaPN && pn.MaSP == imei.MaSP);
                                if (loHang != null)
                                {
                                    loHang.SoLuongDaBan += 1;
                                }
                            }
                        }
                    }

                    // C. [LIÊN KẾT KHÁCH HÀNG] - Tích lũy số lần mua và tổng tiền chi tiêu
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

        // 3. LẤY DANH SÁCH HÓA ĐƠN (HỖ TRỢ HIỂN THỊ TÊN KHÁCH & NHÂN VIÊN)
        public List<HoaDonViewModel> GetDanhSachHoaDon()
        {
            var query = from hd in _db.HoaDons
                        join nv in _db.NhanViens on hd.MaNV equals nv.MaNV
                        join kh in _db.KhachHangs on hd.SDTKhachHang equals kh.SDT into khGroup
                        from kh in khGroup.DefaultIfEmpty()
                        select new HoaDonViewModel
                        {
                            MaHD = hd.MaHD,
                            NgayLap = hd.NgayLap,
                            TenNhanVien = nv.HoTen,
                            TenKhachHang = kh != null ? kh.HoTen : "Khách vãng lai",
                            TongTien = hd.TongTien,
                            TrangThai = hd.TrangThai
                        };
            return query.OrderByDescending(x => x.NgayLap).ToList();
        }
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
    }

}