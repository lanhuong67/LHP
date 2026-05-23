using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanDienThoai.Models;
using WebBanDienThoai.Helpers;

namespace WebBanDienThoai.Controllers
{
    public class ProductController : Controller
    {
        private readonly WebDbContext _db;

        public ProductController(WebDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string? keyword, string? maHang, string? maChiNhanh)
        {
            var query = _db.SanPhams
                .Include(sp => sp.HangSanXuat)
                .Include(sp => sp.ChiNhanh)
                .Where(sp => sp.TrangThai == "Đang kinh doanh");

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();

                query = query.Where(sp =>
                    sp.MaSP.Contains(keyword) ||
                    sp.TenSP.Contains(keyword) ||
                    sp.CauHinh.Contains(keyword));
            }

            if (!string.IsNullOrWhiteSpace(maHang))
            {
                query = query.Where(sp => sp.MaHang == maHang);
            }

            if (!string.IsNullOrWhiteSpace(maChiNhanh))
            {
                query = query.Where(sp => sp.MaChiNhanh == maChiNhanh);
            }

            ViewBag.HangSanXuat = _db.HangSanXuats
                .OrderBy(h => h.TenHang)
                .ToList();

            ViewBag.ChiNhanh = _db.ChiNhanhs
                .OrderBy(cn => cn.TenChiNhanh)
                .ToList();

            ViewBag.Keyword = keyword ?? "";
            ViewBag.MaHangDangChon = maHang ?? "";
            ViewBag.MaChiNhanhDangChon = maChiNhanh ?? "";

            var dsSanPham = query
                .OrderBy(sp => sp.TenSP)
                .ToList();
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItemViewModel>>("GIO_HANG")
           ?? new List<CartItemViewModel>();

            ViewBag.Cart = cart;
            ViewBag.CartCount = cart.Sum(x => x.SoLuong);
            ViewBag.CartTotal = cart.Sum(x => x.ThanhTien);
            return View(dsSanPham);
        }

        public IActionResult Detail(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var sp = _db.SanPhams
                .Include(x => x.HangSanXuat)
                .Include(x => x.ChiNhanh)
                .FirstOrDefault(x => x.MaSP == id);

            if (sp == null)
            {
                return NotFound();
            }

            return View(sp);
        }
    }
}