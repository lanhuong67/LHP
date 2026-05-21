using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class UC_ChamSocKH : UserControl
    {
        private ChamSocKhachHangBUS _bus = new ChamSocKhachHangBUS();
        private BaoHanhBUS _baoHanhBus = new BaoHanhBUS();
        private KhachHangChamSocViewModel _khachHangDangChon = null;

        private const string PLACEHOLDER_TIM = "Tìm tên KH, SĐT...";
        private const string PLACEHOLDER_NOIDUNG = "Nhập nội dung cần trao đổi với khách hàng...";
        private const string PLACEHOLDER_LICHSU = "Tìm tên KH, SĐT......";

        public UC_ChamSocKH()
        {
            InitializeComponent();
        }

        private void UC_ChamSocKH_Load(object sender, EventArgs e)
        {
            dgvDanhSachChamSoc.AutoGenerateColumns = false;
            dgvLichSuLienHe.AutoGenerateColumns = false;
            CauHinhCotChiNhanhPhatSinh();
            KhoiTaoComboBox();
            GanSuKien();
            SetPlaceholder();
            DongBoTuBaoHanh();
            LoadDanhSachChamSoc();
            LoadLichSuLienHe();
            LoadThongKe();
        }

        private void KhoiTaoComboBox()
        {
            cboLoaiLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThaiLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiChamSoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiLichSu.DropDownStyle = ComboBoxStyle.DropDownList;

            cboLoaiLoc.Items.Clear();
            cboLoaiLoc.Items.AddRange(new string[]
            {
                "--Tất cả loại--",
                "Sau mua hàng",
                "Bảo hành sắp hết hạn",
                "Bảo hành đã hết hạn",
                "Sinh nhật",
                "Nhắc thủ công",
                "Khác"
            });
            cboLoaiLoc.SelectedIndex = 0;

            cboTrangThaiLoc.Items.Clear();
            cboTrangThaiLoc.Items.AddRange(new string[]
            {
                "--Tất cả trạng thái--",
                "Chưa xử lý",
                "Đã xử lý"
            });
            cboTrangThaiLoc.SelectedIndex = 0;

            cboLoaiChamSoc.Items.Clear();
            cboLoaiChamSoc.Items.AddRange(new string[]
            {
                "Nhắc thủ công",
                "Sau mua hàng",
                "Bảo hành sắp hết hạn",
                "Bảo hành đã hết hạn",
                "Sinh nhật",
                "Khác"
            });
            cboLoaiChamSoc.SelectedIndex = 0;

            cboLoaiLichSu.Items.Clear();
            cboLoaiLichSu.Items.AddRange(new string[]
            {
                "--Tất cả loại--",
                "Sau mua hàng",
                "Bảo hành sắp hết hạn",
                "Bảo hành đã hết hạn",
                "Sinh nhật",
                "Nhắc thủ công",
                "Khác"
            });
            cboLoaiLichSu.SelectedIndex = 0;

            dtpNgayLienHe.Format = DateTimePickerFormat.Custom;
            dtpNgayLienHe.CustomFormat = "dd/MM/yyyy";
            dtpNgayLienHe.Value = DateTime.Today;
        }

        private void GanSuKien()
        {
            btnTim.Click -= btnTim_Click;
            btnTim.Click += btnTim_Click;

            btnTimKH.Click -= btnTimKH_Click;
            btnTimKH.Click += btnTimKH_Click;

            btnTaoLich.Click -= btnTaoLich_Click;
            btnTaoLich.Click += btnTaoLich_Click;

            btnTimLichSu.Click -= btnTimLichSu_Click;
            btnTimLichSu.Click += btnTimLichSu_Click;

            btnLamTrongLichSu.Click -= button4_Click;
            btnLamTrongLichSu.Click += button4_Click;

            cboLoaiLoc.SelectedIndexChanged -= BoLocDanhSach_Changed;
            cboLoaiLoc.SelectedIndexChanged += BoLocDanhSach_Changed;

            cboTrangThaiLoc.SelectedIndexChanged -= BoLocDanhSach_Changed;
            cboTrangThaiLoc.SelectedIndexChanged += BoLocDanhSach_Changed;

            cboLoaiLichSu.SelectedIndexChanged -= BoLocLichSu_Changed;
            cboLoaiLichSu.SelectedIndexChanged += BoLocLichSu_Changed;

            dgvDanhSachChamSoc.CellContentClick -= dgvDanhSachChamSoc_CellContentClick;
            dgvDanhSachChamSoc.CellContentClick += dgvDanhSachChamSoc_CellContentClick;

            dgvDanhSachChamSoc.CellFormatting -= dgvDanhSachChamSoc_CellFormatting;
            dgvDanhSachChamSoc.CellFormatting += dgvDanhSachChamSoc_CellFormatting;

            txtTimKiem.Enter -= txtTimKiem_Enter;
            txtTimKiem.Enter += txtTimKiem_Enter;

            txtTimKiem.Leave -= txtTimKiem_Leave;
            txtTimKiem.Leave += txtTimKiem_Leave;

            txtNoiDungNhac.Enter -= txtNoiDungNhac_Enter;
            txtNoiDungNhac.Enter += txtNoiDungNhac_Enter;

            txtNoiDungNhac.Leave -= txtNoiDungNhac_Leave;
            txtNoiDungNhac.Leave += txtNoiDungNhac_Leave;

            txtTimLichSu.Enter -= txtTimLichSu_Enter;
            txtTimLichSu.Enter += txtTimLichSu_Enter;

            txtTimLichSu.Leave -= txtTimLichSu_Leave;
            txtTimLichSu.Leave += txtTimLichSu_Leave;
        }

        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = PLACEHOLDER_TIM;
                txtTimKiem.ForeColor = Color.Gray;
            }

            if (string.IsNullOrWhiteSpace(txtNoiDungNhac.Text))
            {
                txtNoiDungNhac.Text = PLACEHOLDER_NOIDUNG;
                txtNoiDungNhac.ForeColor = Color.Gray;
            }

            if (string.IsNullOrWhiteSpace(txtTimLichSu.Text))
            {
                txtTimLichSu.Text = PLACEHOLDER_LICHSU;
                txtTimLichSu.ForeColor = Color.Gray;
            }
        }

        private void LoadDanhSachChamSoc()
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (tuKhoa == PLACEHOLDER_TIM) tuKhoa = "";

            string loai = cboLoaiLoc.Text;
            string trangThai = cboTrangThaiLoc.Text;

            var ds = _bus.TimKiem(tuKhoa, loai, trangThai);

            dgvDanhSachChamSoc.DataSource = null;
            dgvDanhSachChamSoc.DataSource = ds;
        }

        private void LoadLichSuLienHe()
        {
            string tuKhoa = txtTimLichSu.Text.Trim();
            if (tuKhoa == PLACEHOLDER_LICHSU) tuKhoa = "";

            string loai = cboLoaiLichSu.Text;

            var ds = _bus.TimKiem(tuKhoa, loai, "Đã xử lý");

            dgvLichSuLienHe.DataSource = null;
            dgvLichSuLienHe.DataSource = ds;
        }

        private void LoadThongKe()
        {
            var tk = _bus.GetThongKe();

            lblNhacHomNay.Text = tk.NhacHomNay + " KH";
            lblBHSapHetHan.Text = tk.BaoHanhSapHetHan + " KH";
            lblChuaLienHe.Text = tk.ChuaLienHeLai + " KH";
            lblDaXuLyTuanNay.Text = tk.DaXuLyTuanNay + " KH";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadDanhSachChamSoc();
            LoadThongKe();
        }

        private void BoLocDanhSach_Changed(object sender, EventArgs e)
        {
            LoadDanhSachChamSoc();
        }

        private void BoLocLichSu_Changed(object sender, EventArgs e)
        {
            LoadLichSuLienHe();
        }

        private void btnTimLichSu_Click(object sender, EventArgs e)
        {
            LoadLichSuLienHe();
        }

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtKhachHang.Text.Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng, tên khách hàng hoặc số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dsKH = _bus.TimKhachHang(tuKhoa);

            if (dsKH == null || dsKH.Count == 0)
            {
                _khachHangDangChon = null;
                MessageBox.Show("Không tìm thấy khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _khachHangDangChon = dsKH.First();

            txtKhachHang.Text = $"{_khachHangDangChon.MaKH} - {_khachHangDangChon.TenKH} - {_khachHangDangChon.SDT}";
            txtKhachHang.ForeColor = Color.Black;
        }

        private void btnTaoLich_Click(object sender, EventArgs e)
        {
            if (_khachHangDangChon == null)
            {
                MessageBox.Show("Vui lòng tìm và chọn khách hàng trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string noiDung = txtNoiDungNhac.Text.Trim();

            if (string.IsNullOrWhiteSpace(noiDung) || noiDung == PLACEHOLDER_NOIDUNG)
            {
                MessageBox.Show("Vui lòng nhập nội dung nhắc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChamSocKhachHang cs = new ChamSocKhachHang
            {
                MaKH = _khachHangDangChon.MaKH,
                TenKH = _khachHangDangChon.TenKH,
                SDT = _khachHangDangChon.SDT,
                LoaiChamSoc = cboLoaiChamSoc.Text,
                NoiDung = noiDung,
                NgayHen = dtpNgayLienHe.Value.Date,
                TrangThai = "Chưa xử lý",
                MaNVPhuTrach = UserSession.MaNV,
                NguonPhatSinh = "Tạo thủ công",
                MaNguon = "",
                MaChiNhanhPhatSinh = UserSession.ChiNhanhDuocChon,
                GhiChuKetQua = "",
                NgayTao = DateTime.Now,
                NgayXuLy = null
            };

            try
            {
                if (_bus.Them(cs))
                {
                    MessageBox.Show("Tạo lịch chăm sóc khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _khachHangDangChon = null;
                    txtKhachHang.Clear();
                    txtNoiDungNhac.Clear();
                    SetPlaceholder();

                    LoadDanhSachChamSoc();
                    LoadLichSuLienHe();
                    LoadThongKe();

                    tabControl1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo lịch chăm sóc: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSachChamSoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var item = dgvDanhSachChamSoc.Rows[e.RowIndex].DataBoundItem as ChamSocKHViewModel;
            if (item == null) return;

            string colName = dgvDanhSachChamSoc.Columns[e.ColumnIndex].Name;

            if (colName == "colGoi")
            {
                MessageBox.Show(
                    $"Thông tin liên hệ khách hàng:\n\n" +
                    $"Khách hàng: {item.TenKH}\n" +
                    $"SĐT: {item.SDT}\n" +
                    $"Loại chăm sóc: {item.LoaiChamSoc}\n" +
                    $"Nội dung: {item.NoiDung}",
                    "Gợi ý gọi khách",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else if (colName == "colXong")
            {
                string ghiChu = NhapGhiChuKetQua(item.TenKH);

                if (ghiChu == null) return;

                try
                {
                    if (_bus.DanhDauDaXuLy(item.Id, ghiChu))
                    {
                        MessageBox.Show("Đã đánh dấu xử lý xong.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDanhSachChamSoc();
                        LoadLichSuLienHe();
                        LoadThongKe();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string NhapGhiChuKetQua(string tenKH)
        {
            Form frm = new Form()
            {
                Width = 480,
                Height = 240,
                Text = "Kết quả chăm sóc khách hàng",
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lbl = new Label()
            {
                Left = 20,
                Top = 20,
                Width = 420,
                Text = $"Nhập ghi chú kết quả liên hệ với khách hàng: {tenKH}"
            };

            TextBox txt = new TextBox()
            {
                Left = 20,
                Top = 55,
                Width = 420,
                Height = 80,
                Multiline = true
            };

            Button btnOK = new Button()
            {
                Text = "Xác nhận",
                Left = 240,
                Width = 95,
                Top = 150,
                DialogResult = DialogResult.OK
            };

            Button btnCancel = new Button()
            {
                Text = "Hủy",
                Left = 345,
                Width = 95,
                Top = 150,
                DialogResult = DialogResult.Cancel
            };

            frm.Controls.Add(lbl);
            frm.Controls.Add(txt);
            frm.Controls.Add(btnOK);
            frm.Controls.Add(btnCancel);

            frm.AcceptButton = btnOK;
            frm.CancelButton = btnCancel;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                return string.IsNullOrWhiteSpace(txt.Text)
                    ? "Đã liên hệ khách hàng"
                    : txt.Text.Trim();
            }

            return null;
        }

        private void dgvDanhSachChamSoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string colName = dgvDanhSachChamSoc.Columns[e.ColumnIndex].Name;

            if (colName == "colTrangThai")
            {
                string trangThai = e.Value.ToString();

                if (trangThai == "Đã xử lý")
                    e.CellStyle.ForeColor = Color.Green;
                else if (trangThai == "Chưa xử lý")
                    e.CellStyle.ForeColor = Color.DarkOrange;
            }

            if (colName == "colNgayHen")
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime ngay))
                {
                    e.Value = ngay.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtTimLichSu.Clear();

            if (cboLoaiLichSu.Items.Count > 0)
                cboLoaiLichSu.SelectedIndex = 0;

            SetPlaceholder();
            LoadLichSuLienHe();
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == PLACEHOLDER_TIM)
            {
                txtTimKiem.Clear();
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            SetPlaceholder();
        }

        private void txtNoiDungNhac_Enter(object sender, EventArgs e)
        {
            if (txtNoiDungNhac.Text == PLACEHOLDER_NOIDUNG)
            {
                txtNoiDungNhac.Clear();
                txtNoiDungNhac.ForeColor = Color.Black;
            }
        }

        private void txtNoiDungNhac_Leave(object sender, EventArgs e)
        {
            SetPlaceholder();
        }

        private void txtTimLichSu_Enter(object sender, EventArgs e)
        {
            if (txtTimLichSu.Text == PLACEHOLDER_LICHSU)
            {
                txtTimLichSu.Clear();
                txtTimLichSu.ForeColor = Color.Black;
            }
        }

        private void txtTimLichSu_Leave(object sender, EventArgs e)
        {
            SetPlaceholder();
        }
        private void DongBoTuBaoHanh()
        {
            try
            {
                _baoHanhBus.DongBoTuDongBaoHanhSangChamSoc(UserSession.MaNV, 7);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi đồng bộ bảo hành sang chăm sóc khách hàng: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void CauHinhCotChiNhanhPhatSinh()
        {
            // ================================
            // 1. Grid danh sách chăm sóc
            // ================================
            if (!dgvDanhSachChamSoc.Columns.Contains("colChiNhanhPhatSinh"))
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "colChiNhanhPhatSinh";
                col.HeaderText = "Chi nhánh";
                col.DataPropertyName = "TenChiNhanhPhatSinh";
                col.Width = 130;

                int viTriChen = dgvDanhSachChamSoc.Columns.Contains("colTrangThai")
                    ? dgvDanhSachChamSoc.Columns["colTrangThai"].Index
                    : dgvDanhSachChamSoc.Columns.Count;

                dgvDanhSachChamSoc.Columns.Insert(viTriChen, col);
            }

            // ================================
            // 2. Grid lịch sử liên hệ
            // ================================
            if (!dgvLichSuLienHe.Columns.Contains("colChiNhanhPhatSinhLS"))
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = "colChiNhanhPhatSinhLS";
                col.HeaderText = "Chi nhánh";
                col.DataPropertyName = "TenChiNhanhPhatSinh";
                col.Width = 130;

                dgvLichSuLienHe.Columns.Add(col);
            }
        }
    }
}