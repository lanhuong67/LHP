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
            // Nếu người đăng nhập KHÔNG PHẢI là Admin (tức là Staff/Nhân viên bình thường)
            if (_vaiTro != "Admin")
            {
                // ==========================================
                // 1. ẨN NHÓM TÍNH NĂNG KHO HÀNG CHUYÊN SÂU
                // ==========================================
                // Ẩn menu "Nhập hàng / lô"
                picNhapHang.Visible = false;
                lblNhapHang.Visible = false;

                // Ẩn menu "Cảnh báo tồn kho"
                lblCanhBaoTonKho.Visible = false;
                picCanhBaoTonKho.Visible = false;

                // ==========================================
                // 2. ẨN TOÀN BỘ NHÓM "DANH MỤC"
                // ==========================================
                // Ẩn menu "Nhân viên"
                lblNhanVien.Visible = false;
                picNhanVien.Visible = false;

                // Ẩn menu "Hãng sản xuất"
                lblHangSanXuat.Visible = false;
                picHangSanXuat.Visible = false;

                // Ẩn menu "Chi nhánh"
                lblChiNhanh.Visible = false;
                picChiNhanh.Visible = false;

                // (Tùy chọn) Ẩn luôn chữ tiêu đề "Danh mục" màu trắng nhạt trên menu
                lblTitleDanhMuc.Visible = false; 

                // ==========================================
                // 3. ẨN TOÀN BỘ NHÓM "BÁO CÁO"
                // ==========================================
                // Ẩn menu "Doanh thu"
                lblDoanhThu.Visible = false;
                picDoanhThu.Visible = false;

                // Ẩn menu "Top bán chạy"
                lblTopBanChay.Visible = false;
                picTopBanChay.Visible = false;

                // (Tùy chọn) Ẩn luôn chữ tiêu đề "Báo cáo" màu trắng nhạt trên menu
                lblTitleBaoCao.Visible = false; 
            }
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
        private void AddUserControl(UserControl uc)
        {
            // Đặt UserControl lấp đầy vùng chứa
            uc.Dock = DockStyle.Fill;

            // Xóa các UserControl hiện đang hiển thị trước đó
            pnlContainer.Controls.Clear();

            // Thêm UserControl mới vào và đẩy lên mặt trước
            pnlContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        private void picNhanVien_Click(object sender, EventArgs e)
        {
            // Gọi UC_NhanVien ra và đưa vào Panel chứa (pnlContainer)
            UC_NhanVien ucNhanVien = new UC_NhanVien();
            AddUserControl(ucNhanVien);
        }

        private void lblNhanVien_Click(object sender, EventArgs e)
        {
            picNhanVien_Click(sender, e);
        }

        // Sự kiện khi click vào Icon/Hình ảnh của nút Danh sách khách hàng
        private void picDanhSachKH_Click(object sender, EventArgs e)
        {
            // Gọi UC_KhachHang ra và đưa vào hàm AddUserControl bạn đã viết sẵn
            UC_KhachHang ucKhachHang = new UC_KhachHang();
            AddUserControl(ucKhachHang);
        }

        // Sự kiện khi click vào dòng chữ "Danh sách khách hàng"
        private void lblDanhSachKH_Click(object sender, EventArgs e)
        {
            // Tái sử dụng lại hàm click của hình ảnh cho đồng bộ
            picDanhSachKH_Click(sender, e);
        }

        private void picHangSanXuat_Click(object sender, EventArgs e)
        {
            UC_HangSanXuat ucHangSanXuat = new UC_HangSanXuat();
            AddUserControl(ucHangSanXuat);
        }

     
        private void lblHangSanXuat_Click(object sender, EventArgs e)
        {
            // Tái sử dụng lại hàm click của hình ảnh cho đồng bộ
            picHangSanXuat_Click(sender, e);
        }

        private void picSanPham_Click(object sender, EventArgs e)
        {
            UC_SanPham ucSanPham = new UC_SanPham();
            AddUserControl(ucSanPham);
        }


        private void lblSanPham_Click(object sender, EventArgs e)
        {
            // Tái sử dụng lại hàm click của hình ảnh cho đồng bộ
            picSanPham_Click(sender, e);
        }

        private void picNhapHang_Click(object sender, EventArgs e)
        {
            UC_NhapHangLo ucNhapHangLo = new UC_NhapHangLo();
            AddUserControl(ucNhapHangLo);
        }


        private void lblNhapHang_Click(object sender, EventArgs e)
        {
            // Tái sử dụng lại hàm click của hình ảnh cho đồng bộ
            picNhapHang_Click(sender, e);
        }
    }

 
}