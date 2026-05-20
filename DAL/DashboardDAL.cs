using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DashboardDAL
    {
        private AppDbContext _db = new AppDbContext();

        // ==========================================
        // 1. TỔNG QUAN (4 CARDS)
        // ==========================================
        public TongQuanDashboard GetTongQuan(int nam)
        {
            var result = new TongQuanDashboard();
            int thangHienTai = DateTime.Now.Month;
            int thangTruoc = thangHienTai == 1 ? 12 : thangHienTai - 1;
            int namThangTruoc = thangHienTai == 1 ? nam - 1 : nam;

            var hdHopLe = _db.HoaDons.Where(hd => hd.TrangThai != "Đã hủy");

            // Doanh thu tháng hiện tại
            result.DoanhThuThangHienTai = hdHopLe
                .Where(hd => hd.NgayLap.Month == thangHienTai && hd.NgayLap.Year == nam)
                .Sum(hd => (decimal?)hd.TongTien) ?? 0;

            // Doanh thu tháng trước
            result.DoanhThuThangTruoc = hdHopLe
                .Where(hd => hd.NgayLap.Month == thangTruoc && hd.NgayLap.Year == namThangTruoc)
                .Sum(hd => (decimal?)hd.TongTien) ?? 0;

            // Đơn hàng hôm nay
            var homNay = DateTime.Today;
            result.DonHangHomNay = hdHopLe
                .Count(hd => hd.NgayLap.Date == homNay);

            // Đơn hàng hôm qua
            var homQua = DateTime.Today.AddDays(-1);
            result.DonHangHomQua = hdHopLe
                .Count(hd => hd.NgayLap.Date == homQua);

            // Tổng khách hàng
            result.TongKhachHang = _db.KhachHangs.Count();

            // Khách hàng mới tháng này (lần đầu mua trong tháng)
            var sdtDaMuaTruoc = hdHopLe
                .Where(hd => hd.NgayLap < new DateTime(nam, thangHienTai, 1))
                .Select(hd => hd.SDTKhachHang)
                .Distinct();

            result.KhachHangMoiThang = hdHopLe
                .Where(hd => hd.NgayLap.Month == thangHienTai && hd.NgayLap.Year == nam)
                .Select(hd => hd.SDTKhachHang)
                .Distinct()
                .Count(sdt => !sdtDaMuaTruoc.Contains(sdt));

            // Sản phẩm sắp hết hàng (tồn kho <= 5)
            result.SanPhamSapHetHang = _db.SanPhams
                .Count(sp => sp.TonKho <= 5);

            return result;
        }

        // ==========================================
        // 2. DOANH THU THEO THÁNG (BIỂU ĐỒ)
        // ==========================================
        public List<DoanhThuTheoThang> GetDoanhThuTheoThang(int nam)
        {
            var result = Enumerable.Range(1, 12)
                .Select(t => new DoanhThuTheoThang { Thang = t, DoanhThu = 0 })
                .ToList();

            var data = _db.HoaDons
                .Where(hd => hd.NgayLap.Year == nam && hd.TrangThai != "Đã hủy")
                .GroupBy(hd => hd.NgayLap.Month)
                .Select(g => new { Thang = g.Key, DoanhThu = g.Sum(hd => hd.TongTien) })
                .ToList();

            foreach (var item in data)
                result[item.Thang - 1].DoanhThu = item.DoanhThu;

            return result;
        }

        // ==========================================
        // 3. TOP SẢN PHẨM BÁN CHẠY
        // ==========================================
        public List<SanPhamBanChay> GetTopSanPhamBanChay(int nam, int topN = 5)
        {
            var query = from ct in _db.ChiTietHoaDons
                        join hd in _db.HoaDons on ct.MaHD equals hd.MaHD
                        join sp in _db.SanPhams on ct.MaSP equals sp.MaSP
                        where hd.NgayLap.Year == nam && hd.TrangThai != "Đã hủy"
                        group new { ct, sp } by new { ct.MaSP, sp.TenSP } into g
                        orderby g.Sum(x => x.ct.SoLuong) descending
                        select new SanPhamBanChay
                        {
                            MaSP = g.Key.MaSP,
                            TenSP = g.Key.TenSP,
                            SoLuongBan = g.Sum(x => x.ct.SoLuong),
                            DoanhThu = g.Sum(x => x.ct.ThanhTien)
                        };

            var list = query.Take(topN).ToList();
            for (int i = 0; i < list.Count; i++)
                list[i].Rank = i + 1;

            return list;
        }

        // ==========================================
        // 4. CẢNH BÁO KHO (TỒN KHO THẤP)
        // ==========================================
        public List<SanPhamTonKho> GetSanPhamSapHetHang(int nguong = 5)
        {
            return _db.SanPhams
                .Where(sp => sp.TonKho <= nguong)
                .OrderBy(sp => sp.TonKho)
                .Take(10)
                .Select(sp => new SanPhamTonKho
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    SoLuongTon = sp.TonKho,
                    TrangThai = sp.TonKho == 0 ? "Hết hàng" : "Sắp hết"
                })
                .ToList();
        }

        // ==========================================
        // 5. BẢO HÀNH SẮP HẾT HẠN
        // ==========================================
        public List<BaoHanhSapHet> GetBaoHanhSapHetHan(int soNgay = 30)
        {
            var ngayGioiHan = DateTime.Today.AddDays(soNgay);

            var query = from pbh in _db.PhieuBaoHanhs
                        join hd in _db.HoaDons on pbh.MaHD equals hd.MaHD
                        join kh in _db.KhachHangs on hd.SDTKhachHang equals kh.SDT into khGroup
                        from kh in khGroup.DefaultIfEmpty()
                        join sp in _db.SanPhams on pbh.MaSP equals sp.MaSP
                        where pbh.TrangThai == "Đang hiệu lực"
                           && pbh.NgayHetHanBH >= DateTime.Today
                           && pbh.NgayHetHanBH <= ngayGioiHan
                        orderby pbh.NgayHetHanBH ascending
                        select new BaoHanhSapHet
                        {
                            MaPhieuBH = pbh.MaPhieuBH,
                            TenKhachHang = kh != null ? kh.HoTen : "Khách vãng lai",
                            SDT = kh != null ? kh.SDT : hd.SDTKhachHang,
                            TenSP = sp.TenSP,
                            NgayHetHan = pbh.NgayHetHanBH,
                            SoNgayCon = (int)(pbh.NgayHetHanBH - DateTime.Today).TotalDays
                        };

            return query.Take(10).ToList();
        }

        // ==========================================
        // 6. HOẠT ĐỘNG GẦN ĐÂY
        // ==========================================
        public List<string> GetHoatDongGanDay(int soLuong = 10)
        {
            var hdGanDay = (from hd in _db.HoaDons
                            join kh in _db.KhachHangs on hd.SDTKhachHang equals kh.SDT into khGroup
                            from kh in khGroup.DefaultIfEmpty()
                            where hd.TrangThai != "Đã hủy"
                            orderby hd.NgayLap descending
                            select new
                            {
                                NoiDung = "🛒 Bán hàng: " + hd.MaHD + " - KH: " +
                                          (kh != null ? kh.HoTen : "Khách vãng lai") +
                                          " (" + hd.NgayLap.ToString("dd/MM HH:mm") + ")",
                                Ngay = hd.NgayLap
                            })
                           .Take(soLuong)
                           .ToList();

            var bhGanDay = (from pbh in _db.PhieuBaoHanhs
                            join sp in _db.SanPhams on pbh.MaSP equals sp.MaSP
                            orderby pbh.NgayBatDauBH descending
                            select new
                            {
                                NoiDung = "🔒 Bảo hành: " + pbh.MaPhieuBH + " - SP: " +
                                          sp.TenSP +
                                          " (" + pbh.NgayBatDauBH.ToString("dd/MM HH:mm") + ")",
                                Ngay = pbh.NgayBatDauBH
                            })
                           .Take(soLuong)
                           .ToList();

            return hdGanDay.Select(x => new { x.NoiDung, x.Ngay })
                           .Concat(bhGanDay.Select(x => new { x.NoiDung, x.Ngay }))
                           .OrderByDescending(x => x.Ngay)
                           .Take(soLuong)
                           .Select(x => x.NoiDung)
                           .ToList();
        }
    }
}