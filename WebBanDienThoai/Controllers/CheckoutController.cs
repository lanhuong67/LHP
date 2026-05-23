using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanDienThoai.Helpers;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly WebDbContext _db;
        private const string CART_KEY = "GIO_HANG";

        private const string VIETQR_BANK_ID = "970422";
        private const string VIETQR_ACCOUNT_NO = "0123456789";
        private const string VIETQR_ACCOUNT_NAME = "LE HUU PHUC";

        public CheckoutController(WebDbContext db)
        {
            _db = db;
        }

        private List<CartItemViewModel> GetCart()
        {
            return HttpContext.Session.GetObjectFromJson<List<CartItemViewModel>>(CART_KEY)
                   ?? new List<CartItemViewModel>();
        }

        private void ClearCart()
        {
            HttpContext.Session.Remove(CART_KEY);
        }

        private bool DaDangNhap()
        {
            return !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("KH_MaKH"));
        }

        private IActionResult ChuyenSangDangNhap()
        {
            string returnUrl = Url.Action("Index", "Checkout") ?? "/Checkout";
            return RedirectToAction("Login", "Account", new { returnUrl });
        }

        private bool KiemTraGioHangCungChiNhanh(List<CartItemViewModel> cart, out string message)
        {
            message = "";

            if (cart.Count == 0)
            {
                message = "Giỏ hàng đang trống.";
                return false;
            }

            if (cart.Any(x => string.IsNullOrWhiteSpace(x.MaChiNhanh)))
            {
                message = "Giỏ hàng thiếu thông tin chi nhánh. Vui lòng xóa giỏ hàng và thêm lại sản phẩm.";
                return false;
            }

            int soChiNhanh = cart.Select(x => x.MaChiNhanh).Distinct().Count();

            if (soChiNhanh > 1)
            {
                message = "Giỏ hàng đang có sản phẩm thuộc nhiều chi nhánh. Vui lòng chỉ đặt sản phẩm trong cùng một chi nhánh.";
                return false;
            }

            return true;
        }

        public async Task<IActionResult> Index()
        {
            if (!DaDangNhap())
            {
                return ChuyenSangDangNhap();
            }

            var cart = GetCart();

            if (cart.Count == 0)
            {
                TempData["CartMessage"] = "Giỏ hàng đang trống, vui lòng chọn sản phẩm trước.";
                return RedirectToAction("Index", "Product");
            }

            if (!KiemTraGioHangCungChiNhanh(cart, out string message))
            {
                TempData["CartMessage"] = message;
                return RedirectToAction("Index", "Product");
            }

            string maKH = HttpContext.Session.GetString("KH_MaKH") ?? "";
            var khachHang = await _db.KhachHangs.FirstOrDefaultAsync(x => x.MaKH == maKH);

            if (khachHang == null)
            {
                return ChuyenSangDangNhap();
            }

            string maChiNhanh = cart.First().MaChiNhanh;
            string tenChiNhanh = cart.First().TenChiNhanh;

            ViewBag.Cart = cart;
            ViewBag.CartCount = cart.Sum(x => x.SoLuong);
            ViewBag.CartTotal = cart.Sum(x => x.ThanhTien);
            ViewBag.MaChiNhanh = maChiNhanh;
            ViewBag.TenChiNhanh = tenChiNhanh;

            var model = new CheckoutViewModel
            {
                HoTen = khachHang.HoTen,
                SDT = khachHang.SDT,
                DiaChiGiaoHang = "",
                MaChiNhanh = maChiNhanh,
                TenChiNhanh = tenChiNhanh,
                HinhThucNhanHang = "Nhận tại cửa hàng",
                PhuongThucThanhToan = "Thanh toán khi nhận hàng",
                MaGiamGia = ""
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(CheckoutViewModel model)
        {
            if (!DaDangNhap())
            {
                return ChuyenSangDangNhap();
            }

            var cart = GetCart();

            if (cart.Count == 0)
            {
                TempData["CartMessage"] = "Giỏ hàng đang trống, không thể đặt hàng.";
                return RedirectToAction("Index", "Product");
            }

            if (!KiemTraGioHangCungChiNhanh(cart, out string message))
            {
                TempData["CartMessage"] = message;
                return RedirectToAction("Index", "Product");
            }

            string maKH = HttpContext.Session.GetString("KH_MaKH") ?? "";
            var khachHang = await _db.KhachHangs.FirstOrDefaultAsync(x => x.MaKH == maKH);

            if (khachHang == null)
            {
                return ChuyenSangDangNhap();
            }

            string maChiNhanhTuGioHang = cart.First().MaChiNhanh;
            string tenChiNhanhTuGioHang = cart.First().TenChiNhanh;

            model.HoTen = khachHang.HoTen;
            model.SDT = khachHang.SDT;
            model.MaChiNhanh = maChiNhanhTuGioHang;
            model.TenChiNhanh = tenChiNhanhTuGioHang;

            ViewBag.Cart = cart;
            ViewBag.CartCount = cart.Sum(x => x.SoLuong);
            ViewBag.CartTotal = cart.Sum(x => x.ThanhTien);
            ViewBag.MaChiNhanh = maChiNhanhTuGioHang;
            ViewBag.TenChiNhanh = tenChiNhanhTuGioHang;

            if (model.HinhThucNhanHang == "Giao hàng" &&
                string.IsNullOrWhiteSpace(model.DiaChiGiaoHang))
            {
                ModelState.AddModelError("DiaChiGiaoHang", "Vui lòng nhập địa chỉ giao hàng.");
            }

            ModelState.Remove("HoTen");
            ModelState.Remove("SDT");
            ModelState.Remove("MaChiNhanh");
            ModelState.Remove("TenChiNhanh");

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                foreach (var item in cart)
                {
                    var sp = await _db.SanPhams
                        .FirstOrDefaultAsync(x =>
                            x.MaSP == item.MaSP &&
                            x.MaChiNhanh == maChiNhanhTuGioHang);

                    if (sp == null)
                    {
                        ModelState.AddModelError("", $"Không tìm thấy sản phẩm {item.TenSP} tại chi nhánh {tenChiNhanhTuGioHang}.");
                        return View("Index", model);
                    }

                    if (sp.TonKho < item.SoLuong)
                    {
                        ModelState.AddModelError("", $"Sản phẩm {item.TenSP} tại chi nhánh {tenChiNhanhTuGioHang} chỉ còn {sp.TonKho} sản phẩm.");
                        return View("Index", model);
                    }
                }

                decimal tongTienGoc = cart.Sum(x => x.ThanhTien);
                decimal giamGia = TinhGiamGia(model.MaGiamGia, tongTienGoc);
                decimal thanhTienSauGiam = tongTienGoc - giamGia;

                if (thanhTienSauGiam < 0)
                    thanhTienSauGiam = 0;

                string phuongThucThanhToan = model.PhuongThucThanhToan ?? "Thanh toán khi nhận hàng";
                string trangThaiThanhToan = phuongThucThanhToan == "Chuyển khoản"
                    ? "Chờ xác nhận"
                    : "Chưa thanh toán";

                string maHD = TaoMaHoaDon();

                string ghiChu = model.GhiChu ?? "";

                if (!string.IsNullOrWhiteSpace(model.MaGiamGia))
                {
                    string maGiamGia = model.MaGiamGia.Trim().ToUpper();

                    if (giamGia > 0)
                    {
                        ghiChu += $" | Mã giảm giá: {maGiamGia} - Giảm {giamGia:N0}đ";
                    }
                    else
                    {
                        ghiChu += $" | Khách nhập mã giảm giá không đủ điều kiện: {maGiamGia}";
                    }
                }

                var hoaDon = new HoaDonWeb
                {
                    MaHD = maHD,
                    NgayLap = DateTime.Now,
                    MaNV = "WEB",
                    SDTKhachHang = khachHang.SDT,

                    TongTienGoc = tongTienGoc,
                    GiamGia = giamGia,
                    ThanhTienSauGiam = thanhTienSauGiam,
                    TongTien = thanhTienSauGiam,

                    TrangThai = "Chờ xử lý",
                    MaChiNhanh = maChiNhanhTuGioHang,
                    LyDoHuy = "",

                    HinhThucNhanHang = model.HinhThucNhanHang ?? "",
                    DiaChiGiaoHang = model.HinhThucNhanHang == "Giao hàng"
                        ? (model.DiaChiGiaoHang ?? "")
                        : "",
                    GhiChuDonHang = ghiChu,

                    PhuongThucThanhToan = phuongThucThanhToan,
                    TrangThaiThanhToan = trangThaiThanhToan
                };

                _db.HoaDons.Add(hoaDon);

                foreach (var item in cart)
                {
                    var chiTiet = new ChiTietHoaDonWeb
                    {
                        MaHD = maHD,
                        MaSP = item.MaSP,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia,
                        ThanhTien = item.ThanhTien,
                        GhiChuImei = ""
                    };

                    _db.ChiTietHoaDons.Add(chiTiet);
                }

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                ClearCart();

                if (phuongThucThanhToan == "Chuyển khoản")
                {
                    return RedirectToAction("Payment", new { id = maHD });
                }

                return RedirectToAction("Success", new { id = maHD });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                string errorMessage = ex.InnerException?.Message ?? ex.Message;
                ModelState.AddModelError("", "Lỗi khi tạo đơn hàng: " + errorMessage);

                return View("Index", model);
            }
        }

        public async Task<IActionResult> Payment(string id)
        {
            var hoaDon = await _db.HoaDons.FirstOrDefaultAsync(x => x.MaHD == id);

            if (hoaDon == null)
            {
                return RedirectToAction("Index", "Product");
            }

            string noiDung = Uri.EscapeDataString(hoaDon.MaHD);
            string tenTaiKhoan = Uri.EscapeDataString(VIETQR_ACCOUNT_NAME);
            long soTien = Convert.ToInt64(hoaDon.ThanhTienSauGiam > 0 ? hoaDon.ThanhTienSauGiam : hoaDon.TongTien);

            string qrUrl =
                $"https://img.vietqr.io/image/{VIETQR_BANK_ID}-{VIETQR_ACCOUNT_NO}-compact2.png" +
                $"?amount={soTien}" +
                $"&addInfo={noiDung}" +
                $"&accountName={tenTaiKhoan}";

            ViewBag.QrUrl = qrUrl;
            ViewBag.BankId = VIETQR_BANK_ID;
            ViewBag.AccountNo = VIETQR_ACCOUNT_NO;
            ViewBag.AccountName = VIETQR_ACCOUNT_NAME;

            return View(hoaDon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmTransfer(string id)
        {
            var hoaDon = await _db.HoaDons.FirstOrDefaultAsync(x => x.MaHD == id);

            if (hoaDon == null)
            {
                return RedirectToAction("Index", "Product");
            }

            if (hoaDon.PhuongThucThanhToan == "Chuyển khoản" &&
                hoaDon.TrangThaiThanhToan == "Chờ xác nhận")
            {
                hoaDon.GhiChuDonHang =
                    (hoaDon.GhiChuDonHang ?? "") +
                    $" | Khách báo đã chuyển khoản lúc {DateTime.Now:dd/MM/yyyy HH:mm}";
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("Success", new { id });
        }

        public IActionResult Success(string id)
        {
            ViewBag.MaHD = id;
            return View();
        }

        private string TaoMaHoaDon()
        {
            return "HDWEB" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private decimal TinhGiamGia(string? maGiamGia, decimal tongTienGoc)
        {
            if (string.IsNullOrWhiteSpace(maGiamGia))
                return 0;

            string ma = maGiamGia.Trim().ToUpper();

            if (ma == "LHP50K")
                return tongTienGoc >= 500000 ? 50000 : 0;

            if (ma == "LHP10")
            {
                if (tongTienGoc >= 1000000)
                {
                    decimal giam = tongTienGoc * 0.10m;
                    return giam > 500000 ? 500000 : giam;
                }

                return 0;
            }

            if (ma == "VIP100K")
                return tongTienGoc >= 2000000 ? 100000 : 0;

            return 0;
        }
    }
}