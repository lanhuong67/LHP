using System.ComponentModel.DataAnnotations;

namespace WebBanDienThoai.Models
{
    public class AccountLoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string SDT { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string MatKhau { get; set; } = string.Empty;

        public string? ReturnUrl { get; set; }
    }

    public class AccountRegisterViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string HoTen { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string SDT { get; set; } = string.Empty;

        // Giữ lại để view Register cũ không lỗi nếu đang có ô Địa chỉ.
        // Nhưng hiện tại không lưu vào KhachHangWeb vì KhachHangWeb chưa có cột DiaChi.
        public string? DiaChi { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(6, ErrorMessage = "Mật khẩu tối thiểu 6 ký tự")]
        public string MatKhau { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu nhập lại không khớp")]
        public string NhapLaiMatKhau { get; set; } = string.Empty;

        public string? ReturnUrl { get; set; }
    }

    public class AccountProfileViewModel
    {
        public string MaKH { get; set; } = string.Empty;

        public string HoTen { get; set; } = string.Empty;

        public string SDT { get; set; } = string.Empty;

        public int SoLanMua { get; set; }

        public decimal TongChiTieu { get; set; }

        // View Profile hiện tại của bạn đang gọi Model.DonHang
        public List<HoaDonWeb> DonHang { get; set; } = new List<HoaDonWeb>();

        // Dự phòng nếu file nào dùng Model.HoaDons
        public List<HoaDonWeb> HoaDons
        {
            get => DonHang;
            set => DonHang = value ?? new List<HoaDonWeb>();
        }
    }

    // Giữ alias để nếu code nào còn dùng tên ngắn thì vẫn build được
    public class LoginViewModel : AccountLoginViewModel
    {
    }

    public class RegisterViewModel : AccountRegisterViewModel
    {
    }
}