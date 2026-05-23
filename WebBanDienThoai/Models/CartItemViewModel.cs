namespace WebBanDienThoai.Models
{
    public class CartItemViewModel
    {
        public string MaSP { get; set; } = string.Empty;

        public string TenSP { get; set; } = string.Empty;

        public string TenHang { get; set; } = string.Empty;

        public string MaChiNhanh { get; set; } = string.Empty;

        public string TenChiNhanh { get; set; } = string.Empty;

        public decimal DonGia { get; set; }

        public int SoLuong { get; set; }

        public int TonKho { get; set; }

        public decimal ThanhTien
        {
            get { return DonGia * SoLuong; }
        }
    }
}