using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class BaoHanhDAL
    {
        private AppDbContext _db = new AppDbContext();

        // ============================================================
        // 1. TÌM HÓA ĐƠN ĐỂ TẠO PHIẾU BẢO HÀNH
        // ============================================================
        public HoaDonViewModel TimHoaDonBaoHanh(string tuKhoa)
        {
            var query = from hd in _db.HoaDons
                        join kh in _db.KhachHangs on hd.SDTKhachHang equals kh.SDT into khGroup
                        from kh in khGroup.DefaultIfEmpty()
                        where (hd.MaHD == tuKhoa || hd.SDTKhachHang == tuKhoa)
                              && hd.TrangThai == "Hoàn thành"
                        orderby hd.NgayLap descending
                        select new HoaDonViewModel
                        {
                            MaHD = hd.MaHD,
                            NgayLap = hd.NgayLap,
                            TenKhachHang = kh != null ? kh.HoTen : "Khách vãng lai",

                            // Tạm dùng TenNhanVien để truyền SĐT về UC_BaoHanh
                            TenNhanVien = hd.SDTKhachHang
                        };

            return query.FirstOrDefault();
        }

        // ============================================================
        // 2. LẤY SẢN PHẨM TỪ HÓA ĐƠN
        // ============================================================
        public List<SanPhamBaoHanhViewModel> GetSanPhamTuHoaDon(string maHD)
        {
            var query = from ct in _db.ChiTietHoaDons
                        join sp in _db.SanPhams on ct.MaSP equals sp.MaSP
                        where ct.MaHD == maHD
                        select new SanPhamBaoHanhViewModel
                        {
                            Chon = false,
                            MaSP = sp.MaSP,
                            TenSP = sp.TenSP,
                            SoLuong = ct.SoLuong,
                            DonGia = ct.DonGia,
                            Imei = ct.GhiChuImei
                        };

            return query.ToList();
        }

        // ============================================================
        // 3. TẠO PHIẾU BẢO HÀNH
        // ============================================================
        public bool TaoPhieuBaoHanh(PhieuBaoHanh pbh)
        {
            try
            {
                _db.PhieuBaoHanhs.Add(pbh);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        // ============================================================
        // 4. LẤY DANH SÁCH PHIẾU BẢO HÀNH
        // Có tự cập nhật phiếu đã hết hạn trước khi hiển thị
        // ============================================================
        public List<TraCuuBaoHanhViewModel> GetDanhSachBaoHanh()
        {
            try
            {
                CapNhatTrangThaiBaoHanhTheoNgay(_db);
                _db.SaveChanges();

                var query = from p in _db.PhieuBaoHanhs
                            join hd in _db.HoaDons on p.MaHD equals hd.MaHD
                            join kh in _db.KhachHangs on hd.SDTKhachHang equals kh.SDT into khGroup
                            from kh in khGroup.DefaultIfEmpty()
                            join sp in _db.SanPhams on p.MaSP equals sp.MaSP
                            select new TraCuuBaoHanhViewModel
                            {
                                MaPhieuBH = p.MaPhieuBH,
                                TenKhachHang = kh != null ? kh.HoTen : hd.SDTKhachHang,
                                SDTKhachHang = hd.SDTKhachHang,
                                TenSP = sp.TenSP,
                                NgayHetHanBH = p.NgayHetHanBH,
                                TrangThai = p.TrangThai
                            };

                return query.OrderByDescending(x => x.MaPhieuBH).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải danh sách bảo hành: " + (ex.InnerException?.Message ?? ex.Message));
            }
        }

        // ============================================================
        // 5. CẬP NHẬT TRẠNG THÁI THỦ CÔNG
        // ============================================================
        public bool CapNhatTrangThai(string maPhieu, string trangThaiMoi)
        {
            try
            {
                var pbh = _db.PhieuBaoHanhs.Find(maPhieu);

                if (pbh != null)
                {
                    pbh.TrangThai = trangThaiMoi;
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

        // ============================================================
        // 6. LẤY IMEI ĐÃ TẠO PHIẾU BẢO HÀNH
        // ============================================================
        public List<string> GetImeiDaBaoHanh(string maHD)
        {
            return _db.PhieuBaoHanhs
                      .Where(x => x.MaHD == maHD && !string.IsNullOrEmpty(x.Imei))
                      .Select(x => x.Imei)
                      .ToList();
        }

        // ============================================================
        // 7. HÀM CẬP NHẬT PHIẾU BẢO HÀNH HẾT HẠN
        // Chỉ phiếu có ngày hết hạn < hôm nay mới hết hạn.
        // Ví dụ hết hạn ngày 24/05 thì trong ngày 24/05 vẫn còn hiệu lực.
        // Sang 25/05 mới là đã hết hạn.
        // ============================================================
        private void CapNhatTrangThaiBaoHanhTheoNgay(AppDbContext db)
        {
            DateTime homNay = DateTime.Today;

            var dsHetHan = db.PhieuBaoHanhs
                .Where(p => p.NgayHetHanBH.Date < homNay
                            && p.TrangThai != "Đã hết hạn"
                            && p.TrangThai != "Đã hủy"
                            && p.TrangThai != "Từ chối")
                .ToList();

            foreach (var p in dsHetHan)
            {
                p.TrangThai = "Đã hết hạn";
            }
        }

        // ============================================================
        // 8. ĐỒNG BỘ BẢO HÀNH SANG CHĂM SÓC KHÁCH HÀNG
        // Tạo lịch CSKH cho:
        // - Phiếu đã hết hạn
        // - Phiếu sắp hết hạn trong số ngày cảnh báo
        // ============================================================
        public int DongBoBaoHanhSangChamSocKhachHang(int soNgayNhacTruoc = 7)
        {
            try
            {
                DateTime homNay = DateTime.Today;
                DateTime ngayCanhBao = homNay.AddDays(soNgayNhacTruoc);

                // 1. Cập nhật trạng thái phiếu hết hạn trước
                CapNhatTrangThaiBaoHanhTheoNgay(_db);

                // 2. Lấy phiếu cần chăm sóc
                var query = from p in _db.PhieuBaoHanhs
                            join hd in _db.HoaDons on p.MaHD equals hd.MaHD
                            join kh in _db.KhachHangs on hd.SDTKhachHang equals kh.SDT into khGroup
                            from kh in khGroup.DefaultIfEmpty()
                            join sp in _db.SanPhams on p.MaSP equals sp.MaSP into spGroup
                            from sp in spGroup.DefaultIfEmpty()
                            where p.NgayHetHanBH.Date <= ngayCanhBao
                                  && !string.IsNullOrEmpty(hd.SDTKhachHang)
                                  && p.TrangThai != "Đã hủy"
                                  && p.TrangThai != "Từ chối"
                            select new
                            {
                                PhieuBH = p,
                                HoaDon = hd,
                                KhachHang = kh,
                                SanPham = sp
                            };

                var dsCanChamSoc = query.ToList();

                int soDongTaoMoi = 0;

                foreach (var item in dsCanChamSoc)
                {
                    string maPhieuBH = item.PhieuBH.MaPhieuBH;

                    // 3. Chống tạo trùng lịch CSKH cho cùng phiếu bảo hành
                    bool daTonTai = _db.ChamSocKhachHangs.Any(cs =>
                        cs.NguonPhatSinh == "Bảo hành"
                        && cs.MaNguon == maPhieuBH);

                    if (daTonTai)
                        continue;

                    string tenKH = item.KhachHang != null
                        ? item.KhachHang.HoTen
                        : item.HoaDon.SDTKhachHang;

                    string maKH = item.KhachHang != null
                        ? item.KhachHang.MaKH
                        : item.HoaDon.SDTKhachHang;

                    string sdt = item.HoaDon.SDTKhachHang;

                    string tenSP = item.SanPham != null
                        ? item.SanPham.TenSP
                        : item.PhieuBH.MaSP;

                    bool daHetHan = item.PhieuBH.NgayHetHanBH.Date < homNay;

                    string loaiChamSoc = daHetHan
                        ? "Bảo hành đã hết hạn"
                        : "Bảo hành sắp hết hạn";

                    string noiDung = daHetHan
                        ? $"Phiếu bảo hành {maPhieuBH} của sản phẩm {tenSP} đã hết hạn ngày {item.PhieuBH.NgayHetHanBH:dd/MM/yyyy}. Gọi thông báo và tư vấn khách hàng."
                        : $"Phiếu bảo hành {maPhieuBH} của sản phẩm {tenSP} sẽ hết hạn ngày {item.PhieuBH.NgayHetHanBH:dd/MM/yyyy}. Gọi nhắc khách trước khi hết hạn.";

                    ChamSocKhachHang cs = new ChamSocKhachHang
                    {
                        MaKH = maKH,
                        TenKH = tenKH,
                        SDT = sdt,
                        LoaiChamSoc = loaiChamSoc,
                        NoiDung = noiDung,
                        NgayHen = homNay,
                        TrangThai = "Chưa xử lý",
                        MaNVPhuTrach = UserSession.MaNV,
                        NguonPhatSinh = "Bảo hành",
                        MaNguon = maPhieuBH,
                        MaChiNhanhPhatSinh = item.HoaDon.MaChiNhanh,
                        GhiChuKetQua = "",
                        NgayTao = DateTime.Now,
                        NgayXuLy = null

                    };

                    _db.ChamSocKhachHangs.Add(cs);
                    soDongTaoMoi++;
                }

                _db.SaveChanges();
                return soDongTaoMoi;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi đồng bộ bảo hành sang chăm sóc khách hàng: " +
                    (ex.InnerException?.Message ?? ex.Message));
            }
        }

        // ============================================================
        // 9. HÀM CŨ GIỮ LẠI ĐỂ KHÔNG LỖI BÊN BUS
        // Nhưng bên trong gọi về hàm đồng bộ chính ở trên
        // ============================================================
        public int CapNhatBaoHanhHetHanVaTaoChamSoc(string maNVPhuTrach)
        {
            return DongBoBaoHanhSangChamSocKhachHang(0);
        }
    }
}