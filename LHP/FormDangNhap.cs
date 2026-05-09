using System;
using System.Drawing;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();

            // Khởi tạo trạng thái ban đầu
            lblError.Visible = false;
            SetPlaceholder();

            // Kích hoạt tính năng hiện đại: Bấm Enter để đăng nhập
            txtTenDangNhap.KeyDown += Txt_KeyDown;
            txtMatKhau.KeyDown += Txt_KeyDown;
        }

        // ==========================================
        // 1. HIỆU ỨNG CHỮ MỜ (PLACEHOLDER)
        // ==========================================
        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                txtTenDangNhap.Text = "Nhập tên đăng nhập...";
                txtTenDangNhap.ForeColor = Color.Gray;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                txtMatKhau.Text = "Nhập mật khẩu...";
                txtMatKhau.ForeColor = Color.Gray;
                // Khi đang hiện chữ mờ thì TẮT dấu chấm tròn để đọc được chữ
                txtMatKhau.UseSystemPasswordChar = false;
            }
        }

        // Khi trỏ chuột VÀO ô Tài khoản
        private void txtTenDangNhap_Enter(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "Nhập tên đăng nhập...")
            {
                txtTenDangNhap.Text = "";
                txtTenDangNhap.ForeColor = Color.Black;
            }
        }

        // Khi trỏ chuột RA KHỎI ô Tài khoản
        private void txtTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                txtTenDangNhap.Text = "Nhập tên đăng nhập...";
                txtTenDangNhap.ForeColor = Color.Gray;
            }
        }

        // Khi trỏ chuột VÀO ô Mật khẩu
        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Nhập mật khẩu...")
            {
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = Color.Black;
                // Bắt đầu gõ thì BẬT dấu chấm tròn bảo mật lên
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        // Khi trỏ chuột RA KHỎI ô Mật khẩu
        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                txtMatKhau.Text = "Nhập mật khẩu...";
                txtMatKhau.ForeColor = Color.Gray;
                // Không có text thì tắt dấu chấm để hiện chữ mờ
                txtMatKhau.UseSystemPasswordChar = false;
            }
        }

        // ==========================================
        // 2. XỬ LÝ ĐĂNG NHẬP
        // ==========================================
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            // Kiểm tra xem người dùng có lười chưa gõ gì mà để nguyên chữ mờ rồi bấm Đăng nhập không
            if (string.IsNullOrEmpty(user) || user == "Nhập tên đăng nhập..." ||
                string.IsNullOrEmpty(pass) || pass == "Nhập mật khẩu...")
            {
                lblError.Text = "Vui lòng nhập đầy đủ thông tin!";
                lblError.Visible = true;
                return;
            }

            NhanVienBUS bus = new NhanVienBUS();
            NhanVien tk = bus.Login(user, pass);

            if (tk != null)
            {
                lblError.Visible = false;
                FormMain frm = new FormMain(tk.VaiTro, tk.TenDangNhap);
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                lblError.Text = "Tài khoản hoặc mật khẩu không đúng!";
                lblError.Visible = true;
            }
        }

        // ==========================================
        // 3. TÍNH NĂNG BẤM ENTER TỰ ĐĂNG NHẬP
        // ==========================================
        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Ngăn chặn tiếng bíp (ding) mặc định của Windows
                e.SuppressKeyPress = true;
                // Gọi thẳng hàm click nút đăng nhập
                btnDangNhap_Click(sender, e);
            }
        }
    }
}