using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_ChiNhanh : UserControl
    {
        private ChiNhanhBUS _cnBus = new ChiNhanhBUS();
        private bool _isAddNew = false;

        private readonly string _placeholderTimKiem = "Tìm tên hoặc mã chi nhánh...";
        private string _trangThaiCuDangChon = "";

        public UC_ChiNhanh()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UC_ChiNhanh_Load;

            btnThemCN.Click += BtnThemCN_Click;
            btnSuaCN.Click += BtnSuaCN_Click;
            btnXoaCN.Click += BtnXoaCN_Click;
            btnLuu.Click += BtnLuu_Click;
            btnLamTrong.Click += BtnLamTrong_Click;
            btnLamMoiTimKiem.Click += BtnLamMoiTimKiem_Click;

            dgvChiNhanh.CellClick += dgvChiNhanh_CellClick;

            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
            txtTimKiem.Enter += TxtTimKiem_Enter;
            txtTimKiem.Leave += TxtTimKiem_Leave;

            cboThanhPho.SelectedIndexChanged += CboThanhPho_SelectedIndexChanged;

            cboThanhPho.Click += (s, e) => { cboThanhPho.DroppedDown = true; };
            cboQuanLy.Click += (s, e) => { cboQuanLy.DroppedDown = true; };
            cboTrangThai.Click += (s, e) => { cboTrangThai.DroppedDown = true; };

            if (this.Controls.Find("cboQuanHuyen", true).FirstOrDefault() is ComboBox cboQH)
            {
                cboQH.Click += (s, e) => { cboQH.DroppedDown = true; };
            }
        }

        private void UC_ChiNhanh_Load(object sender, EventArgs e)
        {
            dgvChiNhanh.AutoGenerateColumns = false;
            dgvChiNhanh.AllowUserToAddRows = false;
            dgvChiNhanh.ReadOnly = true;
            dgvChiNhanh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            KhoiTaoDuLieuDanhMuc();
            LoadDanhSachChiNhanh();
            TrangThaiKhaiBaoForm(false);

            ThietLapChuMoTimKiem();
        }

        private void ThietLapChuMoTimKiem()
        {
            txtTimKiem.Text = _placeholderTimKiem;
            txtTimKiem.ForeColor = Color.Gray;
        }

        private void TxtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == _placeholderTimKiem)
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void TxtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                ThietLapChuMoTimKiem();
                LoadDanhSachChiNhanh();
            }
        }

        private void KhoiTaoDuLieuDanhMuc()
        {
            cboThanhPho.Items.Clear();
            cboThanhPho.Items.Add("TP. Hồ Chí Minh");

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[]
            {
                "Đang hoạt động",
                "Ngưng hoạt động"
            });

            cboQuanLy.Items.Clear();

            try
            {
                NhanVienBUS nvBus = new NhanVienBUS();
                var dsNhanVien = nvBus.GetAllNhanVien();

                if (dsNhanVien != null && dsNhanVien.Count > 0)
                {
                    var listAdmin = dsNhanVien
                        .Where(x => !string.IsNullOrWhiteSpace(x.VaiTro)
                            && x.VaiTro.Trim().Equals("Admin", StringComparison.OrdinalIgnoreCase))
                        .Select(x => x.HoTen)
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Distinct()
                        .ToArray();

                    if (listAdmin.Length > 0)
                    {
                        cboQuanLy.Items.AddRange(listAdmin);
                    }
                    else
                    {
                        cboQuanLy.Items.Add("Chưa có Admin nào");
                    }
                }
                else
                {
                    cboQuanLy.Items.Add("Chưa có dữ liệu");
                }
            }
            catch
            {
                cboQuanLy.Items.Add("Lỗi tải nhân viên");
            }
        }

        private void CboThanhPho_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cboQuanHuyen = this.Controls.Find("cboQuanHuyen", true).FirstOrDefault() as ComboBox;
            if (cboQuanHuyen == null) return;

            cboQuanHuyen.Items.Clear();

            if (cboThanhPho.Text == "TP. Hồ Chí Minh")
            {
                string[] dsQuanHuyenHCM = new string[]
                {
                    "Quận 1", "Quận 3", "Quận 4", "Quận 5", "Quận 6", "Quận 7", "Quận 8",
                    "Quận 10", "Quận 11", "Quận 12", "Quận Bình Tân", "Quận Bình Thạnh",
                    "Quận Gò Vấp", "Quận Phú Nhuận", "Quận Tân Bình", "Quận Tân Phú",
                    "TP. Thủ Đức", "Huyện Bình Chánh", "Huyện Cần Giờ", "Huyện Củ Chi",
                    "Huyện Hóc Môn", "Huyện Nhà Bè"
                };

                cboQuanHuyen.Items.AddRange(dsQuanHuyenHCM);
            }
        }

        private void LoadDanhSachChiNhanh()
        {
            try
            {
                var dsChiNhanh = _cnBus.GetAll();
                dgvChiNhanh.DataSource = null;
                dgvChiNhanh.DataSource = dsChiNhanh;

                CapNhatThongKeTheCard(dsChiNhanh);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống không thể tải danh sách chi nhánh: " + ex.Message,
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhatThongKeTheCard(List<ChiNhanh> ds)
        {
            if (ds == null) return;

            lblTongCN.Text = ds.Count.ToString();
            lblDangHoatDong.Text = ds.Count(x => LaTrangThaiDangHoatDong(x.TrangThai)).ToString();
            lblNgungHoatDong.Text = ds.Count(x => LaTrangThaiNgungHoatDong(x.TrangThai)).ToString();

            try
            {
                NhanVienBUS nvBus = new NhanVienBUS();
                lblTongNV.Text = nvBus.GetAllNhanVien().Count.ToString();
            }
            catch
            {
                lblTongNV.Text = "Lỗi";
            }
        }

        private void TrangThaiKhaiBaoForm(bool isEditMode)
        {
            txtMaCN.Enabled = false;
            txtTenCN.Enabled = isEditMode;
            cboThanhPho.Enabled = isEditMode;
            txtDiaChi.Enabled = isEditMode;
            cboQuanLy.Enabled = isEditMode;
            txtSDT.Enabled = isEditMode;
            txtEmail.Enabled = isEditMode;
            cboTrangThai.Enabled = isEditMode;
            btnLuu.Enabled = isEditMode;
            btnLamTrong.Enabled = isEditMode;

            ComboBox cboQuanHuyen = this.Controls.Find("cboQuanHuyen", true).FirstOrDefault() as ComboBox;
            if (cboQuanHuyen != null)
            {
                cboQuanHuyen.Enabled = isEditMode;
            }
        }

        private void BtnLamTrong_Click(object sender, EventArgs e)
        {
            txtMaCN.Clear();
            txtTenCN.Clear();
            cboThanhPho.SelectedIndex = -1;
            txtDiaChi.Clear();
            cboQuanLy.SelectedIndex = -1;
            txtSDT.Clear();
            txtEmail.Clear();

            if (cboTrangThai.Items.Count > 0)
            {
                cboTrangThai.Text = "Đang hoạt động";
            }

            ComboBox cboQuanHuyen = this.Controls.Find("cboQuanHuyen", true).FirstOrDefault() as ComboBox;
            if (cboQuanHuyen != null)
            {
                cboQuanHuyen.SelectedIndex = -1;
                cboQuanHuyen.Text = "";
            }

            _trangThaiCuDangChon = "";
        }

        private void BtnThemCN_Click(object sender, EventArgs e)
        {
            _isAddNew = true;

            TrangThaiKhaiBaoForm(true);
            BtnLamTrong_Click(null, null);

            txtMaCN.Text = "CN" + DateTime.Now.ToString("yyMMddHHmm");
            cboThanhPho.Text = "TP. Hồ Chí Minh";
            cboTrangThai.Text = "Đang hoạt động";

            txtTenCN.Focus();
        }

        private void BtnSuaCN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCN.Text))
            {
                MessageBox.Show("Vui lòng click chọn một chi nhánh từ bảng danh sách trước khi sửa!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isAddNew = false;
            TrangThaiKhaiBaoForm(true);
            txtTenCN.Focus();
        }

        private void dgvChiNhanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            TrangThaiKhaiBaoForm(false);

            var cn = dgvChiNhanh.Rows[e.RowIndex].DataBoundItem as ChiNhanh;

            if (cn == null) return;

            txtMaCN.Text = cn.MaChiNhanh;
            txtTenCN.Text = cn.TenChiNhanh;
            cboThanhPho.Text = cn.ThanhPho;
            txtDiaChi.Text = cn.DiaChi;
            cboQuanLy.Text = cn.QuanLy;
            txtSDT.Text = cn.SDT;
            txtEmail.Text = cn.Email;
            cboTrangThai.Text = cn.TrangThai;

            _trangThaiCuDangChon = cn.TrangThai ?? "";

            ComboBox cboQuanHuyen = this.Controls.Find("cboQuanHuyen", true).FirstOrDefault() as ComboBox;
            if (cboQuanHuyen != null)
            {
                cboQuanHuyen.Text = cn.QuanHuyen;
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            ComboBox cboQuanHuyen = this.Controls.Find("cboQuanHuyen", true).FirstOrDefault() as ComboBox;
            string tenQuanHuyen = cboQuanHuyen != null ? cboQuanHuyen.Text.Trim() : "";

            if (!KiemTraDuLieuHopLe(tenQuanHuyen))
            {
                return;
            }

            ChiNhanh cn = new ChiNhanh
            {
                MaChiNhanh = txtMaCN.Text.Trim(),
                TenChiNhanh = txtTenCN.Text.Trim(),
                ThanhPho = cboThanhPho.Text.Trim(),
                QuanHuyen = tenQuanHuyen,
                DiaChi = txtDiaChi.Text.Trim(),
                QuanLy = cboQuanLy.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                TrangThai = cboTrangThai.Text.Trim()
            };

            bool dangChuyenSangNgungHoatDong =
                !_isAddNew &&
                LaTrangThaiDangHoatDong(_trangThaiCuDangChon) &&
                LaTrangThaiNgungHoatDong(cn.TrangThai);

            if (dangChuyenSangNgungHoatDong)
            {
                DialogResult confirm = MessageBox.Show(
                    "Bạn đang chuyển chi nhánh này sang trạng thái Ngưng hoạt động.\n\n" +
                    "Sau khi ngưng hoạt động:\n" +
                    "- Chi nhánh sẽ không còn xuất hiện trong combobox thao tác toàn cục.\n" +
                    "- Các UC khác sẽ không được tạo hóa đơn, nhập hàng, bán hàng hoặc xử lý nghiệp vụ mới tại chi nhánh này.\n" +
                    "- Website cũng không hiển thị chi nhánh này cho khách đặt hàng.\n" +
                    "- Dữ liệu cũ vẫn được giữ lại để tra cứu và báo cáo.\n\n" +
                    "Bạn có chắc chắn muốn tiếp tục không?",
                    "Xác nhận ngưng hoạt động chi nhánh",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                bool success;

                if (_isAddNew)
                {
                    success = _cnBus.Them(cn);

                    if (success)
                    {
                        MessageBox.Show("Đã thêm thông tin chi nhánh mới lên hệ thống thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    success = _cnBus.Sua(cn);

                    if (success)
                    {
                        MessageBox.Show("Cập nhật thông tin chi nhánh thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (success)
                {
                    XuLySauKhiLuuChiNhanh(cn, dangChuyenSangNgungHoatDong);

                    LoadDanhSachChiNhanh();
                    TrangThaiKhaiBaoForm(false);

                    _isAddNew = false;
                    _trangThaiCuDangChon = cn.TrangThai;
                }
                else
                {
                    MessageBox.Show("Quá trình lưu dữ liệu gặp sự cố. Vui lòng kiểm tra lại cấu trúc kết nối!",
                        "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối tệp tin dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KiemTraDuLieuHopLe(string tenQuanHuyen)
        {
            if (string.IsNullOrWhiteSpace(txtMaCN.Text))
            {
                MessageBox.Show("Mã chi nhánh không được để trống!",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenCN.Text))
            {
                MessageBox.Show("Tên chi nhánh không được phép bỏ trống!",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboThanhPho.Text))
            {
                MessageBox.Show("Vui lòng chọn thành phố!",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboThanhPho.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tenQuanHuyen))
            {
                MessageBox.Show("Vui lòng chọn quận/huyện!",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ chi nhánh không được phép bỏ trống!",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboTrangThai.Text))
            {
                MessageBox.Show("Vui lòng chọn trạng thái chi nhánh!",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrangThai.Focus();
                return false;
            }

            if (!LaTrangThaiDangHoatDong(cboTrangThai.Text) && !LaTrangThaiNgungHoatDong(cboTrangThai.Text))
            {
                MessageBox.Show("Trạng thái chi nhánh không hợp lệ. Chỉ được chọn Đang hoạt động hoặc Ngưng hoạt động!",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrangThai.Focus();
                return false;
            }

            return true;
        }

        private void XuLySauKhiLuuChiNhanh(ChiNhanh cn, bool vuaChuyenSangNgungHoatDong)
        {
            LamMoiComboChiNhanhToanCuc();

            if (!vuaChuyenSangNgungHoatDong)
            {
                return;
            }

            if (UserSession.ChiNhanhDuocChon == cn.MaChiNhanh)
            {
                ChuyenSessionSangChiNhanhHoatDongKhac(cn.MaChiNhanh);
                LamMoiComboChiNhanhToanCuc();

                if (string.IsNullOrWhiteSpace(UserSession.ChiNhanhDuocChon))
                {
                    MessageBox.Show(
                        "Chi nhánh đang thao tác đã được chuyển sang Ngưng hoạt động.\n" +
                        "Hiện không còn chi nhánh nào đang hoạt động để tiếp tục thao tác nghiệp vụ.",
                        "Không còn chi nhánh hoạt động",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Chi nhánh đang thao tác đã được chuyển sang Ngưng hoạt động.\n" +
                        "Hệ thống đã tự chuyển sang chi nhánh đang hoạt động khác để tiếp tục thao tác.",
                        "Đã đổi chi nhánh thao tác",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void ChuyenSessionSangChiNhanhHoatDongKhac(string maChiNhanhVuaNgung)
        {
            var dsConHoatDong = _cnBus.GetAll()
                .Where(x =>
                    x.MaChiNhanh != maChiNhanhVuaNgung &&
                    LaTrangThaiDangHoatDong(x.TrangThai))
                .OrderBy(x => x.TenChiNhanh)
                .ToList();

            if (dsConHoatDong.Count == 0)
            {
                UserSession.ChiNhanhDuocChon = "";
                return;
            }

            UserSession.ChiNhanhDuocChon = dsConHoatDong[0].MaChiNhanh;
        }

        private void LamMoiComboChiNhanhToanCuc()
        {
            try
            {
                Form formMain = this.FindForm();
                if (formMain == null) return;

                ComboBox cboGlobal = formMain.Controls.Find("cboGlobalChiNhanh", true).FirstOrDefault() as ComboBox;
                if (cboGlobal == null) return;

                var dsChiNhanhHoatDong = _cnBus.GetAll()
                    .Where(x => LaTrangThaiDangHoatDong(x.TrangThai))
                    .OrderBy(x => x.TenChiNhanh)
                    .ToList();

                cboGlobal.DisplayMember = "TenChiNhanh";
                cboGlobal.ValueMember = "MaChiNhanh";
                cboGlobal.DataSource = null;
                cboGlobal.DataSource = dsChiNhanhHoatDong;

                if (dsChiNhanhHoatDong.Count == 0)
                {
                    cboGlobal.SelectedIndex = -1;
                    cboGlobal.Enabled = false;
                    UserSession.ChiNhanhDuocChon = "";
                    return;
                }

                if (!string.IsNullOrWhiteSpace(UserSession.ChiNhanhDuocChon) &&
                    dsChiNhanhHoatDong.Any(x => x.MaChiNhanh == UserSession.ChiNhanhDuocChon))
                {
                    cboGlobal.SelectedValue = UserSession.ChiNhanhDuocChon;
                }
                else
                {
                    cboGlobal.SelectedIndex = 0;
                    UserSession.ChiNhanhDuocChon = cboGlobal.SelectedValue?.ToString() ?? "";
                }

                cboGlobal.Enabled = UserSession.VaiTro == "Admin";
            }
            catch
            {
                // Không chặn lưu chi nhánh nếu chỉ lỗi refresh combobox toàn cục.
            }
        }

        private void BtnXoaCN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCN.Text))
            {
                MessageBox.Show("Vui lòng tích chọn chi nhánh cần loại bỏ khỏi danh sách!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa chi nhánh [{txtTenCN.Text}] không?\n\n" +
                "Chỉ nên xóa cứng khi chi nhánh chưa phát sinh dữ liệu.\n" +
                "Nếu chi nhánh đã có nhân viên, sản phẩm, hóa đơn hoặc phiếu nhập thì nên chuyển trạng thái sang Ngưng hoạt động.",
                "Xác nhận loại bỏ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string maCNCanXoa = txtMaCN.Text.Trim();

                if (_cnBus.Xoa(maCNCanXoa))
                {
                    MessageBox.Show("Đã xóa chi nhánh ra khỏi hệ thống cơ sở dữ liệu!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (UserSession.ChiNhanhDuocChon == maCNCanXoa)
                    {
                        ChuyenSessionSangChiNhanhHoatDongKhac(maCNCanXoa);
                    }

                    BtnLamTrong_Click(null, null);
                    LoadDanhSachChiNhanh();
                    LamMoiComboChiNhanhToanCuc();
                }
                else
                {
                    MessageBox.Show(
                        "Không thể xóa chi nhánh này.\n" +
                        "Nếu chi nhánh đã phát sinh dữ liệu, hãy chuyển trạng thái sang Ngưng hoạt động.",
                        "Không thể xóa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show(
                    "Không thể xóa chi nhánh này do có ràng buộc khóa ngoại.\n" +
                    "Hãy chuyển trạng thái sang Ngưng hoạt động để ngừng phát sinh nghiệp vụ mới nhưng vẫn giữ dữ liệu cũ.",
                    "Lỗi ràng buộc",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == _placeholderTimKiem) return;

            string tuKhoa = txtTimKiem.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                LoadDanhSachChiNhanh();
                return;
            }

            var dsAll = _cnBus.GetAll();

            var dsLoc = dsAll.Where(x =>
                (!string.IsNullOrEmpty(x.TenChiNhanh) && x.TenChiNhanh.ToLower().Contains(tuKhoa)) ||
                (!string.IsNullOrEmpty(x.MaChiNhanh) && x.MaChiNhanh.ToLower().Contains(tuKhoa)) ||
                (!string.IsNullOrEmpty(x.TrangThai) && x.TrangThai.ToLower().Contains(tuKhoa))
            ).ToList();

            dgvChiNhanh.DataSource = null;
            dgvChiNhanh.DataSource = dsLoc;

            CapNhatThongKeTheCard(dsLoc);
        }

        private void BtnLamMoiTimKiem_Click(object sender, EventArgs e)
        {
            ThietLapChuMoTimKiem();
            LoadDanhSachChiNhanh();
        }

        private bool LaTrangThaiDangHoatDong(string trangThai)
        {
            if (string.IsNullOrWhiteSpace(trangThai))
                return false;

            string value = trangThai.Trim().ToLower();

            return value == "đang hoạt động"
                || value == "dang hoat dong"
                || value == "hoạt động"
                || value == "hoat dong"
                || value == "đang kinh doanh"
                || value == "dang kinh doanh"
                || value == "active"
                || value == "true"
                || value == "1";
        }

        private bool LaTrangThaiNgungHoatDong(string trangThai)
        {
            if (string.IsNullOrWhiteSpace(trangThai))
                return false;

            string value = trangThai.Trim().ToLower();

            return value == "ngưng hoạt động"
                || value == "ngung hoat dong"
                || value == "ngừng hoạt động"
                || value == "ngung hoạt động"
                || value == "tạm ngưng"
                || value == "tam ngung"
                || value == "inactive"
                || value == "false"
                || value == "0";
        }
    }
}
