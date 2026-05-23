using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanDienThoai.Helpers;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Controllers
{
    public class AccountController : Controller
    {
        private readonly WebDbContext _db;

        public AccountController(WebDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            return View(new AccountLoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string sdt = model.SDT.Trim();

            var taiKhoan = await _db.TaiKhoanKhachHangs
                .Include(x => x.KhachHang)
                .FirstOrDefaultAsync(x => x.SDT == sdt);

            if (taiKhoan == null)
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại.");
                return View(model);
            }

            if (!TaiKhoanDangHoatDong(taiKhoan.TrangThai))
            {
                ModelState.AddModelError("", "Tài khoản đang bị khóa.");
                return View(model);
            }

            bool dungMatKhau = PasswordHasher.VerifyPassword(model.MatKhau, taiKhoan.MatKhauHash);

            if (!dungMatKhau)
            {
                ModelState.AddModelError("", "Mật khẩu không đúng.");
                return View(model);
            }

            if (taiKhoan.KhachHang == null)
            {
                ModelState.AddModelError("", "Không tìm thấy thông tin khách hàng của tài khoản này.");
                return View(model);
            }

            LuuSessionDangNhap(taiKhoan.KhachHang);

            if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }

            return RedirectToAction("Profile");
        }

        [HttpGet]
        public IActionResult Register(string? returnUrl = null)
        {
            return View(new AccountRegisterViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string sdt = model.SDT.Trim();

            if (!sdt.All(char.IsDigit) || sdt.Length < 9 || sdt.Length > 11)
            {
                ModelState.AddModelError("SDT", "Số điện thoại không hợp lệ. Vui lòng nhập từ 9 đến 11 chữ số.");
                return View(model);
            }

            bool daCoTaiKhoan = await _db.TaiKhoanKhachHangs
                .AnyAsync(x => x.SDT == sdt);

            if (daCoTaiKhoan)
            {
                ModelState.AddModelError("SDT", "Số điện thoại này đã đăng ký tài khoản.");
                return View(model);
            }

            var khachHang = await _db.KhachHangs
                .FirstOrDefaultAsync(x => x.SDT == sdt);

            if (khachHang == null)
            {
                khachHang = new KhachHangWeb
                {
                    MaKH = TaoMaKhachHang(),
                    HoTen = model.HoTen.Trim(),
                    SDT = sdt,
                    TongChiTieu = 0,
                    SoLanMua = 0
                };

                _db.KhachHangs.Add(khachHang);
            }
            else
            {
                khachHang.HoTen = model.HoTen.Trim();
            }

            var taiKhoan = new TaiKhoanKhachHangWeb
            {
                MaTaiKhoan = await TaoMaTaiKhoanTuDong(),
                MaKH = khachHang.MaKH,
                SDT = sdt,
                MatKhauHash = PasswordHasher.HashPassword(model.MatKhau),
                NgayDangKy = DateTime.Now,
                TrangThai = "Hoạt động"
            };

            _db.TaiKhoanKhachHangs.Add(taiKhoan);

            await _db.SaveChangesAsync();

            LuuSessionDangNhap(khachHang);

            if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }

            return RedirectToAction("Profile");
        }

        public async Task<IActionResult> Profile()
        {
            string? maKH = HttpContext.Session.GetString("KH_MaKH");

            if (string.IsNullOrWhiteSpace(maKH))
            {
                return RedirectToAction("Login");
            }

            var khachHang = await _db.KhachHangs
                .FirstOrDefaultAsync(x => x.MaKH == maKH);

            if (khachHang == null)
            {
                XoaSessionDangNhap();
                return RedirectToAction("Login");
            }

            var donHang = await _db.HoaDons
                .Where(x => x.SDTKhachHang == khachHang.SDT)
                .OrderByDescending(x => x.NgayLap)
                .Take(10)
                .ToListAsync();

            var model = new AccountProfileViewModel
            {
                MaKH = khachHang.MaKH,
                HoTen = khachHang.HoTen ?? "",
                SDT = khachHang.SDT ?? "",
                SoLanMua = khachHang.SoLanMua,
                TongChiTieu = khachHang.TongChiTieu,
                DonHang = donHang
            };

            return View(model);
        }

        public IActionResult Logout()
        {
            XoaSessionDangNhap();
            return RedirectToAction("Index", "Product");
        }

        private void LuuSessionDangNhap(KhachHangWeb khachHang)
        {
            HttpContext.Session.SetString("KH_MaKH", khachHang.MaKH);
            HttpContext.Session.SetString("KH_HoTen", khachHang.HoTen ?? "");
            HttpContext.Session.SetString("KH_SDT", khachHang.SDT ?? "");
        }

        private void XoaSessionDangNhap()
        {
            HttpContext.Session.Remove("KH_MaKH");
            HttpContext.Session.Remove("KH_HoTen");
            HttpContext.Session.Remove("KH_SDT");
        }

        private string TaoMaKhachHang()
        {
            return "KH" + DateTime.Now.ToString("yyMMddHHmmss");
        }

        private async Task<int> TaoMaTaiKhoanTuDong()
        {
            bool coTaiKhoan = await _db.TaiKhoanKhachHangs.AnyAsync();

            if (!coTaiKhoan)
                return 1;

            int maxMa = await _db.TaiKhoanKhachHangs.MaxAsync(x => x.MaTaiKhoan);

            return maxMa + 1;
        }

        private bool TaiKhoanDangHoatDong(string? trangThai)
        {
            if (string.IsNullOrWhiteSpace(trangThai))
                return false;

            string value = trangThai.Trim().ToLower();

            return value == "hoạt động"
                   || value == "hoat dong"
                   || value == "active"
                   || value == "true"
                   || value == "1";
        }
    }
}