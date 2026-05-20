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
        public DbSet<PhieuBaoHanh> PhieuBaoHanhs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=QL_CuaHangDienThoai;User Id=sa;Password=123123;TrustServerCertificate=True;");
            }
        }

        // ===============================================
        // 🔴 BỔ SUNG LUẬT RÀNG BUỘC (FLUENT API) Ở ĐÂY
        // ===============================================
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Chặn tính năng "Xóa dây chuyền" (Cascade Delete) từ Chi Nhánh sang Nhân Viên
            modelBuilder.Entity<NhanVien>()
                .HasOne(nv => nv.ChiNhanh)
                .WithMany() // Một chi nhánh có nhiều nhân viên
                .HasForeignKey(nv => nv.MaChiNhanh)
                .OnDelete(DeleteBehavior.NoAction); // Bắt buộc dùng NoAction để tránh lỗi vòng lặp

            // THÊM RÀNG BUỘC CHO SẢN PHẨM ĐỂ KHÔNG BỊ LỖI SQL SERVER
            modelBuilder.Entity<SanPham>()
                .HasOne(sp => sp.ChiNhanh)
                .WithMany()
                .HasForeignKey(sp => sp.MaChiNhanh)
                .OnDelete(DeleteBehavior.NoAction);

            // 🔴 THÊM RÀNG BUỘC MỚI CHO HÓA ĐƠN ĐỂ TRÁNH LỖI MIGRATION
            modelBuilder.Entity<HoaDon>()
                .HasOne(hd => hd.ChiNhanh)
                .WithMany()
                .HasForeignKey(hd => hd.MaChiNhanh)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}