using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class HangSanXuatDAL
    {
        private AppDbContext _db = new AppDbContext();

        public List<HangSanXuat> GetAll()
        {
            return _db.HangSanXuats.ToList();
        }

        public bool Them(HangSanXuat h)
        {
            try
            {
                _db.HangSanXuats.Add(h);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Sua(HangSanXuat hUpdate)
        {
            try
            {
                var hCu = _db.HangSanXuats.FirstOrDefault(x => x.MaHang == hUpdate.MaHang);

                if (hCu == null)
                    return false;

                hCu.TenHang = hUpdate.TenHang;
                hCu.QuocGia = hUpdate.QuocGia;
                hCu.MoTa = hUpdate.MoTa;
                hCu.TrangThai = hUpdate.TrangThai;

                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Xoa(string maHang)
        {
            string thongBao;
            return Xoa(maHang, out thongBao);
        }

        public bool Xoa(string maHang, out string thongBao)
        {
            thongBao = "";

            try
            {
                if (string.IsNullOrWhiteSpace(maHang))
                {
                    thongBao = "Vui lòng chọn hãng sản xuất cần xóa khỏi danh mục.";
                    return false;
                }

                var hang = _db.HangSanXuats.FirstOrDefault(x => x.MaHang == maHang);

                if (hang == null)
                {
                    thongBao = "Không tìm thấy hãng sản xuất trong hệ thống.";
                    return false;
                }

                bool daCoSanPham = _db.SanPhams.Any(sp => sp.MaHang == maHang);

                if (daCoSanPham)
                {
                    hang.TrangThai = "Ngừng hợp tác";
                    _db.SaveChanges();

                    thongBao =
                        $"Hãng sản xuất [{hang.TenHang}] đang có sản phẩm liên quan nên không thể xóa khỏi danh mục.\n\n" +
                        "Hệ thống đã chuyển hãng sang trạng thái Ngừng hợp tác để giữ lại lịch sử dữ liệu.";

                    return true;
                }

                _db.HangSanXuats.Remove(hang);
                _db.SaveChanges();

                thongBao = $"Đã xóa hãng sản xuất [{hang.TenHang}] khỏi danh mục.";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Không thể xử lý hãng sản xuất này. Chi tiết lỗi: " +
                           (ex.InnerException?.Message ?? ex.Message);
                return false;
            }
        }
    }
}