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

            KhoiTaoDuanLieuDanhMuc();
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

        private void KhoiTaoDuanLieuDanhMuc()
        {
            cboThanhPho.Items.Clear();
            cboThanhPho.Items.Add("TP. Hồ Chí Minh");

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[] { "Đang hoạt động", "Ngưng hoạt động" });

            // 🔴 CHỈ LẤY ADMIN ĐỔ VÀO COMBOBOX QUẢN LÝ
            cboQuanLy.Items.Clear();
            try
            {
                NhanVienBUS nvBus = new NhanVienBUS();
                var dsNhanVien = nvBus.GetAllNhanVien();

                if (dsNhanVien != null && dsNhanVien.Count > 0)
                {
                    // Lọc những ai có VaiTro là "Admin" (không phân biệt hoa thường)
                    var listAdmin = dsNhanVien
                        .Where(x => !string.IsNullOrEmpty(x.VaiTro) && x.VaiTro.Trim().Equals("Admin", StringComparison.OrdinalIgnoreCase))
                        .Select(x => x.HoTen)
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
                cboQuanLy.Items.Add("Lỗi Tải NV");
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
                dgvChiNhanh.DataSource = dsChiNhanh;
                CapNhatThongKeTheCard(dsChiNhanh);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống không thể tải danh sách chi nhánh: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhatThongKeTheCard(List<ChiNhanh> ds)
        {
            if (ds == null) return;
            lblTongCN.Text = ds.Count.ToString();
            lblDangHoatDong.Text = ds.Count(x => x.TrangThai == "Đang hoạt động").ToString();
            lblNgungHoatDong.Text = ds.Count(x => x.TrangThai == "Ngưng hoạt động").ToString();

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
            if (cboQuanHuyen != null) cboQuanHuyen.Enabled = isEditMode;
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
            cboTrangThai.SelectedIndex = 0;

            ComboBox cboQuanHuyen = this.Controls.Find("cboQuanHuyen", true).FirstOrDefault() as ComboBox;
            if (cboQuanHuyen != null)
            {
                cboQuanHuyen.SelectedIndex = -1;
                cboQuanHuyen.Text = "";
            }
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
                MessageBox.Show("Vui lòng click chọn một chi nhánh từ bảng danh sách trước khi sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _isAddNew = false;
            TrangThaiKhaiBaoForm(true);
            txtTenCN.Focus();
        }

        private void dgvChiNhanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TrangThaiKhaiBaoForm(false);

                var cn = dgvChiNhanh.Rows[e.RowIndex].DataBoundItem as ChiNhanh;

                if (cn != null)
                {
                    txtMaCN.Text = cn.MaChiNhanh;
                    txtTenCN.Text = cn.TenChiNhanh;
                    cboThanhPho.Text = cn.ThanhPho;
                    txtDiaChi.Text = cn.DiaChi;
                    cboQuanLy.Text = cn.QuanLy;
                    txtSDT.Text = cn.SDT;
                    txtEmail.Text = cn.Email;
                    cboTrangThai.Text = cn.TrangThai;

                    ComboBox cboQuanHuyen = this.Controls.Find("cboQuanHuyen", true).FirstOrDefault() as ComboBox;
                    if (cboQuanHuyen != null) cboQuanHuyen.Text = cn.QuanHuyen;
                }
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            ComboBox cboQuanHuyen = this.Controls.Find("cboQuanHuyen", true).FirstOrDefault() as ComboBox;
            string tenQuanHuyen = cboQuanHuyen != null ? cboQuanHuyen.Text.Trim() : "";

            if (string.IsNullOrWhiteSpace(txtTenCN.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Tên chi nhánh và thông tin Địa chỉ không được phép bỏ trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ChiNhanh cn = new ChiNhanh
            {
                MaChiNhanh = txtMaCN.Text,
                TenChiNhanh = txtTenCN.Text.Trim(),
                ThanhPho = cboThanhPho.Text,
                QuanHuyen = tenQuanHuyen,
                DiaChi = txtDiaChi.Text.Trim(),
                QuanLy = cboQuanLy.Text,
                SDT = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                TrangThai = cboTrangThai.Text
            };

            try
            {
                bool success = false;
                if (_isAddNew)
                {
                    success = _cnBus.Them(cn);
                    if (success) MessageBox.Show("Đã thêm thông tin chi nhánh mới lên hệ thống thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    success = _cnBus.Sua(cn);
                    if (success) MessageBox.Show("Cập nhật thông tin chi nhánh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (success)
                {
                    LoadDanhSachChiNhanh();
                    TrangThaiKhaiBaoForm(false);
                }
                else
                {
                    MessageBox.Show("Quá trình lưu dữ liệu gặp sự cố. Vui lòng kiểm tra lại cấu trúc kết nối!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi kết nối tệp tin dữ liệu: " + ex.Message); }
        }

        private void BtnXoaCN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCN.Text))
            {
                MessageBox.Show("Vui lòng tích chọn chi nhánh cần loại bỏ khỏi danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa chi nhánh [{txtTenCN.Text}] không?\nDữ liệu liên quan sẽ bị ảnh hưởng!", "Xác nhận loại bỏ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                try
                {
                    if (_cnBus.Xoa(txtMaCN.Text))
                    {
                        MessageBox.Show("Đã xóa chi nhánh ra khỏi hệ thống cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnLamTrong_Click(null, null);
                        LoadDanhSachChiNhanh();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa chi nhánh này do có ràng buộc khóa ngoại.\nHãy chuyển trạng thái sang 'Ngưng hoạt động' để xử lý ẩn danh mục.", "Lỗi Ràng Buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                (!string.IsNullOrEmpty(x.MaChiNhanh) && x.MaChiNhanh.ToLower().Contains(tuKhoa))
            ).ToList();

            dgvChiNhanh.DataSource = null;
            dgvChiNhanh.DataSource = dsLoc;
        }

        private void BtnLamMoiTimKiem_Click(object sender, EventArgs e)
        {
            ThietLapChuMoTimKiem();
            LoadDanhSachChiNhanh();
        }
    }
}