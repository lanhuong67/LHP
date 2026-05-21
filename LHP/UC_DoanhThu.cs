using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class UC_DoanhThu : UserControl, IBranchRefreshable
    {
        private BaoCaoBUS _bus = new BaoCaoBUS();

        public UC_DoanhThu()
        {
            InitializeComponent();
            this.Load += UC_DoanhThu_Load;
        }

        private void UC_DoanhThu_Load(object sender, EventArgs e)
        {
            KhoiTaoComboBox();
            CauHinhDataGridView();
            GanSuKien();
            LoadBaoCao();
        }

        // Tự reload khi Admin đổi chi nhánh ở FormMain
        public void RefreshByBranch()
        {
            LoadBaoCao();
        }

        private void KhoiTaoComboBox()
        {
            cboKieuBaoCao.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNam.DropDownStyle = ComboBoxStyle.DropDownList;

            cboKieuBaoCao.Items.Clear();
            cboKieuBaoCao.Items.Add("Theo ngày");
            cboKieuBaoCao.Items.Add("Theo tháng");
            cboKieuBaoCao.Items.Add("Theo năm");
            cboKieuBaoCao.SelectedIndex = 0;

            cboThang.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add("Tháng " + i);
            }
            cboThang.SelectedIndex = DateTime.Now.Month - 1;

            cboNam.Items.Clear();
            int namHienTai = DateTime.Now.Year;

            for (int nam = namHienTai - 5; nam <= namHienTai + 1; nam++)
            {
                cboNam.Items.Add(nam.ToString());
            }

            cboNam.SelectedItem = namHienTai.ToString();

            DieuChinhComboBoxTheoKieuBaoCao();
        }

        private void CauHinhDataGridView()
        {
            dgvDoanhThu.AutoGenerateColumns = false;
            dgvDoanhThu.Columns.Clear();

            DataGridViewTextBoxColumn colThoiGian = new DataGridViewTextBoxColumn();
            colThoiGian.Name = "colThoiGian";
            colThoiGian.HeaderText = "Thời gian";
            colThoiGian.DataPropertyName = "ThoiGian";
            colThoiGian.Width = 300;
            dgvDoanhThu.Columns.Add(colThoiGian);

            DataGridViewTextBoxColumn colSoHoaDon = new DataGridViewTextBoxColumn();
            colSoHoaDon.Name = "colSoHoaDon";
            colSoHoaDon.HeaderText = "Số hóa đơn";
            colSoHoaDon.DataPropertyName = "SoHoaDon";
            colSoHoaDon.Width = 250;
            dgvDoanhThu.Columns.Add(colSoHoaDon);

            DataGridViewTextBoxColumn colDoanhThu = new DataGridViewTextBoxColumn();
            colDoanhThu.Name = "colDoanhThu";
            colDoanhThu.HeaderText = "Doanh thu";
            colDoanhThu.DataPropertyName = "DoanhThu";
            colDoanhThu.Width = 300;
            dgvDoanhThu.Columns.Add(colDoanhThu);

            dgvDoanhThu.CellFormatting -= dgvDoanhThu_CellFormatting;
            dgvDoanhThu.CellFormatting += dgvDoanhThu_CellFormatting;
        }

        private void GanSuKien()
        {

            cboKieuBaoCao.SelectedIndexChanged -= cboKieuBaoCao_SelectedIndexChanged;
            cboKieuBaoCao.SelectedIndexChanged += cboKieuBaoCao_SelectedIndexChanged;

            cboThang.SelectedIndexChanged -= cboThang_SelectedIndexChanged;
            cboThang.SelectedIndexChanged += cboThang_SelectedIndexChanged;

            cboNam.SelectedIndexChanged -= cboNam_SelectedIndexChanged;
            cboNam.SelectedIndexChanged += cboNam_SelectedIndexChanged;
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            LoadBaoCao();
        }

        private void cboKieuBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            DieuChinhComboBoxTheoKieuBaoCao();
            LoadBaoCao();
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKieuBaoCao.SelectedIndex >= 0)
                LoadBaoCao();
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKieuBaoCao.SelectedIndex >= 0)
                LoadBaoCao();
        }

        private void DieuChinhComboBoxTheoKieuBaoCao()
        {
            string kieu = cboKieuBaoCao.Text;

            if (kieu == "Theo ngày")
            {
                cboThang.Enabled = true;
                cboNam.Enabled = true;
            }
            else if (kieu == "Theo tháng")
            {
                cboThang.Enabled = false;
                cboNam.Enabled = true;
            }
            else if (kieu == "Theo năm")
            {
                cboThang.Enabled = false;
                cboNam.Enabled = false;
            }
        }

        private void LoadBaoCao()
        {
            try
            {
                if (cboKieuBaoCao.SelectedIndex < 0) return;

                if (string.IsNullOrWhiteSpace(UserSession.ChiNhanhDuocChon))
                {
                    dgvDoanhThu.DataSource = null;
                    ResetTongQuan();
                    VeBieuDo(new List<DoanhThuViewModel>());
                    return;
                }

                string maCN = UserSession.ChiNhanhDuocChon;
                string kieu = cboKieuBaoCao.Text;

                List<DoanhThuViewModel> ds = new List<DoanhThuViewModel>();

                if (kieu == "Theo ngày")
                {
                    int thang = cboThang.SelectedIndex + 1;
                    int nam = LayNamDangChon();

                    DateTime tuNgay = new DateTime(nam, thang, 1);
                    DateTime denNgay = tuNgay.AddMonths(1).AddDays(-1);

                    ds = _bus.GetDoanhThuTheoNgay(maCN, tuNgay, denNgay);
                }
                else if (kieu == "Theo tháng")
                {
                    int nam = LayNamDangChon();
                    ds = _bus.GetDoanhThuTheoThang(maCN, nam);
                }
                else if (kieu == "Theo năm")
                {
                    ds = _bus.GetDoanhThuTheoNam(maCN);
                }

                dgvDoanhThu.DataSource = null;
                dgvDoanhThu.DataSource = ds;

                HienThiTongQuan(ds);
                VeBieuDo(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải báo cáo doanh thu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private int LayNamDangChon()
        {
            if (cboNam.SelectedItem == null)
                return DateTime.Now.Year;

            if (int.TryParse(cboNam.SelectedItem.ToString(), out int nam))
                return nam;

            return DateTime.Now.Year;
        }

        private void HienThiTongQuan(List<DoanhThuViewModel> ds)
        {
            TongQuanDoanhThuViewModel tongQuan = _bus.TinhTongQuan(ds);

            lblTongDoanhThu.Text = tongQuan.TongDoanhThu.ToString("N0") + " đ";
            lblSoHoaDon.Text = tongQuan.SoHoaDon.ToString("N0");
            lblTrungBinhHoaDon.Text = tongQuan.TrungBinhHoaDon.ToString("N0") + " đ/đơn";
        }

        private void ResetTongQuan()
        {
            lblTongDoanhThu.Text = "0 đ";
            lblSoHoaDon.Text = "0";
            lblTrungBinhHoaDon.Text = "0 đ/đơn";
        }

        private void dgvDoanhThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string propName = dgvDoanhThu.Columns[e.ColumnIndex].DataPropertyName;

            if (propName == "DoanhThu")
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = value.ToString("N0") + " đ";
                    e.FormattingApplied = true;
                }
            }
        }

        private void VeBieuDo(List<DoanhThuViewModel> ds)
        {
            try
            {
                pnlBieuDoDoanhThu.Controls.Clear();

                Label lblTitle = new Label();
                lblTitle.Text = "Biểu đồ doanh thu";
                lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lblTitle.AutoSize = true;
                lblTitle.Location = new Point(10, 10);
                pnlBieuDoDoanhThu.Controls.Add(lblTitle);

                if (ds == null || ds.Count == 0)
                {
                    Label lblEmpty = new Label();
                    lblEmpty.Text = "Không có dữ liệu doanh thu để hiển thị.";
                    lblEmpty.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                    lblEmpty.AutoSize = true;
                    lblEmpty.Location = new Point(10, 45);
                    pnlBieuDoDoanhThu.Controls.Add(lblEmpty);
                    return;
                }

                Chart chart = new Chart();
                chart.Dock = DockStyle.Fill;
                chart.Padding = new Padding(5, 35, 5, 5);

                ChartArea chartArea = new ChartArea("DoanhThuArea");
                chartArea.AxisX.Title = "Thời gian";
                chartArea.AxisY.Title = "Doanh thu";
                chartArea.AxisX.Interval = 1;
                chartArea.AxisX.LabelStyle.Angle = -30;
                chartArea.AxisY.LabelStyle.Format = "N0";
                chart.ChartAreas.Add(chartArea);

                Series series = new Series("Doanh thu");
                series.ChartType = SeriesChartType.Column;
                series.XValueType = ChartValueType.String;
                series.YValueType = ChartValueType.Double;

                foreach (var item in ds)
                {
                    series.Points.AddXY(item.ThoiGian, Convert.ToDouble(item.DoanhThu));
                }

                chart.Series.Add(series);

                Legend legend = new Legend();
                legend.Docking = Docking.Bottom;
                chart.Legends.Add(legend);

                pnlBieuDoDoanhThu.Controls.Add(chart);
                chart.BringToFront();
            }
            catch
            {
                // Nếu máy chưa hỗ trợ Chart hoặc lỗi giao diện thì bỏ qua,
                // phần bảng và tổng doanh thu vẫn chạy bình thường.
            }
        }
    }
}