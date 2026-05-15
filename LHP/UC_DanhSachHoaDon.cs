using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_DanhSachHoaDon : UserControl
    {
        private HoaDonBUS _bus = new HoaDonBUS();

        public UC_DanhSachHoaDon()
        {
            InitializeComponent();
        }

        private void UC_DanhSachHoaDon_Load(object sender, EventArgs e)
        {
            // 1. Cấu hình bảng hiển thị
            dgvDanhSachHoaDon.AutoGenerateColumns = false;

            // 2. Thiết lập định dạng ngày chuẩn Việt Nam (dd/MM/yyyy)
            SetupVietnameseDatePicker(dtpTuNgay, DateTime.Now.AddDays(-30));
            SetupVietnameseDatePicker(dtpDenNgay, DateTime.Now);

            // 3. Gán sự kiện TỰ ĐỘNG CẬP NHẬT ngay khi thay đổi giá trị
            dtpTuNgay.ValueChanged += (s, ev) => HienThiDanhSach();
            dtpDenNgay.ValueChanged += (s, ev) => HienThiDanhSach();
            cboTrangThai.SelectedIndexChanged += (s, ev) => HienThiDanhSach();

            // 4. Gán sự kiện ComboBox tự động sổ xuống khi click vào bất cứ đâu
            cboTrangThai.Click += Cbo_AutoDropDown;
            cboTrangThai.Enter += Cbo_AutoDropDown;

            // 5. Gán sự kiện định dạng bảng (STT, Màu sắc)
            dgvDanhSachHoaDon.CellFormatting += dgvDanhSachHoaDon_CellFormatting;

            // (ĐÃ XÓA DÒNG GÁN SỰ KIỆN CELLCONTENTCLICK BỊ TRÙNG Ở ĐÂY ĐỂ TRÁNH HIỆN 2 POP-UP)

            // Nạp dữ liệu lần đầu ngay khi mở tab
            HienThiDanhSach();
        }

        private void SetupVietnameseDatePicker(DateTimePicker dtp, DateTime defaultValue)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "dd/MM/yyyy";
            dtp.Value = defaultValue;
        }

        private void Cbo_AutoDropDown(object sender, EventArgs e)
        {
            if (sender is ComboBox cbo && !cbo.DroppedDown)
            {
                cbo.DroppedDown = true;
            }
        }

        private void HienThiDanhSach()
        {
            try
            {
                // Lấy danh sách từ tầng BUS
                var dsFull = _bus.GetDanhSachHoaDon();

                // Lọc tự động theo khoảng ngày đã chọn
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;
                var dsLoc = dsFull.Where(x => x.NgayLap.Date >= tuNgay && x.NgayLap.Date <= denNgay).ToList();

                // Lọc tự động theo trạng thái trong ComboBox
                if (cboTrangThai.SelectedIndex > 0 && cboTrangThai.Text != "--Tất cả trạng thái--")
                {
                    string status = cboTrangThai.Text;
                    dsLoc = dsLoc.Where(x => x.TrangThai == status).ToList();
                }

                // Gán dữ liệu vào bảng
                dgvDanhSachHoaDon.DataSource = dsLoc;
            }
            catch (Exception ex)
            {
                // Chỉ ghi lỗi ra cửa sổ Output để không làm gián đoạn người dùng
                Console.WriteLine("Lỗi nạp danh sách hóa đơn: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Reset về cấu hình mặc định (30 ngày gần nhất)
            dtpTuNgay.Value = DateTime.Now.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now;

            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;

            // Hàm ValueChanged ở trên sẽ tự động gọi lại HienThiDanhSach() cho bạn
        }

        private void dgvDanhSachHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 1. Tự động đánh số thứ tự (STT)
            if (dgvDanhSachHoaDon.Columns[e.ColumnIndex].Name == "colSTT")
            {
                e.Value = (e.RowIndex + 1).ToString();
            }

            // 2. Tô màu trạng thái cho chuyên nghiệp
            if (dgvDanhSachHoaDon.Columns[e.ColumnIndex].Name == "colTrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Hoàn thành") e.CellStyle.ForeColor = Color.Green;
                else if (status == "Đã hủy") e.CellStyle.ForeColor = Color.Red;
            }
        }

        // Hàm xử lý khi bấm vào nút Chi tiết
        private void dgvDanhSachHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có click đúng vào cột không (Đảm bảo Tên cột ngoài Design là colChiTiet)
            if (dgvDanhSachHoaDon.Columns[e.ColumnIndex].Name == "colChiTiet" && e.RowIndex >= 0)
            {
                var hd = dgvDanhSachHoaDon.Rows[e.RowIndex].DataBoundItem as HoaDonViewModel;
                if (hd != null)
                {
                    try
                    {
                        // Gọi BUS lấy chi tiết
                        var dsChiTiet = _bus.GetChiTietHoaDon(hd.MaHD);

                        // Mở form Pop-up
                        using (FormChiTietHoaDon frm = new FormChiTietHoaDon(hd.MaHD, dsChiTiet))
                        {
                            frm.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi lấy chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }

    // ==========================================================
    // CLASS FORM POP-UP XEM CHI TIẾT HÓA ĐƠN
    // ==========================================================
    public class FormChiTietHoaDon : Form
    {
        public FormChiTietHoaDon(string maHD, List<ChiTietHoaDonViewModel> dsChiTiet)
        {
            this.Text = $"Chi tiết Hóa đơn: {maHD}";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // ĐÃ THÊM: AutoSize = true để Label tự động giãn chiều cao, không bị cắt mất dấu _
            Label lblTieuDe = new Label()
            {
                Text = $"DANH SÁCH SẢN PHẨM CỦA {maHD}",
                Left = 20,
                Top = 15,
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Navy
            };

            DataGridView dgvChiTiet = new DataGridView()
            {
                Left = 20,
                Top = 50,
                Width = 740,
                Height = 300,
                AllowUserToAddRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,

                AutoGenerateColumns = false,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            };

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Sản phẩm", DataPropertyName = "TenSP", Width = 150 });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SL", DataPropertyName = "SoLuong", Width = 50 });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đơn giá", DataPropertyName = "DonGia", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }, Width = 100 });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thành tiền", DataPropertyName = "ThanhTien", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }, Width = 100 });

            var colImei = new DataGridViewTextBoxColumn
            {
                HeaderText = "Danh sách IMEI đã bán",
                DataPropertyName = "GhiChuImei",
                DefaultCellStyle = new DataGridViewCellStyle { WrapMode = DataGridViewTriState.True }
            };
            dgvChiTiet.Columns.Add(colImei);

            var formattedList = dsChiTiet.Select(x => new ChiTietHoaDonViewModel
            {
                TenSP = x.TenSP,
                SoLuong = x.SoLuong,
                DonGia = x.DonGia,
                ThanhTien = x.ThanhTien,
                GhiChuImei = string.IsNullOrEmpty(x.GhiChuImei) ? "" : x.GhiChuImei.Replace(", ", "\n")
            }).ToList();

            dgvChiTiet.DataSource = formattedList;

            Button btnDong = new Button() { Text = "Đóng", Left = 660, Top = 360, Width = 100, Height = 35, BackColor = Color.LightGray, FlatStyle = FlatStyle.Flat };
            btnDong.Click += (s, e) => this.Close();

            this.Controls.Add(lblTieuDe);
            this.Controls.Add(dgvChiTiet);
            this.Controls.Add(btnDong);
        }
    }
}