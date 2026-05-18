using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;
using BUS;
using DTO;
using QRCoder;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GUI
{
    public partial class UC_BaoHanh : UserControl
    {
        private BaoHanhBUS _bus = new BaoHanhBUS();
        private bool _isProcessingClick = false;
        private DateTime _lastClickTime = DateTime.MinValue;

        private List<SanPhamBaoHanhViewModel> _dsSanPham = new List<SanPhamBaoHanhViewModel>();
        private readonly string _placeholderTim = "Nhập mã HD hoặc SĐT khách hàng...";

        private List<TraCuuBaoHanhViewModel> _dsTraCuuFull = new List<TraCuuBaoHanhViewModel>();
        private readonly string _placeholderTraCuu = "Mã phiếu BH, tên KH, SĐT...";

        public UC_BaoHanh()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UC_BaoHanh_Load;

            cboThoiHan.SelectedIndexChanged += CapNhatNgayHetHan;
            dtpBatDau.ValueChanged += CapNhatNgayHetHan;
            cboDieuKien.SelectedIndexChanged += (s, ev) => CapNhatPreview();
            txtGhiChu.TextChanged += (s, ev) => CapNhatPreview();

            cboThoiHan.Click += (s, e) => { cboThoiHan.DroppedDown = true; };
            cboDieuKien.Click += (s, e) => { cboDieuKien.DroppedDown = true; };

            dgvSanPham.CellFormatting += dgvSanPham_CellFormatting;

            if (dgvSanPham != null)
            {
                for (int i = 0; i < 10; i++) dgvSanPham.CellContentClick -= dgvSanPham_CellContentClick;
                dgvSanPham.CellContentClick += dgvSanPham_CellContentClick;
            }

            if (btnTaoPhieu != null)
            {
                for (int i = 0; i < 10; i++) btnTaoPhieu.Click -= btnTaoPhieu_Click;
                btnTaoPhieu.Click += btnTaoPhieu_Click;
            }

            if (btnInPhieu != null)
            {
                for (int i = 0; i < 10; i++) btnInPhieu.Click -= btnInPhieu_Click;
                btnInPhieu.Click += btnInPhieu_Click;
            }

            if (cboTrangThaiTraCuu != null)
            {
                cboTrangThaiTraCuu.SelectedIndexChanged += cboTrangThaiTraCuu_SelectedIndexChanged;
                cboTrangThaiTraCuu.Click += (s, e) => { cboTrangThaiTraCuu.DroppedDown = true; };
            }

            if (dgvTraCuu != null)
            {
                dgvTraCuu.CellFormatting += dgvTraCuu_CellFormatting;
                for (int i = 0; i < 10; i++) dgvTraCuu.CellContentClick -= dgvTraCuu_CellContentClick;
                dgvTraCuu.CellContentClick += dgvTraCuu_CellContentClick;
            }
        }

        private void UC_BaoHanh_Load(object sender, EventArgs e)
        {
            dgvSanPham.AutoGenerateColumns = false; dgvSanPham.RowHeadersVisible = false; dgvSanPham.AllowUserToAddRows = false;
            if (dgvTraCuu != null) { dgvTraCuu.AutoGenerateColumns = false; dgvTraCuu.RowHeadersVisible = false; dgvTraCuu.AllowUserToAddRows = false; }

            if (cboThoiHan.Items.Count == 0) { cboThoiHan.Items.AddRange(new string[] { "1 tháng", "3 tháng", "6 tháng", "12 tháng", "24 tháng" }); cboThoiHan.SelectedIndex = 3; }
            if (cboDieuKien.Items.Count == 0) { cboDieuKien.Items.AddRange(new string[] { "Bảo hành nhà sản xuất", "Bảo hành VIP (Rơi vỡ)", "Sửa chữa dịch vụ (Hết hạn)" }); cboDieuKien.SelectedIndex = 0; }

            // 🔴 ĐÃ ĐỔI TÊN TRẠNG THÁI
            if (cboTrangThaiTraCuu != null && cboTrangThaiTraCuu.Items.Count == 0)
            {
                cboTrangThaiTraCuu.Items.AddRange(new string[] { "--Tất cả trạng thái--", "Đang hiệu lực", "Đã hết hạn", "Hủy/Từ chối" });
                cboTrangThaiTraCuu.SelectedIndex = 0;
            }

            dtpBatDau.Format = DateTimePickerFormat.Custom; dtpBatDau.CustomFormat = "dd/MM/yyyy";
            dtpHetHan.Format = DateTimePickerFormat.Custom; dtpHetHan.CustomFormat = "dd/MM/yyyy"; dtpHetHan.Enabled = false;

            SinhMaPhieuBaoHanh();
            KhoiTaoThanhTimKiemRealTime();
            CapNhatNgayHetHan(null, null);
            LoadDanhSachTraCuu();
        }

        private void SinhMaPhieuBaoHanh()
        {
            lblPrevMaBH.Text = "BH" + DateTime.Now.ToString("yyMMddHHmmss");
        }

        private void KhoiTaoThanhTimKiemRealTime()
        {
            if (txtTimKiemHD != null)
            {
                txtTimKiemHD.Text = _placeholderTim; txtTimKiemHD.ForeColor = Color.Gray;
                txtTimKiemHD.Enter += (s, e) => { if (txtTimKiemHD.Text == _placeholderTim) { txtTimKiemHD.Text = ""; txtTimKiemHD.ForeColor = Color.Black; } };
                txtTimKiemHD.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtTimKiemHD.Text)) { txtTimKiemHD.Text = _placeholderTim; txtTimKiemHD.ForeColor = Color.Gray; ResetThongTinBaoHanh(); } };
                txtTimKiemHD.TextChanged += txtTimKiemHD_TextChanged;
            }
            if (txtTimKiemTraCuu != null)
            {
                txtTimKiemTraCuu.Text = _placeholderTraCuu; txtTimKiemTraCuu.ForeColor = Color.Gray;
                txtTimKiemTraCuu.Enter += (s, e) => { if (txtTimKiemTraCuu.Text == _placeholderTraCuu) { txtTimKiemTraCuu.Text = ""; txtTimKiemTraCuu.ForeColor = Color.Black; } };
                txtTimKiemTraCuu.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtTimKiemTraCuu.Text)) { txtTimKiemTraCuu.Text = _placeholderTraCuu; txtTimKiemTraCuu.ForeColor = Color.Gray; HienThiDanhSachTraCuu(); } };
                txtTimKiemTraCuu.TextChanged += (s, e) => HienThiDanhSachTraCuu();
            }
        }

        private void txtTimKiemHD_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemHD.Text.Trim();
            if (string.IsNullOrWhiteSpace(tuKhoa) || tuKhoa == _placeholderTim) { ResetThongTinBaoHanh(); return; }
            if (tuKhoa.Length == 10 || tuKhoa.Length >= 12) ThucHienTimKiemBaoHanh(tuKhoa);
            else ResetThongTinBaoHanh();
        }

        private void ThucHienTimKiemBaoHanh(string tuKhoa)
        {
            var hd = _bus.TimHoaDonBaoHanh(tuKhoa);
            if (hd != null)
            {
                lblMaHD.Text = hd.MaHD; lblKhachHang.Text = hd.TenKhachHang;
                lblSDT.Text = hd.TenNhanVien; lblNgayMua.Text = hd.NgayLap.ToString("dd/MM/yyyy HH:mm");
                lblPrevTenKH.Text = hd.TenKhachHang; lblPrevSDT.Text = hd.TenNhanVien; lblPrevNgayMua.Text = hd.NgayLap.ToString("dd/MM/yyyy");

                var imeiDaBaoHanh = _bus.GetImeiDaBaoHanh(hd.MaHD).Select(x => x?.Trim().ToLower()).ToList();
                var rawList = _bus.GetSanPhamTuHoaDon(hd.MaHD);
                _dsSanPham = new List<SanPhamBaoHanhViewModel>();

                foreach (var item in rawList)
                {
                    if (!string.IsNullOrWhiteSpace(item.Imei) && (item.Imei.Contains(",") || item.Imei.Contains("\n")))
                    {
                        var arrImei = item.Imei.Split(new char[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var imeiStr in arrImei)
                        {
                            string rawImei = imeiStr.Trim();
                            string lowerImeiForCheck = rawImei.ToLower();

                            if (!imeiDaBaoHanh.Contains(lowerImeiForCheck))
                            {
                                _dsSanPham.Add(new SanPhamBaoHanhViewModel
                                {
                                    Chon = false,
                                    MaSP = item.MaSP,
                                    TenSP = item.TenSP,
                                    SoLuong = 1,
                                    DonGia = item.DonGia,
                                    Imei = rawImei
                                });
                            }
                        }
                    }
                    else
                    {
                        item.SoLuong = 1; _dsSanPham.Add(item);
                    }
                }

                dgvSanPham.DataSource = null; dgvSanPham.DataSource = _dsSanPham; CapNhatPreview();
            }
            else { ResetThongTinBaoHanh(); }
        }

        private void ResetThongTinBaoHanh()
        {
            lblMaHD.Text = "HD"; lblKhachHang.Text = "tên KH"; lblSDT.Text = "SĐT"; lblNgayMua.Text = "Ngày mua";
            lblPrevTenKH.Text = "tên KH"; lblPrevSDT.Text = "SĐT"; lblPrevNgayMua.Text = "///"; lblPrevTenSP.Text = "sp";
            dgvSanPham.DataSource = null; if (_dsSanPham != null) _dsSanPham.Clear(); CapNhatPreview();
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "colChon")
            {
                dgvSanPham.CommitEdit(DataGridViewDataErrorContexts.Commit);
                foreach (DataGridViewRow row in dgvSanPham.Rows) { if (row.Index != e.RowIndex) row.Cells["colChon"].Value = false; }
                CapNhatPreview();
            }
        }

        private void CapNhatNgayHetHan(object sender, EventArgs e)
        {
            try
            {
                string thoiHan = cboThoiHan.Text;
                if (string.IsNullOrWhiteSpace(thoiHan)) return;
                string numbers = new string(thoiHan.Where(char.IsDigit).ToArray());
                if (int.TryParse(numbers, out int soThang)) { dtpHetHan.Value = dtpBatDau.Value.AddMonths(soThang); CapNhatPreview(); }
            }
            catch { }
        }

        private void CapNhatPreview()
        {
            var spChon = _dsSanPham?.FirstOrDefault(x => x.Chon);
            lblPrevTenSP.Text = spChon != null ? spChon.TenSP : "Chưa chọn sản phẩm";
            lblPrevBatDau.Text = dtpBatDau.Value.ToString("dd/MM/yyyy");
            lblPrevHetHan.Text = dtpHetHan.Value.ToString("dd/MM/yyyy");
            lblPrevDieuKien.Text = cboDieuKien.Text;

            PictureBox picQR = this.Controls.Find("picQRCode", true).FirstOrDefault() as PictureBox;
            if (picQR != null && lblPrevTenKH.Text != "tên KH")
            {
                string qrContent = $"MÃ BH: {lblPrevMaBH.Text}\n" +
                                   $"KHÁCH HÀNG: {lblPrevTenKH.Text} ({lblPrevSDT.Text})\n" +
                                   $"SẢN PHẨM: {lblPrevTenSP.Text}\n" +
                                   $"IMEI: {(spChon != null ? spChon.Imei : "N/A")}\n" +
                                   $"NGÀY KÍCH HOẠT: {lblPrevBatDau.Text}\n" +
                                   $"HẠN BẢO HÀNH: {lblPrevHetHan.Text}\n" +
                                   $"CỬA HÀNG ĐIỆN THOẠI LHP";

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrContent, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                picQR.Image = qrCode.GetGraphic(5);
            }
            else if (picQR != null)
            {
                picQR.Image = null;
            }
        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].DataPropertyName == "DonGia" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal val)) { e.Value = val.ToString("N0"); e.FormattingApplied = true; }
            }
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            if ((DateTime.Now - _lastClickTime).TotalMilliseconds < 1000) return;
            _lastClickTime = DateTime.Now;

            try
            {
                if (lblMaHD.Text == "HD" || string.IsNullOrWhiteSpace(lblMaHD.Text)) { MessageBox.Show("Vui lòng nhập SĐT hoặc mã để tìm thấy hóa đơn gốc trước!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                var spChon = _dsSanPham?.FirstOrDefault(x => x.Chon);
                if (spChon == null) { MessageBox.Show("Vui lòng tích chọn một thiết bị di động ở Bước 2 để lập phiếu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                // Bật popup xin Email khách
                string emailKhach = PromptInputEmail(lblPrevTenKH.Text);
                if (emailKhach == null) return; // Nếu khách bấm Cancel tắt popup thì hủy luôn tiến trình

                if (MessageBox.Show("Xác nhận tạo Sổ Bảo Hành, xuất file PDF và tự động gửi Email cho khách?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    PhieuBaoHanh pbh = new PhieuBaoHanh
                    {
                        MaPhieuBH = lblPrevMaBH.Text,
                        MaHD = lblMaHD.Text,
                        MaSP = spChon.MaSP,
                        Imei = spChon.Imei,
                        NgayTiepNhan = dtpBatDau.Value, // Đổi thành ngày bắt đầu cho chuẩn logic bán mới
                        NgayBatDauBH = dtpBatDau.Value,
                        NgayHetHanBH = dtpHetHan.Value,
                        DieuKienBaoHanh = cboDieuKien.Text,
                        TinhTrangMay = txtGhiChu.Text.Trim(),
                        TrangThai = "Đang hiệu lực", // 🔴 ĐÃ SỬA THÀNH ĐANG HIỆU LỰC
                        MaNVTiepNhan = UserSession.MaNV ?? "Admin"
                    };

                    if (_bus.TaoPhieuBaoHanh(pbh))
                    {
                        // 1. Tự xuất PDF lấy file
                        string pdfFile = ThucHienInPhieu(true);

                        // 2. Tự bắn Email nếu có nhập mail
                        if (!string.IsNullOrWhiteSpace(emailKhach))
                        {
                            GuiMailPhieuBaoHanh(emailKhach, lblPrevTenKH.Text, pbh.MaPhieuBH, pdfFile);
                        }

                        txtTimKiemHD.Focus();
                        MessageBox.Show("Tạo và phát hành Phiếu bảo hành thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTimKiemHD.Text = ""; ResetThongTinBaoHanh(); SinhMaPhieuBaoHanh(); LoadDanhSachTraCuu();
                    }
                    else { MessageBox.Show("Lỗi kết nối tệp tin CSDL. Không thể lưu.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            ThucHienInPhieu(false);
        }

        // 🔴 ĐÃ SỬA LẠI ĐỂ HÀM IN TRẢ VỀ ĐƯỜNG DẪN TỆP TIN PDF
        private string ThucHienInPhieu(bool isAutoSave)
        {
            if (lblPrevTenKH.Text == "tên KH" || string.IsNullOrWhiteSpace(lblPrevTenKH.Text))
            {
                if (!isAutoSave) MessageBox.Show("Chưa có thông tin phiếu bảo hành hợp lệ để in!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            var spChon = _dsSanPham?.FirstOrDefault(x => x.Chon);
            if (spChon == null)
            {
                if (!isAutoSave) MessageBox.Show("Vui lòng tích chọn sản phẩm trước khi in!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            string filePath = "";
            string fileName = $"ChungNhanBaoHanh_{lblPrevMaBH.Text}.pdf";

            if (isAutoSave)
            {
                string exportFolder = Path.Combine(Application.StartupPath, "PhieuBaoHanh_Export");
                if (!Directory.Exists(exportFolder)) Directory.CreateDirectory(exportFolder);
                filePath = Path.Combine(exportFolder, fileName);
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF Files|*.pdf";
                sfd.FileName = fileName;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    filePath = sfd.FileName;
                }
                else return null;
            }

            try
            {
                string fontPath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + @"\arial.ttf";
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontBold = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

                Document doc = new Document(PageSize.A5);
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                doc.Add(new Paragraph("GIẤY CHỨNG NHẬN BẢO HÀNH THIẾT BỊ", fontTitle) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("Hệ thống cửa hàng điện thoại LHP", fontNormal) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("--------------------------------------------------", fontNormal) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("\n"));

                doc.Add(new Paragraph($"Mã Hợp Đồng BH: {lblPrevMaBH.Text}", fontBold));
                doc.Add(new Paragraph($"Khách hàng: {lblPrevTenKH.Text}", fontNormal));
                doc.Add(new Paragraph($"Số điện thoại: {lblPrevSDT.Text}", fontNormal));
                doc.Add(new Paragraph($"Ngày mua hàng gốc: {lblPrevNgayMua.Text}\n\n", fontNormal));

                doc.Add(new Paragraph($"Sản phẩm: {lblPrevTenSP.Text}", fontNormal));
                doc.Add(new Paragraph($"Mã IMEI: {spChon.Imei}", fontNormal));
                doc.Add(new Paragraph($"Kích hoạt bảo hành: {dtpBatDau.Value:dd/MM/yyyy}", fontNormal));
                doc.Add(new Paragraph($"Hết hạn bảo hành: {dtpHetHan.Value:dd/MM/yyyy}", fontNormal));
                doc.Add(new Paragraph($"Điều kiện: {cboDieuKien.Text}", fontNormal));

                doc.Add(new Paragraph($"Ghi chú tình trạng xuất xưởng: {txtGhiChu.Text.Trim()}", fontNormal));
                doc.Add(new Paragraph("\n"));

                PictureBox picQR = this.Controls.Find("picQRCode", true).FirstOrDefault() as PictureBox;
                if (picQR != null && picQR.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picQR.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        iTextSharp.text.Image qrImg = iTextSharp.text.Image.GetInstance(ms.ToArray());
                        qrImg.Alignment = Element.ALIGN_CENTER;
                        qrImg.ScaleAbsolute(120f, 120f);
                        doc.Add(qrImg);
                    }
                }

                doc.Add(new Paragraph("Mã QR điện tử bảo vệ quyền lợi khách hàng", fontNormal) { Alignment = Element.ALIGN_CENTER });
                doc.Close();

                if (!isAutoSave) MessageBox.Show("Xuất chứng nhận bảo hành PDF thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });

                return filePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // 🔴 ĐOẠN CODE GỬI MAIL VÀ ĐÍNH KÈM PDF
        private void GuiMailPhieuBaoHanh(string emailNhan, string tenKH, string maPhieu, string pdfFilePath)
        {
            try
            {
                // BẠN ĐIỀN EMAIL CỬA HÀNG VÀ MÃ 16 KÝ TỰ CỦA GOOGLE VÀO 2 DÒNG DƯỚI NÀY
                string emailGui = "pixel321vn@gmail.com";
                string matKhauUngDung = "lair gqmm qyfn iszh";

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(emailGui, "Cửa Hàng Điện Thoại LHP");
                mail.To.Add(emailNhan);
                mail.Subject = $"[LHP] Giấy Chứng Nhận Bảo Hành - Mã {maPhieu}";

                mail.Body = $"Kính gửi anh/chị {tenKH},\n\n" +
                            $"Cửa hàng điện thoại LHP chân thành cảm ơn quý khách đã tin tưởng và mua sắm.\n" +
                            $"Thiết bị của anh/chị đã được kích hoạt bảo hành điện tử thành công trên hệ thống.\n\n" +
                            $"Mã Hợp Đồng BH: {maPhieu}\n\n" +
                            $"Chi tiết về thời hạn bảo hành và tình trạng xuất xưởng đã được đính kèm trong tệp tin PDF dưới thư này.\n" +
                            $"Quý khách có thể sử dụng Camera điện thoại quét mã QR in trên tệp tin PDF để xem nhanh trạng thái hiệu lực.\n\n" +
                            $"Trân trọng cảm ơn quý khách!";

                if (!string.IsNullOrEmpty(pdfFilePath) && File.Exists(pdfFilePath))
                {
                    Attachment attachment = new Attachment(pdfFilePath);
                    mail.Attachments.Add(attachment);
                }

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential(emailGui, matKhauUngDung);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi Email cho khách thất bại: " + ex.Message, "Cảnh báo Mail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Giao diện hỏi nhanh Email
        private string PromptInputEmail(string tenKH)
        {
            Form prompt = new Form() { Width = 400, Height = 200, FormBorderStyle = FormBorderStyle.FixedDialog, Text = "Hệ thống thông báo điện tử", StartPosition = FormStartPosition.CenterScreen, MaximizeBox = false, MinimizeBox = false };
            Label textLabel = new Label() { Left = 20, Top = 20, Width = 350, Text = $"Nhập Email để gửi sổ bảo hành cho: {tenKH}", Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular) };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340, Font = new System.Drawing.Font("Segoe UI", 10) };
            textBox.Text = "khachhang@gmail.com";

            Button confirmation = new Button() { Text = "Xác nhận gửi", Left = 240, Width = 120, Height = 35, Top = 100, DialogResult = DialogResult.OK, BackColor = Color.DodgerBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button cancel = new Button() { Text = "Không gửi", Left = 110, Width = 120, Height = 35, Top = 100, DialogResult = DialogResult.Ignore, FlatStyle = FlatStyle.Flat };

            prompt.Controls.Add(textLabel); prompt.Controls.Add(textBox); prompt.Controls.Add(confirmation); prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;

            DialogResult result = prompt.ShowDialog();
            if (result == DialogResult.OK) return textBox.Text.Trim();
            if (result == DialogResult.Ignore) return "";
            return null;
        }

        private void LoadDanhSachTraCuu()
        {
            try { _dsTraCuuFull = _bus.GetDanhSachBaoHanh(); HienThiDanhSachTraCuu(); }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách bảo hành: " + ex.Message); }
        }

        private void HienThiDanhSachTraCuu()
        {
            if (dgvTraCuu == null || _dsTraCuuFull == null) return;
            var dsLoc = _dsTraCuuFull.ToList();

            if (txtTimKiemTraCuu != null && txtTimKiemTraCuu.Text != _placeholderTraCuu && !string.IsNullOrWhiteSpace(txtTimKiemTraCuu.Text))
            {
                string keyword = txtTimKiemTraCuu.Text.Trim().ToLower();
                dsLoc = dsLoc.Where(x => (x.MaPhieuBH != null && x.MaPhieuBH.ToLower().Contains(keyword)) || (x.TenKhachHang != null && x.TenKhachHang.ToLower().Contains(keyword))).ToList();
            }

            if (cboTrangThaiTraCuu != null && cboTrangThaiTraCuu.SelectedIndex > 0)
            {
                string status = cboTrangThaiTraCuu.Text; dsLoc = dsLoc.Where(x => x.TrangThai == status).ToList();
            }

            dgvTraCuu.DataSource = null; dgvTraCuu.DataSource = dsLoc;
        }

        private void cboTrangThaiTraCuu_SelectedIndexChanged(object sender, EventArgs e) { HienThiDanhSachTraCuu(); }

        private void dgvTraCuu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTraCuu.Columns[e.ColumnIndex].DataPropertyName == "TrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();
                // 🔴 ĐỔI MÀU CHO KHỚP TÊN MỚI
                if (status == "Đang hiệu lực") e.CellStyle.ForeColor = Color.Green;
                else if (status == "Đã hết hạn") e.CellStyle.ForeColor = Color.DarkOrange;
                else if (status == "Hủy/Từ chối") e.CellStyle.ForeColor = Color.Red;
            }

            if (dgvTraCuu.Columns[e.ColumnIndex].DataPropertyName == "NgayHetHanBH" && e.Value != null)
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime date)) { e.Value = date.ToString("dd/MM/yyyy"); e.FormattingApplied = true; }
            }
        }

        private void dgvTraCuu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _isProcessingClick) return;

            if ((DateTime.Now - _lastClickTime).TotalMilliseconds < 500) return;
            _lastClickTime = DateTime.Now;

            try
            {
                if (dgvTraCuu.Columns[e.ColumnIndex].Name == "colThaoTac")
                {
                    var pbh = dgvTraCuu.Rows[e.RowIndex].DataBoundItem as TraCuuBaoHanhViewModel;
                    if (pbh == null) return;

                    string trangThaiMoi = PromptCapNhatTrangThai(pbh.MaPhieuBH, pbh.TrangThai);
                    if (!string.IsNullOrEmpty(trangThaiMoi) && trangThaiMoi != pbh.TrangThai)
                    {
                        if (_bus.CapNhatTrangThai(pbh.MaPhieuBH, trangThaiMoi))
                        {
                            MessageBox.Show($"Đã cập nhật trạng thái hợp đồng {pbh.MaPhieuBH} thành: {trangThaiMoi}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDanhSachTraCuu();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private string PromptCapNhatTrangThai(string maPhieu, string trangThaiHienTai)
        {
            Form prompt = new Form() { Width = 350, Height = 200, FormBorderStyle = FormBorderStyle.FixedDialog, Text = "Quản lý hợp đồng bảo hành", StartPosition = FormStartPosition.CenterScreen, MaximizeBox = false, MinimizeBox = false };
            Label textLabel = new Label() { Left = 20, Top = 20, Width = 300, Text = $"Cập nhật trạng thái cho: {maPhieu}", Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold) };
            ComboBox cboStatus = new ComboBox() { Left = 20, Top = 60, Width = 290, DropDownStyle = ComboBoxStyle.DropDownList };

            // 🔴 ĐỔI TÊN MỤC CHỌN CHO KHỚP
            cboStatus.Items.AddRange(new string[] { "Đang hiệu lực", "Đã hết hạn", "Hủy/Từ chối" });
            cboStatus.SelectedItem = trangThaiHienTai;

            cboStatus.Click += (s, e) => { cboStatus.DroppedDown = true; };

            Button confirmation = new Button() { Text = "Xác nhận", Left = 180, Width = 100, Height = 35, Top = 110, DialogResult = DialogResult.OK, BackColor = Color.DodgerBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            Button cancel = new Button() { Text = "Hủy", Left = 60, Width = 100, Height = 35, Top = 110, DialogResult = DialogResult.Cancel, FlatStyle = FlatStyle.Flat };
            prompt.Controls.Add(textLabel); prompt.Controls.Add(cboStatus); prompt.Controls.Add(confirmation); prompt.Controls.Add(cancel); prompt.AcceptButton = confirmation; prompt.CancelButton = cancel;
            return prompt.ShowDialog() == DialogResult.OK ? cboStatus.Text : null;
        }
    }
}