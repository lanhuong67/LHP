using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class UC_TopBanChay : UserControl, IBranchRefreshable
    {
        private BaoCaoBUS _bus = new BaoCaoBUS();

        public UC_TopBanChay()
        {
            InitializeComponent();
            this.Load += UC_TopBanChay_Load;
        }

        private void UC_TopBanChay_Load(object sender, EventArgs e)
        {
            KhoiTaoComboBox();
            CauHinhDataGridView();
            GanSuKien();
            LoadTopBanChay();
        }

        // =====================================================
        // TỰ RELOAD KHI ĐỔI CHI NHÁNH Ở FORMMAIN
        // =====================================================
        public void RefreshByBranch()
        {
            LoadTopBanChay();
        }

        // =====================================================
        // 1. KHỞI TẠO COMBOBOX
        // =====================================================
        private void KhoiTaoComboBox()
        {
            cboThoiGian.DropDownStyle = ComboBoxStyle.DropDownList;

            cboThoiGian.Items.Clear();
            cboThoiGian.Items.Add("Hôm nay");
            cboThoiGian.Items.Add("Tháng này");
            cboThoiGian.Items.Add("Năm này");
            cboThoiGian.Items.Add("Tất cả");

            cboThoiGian.SelectedIndex = 1; // Mặc định xem tháng này
        }

        // =====================================================
        // 2. CẤU HÌNH DATAGRIDVIEW
        // =====================================================
        private void CauHinhDataGridView()
        {
            dgvTopBanChay.AutoGenerateColumns = false;
            dgvTopBanChay.Columns.Clear();

            DataGridViewTextBoxColumn colHang = new DataGridViewTextBoxColumn();
            colHang.Name = "colHang";
            colHang.HeaderText = "Hạng";
            colHang.DataPropertyName = "Hang";
            colHang.Width = 80;
            dgvTopBanChay.Columns.Add(colHang);

            DataGridViewTextBoxColumn colSanPham = new DataGridViewTextBoxColumn();
            colSanPham.Name = "colSanPham";
            colSanPham.HeaderText = "Sản phẩm";
            colSanPham.DataPropertyName = "TenSP";
            colSanPham.Width = 280;
            dgvTopBanChay.Columns.Add(colSanPham);

            DataGridViewTextBoxColumn colHangSX = new DataGridViewTextBoxColumn();
            colHangSX.Name = "colHangSX";
            colHangSX.HeaderText = "Hãng";
            colHangSX.DataPropertyName = "TenHang";
            colHangSX.Width = 180;
            dgvTopBanChay.Columns.Add(colHangSX);

            DataGridViewTextBoxColumn colSoLuongBan = new DataGridViewTextBoxColumn();
            colSoLuongBan.Name = "colSoLuongBan";
            colSoLuongBan.HeaderText = "Số lượng bán";
            colSoLuongBan.DataPropertyName = "SoLuongBan";
            colSoLuongBan.Width = 180;
            dgvTopBanChay.Columns.Add(colSoLuongBan);

            DataGridViewTextBoxColumn colDoanhThu = new DataGridViewTextBoxColumn();
            colDoanhThu.Name = "colDoanhThu";
            colDoanhThu.HeaderText = "Doanh thu";
            colDoanhThu.DataPropertyName = "DoanhThu";
            colDoanhThu.Width = 220;
            dgvTopBanChay.Columns.Add(colDoanhThu);

            dgvTopBanChay.CellFormatting -= dgvTopBanChay_CellFormatting;
            dgvTopBanChay.CellFormatting += dgvTopBanChay_CellFormatting;
        }

        // =====================================================
        // 3. GẮN SỰ KIỆN
        // =====================================================
        private void GanSuKien()
        {
            btnXem.Click -= btnXem_Click;
            btnXem.Click += btnXem_Click;

            cboThoiGian.SelectedIndexChanged -= cboThoiGian_SelectedIndexChanged;
            cboThoiGian.SelectedIndexChanged += cboThoiGian_SelectedIndexChanged;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadTopBanChay();
        }

        private void cboThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThoiGian.SelectedIndex >= 0)
            {
                LoadTopBanChay();
            }
        }

        // =====================================================
        // 4. LOAD TOP BÁN CHẠY
        // =====================================================
        private void LoadTopBanChay()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(UserSession.ChiNhanhDuocChon))
                {
                    dgvTopBanChay.DataSource = null;
                    return;
                }

                string maCN = UserSession.ChiNhanhDuocChon;

                DateTime? tuNgay = null;
                DateTime? denNgay = null;

                LayKhoangThoiGian(out tuNgay, out denNgay);

                List<TopSanPhamBanChayViewModel> ds = _bus.GetTopSanPhamBanChay(
                    maCN,
                    tuNgay,
                    denNgay,
                    10
                );

                dgvTopBanChay.DataSource = null;
                dgvTopBanChay.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải top sản phẩm bán chạy: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // 5. LẤY KHOẢNG THỜI GIAN THEO COMBOBOX
        // =====================================================
        private void LayKhoangThoiGian(out DateTime? tuNgay, out DateTime? denNgay)
        {
            tuNgay = null;
            denNgay = null;

            string luaChon = cboThoiGian.Text;
            DateTime today = DateTime.Today;

            if (luaChon == "Hôm nay")
            {
                tuNgay = today;
                denNgay = today;
            }
            else if (luaChon == "Tháng này")
            {
                tuNgay = new DateTime(today.Year, today.Month, 1);
                denNgay = tuNgay.Value.AddMonths(1).AddDays(-1);
            }
            else if (luaChon == "Năm này")
            {
                tuNgay = new DateTime(today.Year, 1, 1);
                denNgay = new DateTime(today.Year, 12, 31);
            }
            else if (luaChon == "Tất cả")
            {
                tuNgay = null;
                denNgay = null;
            }
        }

        // =====================================================
        // 6. FORMAT TIỀN
        // =====================================================
        private void dgvTopBanChay_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string propName = dgvTopBanChay.Columns[e.ColumnIndex].DataPropertyName;

            if (propName == "DoanhThu")
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = value.ToString("N0") + " đ";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}