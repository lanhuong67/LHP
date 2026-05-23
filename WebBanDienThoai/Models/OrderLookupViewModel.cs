using System.ComponentModel.DataAnnotations;

namespace WebBanDienThoai.Models
{
    public class OrderLookupViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập mã đơn hàng hoặc số điện thoại")]
        public string TuKhoa { get; set; } = string.Empty;

        public List<OrderLookupResultViewModel> KetQua { get; set; } = new List<OrderLookupResultViewModel>();
    }

    public class OrderLookupResultViewModel
    {
        public string MaHD { get; set; } = string.Empty;

        public DateTime NgayLap { get; set; }

        public string TenKhachHang { get; set; } = string.Empty;

        public string SDTKhachHang { get; set; } = string.Empty;

        public string TenChiNhanh { get; set; } = string.Empty;

        public decimal TongTien { get; set; }

        public string TrangThai { get; set; } = string.Empty;

        public string LyDoHuy { get; set; } = string.Empty;

        public string NguonDon { get; set; } = string.Empty;

        public string HinhThucNhanHang { get; set; } = string.Empty;

        public string DiaChiGiaoHang { get; set; } = string.Empty;

        public string GhiChuDonHang { get; set; } = string.Empty;

        public List<OrderLookupDetailViewModel> ChiTiet { get; set; } = new List<OrderLookupDetailViewModel>();
    }

    public class OrderLookupDetailViewModel
    {
        public string MaSP { get; set; } = string.Empty;

        public string TenSP { get; set; } = string.Empty;

        public int SoLuong { get; set; }

        public decimal DonGia { get; set; }

        public decimal ThanhTien { get; set; }

        public string GhiChuImei { get; set; } = string.Empty;
    }
}