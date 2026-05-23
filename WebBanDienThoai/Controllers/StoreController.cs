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
            var dsChiNhanh = await _db.ChiNhanhs
                .OrderBy(x => x.TenChiNhanh)
                .ToListAsync();

            return View(dsChiNhanh);
        }
    }
}