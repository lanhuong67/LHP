using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    // 1. Bảng lưu thông tin chung của Hóa Đơn
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        [StringLength(20)]
        public string MaHD { get; set; } = string.Empty;

        public DateTime NgayLap { get; set; } = DateTime.Now;

        [StringLength(20)]
        public string MaNV { get; set; } = string.Empty;

        [StringLength(15)]
        public string SDTKhachHang { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,0)")]
        public decimal TongTien { get; set; } = 0;

        [StringLength(50)]
        public string TrangThai { get; set; } = "Hoàn thành";

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
    }

    // 2. Bảng lưu chi tiết các sản phẩm được bán trong Hóa Đơn đó
    [Table("ChiTietHoaDon")]
    public class ChiTietHoaDon
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string MaHD { get; set; } = string.Empty;
        [ForeignKey("MaHD")]
        public virtual HoaDon? HoaDon { get; set; }

        [StringLength(20)]
        public string MaSP { get; set; } = string.Empty;

        public int SoLuong { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal DonGia { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal ThanhTien { get; set; }

        // Cực kỳ quan trọng: Chuỗi này sẽ lưu các mã IMEI khách mua, cách nhau bằng dấu phẩy
        public string GhiChuImei { get; set; } = string.Empty;
    }

    // 3. Class dùng làm Giỏ hàng hiển thị tạm trên giao diện
    public class ChiTietBanViewModel
    {
        public string MaSP { get; set; } = string.Empty;
        public string TenSP { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public decimal DonGiaBan { get; set; }
        public decimal ThanhTien { get; set; }

        // Danh sách "ôm" các mã IMEI mà nhân viên sẽ tích chọn ở Pop-up
        public List<string> ImeiDaChon { get; set; } = new List<string>();
    }

    // 4. Class hiển thị danh sách hóa đơn ra DataGridView (Nối cầu dữ liệu)
    public class HoaDonViewModel
    {
        public string MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public string TenNhanVien { get; set; }
        public string TenKhachHang { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
    }

    public class ChiTietHoaDonViewModel
    {
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string GhiChuImei { get; set; }
    }
}