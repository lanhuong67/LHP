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
            LoadData();

            // Khởi tạo chữ mờ cho thanh tìm kiếm lúc vừa mở Form
            SetPlaceholderTimKiem();
        }

        private void LoadData()
        {
            dgvNhanVien.DataSource = _nhanVienBUS.GetAllNhanVien();

            if (dgvNhanVien.Columns["MatKhau"] != null)
            {
                dgvNhanVien.Columns["MatKhau"].Visible = false;
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

                    isAdding = false;
                    txtMaNV.ReadOnly = true;
                }
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearForm();
            txtMaNV.ReadOnly = false;
            txtMaNV.Focus();
        }

        private void btnLamTrong_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtMaNV.ReadOnly = false;
        }

        // Hàm hỗ trợ xóa trắng các ô nhập liệu
        private void ClearForm()
        {
            txtMaNV.Clear(); txtHoTen.Clear(); txtSDT.Clear();
            txtEmail.Clear(); txtVaiTro.Clear(); txtTaiKhoan.Clear(); txtMatKhau.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã NV, Họ tên và Tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                    MatKhau = txtMatKhau.Text.Trim()
                };

                if (_nhanVienBUS.ThemNhanVien(nvMoi))
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    isAdding = false;
                }
                else
                {
                    MessageBox.Show("Mã nhân viên hoặc Tài khoản đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn một nhân viên từ danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NhanVien nvCapNhat = new NhanVien
            {
                MaNV = txtMaNV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                VaiTro = txtVaiTro.Text.Trim(),
                TenDangNhap = txtTaiKhoan.Text.Trim(),
                MatKhau = txtMatKhau.Text.Trim()
            };

            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn cập nhật thông tin cho nhân viên [{nvCapNhat.HoTen}] không?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if (_nhanVienBUS.SuaNhanVien(nvCapNhat))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btnLamTrong_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            SetPlaceholderTimKiem(); // Trả lại chữ mờ
            LoadData(); // Tải lại toàn bộ dữ liệu
        }

        // ==========================================
        // CÁC HÀM XỬ LÝ THANH TÌM KIẾM MỚI
        // ==========================================

        private void SetPlaceholderTimKiem()
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Tìm tên hoặc số điện thoại...";
                txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            }
        }

        // 1. Khi click chuột VÀO ô tìm kiếm
        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm tên hoặc số điện thoại...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = System.Drawing.Color.Black;
            }
        }

        // 2. Khi click chuột RA KHỎI ô tìm kiếm
        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            SetPlaceholderTimKiem();
        }

        // ==========================================
        // HÀM HỖ TRỢ: LOẠI BỎ DẤU TIẾNG VIỆT
        // ==========================================
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

            // Xử lý riêng chữ Đ (vì nó không phải là dấu)
            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC)
                                .Replace("đ", "d").Replace("Đ", "D");
        }

        // 3. Cơ chế: Tìm tới đâu, lọc tới đó (Đã update Không dấu & Tìm theo Vai trò)
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            // Bỏ qua nếu đang là chữ mờ hoặc trống
            if (string.IsNullOrEmpty(keyword) || keyword == "Tìm tên hoặc số điện thoại...")
            {
                LoadData();
                return;
            }

            // Chuyển TỪ KHÓA về dạng: Không dấu + Chữ thường
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