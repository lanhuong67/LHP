using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_BaoHanh : UserControl
    {
        private BaoHanhBUS _bus = new BaoHanhBUS();
        private List<SanPhamBaoHanhViewModel> _dsSanPham = new List<SanPhamBaoHanhViewModel>();
        private bool _isProcessingClick = false;

        // Chuỗi chữ mờ mặc định
        private readonly string _placeholderTim = "Nhập mã HD hoặc SĐT khách hàng...";

        public UC_BaoHanh()
        {
            InitializeComponent();
            // 🔴 THÊM DÒNG NÀY VÀO ĐỂ FORM TỰ ĐỘNG LẤP ĐẦY KHOẢNG TRỐNG
            this.Dock = DockStyle.Fill;
            // 🔴 TỰ ĐỘNG GÁN TOÀN BỘ SỰ KIỆN BẰNG CODE (Không cần bấm tia sét ngoài Design)
            this.Load += UC_BaoHanh_Load;

            // Sự kiện tính ngày và cập nhật phiếu Preview thời gian thực
            cboThoiHan.SelectedIndexChanged += CapNhatNgayHetHan;
            dtpBatDau.ValueChanged += CapNhatNgayHetHan;
            cboDieuKien.SelectedIndexChanged += (s, ev) => CapNhatPreview();
            txtGhiChu.TextChanged += (s, ev) => CapNhatPreview();

            // Sự kiện click chọn trên bảng sản phẩm
            dgvSanPham.CellFormatting += dgvSanPham_CellFormatting;
            dgvSanPham.CellContentClick += dgvSanPham_CellContentClick;

            // Nút bấm chốt phiếu bảo hành
            btnTaoPhieu.Click += btnTaoPhieu_Click;
        }

        private void UC_BaoHanh_Load(object sender, EventArgs e)
        {
            // Cấu hình bảng chọn sản phẩm sạch sẽ, mất cột dấu * dư thừa
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.AllowUserToAddRows = false;

            // Nạp dữ liệu mặc định cho các ComboBox
            if (cboThoiHan.Items.Count == 0)
            {
                cboThoiHan.Items.AddRange(new string[] { "1 tháng", "3 tháng", "6 tháng", "12 tháng", "24 tháng" });
                cboThoiHan.SelectedIndex = 3; // Mặc định chọn 12 tháng
            }

            if (cboDieuKien.Items.Count == 0)
            {
                cboDieuKien.Items.AddRange(new string[] { "Bảo hành nhà sản xuất", "Bảo hành VIP (Rơi vỡ)", "Sửa chữa dịch vụ (Hết hạn)" });
                cboDieuKien.SelectedIndex = 0;
            }

            dtpBatDau.Format = DateTimePickerFormat.Custom;
            dtpBatDau.CustomFormat = "dd/MM/yyyy";
            dtpHetHan.Format = DateTimePickerFormat.Custom;
            dtpHetHan.CustomFormat = "dd/MM/yyyy";
            dtpHetHan.Enabled = false; // Khóa lại, ép hệ thống tự tính toán tăng độ chính xác

            SinhMaPhieuBaoHanh();
            KhoiTaoThanhTimKiemRealTime();
            CapNhatNgayHetHan(null, null);
        }

        private void SinhMaPhieuBaoHanh()
        {
            lblPrevMaBH.Text = "BH" + DateTime.Now.ToString("yyMMddHHmm");
        }

        // =========================================================
        // LOGIC XỬ LÝ TÌM KIẾM THỜI GIAN THỰC (REAL-TIME NO BUTTON)
        // =========================================================
        private void KhoiTaoThanhTimKiemRealTime()
        {
            if (txtTimKiemHD != null)
            {
                txtTimKiemHD.Text = _placeholderTim;
                txtTimKiemHD.ForeColor = Color.Gray;

                txtTimKiemHD.Enter += (s, e) => {
                    if (txtTimKiemHD.Text == _placeholderTim) { txtTimKiemHD.Text = ""; txtTimKiemHD.ForeColor = Color.Black; }
                };

                txtTimKiemHD.Leave += (s, e) => {
                    if (string.IsNullOrWhiteSpace(txtTimKiemHD.Text)) { txtTimKiemHD.Text = _placeholderTim; txtTimKiemHD.ForeColor = Color.Gray; ResetThongTinBaoHanh(); }
                };

                // Gán sự kiện quét thời gian thực khi gõ chữ
                txtTimKiemHD.TextChanged += txtTimKiemHD_TextChanged;
            }
        }

        private void txtTimKiemHD_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemHD.Text.Trim();
            if (string.IsNullOrWhiteSpace(tuKhoa) || tuKhoa == _placeholderTim)
            {
                ResetThongTinBaoHanh();
                return;
            }

            // 🔴 TRỰC QUAN & THÔNG MINH: Tự động tìm khi gõ đủ 10 số điện thoại hoặc gõ chuỗi mã hóa đơn dài hơn 6 ký tự
            if (tuKhoa.Length == 10 || tuKhoa.Length >= 12)
            {
                ThucHienTimKiemBaoHanh(tuKhoa);
            }
            else
            {
                ResetThongTinBaoHanh();
            }
        }

        private void ThucHienTimKiemBaoHanh(string tuKhoa)
        {
            var hd = _bus.TimHoaDonBaoHanh(tuKhoa);
            if (hd != null)
            {
                // Bung thông tin ra Bước 1
                lblMaHD.Text = hd.MaHD;
                lblKhachHang.Text = hd.TenKhachHang;
                lblSDT.Text = hd.TenNhanVien; // Tầng DAL mượn biến này trả về SĐT khách
                lblNgayMua.Text = hd.NgayLap.ToString("dd/MM/yyyy HH:mm");

                // Bung thông tin ra Giấy Preview bên phải
                lblPrevTenKH.Text = hd.TenKhachHang;
                lblPrevSDT.Text = hd.TenNhanVien;
                lblPrevNgayMua.Text = hd.NgayLap.ToString("dd/MM/yyyy");

                // Đổ danh sách máy của hóa đơn đó vào bảng B2
                _dsSanPham = _bus.GetSanPhamTuHoaDon(hd.MaHD);
                dgvSanPham.DataSource = _dsSanPham;
                CapNhatPreview();
            }
            else
            {
                ResetThongTinBaoHanh();
            }
        }

        private void ResetThongTinBaoHanh()
        {
            lblMaHD.Text = "HD"; lblKhachHang.Text = "tên KH"; lblSDT.Text = "SĐT"; lblNgayMua.Text = "Ngày mua";
            lblPrevTenKH.Text = "tên KH"; lblPrevSDT.Text = "SĐT"; lblPrevNgayMua.Text = "///"; lblPrevTenSP.Text = "sp";
            dgvSanPham.DataSource = null;
            if (_dsSanPham != null) _dsSanPham.Clear();
            CapNhatPreview();
        }

        // =========================================================
        // XỬ LÝ TICK CHỌN SẢN PHẨM TRÊN LƯỚI (CHỈ ĐƯỢC CHỌN 1 MÁY)
        // =========================================================
        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvSanPham.Columns[e.ColumnIndex].Name == "colChon")
            {
                dgvSanPham.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Ràng buộc nghiệp vụ: Mỗi phiếu bảo hành chỉ lập cho 1 máy duy nhất
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    if (row.Index != e.RowIndex) row.Cells["colChon"].Value = false;
                }
                CapNhatPreview();
            }
        }

        // =========================================================
        // TỰ ĐỘNG TÍNH TOÁN HẠN BẢO HÀNH & HIỂN THỊ PREVIEW REAL-TIME
        // =========================================================
        private void CapNhatNgayHetHan(object sender, EventArgs e)
        {
            if (cboThoiHan.SelectedItem != null)
            {
                string thoiHan = cboThoiHan.SelectedItem.ToString();
                int soThang = int.Parse(new string(thoiHan.Where(char.IsDigit).ToArray()));

                dtpHetHan.Value = dtpBatDau.Value.AddMonths(soThang);
                CapNhatPreview();
            }
        }

        private void CapNhatPreview()
        {
            var spChon = _dsSanPham?.FirstOrDefault(x => x.Chon);

            lblPrevTenSP.Text = spChon != null ? spChon.TenSP : "Chưa chọn sản phẩm";
            lblPrevBatDau.Text = dtpBatDau.Value.ToString("dd/MM/yyyy");
            lblPrevHetHan.Text = dtpHetHan.Value.ToString("dd/MM/yyyy");
            lblPrevDieuKien.Text = cboDieuKien.Text;
        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].DataPropertyName == "DonGia" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal val))
                {
                    e.Value = val.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }

        // =========================================================
        // XÁC NHẬN LƯU PHIẾU VÀO DATABASE
        // =========================================================
        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            if (e == null || _isProcessingClick) return;
            _isProcessingClick = true;

            try
            {
                if (lblMaHD.Text == "HD" || string.IsNullOrWhiteSpace(lblMaHD.Text))
                {
                    MessageBox.Show("Vui lòng nhập SĐT hoặc mã để tìm thấy hóa đơn gốc trước!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var spChon = _dsSanPham?.FirstOrDefault(x => x.Chon);
                if (spChon == null)
                {
                    MessageBox.Show("Vui lòng tích chọn một thiết bị di động ở Bước 2 để làm thủ tục bảo hành!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Xác nhận in và lưu Phiếu Tiếp Nhận Bảo Hành lên hệ thống?", "Xác nhận nghiệp vụ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    PhieuBaoHanh pbh = new PhieuBaoHanh
                    {
                        MaPhieuBH = lblPrevMaBH.Text,
                        MaHD = lblMaHD.Text,
                        MaSP = spChon.MaSP,
                        NgayTiepNhan = DateTime.Now,
                        NgayBatDauBH = dtpBatDau.Value,
                        NgayHetHanBH = dtpHetHan.Value,
                        DieuKienBaoHanh = cboDieuKien.Text,
                        TinhTrangMay = txtGhiChu.Text.Trim(),
                        TrangThai = "Đang xử lý",
                        MaNVTiepNhan = UserSession.MaNV ?? "Admin"
                    };

                    if (_bus.TaoPhieuBaoHanh(pbh))
                    {
                        MessageBox.Show("Lập phiếu bảo hành thành công!\nHệ thống lưu vết kiểm toán và sẵn sàng lệnh in.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Khởi động lại đơn mới
                        txtTimKiemHD.Text = "";
                        ResetThongTinBaoHanh();
                        SinhMaPhieuBaoHanh();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi kết nối tệp tin CSDL. Không thể lưu.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { _isProcessingClick = false; }
        }
    }
}