using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HangSanXuat> HangSanXuats { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public DbSet<ChiNhanh> ChiNhanhs { get; set; }
        public DbSet<ChiTietIMEI> ChiTietIMEIs { get; set; }

        // ===============================================
        // BỔ SUNG 2 BẢNG NÀY CHO MODULE BÁN HÀNG
        // ===============================================
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=QL_CuaHangDienThoai;User Id=sa;Password=123123;TrustServerCertificate=True;");
            }
        }
    }
}