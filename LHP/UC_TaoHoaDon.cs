using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_TaoHoaDon : UserControl, IBranchRefreshable
    {
        private SanPhamBUS _spBus = new SanPhamBUS();
        private KhachHangBUS _khBus = new KhachHangBUS();
        private HoaDonBUS _hdBus = new HoaDonBUS();

        private BindingList<ChiTietBanViewModel> gioHang = new BindingList<ChiTietBanViewModel>();
        private readonly string _placeholderSDT = "Nhập SĐT tìm KH...";

        public UC_TaoHoaDon()
        {
            InitializeComponent();

            this.VisibleChanged -= UC_TaoHoaDon_VisibleChanged;
            this.VisibleChanged += UC_TaoHoaDon_VisibleChanged;

            dgvGioHang.CellFormatting -= dgvGioHang_CellFormatting;
            dgvGioHang.CellContentClick -= dgvGioHang_CellContentClick;

            dgvGioHang.CellFormatting += dgvGioHang_CellFormatting;
            dgvGioHang.CellContentClick += dgvGioHang_CellContentClick;
        }

        private void UC_TaoHoaDon_Load(object sender, EventArgs e)
        {
            dgvGioHang.AutoGenerateColumns = false;
            dgvGioHang.RowHeadersVisible = false;
            dgvGioHang.DataSource = gioHang;

            SinhMaHoaDon();
            KhoiTaoTraiNghiemNguoiDung();
            KhoiTaoPhuongThucThanhToan();
            KhoiTaoMaGiamGia();
            LoadComboBoxes();

            txtNhanVien.Text = UserSession.HoTen;
            txtNhanVien.ReadOnly = true;
            txtNhanVien.BackColor = SystemColors.Control;

            dtpNgayLap.Format = DateTimePickerFormat.Custom;
            dtpNgayLap.CustomFormat = "dd/MM/yyyy";

            CapNhatTongTien();
        }

        private void UC_TaoHoaDon_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                RefreshByBranch();
            }
        }

        public void RefreshByBranch()
        {
            if (gioHang.Count > 0)
            {
                gioHang.Clear();
                CapNhatTongTien();
            }

            SinhMaHoaDon();

            txtSDTKhachHang.Text = "";
            txtTenKhachHang.Text = "Khách vãng lai";
            txtTenKhachHang.ReadOnly = true;
            txtTenKhachHang.ForeColor = Color.Black;
            SetPlaceholderSDT();

            numSoLuong.Value = numSoLuong.Minimum;

            LoadComboBoxes();
            ResetPhuongThucThanhToan();
            ResetMaGiamGia();
        }

        // ============================================================
        // 0. PHƯƠNG THỨC THANH TOÁN
        // Designer cần có ComboBox tên: cboPhuongThucThanhToan
        // ============================================================
        private void KhoiTaoPhuongThucThanhToan()
        {
            cboPhuongThucThanhToan.DropDownStyle = ComboBoxStyle.DropDownList;

            cboPhuongThucThanhToan.Items.Clear();
            cboPhuongThucThanhToan.Items.Add("Tiền mặt");
            cboPhuongThucThanhToan.Items.Add("Chuyển khoản");

            cboPhuongThucThanhToan.SelectedIndex = 0;

            cboPhuongThucThanhToan.Click -= Cbo_AutoDropDown;
            cboPhuongThucThanhToan.Enter -= Cbo_AutoDropDown;

            cboPhuongThucThanhToan.Click += Cbo_AutoDropDown;
            cboPhuongThucThanhToan.Enter += Cbo_AutoDropDown;
        }

        private void ResetPhuongThucThanhToan()
        {
            if (cboPhuongThucThanhToan != null && cboPhuongThucThanhToan.Items.Count > 0)
            {
                cboPhuongThucThanhToan.SelectedIndex = 0;
            }
        }

        private string LayPhuongThucThanhToan()
        {
            if (cboPhuongThucThanhToan == null ||
                cboPhuongThucThanhToan.SelectedItem == null ||
                string.IsNullOrWhiteSpace(cboPhuongThucThanhToan.SelectedItem.ToString()))
            {
                return "Tiền mặt";
            }

            return cboPhuongThucThanhToan.SelectedItem.ToString();
        }
        // ============================================================
        // 0.1 MÃ GIẢM GIÁ
        // Designer cần có ComboBox tên: cboMaGiamGia
        // ============================================================
        private class MaGiamGiaOption
        {
            public string Ma { get; set; } = "";
            public string TenHienThi { get; set; } = "";
        }

        private void KhoiTaoMaGiamGia()
        {
            cboMaGiamGia.DropDownStyle = ComboBoxStyle.DropDownList;

            var dsMa = new List<MaGiamGiaOption>
    {
        new MaGiamGiaOption { Ma = "", TenHienThi = "--Không áp dụng--" },
        new MaGiamGiaOption { Ma = "LHP50K", TenHienThi = "LHP50K - Giảm 50,000đ từ đơn 500,000đ" },
        new MaGiamGiaOption { Ma = "LHP10", TenHienThi = "LHP10 - Giảm 10%, tối đa 500,000đ từ đơn 1,000,000đ" },
        new MaGiamGiaOption { Ma = "VIP100K", TenHienThi = "VIP100K - Giảm 100,000đ từ đơn 2,000,000đ" }
    };

            cboMaGiamGia.SelectedIndexChanged -= cboMaGiamGia_SelectedIndexChanged;

            cboMaGiamGia.DataSource = dsMa;
            cboMaGiamGia.DisplayMember = "TenHienThi";
            cboMaGiamGia.ValueMember = "Ma";

            cboMaGiamGia.SelectedIndexChanged += cboMaGiamGia_SelectedIndexChanged;

            cboMaGiamGia.Click -= Cbo_AutoDropDown;
            cboMaGiamGia.Enter -= Cbo_AutoDropDown;

            cboMaGiamGia.Click += Cbo_AutoDropDown;
            cboMaGiamGia.Enter += Cbo_AutoDropDown;
        }

        private void cboMaGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private string LayMaGiamGia()
        {
            if (cboMaGiamGia == null || cboMaGiamGia.SelectedValue == null)
                return "";

            return cboMaGiamGia.SelectedValue.ToString() ?? "";
        }

        private decimal TinhGiamGia(decimal tongTienGoc)
        {
            string ma = LayMaGiamGia();

            if (string.IsNullOrWhiteSpace(ma))
                return 0;

            ma = ma.Trim().ToUpper();

            if (ma == "LHP50K")
            {
                if (tongTienGoc >= 500000)
                    return 50000;

                return 0;
            }

            if (ma == "LHP10")
            {
                if (tongTienGoc >= 1000000)
                {
                    decimal giam = tongTienGoc * 0.10m;

                    if (giam > 500000)
                        giam = 500000;

                    return giam;
                }

                return 0;
            }

            if (ma == "VIP100K")
            {
                if (tongTienGoc >= 2000000)
                    return 100000;

                return 0;
            }

            return 0;
        }

        private void ResetMaGiamGia()
        {
            if (cboMaGiamGia != null && cboMaGiamGia.Items.Count > 0)
            {
                cboMaGiamGia.SelectedIndex = 0;
            }
        }

        // ============================================================
        // 1. UX
        // ============================================================
        private void KhoiTaoTraiNghiemNguoiDung()
        {
            txtSDTKhachHang.Enter -= TxtSDTKhachHang_Enter;
            txtSDTKhachHang.Leave -= TxtSDTKhachHang_Leave;
            txtSDTKhachHang.TextChanged -= TxtSDTKhachHang_TextChanged;

            txtSDTKhachHang.Enter += TxtSDTKhachHang_Enter;
            txtSDTKhachHang.Leave += TxtSDTKhachHang_Leave;
            txtSDTKhachHang.TextChanged += TxtSDTKhachHang_TextChanged;

            SetPlaceholderSDT();

            ComboBox[] danhSachCbo = { cboHangSX, cboSanPham };

            foreach (var cbo in danhSachCbo)
            {
                cbo.DropDownStyle = ComboBoxStyle.DropDownList;

                cbo.Click -= Cbo_AutoDropDown;
                cbo.Enter -= Cbo_AutoDropDown;

                cbo.Click += Cbo_AutoDropDown;
                cbo.Enter += Cbo_AutoDropDown;
            }
        }

        private void Cbo_AutoDropDown(object sender, EventArgs e)
        {
            if (sender is ComboBox cbo && !cbo.DroppedDown)
            {
                cbo.DroppedDown = true;
            }
        }

        private void SetPlaceholderSDT()
        {
            if (txtSDTKhachHang != null && string.IsNullOrWhiteSpace(txtSDTKhachHang.Text))
            {
                txtSDTKhachHang.Text = _placeholderSDT;
                txtSDTKhachHang.ForeColor = Color.Gray;
            }
        }

        private void TxtSDTKhachHang_Enter(object sender, EventArgs e)
        {
            if (txtSDTKhachHang.Text == _placeholderSDT)
            {
                txtSDTKhachHang.Text = "";
                txtSDTKhachHang.ForeColor = SystemColors.WindowText;
            }
        }

        private void TxtSDTKhachHang_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSDTKhachHang.Text))
            {
                txtSDTKhachHang.Text = _placeholderSDT;
                txtSDTKhachHang.ForeColor = Color.Gray;

                txtTenKhachHang.Text = "Khách vãng lai";
                txtTenKhachHang.ForeColor = Color.Black;
                txtTenKhachHang.ReadOnly = true;
            }
        }

        private void TxtSDTKhachHang_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSDTKhachHang.Text.Trim();

            if (sdt == _placeholderSDT)
                return;

            if (sdt.Length == 10 && sdt.All(char.IsDigit))
            {
                var kh = _khBus.TimKhachHangTheoSDT(sdt);

                if (kh != null)
                {
                    txtTenKhachHang.Text = kh.HoTen;
                    txtTenKhachHang.ForeColor = Color.Green;
                    txtTenKhachHang.ReadOnly = true;
                }
                else
                {
                    txtTenKhachHang.ReadOnly = false;
                    txtTenKhachHang.Text = "";
                    txtTenKhachHang.ForeColor = Color.Black;
                    txtTenKhachHang.Focus();
                }
            }
            else
            {
                txtTenKhachHang.Text = "Khách vãng lai";
                txtTenKhachHang.ForeColor = Color.Black;
                txtTenKhachHang.ReadOnly = true;
            }
        }

        private void TxtSDTKhachHang_TextChanged(object sender, EventArgs e, bool dummy = false)
        {
            TxtSDTKhachHang_TextChanged(sender, e);
        }

        // ============================================================
        // 2. LOAD DỮ LIỆU
        // ============================================================
        private void SinhMaHoaDon()
        {
            txtMaHD.Text = "HD" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            txtMaHD.ReadOnly = true;
            txtMaHD.BackColor = SystemColors.Control;
        }

        private void LoadComboBoxes()
        {
            try
            {
                string maCN = UserSession.ChiNhanhDuocChon;

                if (string.IsNullOrWhiteSpace(maCN))
                {
                    MessageBox.Show("Chưa xác định được chi nhánh đang làm việc.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dsHangHoatDong = _spBus.GetAllHang()
                    .Where(h => h.TrangThai == "Đang hợp tác")
                    .ToList();

                dsHangHoatDong.Insert(0, new HangSanXuat
                {
                    MaHang = "",
                    TenHang = "--Chọn hãng--"
                });

                cboHangSX.SelectedIndexChanged -= cboHangSX_SelectedIndexChanged;

                cboHangSX.DataSource = dsHangHoatDong;
                cboHangSX.DisplayMember = "TenHang";
                cboHangSX.ValueMember = "MaHang";

                cboHangSX.SelectedIndexChanged += cboHangSX_SelectedIndexChanged;

                cboSanPham.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hãng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboHangSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboHangSX.SelectedValue == null)
                {
                    cboSanPham.DataSource = null;
                    return;
                }

                string maHang = cboHangSX.SelectedValue.ToString();

                if (string.IsNullOrWhiteSpace(maHang))
                {
                    cboSanPham.DataSource = null;
                    return;
                }

                string maCN = UserSession.ChiNhanhDuocChon;

                if (string.IsNullOrWhiteSpace(maCN))
                {
                    cboSanPham.DataSource = null;
                    return;
                }

                var dsSP = _spBus.GetByBranch(maCN)
                    .Where(s =>
                        s.MaHang == maHang &&
                        s.TrangThai == "Đang kinh doanh" &&
                        s.TonKho > 0)
                    .ToList();

                dsSP.Insert(0, new SanPham
                {
                    MaSP = "",
                    TenSP = "--Chọn sản phẩm--"
                });

                cboSanPham.DataSource = dsSP;
                cboSanPham.DisplayMember = "TenSP";
                cboSanPham.ValueMember = "MaSP";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm theo chi nhánh: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // 3. THÊM SẢN PHẨM VÀ CHỌN IMEI
        // ============================================================
        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserSession.ChiNhanhDuocChon))
            {
                MessageBox.Show("Chưa xác định được chi nhánh đang làm việc.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboSanPham.SelectedItem is not SanPham sp || string.IsNullOrEmpty(sp.MaSP))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm hợp lệ để thêm!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuongMua = (int)numSoLuong.Value;

            if (soLuongMua <= 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng cần mua!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> danhSachImeiKho = _hdBus.GetImeiTonKho(sp.MaSP, UserSession.ChiNhanhDuocChon);

            var imeiDaNamTrongGio = gioHang
                .SelectMany(x => x.ImeiDaChon)
                .ToList();

            danhSachImeiKho = danhSachImeiKho
                .Where(imei => !imeiDaNamTrongGio.Contains(imei))
                .ToList();

            if (danhSachImeiKho.Count < soLuongMua)
            {
                MessageBox.Show($"Kho chi nhánh hiện tại không đủ máy! Sản phẩm này hiện chỉ còn {danhSachImeiKho.Count} chiếc.",
                    "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FormChonIMEI frm = new FormChonIMEI(sp.TenSP, soLuongMua, danhSachImeiKho))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var item = gioHang.FirstOrDefault(x => x.MaSP == sp.MaSP);

                    if (item != null)
                    {
                        item.SoLuong += soLuongMua;
                        item.ThanhTien = item.SoLuong * item.DonGiaBan;
                        item.ImeiDaChon.AddRange(frm.ImeiDaChon);
                    }
                    else
                    {
                        gioHang.Add(new ChiTietBanViewModel
                        {
                            MaSP = sp.MaSP,
                            TenSP = sp.TenSP,
                            SoLuong = soLuongMua,
                            DonGiaBan = sp.GiaBan,
                            ThanhTien = soLuongMua * sp.GiaBan,
                            ImeiDaChon = frm.ImeiDaChon
                        });
                    }

                    dgvGioHang.Refresh();
                    CapNhatTongTien();

                    numSoLuong.Value = numSoLuong.Minimum;

                    if (cboSanPham.Items.Count > 0)
                        cboSanPham.SelectedIndex = 0;
                }
            }
        }

        private void CapNhatTongTien()
        {
            decimal tongTienGoc = gioHang.Sum(x => x.ThanhTien);
            decimal giamGia = TinhGiamGia(tongTienGoc);
            decimal thanhTienSauGiam = tongTienGoc - giamGia;

            if (thanhTienSauGiam < 0)
                thanhTienSauGiam = 0;

            lblTongSoSP.Text = gioHang.Sum(x => x.SoLuong).ToString();

            lblTongTienGoc.Text = tongTienGoc.ToString("N0") + " đ";
            lblSoTienGiam.Text = giamGia.ToString("N0") + " đ";
            lblThanhTienSauGiam.Text = thanhTienSauGiam.ToString("N0") + " đ";
        }

        private void dgvGioHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvGioHang.Columns[e.ColumnIndex].Name == "colSTT")
            {
                e.Value = (e.RowIndex + 1).ToString();
                e.FormattingApplied = true;
            }

            string propName = dgvGioHang.Columns[e.ColumnIndex].DataPropertyName;

            if ((propName == "DonGiaBan" || propName == "ThanhTien") && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = val.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvGioHang.Columns[e.ColumnIndex].Name == "colXoa")
            {
                gioHang.RemoveAt(e.RowIndex);
                CapNhatTongTien();
            }
        }

        // ============================================================
        // 4. HỦY ĐƠN VÀ THANH TOÁN
        // ============================================================
        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            if (gioHang.Count > 0)
            {
                if (MessageBox.Show("Xóa toàn bộ giỏ hàng và làm mới hóa đơn?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ResetFormSauThanhToan();
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieuTruocThanhToan())
                return;

            decimal tongTienGoc = gioHang.Sum(x => x.ThanhTien);
            decimal giamGia = TinhGiamGia(tongTienGoc);
            decimal thanhTienSauGiam = tongTienGoc - giamGia;

            if (thanhTienSauGiam < 0)
                thanhTienSauGiam = 0;

            string phuongThucThanhToan = LayPhuongThucThanhToan();

            if (phuongThucThanhToan == "Tiền mặt")
            {
                XuLyThanhToanTienMat(tongTienGoc, giamGia, thanhTienSauGiam);
            }
            else if (phuongThucThanhToan == "Chuyển khoản")
            {
                XuLyThanhToanChuyenKhoan(tongTienGoc, giamGia, thanhTienSauGiam);
            }
            else
            {
                MessageBox.Show("Phương thức thanh toán không hợp lệ.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool KiemTraDuLieuTruocThanhToan()
        {
            if (!gioHang.Any())
            {
                MessageBox.Show("Giỏ hàng đang trống!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(UserSession.ChiNhanhDuocChon))
            {
                MessageBox.Show("Chưa xác định được chi nhánh đang làm việc.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void XuLyThanhToanTienMat(decimal tongTienGoc, decimal giamGia, decimal thanhTienSauGiam)
        {
            string noiDungXacNhan =
                $"Xác nhận thanh toán tiền mặt và xuất kho hóa đơn này?\n\n" +
                $"Tổng tiền gốc: {tongTienGoc:N0} đ\n" +
                $"Giảm giá: {giamGia:N0} đ\n" +
                $"Thành tiền: {thanhTienSauGiam:N0} đ\n" +
                $"Phương thức thanh toán: Tiền mặt\n" +
                $"Trạng thái thanh toán: Đã thanh toán";

            if (MessageBox.Show(noiDungXacNhan,
                "Xác nhận thanh toán tiền mặt", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                TaoVaLuuHoaDon("Tiền mặt", "Đã thanh toán", tongTienGoc, giamGia, thanhTienSauGiam);
            }
        }

        private void XuLyThanhToanChuyenKhoan(decimal tongTienGoc, decimal giamGia, decimal thanhTienSauGiam)
        {
            using (FormThanhToanChuyenKhoan frm = new FormThanhToanChuyenKhoan(
                txtMaHD.Text,
                thanhTienSauGiam,
                "LE HUU PHUC",
                "970422",
                "0123456789"))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    TaoVaLuuHoaDon("Chuyển khoản", "Đã thanh toán", tongTienGoc, giamGia, thanhTienSauGiam);
                }
            }
        }

        private void TaoVaLuuHoaDon(string phuongThucThanhToan, string trangThaiThanhToan, decimal tongTienGoc, decimal giamGia, decimal thanhTienSauGiam)
        {
            try
            {
                string sdtLuu = txtSDTKhachHang.Text == _placeholderSDT ? "" : txtSDTKhachHang.Text.Trim();

                TaoKhachHangMoiNeuCan(sdtLuu);

                HoaDon hd = new HoaDon
                {
                    MaHD = txtMaHD.Text,
                    NgayLap = dtpNgayLap.Value,
                    MaNV = string.IsNullOrWhiteSpace(UserSession.MaNV) ? "NV01" : UserSession.MaNV,
                    SDTKhachHang = sdtLuu,

                    TongTienGoc = tongTienGoc,
                    GiamGia = giamGia,
                    ThanhTienSauGiam = thanhTienSauGiam,
                    TongTien = thanhTienSauGiam,

                    TrangThai = "Hoàn thành",
                    MaChiNhanh = UserSession.ChiNhanhDuocChon,

                    HinhThucNhanHang = "Mua tại cửa hàng",
                    DiaChiGiaoHang = "",
                    GhiChuDonHang = "",

                    PhuongThucThanhToan = phuongThucThanhToan,
                    TrangThaiThanhToan = trangThaiThanhToan
                };

                var dsChiTiet = gioHang.Select(item => new ChiTietHoaDon
                {
                    MaSP = item.MaSP,
                    SoLuong = item.SoLuong,
                    DonGia = item.DonGiaBan,
                    ThanhTien = item.ThanhTien,
                    GhiChuImei = string.Join(", ", item.ImeiDaChon)
                }).ToList();

                if (_hdBus.TaoHoaDon(hd, dsChiTiet))
                {
                    MessageBox.Show("Thanh toán thành công! Đã trừ tồn kho đúng chi nhánh.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetFormSauThanhToan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaoKhachHangMoiNeuCan(string sdtLuu)
        {
            if (!string.IsNullOrEmpty(sdtLuu) &&
                txtTenKhachHang.ReadOnly == false &&
                !string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            {
                KhachHang khMoi = new KhachHang
                {
                    MaKH = "KH" + DateTime.Now.ToString("yyMMddHHmmss"),
                    HoTen = txtTenKhachHang.Text.Trim(),
                    SDT = sdtLuu,
                    TongChiTieu = 0,
                    SoLanMua = 0
                };

                _khBus.Them(khMoi);
            }
        }

        private void ResetFormSauThanhToan()
        {
            gioHang.Clear();
            CapNhatTongTien();
            SinhMaHoaDon();

            txtSDTKhachHang.Text = "";
            txtTenKhachHang.Text = "Khách vãng lai";
            txtTenKhachHang.ReadOnly = true;
            txtTenKhachHang.ForeColor = Color.Black;
            SetPlaceholderSDT();

            numSoLuong.Value = numSoLuong.Minimum;

            if (cboHangSX.Items.Count > 0)
                cboHangSX.SelectedIndex = 0;

            cboSanPham.DataSource = null;

            ResetPhuongThucThanhToan();
            ResetMaGiamGia();
        }
    }

    // ==========================================================
    // FORM POP-UP CHỌN IMEI
    // ==========================================================
    public class FormChonIMEI : Form
    {
        public List<string> ImeiDaChon { get; private set; } = new List<string>();

        private int _soLuongCanChon;
        private CheckedListBox clbImeis;
        private Label lblTrangThai;

        public FormChonIMEI(string tenSP, int soLuongCanChon, List<string> danhSachImeiSanSang)
        {
            _soLuongCanChon = soLuongCanChon;

            this.Text = $"Chọn mã IMEI - {tenSP}";
            this.Size = new Size(420, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblHuongDan = new Label()
            {
                Text = $"Hệ thống đã tự động tích ưu tiên {soLuongCanChon} mã IMEI nhập kho lâu nhất (FIFO). Vui lòng kiểm tra và xác nhận:",
                Left = 15,
                Top = 10,
                Width = 380,
                Height = 40,
                ForeColor = Color.DarkGreen,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            clbImeis = new CheckedListBox()
            {
                Left = 15,
                Top = 50,
                Width = 370,
                Height = 250,
                CheckOnClick = true
            };

            clbImeis.Items.AddRange(danhSachImeiSanSang.ToArray());

            for (int i = 0; i < _soLuongCanChon && i < clbImeis.Items.Count; i++)
            {
                clbImeis.SetItemChecked(i, true);
            }

            lblTrangThai = new Label()
            {
                Text = $"Đã chọn: {clbImeis.CheckedItems.Count} / {soLuongCanChon}",
                Left = 15,
                Top = 330,
                Width = 150,
                ForeColor = Color.Green,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            clbImeis.ItemCheck += (s, e) =>
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    int currentChecked = clbImeis.CheckedItems.Count;
                    lblTrangThai.Text = $"Đã chọn: {currentChecked} / {_soLuongCanChon}";
                    lblTrangThai.ForeColor = currentChecked == _soLuongCanChon
                        ? Color.Green
                        : (currentChecked > _soLuongCanChon ? Color.Red : Color.Blue);
                });
            };

            Button btnXacNhan = new Button()
            {
                Text = "Xác nhận",
                Left = 265,
                Top = 320,
                Width = 120,
                Height = 40,
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnXacNhan.Click += (s, e) =>
            {
                if (clbImeis.CheckedItems.Count != _soLuongCanChon)
                {
                    MessageBox.Show($"Lỗi: Bạn phải tích chọn chính xác {_soLuongCanChon} mã IMEI.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ImeiDaChon.Clear();

                foreach (var item in clbImeis.CheckedItems)
                {
                    ImeiDaChon.Add(item.ToString());
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            this.Controls.Add(lblHuongDan);
            this.Controls.Add(clbImeis);
            this.Controls.Add(lblTrangThai);
            this.Controls.Add(btnXacNhan);
        }
    }

    // ==========================================================
    // FORM THANH TOÁN CHUYỂN KHOẢN BẰNG VIETQR - FIT NỘI DUNG RỘNG
    // ==========================================================
    public class FormThanhToanChuyenKhoan : Form
    {
        private readonly string _maHD;
        private readonly decimal _soTien;
        private readonly string _chuTaiKhoan;
        private readonly string _maNganHang;
        private readonly string _soTaiKhoan;

        private PictureBox picQR;
        private Label lblTrangThai;
        private TextBox txtLinkQR;

        public FormThanhToanChuyenKhoan(string maHD, decimal soTien, string chuTaiKhoan, string maNganHang, string soTaiKhoan)
        {
            _maHD = maHD;
            _soTien = soTien;
            _chuTaiKhoan = chuTaiKhoan;
            _maNganHang = maNganHang;
            _soTaiKhoan = soTaiKhoan;

            KhoiTaoGiaoDien();
            LoadVietQR();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "Thanh toán chuyển khoản VietQR";
            this.ClientSize = new Size(1080, 690);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AutoScroll = false;
            this.BackColor = Color.FromArgb(245, 250, 252);

            // ================= HEADER =================
            Panel pnlHeader = new Panel
            {
                Left = 0,
                Top = 0,
                Width = 1080,
                Height = 86,
                BackColor = Color.White
            };

            Label lblLogo = new Label
            {
                Text = "LHP",
                Left = 36,
                Top = 22,
                Width = 76,
                Height = 42,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(15, 75, 92),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 17, FontStyle.Bold)
            };

            Label lblTitle = new Label
            {
                Text = "Thanh toán chuyển khoản VietQR",
                Left = 135,
                Top = 18,
                Width = 650,
                Height = 38,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(20, 55, 70),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblSubTitle = new Label
            {
                Text = "Quét mã bằng ứng dụng ngân hàng để thanh toán hóa đơn",
                Left = 138,
                Top = 55,
                Width = 650,
                Height = 24,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Gray
            };

            pnlHeader.Controls.Add(lblLogo);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubTitle);

            // ================= MAIN BOX =================
            Panel pnlMain = new Panel
            {
                Left = 32,
                Top = 108,
                Width = 1016,
                Height = 430,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // ================= LEFT PANEL =================
            Panel pnlLeft = new Panel
            {
                Left = 34,
                Top = 24,
                Width = 455,
                Height = 385,
                BackColor = Color.White
            };

            Label lblThongTin = new Label
            {
                Text = "Thông tin chuyển khoản",
                Left = 0,
                Top = 0,
                Width = 430,
                Height = 34,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(20, 55, 70)
            };

            Label lblDonViTitle = TaoLabelTitle("Đơn vị bán hàng", 0, 48);
            Label lblDonVi = TaoLabelValue("LHP Mobile Store", 0, 70);

            Label line1 = TaoLine(0, 104);

            Label lblNganHangTitle = TaoLabelTitle("Mã ngân hàng / BIN", 0, 118);
            Label lblNganHang = TaoLabelValue(_maNganHang, 0, 140);

            Label line2 = TaoLine(0, 174);

            Label lblSoTaiKhoanTitle = TaoLabelTitle("Số tài khoản", 0, 188);
            Label lblSoTaiKhoan = TaoLabelValue(_soTaiKhoan, 0, 210);

            Label line3 = TaoLine(0, 244);

            Label lblChuTaiKhoanTitle = TaoLabelTitle("Chủ tài khoản", 0, 258);
            Label lblChuTaiKhoan = TaoLabelValue(_chuTaiKhoan, 0, 280);

            Label line4 = TaoLine(0, 314);

            Label lblNoiDungTitle = TaoLabelTitle("Nội dung chuyển khoản", 0, 328);

            TextBox txtNoiDung = new TextBox
            {
                Text = _maHD,
                Left = 0,
                Top = 352,
                Width = 430,
                Height = 30,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 90, 170)
            };

            pnlLeft.Controls.Add(lblThongTin);
            pnlLeft.Controls.Add(lblDonViTitle);
            pnlLeft.Controls.Add(lblDonVi);
            pnlLeft.Controls.Add(line1);
            pnlLeft.Controls.Add(lblNganHangTitle);
            pnlLeft.Controls.Add(lblNganHang);
            pnlLeft.Controls.Add(line2);
            pnlLeft.Controls.Add(lblSoTaiKhoanTitle);
            pnlLeft.Controls.Add(lblSoTaiKhoan);
            pnlLeft.Controls.Add(line3);
            pnlLeft.Controls.Add(lblChuTaiKhoanTitle);
            pnlLeft.Controls.Add(lblChuTaiKhoan);
            pnlLeft.Controls.Add(line4);
            pnlLeft.Controls.Add(lblNoiDungTitle);
            pnlLeft.Controls.Add(txtNoiDung);

            // ================= RIGHT QR PANEL =================
            Panel pnlQR = new Panel
            {
                Left = 535,
                Top = 30,
                Width = 430,
                Height = 365,
                BackColor = Color.FromArgb(232, 242, 244),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblQRTitle = new Label
            {
                Text = "Quét mã QR để chuyển khoản",
                Left = 0,
                Top = 18,
                Width = 430,
                Height = 34,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 75, 92)
            };

            picQR = new PictureBox
            {
                Left = 110,
                Top = 60,
                Width = 210,
                Height = 210,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            Label lblSoTienTitle = new Label
            {
                Text = "Số tiền cần thanh toán",
                Left = 0,
                Top = 278,
                Width = 430,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Gray
            };

            Label lblSoTien = new Label
            {
                Text = $"{_soTien:N0} đ",
                Left = 0,
                Top = 298,
                Width = 430,
                Height = 38,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 75, 92)
            };

            lblTrangThai = new Label
            {
                Text = "Đang tải mã VietQR...",
                Left = 20,
                Top = 338,
                Width = 390,
                Height = 22,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.DarkOrange
            };

            pnlQR.Controls.Add(lblQRTitle);
            pnlQR.Controls.Add(picQR);
            pnlQR.Controls.Add(lblSoTienTitle);
            pnlQR.Controls.Add(lblSoTien);
            pnlQR.Controls.Add(lblTrangThai);

            pnlMain.Controls.Add(pnlLeft);
            pnlMain.Controls.Add(pnlQR);

            // ================= NOTE =================
            Panel pnlNote = new Panel
            {
                Left = 32,
                Top = 552,
                Width = 1016,
                Height = 50,
                BackColor = Color.FromArgb(255, 248, 232)
            };

            Label lblHuongDan = new Label
            {
                Text = "Lưu ý: QR đã có sẵn số tiền và nội dung chuyển khoản là mã hóa đơn. Sau khi kiểm tra tiền đã vào tài khoản, nhân viên mới bấm “Tôi đã nhận tiền”.",
                Left = 18,
                Top = 7,
                Width = 970,
                Height = 34,
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.FromArgb(120, 85, 0),
                TextAlign = ContentAlignment.MiddleLeft
            };

            pnlNote.Controls.Add(lblHuongDan);

            // ================= BUTTONS =================
            Button btnDaNhanTien = new Button
            {
                Text = "Tôi đã nhận tiền",
                Left = 665,
                Top = 620,
                Width = 190,
                Height = 42,
                BackColor = Color.FromArgb(15, 75, 92),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            btnDaNhanTien.FlatAppearance.BorderSize = 0;

            btnDaNhanTien.Click += (s, e) =>
            {
                string noiDungXacNhan =
                    $"Xác nhận đã nhận tiền chuyển khoản?\n\n" +
                    $"Mã hóa đơn: {_maHD}\n" +
                    $"Số tiền: {_soTien:N0} đ\n" +
                    $"Nội dung CK: {_maHD}\n\n" +
                    $"Sau khi xác nhận, hệ thống sẽ tạo hóa đơn và xuất kho.";

                if (MessageBox.Show(noiDungXacNhan,
                    "Xác nhận đã nhận tiền", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };

            Button btnHuy = new Button
            {
                Text = "Hủy",
                Left = 875,
                Top = 620,
                Width = 130,
                Height = 42,
                BackColor = Color.White,
                ForeColor = Color.Red,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            btnHuy.FlatAppearance.BorderColor = Color.Red;
            btnHuy.FlatAppearance.BorderSize = 1;

            btnHuy.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            txtLinkQR = new TextBox
            {
                Left = 32,
                Top = 620,
                Width = 500,
                Height = 42,
                ReadOnly = true,
                Font = new Font("Segoe UI", 8),
                Visible = false
            };

            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlMain);
            this.Controls.Add(pnlNote);
            this.Controls.Add(txtLinkQR);
            this.Controls.Add(btnDaNhanTien);
            this.Controls.Add(btnHuy);
        }

        private Label TaoLabelTitle(string text, int left, int top)
        {
            return new Label
            {
                Text = text,
                Left = left,
                Top = top,
                Width = 430,
                Height = 20,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Gray
            };
        }

        private Label TaoLabelValue(string text, int left, int top)
        {
            return new Label
            {
                Text = text,
                Left = left,
                Top = top,
                Width = 430,
                Height = 26,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black
            };
        }

        private Label TaoLine(int left, int top)
        {
            return new Label
            {
                Left = left,
                Top = top,
                Width = 430,
                Height = 1,
                BackColor = Color.FromArgb(235, 235, 235)
            };
        }

        private void LoadVietQR()
        {
            try
            {
                string qrUrl = TaoVietQrUrl();

                txtLinkQR.Text = qrUrl;

                picQR.LoadCompleted += (s, e) =>
                {
                    if (e.Error != null)
                    {
                        lblTrangThai.Text = "Không tải được QR. Kiểm tra internet hoặc thông tin ngân hàng.";
                        lblTrangThai.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblTrangThai.Text = "QR đã sẵn sàng để quét";
                        lblTrangThai.ForeColor = Color.Green;
                    }
                };

                picQR.LoadAsync(qrUrl);
            }
            catch (Exception ex)
            {
                lblTrangThai.Text = "Lỗi tạo VietQR";
                lblTrangThai.ForeColor = Color.Red;

                MessageBox.Show("Lỗi tạo mã VietQR: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string TaoVietQrUrl()
        {
            long soTienLamTron = Convert.ToInt64(_soTien);

            string noiDung = Uri.EscapeDataString(_maHD);
            string tenTaiKhoan = Uri.EscapeDataString(_chuTaiKhoan);

            return $"https://img.vietqr.io/image/{_maNganHang}-{_soTaiKhoan}-compact2.png" +
                   $"?amount={soTienLamTron}" +
                   $"&addInfo={noiDung}" +
                   $"&accountName={tenTaiKhoan}";
        }
    }
}