using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_NhapHangLo : UserControl
    {
        private NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        private SanPhamBUS _spBus = new SanPhamBUS();
        private PhieuNhapBUS _pnBus = new PhieuNhapBUS();

        private BindingList<ChiTietNhapViewModel> gioHang = new BindingList<ChiTietNhapViewModel>();

        public UC_NhapHangLo()
        {
            InitializeComponent();
        }

        private void UC_NhapHangLo_Load(object sender, EventArgs e)
        {
            dgvChiTietNhap.AutoGenerateColumns = false;
            dgvChiTietNhap.DataSource = gioHang;

            SinhMaPhieu();
            LoadComboBoxes();

            // Gọi hàm load lịch sử khi vừa mở form
            LoadLichSuNhap();
        }

        private void SinhMaPhieu()
        {
            txtMaPhieu.Text = "PN" + DateTime.Now.ToString("yyyyMMdd_HHmm");
            txtMaPhieu.ReadOnly = true;
        }

        private void LoadComboBoxes()
        {
            try
            {
                // 1. Load Chi Nhánh
                var dsChiNhanh = _pnBus.GetAllChiNhanh();
                cboChiNhanh.DataSource = dsChiNhanh;
                cboChiNhanh.DisplayMember = "TenChiNhanh";
                cboChiNhanh.ValueMember = "MaChiNhanh";

                // 2. Load Nhà Cung Cấp (Cho Tab Nhập hàng)
                var dsNCC = _pnBus.GetAllNhaCungCap();
                cboNhaCungCap.DataSource = dsNCC;
                cboNhaCungCap.DisplayMember = "TenNCC";
                cboNhaCungCap.ValueMember = "MaNCC";

                // 3. Load Hãng SX 
                var dsHang = _spBus.GetAllHang();
                cboHangSX_Loc.DataSource = dsHang;
                cboHangSX_Loc.DisplayMember = "TenHang";
                cboHangSX_Loc.ValueMember = "MaHang";

                // 4. Load Nhân Viên (Chỉ lấy Admin)
                var dsAdmin = _nhanVienBUS.GetAllNhanVien().Where(nv => nv.VaiTro.ToLower() == "admin").ToList();
                if (dsAdmin.Count > 0)
                {
                    cboNhanVien.DataSource = dsAdmin;
                    cboNhanVien.DisplayMember = "HoTen";
                    cboNhanVien.ValueMember = "MaNV";
                }

                // ==========================================
                // NẠP DỮ LIỆU CHO 2 COMBOBOX LỌC Ở TAB LỊCH SỬ
                // ==========================================
                // 5. Load ComboBox Lọc Nhà Cung Cấp
                var listNCC_Loc = new List<string>();
                listNCC_Loc.Add("--Tất cả Nhà cung cấp--");
                if (dsNCC != null)
                {
                    listNCC_Loc.AddRange(dsNCC.Select(ncc => ncc.TenNCC));
                }
                cboLocNCC.DataSource = listNCC_Loc;

                // 6. Load ComboBox Lọc Trạng Thái (ĐÃ BỎ LƯU NHÁP)
                cboLocTrangThai.Items.Clear();
                cboLocTrangThai.Items.Add("--Tất cả trạng thái--");
                cboLocTrangThai.Items.Add("Hoàn thành");
                cboLocTrangThai.Items.Add("Đã hủy"); // Phòng hờ tính năng hủy
                cboLocTrangThai.SelectedIndex = 0; // Chọn mặc định dòng đầu tiên
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra lại dữ liệu gốc!\nLỗi: " + ex.Message, "Lỗi Tải Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboHangSX_Loc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHangSX_Loc.SelectedValue != null)
            {
                string maHang = cboHangSX_Loc.SelectedValue.ToString();
                cboSanPham.DataSource = _spBus.GetAll().Where(s => s.MaHang == maHang).ToList();
                cboSanPham.DisplayMember = "TenSP";
                cboSanPham.ValueMember = "MaSP";
            }
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedItem is SanPham sp)
            {
                txtGiaNhap.Text = sp.GiaNhap.ToString("0.##");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedItem == null) return;

            int soLuong = (int)numSoLuong.Value;
            if (soLuong <= 0) { MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo"); return; }

            if (!decimal.TryParse(txtGiaNhap.Text, out decimal giaNhap))
            {
                MessageBox.Show("Giá nhập không hợp lệ!", "Lỗi"); return;
            }

            SanPham sp = cboSanPham.SelectedItem as SanPham;

            var item = gioHang.FirstOrDefault(x => x.MaSP == sp.MaSP);
            if (item != null)
            {
                item.SoLuong += soLuong;
                item.GiaNhap = giaNhap;
                item.ThanhTien = item.SoLuong * item.GiaNhap;
            }
            else
            {
                gioHang.Add(new ChiTietNhapViewModel
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    SoLuong = soLuong,
                    GiaNhap = giaNhap,
                    ThanhTien = soLuong * giaNhap
                });
            }

            dgvChiTietNhap.Refresh();
            CapNhatTongKet();
        }

        private void CapNhatTongKet()
        {
            lblSoLoaiSP.Text = gioHang.Count.ToString();
            lblTongSoLuong.Text = gioHang.Sum(x => x.SoLuong).ToString();
            lblTongTienNhap.Text = gioHang.Sum(x => x.ThanhTien).ToString("N0") + " đ";
        }

        private void dgvChiTietNhap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvChiTietNhap.Columns[e.ColumnIndex].Name == "colNhap_STT")
            {
                e.Value = (e.RowIndex + 1).ToString();
            }
        }

        private void dgvChiTietNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChiTietNhap.Columns[e.ColumnIndex].Name == "colNhap_Xoa" && e.RowIndex >= 0)
            {
                gioHang.RemoveAt(e.RowIndex);
                CapNhatTongKet();
            }
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy bỏ toàn bộ phiếu nhập này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                gioHang.Clear();
                CapNhatTongKet();
                SinhMaPhieu();
                txtSoHoaDonNCC.Clear();
                txtGhiChu.Clear();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (gioHang.Count == 0) { MessageBox.Show("Chưa có sản phẩm nào để nhập!", "Cảnh báo"); return; }
            if (cboNhaCungCap.SelectedValue == null) { MessageBox.Show("Vui lòng chọn Nhà cung cấp!", "Cảnh báo"); return; }
            if (cboChiNhanh.SelectedValue == null) { MessageBox.Show("Vui lòng chọn Chi nhánh!", "Cảnh báo"); return; }
            if (cboNhanVien.SelectedValue == null) { MessageBox.Show("Không có quyền Admin để lập phiếu nhập!", "Cảnh báo"); return; }

            if (MessageBox.Show("Xác nhận nhập lô hàng này? Tồn kho sẽ tăng ngay lập tức.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                PhieuNhap pn = new PhieuNhap
                {
                    MaPN = txtMaPhieu.Text,
                    NgayNhap = dtpNgayNhap.Value,
                    MaNCC = cboNhaCungCap.SelectedValue.ToString(),
                    MaChiNhanh = cboChiNhanh.SelectedValue.ToString(),
                    MaNV = cboNhanVien.SelectedValue.ToString(),
                    SoHoaDonNCC = txtSoHoaDonNCC.Text,
                    GhiChu = txtGhiChu.Text,
                    TongTien = gioHang.Sum(x => x.ThanhTien),
                    TrangThai = "Hoàn thành"
                };

                List<ChiTietPhieuNhap> dsChiTiet = gioHang.Select(item => new ChiTietPhieuNhap
                {
                    MaSP = item.MaSP,
                    SoLuong = item.SoLuong,
                    DonGiaNhap = item.GiaNhap,
                    ThanhTien = item.ThanhTien
                }).ToList();

                try
                {
                    if (_pnBus.TaoPhieuNhap(pn, dsChiTiet))
                    {
                        MessageBox.Show("Nhập kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        gioHang.Clear();
                        CapNhatTongKet();
                        SinhMaPhieu();
                        txtSoHoaDonNCC.Clear();
                        txtGhiChu.Clear();

                        // Gọi lại hàm này để Lịch sử tự làm mới ngay sau khi nhập xong
                        LoadLichSuNhap();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void LoadLichSuNhap()
        {
            var dsLichSu = _pnBus.GetLichSuNhap();

            dgvLichSuNhap.AutoGenerateColumns = false;
            dgvLichSuNhap.DataSource = dsLichSu;

            lblTongPhieuNhap.Text = dsLichSu.Count.ToString();
            lblTongSPDaNhap.Text = dsLichSu.Sum(x => x.SoSanPham).ToString();
            lblTongChi.Text = dsLichSu.Sum(x => x.TongTien).ToString("N0") + " đ";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            var dsLoc = _pnBus.GetLichSuNhap();

            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;
            dsLoc = dsLoc.Where(x => x.NgayNhap.Date >= tuNgay && x.NgayNhap.Date <= denNgay).ToList();

            string nccDaChon = cboLocNCC.Text.Trim();
            if (!string.IsNullOrEmpty(nccDaChon) && nccDaChon != "--Tất cả Nhà cung cấp--")
            {
                dsLoc = dsLoc.Where(x => x.TenNCC != null && x.TenNCC.Contains(nccDaChon)).ToList();
            }

            string trangThai = cboLocTrangThai.Text.Trim();
            if (!string.IsNullOrEmpty(trangThai) && trangThai != "--Tất cả trạng thái--")
            {
                dsLoc = dsLoc.Where(x => x.TrangThai == trangThai).ToList();
            }

            dgvLichSuNhap.DataSource = dsLoc;

            lblTongPhieuNhap.Text = dsLoc.Count.ToString();
            lblTongSPDaNhap.Text = dsLoc.Sum(x => x.SoSanPham).ToString();
            lblTongChi.Text = dsLoc.Sum(x => x.TongTien).ToString("N0") + " đ";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now;
            dtpDenNgay.Value = DateTime.Now;
            cboLocNCC.Text = "--Tất cả Nhà cung cấp--";
            cboLocTrangThai.Text = "--Tất cả trạng thái--";

            LoadLichSuNhap();
        }

        private void dgvLichSuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra click đúng vào cột Chi tiết
            if (e.RowIndex >= 0 && dgvLichSuNhap.Columns[e.ColumnIndex].Name == "colChiTiet")
            {
                LichSuNhapViewModel phieuDuocChon = dgvLichSuNhap.Rows[e.RowIndex].DataBoundItem as LichSuNhapViewModel;

                if (phieuDuocChon != null)
                {
                    MessageBox.Show($"Mã Phiếu: {phieuDuocChon.MaPN}\nNhà cung cấp: {phieuDuocChon.TenNCC}\nTổng tiền: {phieuDuocChon.TongTien:N0} đ\n\nForm xem chi tiết sẽ được phát triển ở giai đoạn sau.", "Thông tin phiếu nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

    public class ChiTietNhapViewModel
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal ThanhTien { get; set; }
    }
}