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
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<PhieuBaoHanh> PhieuBaoHanhs { get; set; }
        public DbSet<ChamSocKhachHang> ChamSocKhachHangs { get; set; }
        public DbSet<TaiKhoanKhachHang> TaiKhoanKhachHangs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=QL_CuaHangDienThoai;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ================================
            // NHÂN VIÊN
            // ================================
            modelBuilder.Entity<NhanVien>()
                .Property(nv => nv.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("Đang hoạt động");

            modelBuilder.Entity<NhanVien>()
                .HasOne(nv => nv.ChiNhanh)
                .WithMany()
                .HasForeignKey(nv => nv.MaChiNhanh)
                .OnDelete(DeleteBehavior.NoAction);

            // ================================
            // SẢN PHẨM
            // ================================
            modelBuilder.Entity<SanPham>()
                .HasOne(sp => sp.ChiNhanh)
                .WithMany()
                .HasForeignKey(sp => sp.MaChiNhanh)
                .OnDelete(DeleteBehavior.NoAction);

            // ================================
            // HÓA ĐƠN
            // ================================
            modelBuilder.Entity<HoaDon>()
                .HasOne(hd => hd.ChiNhanh)
                .WithMany()
                .HasForeignKey(hd => hd.MaChiNhanh)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<HoaDon>()
                .Property(hd => hd.HinhThucNhanHang)
                .HasMaxLength(50);

            modelBuilder.Entity<HoaDon>()
                .Property(hd => hd.DiaChiGiaoHang)
                .HasMaxLength(255);

            modelBuilder.Entity<HoaDon>()
                .Property(hd => hd.GhiChuDonHang)
                .HasMaxLength(500);

            modelBuilder.Entity<HoaDon>()
                .Property(hd => hd.PhuongThucThanhToan)
                .HasMaxLength(50);

            modelBuilder.Entity<HoaDon>()
                .Property(hd => hd.TrangThaiThanhToan)
                .HasMaxLength(50);

            modelBuilder.Entity<HoaDon>()
                .Property(hd => hd.TongTienGoc)
                .HasColumnType("decimal(18,0)");

            modelBuilder.Entity<HoaDon>()
                .Property(hd => hd.GiamGia)
                .HasColumnType("decimal(18,0)");

            modelBuilder.Entity<HoaDon>()
                .Property(hd => hd.ThanhTienSauGiam)
                .HasColumnType("decimal(18,0)");

            // ================================
            // TÀI KHOẢN KHÁCH HÀNG WEB
            // ================================
            modelBuilder.Entity<TaiKhoanKhachHang>()
                .HasIndex(tk => tk.SDT)
                .IsUnique();

            modelBuilder.Entity<TaiKhoanKhachHang>()
                .HasIndex(tk => tk.MaKH)
                .IsUnique();

            modelBuilder.Entity<TaiKhoanKhachHang>()
                .HasOne(tk => tk.KhachHang)
                .WithMany()
                .HasForeignKey(tk => tk.MaKH)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}