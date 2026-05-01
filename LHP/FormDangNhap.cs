using System;
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

            // LỖI 1: Mật khẩu không ẩn -> Dùng thuộc tính này để hiện dấu chấm tròn bảo mật
            txtMatKhau.UseSystemPasswordChar = true;

            // LỖI 2: Vẫn hiện lblError -> Ẩn nó đi ngay khi vừa mở Form
            lblError.Visible = false;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // LỖI 3: Không ấn đăng nhập không xảy ra gì -> 
            // Bước 1: Kiểm tra xem ô nhập có bị trống không trước khi gọi xuống Database
            if (string.IsNullOrEmpty(txtTenDangNhap.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                lblError.Text = "Vui lòng nhập đầy đủ thông tin!";
                lblError.Visible = true;
                return;
            }

            NhanVienBUS bus = new NhanVienBUS();
            NhanVien tk = bus.Login(txtTenDangNhap.Text, txtMatKhau.Text);

            if (tk != null)
            {
                lblError.Visible = false;

                // Mở Form chính và truyền dữ liệu
                FormMain frm = new FormMain(tk.VaiTro, tk.TenDangNhap);
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                // Hiển thị lỗi nếu sai tài khoản/mật khẩu
                lblError.Text = "Tài khoản hoặc mật khẩu không đúng";
                lblError.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Để trống hoặc xóa nếu không dùng
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            // Lấy thông tin người dùng nhập
            string user = txtTenDangNhap.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            // Gọi lớp BUS để kiểm tra Database
            NhanVienBUS bus = new NhanVienBUS();
            NhanVien tk = bus.Login(user, pass);

            if (tk != null) // Đăng nhập thành công
            {
                lblError.Visible = false; // Ẩn lỗi
                

                // Truyền 2 tham số: Vai trò và Tên đăng nhập sang FormMain
                FormMain frm = new FormMain(tk.VaiTro, tk.TenDangNhap);
                this.Hide();
                frm.ShowDialog();
                this.Close(); // Đóng hẳn khi thoát FormMain
            }
            else // Đăng nhập thất bại (Sai user hoặc pass)
            {
                lblError.Text = "Tài khoản hoặc mật khẩu không đúng!";
                lblError.Visible = true; // Hiện dòng lỗi màu đỏ lên
            }
        }
    }
}