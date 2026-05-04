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

        public bool TaoPhieuNhap(PhieuNhap pn, List<ChiTietPhieuNhap> danhSachChiTiet)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    // 1. Lưu Phiếu Nhập
                    _db.PhieuNhaps.Add(pn);
                    _db.SaveChanges(); // Phải Save để bảng ChiTiet có mã cha mà liên kết

                    // 2. Lưu Chi tiết và Cập nhật Tồn kho (Có phân luồng Trạng thái)
                    foreach (var ct in danhSachChiTiet)
                    {
                        ct.MaPN = pn.MaPN;
                        _db.ChiTietPhieuNhaps.Add(ct);

                        // --- LOGIC LƯU NHÁP ---
                        // CHỈ TĂNG TỒN KHO VÀ CẬP NHẬT GIÁ NẾU TRẠNG THÁI LÀ "Hoàn thành"
                        if (pn.TrangThai == "Hoàn thành")
                        {
                            // Tìm sản phẩm để cộng dồn tồn kho
                            var sp = _db.SanPhams.FirstOrDefault(s => s.MaSP == ct.MaSP);
                            if (sp != null)
                            {
                                sp.TonKho += ct.SoLuong;
                                sp.GiaNhap = ct.DonGiaNhap; // Cập nhật lại giá nhập mới nhất cho danh mục
                            }
                        }
                    }
                    _db.SaveChanges();

                    // 3. Mọi thứ thành công thì chốt
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
    }
}