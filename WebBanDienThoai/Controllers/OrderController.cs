using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Controllers
{
    public class OrderController : Controller
    {
        private readonly WebDbContext _db;

        public OrderController(WebDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Lookup(string? keyword)
        {
            var model = new OrderLookupViewModel();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                model.TuKhoa = keyword.Trim();
                model.KetQua = await TimKiemDonHang(model.TuKhoa);

                if (model.KetQua.Count == 0)
                {
                    ModelState.AddModelError("", "Không tìm thấy đơn hàng phù hợp.");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Lookup(OrderLookupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.TuKhoa = model.TuKhoa.Trim();
            model.KetQua = await TimKiemDonHang(model.TuKhoa);

            if (model.KetQua.Count == 0)
            {
                ModelState.AddModelError("", "Không tìm thấy đơn hàng phù hợp.");
            }

            return View(model);
        }

        private async Task<List<OrderLookupResultViewModel>> TimKiemDonHang(string tuKhoa)
        {
            var hoaDons = await (
                from hd in _db.HoaDons

                join kh in _db.KhachHangs
                    on hd.SDTKhachHang equals kh.SDT into khGroup
                from kh in khGroup.DefaultIfEmpty()

                join cn in _db.ChiNhanhs
                    on hd.MaChiNhanh equals cn.MaChiNhanh into cnGroup
                from cn in cnGroup.DefaultIfEmpty()

                where hd.MaHD.Contains(tuKhoa)
                      || hd.SDTKhachHang.Contains(tuKhoa)
                      || (kh != null && kh.HoTen.Contains(tuKhoa))

                orderby hd.NgayLap descending

                select new OrderLookupResultViewModel
                {
                    MaHD = hd.MaHD,
                    NgayLap = hd.NgayLap,
                    TenKhachHang = kh != null ? kh.HoTen : "Khách vãng lai",
                    SDTKhachHang = hd.SDTKhachHang,
                    TenChiNhanh = cn != null ? cn.TenChiNhanh : hd.MaChiNhanh,
                    TongTien = hd.TongTien,
                    TrangThai = hd.TrangThai,
                    LyDoHuy = hd.LyDoHuy,
                    NguonDon = hd.MaHD.StartsWith("HDWEB") ? "Web" : "Cửa hàng",

                    HinhThucNhanHang = hd.HinhThucNhanHang,
                    DiaChiGiaoHang = hd.DiaChiGiaoHang,
                    GhiChuDonHang = hd.GhiChuDonHang
                }
            ).ToListAsync();

            foreach (var hd in hoaDons)
            {
                hd.ChiTiet = await (
                    from ct in _db.ChiTietHoaDons
                    join sp in _db.SanPhams
                        on ct.MaSP equals sp.MaSP into spGroup
                    from sp in spGroup.DefaultIfEmpty()
                    where ct.MaHD == hd.MaHD
                    select new OrderLookupDetailViewModel
                    {
                        MaSP = ct.MaSP,
                        TenSP = sp != null ? sp.TenSP : ct.MaSP,
                        SoLuong = ct.SoLuong,
                        DonGia = ct.DonGia,
                        ThanhTien = ct.ThanhTien,
                        GhiChuImei = ct.GhiChuImei
                    }
                ).ToListAsync();
            }

            return hoaDons;
        }
    }
}