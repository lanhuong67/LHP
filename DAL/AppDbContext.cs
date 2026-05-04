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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Sửa lại tên Server chuẩn xác 100% theo máy của Phúc
                optionsBuilder.UseSqlServer("Server=.;Database=QL_CuaHangDienThoai;User Id=sa;Password=123123;TrustServerCertificate=True;");
            }
        }
    }
}