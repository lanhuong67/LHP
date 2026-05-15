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
    public partial class UC_TaoHoaDon : UserControl
    {
        // ==========================================
        // 1. KHAI BÁO BIẾN & TẦNG XỬ LÝ (BUS)
        // ==========================================
        private SanPhamBUS _spBus = new SanPhamBUS();
        private KhachHangBUS _khBus = new KhachHangBUS();
        private HoaDonBUS _hdBus = new HoaDonBUS();

        // Giỏ hàng lưu trữ dữ liệu tạm để hiển thị lên DataGridView
        private BindingList<ChiTietBanViewModel> gioHang = new BindingList<ChiTietBanViewModel>();
        private readonly string _placeholderSDT = "Nhập SĐT tìm KH...";

        public UC_TaoHoaDon()
        {
            InitializeComponent();
        }

        private void UC_TaoHoaDon_Load(object sender, EventArgs e)
        {
            // Tắt tự sinh cột vì đã cấu hình tay ngoài Design
            dgvGioHang.AutoGenerateColumns = false;
            dgvGioHang.DataSource = gioHang;

            // Chạy các thiết lập ban đầu
            SinhMaHoaDon();
            KhoiTaoTraiNghiemNguoiDung();
            LoadComboBoxes();

            // Lấy tên nhân viên tự động từ Session
            txtNhanVien.Text = UserSession.HoTen;
            txtNhanVien.ReadOnly = true;
            txtNhanVien.BackColor = SystemColors.Control;

            // Đổi format ngày tháng sang chuẩn Việt Nam
            dtpNgayLap.Format = DateTimePickerFormat.Custom;
            dtpNgayLap.CustomFormat = "dd/MM/yyyy";
        }

        // ==========================================
        // 2. XỬ LÝ UX HIỆN ĐẠI
        // ==========================================
        private void KhoiTaoTraiNghiemNguoiDung()
        {
            // Xử lý ô Số điện thoại (Chữ mờ) bằng code ẩn để khỏi kéo thả rườm rà
            txtSDTKhachHang.Enter += (s, e) => {
                if (txtSDTKhachHang.Text == _placeholderSDT)
                {
                    txtSDTKhachHang.Text = "";
                    txtSDTKhachHang.ForeColor = SystemColors.WindowText;
                }
            };

            txtSDTKhachHang.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtSDTKhachHang.Text))
                {
                    txtSDTKhachHang.Text = _placeholderSDT;
                    txtSDTKhachHang.ForeColor = Color.Gray;
                    txtTenKhachHang.Text = "Khách vãng lai";
                    txtTenKhachHang.ForeColor = Color.Black;
                    txtTenKhachHang.ReadOnly = true;
                }
            };

            // Kích hoạt chữ mờ ngay khi mở form
            txtSDTKhachHang.Focus();
            this.Focus();

            // Xử lý ComboBox tự xổ xuống khi click vào
            ComboBox[] danhSachCbo = { cboHangSX, cboSanPham };
            foreach (var cbo in danhSachCbo)
            {
                cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                cbo.Click += (s, e) => { if (!cbo.DroppedDown) cbo.DroppedDown = true; };
                cbo.Enter += (s, e) => { if (!cbo.DroppedDown) cbo.DroppedDown = true; };
            }
        }

        // Sự kiện này bạn đã gán bằng Tia Sét (TextChanged) ngoài Design
        private void TxtSDTKhachHang_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSDTKhachHang.Text.Trim();
            if (sdt == _placeholderSDT) return;

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

        // ==========================================
        // 3. LOAD DỮ LIỆU ĐẦU VÀO
        // ==========================================
        private void SinhMaHoaDon()
        {
            txtMaHD.Text = "HD" + DateTime.Now.ToString("yyyyMMdd_HHmm");
            txtMaHD.ReadOnly = true;
            txtMaHD.BackColor = SystemColors.Control;
        }

        private void LoadComboBoxes()
        {
            try
            {
                cboHangSX.DataSource = _spBus.GetAllHang();
                cboHangSX.DisplayMember = "TenHang";
                cboHangSX.ValueMember = "MaHang";
            }
            catch { }
        }

        // Sự kiện này bạn đã gán bằng Tia Sét (SelectedIndexChanged) ngoài Design
        private void cboHangSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHangSX.SelectedValue != null)
            {
                string maHang = cboHangSX.SelectedValue.ToString();
                cboSanPham.DataSource = _spBus.GetAll().Where(s => s.MaHang == maHang).ToList();
                cboSanPham.DisplayMember = "TenSP";
                cboSanPham.ValueMember = "MaSP";
            }
        }

        // ==========================================
        // 4. LOGIC THÊM SẢN PHẨM (KÈM POP-UP IMEI)
        // ==========================================
        // Sự kiện này bạn đã gán bằng Tia Sét (Click) ngoài Design
        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedItem is not SanPham sp) return;

            int soLuongMua = (int)numSoLuong.Value;
            if (soLuongMua <= 0) { MessageBox.Show("Vui lòng chọn số lượng cần mua!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            List<string> danhSachImeiKho = _hdBus.GetImeiTonKho(sp.MaSP);

            if (danhSachImeiKho.Count < soLuongMua)
            {
                MessageBox.Show($"Kho không đủ máy! Sản phẩm này hiện chỉ còn {danhSachImeiKho.Count} chiếc.", "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi form ép chọn IMEI
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

                    // ĐẶT LẠI SỐ LƯỢNG VỀ 0 SAU KHI THÊM THÀNH CÔNG
                    numSoLuong.Value = 0;
                }
            }
        }

        private void CapNhatTongTien()
        {
            lblTongSoSP.Text = gioHang.Sum(x => x.SoLuong).ToString();
            lblTongTien.Text = gioHang.Sum(x => x.ThanhTien).ToString("N0") + " đ";
        }

        // Sự kiện này bạn đã gán bằng Tia Sét (CellFormatting) ngoài Design
        private void dgvGioHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Tự sinh số thứ tự
            if (dgvGioHang.Columns[e.ColumnIndex].Name == "colSTT")
                e.Value = (e.RowIndex + 1).ToString();
        }

        // Sự kiện này bạn đã gán bằng Tia Sét (CellContentClick) ngoài Design
        private void dgvGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý nút Xóa
            if (dgvGioHang.Columns[e.ColumnIndex].Name == "colXoa" && e.RowIndex >= 0)
            {
                gioHang.RemoveAt(e.RowIndex);
                CapNhatTongTien();
            }
        }

        // ==========================================
        // 5. CHỐT ĐƠN VÀ THANH TOÁN
        // ==========================================
        // Sự kiện này bạn đã gán bằng Tia Sét (Click) ngoài Design
        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            if (gioHang.Count > 0)
            {
                if (MessageBox.Show("Xóa toàn bộ giỏ hàng và làm mới hóa đơn?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    gioHang.Clear();
                    CapNhatTongTien();
                    SinhMaHoaDon();
                    txtSDTKhachHang.Text = "";
                    txtSDTKhachHang.Focus();
                    this.Focus();
                }
            }
        }

        // Sự kiện này bạn đã gán bằng Tia Sét (Click) ngoài Design
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (!gioHang.Any()) { MessageBox.Show("Giỏ hàng đang trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string sdtLuu = txtSDTKhachHang.Text == _placeholderSDT ? "" : txtSDTKhachHang.Text;

            // Tự động lưu Khách hàng mới vào Database
            if (!string.IsNullOrEmpty(sdtLuu) && txtTenKhachHang.ReadOnly == false && !string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            {
                KhachHang khMoi = new KhachHang { MaKH = "KH" + DateTime.Now.ToString("yyMMddHHmm"), HoTen = txtTenKhachHang.Text.Trim(), SDT = sdtLuu };
                _khBus.Them(khMoi);
            }

            if (MessageBox.Show("Xác nhận thanh toán và xuất kho lô hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                HoaDon hd = new HoaDon
                {
                    MaHD = txtMaHD.Text,
                    NgayLap = dtpNgayLap.Value,
                    MaNV = UserSession.MaNV, // Lấy mã NV tự động từ Session
                    SDTKhachHang = sdtLuu,
                    TongTien = gioHang.Sum(x => x.ThanhTien),
                    TrangThai = "Hoàn thành"
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
                        MessageBox.Show("Thanh toán thành công! Đã trừ tồn kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset giao diện chuẩn bị cho đơn hàng mới
                        gioHang.Clear();
                        CapNhatTongTien();
                        SinhMaHoaDon();
                        txtSDTKhachHang.Text = "";
                        txtSDTKhachHang.Focus();
                        this.Focus();
                        numSoLuong.Value = 0; // Đảm bảo số lượng cũng được reset về 0 sau khi thanh toán
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }

    // ==========================================================
    // CLASS FORM POP-UP CHỌN IMEI 
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
            this.Size = new Size(400, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Label lblHuongDan = new Label() { Text = $"Vui lòng tích chọn ĐÚNG {soLuongCanChon} mã IMEI để bán:", Left = 15, Top = 15, Width = 350 };

            clbImeis = new CheckedListBox() { Left = 15, Top = 40, Width = 350, Height = 280, CheckOnClick = true };
            clbImeis.Items.AddRange(danhSachImeiSanSang.ToArray());

            clbImeis.ItemCheck += (s, e) =>
            {
                int currentChecked = clbImeis.CheckedItems.Count;
                if (e.NewValue == CheckState.Checked) currentChecked++;
                if (e.NewValue == CheckState.Unchecked) currentChecked--;

                lblTrangThai.Text = $"Đã chọn: {currentChecked} / {_soLuongCanChon}";
                lblTrangThai.ForeColor = currentChecked == _soLuongCanChon ? Color.Green : (currentChecked > _soLuongCanChon ? Color.Red : Color.Blue);
            };

            lblTrangThai = new Label() { Text = $"Đã chọn: 0 / {soLuongCanChon}", Left = 15, Top = 330, Width = 150, ForeColor = Color.Blue, Font = new Font("Arial", 10, FontStyle.Bold) };
            Button btnXacNhan = new Button() { Text = "Xác nhận", Left = 245, Top = 330, Width = 120, Height = 35, BackColor = Color.DodgerBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            btnXacNhan.Click += (s, e) =>
            {
                if (clbImeis.CheckedItems.Count != _soLuongCanChon)
                {
                    MessageBox.Show($"Lỗi: Bạn phải tích chọn chính xác {_soLuongCanChon} mã IMEI.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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