using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ChamSocKhachHangDAL
    {
        public List<ChamSocKHViewModel> GetAll()
        {
            using (var db = new AppDbContext())
            {
                var query = from cs in db.ChamSocKhachHangs
                            join cn in db.ChiNhanhs
                                on cs.MaChiNhanhPhatSinh equals cn.MaChiNhanh into cnGroup
                            from cn in cnGroup.DefaultIfEmpty()
                            orderby cs.NgayHen
                            select new ChamSocKHViewModel
                            {
                                Id = cs.Id,
                                MaKH = cs.MaKH,
                                TenKH = cs.TenKH,
                                SDT = cs.SDT,
                                LoaiChamSoc = cs.LoaiChamSoc,
                                NoiDung = cs.NoiDung,
                                NgayHen = cs.NgayHen,
                                TrangThai = cs.TrangThai,
                                MaNVPhuTrach = cs.MaNVPhuTrach,
                                NguonPhatSinh = cs.NguonPhatSinh,
                                MaNguon = cs.MaNguon,

                                MaChiNhanhPhatSinh = cs.MaChiNhanhPhatSinh,
                                TenChiNhanhPhatSinh = cn != null ? cn.TenChiNhanh : "Không xác định",

                                NgayXuLy = cs.NgayXuLy
                            };

                return query.ToList();
            }
        }

        public List<ChamSocKHViewModel> TimKiem(string tuKhoa, string loai, string trangThai)
        {
            using (var db = new AppDbContext())
            {
                tuKhoa = tuKhoa?.Trim().ToLower() ?? "";

                var query = from cs in db.ChamSocKhachHangs
                            join cn in db.ChiNhanhs
                                on cs.MaChiNhanhPhatSinh equals cn.MaChiNhanh into cnGroup
                            from cn in cnGroup.DefaultIfEmpty()
                            select new ChamSocKHViewModel
                            {
                                Id = cs.Id,
                                MaKH = cs.MaKH,
                                TenKH = cs.TenKH,
                                SDT = cs.SDT,
                                LoaiChamSoc = cs.LoaiChamSoc,
                                NoiDung = cs.NoiDung,
                                NgayHen = cs.NgayHen,
                                TrangThai = cs.TrangThai,
                                MaNVPhuTrach = cs.MaNVPhuTrach,
                                NguonPhatSinh = cs.NguonPhatSinh,
                                MaNguon = cs.MaNguon,

                                MaChiNhanhPhatSinh = cs.MaChiNhanhPhatSinh,
                                TenChiNhanhPhatSinh = cn != null ? cn.TenChiNhanh : "Không xác định",

                                NgayXuLy = cs.NgayXuLy
                            };

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query = query.Where(x =>
                        x.MaKH.ToLower().Contains(tuKhoa) ||
                        x.TenKH.ToLower().Contains(tuKhoa) ||
                        x.SDT.ToLower().Contains(tuKhoa) ||
                        x.NoiDung.ToLower().Contains(tuKhoa) ||
                        x.TenChiNhanhPhatSinh.ToLower().Contains(tuKhoa)
                    );
                }

                if (!string.IsNullOrWhiteSpace(loai) && loai != "--Tất cả loại--")
                {
                    query = query.Where(x => x.LoaiChamSoc == loai);
                }

                if (!string.IsNullOrWhiteSpace(trangThai) && trangThai != "--Tất cả trạng thái--")
                {
                    query = query.Where(x => x.TrangThai == trangThai);
                }

                return query.OrderBy(x => x.NgayHen).ToList();
            }
        }

        public ChamSocThongKeViewModel GetThongKe()
        {
            using (var db = new AppDbContext())
            {
                DateTime today = DateTime.Today;

                int diff = today.DayOfWeek == DayOfWeek.Sunday
                    ? -6
                    : DayOfWeek.Monday - today.DayOfWeek;

                DateTime dauTuan = today.AddDays(diff);
                DateTime cuoiTuan = dauTuan.AddDays(7);

                return new ChamSocThongKeViewModel
                {
                    NhacHomNay = db.ChamSocKhachHangs.Count(x =>
                        x.NgayHen.Date == today &&
                        x.TrangThai != "Đã xử lý"),

                    BaoHanhSapHetHan = db.ChamSocKhachHangs.Count(x =>
                        x.LoaiChamSoc != null &&
                        x.LoaiChamSoc.Contains("Bảo hành") &&
                        x.TrangThai != "Đã xử lý"),

                    ChuaLienHeLai = db.ChamSocKhachHangs.Count(x =>
                        x.TrangThai == "Chưa xử lý"),

                    DaXuLyTuanNay = db.ChamSocKhachHangs.Count(x =>
                        x.TrangThai == "Đã xử lý" &&
                        x.NgayXuLy != null &&
                        x.NgayXuLy.Value.Date >= dauTuan &&
                        x.NgayXuLy.Value.Date < cuoiTuan)
                };
            }
        }

        public bool Them(ChamSocKhachHang cs)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.ChamSocKhachHangs.Add(cs);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public bool DanhDauDaXuLy(int id, string ghiChuKetQua)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var item = db.ChamSocKhachHangs.FirstOrDefault(x => x.Id == id);

                    if (item == null) return false;

                    item.TrangThai = "Đã xử lý";
                    item.GhiChuKetQua = ghiChuKetQua;
                    item.NgayXuLy = DateTime.Now;

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public bool CapNhatTrangThai(int id, string trangThai)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var item = db.ChamSocKhachHangs.FirstOrDefault(x => x.Id == id);

                    if (item == null) return false;

                    item.TrangThai = trangThai;

                    if (trangThai == "Đã xử lý")
                        item.NgayXuLy = DateTime.Now;

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public List<KhachHangChamSocViewModel> TimKhachHang(string tuKhoa)
        {
            using (var db = new AppDbContext())
            {
                if (string.IsNullOrWhiteSpace(tuKhoa))
                    return new List<KhachHangChamSocViewModel>();

                tuKhoa = tuKhoa.Trim().ToLower();

                return db.KhachHangs
                    .Where(x =>
                        x.MaKH.ToLower().Contains(tuKhoa) ||
                        x.HoTen.ToLower().Contains(tuKhoa) ||
                        x.SDT.ToLower().Contains(tuKhoa))
                    .Select(x => new KhachHangChamSocViewModel
                    {
                        MaKH = x.MaKH,
                        TenKH = x.HoTen,
                        SDT = x.SDT
                    })
                    .ToList();
            }
        }
    }
}