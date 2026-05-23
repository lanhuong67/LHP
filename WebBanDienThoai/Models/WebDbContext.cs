using Microsoft.EntityFrameworkCore;

namespace WebBanDienThoai.Models
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
        {
        }

        public DbSet<SanPhamWeb> SanPhams { get; set; }
        public DbSet<HangSanXuatWeb> HangSanXuats { get; set; }
        public DbSet<ChiNhanhWeb> ChiNhanhs { get; set; }

        public DbSet<HoaDonWeb> HoaDons { get; set; }
        public DbSet<ChiTietHoaDonWeb> ChiTietHoaDons { get; set; }
        public DbSet<KhachHangWeb> KhachHangs { get; set; }
        public DbSet<TaiKhoanKhachHangWeb> TaiKhoanKhachHangs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SanPhamWeb>()
                .HasOne(sp => sp.HangSanXuat)
                .WithMany(h => h.SanPhams)
                .HasForeignKey(sp => sp.MaHang)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SanPhamWeb>()
                .HasOne(sp => sp.ChiNhanh)
                .WithMany(cn => cn.SanPhams)
                .HasForeignKey(sp => sp.MaChiNhanh)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ChiTietHoaDonWeb>()
                .HasKey(ct => new { ct.MaHD, ct.MaSP });

            modelBuilder.Entity<ChiTietHoaDonWeb>()
                .HasOne(ct => ct.HoaDon)
                .WithMany(hd => hd.ChiTietHoaDons)
                .HasForeignKey(ct => ct.MaHD)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ChiTietHoaDonWeb>()
                .HasOne(ct => ct.SanPham)
                .WithMany()
                .HasForeignKey(ct => ct.MaSP)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TaiKhoanKhachHangWeb>()
                .HasIndex(x => x.SDT)
                .IsUnique();

            modelBuilder.Entity<TaiKhoanKhachHangWeb>()
                .HasOne(x => x.KhachHang)
                .WithMany()
                .HasForeignKey(x => x.MaKH)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}