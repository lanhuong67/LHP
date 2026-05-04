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
                dsHangTimKiem.AddRange(dsHang); // Nối danh sách hãng thật vào sau

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
                    cboTrangThai.SelectedItem = sp.TrangThai;

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
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang kinh doanh"
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

            SanPham spCapNhat = new SanPham
            {
                MaSP = txtMaSP.Text.Trim(),
                TenSP = txtTenSP.Text.Trim(),
                MaHang = cboHangSanXuat.SelectedValue?.ToString() ?? "",
                GiaNhap = giaNhap,
                GiaBan = giaBan,
                CauHinh = txtCauHinh.Text.Trim(),
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang kinh doanh"
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            string maHangLoc = cboTimKiemHang.SelectedValue?.ToString() ?? "";

            try
            {
                var ds = _bus.GetAll();

                // Lọc theo từ khóa (Mã hoặc Tên)
                if (!string.IsNullOrEmpty(keyword))
                {
                    ds = ds.Where(s =>
                        (s.TenSP != null && s.TenSP.ToLower().Contains(keyword)) ||
                        (s.MaSP != null && s.MaSP.ToLower().Contains(keyword))
                    ).ToList();
                }

                // Lọc theo Hãng Sản Xuất (nếu người dùng không chọn "--Tất cả hãng--")
                if (!string.IsNullOrEmpty(maHangLoc))
                {
                    ds = ds.Where(s => s.MaHang == maHangLoc).ToList();
                }

                dgvSanPham.DataSource = ds;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            if (cboTimKiemHang.Items.Count > 0) cboTimKiemHang.SelectedIndex = 0;
            LoadData();
            btnLamTrong_Click(sender, e);
        }

        // Sự kiện cho nút Nhập kho (Tương lai bạn sẽ code gọi form Nhập lô ở đây)
        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn một Sản phẩm để nhập hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show($"Chức năng sẽ điều hướng sang Form Nhập hàng lô cho mã: {txtMaSP.Text}", "Đang phát triển", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}