using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormMain : Form
    {
        private string _vaiTro;
        private string _tenHienThi;

        // Hàm khởi tạo nhận 2 tham số: Vai trò và Tên để hiển thị
        public FormMain(string vaiTro, string ten)
        {
            InitializeComponent();
            this._vaiTro = vaiTro;
            this._tenHienThi = ten;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // 1. Cập nhật dòng chữ "Xin chào, [tên]" ở góc phải
            lblTenNV.Text = $"Xin chào, {_tenHienThi}";

            // 2. Thực hiện phân quyền
            PhanQuyenHeThong();
        }

        private void PhanQuyenHeThong()
        {
            if (_vaiTro == "Staff")
            {
                // Giả sử Staff không được xem các mục Quản lý (nếu bạn có sau này)
                // Hiện tại Staff có thể thấy Dashboard và Bán hàng
                // Nếu bạn có thêm mục "Cấu hình" hay "Nhân viên", hãy ẩn ở đây:
                // lblNhanVien.Visible = false;
                // picNhanVien.Visible = false;
            }
            // Admin mặc định thấy hết nên không cần xử lý thêm
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // 1. Hiển thị hộp thoại xác nhận để tránh người dùng bấm nhầm
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất và quay lại màn hình đăng nhập không?",
                                                  "Xác nhận đăng xuất",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 2. Ẩn Form hiện tại (FormMain)
                this.Hide();

                // 3. Khởi tạo lại Form Đăng nhập
                FormDangNhap frmLogin = new FormDangNhap();

                // 4. Hiển thị Form Đăng nhập dưới dạng Dialog
                frmLogin.ShowDialog();

                // 5. Sau khi Form Đăng nhập đóng lại (nếu có), ta mới đóng hẳn FormMain
                this.Close();
            }
        }
    }
}