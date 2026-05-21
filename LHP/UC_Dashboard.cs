using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class UC_Dashboard : UserControl, IBranchRefreshable
    {
        private BaoCaoBUS _bus = new BaoCaoBUS();

        public UC_Dashboard()
        {
            InitializeComponent();
            this.Load += UC_Dashboard_Load;
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            CauHinhDataGridView();
            GanSuKien();
            LoadDashboard();
        }

        // Tự reload khi Admin đổi chi nhánh ở FormMain
        public void RefreshByBranch()
        {
            LoadDashboard();
        }

        private void GanSuKien()
        {
            btnLamMoiDashboard.Click -= btnLamMoiDashboard_Click;
            btnLamMoiDashboard.Click += btnLamMoiDashboard_Click;
        }

        private void btnLamMoiDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        // =====================================================
        // 1. CẤU HÌNH GIAO DIỆN DATAGRIDVIEW CHUNG
        // =====================================================
        private void CauHinhStyleGrid(DataGridView dgv)
        {
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.AutoGenerateColumns = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 28;
            dgv.RowTemplate.Height = 26;

            dgv.ScrollBars = ScrollBars.Vertical;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
        }

        private void CauHinhDataGridView()
        {
            CauHinhStyleGrid(dgvTopSanPhamDashboard);
            CauHinhStyleGrid(dgvCanhBaoTonKhoDashboard);
            CauHinhStyleGrid(dgvBaoHanhSapHetDashboard);
            CauHinhStyleGrid(dgvHoatDongGanDayDashboard);

            CauHinhDgvTopSanPham();
            CauHinhDgvCanhBaoTonKho();
            CauHinhDgvBaoHanhSapHet();
            CauHinhDgvHoatDongGanDay();
        }

        // =====================================================
        // 2. CẤU HÌNH BẢNG TOP SẢN PHẨM BÁN CHẠY
        // =====================================================
        private void CauHinhDgvTopSanPham()
        {
            dgvTopSanPhamDashboard.Columns.Clear();

            dgvTopSanPhamDashboard.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHang",
                HeaderText = "#",
                DataPropertyName = "Hang",
                FillWeight = 18
            });

            dgvTopSanPhamDashboard.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTenSP",
                HeaderText = "Sản phẩm",
                DataPropertyName = "TenSP",
                FillWeight = 62
            });

            dgvTopSanPhamDashboard.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSoLuongBan",
                HeaderText = "SL",
                DataPropertyName = "SoLuongBan",
                FillWeight = 20
            });
        }

        // =====================================================
        // 3. CẤU HÌNH BẢNG CẢNH BÁO TỒN KHO
        // =====================================================
        private void CauHinhDgvCanhBaoTonKho()
        {
            dgvCanhBaoTonKhoDashboard.Columns.Clear();

            dgvCanhBaoTonKhoDashboard.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaSP",
                HeaderText = "Mã",
                DataPropertyName = "MaSP",
                FillWeight = 22
            });

            dgvCanhBaoTonKhoDashboard.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTenSP",
                HeaderText = "Tên SP",
                DataPropertyName = "TenSP",
                FillWeight = 42
            });

            dgvCanhBaoTonKhoDashboard.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTonKho",
                HeaderText = "Tồn",
                DataPropertyName = "TonKho",
                FillWeight = 16
            });

            dgvCanhBaoTonKhoDashboard.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMucCanhBao",
                HeaderText = "Mức",
                DataPropertyName = "MucCanhBao",
                FillWeight = 25
            });
        }

        // =====================================================
        // 4. CẤU HÌNH BẢNG BẢO HÀNH SẮP HẾT
        // =====================================================
        private void CauHinhDgvBaoHanhSapHet()
        {
            dgvBaoHanhSapHetDashboard.Columns.Clear();

            dgvBaoHanhSapHetDashboard.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaBH",
                HeaderText = "Mã BH",
                DataPropertyName = "MaPhieuBH",
                FillWeight = 35
            });

            dgvBaoHanhSapHetDashboard.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colKhachHang",
                HeaderText = "Khách hàng",
                DataPropertyName = "TenKhachHang",
                FillWeight = 42
            });

            dgvBaoHanhSapHetDashboard.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNgayHetHan",
                HeaderText = "Hết hạn",
                DataPropertyName = "NgayHetHanBH",
                FillWeight = 28
            });

            dgvBaoHanhSapHetDashboard.CellFormatting -= dgvBaoHanhSapHetDashboard_CellFormatting;
            dgvBaoHanhSapHetDashboard.CellFormatting += dgvBaoHanhSapHetDashboard_CellFormatting;
        }

        // =====================================================
        // 5. CẤU HÌNH BẢNG HOẠT ĐỘNG GẦN ĐÂY
        // =====================================================
        private void CauHinhDgvHoatDongGanDay()
        {
            dgvHoatDongGanDayDashboard.Columns.Clear();

            dgvHoatDongGanDayDashboard.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colThoiGian",
                HeaderText = "Thời gian",
                DataPropertyName = "ThoiGian",
                FillWeight = 35
            });

            dgvHoatDongGanDayDashboard.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNoiDung",
                HeaderText = "Nội dung",
                DataPropertyName = "NoiDung",
                FillWeight = 65
            });

            dgvHoatDongGanDayDashboard.CellFormatting -= dgvHoatDongGanDayDashboard_CellFormatting;
            dgvHoatDongGanDayDashboard.CellFormatting += dgvHoatDongGanDayDashboard_CellFormatting;
        }

        // =====================================================
        // 6. LOAD DASHBOARD
        // =====================================================
        private void LoadDashboard()
        {
            try
            {
                lblNgayHienTai.Text = DateTime.Now.ToString("dd/MM/yyyy");

                if (string.IsNullOrWhiteSpace(UserSession.ChiNhanhDuocChon))
                {
                    ResetDashboard();
                    return;
                }

                string maCN = UserSession.ChiNhanhDuocChon;

                LoadTongQuan(maCN);
                LoadTopSanPham(maCN);
                LoadDoanhThuTheoThang(maCN);
                LoadCanhBaoTonKho(maCN);
                LoadBaoHanhSapHet(maCN);
                LoadHoatDongGanDay(maCN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải Dashboard: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadTongQuan(string maCN)
        {
            DashboardTongQuanViewModel tongQuan = _bus.GetDashboardTongQuan(maCN);

            lblDoanhThuThangNay.Text = tongQuan.DoanhThuThangNay.ToString("N0") + " đ";
            lblDonHangHomNay.Text = tongQuan.DonHangHomNay.ToString("N0");
            lblTongKhachHang.Text = tongQuan.TongKhachHang.ToString("N0");
            lblSanPhamSapHet.Text = tongQuan.SanPhamSapHet.ToString("N0");
        }

        private void LoadTopSanPham(string maCN)
        {
            DateTime today = DateTime.Today;
            DateTime dauThang = new DateTime(today.Year, today.Month, 1);
            DateTime cuoiThang = dauThang.AddMonths(1).AddDays(-1);

            // Dashboard chỉ nên xem nhanh 3 dòng
            var ds = _bus.GetTopSanPhamBanChay(maCN, dauThang, cuoiThang, 3);

            dgvTopSanPhamDashboard.DataSource = null;
            dgvTopSanPhamDashboard.DataSource = ds;
        }

        private void LoadDoanhThuTheoThang(string maCN)
        {
            int nam = DateTime.Now.Year;
            var ds = _bus.GetDoanhThuTheoThang(maCN, nam);

            VeBieuDoDoanhThuTheoThang(ds);
        }

        private void LoadCanhBaoTonKho(string maCN)
        {
            // Dashboard chỉ nên xem nhanh 3 dòng
            var ds = _bus.GetCanhBaoTonKhoDashboard(maCN, 3);

            dgvCanhBaoTonKhoDashboard.DataSource = null;
            dgvCanhBaoTonKhoDashboard.DataSource = ds;
        }

        private void LoadBaoHanhSapHet(string maCN)
        {
            // Lấy bảo hành sắp hết trong 30 ngày tới, hiển thị 3 dòng
            var ds = _bus.GetBaoHanhSapHetDashboard(maCN, 30, 3);

            dgvBaoHanhSapHetDashboard.DataSource = null;
            dgvBaoHanhSapHetDashboard.DataSource = ds;
        }

        private void LoadHoatDongGanDay(string maCN)
        {
            // Dashboard chỉ nên xem nhanh 3 dòng
            var ds = _bus.GetHoatDongGanDayDashboard(maCN, 3);

            dgvHoatDongGanDayDashboard.DataSource = null;
            dgvHoatDongGanDayDashboard.DataSource = ds;
        }

        // =====================================================
        // 7. BIỂU ĐỒ DOANH THU THEO THÁNG
        // =====================================================
        private void VeBieuDoDoanhThuTheoThang(List<DoanhThuViewModel> ds)
        {
            pnlDoanhThuTheoThang.Controls.Clear();

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;
            chart.Margin = new Padding(0);
            chart.Padding = new Padding(0);

            ChartArea area = new ChartArea("DoanhThuTheoThangArea");
            area.AxisX.Title = "";
            area.AxisY.Title = "";
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisY.LabelStyle.Format = "N0";
            area.Position.Auto = true;

            chart.ChartAreas.Add(area);

            Series series = new Series("Doanh thu");
            series.ChartType = SeriesChartType.Column;
            series.XValueType = ChartValueType.String;
            series.YValueType = ChartValueType.Double;

            if (ds != null)
            {
                foreach (var item in ds)
                {
                    series.Points.AddXY(item.ThoiGian, Convert.ToDouble(item.DoanhThu));
                }
            }

            chart.Series.Add(series);

            // Không thêm Legend để biểu đồ đỡ chiếm chỗ
            pnlDoanhThuTheoThang.Controls.Add(chart);
        }

        // =====================================================
        // 8. FORMAT DATAGRIDVIEW
        // =====================================================
        private void dgvBaoHanhSapHetDashboard_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string propName = dgvBaoHanhSapHetDashboard.Columns[e.ColumnIndex].DataPropertyName;

            if (propName == "NgayHetHanBH")
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime ngay))
                {
                    e.Value = ngay.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvHoatDongGanDayDashboard_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string propName = dgvHoatDongGanDayDashboard.Columns[e.ColumnIndex].DataPropertyName;

            if (propName == "ThoiGian")
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime ngay))
                {
                    e.Value = ngay.ToString("dd/MM HH:mm");
                    e.FormattingApplied = true;
                }
            }
        }

        // =====================================================
        // 9. RESET DASHBOARD
        // =====================================================
        private void ResetDashboard()
        {
            lblDoanhThuThangNay.Text = "0 đ";
            lblDonHangHomNay.Text = "0";
            lblTongKhachHang.Text = "0";
            lblSanPhamSapHet.Text = "0";

            dgvTopSanPhamDashboard.DataSource = null;
            dgvCanhBaoTonKhoDashboard.DataSource = null;
            dgvBaoHanhSapHetDashboard.DataSource = null;
            dgvHoatDongGanDayDashboard.DataSource = null;

            pnlDoanhThuTheoThang.Controls.Clear();
        }
    }
}