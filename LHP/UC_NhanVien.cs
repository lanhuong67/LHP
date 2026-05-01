using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BUS; // Khai báo để dùng lớp Nghiệp vụ
using DTO; // Khai báo để dùng lớp Dữ liệu NhanVien

namespace GUI
{
    public partial class UC_NhanVien : UserControl
    {
        // Khai báo công cụ giao tiếp với Database
        private NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        private bool isAdding = false; // Biến đánh dấu xem đang Thêm hay Sửa

        public UC_NhanVien()
        {
            InitializeComponent();
        }

        // ==========================================
        // SỰ KIỆN 1: KHI FORM VỪA MỞ LÊN
        // ==========================================
        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.AutoGenerateColumns = false; // Tắt tự động sinh cột
            LoadData(); // Gọi hàm load dữ liệu
        }

        // Hàm hỗ trợ Load dữ liệu lên Lưới (DataGridView)
        private void LoadData()
        {
            dgvNhanVien.DataSource = _nhanVienBUS.GetAllNhanVien();

            // Ẩn cột Mật khẩu đi để bảo mật
            if (dgvNhanVien.Columns["MatKhau"] != null)
            {
                dgvNhanVien.Columns["MatKhau"].Visible = false;
            }
        }

        // ==========================================
        // SỰ KIỆN 2: KHI CLICK VÀO 1 DÒNG TRÊN LƯỚI
        // ==========================================
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo click đúng vào dòng có dữ liệu (không click vào tiêu đề)
            if (e.RowIndex >= 0)
            {
                // "Tóm" lấy đối tượng NhanVien đang ẩn đằng sau dòng được click
                NhanVien nv = dgvNhanVien.Rows[e.RowIndex].DataBoundItem as NhanVien;

                // Nếu đối tượng tồn tại (không bị null)
                if (nv != null)
                {
                    // Đổ trực tiếp dữ liệu từ Object vào TextBox
                    txtMaNV.Text = nv.MaNV;
                    txtHoTen.Text = nv.HoTen;
                    txtSDT.Text = nv.SDT;
                    txtEmail.Text = nv.Email;
                    txtVaiTro.Text = nv.VaiTro;

                    // Lấy trực tiếp tên đăng nhập và mật khẩu từ Object, không cần quan tâm trên lưới có cột này hay không!
                    txtTaiKhoan.Text = nv.TenDangNhap;
                    txtMatKhau.Text = nv.MatKhau;

                    isAdding = false; // Chuyển về trạng thái xem/sửa
                    txtMaNV.ReadOnly = true; // Khóa Mã NV
                }
            }
        }

        // ==========================================
        // SỰ KIỆN 3: CÁC NÚT BẤM (THÊM, LƯU, LÀM TRỐNG)
        // ==========================================
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            isAdding = true; // Bật chế độ thêm mới

            // Xóa trắng các ô nhập
            txtMaNV.Clear(); txtHoTen.Clear(); txtSDT.Clear();
            txtEmail.Clear(); txtVaiTro.Clear(); txtTaiKhoan.Clear(); txtMatKhau.Clear();

            txtMaNV.ReadOnly = false; // Mở khóa cho phép nhập Mã NV
            txtMaNV.Focus(); // Đưa con trỏ nhấp nháy vào ô Mã NV
        }

        private void btnLamTrong_Click(object sender, EventArgs e)
        {
            // Chỉ xóa trắng form, không bật chế độ thêm
            txtMaNV.Clear(); txtHoTen.Clear(); txtSDT.Clear();
            txtEmail.Clear(); txtVaiTro.Clear(); txtTaiKhoan.Clear(); txtMatKhau.Clear();
            txtMaNV.ReadOnly = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Bắt lỗi: Không cho bỏ trống các trường quan trọng
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã NV, Họ tên và Tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isAdding) // Nếu đang ở chế độ Thêm mới
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
                    LoadData(); // Load lại lưới để thấy nhân viên mới
                    isAdding = false;
                }
                else
                {
                    MessageBox.Show("Mã nhân viên hoặc Tài khoản đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // SỰ KIỆN 4: TÌM KIẾM
        // ==========================================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            // Nếu để trống thì load lại toàn bộ
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                return;
            }

            var ds = _nhanVienBUS.GetAllNhanVien();

            // Cập nhật: Thêm điều kiện tìm kiếm theo MaNV
            dgvNhanVien.DataSource = ds.Where(nv =>
                (nv.MaNV != null && nv.MaNV.ToLower().Contains(keyword)) || // Tìm theo Mã NV
                (nv.HoTen != null && nv.HoTen.ToLower().Contains(keyword)) || // Tìm theo Tên
                (nv.SDT != null && nv.SDT.Contains(keyword)) // Tìm theo SĐT
            ).ToList();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn nhân viên nào trên lưới chưa
            // Nếu ô txtMaNV đang trống nghĩa là chưa chọn
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn một nhân viên từ danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Gom dữ liệu mới từ các TextBox vào đối tượng DTO
            NhanVien nvCapNhat = new NhanVien
            {
                MaNV = txtMaNV.Text.Trim(), // Lấy MaNV cũ để làm mỏ neo tìm kiếm
                HoTen = txtHoTen.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                VaiTro = txtVaiTro.Text.Trim(),
                TenDangNhap = txtTaiKhoan.Text.Trim(),
                MatKhau = txtMatKhau.Text.Trim()
            };

            // 3. Hiển thị thông báo xác nhận trước khi sửa (Tránh bấm nhầm)
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn cập nhật thông tin cho nhân viên [{nvCapNhat.HoTen}] không?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // Gọi BUS thực hiện cập nhật
                if (_nhanVienBUS.SuaNhanVien(nvCapNhat))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Load lại lưới để thấy sự thay đổi ngay lập tức

                    // Xóa rỗng form và mở khóa để sẵn sàng thao tác khác
                    btnLamTrong_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}