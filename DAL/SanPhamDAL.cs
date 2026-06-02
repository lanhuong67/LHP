using System;
using DTO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SanPhamDAL
    {
        private AppDbContext _db = new AppDbContext();

        public List<SanPham> GetAll()
        {
            return _db.SanPhams
                .Include(s => s.HangSanXuat)
                .ToList();
        }

        public List<SanPham> GetByBranch(string maCN)
        {
            return _db.SanPhams
                .Include(s => s.HangSanXuat)
                .Where(s => s.MaChiNhanh == maCN)
                .ToList();
        }

        public List<HangSanXuat> GetAllHang()
        {
            return _db.HangSanXuats.ToList();
        }

        public bool Them(SanPham sp)
        {
            try
            {
                _db.SanPhams.Add(sp);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public bool Sua(SanPham spUpdate)
        {
            try
            {
                var sp = _db.SanPhams.FirstOrDefault(s => s.MaSP == spUpdate.MaSP);

                if (sp != null)
                {
                    sp.TenSP = spUpdate.TenSP;
                    sp.MaHang = spUpdate.MaHang;
                    sp.GiaNhap = spUpdate.GiaNhap;
                    sp.GiaBan = spUpdate.GiaBan;
                    sp.CauHinh = spUpdate.CauHinh;
                    sp.TrangThai = spUpdate.TrangThai;
                    sp.MaChiNhanh = spUpdate.MaChiNhanh;

                    _db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public bool Xoa(string maSP)
        {
            string thongBao;
            return Xoa(maSP, out thongBao);
        }

        public bool Xoa(string maSP, out string thongBao)
        {
            thongBao = "";

            try
            {
                if (string.IsNullOrWhiteSpace(maSP))
                {
                    thongBao = "Vui lòng chọn sản phẩm cần xóa khỏi danh mục.";
                    return false;
                }

                var sp = _db.SanPhams.FirstOrDefault(s => s.MaSP == maSP);

                if (sp == null)
                {
                    thongBao = "Không tìm thấy sản phẩm trong hệ thống.";
                    return false;
                }

                // 1. Sản phẩm còn tồn kho thì KHÔNG cho xóa
                if (sp.TonKho > 0)
                {
                    thongBao =
                        $"Sản phẩm [{sp.TenSP}] hiện còn {sp.TonKho} sản phẩm trong kho nên không thể xóa khỏi danh mục.\n\n" +
                        "Vui lòng bán hết, chuyển kho hoặc xử lý tồn kho trước. " +
                        "Nếu sản phẩm không còn kinh doanh, bạn có thể chuyển trạng thái sang Ngừng kinh doanh.";

                    return false;
                }

                // 2. Kiểm tra sản phẩm đã từng phát sinh nghiệp vụ chưa
                bool daPhatSinhNhapHang = _db.ChiTietPhieuNhaps.Any(x => x.MaSP == maSP);
                bool daPhatSinhBanHang = _db.ChiTietHoaDons.Any(x => x.MaSP == maSP);
                bool daCoImei = _db.ChiTietIMEIs.Any(x => x.MaSP == maSP);
                bool daPhatSinhBaoHanh = _db.PhieuBaoHanhs.Any(x => x.MaSP == maSP);

                bool daPhatSinhDuLieu =
                    daPhatSinhNhapHang ||
                    daPhatSinhBanHang ||
                    daCoImei ||
                    daPhatSinhBaoHanh;

                // 3. Nếu đã có lịch sử nhưng không còn tồn kho
                // thì không xóa khỏi database, chỉ chuyển sang Ngừng kinh doanh
                if (daPhatSinhDuLieu)
                {
                    sp.TrangThai = "Ngừng kinh doanh";
                    _db.SaveChanges();

                    thongBao =
                        $"Sản phẩm [{sp.TenSP}] đã có dữ liệu nhập hàng, bán hàng, IMEI hoặc bảo hành liên quan.\n\n" +
                        "Hệ thống đã chuyển sản phẩm sang trạng thái Ngừng kinh doanh để giữ lại lịch sử nghiệp vụ.";

                    return true;
                }

                // 4. Chỉ xóa khỏi danh mục nếu sản phẩm chưa có tồn kho và chưa phát sinh nghiệp vụ
                _db.SanPhams.Remove(sp);
                _db.SaveChanges();

                thongBao = $"Đã xóa sản phẩm [{sp.TenSP}] khỏi danh mục.";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Không thể xử lý sản phẩm này. Chi tiết lỗi: " + (ex.InnerException?.Message ?? ex.Message);
                return false;
            }
        }
    }
}