using System;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class FormMain : Form
    {
        private bool dangNapChiNhanh = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblTenNV.Text = $"Xin chào, {UserSession.HoTen}";

            LoadGlobalChiNhanh();
            PhanQuyenHeThong();
        }

        private ComboBox LayComboChiNhanhToanCuc()
        {
            return this.Controls.Find("cboGlobalChiNhanh", true)
                .FirstOrDefault() as ComboBox;
        }

        private void SetVisibleControl(string tenControl, bool hienThi)
        {
            Control[] dsControl = this.Controls.Find(tenControl, true);

            foreach (Control control in dsControl)
            {
                control.Visible = hienThi;
            }
        }

        private void CboGlobalChiNhanh_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is ChiNhanh cn)
            {
                e.Value = cn.TenChiNhanh;
            }
        }

        private string LayMaChiNhanhDangChonTuComboBox(ComboBox cbo)
        {
            if (cbo == null)
                return "";

            if (cbo.SelectedValue is ChiNhanh cnValue)
                return cnValue.MaChiNhanh;

            if (cbo.SelectedItem is ChiNhanh cnItem)
                return cnItem.MaChiNhanh;

            if (cbo.SelectedValue != null)
                return cbo.SelectedValue.ToString() ?? "";

            return "";
        }

        private void LoadGlobalChiNhanh()
        {
            ComboBox cboGlobal = null;

            try
            {
                dangNapChiNhanh = true;

                cboGlobal = LayComboChiNhanhToanCuc();

                if (cboGlobal == null)
                    return;

                cboGlobal.SelectedIndexChanged -= CboGlobalChiNhanh_SelectedIndexChanged;
                cboGlobal.Format -= CboGlobalChiNhanh_Format;

                cboGlobal.DataSource = null;
                cboGlobal.Text = "";

                cboGlobal.DropDownStyle = ComboBoxStyle.DropDownList;
                cboGlobal.FormattingEnabled = true;

                cboGlobal.DisplayMember = "TenChiNhanh";
                cboGlobal.ValueMember = "MaChiNhanh";

                cboGlobal.Format += CboGlobalChiNhanh_Format;

                ChiNhanhBUS cnBus = new ChiNhanhBUS();

                var dsCNHoatDong = cnBus.GetChiNhanhDangHoatDong()
                    .OrderBy(cn => cn.TenChiNhanh)
                    .ToList();

                if (dsCNHoatDong.Count == 0)
                {
                    UserSession.ChiNhanhDuocChon = "";

                    cboGlobal.DataSource = null;
                    cboGlobal.SelectedIndex = -1;
                    cboGlobal.Enabled = false;

                    MessageBox.Show(
                        "Hiện không có chi nhánh nào đang hoạt động.\n" +
                        "Bạn cần vào Quản lý chi nhánh để kích hoạt chi nhánh trước khi thao tác nghiệp vụ.",
                        "Không có chi nhánh hoạt động",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                cboGlobal.DataSource = dsCNHoatDong;

                if (UserSession.VaiTro != "Admin")
                {
                    string maChiNhanhNhanVien = UserSession.MaChiNhanh?.Trim() ?? "";

                    bool chiNhanhCuaStaffConHoatDong = dsCNHoatDong.Any(x =>
                        (x.MaChiNhanh ?? "").Trim()
                        .Equals(maChiNhanhNhanVien, StringComparison.OrdinalIgnoreCase));

                    if (!chiNhanhCuaStaffConHoatDong)
                    {
                        UserSession.ChiNhanhDuocChon = "";

                        cboGlobal.SelectedIndex = -1;
                        cboGlobal.Enabled = false;

                        MessageBox.Show(
                            "Chi nhánh làm việc của tài khoản này đã ngừng hoạt động.\n" +
                            "Bạn không thể thao tác nghiệp vụ. Vui lòng liên hệ Admin.",
                            "Chi nhánh đã ngừng hoạt động",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    cboGlobal.SelectedValue = maChiNhanhNhanVien;
                    UserSession.MaChiNhanh = maChiNhanhNhanVien;
                    UserSession.ChiNhanhDuocChon = maChiNhanhNhanVien;
                    cboGlobal.Enabled = false;
                }
                else
                {
                    cboGlobal.Enabled = true;

                    if (!string.IsNullOrWhiteSpace(UserSession.ChiNhanhDuocChon) &&
                        dsCNHoatDong.Any(x => x.MaChiNhanh == UserSession.ChiNhanhDuocChon))
                    {
                        cboGlobal.SelectedValue = UserSession.ChiNhanhDuocChon;
                    }
                    else if (!string.IsNullOrWhiteSpace(UserSession.MaChiNhanh) &&
                             dsCNHoatDong.Any(x => x.MaChiNhanh == UserSession.MaChiNhanh))
                    {
                        cboGlobal.SelectedValue = UserSession.MaChiNhanh;
                        UserSession.ChiNhanhDuocChon = UserSession.MaChiNhanh;
                    }
                    else
                    {
                        cboGlobal.SelectedIndex = 0;
                        UserSession.ChiNhanhDuocChon = dsCNHoatDong[0].MaChiNhanh;
                    }
                }

                cboGlobal.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải danh mục chi nhánh tổng: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (cboGlobal != null)
                {
                    cboGlobal.SelectedIndexChanged -= CboGlobalChiNhanh_SelectedIndexChanged;
                    cboGlobal.SelectedIndexChanged += CboGlobalChiNhanh_SelectedIndexChanged;
                }

                dangNapChiNhanh = false;
            }
        }

        private void CboGlobalChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangNapChiNhanh)
                return;

            ComboBox cbo = sender as ComboBox;

            if (cbo == null)
                return;

            string maChiNhanh = LayMaChiNhanhDangChonTuComboBox(cbo);

            if (string.IsNullOrWhiteSpace(maChiNhanh))
                return;

            ChiNhanhBUS cnBus = new ChiNhanhBUS();

            if (!cnBus.ChiNhanhDangHoatDong(maChiNhanh))
            {
                MessageBox.Show(
                    "Chi nhánh này đã ngừng hoạt động nên không thể thao tác nghiệp vụ.",
                    "Chi nhánh ngừng hoạt động",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                LoadGlobalChiNhanh();
                return;
            }

            UserSession.ChiNhanhDuocChon = maChiNhanh;

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

        private bool KiemTraChiNhanhTruocKhiMoUC()
        {
            if (string.IsNullOrWhiteSpace(UserSession.ChiNhanhDuocChon))
            {
                MessageBox.Show(
                    "Chưa có chi nhánh đang hoạt động để thao tác.\n" +
                    "Vui lòng chọn hoặc kích hoạt chi nhánh trước.",
                    "Thiếu chi nhánh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            ChiNhanhBUS cnBus = new ChiNhanhBUS();

            if (!cnBus.ChiNhanhDangHoatDong(UserSession.ChiNhanhDuocChon))
            {
                MessageBox.Show(
                    "Chi nhánh đang chọn đã ngừng hoạt động.\n" +
                    "Bạn không thể tạo hoặc cập nhật nghiệp vụ mới tại chi nhánh này.",
                    "Chi nhánh ngừng hoạt động",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                LoadGlobalChiNhanh();
                return false;
            }

            return true;
        }

        private bool UcCanChiNhanhHoatDong(UserControl uc)
        {
            return uc is UC_SanPham
                || uc is UC_NhapHangLo
                || uc is UC_TaoHoaDon
                || uc is UC_DanhSachHoaDon
                || uc is UC_BaoHanh
                || uc is UC_CanhBaoKho
                || uc is UC_ChamSocKH
                || uc is UC_KhachHang
                || uc is UC_Dashboard
                || uc is UC_DoanhThu
                || uc is UC_TopBanChay;
        }

        private void AddUserControl(UserControl uc)
        {
            if (UcCanChiNhanhHoatDong(uc))
            {
                if (!KiemTraChiNhanhTruocKhiMoUC())
                    return;
            }

            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        private void PhanQuyenHeThong()
        {
            ComboBox cboGlobal = LayComboChiNhanhToanCuc();

            if (UserSession.VaiTro != "Admin")
            {
                if (cboGlobal != null)
                    cboGlobal.Enabled = false;

                SetVisibleControl("picDashBoard", false);
                SetVisibleControl("lblDashBoard", false);
                SetVisibleControl("lblTitleTongQuan", false);
                SetVisibleControl("lblTongQuan", false);

                SetVisibleControl("picNhapHang", false);
                SetVisibleControl("lblNhapHang", false);

                SetVisibleControl("picCanhBaoTonKho", false);
                SetVisibleControl("lblCanhBaoTonKho", false);

                SetVisibleControl("picNhanVien", false);
                SetVisibleControl("lblNhanVien", false);

                SetVisibleControl("picHangSanXuat", false);
                SetVisibleControl("lblHangSanXuat", false);

                SetVisibleControl("picChiNhanh", false);
                SetVisibleControl("lblChiNhanh", false);

                SetVisibleControl("lblTitleDanhMuc", false);

                SetVisibleControl("picDoanhThu", false);
                SetVisibleControl("lblDoanhThu", false);

                SetVisibleControl("picTopBanChay", false);
                SetVisibleControl("lblTopBanChay", false);

                SetVisibleControl("lblTitleBaoCao", false);
            }
            else
            {
                if (cboGlobal != null)
                {
                    cboGlobal.Enabled = !string.IsNullOrWhiteSpace(UserSession.ChiNhanhDuocChon);
                }

                SetVisibleControl("picDashBoard", true);
                SetVisibleControl("lblDashBoard", true);
                SetVisibleControl("lblTitleTongQuan", true);
                SetVisibleControl("lblTongQuan", true);

                SetVisibleControl("picNhapHang", true);
                SetVisibleControl("lblNhapHang", true);

                SetVisibleControl("picCanhBaoTonKho", true);
                SetVisibleControl("lblCanhBaoTonKho", true);

                SetVisibleControl("picNhanVien", true);
                SetVisibleControl("lblNhanVien", true);

                SetVisibleControl("picHangSanXuat", true);
                SetVisibleControl("lblHangSanXuat", true);

                SetVisibleControl("picChiNhanh", true);
                SetVisibleControl("lblChiNhanh", true);

                SetVisibleControl("lblTitleDanhMuc", true);

                SetVisibleControl("picDoanhThu", true);
                SetVisibleControl("lblDoanhThu", true);

                SetVisibleControl("picTopBanChay", true);
                SetVisibleControl("lblTopBanChay", true);

                SetVisibleControl("lblTitleBaoCao", true);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
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

        public void MoNhapHangTheoSanPham(string maSP)
        {
            if (!KiemTraChiNhanhTruocKhiMoUC())
                return;

            UC_NhapHangLo ucNhapHangLo = new UC_NhapHangLo();

            AddUserControl(ucNhapHangLo);

            ucNhapHangLo.ChonSanPhamCanNhap(maSP);
        }

        private void picNhanVien_Click(object sender, EventArgs e)
        {
            AddUserControl(new UC_NhanVien());
        }

        private void lblNhanVien_Click(object sender, EventArgs e)
        {
            picNhanVien_Click(sender, e);
        }

        private void picDashBoard_Click(object sender, EventArgs e)
        {
            if (UserSession.VaiTro != "Admin")
            {
                MessageBox.Show(
                    "Tài khoản nhân viên không có quyền xem Dashboard tổng quan.",
                    "Không có quyền truy cập",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            AddUserControl(new UC_Dashboard());
        }

        private void lblDashBoard_Click(object sender, EventArgs e)
        {
            picDashBoard_Click(sender, e);
        }

        private void picSanPham_Click(object sender, EventArgs e)
        {
            AddUserControl(new UC_SanPham());
        }

        private void lblSanPham_Click(object sender, EventArgs e)
        {
            picSanPham_Click(sender, e);
        }

        private void picNhapHang_Click(object sender, EventArgs e)
        {
            AddUserControl(new UC_NhapHangLo());
        }

        private void lblNhapHang_Click(object sender, EventArgs e)
        {
            picNhapHang_Click(sender, e);
        }

        private void picTaoHoaDon_Click(object sender, EventArgs e)
        {
            AddUserControl(new UC_TaoHoaDon());
        }

        private void lblTaoHoaDon_Click(object sender, EventArgs e)
        {
            picTaoHoaDon_Click(sender, e);
        }

        private void picDanhSachHD_Click(object sender, EventArgs e)
        {
            AddUserControl(new UC_DanhSachHoaDon());
        }

        private void lblDanhSachHD_Click(object sender, EventArgs e)
        {
            picDanhSachHD_Click(sender, e);
        }

        private void picBaoHanh_Click(object sender, EventArgs e)
        {
            AddUserControl(new UC_BaoHanh());
        }

        private void lblBaoHanh_Click(object sender, EventArgs e)
        {
            picBaoHanh_Click(sender, e);
        }

        private void picCanhBaoKho_Click(object sender, EventArgs e)
        {
            AddUserControl(new UC_CanhBaoKho());
        }

        private void lblCanhBaoKho_Click(object sender, EventArgs e)
        {
            picCanhBaoKho_Click(sender, e);
        }

        private void picChiNhanh_Click(object sender, EventArgs e)
        {
            AddUserControl(new UC_ChiNhanh());
        }

        private void lblChiNhanh_Click(object sender, EventArgs e)
        {
            picChiNhanh_Click(sender, e);
        }

        private void picChamSocKhachHang_Click(object sender, EventArgs e)
        {
            AddUserControl(new UC_ChamSocKH());
        }

        private void lblChamSocKhachHang_Click(object sender, EventArgs e)
        {
            picChamSocKhachHang_Click(sender, e);
        }

        private void picDoanhThu_Click(object sender, EventArgs e)
        {
            AddUserControl(new UC_DoanhThu());
        }

        private void lblDoanhThu_Click(object sender, EventArgs e)
        {
            picDoanhThu_Click(sender, e);
        }

        private void picTopBanChay_Click(object sender, EventArgs e)
        {
            AddUserControl(new UC_TopBanChay());
        }

        private void lblTopBanChay_Click(object sender, EventArgs e)
        {
            picTopBanChay_Click(sender, e);
        }

        private void picDanhSachKH_Click(object sender, EventArgs e)
        {
            AddUserControl(new UC_KhachHang());
        }

        private void lblDanhSachKH_Click(object sender, EventArgs e)
        {
            picDanhSachKH_Click(sender, e);
        }

        private void picHangSanXuat_Click(object sender, EventArgs e)
        {
            AddUserControl(new UC_HangSanXuat());
        }

        private void lblHangSanXuat_Click(object sender, EventArgs e)
        {
            picHangSanXuat_Click(sender, e);
        }
    }
}
