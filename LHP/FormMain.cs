using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Thêm thư viện DTO để gọi UserSession
using DTO;

namespace GUI
{
    public partial class FormMain : Form
    {
        // 🔴 ĐIỂM SỬA 1: Không cần truyền tham số vào hàm khởi tạo nữa
        // Vì mọi thông tin (Vai trò, Tên) đều được lấy từ túi "UserSession"
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // 🔴 ĐIỂM SỬA 2: Lấy Tên hiển thị từ Session
            lblTenNV.Text = $"Xin chào, {UserSession.HoTen}";

            // Thực hiện phân quyền
            PhanQuyenHeThong();
        }

        private void PhanQuyenHeThong()
        {
            // 🔴 ĐIỂM SỬA 3: Kiểm tra Vai trò từ Session
            if (UserSession.ChucVu != "Admin")
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
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất và quay lại màn hình đăng nhập không?",
                                                  "Xác nhận đăng xuất",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 🔴 ĐIỂM SỬA 4: Xóa sạch Session khi đăng xuất để bảo mật
                UserSession.MaNV = "";
                UserSession.HoTen = "";
                UserSession.ChucVu = "";

                this.Hide();
                FormDangNhap frmLogin = new FormDangNhap();
                frmLogin.ShowDialog();
                this.Close();
            }
        }

        private void AddUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        // ================================================================
        // TẤT CẢ CÁC SỰ KIỆN CLICK MENU CỦA BẠN ĐƯỢC GIỮ NGUYÊN BÊN DƯỚI
        // ================================================================
        private void picNhanVien_Click(object sender, EventArgs e)
        {
            UC_NhanVien ucNhanVien = new UC_NhanVien();
            AddUserControl(ucNhanVien);
        }

        private void lblNhanVien_Click(object sender, EventArgs e)
        {
            picNhanVien_Click(sender, e);
        }

        private void picDanhSachKH_Click(object sender, EventArgs e)
        {
            UC_KhachHang ucKhachHang = new UC_KhachHang();
            AddUserControl(ucKhachHang);
        }

        private void lblDanhSachKH_Click(object sender, EventArgs e)
        {
            picDanhSachKH_Click(sender, e);
        }

        private void picHangSanXuat_Click(object sender, EventArgs e)
        {
            UC_HangSanXuat ucHangSanXuat = new UC_HangSanXuat();
            AddUserControl(ucHangSanXuat);
        }

        private void lblHangSanXuat_Click(object sender, EventArgs e)
        {
            picHangSanXuat_Click(sender, e);
        }

        private void picSanPham_Click(object sender, EventArgs e)
        {
            UC_SanPham ucSanPham = new UC_SanPham();
            AddUserControl(ucSanPham);
        }

        private void lblSanPham_Click(object sender, EventArgs e)
        {
            picSanPham_Click(sender, e);
        }

        private void picNhapHang_Click(object sender, EventArgs e)
        {
            UC_NhapHangLo ucNhapHangLo = new UC_NhapHangLo();
            AddUserControl(ucNhapHangLo);
        }

        private void lblNhapHang_Click(object sender, EventArgs e)
        {
            picNhapHang_Click(sender, e);
        }

        private void picTaoHoaDon_Click(object sender, EventArgs e)
        {
            UC_TaoHoaDon ucTaoHoaDon = new UC_TaoHoaDon();
            AddUserControl(ucTaoHoaDon);
        }

        private void lblTaoHoaDon_Click(object sender, EventArgs e)
        {
            picTaoHoaDon_Click(sender, e);
        }

        private void picDanhSachHD_Click(object sender, EventArgs e)
        {
            UC_DanhSachHoaDon ucDanhSachHoaDon = new UC_DanhSachHoaDon();
            AddUserControl(ucDanhSachHoaDon);
        }

        private void lblDanhSachHD_Click(object sender, EventArgs e)
        {
            picDanhSachHD_Click(sender, e);
        }
    }
}