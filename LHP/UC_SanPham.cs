using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_SanPham : UserControl
    {
        private SanPhamBUS _bus = new SanPhamBUS();
        private bool isAdding = false;

        public UC_SanPham()
        {
            InitializeComponent();
        }

        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            dgvSanPham.AutoGenerateColumns = false;

            // Load Combobox Trạng thái
            if (cboTrangThai.Items.Count == 0)
            {
                cboTrangThai.Items.Add("Đang kinh doanh");
                cboTrangThai.Items.Add("Ngừng kinh doanh");
                cboTrangThai.SelectedIndex = 0;
            }

            LoadComboBoxHang();
            LoadData();

            // Khởi tạo chữ mờ cho thanh tìm kiếm
            SetPlaceholderTimKiem();
        }

        // Tải dữ liệu vào 2 ComboBox Hãng Sản Xuất
        private void LoadComboBoxHang()
        {
            try
            {
                var dsHang = _bus.GetAllHang();

                // 1. Load cho ComboBox phần nhập liệu
                cboHangSanXuat.DataSource = dsHang;
                cboHangSanXuat.DisplayMember = "TenHang";
                cboHangSanXuat.ValueMember = "MaHang";

                // 2. Load cho ComboBox phần Tìm kiếm (Có thêm dòng "--Tất cả hãng--")
                var dsHangTimKiem = new List<HangSanXuat>();
                dsHangTimKiem.Add(new HangSanXuat { MaHang = "", TenHang = "--Tất cả hãng--" });
                if (dsHang != null) dsHangTimKiem.AddRange(dsHang); // Nối danh sách hãng thật vào sau

                cboTimKiemHang.DataSource = dsHangTimKiem;
                cboTimKiemHang.DisplayMember = "TenHang";
                cboTimKiemHang.ValueMember = "MaHang";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hãng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                dgvSanPham.DataSource = null;
                dgvSanPham.DataSource = _bus.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SanPham sp = dgvSanPham.Rows[e.RowIndex].DataBoundItem as SanPham;
                if (sp != null)
                {
                    txtMaSP.Text = sp.MaSP;
                    txtTenSP.Text = sp.TenSP;
                    cboHangSanXuat.SelectedValue = sp.MaHang;
                    txtGiaNhap.Text = sp.GiaNhap.ToString("0.##");
                    txtGiaBan.Text = sp.GiaBan.ToString("0.##");
                    txtTonKho.Text = sp.TonKho.ToString();
                    txtCauHinh.Text = sp.CauHinh;

                    // SỬ DỤNG .Text THAY VÌ .SelectedItem ĐỂ TRÁNH LỖI KHOẢNG TRẮNG TỪ DB
                    cboTrangThai.Text = sp.TrangThai;

                    isAdding = false;
                    txtMaSP.ReadOnly = true;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            btnLamTrong_Click(sender, e);
            txtMaSP.ReadOnly = false;
            txtMaSP.Focus();
        }

        private void btnLamTrong_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtCauHinh.Clear();
            txtTonKho.Text = "0"; // Reset về 0

            if (cboHangSanXuat.Items.Count > 0) cboHangSanXuat.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;

            txtMaSP.ReadOnly = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Tự động nhận diện Thêm mới nếu mã không khóa
            if (!isAdding && txtMaSP.ReadOnly == false && !string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                isAdding = true;
            }

            if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Mã Sản Phẩm và Tên Sản Phẩm không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal giaNhap = 0, giaBan = 0;
            if (!decimal.TryParse(txtGiaNhap.Text, out giaNhap) || !decimal.TryParse(txtGiaBan.Text, out giaBan))
            {
                MessageBox.Show("Giá nhập và Giá bán phải là số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SanPham sp = new SanPham
            {
                MaSP = txtMaSP.Text.Trim(),
                TenSP = txtTenSP.Text.Trim(),
                MaHang = cboHangSanXuat.SelectedValue?.ToString() ?? "",
                GiaNhap = giaNhap,
                GiaBan = giaBan,
                CauHinh = txtCauHinh.Text.Trim(),
                TonKho = 0, // Mới tạo luôn bằng 0
                TrangThai = cboTrangThai.Text // Dùng .Text an toàn hơn trong WinForms
            };

            if (isAdding)
            {
                try
                {
                    if (_bus.Them(sp))
                    {
                        MessageBox.Show("Thêm Sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        isAdding = false;
                        txtMaSP.ReadOnly = true;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                MessageBox.Show("Giao diện đang ở chế độ xem. Vui lòng nhấn nút [Sửa] để cập nhật dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn Sản phẩm cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal giaNhap = 0, giaBan = 0;
            decimal.TryParse(txtGiaNhap.Text, out giaNhap);
            decimal.TryParse(txtGiaBan.Text, out giaBan);

            // BẮT CHÍNH XÁC TRẠNG THÁI HIỂN THỊ TRÊN GIAO DIỆN
            string trangThaiChon = string.IsNullOrWhiteSpace(cboTrangThai.Text)
                                   ? "Đang kinh doanh"
                                   : cboTrangThai.Text;

            SanPham spCapNhat = new SanPham
            {
                MaSP = txtMaSP.Text.Trim(),
                TenSP = txtTenSP.Text.Trim(),
                MaHang = cboHangSanXuat.SelectedValue?.ToString() ?? "",
                GiaNhap = giaNhap,
                GiaBan = giaBan,
                CauHinh = txtCauHinh.Text.Trim(),
                TrangThai = trangThaiChon // Đã cập nhật dòng này
                // Không cập nhật TonKho ở đây để tránh làm sai lệch số lượng kho thực tế
            };

            if (MessageBox.Show($"Bạn có chắc chắn muốn cập nhật SP [{spCapNhat.TenSP}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (_bus.Sua(spCapNhat))
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        btnLamTrong_Click(sender, e);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text)) return;

            string maXoa = txtMaSP.Text.Trim();
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa Sản phẩm này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (_bus.Xoa(maXoa))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        btnLamTrong_Click(sender, e);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            SetPlaceholderTimKiem();
            if (cboTimKiemHang.Items.Count > 0) cboTimKiemHang.SelectedIndex = 0; // Đưa bộ lọc hãng về "--Tất cả hãng--"
            LoadData();
            btnLamTrong_Click(sender, e);
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn một Sản phẩm để nhập hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show($"Chức năng sẽ điều hướng sang Form Nhập hàng lô cho mã: {txtMaSP.Text}", "Đang phát triển", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==========================================
        // CÁC HÀM XỬ LÝ THANH TÌM KIẾM MỚI (REAL-TIME)
        // ==========================================

        private void SetPlaceholderTimKiem()
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Tên sản phẩm...";
                txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tên sản phẩm...")
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

        // HÀM LỌC CHUNG CHO CẢ TEXTBOX VÀ COMBOBOX
        private void ThucHienLocDuLieu()
        {
            // Tránh lỗi khi form chưa load xong dữ liệu
            if (_bus == null) return;

            string keyword = txtTimKiem.Text.Trim();
            string maHangLoc = cboTimKiemHang.SelectedValue?.ToString() ?? "";

            try
            {
                var ds = _bus.GetAll();

                // 1. Lọc theo từ khóa (Mã, Tên, Cấu hình) - Có không dấu
                if (!string.IsNullOrEmpty(keyword) && keyword != "Tên sản phẩm...")
                {
                    string keywordUnsign = RemoveDiacritics(keyword).ToLower();
                    ds = ds.Where(s =>
                        (s.TenSP != null && RemoveDiacritics(s.TenSP).ToLower().Contains(keywordUnsign)) ||
                        (s.MaSP != null && RemoveDiacritics(s.MaSP).ToLower().Contains(keywordUnsign)) ||
                        (s.CauHinh != null && RemoveDiacritics(s.CauHinh).ToLower().Contains(keywordUnsign))
                    ).ToList();
                }

                // 2. Lọc theo Hãng Sản Xuất (Nếu người dùng không chọn "--Tất cả hãng--")
                // Điều kiện cboTimKiemHang.SelectedIndex > 0 để bỏ qua dòng "--Tất cả hãng--" ở trên cùng
                if (!string.IsNullOrEmpty(maHangLoc) && cboTimKiemHang.SelectedIndex > 0)
                {
                    ds = ds.Where(s => s.MaHang == maHangLoc).ToList();
                }

                dgvSanPham.DataSource = ds;
            }
            catch (Exception)
            {
                // Bỏ qua lỗi ngầm khi gõ quá nhanh
            }
        }

        // Bắt sự kiện khi gõ chữ
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ThucHienLocDuLieu();
        }

        // Bắt sự kiện khi chọn hãng
        private void cboTimKiemHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThucHienLocDuLieu();
        }
    }
}