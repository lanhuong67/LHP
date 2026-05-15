using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        // Chuỗi mặc định cho ô tìm kiếm
        private readonly string _placeholderText = "Tìm mã...";

        public UC_NhapHangLo()
        {
            InitializeComponent();
        }

        private void UC_NhapHangLo_Load(object sender, EventArgs e)
        {
            dgvChiTietNhap.AutoGenerateColumns = false;
            dgvChiTietNhap.DataSource = gioHang;

            ThiếtLapNgayThang(dtpTuNgay);
            ThiếtLapNgayThang(dtpDenNgay);

            SinhMaPhieu();
            LoadComboBoxes();
            LoadLichSuNhap();

            LoadComboBox_LoHang();
            HienThiLoHang();

            KhoiTaoTraiNghiemNguoiDung();

            // Hiển thị tên nhân viên đang trực tiếp nhập hàng từ Session
            if (txtNhanVien != null)
            {
                txtNhanVien.Text = UserSession.HoTen;
                txtNhanVien.ReadOnly = true;
                txtNhanVien.BackColor = SystemColors.Control;
            }
        }

        // ==========================================================
        // CÁC HÀM XỬ LÝ UX 
        // ==========================================================
        private void KhoiTaoTraiNghiemNguoiDung()
        {
            if (txtTimMaLo != null)
            {
                txtTimMaLo.Enter += TxtTimMaLo_Enter;
                txtTimMaLo.Leave += TxtTimMaLo_Leave;
                TxtTimMaLo_Leave(txtTimMaLo, EventArgs.Empty);
            }

            ComboBox[] danhSachCbo = { cboLocNCC, cboLocTrangThai, cboSanPham_Lo, cboTrangThai_Lo };
            foreach (var cbo in danhSachCbo)
            {
                if (cbo != null)
                {
                    cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbo.Click += Cbo_AutoDropDown;
                    cbo.Enter += Cbo_AutoDropDown;
                }
            }
        }

        private void TxtTimMaLo_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox txt && txt.Text == _placeholderText)
            {
                txt.Text = "";
                txt.ForeColor = SystemColors.WindowText;
            }
        }

        private void TxtTimMaLo_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox txt && string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = _placeholderText;
                txt.ForeColor = Color.Gray;
            }
        }

        private void Cbo_AutoDropDown(object sender, EventArgs e)
        {
            if (sender is ComboBox cbo && !cbo.DroppedDown) cbo.DroppedDown = true;
        }

        // ==========================================================
        // CÁC HÀM THIẾT LẬP CƠ BẢN
        // ==========================================================
        private void ThiếtLapNgayThang(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "dd/MM/yyyy";
            dtp.ShowCheckBox = true;
            dtp.Checked = false;
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
                cboChiNhanh.DataSource = _pnBus.GetAllChiNhanh();
                cboChiNhanh.DisplayMember = "TenChiNhanh";
                cboChiNhanh.ValueMember = "MaChiNhanh";

                var dsNCC = _pnBus.GetAllNhaCungCap();
                cboNhaCungCap.DataSource = dsNCC;
                cboNhaCungCap.DisplayMember = "TenNCC";
                cboNhaCungCap.ValueMember = "MaNCC";

                cboHangSX_Loc.DataSource = _spBus.GetAllHang();
                cboHangSX_Loc.DisplayMember = "TenHang";
                cboHangSX_Loc.ValueMember = "MaHang";

                var listNCC_Loc = new List<string> { "--Tất cả Nhà cung cấp--" };
                if (dsNCC != null) listNCC_Loc.AddRange(dsNCC.Select(ncc => ncc.TenNCC));
                cboLocNCC.DataSource = listNCC_Loc;

                cboLocTrangThai.Items.Clear();
                cboLocTrangThai.Items.AddRange(new string[] { "--Tất cả trạng thái--", "Hoàn thành", "Đã hủy" });
                cboLocTrangThai.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                txtGiaNhap.Text = sp.GiaNhap.ToString("0.##");
        }

        // ==========================================================
        // XỬ LÝ TAB: TẠO PHIẾU NHẬP
        // ==========================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedItem is not SanPham sp) return;

            int soLuong = (int)numSoLuong.Value;
            if (soLuong <= 0) { MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo"); return; }
            if (!decimal.TryParse(txtGiaNhap.Text, out decimal giaNhap)) { MessageBox.Show("Giá nhập không hợp lệ!", "Lỗi"); return; }

            using (FormNhapIMEI frmIMEI = new FormNhapIMEI(sp.TenSP, soLuong, sp.MaHang))
            {
                if (frmIMEI.ShowDialog() == DialogResult.OK)
                {
                    var item = gioHang.FirstOrDefault(x => x.MaSP == sp.MaSP);
                    if (item != null)
                    {
                        item.SoLuong += soLuong;
                        item.GiaNhap = giaNhap;
                        item.ThanhTien = item.SoLuong * item.GiaNhap;
                        item.DanhSachIMEI.AddRange(frmIMEI.DanhSachIMEI_DaQuet);
                    }
                    else
                    {
                        gioHang.Add(new ChiTietNhapViewModel
                        {
                            MaSP = sp.MaSP,
                            TenSP = sp.TenSP,
                            SoLuong = soLuong,
                            GiaNhap = giaNhap,
                            ThanhTien = soLuong * giaNhap,
                            DanhSachIMEI = frmIMEI.DanhSachIMEI_DaQuet
                        });
                    }
                    dgvChiTietNhap.Refresh();
                    CapNhatTongKet();
                }
            }
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
                e.Value = (e.RowIndex + 1).ToString();
        }

        private void dgvChiTietNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChiTietNhap.Columns[e.ColumnIndex].Name == "colNhap_Xoa" && e.RowIndex >= 0)
            {
                gioHang.RemoveAt(e.RowIndex);
                CapNhatTongKet();
            }
        }

        private void ResetFormTaoPhieu()
        {
            gioHang.Clear();
            CapNhatTongKet();
            SinhMaPhieu();
            txtSoHoaDonNCC.Clear();
            txtGhiChu.Clear();
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa trắng toàn bộ thông tin đang lập dở?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ResetFormTaoPhieu();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra phân quyền: Chỉ Admin mới được xác nhận nhập lô hàng lớn
            if (UserSession.ChucVu != "Admin")
            {
                MessageBox.Show("Chỉ quản lý (Admin) mới có quyền xác nhận nhập kho!", "Cảnh báo bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (!gioHang.Any()) { MessageBox.Show("Chưa có sản phẩm nào để nhập!", "Cảnh báo"); return; }
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
                    MaNV = UserSession.MaNV, // Lấy mã NV trực tiếp từ Session
                    SoHoaDonNCC = txtSoHoaDonNCC.Text,
                    GhiChu = txtGhiChu.Text,
                    TongTien = gioHang.Sum(x => x.ThanhTien),
                    TrangThai = "Hoàn thành"
                };

                var dsChiTiet = gioHang.Select(item => new ChiTietPhieuNhap
                {
                    MaSP = item.MaSP,
                    SoLuong = item.SoLuong,
                    DonGiaNhap = item.GiaNhap,
                    ThanhTien = item.ThanhTien,
                    DanhSachIMEI = item.DanhSachIMEI
                }).ToList();

                try
                {
                    if (_pnBus.TaoPhieuNhap(pn, dsChiTiet))
                    {
                        MessageBox.Show("Nhập kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetFormTaoPhieu();
                        LoadLichSuNhap();
                        HienThiLoHang();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        // ==========================================================
        // XỬ LÝ TAB: LỊCH SỬ NHẬP HÀNG & POP-UP HỦY
        // ==========================================================
        private void LoadLichSuNhap()
        {
            var dsLichSu = _pnBus.GetLichSuNhap();
            dgvLichSuNhap.AutoGenerateColumns = false;
            dgvLichSuNhap.DataSource = dsLichSu;

            lblTongPhieuNhap.Text = dsLichSu.Count.ToString();
            lblTongSPDaNhap.Text = dsLichSu.Sum(x => x.SoSanPham).ToString();
            lblTongChi.Text = dsLichSu.Sum(x => x.TongTien).ToString("N0") + " đ";
        }

        private string PromptLyDoHuy()
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Xác nhận hủy phiếu nhập",
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Width = 350, Text = "Vui lòng nhập lý do hủy phiếu (Bắt buộc):" };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340, Multiline = true, Height = 55 };
            Button confirmation = new Button() { Text = "Xác nhận hủy", Left = 240, Width = 120, Top = 115, DialogResult = DialogResult.OK, BackColor = Color.Red, ForeColor = Color.White };
            Button cancel = new Button() { Text = "Quay lại", Left = 110, Width = 120, Top = 115, DialogResult = DialogResult.Cancel };

            prompt.Controls.Add(textLabel); prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation); prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation; prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text.Trim() : null;
        }

        private void dgvLichSuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var phieuDuocChon = dgvLichSuNhap.Rows[e.RowIndex].DataBoundItem as LichSuNhapViewModel;
            if (phieuDuocChon == null) return;

            if (dgvLichSuNhap.Columns[e.ColumnIndex].Name == "colChiTiet")
            {
                string thongBao = $"Mã Phiếu: {phieuDuocChon.MaPN}\n" +
                                  $"Nhà cung cấp: {phieuDuocChon.TenNCC}\n" +
                                  $"Tổng tiền: {phieuDuocChon.TongTien:N0} đ\n" +
                                  $"Ghi chú: {(string.IsNullOrEmpty(phieuDuocChon.GhiChu) ? "Không có" : phieuDuocChon.GhiChu)}\n\n" +
                                  $"Form xem chi tiết sẽ được phát triển ở giai đoạn sau.";

                MessageBox.Show(thongBao, "Thông tin phiếu nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dgvLichSuNhap.Columns[e.ColumnIndex].Name == "colHuyPhieu")
            {
                if (phieuDuocChon.TrangThai == "Đã hủy")
                {
                    MessageBox.Show("Phiếu này đã được hủy trước đó rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string lyDo = PromptLyDoHuy();
                if (lyDo != null)
                {
                    if (string.IsNullOrWhiteSpace(lyDo))
                    {
                        MessageBox.Show("Bạn phải ghi rõ lý do để hệ thống lưu vết thu hồi kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        if (_pnBus.HuyPhieuNhap(phieuDuocChon.MaPN, lyDo))
                        {
                            MessageBox.Show("Hủy phiếu và trừ tồn kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadLichSuNhap();
                            HienThiLoHang();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi khi hủy", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void ThucHienLocDuLieu()
        {
            if (_pnBus == null || cboLocNCC.Items.Count == 0) return;
            var dsLoc = _pnBus.GetLichSuNhap();

            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            if (dtpTuNgay.Checked && dtpDenNgay.Checked)
                dsLoc = dsLoc.Where(x => x.NgayNhap.Date >= tuNgay && x.NgayNhap.Date <= denNgay).ToList();
            else if (dtpTuNgay.Checked)
                dsLoc = dsLoc.Where(x => x.NgayNhap.Date >= tuNgay).ToList();
            else if (dtpDenNgay.Checked)
                dsLoc = dsLoc.Where(x => x.NgayNhap.Date <= denNgay).ToList();

            string nccDaChon = cboLocNCC.Text.Trim();
            if (!string.IsNullOrEmpty(nccDaChon) && nccDaChon != "--Tất cả Nhà cung cấp--")
                dsLoc = dsLoc.Where(x => x.TenNCC != null && x.TenNCC.Contains(nccDaChon)).ToList();

            string trangThai = cboLocTrangThai.Text.Trim();
            if (!string.IsNullOrEmpty(trangThai) && trangThai != "--Tất cả trạng thái--")
                dsLoc = dsLoc.Where(x => x.TrangThai == trangThai).ToList();

            dgvLichSuNhap.DataSource = dsLoc;
            lblTongPhieuNhap.Text = dsLoc.Count.ToString();
            lblTongSPDaNhap.Text = dsLoc.Sum(x => x.SoSanPham).ToString();
            lblTongChi.Text = dsLoc.Sum(x => x.TongTien).ToString("N0") + " đ";
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e) { ThucHienLocDuLieu(); }
        private void dtpDenNgay_ValueChanged(object sender, EventArgs e) { ThucHienLocDuLieu(); }
        private void cboLocNCC_SelectedIndexChanged(object sender, EventArgs e) { ThucHienLocDuLieu(); }
        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e) { ThucHienLocDuLieu(); }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (cboLocNCC.Items.Count > 0) cboLocNCC.SelectedIndex = 0;
            if (cboLocTrangThai.Items.Count > 0) cboLocTrangThai.SelectedIndex = 0;

            dtpTuNgay.Value = DateTime.Now;
            dtpDenNgay.Value = DateTime.Now;

            dtpTuNgay.Checked = false;
            dtpDenNgay.Checked = false;

            ThucHienLocDuLieu();
        }

        // ==========================================================
        // CÁC HÀM XỬ LÝ CHO TAB "THEO DÕI LÔ HÀNG"
        // ==========================================================
        private void LoadComboBox_LoHang()
        {
            try
            {
                var dsSP = _spBus.GetAll();
                var listSP = new List<string> { "--Tất cả sản phẩm--" };
                if (dsSP != null) listSP.AddRange(dsSP.Select(s => s.TenSP));

                if (cboSanPham_Lo != null)
                    cboSanPham_Lo.DataSource = listSP;

                if (cboTrangThai_Lo != null)
                {
                    cboTrangThai_Lo.Items.Clear();
                    cboTrangThai_Lo.Items.AddRange(new string[] { "--Tất cả trạng thái--", "Còn hàng", "Đã bán hết" });
                    cboTrangThai_Lo.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải combobox Lô Hàng: " + ex.Message); }
        }

        private void HienThiLoHang()
        {
            if (_pnBus == null || dgvLoHang == null) return;
            var dsLoHang = _pnBus.GetDanhSachLoHang();

            if (txtTimMaLo != null)
            {
                string tuKhoa = txtTimMaLo.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(tuKhoa) && tuKhoa != _placeholderText.ToLower())
                {
                    dsLoHang = dsLoHang.Where(x => x.MaLo.ToLower().Contains(tuKhoa) || x.MaPN.ToLower().Contains(tuKhoa)).ToList();
                }
            }

            if (cboSanPham_Lo != null)
            {
                string spChon = cboSanPham_Lo.Text;
                if (spChon != "--Tất cả sản phẩm--" && !string.IsNullOrEmpty(spChon))
                {
                    dsLoHang = dsLoHang.Where(x => x.TenSP == spChon).ToList();
                }
            }

            if (cboTrangThai_Lo != null)
            {
                string trangThaiChon = cboTrangThai_Lo.Text;
                if (trangThaiChon != "--Tất cả trạng thái--" && !string.IsNullOrEmpty(trangThaiChon))
                {
                    dsLoHang = dsLoHang.Where(x => x.TrangThai == trangThaiChon).ToList();
                }
            }

            dgvLoHang.AutoGenerateColumns = false;
            dgvLoHang.DataSource = dsLoHang;
        }

        private void btnTimLoHang_Click(object sender, EventArgs e) { HienThiLoHang(); }
        private void cboSanPham_Lo_SelectedIndexChanged(object sender, EventArgs e) { HienThiLoHang(); }
        private void cboTrangThai_Lo_SelectedIndexChanged(object sender, EventArgs e) { HienThiLoHang(); }
    }

    public class ChiTietNhapViewModel
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal ThanhTien { get; set; }
        public List<string> DanhSachIMEI { get; set; } = new List<string>();
    }

    public class FormNhapIMEI : Form
    {
        public List<string> DanhSachIMEI_DaQuet { get; private set; } = new List<string>();
        private int _soLuongYeuCau;
        private string _maHang;
        private TextBox txtInput;
        private Label lblTrangThai;

        public FormNhapIMEI(string tenSP, int soLuong, string maHang)
        {
            _soLuongYeuCau = soLuong;
            _maHang = maHang;

            this.Text = $"Quét mã IMEI - {tenSP}";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblHuongDan = new Label() { Text = $"Vui lòng dùng súng bắn mã vạch quét {soLuong} mã IMEI vào khung dưới đây (mỗi mã 1 dòng):", Left = 15, Top = 15, Width = 350, Height = 40 };
            txtInput = new TextBox() { Left = 15, Top = 60, Width = 350, Height = 180, Multiline = true, ScrollBars = ScrollBars.Vertical };
            lblTrangThai = new Label() { Text = $"Đã quét: 0 / {soLuong}", Left = 15, Top = 250, Width = 120, ForeColor = Color.Blue, Font = new Font("Arial", 10, FontStyle.Bold) };

            Button btnAuto = new Button() { Text = "Tự sinh IMEI", Left = 135, Top = 245, Width = 100, Height = 35, BackColor = Color.DarkOrange, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnAuto.Click += BtnAuto_Click;

            Button btnXacNhan = new Button() { Text = "Xác nhận", Left = 245, Top = 245, Width = 120, Height = 35, BackColor = Color.DodgerBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnXacNhan.Click += BtnXacNhan_Click;

            txtInput.TextChanged += TxtInput_TextChanged;

            this.Controls.Add(lblHuongDan);
            this.Controls.Add(txtInput);
            this.Controls.Add(lblTrangThai);
            this.Controls.Add(btnAuto);
            this.Controls.Add(btnXacNhan);
        }

        private void BtnAuto_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            List<string> listImeis = GenerateMockIMEIs(_maHang, _soLuongYeuCau);
            txtInput.Text = string.Join(Environment.NewLine, listImeis);
        }

        private List<string> GenerateMockIMEIs(string maHang, int count)
        {
            string tac = "35000000";
            switch (maHang.ToUpper().Trim())
            {
                case "AAPL": case "APPLE": tac = "35928206"; break;
                case "SSUNG": case "SAMSUNG": tac = "35315608"; break;
                case "ASUS": tac = "35712309"; break;
                case "NOKIA": tac = "35198700"; break;
                case "SONY": tac = "35876505"; break;
                case "GGL": case "GOOGLE": tac = "35645610"; break;
                case "XIAO": case "XIAOMI": tac = "86622804"; break;
                case "OPPO": tac = "86422804"; break;
                case "VIVO": tac = "86123456"; break;
                case "HWAI": case "HUAWEI": tac = "86111104"; break;
                case "RLME": case "REALME": tac = "86543204"; break;
            }

            List<string> results = new List<string>();
            Random rnd = new Random();

            while (results.Count < count)
            {
                string snr = rnd.Next(0, 1000000).ToString("D6");
                string imei14 = tac + snr;
                string fullImei = imei14 + CalculateLuhnCheckDigit(imei14);

                if (!results.Contains(fullImei)) results.Add(fullImei);
            }
            return results;
        }

        private int CalculateLuhnCheckDigit(string input14)
        {
            int sum = 0;
            for (int i = 0; i < 14; i++)
            {
                int digit = input14[i] - '0';
                if (i % 2 != 0)
                {
                    digit *= 2;
                    if (digit > 9) digit -= 9;
                }
                sum += digit;
            }
            int mod = sum % 10;
            return mod == 0 ? 0 : 10 - mod;
        }

        private void TxtInput_TextChanged(object sender, EventArgs e)
        {
            int soDong = txtInput.Lines.Count(x => !string.IsNullOrWhiteSpace(x));
            lblTrangThai.Text = $"Đã quét: {soDong} / {_soLuongYeuCau}";
            lblTrangThai.ForeColor = soDong == _soLuongYeuCau ? Color.Green : (soDong > _soLuongYeuCau ? Color.Red : Color.Blue);
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            var lines = txtInput.Lines.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToList();

            if (lines.Count != _soLuongYeuCau)
            {
                MessageBox.Show($"Số lượng IMEI không khớp! Yêu cầu {_soLuongYeuCau}, nhưng bạn quét {lines.Count}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lines.Distinct().Count() != lines.Count)
            {
                MessageBox.Show("Có mã IMEI trùng lặp trong danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lines.Any(imei => imei.Length != 15 || !imei.All(char.IsDigit)))
            {
                MessageBox.Show("Mã IMEI không hợp lệ! Phải đúng 15 chữ số.", "Lỗi Định Dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DanhSachIMEI_DaQuet = lines;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}