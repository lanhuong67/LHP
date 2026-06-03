using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_SanPham : UserControl, IBranchRefreshable
    {
        private SanPhamBUS _bus = new SanPhamBUS();
        private bool isAdding = false;

        public UC_SanPham()
        {
            InitializeComponent();
            // 🔴 Đăng ký sự kiện tự động refresh dữ liệu khi Admin đổi chi nhánh ở FormMain
            this.VisibleChanged += UC_SanPham_VisibleChanged;
        }

        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.CellFormatting += dgvSanPham_CellFormatting;
            btnNhapKho.Click -= btnNhapKho_Click;
            btnNhapKho.Click += btnNhapKho_Click;

            if (cboTrangThai.Items.Count == 0)
            {
                cboTrangThai.Items.Add("Đang kinh doanh");
                cboTrangThai.Items.Add("Ngừng kinh doanh");
                cboTrangThai.SelectedIndex = 0;
            }

            LoadComboBoxHang();
            LoadData();
            SetPlaceholderTimKiem();
        }

        private void UC_SanPham_VisibleChanged(object sender, EventArgs e)
        {
            // Khi màn hình hiển thị lại, tự động tải dữ liệu của chi nhánh mới
            if (this.Visible) LoadData();
        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Value != null)
            {
                string propName = dgvSanPham.Columns[e.ColumnIndex].DataPropertyName;
                if (propName == "GiaNhap" || propName == "GiaBan")
                {
                    if (decimal.TryParse(e.Value.ToString(), out decimal val))
                    {
                        e.Value = val.ToString("N0");
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void LoadComboBoxHang()
        {
            try
            {
                var dsHang = _bus.GetAllHang();
                var dsHangHoatDong = dsHang.Where(h => h.TrangThai == "Đang hợp tác").ToList();
                cboHangSanXuat.DataSource = dsHangHoatDong;
                cboHangSanXuat.DisplayMember = "TenHang";
                cboHangSanXuat.ValueMember = "MaHang";

                var dsHangTimKiem = new List<HangSanXuat>();
                dsHangTimKiem.Add(new HangSanXuat { MaHang = "", TenHang = "--Tất cả hãng--" });
                if (dsHang != null) dsHangTimKiem.AddRange(dsHang);

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
                // 🔴 ĐÃ SỬA: Lấy dữ liệu theo chi nhánh đang được chọn
                dgvSanPham.DataSource = _bus.GetByBranch(UserSession.ChiNhanhDuocChon);
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
                    txtGiaNhap.Text = sp.GiaNhap.ToString("N0");
                    txtGiaBan.Text = sp.GiaBan.ToString("N0");
                    txtTonKho.Text = sp.TonKho.ToString();
                    txtCauHinh.Text = sp.CauHinh;
                    cboTrangThai.Text = sp.TrangThai;

                    isAdding = false;
                    txtMaSP.ReadOnly = true;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraChiNhanhDangHoatDong())
                return;

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
            txtTonKho.Text = "0";

            if (cboHangSanXuat.Items.Count > 0) cboHangSanXuat.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;

            txtMaSP.ReadOnly = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraChiNhanhDangHoatDong())
                return;

            if (!isAdding && txtMaSP.ReadOnly == false && !string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                isAdding = true;
            }

            if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Mã Sản Phẩm và Tên Sản Phẩm không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(UserSession.ChiNhanhDuocChon))
            {
                MessageBox.Show("Lỗi hệ thống: Chưa xác định được Chi nhánh đang làm việc. Vui lòng chọn lại Chi nhánh ở góc trái trên cùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal giaNhap, giaBan;

            if (!KiemTraGiaHopLe(out giaNhap, out giaBan))
            {
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
                TonKho = 0,
                TrangThai = cboTrangThai.Text,
                MaChiNhanh = UserSession.ChiNhanhDuocChon // Đã được đảm bảo không rỗng nhờ bước chặn ở trên
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
                    else // 🔴 BỔ SUNG ELSE ĐỂ TRÁNH IM LẶNG
                    {
                        MessageBox.Show("Thêm thất bại! Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // 🔴 HIỂN THỊ CHÍNH XÁC LỖI TỪ SQL LÊN MÀN HÌNH
                    MessageBox.Show("Lỗi Database: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Giao diện đang ở chế độ xem. Vui lòng nhấn nút [Sửa] để cập nhật dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraChiNhanhDangHoatDong())
                return;

            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn Sản phẩm cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal giaNhap, giaBan;

            if (!KiemTraGiaHopLe(out giaNhap, out giaBan))
            {
                return;
            }

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
                TrangThai = trangThaiChon,
                // 🔴 ĐÃ SỬA: Gán chi nhánh để lúc Cập nhật DB không báo lỗi NULL
                MaChiNhanh = UserSession.ChiNhanhDuocChon
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
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần xóa khỏi danh mục.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string maSP = txtMaSP.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm [{tenSP}] khỏi danh mục không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                string thongBao;

                bool ketQua = _bus.Xoa(maSP, out thongBao);

                if (ketQua)
                {
                    MessageBox.Show(
                        thongBao,
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadData();
                    btnLamTrong_Click(sender, e);
                }
                else
                {
                    MessageBox.Show(
                        thongBao,
                        "Không thể xóa sản phẩm",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xử lý sản phẩm này. Chi tiết lỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            SetPlaceholderTimKiem();
            if (cboTimKiemHang.Items.Count > 0) cboTimKiemHang.SelectedIndex = 0;
            LoadData();
            btnLamTrong_Click(sender, e);
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần nhập kho.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string maSP = txtMaSP.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();

            DialogResult result = MessageBox.Show(
                $"Bạn có muốn chuyển sang màn hình Nhập hàng / lô để nhập kho cho sản phẩm [{tenSP}] không?",
                "Xác nhận nhập kho",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            FormMain formMain = this.FindForm() as FormMain;

            if (formMain == null)
            {
                MessageBox.Show(
                    "Không tìm thấy màn hình chính để chuyển sang chức năng nhập kho.",
                    "Lỗi điều hướng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            formMain.MoNhapHangTheoSanPham(maSP);
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
            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC).Replace("đ", "d").Replace("Đ", "D");
        }

        private void ThucHienLocDuLieu()
        {
            if (_bus == null) return;

            string keyword = txtTimKiem.Text.Trim();
            string maHangLoc = cboTimKiemHang.SelectedValue?.ToString() ?? "";

            try
            {
                // 🔴 ĐÃ SỬA: Chỉ tìm kiếm trong các sản phẩm của chi nhánh hiện tại
                var ds = _bus.GetByBranch(UserSession.ChiNhanhDuocChon);

                if (!string.IsNullOrEmpty(keyword) && keyword != "Tên sản phẩm...")
                {
                    string keywordUnsign = RemoveDiacritics(keyword).ToLower();
                    ds = ds.Where(s =>
                        (s.TenSP != null && RemoveDiacritics(s.TenSP).ToLower().Contains(keywordUnsign)) ||
                        (s.MaSP != null && RemoveDiacritics(s.MaSP).ToLower().Contains(keywordUnsign)) ||
                        (s.CauHinh != null && RemoveDiacritics(s.CauHinh).ToLower().Contains(keywordUnsign))
                    ).ToList();
                }

                if (!string.IsNullOrEmpty(maHangLoc) && cboTimKiemHang.SelectedIndex > 0)
                {
                    ds = ds.Where(s => s.MaHang == maHangLoc).ToList();
                }

                dgvSanPham.DataSource = ds;
            }
            catch (Exception) { }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e) { ThucHienLocDuLieu(); }
        private void cboTimKiemHang_SelectedIndexChanged(object sender, EventArgs e) { ThucHienLocDuLieu(); }
        public void RefreshByBranch()
        {
            // Làm trống form bên phải
            btnLamTrong_Click(null, null);

            // Reset ô tìm kiếm
            txtTimKiem.Clear();
            SetPlaceholderTimKiem();

            // Reset lọc hãng
            if (cboTimKiemHang.Items.Count > 0)
                cboTimKiemHang.SelectedIndex = 0;

            // Load lại dữ liệu theo chi nhánh mới
            LoadData();
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
        private bool KiemTraGiaHopLe(out decimal giaNhap, out decimal giaBan)
        {
            giaNhap = 0;
            giaBan = 0;

            string giaNhapText = txtGiaNhap.Text.Trim().Replace(",", "");
            string giaBanText = txtGiaBan.Text.Trim().Replace(",", "");

            if (!decimal.TryParse(giaNhapText, out giaNhap))
            {
                MessageBox.Show(
                    "Giá nhập phải là số hợp lệ.",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtGiaNhap.Focus();
                return false;
            }

            if (!decimal.TryParse(giaBanText, out giaBan))
            {
                MessageBox.Show(
                    "Giá bán phải là số hợp lệ.",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtGiaBan.Focus();
                return false;
            }

            if (giaNhap < 0)
            {
                MessageBox.Show(
                    "Giá nhập không được nhỏ hơn 0.",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtGiaNhap.Focus();
                return false;
            }

            if (giaBan < 0)
            {
                MessageBox.Show(
                    "Giá bán không được nhỏ hơn 0.",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtGiaBan.Focus();
                return false;
            }

            if (giaBan <= giaNhap)
            {
                MessageBox.Show(
                    "Giá bán phải lớn hơn giá nhập.\n\n" +
                    "Ví dụ: Giá nhập 10,000 thì giá bán phải lớn hơn 10,000.",
                    "Giá bán không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtGiaBan.Focus();
                return false;
            }

            return true;
        }
    }
}