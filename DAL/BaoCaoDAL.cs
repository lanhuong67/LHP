using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class BaoCaoDAL
    {
        // =====================================================
        // 1. DOANH THU THEO NGÀY
        // =====================================================
        public List<DoanhThuViewModel> GetDoanhThuTheoNgay(string maCN, DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new AppDbContext())
            {
                tuNgay = tuNgay.Date;
                denNgay = denNgay.Date.AddDays(1).AddTicks(-1);

                var data = db.HoaDons
                    .Where(hd =>
                        hd.MaChiNhanh == maCN &&
                        hd.TrangThai == "Hoàn thành" &&
                        hd.NgayLap >= tuNgay &&
                        hd.NgayLap <= denNgay)
                    .GroupBy(hd => hd.NgayLap.Date)
                    .Select(g => new
                    {
                        Ngay = g.Key,
                        SoHoaDon = g.Count(),
                        DoanhThu = g.Sum(x => x.TongTien)
                    })
                    .OrderBy(x => x.Ngay)
                    .ToList();

                return data.Select(x => new DoanhThuViewModel
                {
                    ThoiGian = x.Ngay.ToString("dd/MM/yyyy"),
                    SoHoaDon = x.SoHoaDon,
                    DoanhThu = x.DoanhThu
                }).ToList();
            }
        }

        // =====================================================
        // 2. DOANH THU THEO THÁNG
        // =====================================================
        public List<DoanhThuViewModel> GetDoanhThuTheoThang(string maCN, int nam)
        {
            using (var db = new AppDbContext())
            {
                var data = db.HoaDons
                    .Where(hd =>
                        hd.MaChiNhanh == maCN &&
                        hd.TrangThai == "Hoàn thành" &&
                        hd.NgayLap.Year == nam)
                    .GroupBy(hd => hd.NgayLap.Month)
                    .Select(g => new
                    {
                        Thang = g.Key,
                        SoHoaDon = g.Count(),
                        DoanhThu = g.Sum(x => x.TongTien)
                    })
                    .OrderBy(x => x.Thang)
                    .ToList();

                return data.Select(x => new DoanhThuViewModel
                {
                    ThoiGian = "Tháng " + x.Thang,
                    SoHoaDon = x.SoHoaDon,
                    DoanhThu = x.DoanhThu
                }).ToList();
            }
        }

        // =====================================================
        // 3. DOANH THU THEO NĂM
        // =====================================================
        public List<DoanhThuViewModel> GetDoanhThuTheoNam(string maCN)
        {
            using (var db = new AppDbContext())
            {
                var data = db.HoaDons
                    .Where(hd =>
                        hd.MaChiNhanh == maCN &&
                        hd.TrangThai == "Hoàn thành")
                    .GroupBy(hd => hd.NgayLap.Year)
                    .Select(g => new
                    {
                        Nam = g.Key,
                        SoHoaDon = g.Count(),
                        DoanhThu = g.Sum(x => x.TongTien)
                    })
                    .OrderBy(x => x.Nam)
                    .ToList();

                return data.Select(x => new DoanhThuViewModel
                {
                    ThoiGian = x.Nam.ToString(),
                    SoHoaDon = x.SoHoaDon,
                    DoanhThu = x.DoanhThu
                }).ToList();
            }
        }

        // =====================================================
        // 4. TÍNH TỔNG QUAN DOANH THU
        // =====================================================
        public TongQuanDoanhThuViewModel TinhTongQuan(List<DoanhThuViewModel> ds)
        {
            if (ds == null || ds.Count == 0)
            {
                return new TongQuanDoanhThuViewModel
                {
                    TongDoanhThu = 0,
                    SoHoaDon = 0
                };
            }

            return new TongQuanDoanhThuViewModel
            {
                TongDoanhThu = ds.Sum(x => x.DoanhThu),
                SoHoaDon = ds.Sum(x => x.SoHoaDon)
            };
        }

        // =====================================================
        // 5. TOP SẢN PHẨM BÁN CHẠY
        // =====================================================
        public List<TopSanPhamBanChayViewModel> GetTopSanPhamBanChay(string maCN, DateTime? tuNgay, DateTime? denNgay, int top = 10)
        {
            using (var db = new AppDbContext())
            {
                var query = from hd in db.HoaDons
                            join ct in db.ChiTietHoaDons on hd.MaHD equals ct.MaHD
                            join sp in db.SanPhams on ct.MaSP equals sp.MaSP
                            join hang in db.HangSanXuats on sp.MaHang equals hang.MaHang into hangGroup
                            from hang in hangGroup.DefaultIfEmpty()
                            where hd.MaChiNhanh == maCN
                                  && hd.TrangThai == "Hoàn thành"
                            select new
                            {
                                hd.NgayLap,
                                ct.MaSP,
                                sp.TenSP,
                                TenHang = hang != null ? hang.TenHang : "Không xác định",
                                ct.SoLuong,
                                ct.ThanhTien
                            };

                if (tuNgay.HasValue)
                {
                    DateTime start = tuNgay.Value.Date;
                    query = query.Where(x => x.NgayLap >= start);
                }

                if (denNgay.HasValue)
                {
                    DateTime end = denNgay.Value.Date.AddDays(1).AddTicks(-1);
                    query = query.Where(x => x.NgayLap <= end);
                }

                var data = query
                    .GroupBy(x => new
                    {
                        x.MaSP,
                        x.TenSP,
                        x.TenHang
                    })
                    .Select(g => new
                    {
                        MaSP = g.Key.MaSP,
                        TenSP = g.Key.TenSP,
                        TenHang = g.Key.TenHang,
                        SoLuongBan = g.Sum(x => x.SoLuong),
                        DoanhThu = g.Sum(x => x.ThanhTien)
                    })
                    .OrderByDescending(x => x.SoLuongBan)
                    .ThenByDescending(x => x.DoanhThu)
                    .Take(top)
                    .ToList();

                int hangXep = 1;

                return data.Select(x => new TopSanPhamBanChayViewModel
                {
                    Hang = hangXep++,
                    MaSP = x.MaSP,
                    TenSP = x.TenSP,
                    TenHang = x.TenHang,
                    SoLuongBan = x.SoLuongBan,
                    DoanhThu = x.DoanhThu
                }).ToList();
            }
        }

        // =====================================================
        // 6. DASHBOARD - 4 Ô TỔNG QUAN
        // =====================================================
        public DashboardTongQuanViewModel GetDashboardTongQuan(string maCN)
        {
            using (var db = new AppDbContext())
            {
                DateTime today = DateTime.Today;
                DateTime dauThang = new DateTime(today.Year, today.Month, 1);
                DateTime cuoiThang = dauThang.AddMonths(1).AddTicks(-1);
                DateTime cuoiNgay = today.AddDays(1).AddTicks(-1);

                decimal doanhThuThangNay = db.HoaDons
                    .Where(hd =>
                        hd.MaChiNhanh == maCN &&
                        hd.TrangThai == "Hoàn thành" &&
                        hd.NgayLap >= dauThang &&
                        hd.NgayLap <= cuoiThang)
                    .Sum(hd => (decimal?)hd.TongTien) ?? 0;

                int donHangHomNay = db.HoaDons.Count(hd =>
                    hd.MaChiNhanh == maCN &&
                    hd.TrangThai == "Hoàn thành" &&
                    hd.NgayLap >= today &&
                    hd.NgayLap <= cuoiNgay);

                // Khách hàng đang quản lý toàn hệ thống, nên không lọc chi nhánh
                int tongKhachHang = db.KhachHangs.Count();

                int sanPhamSapHet = db.SanPhams.Count(sp =>
                    sp.MaChiNhanh == maCN &&
                    sp.TonKho <= 4);

                return new DashboardTongQuanViewModel
                {
                    DoanhThuThangNay = doanhThuThangNay,
                    DonHangHomNay = donHangHomNay,
                    TongKhachHang = tongKhachHang,
                    SanPhamSapHet = sanPhamSapHet
                };
            }
        }

        // =====================================================
        // 7. DASHBOARD - CẢNH BÁO TỒN KHO
        // =====================================================
        public List<CanhBaoTonKhoDashboardViewModel> GetCanhBaoTonKhoDashboard(string maCN, int take = 5)
        {
            using (var db = new AppDbContext())
            {
                var data = db.SanPhams
                    .Where(sp =>
                        sp.MaChiNhanh == maCN &&
                        sp.TonKho <= 4)
                    .OrderBy(sp => sp.TonKho)
                    .Take(take)
                    .ToList();

                return data.Select(sp => new CanhBaoTonKhoDashboardViewModel
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    TonKho = sp.TonKho,
                    MucCanhBao = sp.TonKho <= 2 ? "Nguy hiểm" : "Sắp hết"
                }).ToList();
            }
        }

        // =====================================================
        // 8. DASHBOARD - BẢO HÀNH SẮP HẾT
        // =====================================================
        public List<BaoHanhSapHetDashboardViewModel> GetBaoHanhSapHetDashboard(string maCN, int soNgay = 30, int take = 5)
        {
            using (var db = new AppDbContext())
            {
                DateTime today = DateTime.Today;
                DateTime hanCanhBao = today.AddDays(soNgay);

                var query = from pbh in db.PhieuBaoHanhs
                            join hd in db.HoaDons on pbh.MaHD equals hd.MaHD
                            join sp in db.SanPhams on pbh.MaSP equals sp.MaSP
                            join kh in db.KhachHangs on hd.SDTKhachHang equals kh.SDT into khGroup
                            from kh in khGroup.DefaultIfEmpty()
                            where hd.MaChiNhanh == maCN
                                  && pbh.NgayHetHanBH >= today
                                  && pbh.NgayHetHanBH <= hanCanhBao
                                  && pbh.TrangThai != "Đã hết hạn"
                            orderby pbh.NgayHetHanBH
                            select new
                            {
                                pbh.MaPhieuBH,
                                TenKhachHang = kh != null ? kh.HoTen : hd.SDTKhachHang,
                                sp.TenSP,
                                pbh.NgayHetHanBH,
                                pbh.TrangThai
                            };

                var data = query.Take(take).ToList();

                return data.Select(x => new BaoHanhSapHetDashboardViewModel
                {
                    MaPhieuBH = x.MaPhieuBH,
                    TenKhachHang = x.TenKhachHang,
                    TenSP = x.TenSP,
                    NgayHetHanBH = x.NgayHetHanBH,
                    TrangThai = x.TrangThai
                }).ToList();
            }
        }

        // =====================================================
        // 9. DASHBOARD - HOẠT ĐỘNG GẦN ĐÂY
        // =====================================================
        public List<HoatDongGanDayViewModel> GetHoatDongGanDayDashboard(string maCN, int take = 5)
        {
            using (var db = new AppDbContext())
            {
                var data = db.HoaDons
                    .Where(hd => hd.MaChiNhanh == maCN)
                    .OrderByDescending(hd => hd.NgayLap)
                    .Take(take)
                    .ToList();

                return data.Select(hd => new HoatDongGanDayViewModel
                {
                    ThoiGian = hd.NgayLap,
                    LoaiHoatDong = "Hóa đơn",
                    NoiDung = "HĐ " + hd.MaHD.Replace("HD", "") + " - " + hd.TongTien.ToString("N0") + "đ",
                    GiaTri = hd.TongTien
                }).ToList();
            }
        }
    }
}