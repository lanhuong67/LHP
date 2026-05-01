using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_KhachHang : UserControl
    {
        private KhachHangBUS _bus = new KhachHangBUS();
        private bool isAdding = false;

        public UC_KhachHang()
        {
            InitializeComponent();
        }

        // ==========================================
        // 1. LOAD DỮ LIỆU KHI MỞ FORM
        // ==========================================
        private void UC_KhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.AutoGenerateColumns = false;
            LoadData();
        }

        private void LoadData()
        {
            dgvKhachHang.DataSource = _bus.GetAll();
        }

        // ==========================================
        // 2. CLICK VÀO LƯỚI (DATAGRIDVIEW)
        // ==========================================
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                KhachHang kh = dgvKhachHang.Rows[e.RowIndex].DataBoundItem as KhachHang;
                if (kh != null)
                {
                    txtMaKH.Text = kh.MaKH;
                    txtHoTen.Text = kh.HoTen;
                    txtSDT.Text = kh.SDT;
                    txtDiaChi.Text = kh.DiaChi;

                    // Lịch sử mua hàng hiển thị lên Label
                    lblSoLanMua.Text = kh.SoLanMua.ToString();
                    lblTongChiTieu.Text = kh.TongChiTieu.ToString("N0") + " VNĐ";

                    isAdding = false;
                    txtMaKH.ReadOnly = true; // Khóa Mã KH để không bị sửa nhầm khóa chính
                }
            }
        }

        // ==========================================
        // 3. CÁC NÚT BẤM (BUTTONS) - NGHIỆP VỤ
        // ==========================================
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            isAdding = true; // Bật cờ thêm mới
            btnLamTrong_Click(sender, e); // Gọi hàm làm trống form
            txtMaKH.ReadOnly = false; // Mở khóa cho phép nhập mã
            txtMaKH.Focus();
        }

        private void btnLamTrong_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();

            lblSoLanMua.Text = "0";
            lblTongChiTieu.Text = "0 VNĐ";

            txtMaKH.ReadOnly = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Bắt lỗi rỗng
            if (string.IsNullOrWhiteSpace(txtMaKH.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Mã KH và Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHang kh = new KhachHang
            {
                MaKH = txtMaKH.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim()
            };

            if (isAdding) // Nhánh Thêm
            {
                if (_bus.Them(kh))
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    isAdding = false;
                }
                else MessageBox.Show("Lỗi! Mã khách hàng này đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // Nhánh ấn Lưu khi đang ở chế độ Xem (Không cho phép)
            {
                MessageBox.Show("Vui lòng sử dụng nút [Sửa] để cập nhật thông tin khách hàng hiện tại!", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng từ danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHang khCapNhat = new KhachHang
            {
                MaKH = txtMaKH.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim()
            };

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn cập nhật thông tin cho khách hàng [{khCapNhat.HoTen}] không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (_bus.Sua(khCapNhat))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btnLamTrong_Click(sender, e);
                }
                else MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng từ danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKH = txtMaKH.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            DialogResult result = MessageBox.Show($"Bạn có thực sự muốn xóa khách hàng [{hoTen}] không?\nDữ liệu đã xóa sẽ không thể khôi phục!", "Cảnh báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (_bus.Xoa(maKH))
                {
                    MessageBox.Show("Đã xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    btnLamTrong_Click(sender, e);
                }
                else MessageBox.Show("Xóa thất bại! Khách hàng này có thể đã phát sinh giao dịch trong hệ thống.", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // 4. CÁC NÚT BẤM (BUTTONS) - TÌM KIẾM
        // ==========================================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword)) { LoadData(); return; }

            var ds = _bus.GetAll();
            dgvKhachHang.DataSource = ds.Where(k =>
                (k.MaKH != null && k.MaKH.ToLower().Contains(keyword)) ||
                (k.HoTen != null && k.HoTen.ToLower().Contains(keyword)) ||
                (k.SDT != null && k.SDT.Contains(keyword))).ToList();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
        }
    }
}