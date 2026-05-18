using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_BaoHanh : UserControl
    {
        private BaoHanhBUS _bus = new BaoHanhBUS();

        // 🔴 GIÁP CHỐNG SPAM CLICK / DOUBLE CLICK ẢO MA
        private DateTime _lastClickTime = DateTime.MinValue;

        private List<SanPhamBaoHanhViewModel> _dsSanPham = new List<SanPhamBaoHanhViewModel>();
        private readonly string _placeholderTim = "Nhập mã HD hoặc SĐT khách hàng...";

        private List<TraCuuBaoHanhViewModel> _dsTraCuuFull = new List<TraCuuBaoHanhViewModel>();
        private readonly string _placeholderTraCuu = "Mã phiếu BH, tên KH, SĐT...";

        public UC_BaoHanh()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UC_BaoHanh_Load;

            cboThoiHan.SelectedIndexChanged += CapNhatNgayHetHan;
            dtpBatDau.ValueChanged += CapNhatNgayHetHan;
            cboDieuKien.SelectedIndexChanged += (s, ev) => CapNhatPreview();
            txtGhiChu.TextChanged += (s, ev) => CapNhatPreview();

            cboThoiHan.Click += (s, e) => { cboThoiHan.DroppedDown = true; };
            cboDieuKien.Click += (s, e) => { cboDieuKien.DroppedDown = true; };

            dgvSanPham.CellFormatting += dgvSanPham_CellFormatting;

            if (dgvSanPham != null)
            {
                for (int i = 0; i < 10; i++) dgvSanPham.CellContentClick -= dgvSanPham_CellContentClick;
                dgvSanPham.CellContentClick += dgvSanPham_CellContentClick;
            }

            if (btnTaoPhieu != null)
            {
                for (int i = 0; i < 10; i++) btnTaoPhieu.Click -= btnTaoPhieu_Click;
                btnTaoPhieu.Click += btnTaoPhieu_Click;
            }

            if (btnInPhieu != null)
            {
                for (int i = 0; i < 10; i++) btnInPhieu.Click -= btnInPhieu_Click;
                btnInPhieu.Click += btnInPhieu_Click;
            }

            if (cboTrangThaiTraCuu != null)
            {
                cboTrangThaiTraCuu.SelectedIndexChanged += cboTrangThaiTraCuu_SelectedIndexChanged;
                cboTrangThaiTraCuu.Click += (s, e) => { cboTrangThaiTraCuu.DroppedDown = true; };
            }

            if (dgvTraCuu != null)
            {
                dgvTraCuu.CellFormatting += dgvTraCuu_CellFormatting;
                for (int i = 0; i < 10; i++) dgvTraCuu.CellContentClick -= dgvTraCuu_CellContentClick;
                dgvTraCuu.CellContentClick += dgvTraCuu_CellContentClick;
            }
        }

        private void UC_BaoHanh_Load(object sender, EventArgs e)
        {
            dgvSanPham.AutoGenerateColumns = false; dgvSanPham.RowHeadersVisible = false; dgvSanPham.AllowUserToAddRows = false;
            if (dgvTraCuu != null) { dgvTraCuu.AutoGenerateColumns = false; dgvTraCuu.RowHeadersVisible = false; dgvTraCuu.AllowUserToAddRows = false; }

            if (cboThoiHan.Items.Count == 0) { cboThoiHan.Items.AddRange(new string[] { "1 tháng", "3 tháng", "6 tháng", "12 tháng", "24 tháng" }); cboThoiHan.SelectedIndex = 3; }
            if (cboDieuKien.Items.Count == 0) { cboDieuKien.Items.AddRange(new string[] { "Bảo hành nhà sản xuất", "Bảo hành VIP (Rơi vỡ)", "Sửa chữa dịch vụ (Hết hạn)" }); cboDieuKien.SelectedIndex = 0; }
            if (cboTrangThaiTraCuu != null && cboTrangThaiTraCuu.Items.Count == 0) { cboTrangThaiTraCuu.Items.AddRange(new string[] { "--Tất cả trạng thái--", "Đang xử lý", "Đã xong", "Từ chối" }); cboTrangThaiTraCuu.SelectedIndex = 0; }

            dtpBatDau.Format = DateTimePickerFormat.Custom; dtpBatDau.CustomFormat = "dd/MM/yyyy";
            dtpHetHan.Format = DateTimePickerFormat.Custom; dtpHetHan.CustomFormat = "dd/MM/yyyy"; dtpHetHan.Enabled = false;

            SinhMaPhieuBaoHanh();
            KhoiTaoThanhTimKiemRealTime();
            CapNhatNgayHetHan(null, null);
            LoadDanhSachTraCuu();
        }

        private void SinhMaPhieuBaoHanh()
        {
            lblPrevMaBH.Text = "BH" + DateTime.Now.ToString("yyMMddHHmmss");
        }

        private void KhoiTaoThanhTimKiemRealTime()
        {
            if (txtTimKiemHD != null)
            {
                txtTimKiemHD.Text = _placeholderTim; txtTimKiemHD.ForeColor = Color.Gray;
                txtTimKiemHD.Enter += (s, e) => { if (txtTimKiemHD.Text == _placeholderTim) { txtTimKiemHD.Text = ""; txtTimKiemHD.ForeColor = Color.Black; } };
                txtTimKiemHD.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtTimKiemHD.Text)) { txtTimKiemHD.Text = _placeholderTim; txtTimKiemHD.ForeColor = Color.Gray; ResetThongTinBaoHanh(); } };
                txtTimKiemHD.TextChanged += txtTimKiemHD_TextChanged;
            }
            if (txtTimKiemTraCuu != null)
            {
                txtTimKiemTraCuu.Text = _placeholderTraCuu; txtTimKiemTraCuu.ForeColor = Color.Gray;
                txtTimKiemTraCuu.Enter += (s, e) => { if (txtTimKiemTraCuu.Text == _placeholderTraCuu) { txtTimKiemTraCuu.Text = ""; txtTimKiemTraCuu.ForeColor = Color.Black; } };
                txtTimKiemTraCuu.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtTimKiemTraCuu.Text)) { txtTimKiemTraCuu.Text = _placeholderTraCuu; txtTimKiemTraCuu.ForeColor = Color.Gray; HienThiDanhSachTraCuu(); } };
                txtTimKiemTraCuu.TextChanged += (s, e) => HienThiDanhSachTraCuu();
            }
        }

        private void txtTimKiemHD_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemHD.Text.Trim();
            if (string.IsNullOrWhiteSpace(tuKhoa) || tuKhoa == _placeholderTim) { ResetThongTinBaoHanh(); return; }
            if (tuKhoa.Length == 10 || tuKhoa.Length >= 12) ThucHienTimKiemBaoHanh(tuKhoa);
            else ResetThongTinBaoHanh();
        }

        private void ThucHienTimKiemBaoHanh(string tuKhoa)
        {
            var hd = _bus.TimHoaDonBaoHanh(tuKhoa);
            if (hd != null)
            {
                lblMaHD.Text = hd.MaHD; lblKhachHang.Text = hd.TenKhachHang;
                lblSDT.Text = hd.TenNhanVien; lblNgayMua.Text = hd.NgayLap.ToString("dd/MM/yyyy HH:mm");
                lblPrevTenKH.Text = hd.TenKhachHang; lblPrevSDT.Text = hd.TenNhanVien; lblPrevNgayMua.Text = hd.NgayLap.ToString("dd/MM/yyyy");

                var rawList = _bus.GetSanPhamTuHoaDon(hd.MaHD);
                _dsSanPham = new List<SanPhamBaoHanhViewModel>();

                foreach (var item in rawList)
                {
                    if (!string.IsNullOrWhiteSpace(item.Imei) && (item.Imei.Contains(",") || item.Imei.Contains("\n")))
                    {
                        var arrImei = item.Imei.Split(new char[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var imeiStr in arrImei)
                        {
                            _dsSanPham.Add(new SanPhamBaoHanhViewModel
                            {
                                Chon = false,
                                MaSP = item.MaSP,
                                TenSP = item.TenSP,
                                SoLuong = 1,
                                DonGia = item.DonGia,
                                Imei = imeiStr.Trim()
                            });
                        }
                    }
                    else
                    {
                        item.SoLuong = 1; _dsSanPham.Add(item);
                    }
                }

                dgvSanPham.DataSource = null; dgvSanPham.DataSource = _dsSanPham; CapNhatPreview();
            }
            else { ResetThongTinBaoHanh(); }
        }

        private void ResetThongTinBaoHanh()
        {
            lblMaHD.Text = "HD"; lblKhachHang.Text = "tên KH"; lblSDT.Text = "SĐT"; lblNgayMua.Text = "Ngày mua";
            lblPrevTenKH.Text = "tên KH"; lblPrevSDT.Text = "SĐT"; lblPrevNgayMua.Text = "///"; lblPrevTenSP.Text = "sp";
            dgvSanPham.DataSource = null; if (_dsSanPham != null) _dsSanPham.Clear(); CapNhatPreview();
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "colChon")
            {
                dgvSanPham.CommitEdit(DataGridViewDataErrorContexts.Commit);
                foreach (DataGridViewRow row in dgvSanPham.Rows) { if (row.Index != e.RowIndex) row.Cells["colChon"].Value = false; }
                CapNhatPreview();
            }
        }

        private void CapNhatNgayHetHan(object sender, EventArgs e)
        {
            try
            {
                string thoiHan = cboThoiHan.Text;
                if (string.IsNullOrWhiteSpace(thoiHan)) return;
                string numbers = new string(thoiHan.Where(char.IsDigit).ToArray());
                if (int.TryParse(numbers, out int soThang)) { dtpHetHan.Value = dtpBatDau.Value.AddMonths(soThang); CapNhatPreview(); }
            }
            catch { }
        }

        private void CapNhatPreview()
        {
            var spChon = _dsSanPham?.FirstOrDefault(x => x.Chon);
            lblPrevTenSP.Text = spChon != null ? spChon.TenSP : "Chưa chọn sản phẩm";
            lblPrevBatDau.Text = dtpBatDau.Value.ToString("dd/MM/yyyy");
            lblPrevHetHan.Text = dtpHetHan.Value.ToString("dd/MM/yyyy");
            lblPrevDieuKien.Text = cboDieuKien.Text;
        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].DataPropertyName == "DonGia" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal val)) { e.Value = val.ToString("N0"); e.FormattingApplied = true; }
            }
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            // 🔴 NẾU KHOẢNG CÁCH GIỮA 2 LẦN CLICK DƯỚI 1 GIÂY -> BỎ QUA NGAY (Trị dứt điểm Ghost click)
            if ((DateTime.Now - _lastClickTime).TotalMilliseconds < 1000) return;
            _lastClickTime = DateTime.Now;

            try
            {
                if (lblMaHD.Text == "HD" || string.IsNullOrWhiteSpace(lblMaHD.Text)) { MessageBox.Show("Vui lòng nhập SĐT hoặc mã để tìm thấy hóa đơn gốc trước!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                var spChon = _dsSanPham?.FirstOrDefault(x => x.Chon);
                if (spChon == null) { MessageBox.Show("Vui lòng tích chọn một thiết bị di động ở Bước 2 để làm thủ tục bảo hành!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (MessageBox.Show("Xác nhận in và lưu Phiếu Tiếp Nhận Bảo Hành lên hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    PhieuBaoHanh pbh = new PhieuBaoHanh
                    {
                        MaPhieuBH = lblPrevMaBH.Text,
                        MaHD = lblMaHD.Text,
                        MaSP = spChon.MaSP,
                        Imei = spChon.Imei,
                        NgayTiepNhan = DateTime.Now,
                        NgayBatDauBH = dtpBatDau.Value,
                        NgayHetHanBH = dtpHetHan.Value,
                        DieuKienBaoHanh = cboDieuKien.Text,
                        TinhTrangMay = txtGhiChu.Text.Trim(),
                        TrangThai = "Đang xử lý",
                        MaNVTiepNhan = UserSession.MaNV ?? "Admin"
                    };

                    if (_bus.TaoPhieuBaoHanh(pbh))
                    {
                        MessageBox.Show("Lập phiếu bảo hành thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTimKiemHD.Text = ""; ResetThongTinBaoHanh(); SinhMaPhieuBaoHanh(); LoadDanhSachTraCuu();
                    }
                    else { MessageBox.Show("Lỗi kết nối tệp tin CSDL. Không thể lưu.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (lblPrevTenKH.Text == "tên KH" || string.IsNullOrWhiteSpace(lblPrevTenKH.Text)) { MessageBox.Show("Chưa có thông tin phiếu bảo hành hợp lệ để in!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            MessageBox.Show("Đang kết nối với máy in POS...\n(Tính năng in sẽ được phát triển ở giai đoạn sau)", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadDanhSachTraCuu()
        {
            try { _dsTraCuuFull = _bus.GetDanhSachBaoHanh(); HienThiDanhSachTraCuu(); }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách bảo hành: " + ex.Message); }
        }

        private void HienThiDanhSachTraCuu()
        {
            if (dgvTraCuu == null || _dsTraCuuFull == null) return;
            var dsLoc = _dsTraCuuFull.ToList();

            if (txtTimKiemTraCuu != null && txtTimKiemTraCuu.Text != _placeholderTraCuu && !string.IsNullOrWhiteSpace(txtTimKiemTraCuu.Text))
            {
                string keyword = txtTimKiemTraCuu.Text.Trim().ToLower();
                dsLoc = dsLoc.Where(x => (x.MaPhieuBH != null && x.MaPhieuBH.ToLower().Contains(keyword)) || (x.TenKhachHang != null && x.TenKhachHang.ToLower().Contains(keyword))).ToList();
            }

            if (cboTrangThaiTraCuu != null && cboTrangThaiTraCuu.SelectedIndex > 0)
            {
                string status = cboTrangThaiTraCuu.Text; dsLoc = dsLoc.Where(x => x.TrangThai == status).ToList();
            }

            dgvTraCuu.DataSource = null; dgvTraCuu.DataSource = dsLoc;
        }

        private void cboTrangThaiTraCuu_SelectedIndexChanged(object sender, EventArgs e) { HienThiDanhSachTraCuu(); }

        private void dgvTraCuu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTraCuu.Columns[e.ColumnIndex].DataPropertyName == "TrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Đang xử lý") e.CellStyle.ForeColor = Color.DarkOrange;
                else if (status == "Đã xong") e.CellStyle.ForeColor = Color.Green;
                else if (status == "Từ chối") e.CellStyle.ForeColor = Color.Red;
            }

            if (dgvTraCuu.Columns[e.ColumnIndex].DataPropertyName == "NgayHetHanBH" && e.Value != null)
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime date)) { e.Value = date.ToString("dd/MM/yyyy"); e.FormattingApplied = true; }
            }
        }

        private void dgvTraCuu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 🔴 ÁP DỤNG LUÔN CHO BẢNG TRA CỨU: Chống double click văng 2 popup cập nhật trạng thái
            if ((DateTime.Now - _lastClickTime).TotalMilliseconds < 500) return;
            _lastClickTime = DateTime.Now;

            try
            {
                if (dgvTraCuu.Columns[e.ColumnIndex].Name == "colThaoTac")
                {
                    var pbh = dgvTraCuu.Rows[e.RowIndex].DataBoundItem as TraCuuBaoHanhViewModel;
                    if (pbh == null) return;

                    string trangThaiMoi = PromptCapNhatTrangThai(pbh.MaPhieuBH, pbh.TrangThai);
                    if (!string.IsNullOrEmpty(trangThaiMoi) && trangThaiMoi != pbh.TrangThai)
                    {
                        if (_bus.CapNhatTrangThai(pbh.MaPhieuBH, trangThaiMoi))
                        {
                            MessageBox.Show($"Đã cập nhật trạng thái phiếu {pbh.MaPhieuBH} thành: {trangThaiMoi}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDanhSachTraCuu();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private string PromptCapNhatTrangThai(string maPhieu, string trangThaiHienTai)
        {
            Form prompt = new Form() { Width = 350, Height = 200, FormBorderStyle = FormBorderStyle.FixedDialog, Text = "Xử lý phiếu bảo hành", StartPosition = FormStartPosition.CenterScreen, MaximizeBox = false, MinimizeBox = false };
            Label textLabel = new Label() { Left = 20, Top = 20, Width = 300, Text = $"Cập nhật trạng thái cho: {maPhieu}", Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            ComboBox cboStatus = new ComboBox() { Left = 20, Top = 60, Width = 290, DropDownStyle = ComboBoxStyle.DropDownList };
            cboStatus.Items.AddRange(new string[] { "Đang xử lý", "Đã xong", "Từ chối" }); cboStatus.SelectedItem = trangThaiHienTai;

            cboStatus.Click += (s, e) => { cboStatus.DroppedDown = true; };

            Button confirmation = new Button() { Text = "Xác nhận", Left = 180, Width = 100, Height = 35, Top = 110, DialogResult = DialogResult.OK, BackColor = Color.DodgerBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button cancel = new Button() { Text = "Hủy", Left = 60, Width = 100, Height = 35, Top = 110, DialogResult = DialogResult.Cancel, FlatStyle = FlatStyle.Flat };
            prompt.Controls.Add(textLabel); prompt.Controls.Add(cboStatus); prompt.Controls.Add(confirmation); prompt.Controls.Add(cancel); prompt.AcceptButton = confirmation; prompt.CancelButton = cancel;
            return prompt.ShowDialog() == DialogResult.OK ? cboStatus.Text : null;
        }
    }
}