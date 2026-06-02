using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class NhanVienDAL
    {
        private AppDbContext _db = new AppDbContext();

        public NhanVien? Login(string user, string pass)
        {
            return _db.NhanViens.FirstOrDefault(nv =>
                nv.TenDangNhap == user &&
                nv.MatKhau == pass);
        }

        public List<NhanVien> GetAllNhanVien()
        {
            return _db.NhanViens.ToList();
        }

        public bool ThemNhanVien(NhanVien nv)
        {
            try
            {
                _db.NhanViens.Add(nv);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaNhanVien(NhanVien nvUpdate)
        {
            try
            {
                var nvCu = _db.NhanViens.FirstOrDefault(n => n.MaNV == nvUpdate.MaNV);

                if (nvCu != null)
                {
                    nvCu.HoTen = nvUpdate.HoTen;
                    nvCu.SDT = nvUpdate.SDT;
                    nvCu.Email = nvUpdate.Email;
                    nvCu.VaiTro = nvUpdate.VaiTro;
                    nvCu.TenDangNhap = nvUpdate.TenDangNhap;
                    nvCu.MatKhau = nvUpdate.MatKhau;
                    nvCu.MaChiNhanh = nvUpdate.MaChiNhanh;

                    _db.SaveChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaNhanVien(string maNV)
        {
            string thongBao;
            return XoaNhanVien(maNV, out thongBao);
        }

        public bool XoaNhanVien(string maNV, out string thongBao)
        {
            thongBao = "";

            try
            {
                if (string.IsNullOrWhiteSpace(maNV))
                {
                    thongBao = "Vui lòng chọn nhân viên cần xóa khỏi danh mục.";
                    return false;
                }

                var nv = _db.NhanViens.FirstOrDefault(n => n.MaNV == maNV);

                if (nv == null)
                {
                    thongBao = "Không tìm thấy nhân viên trong hệ thống.";
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(nv.VaiTro) &&
                    nv.VaiTro.Trim().ToLower() == "admin")
                {
                    int soAdmin = _db.NhanViens
                        .AsEnumerable()
                        .Count(x =>
                            !string.IsNullOrWhiteSpace(x.VaiTro) &&
                            x.VaiTro.Trim().ToLower() == "admin");

                    if (soAdmin <= 1)
                    {
                        thongBao = "Không thể xóa tài khoản Admin cuối cùng của hệ thống.";
                        return false;
                    }
                }

                try
                {
                    _db.NhanViens.Remove(nv);
                    _db.SaveChanges();

                    thongBao = "Đã xóa nhân viên khỏi danh mục.";
                    return true;
                }
                catch (DbUpdateException)
                {
                    _db.Entry(nv).State = EntityState.Unchanged;

                    thongBao =
                        "Nhân viên này đã có dữ liệu nghiệp vụ liên quan nên không thể xóa khỏi danh mục. " +
                        "Cần giữ lại thông tin nhân viên để tra cứu lịch sử hóa đơn, nhập hàng hoặc các nghiệp vụ đã xử lý.";

                    return false;
                }
            }
            catch (Exception ex)
            {
                thongBao = "Không thể xử lý nhân viên này. Chi tiết lỗi: " + ex.Message;
                return false;
            }
        }
    }
}