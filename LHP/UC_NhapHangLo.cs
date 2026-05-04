using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_NhapHangLo : UserControl
    {
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
                // 1. Load Chi Nhánh từ Database
                var dsChiNhanh = _pnBus.GetAllChiNhanh();
                cboChiNhanh.DataSource = dsChiNhanh;
                cboChiNhanh.DisplayMember = "TenChiNhanh";
                cboChiNhanh.ValueMember = "MaChiNhanh";

                // 2. Load Nhà Cung Cấp
                var dsNCC = _pnBus.GetAllNhaCungCap();
                cboNhaCungCap.DataSource = dsNCC;
                cboNhaCungCap.DisplayMember = "TenNCC";
                cboNhaCungCap.ValueMember = "MaNCC";

                // 3. Load Hãng SX 
                var dsHang = _spBus.GetAllHang();
                cboHangSX_Loc.DataSource = dsHang;
                cboHangSX_Loc.DisplayMember = "TenHang";
                cboHangSX_Loc.ValueMember = "MaHang";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng thêm dữ liệu Chi Nhánh và Nhà Cung Cấp vào Database trước!\nLỗi: " + ex.Message, "Thiếu dữ liệu gốc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // TỰ ĐỘNG ĐÁNH STT THEO TÊN CỘT MỚI
        private void dgvChiTietNhap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvChiTietNhap.Columns[e.ColumnIndex].Name == "colNhap_STT")
            {
                e.Value = (e.RowIndex + 1).ToString();
            }
        }

        // XÓA DÒNG THEO TÊN CỘT MỚI
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

        private void btnLuuNhap_Click(object sender, EventArgs e)
        {
            if (gioHang.Count == 0) { MessageBox.Show("Chưa có sản phẩm nào để lưu nháp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (cboNhaCungCap.SelectedValue == null) { MessageBox.Show("Vui lòng chọn Nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // Kiểm tra cboChiNhanh nếu bạn bắt buộc phải có chi nhánh
            if (cboChiNhanh.SelectedValue == null) { MessageBox.Show("Vui lòng chọn Chi nhánh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (MessageBox.Show("Bạn muốn lưu nháp phiếu này?\nTồn kho sẽ KHÔNG bị thay đổi cho đến khi bạn xác nhận chính thức.", "Xác nhận Lưu nháp", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                PhieuNhap pn = new PhieuNhap
                {
                    MaPN = txtMaPhieu.Text,
                    NgayNhap = dtpNgayNhap.Value,
                    MaNCC = cboNhaCungCap.SelectedValue.ToString(),
                    MaChiNhanh = cboChiNhanh.SelectedValue.ToString(),
                    MaNV = "NV01", // Tương lai sẽ lấy mã nhân viên đang đăng nhập
                    SoHoaDonNCC = txtSoHoaDonNCC.Text,
                    GhiChu = txtGhiChu.Text,
                    TongTien = gioHang.Sum(x => x.ThanhTien),
                    TrangThai = "Lưu nháp" // <--- DÒNG CỐT LÕI ĐỂ BÁO CHO DAL BIẾT
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
                    // Vẫn gọi hàm TaoPhieuNhap bình thường, DAL sẽ tự biết phân luồng nhờ cái TrangThai
                    if (_pnBus.TaoPhieuNhap(pn, dsChiTiet))
                    {
                        MessageBox.Show("Đã lưu nháp thành công! Bạn có thể xem lại ở tab Lịch sử nhập hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Dọn dẹp form đón phiếu mới
                        gioHang.Clear();
                        CapNhatTongKet();
                        SinhMaPhieu();
                        txtSoHoaDonNCC.Clear();
                        txtGhiChu.Clear();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (gioHang.Count == 0) { MessageBox.Show("Chưa có sản phẩm nào để nhập!", "Cảnh báo"); return; }
            if (cboNhaCungCap.SelectedValue == null) { MessageBox.Show("Vui lòng chọn Nhà cung cấp!", "Cảnh báo"); return; }
            if (cboChiNhanh.SelectedValue == null) { MessageBox.Show("Vui lòng chọn Chi nhánh!", "Cảnh báo"); return; }

            if (MessageBox.Show("Xác nhận nhập lô hàng này? Tồn kho sẽ tăng ngay lập tức.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                PhieuNhap pn = new PhieuNhap
                {
                    MaPN = txtMaPhieu.Text,
                    NgayNhap = dtpNgayNhap.Value,
                    MaNCC = cboNhaCungCap.SelectedValue.ToString(),
                    MaChiNhanh = cboChiNhanh.SelectedValue.ToString(),
                    // Tương lai khi có form đăng nhập, bạn lấy MaNV gắn vào đây. Hiện tại để tạm "NV01"
                    MaNV = "NV01",
                    SoHoaDonNCC = txtSoHoaDonNCC.Text,
                    GhiChu = txtGhiChu.Text,
                    TongTien = gioHang.Sum(x => x.ThanhTien),
                    TrangThai = "Hoàn thành"
                };

                // SoLuongDaBan mặc định là 0 đã được set ở DTO, không cần gán ở đây
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
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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