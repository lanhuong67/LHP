using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_NhanVien : UserControl
    {
        private NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        private bool isAdding = false;

        public UC_NhanVien()
        {
            InitializeComponent();
        }

        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.AutoGenerateColumns = false;
            ThemCotTrangThaiNeuChuaCo();
            KhoiTaoComboBoxVaiTro();
            KhoiTaoComboBoxChiNhanh();

            LoadData();
            SetPlaceholderTimKiem();

            SetTrangThaiKhaiBao(false);
        }

        private void KhoiTaoComboBoxVaiTro()
        {
            try
            {
                cboVaiTro.Items.Clear();
                cboVaiTro.Items.Add("Admin");
                cboVaiTro.Items.Add("Staff");

                cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
                cboVaiTro.SelectedIndex = 1; // Mặc định Staff
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo ComboBox vai trò: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KhoiTaoComboBoxChiNhanh()
        {
            try
            {
                ComboBox cboCN = this.Controls.Find("cboChiNhanh", true).FirstOrDefault() as ComboBox;

                if (cboCN != null)
                {
                    ChiNhanhBUS cnBus = new ChiNhanhBUS();

                    // Chỉ lấy chi nhánh đang hoạt động.
                    // Chi nhánh ngưng hoạt động không được phân công cho nhân viên mới/sửa.
                    var dsChiNhanh = cnBus.GetChiNhanhDangHoatDong();

                    cboCN.DataSource = null;
                    cboCN.DropDownStyle = ComboBoxStyle.DropDownList;
                    cboCN.DisplayMember = "TenChiNhanh";
                    cboCN.ValueMember = "MaChiNhanh";
                    cboCN.DataSource = dsChiNhanh;
                    cboCN.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục Chi nhánh: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetTrangThaiKhaiBao(bool isEnabled)
        {
            txtHoTen.Enabled = isEnabled;
            txtSDT.Enabled = isEnabled;
            txtEmail.Enabled = isEnabled;
            txtTaiKhoan.Enabled = isEnabled;
            txtMatKhau.Enabled = isEnabled;

            cboVaiTro.Enabled = isEnabled;

            // Mã nhân viên tự sinh / khóa chính nên luôn khóa
            txtMaNV.Enabled = false;

            ComboBox cboCN = this.Controls.Find("cboChiNhanh", true).FirstOrDefault() as ComboBox;
            if (cboCN != null)
            {
                cboCN.Enabled = isEnabled;
            }

            btnLuu.Enabled = isEnabled;
        }

        private void LoadData()
        {
            dgvNhanVien.DataSource = _nhanVienBUS.GetAllNhanVien();

            if (dgvNhanVien.Columns["MatKhau"] != null)
            {
                dgvNhanVien.Columns["MatKhau"].Visible = false;
            }
        }

        private string PhatSinhMaNhanVienTuDong()
        {
            try
            {
                var danhSachNV = _nhanVienBUS.GetAllNhanVien();

                if (danhSachNV == null || danhSachNV.Count == 0)
                {
                    return "NV001";
                }

                var danhSachMaHopLe = danhSachNV
                    .Where(x => !string.IsNullOrWhiteSpace(x.MaNV) && x.MaNV.StartsWith("NV"))
                    .ToList();

                if (danhSachMaHopLe.Count == 0)
                {
                    return "NV001";
                }

                string maLonNhat = danhSachMaHopLe
                    .OrderByDescending(x => x.MaNV)
                    .First()
                    .MaNV;

                string phanSoText = maLonNhat.Substring(2);
                int phanSo = int.Parse(phanSoText);
                phanSo++;

                return "NV" + phanSo.ToString("D3");
            }
            catch
            {
                return "NV" + DateTime.Now.ToString("mmss");
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            NhanVien nv = dgvNhanVien.Rows[e.RowIndex].DataBoundItem as NhanVien;

            if (nv == null) return;

            txtMaNV.Text = nv.MaNV;
            txtHoTen.Text = nv.HoTen;
            txtSDT.Text = nv.SDT;
            txtEmail.Text = nv.Email;
            txtTaiKhoan.Text = nv.TenDangNhap;
            txtMatKhau.Text = nv.MatKhau;

            GanVaiTroLenComboBox(nv.VaiTro);
            GanChiNhanhLenComboBox(nv.MaChiNhanh);

            isAdding = false;
            SetTrangThaiKhaiBao(true);
        }

        private void GanChiNhanhLenComboBox(string maChiNhanh)
        {
            ComboBox cboCN = this.Controls.Find("cboChiNhanh", true).FirstOrDefault() as ComboBox;

            if (cboCN == null)
                return;

            if (string.IsNullOrWhiteSpace(maChiNhanh))
            {
                cboCN.SelectedIndex = -1;
                return;
            }

            ChiNhanhBUS cnBus = new ChiNhanhBUS();

            if (cnBus.ChiNhanhDangHoatDong(maChiNhanh))
            {
                cboCN.SelectedValue = maChiNhanh;
            }
            else
            {
                cboCN.SelectedIndex = -1;

                MessageBox.Show(
                    "Nhân viên này đang thuộc chi nhánh đã ngưng hoạt động.\n\n" +
                    "Nếu muốn cập nhật nhân viên này, bạn phải chuyển nhân viên sang một chi nhánh đang hoạt động.",
                    "Chi nhánh ngưng hoạt động",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void GanVaiTroLenComboBox(string vaiTro)
        {
            string value = ChuanHoaVaiTro(vaiTro);

            if (value == "Admin" || value == "Staff")
            {
                cboVaiTro.SelectedItem = value;
            }
            else
            {
                cboVaiTro.SelectedItem = "Staff";
            }
        }

        private string LayVaiTroDangChon()
        {
            if (cboVaiTro.SelectedItem == null)
            {
                return "";
            }

            return cboVaiTro.SelectedItem.ToString().Trim();
        }

        private string ChuanHoaVaiTro(string vaiTro)
        {
            if (string.IsNullOrWhiteSpace(vaiTro))
            {
                return "Staff";
            }

            string value = vaiTro.Trim().ToLower();

            if (value == "admin" || value == "quản trị" || value == "quan tri")
            {
                return "Admin";
            }

            if (value == "staff" || value == "nhân viên" || value == "nhan vien")
            {
                return "Staff";
            }

            return vaiTro.Trim();
        }

        private string LayMaChiNhanhDangChon()
        {
            ComboBox cboCN = this.Controls.Find("cboChiNhanh", true).FirstOrDefault() as ComboBox;

            if (cboCN == null || cboCN.SelectedValue == null)
            {
                return "";
            }

            if (cboCN.SelectedValue is ChiNhanh cn)
            {
                return cn.MaChiNhanh;
            }

            return cboCN.SelectedValue.ToString() ?? "";
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearForm();

            txtMaNV.Text = PhatSinhMaNhanVienTuDong();

            SetTrangThaiKhaiBao(true);
            txtHoTen.Focus();
        }

        private void btnLamTrong_Click(object sender, EventArgs e)
        {
            ClearForm();

            if (isAdding)
            {
                txtMaNV.Text = PhatSinhMaNhanVienTuDong();
                SetTrangThaiKhaiBao(true);
            }
            else
            {
                SetTrangThaiKhaiBao(false);
            }
        }

        private void ClearForm()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();

            if (cboVaiTro.Items.Count > 0)
            {
                cboVaiTro.SelectedItem = "Staff";
            }

            ComboBox cboCN = this.Controls.Find("cboChiNhanh", true).FirstOrDefault() as ComboBox;
            if (cboCN != null)
            {
                cboCN.SelectedIndex = -1;
            }
        }

        private bool KiemTraDuLieuNhap()
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã nhân viên!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên nhân viên!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập Tài khoản đăng nhập!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return false;
            }

            string vaiTro = LayVaiTroDangChon();

            if (vaiTro != "Admin" && vaiTro != "Staff")
            {
                MessageBox.Show("Vai trò nhân viên không hợp lệ. Chỉ được chọn Admin hoặc Staff!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboVaiTro.Focus();
                return false;
            }

            string maChiNhanh = LayMaChiNhanhDangChon();

            if (string.IsNullOrWhiteSpace(maChiNhanh))
            {
                MessageBox.Show(
                    "Vui lòng chỉ định chi nhánh đang hoạt động cho nhân viên này!\n\n" +
                    "Chi nhánh đã ngưng hoạt động sẽ không được phép chọn.",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            ChiNhanhBUS cnBus = new ChiNhanhBUS();

            if (!cnBus.ChiNhanhDangHoatDong(maChiNhanh))
            {
                MessageBox.Show(
                    "Chi nhánh được chọn đã ngưng hoạt động.\n" +
                    "Vui lòng chọn chi nhánh đang hoạt động khác.",
                    "Chi nhánh không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraDuLieuNhap())
                {
                    return;
                }

                string maChiNhanhDaChon = LayMaChiNhanhDangChon();
                string vaiTroDaChon = LayVaiTroDangChon();

                if (isAdding)
                {
                    NhanVien nvMoi = new NhanVien
                    {
                        MaNV = txtMaNV.Text.Trim(),
                        HoTen = txtHoTen.Text.Trim(),
                        SDT = txtSDT.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        VaiTro = vaiTroDaChon,
                        TenDangNhap = txtTaiKhoan.Text.Trim(),
                        MatKhau = txtMatKhau.Text.Trim(),
                        MaChiNhanh = maChiNhanhDaChon,
                        TrangThai = "Đang hoạt động"
                    };

                    if (_nhanVienBUS.ThemNhanVien(nvMoi))
                    {
                        MessageBox.Show("Thêm nhân viên thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                        ClearForm();

                        isAdding = false;
                        SetTrangThaiKhaiBao(false);
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên hoặc Tài khoản đã tồn tại!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtMaNV.Text))
                    {
                        MessageBox.Show("Vui lòng chọn nhân viên cần sửa!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    NhanVien nvCapNhat = new NhanVien
                    {
                        MaNV = txtMaNV.Text.Trim(),
                        HoTen = txtHoTen.Text.Trim(),
                        SDT = txtSDT.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        VaiTro = vaiTroDaChon,
                        TenDangNhap = txtTaiKhoan.Text.Trim(),
                        MatKhau = txtMatKhau.Text.Trim(),
                        MaChiNhanh = maChiNhanhDaChon
                    };

                    DialogResult dialogResult = MessageBox.Show(
                        $"Bạn có chắc chắn muốn cập nhật thông tin cho nhân viên [{nvCapNhat.HoTen}] không?",
                        "Xác nhận sửa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        if (_nhanVienBUS.SuaNhanVien(nvCapNhat))
                        {
                            MessageBox.Show("Cập nhật thành công!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadData();
                            ClearForm();

                            isAdding = false;
                            SetTrangThaiKhaiBao(false);
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu nhân viên: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa từ danh sách!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isAdding = false;
            SetTrangThaiKhaiBao(true);
            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn nhân viên cần ngừng hoạt động.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string maNV = txtMaNV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (maNV == UserSession.MaNV)
            {
                MessageBox.Show(
                    "Bạn không thể ngừng hoạt động tài khoản đang đăng nhập.",
                    "Không thể thực hiện",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn chuyển nhân viên [{hoTen}] sang trạng thái Ngừng hoạt động không?\n\n" +
                "Nhân viên ngừng hoạt động sẽ không thể đăng nhập vào hệ thống, nhưng thông tin vẫn được giữ lại để tra cứu lịch sử nghiệp vụ.",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            string thongBao;

            if (_nhanVienBUS.XoaNhanVien(maNV, out thongBao))
            {
                MessageBox.Show(
                    thongBao,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
                ClearForm();

                isAdding = false;
                SetTrangThaiKhaiBao(false);
            }
            else
            {
                MessageBox.Show(
                    thongBao,
                    "Không thể thực hiện",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            SetPlaceholderTimKiem();

            KhoiTaoComboBoxChiNhanh();
            LoadData();
            ClearForm();

            isAdding = false;
            SetTrangThaiKhaiBao(false);
        }

        private void SetPlaceholderTimKiem()
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Tìm tên hoặc số điện thoại...";
                txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm tên hoặc số điện thoại...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            SetPlaceholderTimKiem();
        }

        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "";

            var normalizedString = text.Normalize(System.Text.NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);

                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString()
                .Normalize(System.Text.NormalizationForm.FormC)
                .Replace("đ", "d")
                .Replace("Đ", "D");
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword) || keyword == "Tìm tên hoặc số điện thoại...")
            {
                LoadData();
                return;
            }

            string keywordUnsign = RemoveDiacritics(keyword).ToLower();
            var ds = _nhanVienBUS.GetAllNhanVien();

            dgvNhanVien.DataSource = ds.Where(nv =>
                (nv.MaNV != null && RemoveDiacritics(nv.MaNV).ToLower().Contains(keywordUnsign)) ||
                (nv.HoTen != null && RemoveDiacritics(nv.HoTen).ToLower().Contains(keywordUnsign)) ||
                (nv.SDT != null && nv.SDT.Contains(keywordUnsign)) ||
                (nv.VaiTro != null && RemoveDiacritics(nv.VaiTro).ToLower().Contains(keywordUnsign))
            ).ToList();
        }
        private void ThemCotTrangThaiNeuChuaCo()
        {
            if (dgvNhanVien.Columns["TrangThai"] != null)
                return;

            DataGridViewTextBoxColumn colTrangThai = new DataGridViewTextBoxColumn();
            colTrangThai.Name = "TrangThai";
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.DataPropertyName = "TrangThai";
            colTrangThai.Width = 130;
            colTrangThai.ReadOnly = true;

            dgvNhanVien.Columns.Add(colTrangThai);
        }
    }
}
