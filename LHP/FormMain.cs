using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblTenNV.Text = $"Xin chào, {UserSession.HoTen}";

            // 1. Nạp danh sách chi nhánh và cấu hình ComboBox
            LoadGlobalChiNhanh();

            // 2. Thực hiện phân quyền
            PhanQuyenHeThong();
        }


        // 1. NẠP CHI NHÁNH VÀ CẤU HÌNH COMBOBOX
        // ==========================================
        private void LoadGlobalChiNhanh()
        {
            try
            {
                ComboBox cboGlobal = this.Controls.Find("cboGlobalChiNhanh", true).FirstOrDefault() as ComboBox;
                if (cboGlobal != null)
                {
                    cboGlobal.DropDownStyle = ComboBoxStyle.DropDownList;

                    ChiNhanhBUS cnBus = new ChiNhanhBUS();
                    var dsCN = cnBus.GetAll();

                    // 🔴 ĐIỂM SỬA QUAN TRỌNG: Phải khai báo ValueMember TRƯỚC DataSource
                    // Để tránh việc WinForms lấy nhầm cục Object
                    cboGlobal.DisplayMember = "TenChiNhanh";
                    cboGlobal.ValueMember = "MaChiNhanh";
                    cboGlobal.DataSource = dsCN;

                    cboGlobal.SelectedIndexChanged -= CboGlobalChiNhanh_SelectedIndexChanged;
                    cboGlobal.SelectedIndexChanged += CboGlobalChiNhanh_SelectedIndexChanged;

                    if (!string.IsNullOrEmpty(UserSession.MaChiNhanh))
                    {
                        cboGlobal.SelectedValue = UserSession.MaChiNhanh;
                        UserSession.ChiNhanhDuocChon = UserSession.MaChiNhanh;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục Chi nhánh tổng: " + ex.Message);
            }
        }

        // 2. SỰ KIỆN KHI ĐỔI CHI NHÁNH
        private void CboGlobalChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;

            if (cbo == null || cbo.SelectedValue == null)
                return;

            // Lấy đúng mã chi nhánh
            if (cbo.SelectedValue is ChiNhanh cn)
            {
                UserSession.ChiNhanhDuocChon = cn.MaChiNhanh;
            }
            else
            {
                UserSession.ChiNhanhDuocChon = cbo.SelectedValue.ToString();
            }

            // Sau khi đổi chi nhánh, reload UC đang mở
            ReloadCurrentUserControlByBranch();
        }

        private void ReloadCurrentUserControlByBranch()
        {
            if (pnlContainer.Controls.Count == 0)
                return;

            UserControl currentUC = pnlContainer.Controls[0] as UserControl;

            if (currentUC is IBranchRefreshable branchUC)
            {
                branchUC.RefreshByBranch();
            }
        }

        // 3. PHÂN QUYỀN HỆ THỐNG
        private void PhanQuyenHeThong()
        {
            ComboBox cboGlobal = this.Controls.Find("cboGlobalChiNhanh", true).FirstOrDefault() as ComboBox;

            if (UserSession.VaiTro != "Admin")
            {
                // Khóa ComboBox lại cho Staff, không cho đổi chi nhánh khác
                if (cboGlobal != null) cboGlobal.Enabled = false;

                // Ẩn menu quản lý (Giữ nguyên logic của bạn)
                picNhapHang.Visible = false; lblNhapHang.Visible = false;
                lblCanhBaoTonKho.Visible = false; picCanhBaoTonKho.Visible = false;
                lblNhanVien.Visible = false; picNhanVien.Visible = false;
                lblHangSanXuat.Visible = false; picHangSanXuat.Visible = false;
                lblChiNhanh.Visible = false; picChiNhanh.Visible = false;
                lblTitleDanhMuc.Visible = false;
                lblDoanhThu.Visible = false; picDoanhThu.Visible = false;
                lblTopBanChay.Visible = false; picTopBanChay.Visible = false;
                lblTitleBaoCao.Visible = false;
            }
            else
            {
                // Admin thì được mở khóa
                if (cboGlobal != null) cboGlobal.Enabled = true;
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UserSession.MaNV = "";
                UserSession.HoTen = "";
                UserSession.VaiTro = "";
                UserSession.MaChiNhanh = "";
                UserSession.ChiNhanhDuocChon = "";

                this.Hide();
                new FormDangNhap().ShowDialog();
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
        public void MoNhapHangTheoSanPham(string maSP)
        {
            UC_NhapHangLo ucNhapHangLo = new UC_NhapHangLo();

            AddUserControl(ucNhapHangLo);

            ucNhapHangLo.ChonSanPhamCanNhap(maSP);
        }


        // ================================================================
        // CÁC SỰ KIỆN CLICK MENU (Giữ nguyên)
        // ================================================================
        private void picNhanVien_Click(object sender, EventArgs e) { AddUserControl(new UC_NhanVien()); }
        private void lblNhanVien_Click(object sender, EventArgs e) { picNhanVien_Click(sender, e); }
        private void picDashBoard_Click(object sender, EventArgs e) { AddUserControl(new UC_Dashboard()); }
        private void lblDashBoard_Click(object sender, EventArgs e) { picDashBoard_Click(sender, e); }
        private void picSanPham_Click(object sender, EventArgs e) { AddUserControl(new UC_SanPham()); }
        private void lblSanPham_Click(object sender, EventArgs e) { picSanPham_Click(sender, e); }
        private void picNhapHang_Click(object sender, EventArgs e) { AddUserControl(new UC_NhapHangLo()); }
        private void lblNhapHang_Click(object sender, EventArgs e) { picNhapHang_Click(sender, e); }
        private void picTaoHoaDon_Click(object sender, EventArgs e) { AddUserControl(new UC_TaoHoaDon()); }
        private void lblTaoHoaDon_Click(object sender, EventArgs e) { picTaoHoaDon_Click(sender, e); }
        private void picDanhSachHD_Click(object sender, EventArgs e) { AddUserControl(new UC_DanhSachHoaDon()); }
        private void lblDanhSachHD_Click(object sender, EventArgs e) { picDanhSachHD_Click(sender, e); }
        private void picBaoHanh_Click(object sender, EventArgs e) { AddUserControl(new UC_BaoHanh()); }
        private void lblBaoHanh_Click(object sender, EventArgs e) { picBaoHanh_Click(sender, e); }
        private void picCanhBaoKho_Click(object sender, EventArgs e) { AddUserControl(new UC_CanhBaoKho()); }
        private void lblCanhBaoKho_Click(object sender, EventArgs e) { picCanhBaoKho_Click(sender, e); }
        private void picChiNhanh_Click(object sender, EventArgs e) { AddUserControl(new UC_ChiNhanh()); }
        private void lblChiNhanh_Click(object sender, EventArgs e) { picChiNhanh_Click(sender, e); }
        private void picChamSocKhachHang_Click(object sender, EventArgs e) { AddUserControl(new UC_ChamSocKH()); }
        private void lblChamSocKhachHang_Click(object sender, EventArgs e) { picChamSocKhachHang_Click(sender, e); }
        private void picDoanhThu_Click(object sender, EventArgs e) { AddUserControl(new UC_DoanhThu()); }
        private void lblDoanhThu_Click(object sender, EventArgs e) { picDoanhThu_Click(sender, e); }
        private void picTopBanChay_Click(object sender, EventArgs e) { AddUserControl(new UC_TopBanChay()); }
        private void lblTopBanChay_Click(object sender, EventArgs e) { picTopBanChay_Click(sender, e); }
        private void picDanhSachKH_Click(object sender, EventArgs e) { AddUserControl(new UC_KhachHang()); }
        private void lblDanhSachKH_Click(object sender, EventArgs e) { picDanhSachKH_Click(sender, e); }
        private void picHangSanXuat_Click(object sender, EventArgs e) { AddUserControl(new UC_HangSanXuat()); }
        private void lblHangSanXuat_Click(object sender, EventArgs e) { picHangSanXuat_Click(sender, e); }
    }
}