using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_HangSanXuat : UserControl
    {
        private HangSanXuatBUS _bus = new HangSanXuatBUS();
        private bool isAdding = false;

        public UC_HangSanXuat()
        {
            InitializeComponent();
        }

        private void UC_HangSanXuat_Load(object sender, EventArgs e)
        {
            dgvHangSanXuat.AutoGenerateColumns = false;

            if (cboTrangThai.Items.Count == 0)
            {
                cboTrangThai.Items.Add("Đang hợp tác");
                cboTrangThai.Items.Add("Ngừng hợp tác");
                cboTrangThai.SelectedIndex = 0;
            }

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvHangSanXuat.DataSource = null;
                dgvHangSanXuat.DataSource = _bus.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHangSanXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                HangSanXuat hsx = dgvHangSanXuat.Rows[e.RowIndex].DataBoundItem as HangSanXuat;
                if (hsx != null)
                {
                    txtMaHang.Text = hsx.MaHang;
                    txtTenHang.Text = hsx.TenHang;
                    txtQuocGia.Text = hsx.QuocGia;
                    txtMoTa.Text = hsx.MoTa;
                    cboTrangThai.SelectedItem = hsx.TrangThai;

                    isAdding = false;
                    txtMaHang.ReadOnly = true; // Chuyển sang xem/sửa, khóa ô Mã
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            btnLamTrong_Click(sender, e);
            txtMaHang.ReadOnly = false;
            txtMaHang.Focus();
        }

        private void btnLamTrong_Click(object sender, EventArgs e)
        {
            txtMaHang.Clear();
            txtTenHang.Clear();
            txtQuocGia.Clear();
            txtMoTa.Clear();
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
            txtMaHang.ReadOnly = false; // Mở khóa ô Mã để nhập mới
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // CẢI TIẾN: Tự động nhận diện Thêm mới
            if (!isAdding && txtMaHang.ReadOnly == false && !string.IsNullOrWhiteSpace(txtMaHang.Text))
            {
                isAdding = true;
            }

            if (string.IsNullOrWhiteSpace(txtMaHang.Text) || string.IsNullOrWhiteSpace(txtTenHang.Text))
            {
                MessageBox.Show("Mã hãng và Tên hãng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HangSanXuat hsx = new HangSanXuat
            {
                MaHang = txtMaHang.Text.Trim(),
                TenHang = txtTenHang.Text.Trim(),
                QuocGia = txtQuocGia.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang hợp tác"
            };

            if (isAdding)
            {
                try
                {
                    if (_bus.Them(hsx))
                    {
                        MessageBox.Show("Thêm Hãng sản xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        isAdding = false;
                        txtMaHang.ReadOnly = true; // Thêm xong thì khóa lại
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm! Có thể mã hãng đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Hứng lỗi do tầng DAL ném lên (Lỗi chuỗi kết nối, trùng khóa chính...)
                    MessageBox.Show(ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Giao diện đang ở chế độ xem. Vui lòng nhấn nút [Sửa] để cập nhật dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHang.Text))
            {
                MessageBox.Show("Vui lòng chọn một Hãng từ danh sách để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HangSanXuat hsxCapNhat = new HangSanXuat
            {
                MaHang = txtMaHang.Text.Trim(),
                TenHang = txtTenHang.Text.Trim(),
                QuocGia = txtQuocGia.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang hợp tác"
            };

            if (MessageBox.Show($"Bạn có chắc chắn muốn cập nhật thông tin hãng [{hsxCapNhat.TenHang}] không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (_bus.Sua(hsxCapNhat))
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        btnLamTrong_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại! Không tìm thấy mã hãng cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHang.Text)) return;

            string maXoa = txtMaHang.Text.Trim();
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa Hãng sản xuất này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (_bus.Xoa(maXoa))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        btnLamTrong_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa! Có thể hãng này đang có sản phẩm trong hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                return;
            }

            try
            {
                var ds = _bus.GetAll();
                dgvHangSanXuat.DataSource = ds.Where(h =>
                    (h.MaHang != null && h.MaHang.ToLower().Contains(keyword)) ||
                    (h.TenHang != null && h.TenHang.ToLower().Contains(keyword))
                ).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
            btnLamTrong_Click(sender, e);
        }
    }
}