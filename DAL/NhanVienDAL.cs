using DTO;
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
            var nv = _db.NhanViens.FirstOrDefault(x =>
                x.TenDangNhap == user &&
                x.MatKhau == pass);

            if (nv == null)
                return null;

            if (LaTrangThaiNgungHoatDong(nv.TrangThai))
                return null;

            return nv;
        }

        public List<NhanVien> GetAllNhanVien()
        {
            return _db.NhanViens.ToList();
        }

        public bool ThemNhanVien(NhanVien nv)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nv.TrangThai))
                {
                    nv.TrangThai = "Đang hoạt động";
                }

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

                if (nvCu == null)
                    return false;

                nvCu.HoTen = nvUpdate.HoTen;
                nvCu.SDT = nvUpdate.SDT;
                nvCu.Email = nvUpdate.Email;
                nvCu.VaiTro = nvUpdate.VaiTro;
                nvCu.TenDangNhap = nvUpdate.TenDangNhap;
                nvCu.MatKhau = nvUpdate.MatKhau;
                nvCu.MaChiNhanh = nvUpdate.MaChiNhanh;

                // Không tự ý đổi trạng thái khi sửa thông tin.
                // Tránh trường hợp nhân viên đã Ngừng hoạt động bị sửa xong lại thành Đang hoạt động.
                if (string.IsNullOrWhiteSpace(nvCu.TrangThai))
                {
                    nvCu.TrangThai = "Đang hoạt động";
                }

                _db.SaveChanges();

                return true;
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
                    thongBao = "Vui lòng chọn nhân viên cần ngừng hoạt động.";
                    return false;
                }

                var nv = _db.NhanViens.FirstOrDefault(n => n.MaNV == maNV);

                if (nv == null)
                {
                    thongBao = "Không tìm thấy nhân viên trong hệ thống.";
                    return false;
                }

                if (LaTrangThaiNgungHoatDong(nv.TrangThai))
                {
                    thongBao = "Nhân viên này đã ở trạng thái Ngừng hoạt động.";
                    return false;
                }

                if (LaVaiTroAdmin(nv.VaiTro))
                {
                    int soAdminDangHoatDong = _db.NhanViens
                        .AsEnumerable()
                        .Count(x => LaVaiTroAdmin(x.VaiTro) && !LaTrangThaiNgungHoatDong(x.TrangThai));

                    if (soAdminDangHoatDong <= 1)
                    {
                        thongBao = "Không thể ngừng hoạt động tài khoản Admin cuối cùng của hệ thống.";
                        return false;
                    }
                }

                nv.TrangThai = "Ngừng hoạt động";
                _db.SaveChanges();

                thongBao =
                    $"Nhân viên [{nv.HoTen}] đã được chuyển sang trạng thái Ngừng hoạt động.\n\n" +
                    "Nhân viên này sẽ không thể đăng nhập vào hệ thống, nhưng thông tin vẫn được giữ lại để tra cứu lịch sử hóa đơn, nhập hàng, bảo hành hoặc các nghiệp vụ đã xử lý.";

                return true;
            }
            catch (Exception ex)
            {
                thongBao = "Không thể cập nhật trạng thái nhân viên. Chi tiết lỗi: " +
                           (ex.InnerException?.Message ?? ex.Message);
                return false;
            }
        }

        private bool LaVaiTroAdmin(string vaiTro)
        {
            if (string.IsNullOrWhiteSpace(vaiTro))
                return false;

            string value = vaiTro.Trim().ToLower();

            return value == "admin" ||
                   value == "quản trị" ||
                   value == "quan tri";
        }

        private bool LaTrangThaiNgungHoatDong(string trangThai)
        {
            if (string.IsNullOrWhiteSpace(trangThai))
                return false;

            string value = trangThai.Trim().ToLower();

            return value == "ngừng hoạt động" ||
                   value == "ngưng hoạt động" ||
                   value == "ngung hoat dong" ||
                   value == "inactive" ||
                   value == "false" ||
                   value == "0";
        }
    }
}