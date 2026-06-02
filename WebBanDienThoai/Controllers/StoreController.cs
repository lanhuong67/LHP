using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Controllers
{
    public class StoreController : Controller
    {
        private readonly WebDbContext _db;

        public StoreController(WebDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var trangThaiHoatDong = LayDanhSachTrangThaiHoatDong();

            var dsChiNhanh = await _db.ChiNhanhs
                .Where(x => trangThaiHoatDong.Contains(x.TrangThai))
                .OrderBy(x => x.TenChiNhanh)
                .ToListAsync();

            return View(dsChiNhanh);
        }

        private string[] LayDanhSachTrangThaiHoatDong()
        {
            return new[]
            {
                "Đang hoạt động",
                "Hoạt động",
                "Đang kinh doanh",
                "Kích hoạt",
                "Active",
                "active",
                "True",
                "true",
                "1"
            };
        }
    }
}