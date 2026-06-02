using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class UC_KhachHang : UserControl
    {
        private KhachHangBUS _bus = new KhachHangBUS();
        private bool isAdding = false;

        public UC_KhachHang()
        {
            InitializeComponent();
        }

        // ==========================================
        // 1. LOAD DỮ LIỆU KHI MỞ FORM
        // ==========================================
        private void UC_KhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.AutoGenerateColumns = false;
            LoadData();

            txtMaKH.ReadOnly = true;
            txtMaKH.BackColor = System.Drawing.SystemColors.Control;

            SetPlaceholderTimKiem();
        }

        private void LoadData()
        {
            dgvKhachHang.DataSource = _bus.GetAll();
        }

        // ==========================================
        // 2. TỰ ĐỘNG SINH MÃ KHÁCH HÀNG
        // ==========================================
        private string TaoMaKhachHangTuDong()
        {
            string maMoi;
            int dem = 0;

            do
            {
                // Ví dụ: KH260523001530
                maMoi = "KH" + DateTime.Now.AddSeconds(dem).ToString("yyMMddHHmmss");
                dem++;
            }
            while (_bus.GetAll().Any(kh => kh.MaKH == maMoi));

            return maMoi;
        }

        // ==========================================
        // 3. CLICK VÀO LƯỚI DATAGRIDVIEW
        // ==========================================
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                KhachHang kh = dgvKhachHang.Rows[e.RowIndex].DataBoundItem as KhachHang;

                if (kh != null)
                {
                    txtMaKH.Text = kh.MaKH;
                    txtHoTen.Text = kh.HoTen;
                    txtSDT.Text = kh.SDT;
                    txtDiaChi.Text = kh.DiaChi;

                    lblSoLanMua.Text = kh.SoLanMua.ToString();
                    lblTongChiTieu.Text = kh.TongChiTieu.ToString("N0") + " VNĐ";

                    isAdding = false;

                    txtMaKH.ReadOnly = true;
                    txtMaKH.BackColor = System.Drawing.SystemColors.Control;
                }
            }
        }

        // ==========================================
        // 4. NÚT THÊM KHÁCH HÀNG
        // ==========================================
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            isAdding = true;

            txtMaKH.Text = TaoMaKhachHangTuDong();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();

            lblSoLanMua.Text = "0";
            lblTongChiTieu.Text = "0 VNĐ";

            txtMaKH.ReadOnly = true;
            txtMaKH.BackColor = System.Drawing.SystemColors.Control;

            txtHoTen.Focus();
        }

        // ==========================================
        // 5. LÀM TRỐNG FORM
        // ==========================================
        private void btnLamTrong_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();

            lblSoLanMua.Text = "0";
            lblTongChiTieu.Text = "0 VNĐ";

            isAdding = false;

            txtMaKH.ReadOnly = true;
            txtMaKH.BackColor = System.Drawing.SystemColors.Control;
        }

        // ==========================================
        // 6. LƯU KHÁCH HÀNG MỚI
        // ==========================================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!isAdding)
            {
                MessageBox.Show(
                    "Vui lòng bấm [Thêm KH] trước khi lưu khách hàng mới.\nNếu muốn cập nhật khách hàng hiện tại, hãy dùng nút [Sửa].",
                    "Hướng dẫn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                txtMaKH.Text = TaoMaKhachHangTuDong();
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên khách hàng không được để trống!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                string sdt = txtSDT.Text.Trim();

                if (!sdt.All(char.IsDigit) || sdt.Length < 9 || sdt.Length > 11)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập từ 9 đến 11 chữ số.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }

                bool sdtDaTonTai = _bus.GetAll()
                    .Any(kh => kh.SDT == sdt && kh.MaKH != txtMaKH.Text.Trim());

                if (sdtDaTonTai)
                {
                    MessageBox.Show("Số điện thoại này đã tồn tại trong danh sách khách hàng.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }
            }

            KhachHang kh = new KhachHang
            {
                MaKH = txtMaKH.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                SoLanMua = 0,
                TongChiTieu = 0
            };

            if (_bus.Them(kh))
            {
                MessageBox.Show("Thêm khách hàng thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                btnLamTrong_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Lỗi! Mã khách hàng này đã tồn tại hoặc không thể thêm khách hàng.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // 7. SỬA KHÁCH HÀNG
        // ==========================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng từ danh sách để sửa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên khách hàng không được để trống!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                string sdt = txtSDT.Text.Trim();

                if (!sdt.All(char.IsDigit) || sdt.Length < 9 || sdt.Length > 11)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập từ 9 đến 11 chữ số.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }

                bool sdtDaTonTai = _bus.GetAll()
                    .Any(kh => kh.SDT == sdt && kh.MaKH != txtMaKH.Text.Trim());

                if (sdtDaTonTai)
                {
                    MessageBox.Show("Số điện thoại này đã thuộc về khách hàng khác.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }
            }

            KhachHang khCapNhat = new KhachHang
            {
                MaKH = txtMaKH.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim()
            };

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn cập nhật thông tin cho khách hàng [{khCapNhat.HoTen}] không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (_bus.Sua(khCapNhat))
                {
                    MessageBox.Show("Cập nhật thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                    btnLamTrong_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // 8. XÓA KHÁCH HÀNG
        // ==========================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa khỏi danh mục!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKH = txtMaKH.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khách hàng [{hoTen}] khỏi danh mục không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                if (_bus.Xoa(maKH))
                {
                    MessageBox.Show("Đã xóa khách hàng khỏi danh mục.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                    btnLamTrong_Click(sender, e);
                }
                else
                {
                    MessageBox.Show(
                        "Khách hàng này đã có dữ liệu mua hàng, bảo hành hoặc chăm sóc khách hàng liên quan nên không thể xóa khỏi danh mục.\n" +
                        "Hệ thống cần giữ lại thông tin khách hàng để tra cứu lịch sử nghiệp vụ.",
                        "Không thể xóa khách hàng",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xử lý khách hàng này. Chi tiết lỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // 9. LÀM MỚI
        // ==========================================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            SetPlaceholderTimKiem();
            LoadData();
            btnLamTrong_Click(sender, e);
        }

        // ==========================================
        // 10. PLACEHOLDER TÌM KIẾM
        // ==========================================
        private void SetPlaceholderTimKiem()
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Tìm tên hoặc số điện thoại...";
                txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm tên hoặc số điện thoại...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            SetPlaceholderTimKiem();
        }

        // ==========================================
        // 11. HỖ TRỢ TÌM KIẾM KHÔNG DẤU
        // ==========================================
        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";

            var normalizedString = text.Normalize(System.Text.NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);

                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString()
                .Normalize(System.Text.NormalizationForm.FormC)
                .Replace("đ", "d")
                .Replace("Đ", "D");
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword) || keyword == "Tìm tên hoặc số điện thoại...")
            {
                LoadData();
                return;
            }

            string keywordUnsign = RemoveDiacritics(keyword).ToLower();

            var ds = _bus.GetAll();

            dgvKhachHang.DataSource = ds.Where(k =>
                (k.MaKH != null && RemoveDiacritics(k.MaKH).ToLower().Contains(keywordUnsign)) ||
                (k.HoTen != null && RemoveDiacritics(k.HoTen).ToLower().Contains(keywordUnsign)) ||
                (k.SDT != null && k.SDT.Contains(keywordUnsign)) ||
                (k.DiaChi != null && RemoveDiacritics(k.DiaChi).ToLower().Contains(keywordUnsign))
            ).ToList();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}