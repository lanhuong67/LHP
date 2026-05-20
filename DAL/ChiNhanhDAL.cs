using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class ChiNhanhDAL
    {
        // 🔴 ĐỔI "LHPContext" THÀNH TÊN DBCONTEXT CỦA BẠN (Ví dụ: QLCuaHangContext, Model1, v.v.)
        private AppDbContext _db = new AppDbContext();

        // 1. READ: Lấy toàn bộ danh sách chi nhánh
        public List<ChiNhanh> GetAll()
        {
            // Trả về danh sách sắp xếp theo mã chi nhánh
            return _db.ChiNhanhs.OrderBy(x => x.MaChiNhanh).ToList();
        }

        // 2. CREATE: Thêm chi nhánh mới
        public bool Them(ChiNhanh cn)
        {
            try
            {
                _db.ChiNhanhs.Add(cn);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // 3. UPDATE: Sửa thông tin chi nhánh
        public bool Sua(ChiNhanh cnMoi)
        {
            try
            {
                // Tìm chi nhánh cũ trong CSDL
                var cnCu = _db.ChiNhanhs.FirstOrDefault(x => x.MaChiNhanh == cnMoi.MaChiNhanh);
                if (cnCu != null)
                {
                    // Đổ dữ liệu mới đè lên dữ liệu cũ
                    cnCu.TenChiNhanh = cnMoi.TenChiNhanh;
                    cnCu.ThanhPho = cnMoi.ThanhPho;
                    cnCu.QuanHuyen = cnMoi.QuanHuyen;
                    cnCu.DiaChi = cnMoi.DiaChi;
                    cnCu.QuanLy = cnMoi.QuanLy;
                    cnCu.SDT = cnMoi.SDT;
                    cnCu.Email = cnMoi.Email;
                    cnCu.TrangThai = cnMoi.TrangThai;

                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // 4. DELETE: Xóa chi nhánh
        public bool Xoa(string maCN)
        {
            try
            {
                var cnCu = _db.ChiNhanhs.FirstOrDefault(x => x.MaChiNhanh == maCN);
                if (cnCu != null)
                {
                    _db.ChiNhanhs.Remove(cnCu);
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Cố tình ném lỗi ra ngoài để tầng GUI bắt được lỗi Ràng buộc khóa ngoại
                // (Không cho phép xóa chi nhánh nếu đã có nhân viên hoặc phiếu nhập thuộc chi nhánh đó)
                throw new Exception(ex.Message);
            }
        }
    }
}