using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_CanhBaoKho : UserControl, IBranchRefreshable
    {
        private SanPhamBUS _spBus = new SanPhamBUS();

        private List<CanhBaoKhoViewModel> _dsCanhBaoGoc = new List<CanhBaoKhoViewModel>();

        public UC_CanhBaoKho()
        {
            InitializeComponent();
        }

        private void UC_CanhBaoKho_Load(object sender, EventArgs e)
        {
            CauHinhDataGridView();
            CauHinhComboBoxLoc();

            LoadData();
        }

        // Hàm này dùng cho FormMain gọi khi đổi chi nhánh
        public void RefreshByBranch()
        {
            LoadData();
        }

        private void CauHinhDataGridView()
        {
            dgvCanhBaoKho.AutoGenerateColumns = false;
            dgvCanhBaoKho.AllowUserToAddRows = false;
            dgvCanhBaoKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCanhBaoKho.MultiSelect = false;
            dgvCanhBaoKho.ReadOnly = false;
            dgvCanhBaoKho.BackgroundColor = Color.White;
            dgvCanhBaoKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCanhBaoKho.Columns.Clear();

            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn();
            colSTT.Name = "colSTT";
            colSTT.HeaderText = "";
            colSTT.Width = 40;
            colSTT.ReadOnly = true;
            dgvCanhBaoKho.Columns.Add(colSTT);

            DataGridViewCheckBoxColumn colChon = new DataGridViewCheckBoxColumn();
            colChon.Name = "colChon";
            colChon.HeaderText = "";
            colChon.Width = 50;
            colChon.ReadOnly = false;
            dgvCanhBaoKho.Columns.Add(colChon);

            DataGridViewTextBoxColumn colMaSP = new DataGridViewTextBoxColumn();
            colMaSP.Name = "colMaSP";
            colMaSP.HeaderText = "Mã SP";
            colMaSP.DataPropertyName = "MaSP";
            colMaSP.ReadOnly = true;
            dgvCanhBaoKho.Columns.Add(colMaSP);

            DataGridViewTextBoxColumn colTenSP = new DataGridViewTextBoxColumn();
            colTenSP.Name = "colTenSP";
            colTenSP.HeaderText = "Tên SP";
            colTenSP.DataPropertyName = "TenSP";
            colTenSP.ReadOnly = true;
            dgvCanhBaoKho.Columns.Add(colTenSP);

            DataGridViewTextBoxColumn colHang = new DataGridViewTextBoxColumn();
            colHang.Name = "colHang";
            colHang.HeaderText = "Hãng";
            colHang.DataPropertyName = "TenHang";
            colHang.ReadOnly = true;
            dgvCanhBaoKho.Columns.Add(colHang);

            DataGridViewTextBoxColumn colTonKho = new DataGridViewTextBoxColumn();
            colTonKho.Name = "colTonKho";
            colTonKho.HeaderText = "Tồn kho";
            colTonKho.DataPropertyName = "TonKho";
            colTonKho.ReadOnly = true;
            dgvCanhBaoKho.Columns.Add(colTonKho);

            DataGridViewTextBoxColumn colMucCanhBao = new DataGridViewTextBoxColumn();
            colMucCanhBao.Name = "colMucCanhBao";
            colMucCanhBao.HeaderText = "Mức cảnh báo";
            colMucCanhBao.DataPropertyName = "MucCanhBao";
            colMucCanhBao.ReadOnly = true;
            dgvCanhBaoKho.Columns.Add(colMucCanhBao);

            DataGridViewButtonColumn colNhapKho = new DataGridViewButtonColumn();
            colNhapKho.Name = "colNhapKho";
            colNhapKho.HeaderText = "Thao tác";
            colNhapKho.Text = "Nhập kho";
            colNhapKho.UseColumnTextForButtonValue = true;
            dgvCanhBaoKho.Columns.Add(colNhapKho);

            dgvCanhBaoKho.CellFormatting -= dgvCanhBaoKho_CellFormatting;
            dgvCanhBaoKho.CellFormatting += dgvCanhBaoKho_CellFormatting;

            dgvCanhBaoKho.CellContentClick -= dgvCanhBaoKho_CellContentClick;
            dgvCanhBaoKho.CellContentClick += dgvCanhBaoKho_CellContentClick;
        }

        private void CauHinhComboBoxLoc()
        {
            cboLocCanhBao.DropDownStyle = ComboBoxStyle.DropDownList;

            cboLocCanhBao.Items.Clear();
            cboLocCanhBao.Items.Add("Tất cả");
            cboLocCanhBao.Items.Add("Nguy hiểm");
            cboLocCanhBao.Items.Add("Sắp hết");
            cboLocCanhBao.Items.Add("Bình thường");

            cboLocCanhBao.SelectedIndex = 0;

            cboLocCanhBao.SelectedIndexChanged -= cboLocCanhBao_SelectedIndexChanged;
            cboLocCanhBao.SelectedIndexChanged += cboLocCanhBao_SelectedIndexChanged;
        }

        private void LoadData()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(UserSession.ChiNhanhDuocChon))
                {
                    MessageBox.Show(
                        "Chưa xác định được chi nhánh đang làm việc. Vui lòng chọn chi nhánh ở góc trái.",
                        "Thiếu chi nhánh",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                var dsSP = _spBus.GetByBranch(UserSession.ChiNhanhDuocChon);

                _dsCanhBaoGoc = dsSP.Select(sp => new CanhBaoKhoViewModel
                {
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    MaHang = sp.MaHang,
                    TenHang = sp.HangSanXuat != null ? sp.HangSanXuat.TenHang : sp.MaHang,
                    TonKho = sp.TonKho,
                    MucCanhBao = LayMucCanhBao(sp.TonKho)
                }).ToList();

                CapNhatThongKe();
                ApDungBoLoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải dữ liệu cảnh báo kho: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private string LayMucCanhBao(int tonKho)
        {
            if (tonKho <= 2)
                return "Nguy hiểm";

            if (tonKho >= 3 && tonKho <= 4)
                return "Sắp hết";

            return "Bình thường";
        }

        private void CapNhatThongKe()
        {
            int soNguyHiem = _dsCanhBaoGoc.Count(x => x.MucCanhBao == "Nguy hiểm");
            int soSapHet = _dsCanhBaoGoc.Count(x => x.MucCanhBao == "Sắp hết");
            int soBinhThuong = _dsCanhBaoGoc.Count(x => x.MucCanhBao == "Bình thường");

            lblNguyHiem.Text = soNguyHiem + " SP";
            lblSapHet.Text = soSapHet + " SP";
            lblBinhThuong.Text = soBinhThuong + " SP";
        }

        private void ApDungBoLoc()
        {
            if (_dsCanhBaoGoc == null)
                return;

            string loc = cboLocCanhBao.Text.Trim();

            List<CanhBaoKhoViewModel> dsHienThi = _dsCanhBaoGoc;

            if (loc == "Nguy hiểm")
            {
                dsHienThi = _dsCanhBaoGoc.Where(x => x.MucCanhBao == "Nguy hiểm").ToList();
            }
            else if (loc == "Sắp hết")
            {
                dsHienThi = _dsCanhBaoGoc.Where(x => x.MucCanhBao == "Sắp hết").ToList();
            }
            else if (loc == "Bình thường")
            {
                dsHienThi = _dsCanhBaoGoc.Where(x => x.MucCanhBao == "Bình thường").ToList();
            }

            dgvCanhBaoKho.DataSource = null;
            dgvCanhBaoKho.DataSource = dsHienThi;
        }

        private void dgvCanhBaoKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvCanhBaoKho.Columns[e.ColumnIndex].Name == "colSTT")
            {
                e.Value = (e.RowIndex + 1).ToString();
                e.FormattingApplied = true;
            }

            var rowData = dgvCanhBaoKho.Rows[e.RowIndex].DataBoundItem as CanhBaoKhoViewModel;
            if (rowData == null)
                return;

            if (rowData.MucCanhBao == "Nguy hiểm")
            {
                dgvCanhBaoKho.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                dgvCanhBaoKho.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
            }
            else if (rowData.MucCanhBao == "Sắp hết")
            {
                dgvCanhBaoKho.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                dgvCanhBaoKho.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkOrange;
            }
            else
            {
                dgvCanhBaoKho.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Honeydew;
                dgvCanhBaoKho.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
            }
        }

        private void dgvCanhBaoKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvCanhBaoKho.Columns[e.ColumnIndex].Name == "colNhapKho")
            {
                var sp = dgvCanhBaoKho.Rows[e.RowIndex].DataBoundItem as CanhBaoKhoViewModel;
                if (sp == null)
                    return;

                DialogResult result = MessageBox.Show(
                    $"Bạn muốn chuyển sang màn hình Nhập hàng / lô để nhập thêm sản phẩm này không?\n\n" +
                    $"Mã SP: {sp.MaSP}\n" +
                    $"Tên SP: {sp.TenSP}\n" +
                    $"Tồn kho hiện tại: {sp.TonKho}",
                    "Xác nhận nhập kho",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    FormMain formMain = this.FindForm() as FormMain;

                    if (formMain != null)
                    {
                        formMain.MoNhapHangTheoSanPham(sp.MaSP);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Không tìm thấy FormMain để chuyển màn hình.",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cboLocCanhBao_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApDungBoLoc();
        }

        private void btnNhapKhoHangLoat_Click(object sender, EventArgs e)
        {
            var dsChon = new List<CanhBaoKhoViewModel>();

            foreach (DataGridViewRow row in dgvCanhBaoKho.Rows)
            {
                bool isChecked = false;

                if (row.Cells["colChon"].Value != null)
                {
                    bool.TryParse(row.Cells["colChon"].Value.ToString(), out isChecked);
                }

                if (isChecked && row.DataBoundItem is CanhBaoKhoViewModel sp)
                {
                    dsChon.Add(sp);
                }
            }

            if (!dsChon.Any())
            {
                MessageBox.Show(
                    "Vui lòng chọn ít nhất một sản phẩm cần nhập kho.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            string danhSach = string.Join("\n", dsChon.Select(x => "- " + x.MaSP + " | " + x.TenSP + " | Tồn: " + x.TonKho));

            MessageBox.Show(
                "Danh sách sản phẩm cần nhập kho:\n\n" + danhSach + "\n\nBạn hãy chuyển sang màn hình Nhập hàng / lô để lập phiếu nhập.",
                "Nhập kho hàng loạt",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }

    public class CanhBaoKhoViewModel
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public int TonKho { get; set; }
        public string MucCanhBao { get; set; }
    }
}