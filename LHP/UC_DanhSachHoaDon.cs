using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_DanhSachHoaDon : UserControl
    {
        private HoaDonBUS _bus = new HoaDonBUS();
        private readonly string _placeholderTimKiem = "Nhập Mã HĐ hoặc Tên khách...";
        private bool _isProcessingClick = false;

        public UC_DanhSachHoaDon()
        {
            InitializeComponent();

            dtpTuNgay.ValueChanged += dtp_ValueChanged;
            dtpDenNgay.ValueChanged += dtp_ValueChanged;
            cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged;

            cboTrangThai.Click += Cbo_AutoDropDown;
            cboTrangThai.Enter += Cbo_AutoDropDown;

            dgvDanhSachHoaDon.CellFormatting -= dgvDanhSachHoaDon_CellFormatting;
            dgvDanhSachHoaDon.CellContentClick -= dgvDanhSachHoaDon_CellContentClick;
            dgvDanhSachHoaDon.CellFormatting += dgvDanhSachHoaDon_CellFormatting;
            dgvDanhSachHoaDon.CellContentClick += dgvDanhSachHoaDon_CellContentClick;
        }

        private void UC_DanhSachHoaDon_Load(object sender, EventArgs e)
        {
            dgvDanhSachHoaDon.AutoGenerateColumns = false;

            SetupVietnameseDatePicker(dtpTuNgay, DateTime.Now.AddDays(-30));
            SetupVietnameseDatePicker(dtpDenNgay, DateTime.Now);

            if (cboTrangThai.Items.Count == 0)
            {
                cboTrangThai.Items.Add("--Tất cả trạng thái--");
                cboTrangThai.Items.Add("Hoàn thành");
                cboTrangThai.Items.Add("Đã hủy");
                cboTrangThai.SelectedIndex = 0;
            }

            SetPlaceholderTimKiem();
            if (txtTimKiemHD != null)
            {
                txtTimKiemHD.Enter -= txtTimKiemHD_Enter;
                txtTimKiemHD.Leave -= txtTimKiemHD_Leave;
                txtTimKiemHD.TextChanged -= txtTimKiemHD_TextChanged;

                txtTimKiemHD.Enter += txtTimKiemHD_Enter;
                txtTimKiemHD.Leave += txtTimKiemHD_Leave;
                txtTimKiemHD.TextChanged += txtTimKiemHD_TextChanged;
            }

            HienThiDanhSach();
        }

        private void dtp_ValueChanged(object sender, EventArgs e) { HienThiDanhSach(); }
        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e) { HienThiDanhSach(); }

        private void SetPlaceholderTimKiem()
        {
            if (txtTimKiemHD != null && string.IsNullOrWhiteSpace(txtTimKiemHD.Text))
            {
                txtTimKiemHD.Text = _placeholderTimKiem;
                txtTimKiemHD.ForeColor = Color.Gray;
            }
        }

        private void txtTimKiemHD_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemHD.Text == _placeholderTimKiem)
            {
                txtTimKiemHD.Text = "";
                txtTimKiemHD.ForeColor = Color.Black;
            }
        }

        private void txtTimKiemHD_Leave(object sender, EventArgs e)
        {
            SetPlaceholderTimKiem();
        }

        private void txtTimKiemHD_TextChanged(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        private void SetupVietnameseDatePicker(DateTimePicker dtp, DateTime defaultValue)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "dd/MM/yyyy";
            dtp.Value = defaultValue;
        }

        private void Cbo_AutoDropDown(object sender, EventArgs e)
        {
            if (sender is ComboBox cbo && !cbo.DroppedDown) cbo.DroppedDown = true;
        }

        private void HienThiDanhSach()
        {
            try
            {
                var dsFull = _bus.GetDanhSachHoaDon();
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;
                var dsLoc = dsFull.Where(x => x.NgayLap.Date >= tuNgay && x.NgayLap.Date <= denNgay).ToList();

                if (cboTrangThai.SelectedIndex > 0 && cboTrangThai.Text != "--Tất cả trạng thái--")
                {
                    string status = cboTrangThai.Text;
                    dsLoc = dsLoc.Where(x => x.TrangThai == status).ToList();
                }

                if (txtTimKiemHD != null && txtTimKiemHD.Text != _placeholderTimKiem && !string.IsNullOrWhiteSpace(txtTimKiemHD.Text))
                {
                    string keyword = txtTimKiemHD.Text.Trim().ToLower();
                    dsLoc = dsLoc.Where(x => x.MaHD.ToLower().Contains(keyword) ||
                                            (x.TenKhachHang != null && x.TenKhachHang.ToLower().Contains(keyword))).ToList();
                }

                dgvDanhSachHoaDon.DataSource = dsLoc;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi nạp danh sách: " + ex.Message); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
            if (txtTimKiemHD != null)
            {
                txtTimKiemHD.Text = "";
                SetPlaceholderTimKiem();
            }
        }

        private void dgvDanhSachHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSachHoaDon.Columns[e.ColumnIndex].Name == "colSTT") e.Value = (e.RowIndex + 1).ToString();

            if (dgvDanhSachHoaDon.Columns[e.ColumnIndex].Name == "colTrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Hoàn thành") e.CellStyle.ForeColor = Color.Green;
                else if (status == "Đã hủy") e.CellStyle.ForeColor = Color.Red;
            }

            // 🔴 ĐỊNH DẠNG TIỀN TỆ (Thêm dấu phẩy)
            if (dgvDanhSachHoaDon.Columns[e.ColumnIndex].DataPropertyName == "TongTien" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = val.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvDanhSachHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _isProcessingClick) return;

            _isProcessingClick = true;
            try
            {
                var hd = dgvDanhSachHoaDon.Rows[e.RowIndex].DataBoundItem as HoaDonViewModel;
                if (hd == null) return;

                if (dgvDanhSachHoaDon.Columns[e.ColumnIndex].Name == "colChiTiet")
                {
                    var dsChiTiet = _bus.GetChiTietHoaDon(hd.MaHD);
                    using (FormChiTietHoaDon frm = new FormChiTietHoaDon(hd.MaHD, dsChiTiet)) { frm.ShowDialog(); }
                }
                else if (dgvDanhSachHoaDon.Columns[e.ColumnIndex].Name == "colHuyDon")
                {
                    if (hd.TrangThai == "Đã hủy")
                    {
                        MessageBox.Show("Hóa đơn này đã được hủy trước đó, không thể hủy lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string lyDo = PromptLyDoHuy(hd.MaHD);

                    if (lyDo != null)
                    {
                        if (string.IsNullOrWhiteSpace(lyDo))
                        {
                            MessageBox.Show("Theo quy định, bắt buộc phải ghi rõ lý do hủy hóa đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        string maNhanVien = UserSession.MaNV ?? "Admin";

                        if (_bus.HuyHoaDonThongTu78(hd.MaHD, lyDo, maNhanVien))
                        {
                            MessageBox.Show("Hủy hóa đơn thành công!\nSố lượng máy đã tự động được hoàn lại vào kho.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            HienThiDanhSach();
                        }
                        else
                        {
                            MessageBox.Show("Xử lý thất bại. Vui lòng kiểm tra lại Database.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProcessingClick = false;
            }
        }

        private string PromptLyDoHuy(string maHD)
        {
            Form prompt = new Form()
            {
                Width = 470,
                Height = 280,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Thông báo hủy hóa đơn",
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };
            Label textLabel = new Label() { Left = 20, Top = 15, Width = 400, AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold), Text = $"XÁC NHẬN HỦY HÓA ĐƠN: {maHD}\n\nVui lòng nhập lý do hủy/hoàn trả (Bắt buộc):" };
            TextBox textBox = new TextBox() { Left = 20, Top = 80, Width = 410, Multiline = true, Height = 60 };

            Button cancel = new Button() { Text = "Quay lại", Left = 130, Width = 120, Height = 35, Top = 170, DialogResult = DialogResult.Cancel, FlatStyle = FlatStyle.Flat };
            Button confirmation = new Button() { Text = "Xác nhận hủy", Left = 260, Width = 150, Height = 35, Top = 170, DialogResult = DialogResult.OK, BackColor = Color.Red, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            prompt.Controls.Add(textLabel); prompt.Controls.Add(textBox); prompt.Controls.Add(confirmation); prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation; prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text.Trim() : null;
        }
    }

    public class FormChiTietHoaDon : Form
    {
        public FormChiTietHoaDon(string maHD, List<ChiTietHoaDonViewModel> dsChiTiet)
        {
            this.Text = $"Chi tiết Hóa đơn: {maHD}";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblTieuDe = new Label() { Text = $"DANH SÁCH SẢN PHẨM CỦA {maHD}", Left = 20, Top = 15, AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.Navy };

            DataGridView dgvChiTiet = new DataGridView()
            {
                Left = 20,
                Top = 50,
                Width = 740,
                Height = 300,
                AllowUserToAddRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                AutoGenerateColumns = false,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            };

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Sản phẩm", DataPropertyName = "TenSP", Width = 150 });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SL", DataPropertyName = "SoLuong", Width = 50 });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đơn giá", DataPropertyName = "DonGia", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }, Width = 100 });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thành tiền", DataPropertyName = "ThanhTien", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }, Width = 100 });

            var colImei = new DataGridViewTextBoxColumn { HeaderText = "Danh sách IMEI đã bán", DataPropertyName = "GhiChuImei", DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True } };
            dgvChiTiet.Columns.Add(colImei);

            var formattedList = dsChiTiet.Select(x => new ChiTietHoaDonViewModel
            {
                TenSP = x.TenSP,
                SoLuong = x.SoLuong,
                DonGia = x.DonGia,
                ThanhTien = x.ThanhTien,
                GhiChuImei = string.IsNullOrEmpty(x.GhiChuImei) ? "" : x.GhiChuImei.Replace(", ", "\n")
            }).ToList();

            dgvChiTiet.DataSource = formattedList;

            Button btnDong = new Button() { Text = "Đóng", Left = 660, Top = 360, Width = 100, Height = 35, BackColor = Color.LightGray, FlatStyle = FlatStyle.Flat };
            btnDong.Click += (s, e) => this.Close();

            this.Controls.Add(lblTieuDe); this.Controls.Add(dgvChiTiet); this.Controls.Add(btnDong);
        }
    }
}