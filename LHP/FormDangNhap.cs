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

            lblError.Visible = false;
            SetPlaceholder();

            txtTenDangNhap.KeyDown += Txt_KeyDown;
            txtMatKhau.KeyDown += Txt_KeyDown;
        }

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
                txtMatKhau.UseSystemPasswordChar = false;
            }
        }

        private void txtTenDangNhap_Enter(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "Nhập tên đăng nhập...")
            {
                txtTenDangNhap.Text = "";
                txtTenDangNhap.ForeColor = Color.Black;
            }
        }

        private void txtTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                txtTenDangNhap.Text = "Nhập tên đăng nhập...";
                txtTenDangNhap.ForeColor = Color.Gray;
            }
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Nhập mật khẩu...")
            {
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = Color.Black;
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                txtMatKhau.Text = "Nhập mật khẩu...";
                txtMatKhau.ForeColor = Color.Gray;
                txtMatKhau.UseSystemPasswordChar = false;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(user) || user == "Nhập tên đăng nhập..." ||
                string.IsNullOrEmpty(pass) || pass == "Nhập mật khẩu...")
            {
                lblError.Text = "Vui lòng nhập đầy đủ thông tin!";
                lblError.Visible = true;
                return;
            }

            NhanVienBUS bus = new NhanVienBUS();
            NhanVien? tk = bus.Login(user, pass);

            if (tk == null)
            {
                lblError.Text = "Tài khoản hoặc mật khẩu không đúng!";
                lblError.Visible = true;
                return;
            }

            string vaiTro = tk.VaiTro?.Trim() ?? "";
            string maChiNhanhNhanVien = tk.MaChiNhanh?.Trim() ?? "";

            if (vaiTro != "Admin")
            {
                if (string.IsNullOrWhiteSpace(maChiNhanhNhanVien))
                {
                    lblError.Text = "Tài khoản nhân viên chưa được phân công chi nhánh!";
                    lblError.Visible = true;
                    return;
                }

                ChiNhanhBUS chiNhanhBUS = new ChiNhanhBUS();

                if (!chiNhanhBUS.ChiNhanhDangHoatDong(maChiNhanhNhanVien))
                {
                    lblError.Text = "Chi nhánh làm việc của tài khoản này đã ngừng hoạt động!";
                    lblError.Visible = true;
                    return;
                }
            }

            UserSession.MaNV = tk.MaNV;
            UserSession.HoTen = tk.HoTen;
            UserSession.VaiTro = tk.VaiTro;
            UserSession.MaChiNhanh = maChiNhanhNhanVien;

            if (vaiTro == "Admin")
            {
                UserSession.ChiNhanhDuocChon = maChiNhanhNhanVien;
            }
            else
            {
                UserSession.ChiNhanhDuocChon = maChiNhanhNhanVien;
            }

            lblError.Visible = false;

            FormMain frm = new FormMain();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnDangNhap_Click(sender, e);
            }
        }
    }
}