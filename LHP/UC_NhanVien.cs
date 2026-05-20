using System;
using System.Collections.Generic;
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

            KhoiTaoComboBoxChiNhanh();
            LoadData();
            SetPlaceholderTimKiem();

            // 🔴 KHÓA TOÀN BỘ FORM KHI MỚI MỞ LÊN
            SetTrangThaiKhaiBao(false);
        }

        // ==========================================
        // 🔴 HÀM MỚI: QUẢN LÝ TRẠNG THÁI FORM NHẬP LIỆU
        // ==========================================
        private void SetTrangThaiKhaiBao(bool isEnabled)
        {
            txtHoTen.Enabled = isEnabled;
            txtSDT.Enabled = isEnabled;
            txtEmail.Enabled = isEnabled;
            txtVaiTro.Enabled = isEnabled;
            txtTaiKhoan.Enabled = isEnabled;
            txtMatKhau.Enabled = isEnabled;

            // Luôn khóa ô Mã nhân viên vì nó tự tăng hoặc là khóa chính
            txtMaNV.Enabled = false;

            ComboBox cboCN = this.Controls.Find("cboChiNhanh", true).FirstOrDefault() as ComboBox;
            if (cboCN != null) cboCN.Enabled = isEnabled;

            // Khóa mờ luôn nút Lưu nếu không ở trạng thái nhập
            btnLuu.Enabled = isEnabled;
        }

        private void KhoiTaoComboBoxChiNhanh()
        {
            try
            {
                ComboBox cboCN = this.Controls.Find("cboChiNhanh", true).FirstOrDefault() as ComboBox;

                if (cboCN != null)
                {
                    ChiNhanhBUS cnBus = new ChiNhanhBUS();
                    var dsChiNhanh = cnBus.GetAll();

                    cboCN.DataSource = dsChiNhanh;
                    cboCN.DisplayMember = "TenChiNhanh";
                    cboCN.ValueMember = "MaChiNhanh";
                    cboCN.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục Chi nhánh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                string maLonNhat = danhSachNV.OrderByDescending(x => x.MaNV).First().MaNV;
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
            if (e.RowIndex >= 0)
            {
                NhanVien nv = dgvNhanVien.Rows[e.RowIndex].DataBoundItem as NhanVien;

                if (nv != null)
                {
                    txtMaNV.Text = nv.MaNV;
                    txtHoTen.Text = nv.HoTen;
                    txtSDT.Text = nv.SDT;
                    txtEmail.Text = nv.Email;
                    txtVaiTro.Text = nv.VaiTro;
                    txtTaiKhoan.Text = nv.TenDangNhap;
                    txtMatKhau.Text = nv.MatKhau;

                    ComboBox cboCN = this.Controls.Find("cboChiNhanh", true).FirstOrDefault() as ComboBox;
                    if (cboCN != null && !string.IsNullOrEmpty(nv.MaChiNhanh))
                    {
                        cboCN.SelectedValue = nv.MaChiNhanh;
                    }

                    isAdding = false;

                    // 🔴 MỞ KHÓA FORM ĐỂ SỬA
                    SetTrangThaiKhaiBao(true);
                }
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearForm();

            txtMaNV.Text = PhatSinhMaNhanVienTuDong();

            // 🔴 MỞ KHÓA TOÀN BỘ FORM ĐỂ NHẬP LIỆU
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
                // Nếu đang ấn nút LamMoi bình thường (ko phải thêm) thì khóa form lại
                SetTrangThaiKhaiBao(false);
            }
        }

        private void ClearForm()
        {
            txtMaNV.Clear(); txtHoTen.Clear(); txtSDT.Clear();
            txtEmail.Clear(); txtVaiTro.Clear(); txtTaiKhoan.Clear(); txtMatKhau.Clear();

            ComboBox cboCN = this.Controls.Find("cboChiNhanh", true).FirstOrDefault() as ComboBox;
            if (cboCN != null) cboCN.SelectedIndex = -1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã NV, Họ tên và Tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ComboBox cboCN = this.Controls.Find("cboChiNhanh", true).FirstOrDefault() as ComboBox;
            if (cboCN == null || cboCN.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chỉ định Chi nhánh/Nơi làm việc cho nhân viên này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maChiNhanhDaChon = cboCN.SelectedValue.ToString();

            if (isAdding)
            {
                NhanVien nvMoi = new NhanVien
                {
                    MaNV = txtMaNV.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    SDT = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    VaiTro = txtVaiTro.Text.Trim(),
                    TenDangNhap = txtTaiKhoan.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    MaChiNhanh = maChiNhanhDaChon
                };

                if (_nhanVienBUS.ThemNhanVien(nvMoi))
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    isAdding = false;
                    SetTrangThaiKhaiBao(false); // 🔴 KHÓA LẠI SAU KHI LƯU XONG
                }
                else
                {
                    MessageBox.Show("Mã nhân viên hoặc Tài khoản đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // NẾU LÀ UPDATE
            {
                // Chèn logic nút Sửa (btnSua) xuống đây để gộp chung vào nút Lưu cho chuẩn UX
                NhanVien nvCapNhat = new NhanVien
                {
                    MaNV = txtMaNV.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    SDT = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    VaiTro = txtVaiTro.Text.Trim(),
                    TenDangNhap = txtTaiKhoan.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    MaChiNhanh = maChiNhanhDaChon
                };

                DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn cập nhật thông tin cho nhân viên [{nvCapNhat.HoTen}] không?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    if (_nhanVienBUS.SuaNhanVien(nvCapNhat))
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        SetTrangThaiKhaiBao(false); // 🔴 KHÓA LẠI SAU KHI LƯU XONG
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Bỏ nút Sửa trên giao diện đi cũng được vì mình đã gộp luồng UPDATE vào nút LƯU ở trên.
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Bạn có thể xóa code trong này vì logic đã chuyển lên BtnLuu
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn một nhân viên từ danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = txtMaNV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            DialogResult result = MessageBox.Show($"Bạn có thực sự muốn xóa nhân viên [{hoTen}] không?\nDữ liệu đã xóa sẽ không thể khôi phục!", "Cảnh báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (_nhanVienBUS.XoaNhanVien(maNV))
                {
                    MessageBox.Show("Đã xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btnLamTrong_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Nhân viên này có thể đã phát sinh giao dịch trong hệ thống.", "Lỗi khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            SetPlaceholderTimKiem();
            LoadData();
            SetTrangThaiKhaiBao(false);
            ClearForm();
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

            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC)
                                .Replace("đ", "d").Replace("Đ", "D");
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
    }
}