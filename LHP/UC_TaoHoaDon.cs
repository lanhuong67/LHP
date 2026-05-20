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

        // ============================================================
        // HÀM NÀY ĐỂ FORMMAIN GỌI KHI ĐỔI CHI NHÁNH
        // ============================================================
        public void RefreshByBranch()
        {
            // Khi đổi chi nhánh, nên xóa giỏ hàng để tránh bán nhầm SP/IMEI của chi nhánh cũ
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

        // Nếu Designer đang gắn event TextChanged vào tên hàm cũ thì vẫn giữ hàm này để không lỗi
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

                // CHỈ LẤY SẢN PHẨM THUỘC CHI NHÁNH ĐANG CHỌN
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

            // Lấy IMEI tồn kho đúng chi nhánh
            List<string> danhSachImeiKho = _hdBus.GetImeiTonKho(sp.MaSP, UserSession.ChiNhanhDuocChon);

            // Loại bỏ các IMEI đã nằm trong giỏ hàng để tránh chọn trùng khi thêm nhiều lần
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
            lblTongSoSP.Text = gioHang.Sum(x => x.SoLuong).ToString();
            lblTongTien.Text = gioHang.Sum(x => x.ThanhTien).ToString("N0") + " đ";
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
            if (!gioHang.Any())
            {
                MessageBox.Show("Giỏ hàng đang trống!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(UserSession.ChiNhanhDuocChon))
            {
                MessageBox.Show("Chưa xác định được chi nhánh đang làm việc.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sdtLuu = txtSDTKhachHang.Text == _placeholderSDT ? "" : txtSDTKhachHang.Text.Trim();

            if (!string.IsNullOrEmpty(sdtLuu) &&
                txtTenKhachHang.ReadOnly == false &&
                !string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            {
                KhachHang khMoi = new KhachHang
                {
                    MaKH = "KH" + DateTime.Now.ToString("yyMMddHHmmss"),
                    HoTen = txtTenKhachHang.Text.Trim(),
                    SDT = sdtLuu
                };

                _khBus.Them(khMoi);
            }

            if (MessageBox.Show("Xác nhận thanh toán và xuất kho lô hàng này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                HoaDon hd = new HoaDon
                {
                    MaHD = txtMaHD.Text,
                    NgayLap = dtpNgayLap.Value,
                    MaNV = string.IsNullOrWhiteSpace(UserSession.MaNV) ? "NV01" : UserSession.MaNV,
                    SDTKhachHang = sdtLuu,
                    TongTien = gioHang.Sum(x => x.ThanhTien),
                    TrangThai = "Hoàn thành",

                    // CỰC KỲ QUAN TRỌNG: GẮN HÓA ĐƠN VÀO CHI NHÁNH ĐANG CHỌN
                    MaChiNhanh = UserSession.ChiNhanhDuocChon
                };

                var dsChiTiet = gioHang.Select(item => new ChiTietHoaDon
                {
                    MaSP = item.MaSP,
                    SoLuong = item.SoLuong,
                    DonGia = item.DonGiaBan,
                    ThanhTien = item.ThanhTien,
                    GhiChuImei = string.Join(", ", item.ImeiDaChon)
                }).ToList();

                try
                {
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
}