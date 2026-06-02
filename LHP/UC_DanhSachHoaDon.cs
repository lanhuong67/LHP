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
    public partial class UC_DanhSachHoaDon : UserControl, IBranchRefreshable
    {
        private HoaDonBUS _bus = new HoaDonBUS();
        private readonly string _placeholderTimKiem = "Nhập Mã HĐ hoặc Tên khách...";
        private bool _isProcessingClick = false;

        public UC_DanhSachHoaDon()
        {
            InitializeComponent();

            this.VisibleChanged -= UC_DanhSachHoaDon_VisibleChanged;
            this.VisibleChanged += UC_DanhSachHoaDon_VisibleChanged;

            dtpTuNgay.ValueChanged -= dtp_ValueChanged;
            dtpDenNgay.ValueChanged -= dtp_ValueChanged;
            cboTrangThai.SelectedIndexChanged -= cboTrangThai_SelectedIndexChanged;

            dtpTuNgay.ValueChanged += dtp_ValueChanged;
            dtpDenNgay.ValueChanged += dtp_ValueChanged;
            cboTrangThai.SelectedIndexChanged += cboTrangThai_SelectedIndexChanged;

            cboTrangThai.Click -= Cbo_AutoDropDown;
            cboTrangThai.Enter -= Cbo_AutoDropDown;
            cboTrangThai.Click += Cbo_AutoDropDown;
            cboTrangThai.Enter += Cbo_AutoDropDown;

            dgvDanhSachHoaDon.CellFormatting -= dgvDanhSachHoaDon_CellFormatting;
            dgvDanhSachHoaDon.CellContentClick -= dgvDanhSachHoaDon_CellContentClick;
            dgvDanhSachHoaDon.CellFormatting += dgvDanhSachHoaDon_CellFormatting;
            dgvDanhSachHoaDon.CellContentClick += dgvDanhSachHoaDon_CellContentClick;

            DamBaoCotXuLyWeb();
            DamBaoCotNguonDon();
        }

        private void UC_DanhSachHoaDon_Load(object sender, EventArgs e)
        {
            dgvDanhSachHoaDon.AutoGenerateColumns = false;
            DoiTieuDeCotNhanVien();

            DamBaoCotXuLyWeb();
            DamBaoCotNguonDon();

            if (dgvDanhSachHoaDon.Columns.Contains("colLyDoHuy"))
            {
                dgvDanhSachHoaDon.Columns["colLyDoHuy"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDanhSachHoaDon.Columns["colLyDoHuy"].Width = 250;
            }

            dgvDanhSachHoaDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            SetupVietnameseDatePicker(dtpTuNgay, DateTime.Now.AddDays(-30));
            SetupVietnameseDatePicker(dtpDenNgay, DateTime.Now);

            if (cboTrangThai.Items.Count == 0)
            {
                cboTrangThai.Items.Add("--Tất cả trạng thái--");
                cboTrangThai.Items.Add("Chờ xử lý");
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
        private void DamBaoCotNguonDon()
        {
            if (!dgvDanhSachHoaDon.Columns.Contains("colNguonDon"))
            {
                DataGridViewTextBoxColumn colNguonDon = new DataGridViewTextBoxColumn();
                colNguonDon.Name = "colNguonDon";
                colNguonDon.HeaderText = "Nguồn đơn";
                colNguonDon.DataPropertyName = "NguonDon";
                colNguonDon.Width = 100;
                colNguonDon.ReadOnly = true;

                // Đặt sau cột Mã hóa đơn nếu có
                if (dgvDanhSachHoaDon.Columns.Contains("colMaHD"))
                {
                    int indexMaHD = dgvDanhSachHoaDon.Columns["colMaHD"].Index;
                    dgvDanhSachHoaDon.Columns.Insert(indexMaHD + 1, colNguonDon);
                }
                else
                {
                    dgvDanhSachHoaDon.Columns.Add(colNguonDon);
                }
            }
        }
        private void DoiTieuDeCotNhanVien()
        {
            foreach (DataGridViewColumn col in dgvDanhSachHoaDon.Columns)
            {
                if (col.DataPropertyName == "TenNhanVien")
                {
                    col.HeaderText = "NV xử lý";
                    col.Width = 120;
                    break;
                }
            }
        }
        private void DamBaoCotXuLyWeb()
        {
            if (!dgvDanhSachHoaDon.Columns.Contains("colXuLyWeb"))
            {
                DataGridViewButtonColumn colXuLy = new DataGridViewButtonColumn();
                colXuLy.Name = "colXuLyWeb";
                colXuLy.HeaderText = "Xử lý";
                colXuLy.Text = "";
                colXuLy.UseColumnTextForButtonValue = false;
                colXuLy.Width = 80;

                if (dgvDanhSachHoaDon.Columns.Contains("colHuyDon"))
                {
                    int indexHuy = dgvDanhSachHoaDon.Columns["colHuyDon"].Index;
                    dgvDanhSachHoaDon.Columns.Insert(indexHuy, colXuLy);
                }
                else
                {
                    dgvDanhSachHoaDon.Columns.Add(colXuLy);
                }
            }

            if (dgvDanhSachHoaDon.Columns.Contains("colHuyDon"))
            {
                var colHuy = dgvDanhSachHoaDon.Columns["colHuyDon"] as DataGridViewButtonColumn;

                if (colHuy != null)
                {
                    colHuy.Text = "";
                    colHuy.UseColumnTextForButtonValue = false;
                }
            }
        }

        private void UC_DanhSachHoaDon_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                HienThiDanhSach();
            }
        }

        public void RefreshByBranch()
        {
            if (txtTimKiemHD != null)
            {
                txtTimKiemHD.Text = "";
                SetPlaceholderTimKiem();
            }

            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;

            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;

            HienThiDanhSach();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

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
            if (sender is ComboBox cbo && !cbo.DroppedDown)
                cbo.DroppedDown = true;
        }

        private void HienThiDanhSach()
        {
            try
            {
                string maCN = UserSession.ChiNhanhDuocChon;

                if (string.IsNullOrWhiteSpace(maCN))
                    return;

                var dsFull = _bus.GetDanhSachHoaDon(maCN);

                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                var dsLoc = dsFull
                    .Where(x => x.NgayLap.Date >= tuNgay && x.NgayLap.Date <= denNgay)
                    .ToList();

                if (cboTrangThai.SelectedIndex > 0 && cboTrangThai.Text != "--Tất cả trạng thái--")
                {
                    string status = cboTrangThai.Text;
                    dsLoc = dsLoc.Where(x => x.TrangThai == status).ToList();
                }

                if (txtTimKiemHD != null &&
                    txtTimKiemHD.Text != _placeholderTimKiem &&
                    !string.IsNullOrWhiteSpace(txtTimKiemHD.Text))
                {
                    string keyword = txtTimKiemHD.Text.Trim().ToLower();

                    dsLoc = dsLoc
                        .Where(x =>
                            x.MaHD.ToLower().Contains(keyword) ||
                            (x.TenKhachHang != null &&
                             x.TenKhachHang.ToLower().Contains(keyword)))
                        .ToList();
                }

                dgvDanhSachHoaDon.DataSource = null;
                dgvDanhSachHoaDon.DataSource = dsLoc;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách hóa đơn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;

            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;

            if (txtTimKiemHD != null)
            {
                txtTimKiemHD.Text = "";
                SetPlaceholderTimKiem();
            }

            HienThiDanhSach();
        }

        private void dgvDanhSachHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columnName = dgvDanhSachHoaDon.Columns[e.ColumnIndex].Name;

            if (columnName == "colSTT")
            {
                e.Value = (e.RowIndex + 1).ToString();
                e.FormattingApplied = true;
                return;
            }

            if (columnName == "colTrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();

                if (status == "Hoàn thành")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (status == "Đã hủy")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (status == "Chờ xử lý")
                {
                    e.CellStyle.ForeColor = Color.DarkOrange;
                }
            }

            if (dgvDanhSachHoaDon.Columns[e.ColumnIndex].DataPropertyName == "TongTien" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = val.ToString("N0");
                    e.FormattingApplied = true;
                }
            }

            if (columnName == "colLyDoHuy" && e.Value != null)
            {
                string lyDo = e.Value.ToString();

                if (!string.IsNullOrWhiteSpace(lyDo))
                {
                    e.CellStyle.ForeColor = Color.DarkRed;
                }
            }

            if (columnName == "colXuLyWeb")
            {
                var hd = dgvDanhSachHoaDon.Rows[e.RowIndex].DataBoundItem as HoaDonViewModel;

                if (hd != null)
                {
                    if (hd.TrangThai == "Chờ xử lý")
                    {
                        e.Value = "Xử lý";
                        e.CellStyle.ForeColor = Color.DarkBlue;
                        e.CellStyle.BackColor = Color.White;
                        e.CellStyle.Font = new Font(dgvDanhSachHoaDon.Font, FontStyle.Bold);
                    }
                    else
                    {
                        e.Value = "";
                        e.CellStyle.BackColor = Color.WhiteSmoke;
                    }

                    e.FormattingApplied = true;
                }
            }

            if (columnName == "colHuyDon")
            {
                var hd = dgvDanhSachHoaDon.Rows[e.RowIndex].DataBoundItem as HoaDonViewModel;

                if (hd != null)
                {
                    if (hd.TrangThai == "Đã hủy")
                    {
                        e.Value = "";
                        e.CellStyle.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        e.Value = "Hủy";
                        e.CellStyle.ForeColor = Color.DarkRed;
                        e.CellStyle.BackColor = Color.White;
                        e.CellStyle.Font = new Font(dgvDanhSachHoaDon.Font, FontStyle.Bold);
                    }

                    e.FormattingApplied = true;
                }
            }
            if (dgvDanhSachHoaDon.Columns[e.ColumnIndex].Name == "colNguonDon" && e.Value != null)
            {
                string nguon = e.Value.ToString();

                e.CellStyle.Font = new Font(dgvDanhSachHoaDon.Font, FontStyle.Bold);

                if (nguon == "Web")
                {
                    e.CellStyle.ForeColor = Color.DarkBlue;
                }
                else if (nguon == "Cửa hàng")
                {
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
            }
        }

        private void dgvDanhSachHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _isProcessingClick)
                return;

            _isProcessingClick = true;

            try
            {
                var hd = dgvDanhSachHoaDon.Rows[e.RowIndex].DataBoundItem as HoaDonViewModel;

                if (hd == null)
                    return;

                string columnName = dgvDanhSachHoaDon.Columns[e.ColumnIndex].Name;

                if (columnName == "colChiTiet")
                {
                    var dsChiTiet = _bus.GetChiTietHoaDon(hd.MaHD);

                    using (FormChiTietHoaDon frm = new FormChiTietHoaDon(hd, dsChiTiet))
                    {
                        frm.ShowDialog();
                    }
                }
                else if (columnName == "colXuLyWeb")
                {
                    if (!KiemTraChiNhanhDangHoatDong())
                        return;

                    if (hd.TrangThai != "Chờ xử lý")
                        return;

                    var dsChiTiet = _bus.GetChiTietHoaDon(hd.MaHD);

                    if (dsChiTiet == null || dsChiTiet.Count == 0)
                    {
                        MessageBox.Show(
                            "Hóa đơn này chưa có chi tiết sản phẩm.",
                            "Không thể xử lý",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    using (FormXuLyDonWeb frm = new FormXuLyDonWeb(
                        hd.MaHD,
                        UserSession.ChiNhanhDuocChon,
                        dsChiTiet,
                        _bus))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            HienThiDanhSach();
                        }
                    }
                }
                else if (columnName == "colHuyDon")
                {
                    if (!KiemTraChiNhanhDangHoatDong())
                        return;

                    if (hd.TrangThai == "Đã hủy")
                    {
                        MessageBox.Show(
                            "Hóa đơn này đã được hủy trước đó.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }

                    string lyDo = PromptLyDoHuy(hd.MaHD);

                    if (lyDo == null)
                        return;

                    if (string.IsNullOrWhiteSpace(lyDo))
                    {
                        MessageBox.Show(
                            "Vui lòng nhập lý do hủy hóa đơn.\nLý do hủy là bắt buộc để hệ thống lưu lại lịch sử xử lý.",
                            "Thiếu lý do hủy",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    string maNhanVien = UserSession.MaNV ?? "Admin";
                    string trangThaiTruocKhiHuy = hd.TrangThai;

                    bool ketQua = _bus.HuyHoaDonThongTu78(hd.MaHD, lyDo, maNhanVien);

                    if (ketQua)
                    {
                        if (trangThaiTruocKhiHuy == "Chờ xử lý")
                        {
                            MessageBox.Show(
                                "Đã hủy hóa đơn thành công.\n\n" +
                                "Đơn hàng này đang ở trạng thái chờ xử lý nên hệ thống chỉ cập nhật trạng thái hóa đơn, không cần hoàn kho.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(
                                "Đã hủy hóa đơn thành công.\n\n" +
                                "Hệ thống đã cập nhật lại tồn kho, trạng thái IMEI và thông tin mua hàng của khách nếu có liên quan.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }

                        HienThiDanhSach();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Không thể hủy hóa đơn này. Vui lòng kiểm tra lại trạng thái hóa đơn hoặc dữ liệu liên quan.",
                            "Không thể hủy hóa đơn",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xử lý hóa đơn này. Chi tiết lỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                Width = 490,
                Height = 280,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Xác nhận hủy hóa đơn",
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label()
            {
                Left = 20,
                Top = 15,
                Width = 430,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Text = $"Xác nhận hủy hóa đơn: {maHD}"
            };

            Label noteLabel = new Label()
            {
                Left = 20,
                Top = 50,
                Width = 430,
                Height = 40,
                Text = "Vui lòng nhập lý do hủy hóa đơn. Lý do hủy là bắt buộc để hệ thống lưu lại lịch sử xử lý.",
                ForeColor = Color.DarkRed
            };

            TextBox textBox = new TextBox()
            {
                Left = 20,
                Top = 95,
                Width = 430,
                Multiline = true,
                Height = 70
            };

            Button cancel = new Button()
            {
                Text = "Quay lại",
                Left = 190,
                Width = 120,
                Height = 35,
                Top = 185,
                DialogResult = DialogResult.Cancel,
                FlatStyle = FlatStyle.Flat
            };

            Button confirmation = new Button()
            {
                Text = "Xác nhận hủy",
                Left = 320,
                Width = 130,
                Height = 35,
                Top = 185,
                DialogResult = DialogResult.OK,
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(noteLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);

            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text.Trim() : null;
        }


        private bool KiemTraChiNhanhDangHoatDong()
        {
            if (string.IsNullOrWhiteSpace(UserSession.ChiNhanhDuocChon))
            {
                MessageBox.Show(
                    "Chưa xác định được chi nhánh đang làm việc.\nVui lòng chọn chi nhánh đang hoạt động ở góc trái trên cùng.",
                    "Thiếu chi nhánh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            ChiNhanhBUS cnBus = new ChiNhanhBUS();

            if (!cnBus.ChiNhanhDangHoatDong(UserSession.ChiNhanhDuocChon))
            {
                MessageBox.Show(
                    "Chi nhánh đang chọn đã ngưng hoạt động.\n" +
                    "Bạn không thể tạo, sửa hoặc xử lý nghiệp vụ mới tại chi nhánh này.\n\n" +
                    "Dữ liệu cũ vẫn được giữ lại để tra cứu và báo cáo.",
                    "Chi nhánh ngưng hoạt động",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }
    }

    public class FormChiTietHoaDon : Form
    {
        public FormChiTietHoaDon(HoaDonViewModel hoaDon, List<ChiTietHoaDonViewModel> dsChiTiet)
        {
            this.Text = $"Chi tiết Hóa đơn: {hoaDon.MaHD}";
            this.Size = new Size(900, 590);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblTieuDe = new Label()
            {
                Text = $"CHI TIẾT HÓA ĐƠN: {hoaDon.MaHD}",
                Left = 20,
                Top = 15,
                Width = 840,
                Height = 30,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Navy
            };

            Panel pnlThongTinDon = new Panel()
            {
                Left = 20,
                Top = 50,
                Width = 840,
                Height = 150,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(245, 250, 255)
            };

            Label lblNguon = new Label()
            {
                Text = $"Nguồn đơn: {GiaTriHoacMacDinh(hoaDon.NguonDon)}",
                Left = 12,
                Top = 10,
                Width = 260,
                Height = 24,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = hoaDon.NguonDon == "Web" ? Color.DarkBlue : Color.DarkGreen
            };

            Label lblTrangThai = new Label()
            {
                Text = $"Trạng thái: {GiaTriHoacMacDinh(hoaDon.TrangThai)}",
                Left = 290,
                Top = 10,
                Width = 260,
                Height = 24,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = LayMauTrangThai(hoaDon.TrangThai)
            };

            Label lblNhanVien = new Label()
            {
                Text = $"NV xử lý: {GiaTriHoacMacDinh(hoaDon.TenNhanVien)}",
                Left = 560,
                Top = 10,
                Width = 260,
                Height = 24,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.Black
            };

            Label lblKhach = new Label()
            {
                Text = $"Khách hàng: {GiaTriHoacMacDinh(hoaDon.TenKhachHang)}",
                Left = 12,
                Top = 40,
                Width = 390,
                Height = 24,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Black
            };

            Label lblTongTien = new Label()
            {
                Text = $"Tổng tiền: {hoaDon.TongTien:N0} đ",
                Left = 420,
                Top = 40,
                Width = 390,
                Height = 24,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };

            Label lblHinhThuc = new Label()
            {
                Text = $"Hình thức nhận: {GiaTriHoacMacDinh(hoaDon.HinhThucNhanHang)}",
                Left = 12,
                Top = 70,
                Width = 390,
                Height = 24,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Black
            };

            Label lblDiaChi = new Label()
            {
                Text = $"Địa chỉ giao hàng: {GiaTriHoacMacDinh(hoaDon.DiaChiGiaoHang)}",
                Left = 420,
                Top = 70,
                Width = 390,
                Height = 24,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Black
            };

            Label lblGhiChu = new Label()
            {
                Text = $"Ghi chú khách: {GiaTriHoacMacDinh(hoaDon.GhiChuDonHang)}",
                Left = 12,
                Top = 100,
                Width = 800,
                Height = 42,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = string.IsNullOrWhiteSpace(hoaDon.GhiChuDonHang) ? Color.Gray : Color.DarkRed
            };

            pnlThongTinDon.Controls.Add(lblNguon);
            pnlThongTinDon.Controls.Add(lblTrangThai);
            pnlThongTinDon.Controls.Add(lblNhanVien);
            pnlThongTinDon.Controls.Add(lblKhach);
            pnlThongTinDon.Controls.Add(lblTongTien);
            pnlThongTinDon.Controls.Add(lblHinhThuc);
            pnlThongTinDon.Controls.Add(lblDiaChi);
            pnlThongTinDon.Controls.Add(lblGhiChu);

            Label lblDanhSachSP = new Label()
            {
                Text = "DANH SÁCH SẢN PHẨM",
                Left = 20,
                Top = 215,
                Width = 840,
                Height = 25,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Navy
            };

            DataGridView dgvChiTiet = new DataGridView()
            {
                Left = 20,
                Top = 245,
                Width = 840,
                Height = 250,
                AllowUserToAddRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                AutoGenerateColumns = false,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            };

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã SP",
                DataPropertyName = "MaSP",
                Width = 80
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Sản phẩm",
                DataPropertyName = "TenSP",
                Width = 160
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "SL",
                DataPropertyName = "SoLuong",
                Width = 50
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn giá",
                DataPropertyName = "DonGia",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                Width = 100
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thành tiền",
                DataPropertyName = "ThanhTien",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                Width = 100
            });

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Danh sách IMEI đã bán",
                DataPropertyName = "GhiChuImei",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True
                },
                Width = 230
            });

            var formattedList = dsChiTiet.Select(x => new ChiTietHoaDonViewModel
            {
                MaSP = x.MaSP,
                TenSP = x.TenSP,
                SoLuong = x.SoLuong,
                DonGia = x.DonGia,
                ThanhTien = x.ThanhTien,
                GhiChuImei = string.IsNullOrEmpty(x.GhiChuImei)
                    ? ""
                    : x.GhiChuImei.Replace(", ", "\n")
            }).ToList();

            dgvChiTiet.DataSource = formattedList;

            Button btnDong = new Button()
            {
                Text = "Đóng",
                Left = 760,
                Top = 510,
                Width = 100,
                Height = 35,
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };

            btnDong.Click += (s, e) => this.Close();

            this.Controls.Add(lblTieuDe);
            this.Controls.Add(pnlThongTinDon);
            this.Controls.Add(lblDanhSachSP);
            this.Controls.Add(dgvChiTiet);
            this.Controls.Add(btnDong);
        }

        private static string GiaTriHoacMacDinh(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "Không có" : value;
        }

        private static Color LayMauTrangThai(string trangThai)
        {
            if (trangThai == "Chờ xử lý")
                return Color.DarkOrange;

            if (trangThai == "Hoàn thành")
                return Color.Green;

            if (trangThai == "Đã hủy")
                return Color.Red;

            return Color.Black;
        }
    }

    public class FormXuLyDonWeb : Form
    {
        private readonly string _maHD;
        private readonly string _maCN;
        private readonly List<ChiTietHoaDonViewModel> _dsChiTiet;
        private readonly HoaDonBUS _bus;

        private FlowLayoutPanel flowPanel;
        private Dictionary<string, CheckedListBox> _mapCheckedListBox = new Dictionary<string, CheckedListBox>();

        public FormXuLyDonWeb(string maHD, string maCN, List<ChiTietHoaDonViewModel> dsChiTiet, HoaDonBUS bus)
        {
            _maHD = maHD;
            _maCN = maCN;
            _dsChiTiet = dsChiTiet;
            _bus = bus;

            KhoiTaoGiaoDien();
            LoadDanhSachSanPhamCanXuLy();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = $"Xử lý đơn web: {_maHD}";
            this.Size = new Size(780, 640);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblTitle = new Label()
            {
                Text = $"XÁC NHẬN ĐƠN WEB: {_maHD}",
                Left = 20,
                Top = 15,
                Width = 720,
                Height = 30,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.Navy
            };

            Label lblGuide = new Label()
            {
                Text = "Chọn đúng số lượng IMEI cho từng sản phẩm. Hệ thống tự tick IMEI nhập kho lâu nhất theo FIFO.",
                Left = 20,
                Top = 48,
                Width = 720,
                Height = 25,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.DarkGreen
            };

            flowPanel = new FlowLayoutPanel()
            {
                Left = 20,
                Top = 85,
                Width = 720,
                Height = 420,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            Button btnXacNhan = new Button()
            {
                Text = "Xác nhận hoàn thành đơn",
                Left = 390,
                Top = 525,
                Width = 230,
                Height = 40,
                BackColor = Color.Green,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnXacNhan.Click += BtnXacNhan_Click;

            Button btnDong = new Button()
            {
                Text = "Đóng",
                Left = 640,
                Top = 525,
                Width = 100,
                Height = 40,
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnDong.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblGuide);
            this.Controls.Add(flowPanel);
            this.Controls.Add(btnXacNhan);
            this.Controls.Add(btnDong);
        }

        private void LoadDanhSachSanPhamCanXuLy()
        {
            flowPanel.Controls.Clear();
            _mapCheckedListBox.Clear();

            foreach (var ct in _dsChiTiet)
            {
                Panel panel = new Panel()
                {
                    Width = 680,
                    Height = 190,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    BackColor = Color.FromArgb(248, 250, 252)
                };

                Label lblSP = new Label()
                {
                    Text = $"{ct.TenSP} - SL cần chọn: {ct.SoLuong}",
                    Left = 12,
                    Top = 10,
                    Width = 640,
                    Height = 25,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.DarkBlue
                };

                Label lblMaSP = new Label()
                {
                    Text = $"Mã SP: {ct.MaSP} | Đơn giá: {ct.DonGia:N0} đ | Thành tiền: {ct.ThanhTien:N0} đ",
                    Left = 12,
                    Top = 35,
                    Width = 640,
                    Height = 22,
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.DimGray
                };

                CheckedListBox clbImei = new CheckedListBox()
                {
                    Left = 12,
                    Top = 62,
                    Width = 640,
                    Height = 108,
                    CheckOnClick = true
                };

                var dsImei = _bus.GetImeiTonKho(ct.MaSP, _maCN);

                if (dsImei == null || dsImei.Count < ct.SoLuong)
                {
                    int soLuongCon = dsImei == null ? 0 : dsImei.Count;

                    clbImei.Items.Add($"Không đủ IMEI trong kho. Còn {soLuongCon}, cần {ct.SoLuong}.");
                    clbImei.Enabled = false;
                    panel.BackColor = Color.MistyRose;
                }
                else
                {
                    foreach (var imei in dsImei)
                    {
                        clbImei.Items.Add(imei);
                    }

                    for (int i = 0; i < ct.SoLuong && i < clbImei.Items.Count; i++)
                    {
                        clbImei.SetItemChecked(i, true);
                    }
                }

                clbImei.ItemCheck += (s, e) =>
                {
                    int checkedCount = clbImei.CheckedItems.Count;

                    if (e.NewValue == CheckState.Checked)
                        checkedCount++;
                    else if (e.NewValue == CheckState.Unchecked)
                        checkedCount--;

                    if (checkedCount > ct.SoLuong)
                    {
                        e.NewValue = CheckState.Unchecked;

                        MessageBox.Show(
                            $"Sản phẩm {ct.TenSP} chỉ được chọn đúng {ct.SoLuong} IMEI.",
                            "Cảnh báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }
                };

                panel.Controls.Add(lblSP);
                panel.Controls.Add(lblMaSP);
                panel.Controls.Add(clbImei);

                flowPanel.Controls.Add(panel);

                _mapCheckedListBox[ct.MaSP] = clbImei;
            }
        }

        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, List<string>> imeiTheoSanPham = new Dictionary<string, List<string>>();

                foreach (var ct in _dsChiTiet)
                {
                    if (!_mapCheckedListBox.ContainsKey(ct.MaSP))
                    {
                        MessageBox.Show(
                            $"Chưa có danh sách IMEI cho sản phẩm {ct.TenSP}.",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return;
                    }

                    CheckedListBox clb = _mapCheckedListBox[ct.MaSP];

                    if (!clb.Enabled)
                    {
                        MessageBox.Show(
                            $"Sản phẩm {ct.TenSP} không đủ IMEI trong kho để xử lý đơn.",
                            "Thiếu IMEI",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    List<string> imeiDaChon = new List<string>();

                    foreach (var item in clb.CheckedItems)
                    {
                        if (item != null)
                            imeiDaChon.Add(item.ToString());
                    }

                    imeiDaChon = imeiDaChon
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(x => x.Trim())
                        .Distinct()
                        .ToList();

                    if (imeiDaChon.Count != ct.SoLuong)
                    {
                        MessageBox.Show(
                            $"Sản phẩm {ct.TenSP} cần chọn đúng {ct.SoLuong} IMEI, hiện đang chọn {imeiDaChon.Count}.",
                            "Thiếu IMEI",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    imeiTheoSanPham[ct.MaSP] = imeiDaChon;
                }

                DialogResult confirm = MessageBox.Show(
                    "Xác nhận hoàn thành đơn web?\n\nSau khi xác nhận, hệ thống sẽ trừ tồn kho, cập nhật IMEI đã bán và chuyển hóa đơn sang Hoàn thành.",
                    "Xác nhận xử lý đơn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm != DialogResult.Yes)
                    return;

                string maNV = string.IsNullOrWhiteSpace(UserSession.MaNV)
                    ? "NV01"
                    : UserSession.MaNV;

                bool thanhCong = _bus.XacNhanDonWeb(_maHD, imeiTheoSanPham, maNV);

                if (thanhCong)
                {
                    MessageBox.Show(
                        "Xử lý đơn web thành công!\nHóa đơn đã chuyển sang Hoàn thành.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Không thể xử lý đơn web. Vui lòng kiểm tra lại dữ liệu.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi xử lý đơn web",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}