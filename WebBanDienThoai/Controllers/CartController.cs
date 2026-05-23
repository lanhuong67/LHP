using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanDienThoai.Helpers;
using WebBanDienThoai.Models;

namespace WebBanDienThoai.Controllers
{
    public class CartController : Controller
    {
        private readonly WebDbContext _db;
        private const string CART_KEY = "GIO_HANG";

        public CartController(WebDbContext db)
        {
            _db = db;
        }

        private List<CartItemViewModel> GetCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItemViewModel>>(CART_KEY);

            if (cart == null)
            {
                cart = new List<CartItemViewModel>();
            }

            return cart;
        }

        private void SaveCart(List<CartItemViewModel> cart)
        {
            HttpContext.Session.SetObjectAsJson(CART_KEY, cart);
        }

        private IActionResult BackToPreviousPage()
        {
            string? referer = Request.Headers["Referer"].ToString();

            if (!string.IsNullOrWhiteSpace(referer))
            {
                return Redirect(referer);
            }

            return RedirectToAction("Index", "Product");
        }

        public IActionResult Add(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction("Index", "Product");
            }

            var sp = _db.SanPhams
                .Include(x => x.HangSanXuat)
                .Include(x => x.ChiNhanh)
                .FirstOrDefault(x => x.MaSP == id);

            if (sp == null)
            {
                TempData["CartMessage"] = "Không tìm thấy sản phẩm.";
                return BackToPreviousPage();
            }

            if (sp.TonKho <= 0)
            {
                TempData["CartMessage"] = "Sản phẩm này đang tạm hết hàng.";
                return BackToPreviousPage();
            }

            var cart = GetCart();

            // ============================================================
            // QUAN TRỌNG:
            // Một giỏ hàng chỉ được chứa sản phẩm thuộc cùng một chi nhánh.
            // Tránh trường hợp sản phẩm ở Q1 nhưng checkout chọn Thủ Đức.
            // ============================================================
            if (cart.Count > 0)
            {
                string maChiNhanhDangCoTrongGio = cart.First().MaChiNhanh;

                if (string.IsNullOrWhiteSpace(maChiNhanhDangCoTrongGio))
                {
                    HttpContext.Session.Remove(CART_KEY);
                    TempData["CartMessage"] = "Giỏ hàng cũ thiếu thông tin chi nhánh. Vui lòng thêm lại sản phẩm.";
                    return BackToPreviousPage();
                }

                if (maChiNhanhDangCoTrongGio != sp.MaChiNhanh)
                {
                    TempData["CartMessage"] =
                        $"Giỏ hàng hiện đang thuộc chi nhánh {cart.First().TenChiNhanh}. " +
                        $"Bạn không thể thêm sản phẩm thuộc chi nhánh {sp.ChiNhanh?.TenChiNhanh}. " +
                        $"Vui lòng xóa giỏ hàng nếu muốn đặt ở chi nhánh khác.";

                    return BackToPreviousPage();
                }
            }

            var item = cart.FirstOrDefault(x => x.MaSP == id);

            if (item == null)
            {
                cart.Add(new CartItemViewModel
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    TenHang = sp.HangSanXuat?.TenHang ?? "",
                    MaChiNhanh = sp.MaChiNhanh,
                    TenChiNhanh = sp.ChiNhanh?.TenChiNhanh ?? "",
                    DonGia = sp.GiaBan,
                    SoLuong = 1,
                    TonKho = sp.TonKho
                });
            }
            else
            {
                if (item.SoLuong >= item.TonKho)
                {
                    TempData["CartMessage"] = "Số lượng trong giỏ đã đạt tồn kho hiện có.";
                    return BackToPreviousPage();
                }

                item.SoLuong++;
            }

            SaveCart(cart);

            TempData["CartMessage"] = "Đã thêm sản phẩm vào giỏ hàng.";

            return BackToPreviousPage();
        }

        public IActionResult Increase(string id)
        {
            var cart = GetCart();

            var item = cart.FirstOrDefault(x => x.MaSP == id);

            if (item != null)
            {
                if (item.SoLuong < item.TonKho)
                {
                    item.SoLuong++;
                    SaveCart(cart);
                }
                else
                {
                    TempData["CartMessage"] = "Không thể tăng vì đã đạt tồn kho.";
                }
            }

            return BackToPreviousPage();
        }

        public IActionResult Decrease(string id)
        {
            var cart = GetCart();

            var item = cart.FirstOrDefault(x => x.MaSP == id);

            if (item != null)
            {
                item.SoLuong--;

                if (item.SoLuong <= 0)
                {
                    cart.Remove(item);
                }

                SaveCart(cart);
            }

            return BackToPreviousPage();
        }

        public IActionResult Remove(string id)
        {
            var cart = GetCart();

            var item = cart.FirstOrDefault(x => x.MaSP == id);

            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }

            return BackToPreviousPage();
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove(CART_KEY);

            TempData["CartMessage"] = "Đã xóa toàn bộ giỏ hàng.";

            return BackToPreviousPage();
        }
    }
}