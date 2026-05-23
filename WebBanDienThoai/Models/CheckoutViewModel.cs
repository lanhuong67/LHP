using System.ComponentModel.DataAnnotations;

namespace WebBanDienThoai.Models
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập họ tên khách hàng")]
        public string HoTen { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string SDT { get; set; } = string.Empty;

        public string? MaChiNhanh { get; set; }

        public string? TenChiNhanh { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn hình thức nhận hàng")]
        public string HinhThucNhanHang { get; set; } = "Nhận tại cửa hàng";

        public string? DiaChiGiaoHang { get; set; }

        public string? GhiChu { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn phương thức thanh toán")]
        public string PhuongThucThanhToan { get; set; } = "Thanh toán khi nhận hàng";

        public string? MaGiamGia { get; set; }
    }
}