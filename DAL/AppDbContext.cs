using Microsoft.EntityFrameworkCore;
using DTO; // Đảm bảo đã tham chiếu đến project DTO

namespace DAL
{
    public class AppDbContext : DbContext
    {
        // Khai báo bảng Tài Khoản
        public DbSet<NhanVien> NhanViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Sử dụng tài khoản sa và mật khẩu bạn đã cấu hình ở bước trước
                optionsBuilder.UseSqlServer("Server=.;Database=QL_CuaHangDienThoai;User Id=sa;Password=123123;TrustServerCertificate=True;");
            }
        }
    }
}