using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class BaoHanhBUS
    {
        private BaoHanhDAL _dal = new BaoHanhDAL();

        // ============================================================
        // 1. TÌM HÓA ĐƠN ĐỂ TẠO PHIẾU BẢO HÀNH
        // ============================================================
        public HoaDonViewModel TimHoaDonBaoHanh(string tuKhoa)
        {
            return _dal.TimHoaDonBaoHanh(tuKhoa);
        }

        // ============================================================
        // 2. LẤY SẢN PHẨM TỪ HÓA ĐƠN
        // ============================================================
        public List<SanPhamBaoHanhViewModel> GetSanPhamTuHoaDon(string maHD)
        {
            return _dal.GetSanPhamTuHoaDon(maHD);
        }

        // ============================================================
        // 3. TẠO PHIẾU BẢO HÀNH
        // ============================================================
        public bool TaoPhieuBaoHanh(PhieuBaoHanh pbh)
        {
            return _dal.TaoPhieuBaoHanh(pbh);
        }

        // ============================================================
        // 4. LẤY DANH SÁCH PHIẾU BẢO HÀNH ĐỂ TRA CỨU / XỬ LÝ
        // ============================================================
        public List<TraCuuBaoHanhViewModel> GetDanhSachBaoHanh()
        {
            return _dal.GetDanhSachBaoHanh();
        }

        // ============================================================
        // 5. CẬP NHẬT TRẠNG THÁI PHIẾU BẢO HÀNH
        // ============================================================
        public bool CapNhatTrangThai(string maPhieu, string trangThaiMoi)
        {
            return _dal.CapNhatTrangThai(maPhieu, trangThaiMoi);
        }

        // ============================================================
        // 6. LẤY DANH SÁCH IMEI ĐÃ TỪNG TẠO PHIẾU BẢO HÀNH
        // Dùng để tránh tạo trùng phiếu bảo hành cho cùng 1 IMEI
        // ============================================================
        public List<string> GetImeiDaBaoHanh(string maHD)
        {
            return _dal.GetImeiDaBaoHanh(maHD);
        }

        // ============================================================
        // 7. CẬP NHẬT PHIẾU BẢO HÀNH ĐÃ HẾT HẠN
        // Đồng thời tạo lịch chăm sóc khách hàng cho phiếu đã hết hạn
        // ============================================================
        public int CapNhatBaoHanhHetHanVaTaoChamSoc(string maNVPhuTrach)
        {
            return _dal.CapNhatBaoHanhHetHanVaTaoChamSoc(maNVPhuTrach);
        }

        // ============================================================
        // 8. ĐỒNG BỘ BẢO HÀNH SANG CHĂM SÓC KHÁCH HÀNG
        // Dùng cho các phiếu sắp hết hạn hoặc đã hết hạn
        // Mặc định: nhắc trước 7 ngày
        // ============================================================
        public int DongBoBaoHanhSangChamSocKhachHang(int soNgayNhacTruoc = 7)
        {
            return _dal.DongBoBaoHanhSangChamSocKhachHang(soNgayNhacTruoc);
        }

        // ============================================================
        // 9. HÀM GỘP CHO UC_ChamSocKH GỌI 1 LẦN LÀ ĐỦ
        // Khi mở màn hình Chăm sóc khách hàng:
        // - Cập nhật phiếu bảo hành hết hạn
        // - Tạo lịch chăm sóc cho phiếu hết hạn
        // - Tạo lịch chăm sóc cho phiếu sắp hết hạn
        // ============================================================
        public int DongBoTuDongBaoHanhSangChamSoc(string maNVPhuTrach, int soNgayNhacTruoc = 7)
        {
            int soDongTaoMoi = 0;

            soDongTaoMoi += _dal.CapNhatBaoHanhHetHanVaTaoChamSoc(maNVPhuTrach);
            soDongTaoMoi += _dal.DongBoBaoHanhSangChamSocKhachHang(soNgayNhacTruoc);

            return soDongTaoMoi;
        }
    }
}