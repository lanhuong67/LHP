using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class PhieuNhapDAL
    {
        private AppDbContext _db = new AppDbContext();

        public List<NhaCungCap> GetAllNhaCungCap()
        {
            return _db.NhaCungCaps.ToList();
        }

        public List<ChiNhanh> GetAllChiNhanh()
        {
            return _db.ChiNhanhs.ToList();
        }

        // ==========================================
        // TẠO PHIẾU NHẬP & TỰ ĐỘNG LƯU IMEI VÀO KHO
        // ==========================================
        public bool TaoPhieuNhap(PhieuNhap pn, List<ChiTietPhieuNhap> danhSachChiTiet)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.PhieuNhaps.Add(pn);
                    _db.SaveChanges(); // Lưu để lấy MaPN

                    foreach (var ct in danhSachChiTiet)
                    {
                        ct.MaPN = pn.MaPN;
                        ct.SoLuongDaBan = 0;
                        _db.ChiTietPhieuNhaps.Add(ct);

                        if (pn.TrangThai == "Hoàn thành")
                        {
                            // 1. Cập nhật tồn kho tổng trong bảng SanPham
                            var sp = _db.SanPhams.FirstOrDefault(s => s.MaSP == ct.MaSP);
                            if (sp != null)
                            {
                                sp.TonKho += ct.SoLuong;
                                sp.GiaNhap = ct.DonGiaNhap;
                            }

                            // 2. LƯU TỪNG MÃ IMEI VÀO BẢNG ChiTietIMEI (Đã Fix)
                            if (ct.DanhSachIMEI != null && ct.DanhSachIMEI.Any())
                            {
                                foreach (var maImei in ct.DanhSachIMEI)
                                {
                                    var chiTietImei = new ChiTietIMEI
                                    {
                                        IMEI = maImei,
                                        MaSP = ct.MaSP,
                                        MaPN = pn.MaPN,
                                        TrangThai = "Trong kho" // Trạng thái chuẩn để bán hàng đọc được
                                    };
                                    _db.ChiTietIMEIs.Add(chiTietImei);
                                }
                            }
                        }
                    }
                    _db.SaveChanges(); // Chốt lưu toàn bộ IMEI và Chi tiết
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Lỗi khi lưu Database: " + (ex.InnerException?.Message ?? ex.Message));
                }
            }
        }

        // ==========================================
        // HỦY PHIẾU NHẬP (CÓ KÈM LÝ DO)
        // ==========================================
        public bool HuyPhieuNhap(string maPN, string lyDoHuy)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var pn = _db.PhieuNhaps.FirstOrDefault(x => x.MaPN == maPN);
                    if (pn == null || pn.TrangThai == "Đã hủy") return false;

                    var chiTietList = _db.ChiTietPhieuNhaps.Where(ct => ct.MaPN == maPN).ToList();

                    if (chiTietList.Any(ct => ct.SoLuongDaBan > 0))
                    {
                        throw new Exception("Không thể hủy! Một số sản phẩm trong lô này đã được xuất bán cho khách hàng.");
                    }

                    // Cập nhật trạng thái
                    pn.TrangThai = "Đã hủy";

                    // Gắn lý do vào Ghi chú
                    string textHuy = $"[ĐÃ HỦY: {lyDoHuy}]";
                    pn.GhiChu = string.IsNullOrWhiteSpace(pn.GhiChu) ? textHuy : pn.GhiChu + " | " + textHuy;

                    // Trừ tồn kho và đổi trạng thái IMEI thành "Lỗi trả NCC"
                    foreach (var ct in chiTietList)
                    {
                        var sp = _db.SanPhams.FirstOrDefault(s => s.MaSP == ct.MaSP);
                        if (sp != null)
                        {
                            sp.TonKho -= ct.SoLuong;
                            if (sp.TonKho < 0) sp.TonKho = 0;
                        }

                        // Tìm tất cả IMEI của lô này và đổi trạng thái để không bán được nữa
                        var listImeiLoi = _db.ChiTietIMEIs.Where(i => i.MaPN == maPN).ToList();
                        foreach (var imei in listImeiLoi)
                        {
                            imei.TrangThai = "Lỗi trả NCC";
                        }
                    }

                    _db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public List<LichSuNhapViewModel> GetLichSuNhap()
        {
            var result = (from pn in _db.PhieuNhaps
                          join ncc in _db.NhaCungCaps on pn.MaNCC equals ncc.MaNCC
                          join nv in _db.NhanViens on pn.MaNV equals nv.MaNV
                          select new LichSuNhapViewModel
                          {
                              MaPN = pn.MaPN,
                              NgayNhap = pn.NgayNhap,
                              TenNCC = ncc.TenNCC,
                              TenNhanVien = nv.HoTen,
                              SoSanPham = _db.ChiTietPhieuNhaps.Where(ct => ct.MaPN == pn.MaPN).Sum(ct => ct.SoLuong),
                              TongTien = pn.TongTien,
                              TrangThai = pn.TrangThai,
                              GhiChu = pn.GhiChu
                          }).OrderByDescending(x => x.NgayNhap).ToList();
            return result;
        }

        public List<LoHangViewModel> GetDanhSachLoHang()
        {
            var query = from ct in _db.ChiTietPhieuNhaps
                        join pn in _db.PhieuNhaps on ct.MaPN equals pn.MaPN
                        join sp in _db.SanPhams on ct.MaSP equals sp.MaSP
                        where pn.TrangThai == "Hoàn thành"
                        select new LoHangViewModel
                        {
                            MaLo = pn.MaPN + "_" + sp.MaSP,
                            TenSP = sp.TenSP,
                            MaPN = pn.MaPN,
                            NgayNhap = pn.NgayNhap,
                            SoLuongNhap = ct.SoLuong,
                            SoLuongDaBan = ct.SoLuongDaBan
                        };

            return query.OrderByDescending(x => x.NgayNhap).ToList();
        }
    }
}