namespace GUI
{
    partial class UC_ChamSocKH
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tabPage3 = new TabPage();
            panel9 = new Panel();
            txtTimLichSu = new TextBox();
            cboLoaiLichSu = new ComboBox();
            btnTimLichSu = new Button();
            btnLamTrongLichSu = new Button();
            dgvLichSuLienHe = new DataGridView();
            colLSNhanVien = new DataGridViewTextBoxColumn();
            colLSNgayLienHe = new DataGridViewTextBoxColumn();
            colLSNoiDung = new DataGridViewTextBoxColumn();
            colLSLoai = new DataGridViewTextBoxColumn();
            colLSTenKH = new DataGridViewTextBoxColumn();
            colLSMaKH = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            panel5 = new Panel();
            label10 = new Label();
            label11 = new Label();
            txtKhachHang = new TextBox();
            btnTimKH = new Button();
            label12 = new Label();
            cboLoaiChamSoc = new ComboBox();
            label13 = new Label();
            dtpNgayLienHe = new DateTimePicker();
            txtNoiDungNhac = new TextBox();
            label14 = new Label();
            btnTaoLich = new Button();
            tabPage1 = new TabPage();
            panel1 = new Panel();
            label2 = new Label();
            lblNhacHomNay = new Label();
            panel2 = new Panel();
            label5 = new Label();
            lblBHSapHetHan = new Label();
            panel3 = new Panel();
            label7 = new Label();
            lblChuaLienHe = new Label();
            panel4 = new Panel();
            label9 = new Label();
            lblDaXuLyTuanNay = new Label();
            panel10 = new Panel();
            txtTimKiem = new TextBox();
            cboLoaiLoc = new ComboBox();
            cboTrangThaiLoc = new ComboBox();
            btnTim = new Button();
            dgvDanhSachChamSoc = new DataGridView();
            colXong = new DataGridViewButtonColumn();
            colGoi = new DataGridViewButtonColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colNgayHen = new DataGridViewTextBoxColumn();
            colNoiDung = new DataGridViewTextBoxColumn();
            colLoaiChamSoc = new DataGridViewTextBoxColumn();
            colTenKH = new DataGridViewTextBoxColumn();
            colMaKH = new DataGridViewTextBoxColumn();
            tabControl1 = new TabControl();
            tabPage3.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichSuLienHe).BeginInit();
            tabPage2.SuspendLayout();
            panel5.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachChamSoc).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(32, 13);
            label1.Name = "label1";
            label1.Size = new Size(268, 35);
            label1.TabIndex = 5;
            label1.Text = "Chăm sóc khách hàng";
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.LightSteelBlue;
            tabPage3.BorderStyle = BorderStyle.FixedSingle;
            tabPage3.Controls.Add(dgvLichSuLienHe);
            tabPage3.Controls.Add(panel9);
            tabPage3.Location = new Point(4, 44);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1327, 784);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Lịch sử liên hệ";
            // 
            // panel9
            // 
            panel9.BackColor = Color.White;
            panel9.Controls.Add(btnLamTrongLichSu);
            panel9.Controls.Add(btnTimLichSu);
            panel9.Controls.Add(cboLoaiLichSu);
            panel9.Controls.Add(txtTimLichSu);
            panel9.Location = new Point(6, 6);
            panel9.Name = "panel9";
            panel9.Size = new Size(1313, 87);
            panel9.TabIndex = 0;
            // 
            // txtTimLichSu
            // 
            txtTimLichSu.Location = new Point(22, 25);
            txtTimLichSu.Name = "txtTimLichSu";
            txtTimLichSu.Size = new Size(395, 31);
            txtTimLichSu.TabIndex = 0;
            txtTimLichSu.Text = "Tìm tên KH, SĐT......";
            // 
            // cboLoaiLichSu
            // 
            cboLoaiLichSu.FormattingEnabled = true;
            cboLoaiLichSu.Location = new Point(542, 26);
            cboLoaiLichSu.Name = "cboLoaiLichSu";
            cboLoaiLichSu.Size = new Size(326, 33);
            cboLoaiLichSu.TabIndex = 1;
            cboLoaiLichSu.Text = "--Tất cả loại--";
            // 
            // btnTimLichSu
            // 
            btnTimLichSu.BackColor = SystemColors.HotTrack;
            btnTimLichSu.FlatStyle = FlatStyle.Flat;
            btnTimLichSu.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnTimLichSu.ForeColor = Color.White;
            btnTimLichSu.Location = new Point(1004, 22);
            btnTimLichSu.Name = "btnTimLichSu";
            btnTimLichSu.Size = new Size(128, 38);
            btnTimLichSu.TabIndex = 9;
            btnTimLichSu.Text = "Tìm";
            btnTimLichSu.UseVisualStyleBackColor = false;
            // 
            // btnLamTrongLichSu
            // 
            btnLamTrongLichSu.BackColor = Color.Gainsboro;
            btnLamTrongLichSu.FlatStyle = FlatStyle.Flat;
            btnLamTrongLichSu.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamTrongLichSu.ForeColor = Color.Black;
            btnLamTrongLichSu.Location = new Point(1168, 22);
            btnLamTrongLichSu.Name = "btnLamTrongLichSu";
            btnLamTrongLichSu.Size = new Size(128, 38);
            btnLamTrongLichSu.TabIndex = 10;
            btnLamTrongLichSu.Text = "Làm trống";
            btnLamTrongLichSu.UseVisualStyleBackColor = false;
            btnLamTrongLichSu.Click += button4_Click;
            // 
            // dgvLichSuLienHe
            // 
            dgvLichSuLienHe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichSuLienHe.BackgroundColor = Color.White;
            dgvLichSuLienHe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichSuLienHe.Columns.AddRange(new DataGridViewColumn[] { colLSMaKH, colLSTenKH, colLSLoai, colLSNoiDung, colLSNgayLienHe, colLSNhanVien });
            dgvLichSuLienHe.Location = new Point(7, 107);
            dgvLichSuLienHe.Name = "dgvLichSuLienHe";
            dgvLichSuLienHe.RowHeadersWidth = 51;
            dgvLichSuLienHe.Size = new Size(1312, 669);
            dgvLichSuLienHe.TabIndex = 1;
            // 
            // colLSNhanVien
            // 
            colLSNhanVien.DataPropertyName = "MaNVPhuTrach";
            colLSNhanVien.HeaderText = "Nhân viên";
            colLSNhanVien.MinimumWidth = 6;
            colLSNhanVien.Name = "colLSNhanVien";
            // 
            // colLSNgayLienHe
            // 
            colLSNgayLienHe.DataPropertyName = "NgayXuLy";
            colLSNgayLienHe.HeaderText = "Ngày liên hệ";
            colLSNgayLienHe.MinimumWidth = 6;
            colLSNgayLienHe.Name = "colLSNgayLienHe";
            // 
            // colLSNoiDung
            // 
            colLSNoiDung.DataPropertyName = "NoiDung";
            colLSNoiDung.HeaderText = "Nội dung ghi chú";
            colLSNoiDung.MinimumWidth = 6;
            colLSNoiDung.Name = "colLSNoiDung";
            // 
            // colLSLoai
            // 
            colLSLoai.DataPropertyName = "LoaiChamSoc";
            colLSLoai.HeaderText = "Loại chăm sóc";
            colLSLoai.MinimumWidth = 6;
            colLSLoai.Name = "colLSLoai";
            // 
            // colLSTenKH
            // 
            colLSTenKH.DataPropertyName = "TenKH";
            colLSTenKH.HeaderText = "Tên KH";
            colLSTenKH.MinimumWidth = 6;
            colLSTenKH.Name = "colLSTenKH";
            // 
            // colLSMaKH
            // 
            colLSMaKH.DataPropertyName = "MaKH";
            colLSMaKH.HeaderText = "Mã KH";
            colLSMaKH.MinimumWidth = 6;
            colLSMaKH.Name = "colLSMaKH";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.LightSteelBlue;
            tabPage2.BorderStyle = BorderStyle.FixedSingle;
            tabPage2.Controls.Add(panel5);
            tabPage2.Font = new Font("Segoe UI", 10.2F);
            tabPage2.Location = new Point(4, 44);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1327, 784);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tạo lịch nhắc";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(btnTaoLich);
            panel5.Controls.Add(label14);
            panel5.Controls.Add(txtNoiDungNhac);
            panel5.Controls.Add(dtpNgayLienHe);
            panel5.Controls.Add(label13);
            panel5.Controls.Add(cboLoaiChamSoc);
            panel5.Controls.Add(label12);
            panel5.Controls.Add(btnTimKH);
            panel5.Controls.Add(txtKhachHang);
            panel5.Controls.Add(label11);
            panel5.Controls.Add(label10);
            panel5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel5.Location = new Point(16, 10);
            panel5.Name = "panel5";
            panel5.Size = new Size(1226, 848);
            panel5.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label10.ForeColor = Color.MediumBlue;
            label10.Location = new Point(19, 20);
            label10.Name = "label10";
            label10.Size = new Size(206, 25);
            label10.TabIndex = 9;
            label10.Text = "Tạo lịch nhắc thủ công";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F);
            label11.Location = new Point(47, 67);
            label11.Name = "label11";
            label11.Size = new Size(104, 25);
            label11.TabIndex = 10;
            label11.Text = "Khách hàng";
            // 
            // txtKhachHang
            // 
            txtKhachHang.Font = new Font("Segoe UI", 10.8F);
            txtKhachHang.Location = new Point(47, 95);
            txtKhachHang.Name = "txtKhachHang";
            txtKhachHang.Size = new Size(344, 31);
            txtKhachHang.TabIndex = 11;
            // 
            // btnTimKH
            // 
            btnTimKH.BackColor = SystemColors.HotTrack;
            btnTimKH.FlatStyle = FlatStyle.Flat;
            btnTimKH.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnTimKH.ForeColor = Color.White;
            btnTimKH.Location = new Point(427, 95);
            btnTimKH.Name = "btnTimKH";
            btnTimKH.Size = new Size(128, 31);
            btnTimKH.TabIndex = 12;
            btnTimKH.Text = "Tìm";
            btnTimKH.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F);
            label12.Location = new Point(47, 157);
            label12.Name = "label12";
            label12.Size = new Size(124, 25);
            label12.TabIndex = 13;
            label12.Text = "Loại chăm sóc";
            // 
            // cboLoaiChamSoc
            // 
            cboLoaiChamSoc.FormattingEnabled = true;
            cboLoaiChamSoc.Location = new Point(47, 185);
            cboLoaiChamSoc.Name = "cboLoaiChamSoc";
            cboLoaiChamSoc.Size = new Size(508, 33);
            cboLoaiChamSoc.TabIndex = 15;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.8F);
            label13.Location = new Point(47, 255);
            label13.Name = "label13";
            label13.Size = new Size(110, 25);
            label13.TabIndex = 16;
            label13.Text = "Ngày liên hệ";
            // 
            // dtpNgayLienHe
            // 
            dtpNgayLienHe.Location = new Point(47, 283);
            dtpNgayLienHe.Name = "dtpNgayLienHe";
            dtpNgayLienHe.Size = new Size(508, 31);
            dtpNgayLienHe.TabIndex = 17;
            // 
            // txtNoiDungNhac
            // 
            txtNoiDungNhac.Font = new Font("Segoe UI", 10.8F);
            txtNoiDungNhac.Location = new Point(47, 371);
            txtNoiDungNhac.Multiline = true;
            txtNoiDungNhac.Name = "txtNoiDungNhac";
            txtNoiDungNhac.Size = new Size(508, 189);
            txtNoiDungNhac.TabIndex = 21;
            txtNoiDungNhac.Text = "Nhập nội dung cần trao đổi với khách hàng...";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10.8F);
            label14.Location = new Point(47, 344);
            label14.Name = "label14";
            label14.Size = new Size(129, 25);
            label14.TabIndex = 22;
            label14.Text = "Nội dung nhắc";
            // 
            // btnTaoLich
            // 
            btnTaoLich.BackColor = SystemColors.HotTrack;
            btnTaoLich.FlatStyle = FlatStyle.Flat;
            btnTaoLich.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnTaoLich.ForeColor = Color.White;
            btnTaoLich.Location = new Point(170, 613);
            btnTaoLich.Name = "btnTaoLich";
            btnTaoLich.Size = new Size(273, 42);
            btnTaoLich.TabIndex = 33;
            btnTaoLich.Text = "Tạo lịch nhắc";
            btnTaoLich.UseVisualStyleBackColor = false;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.LightSteelBlue;
            tabPage1.BorderStyle = BorderStyle.FixedSingle;
            tabPage1.Controls.Add(dgvDanhSachChamSoc);
            tabPage1.Controls.Add(panel10);
            tabPage1.Controls.Add(panel4);
            tabPage1.Controls.Add(panel3);
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 44);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1327, 784);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Danh sách chăm sóc";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblNhacHomNay);
            panel1.Controls.Add(label2);
            panel1.Font = new Font("Segoe UI", 12F);
            panel1.Location = new Point(6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(255, 125);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(18, 11);
            label2.Name = "label2";
            label2.Size = new Size(144, 28);
            label2.TabIndex = 1;
            label2.Text = "Nhắc hôm nay";
            // 
            // lblNhacHomNay
            // 
            lblNhacHomNay.AutoSize = true;
            lblNhacHomNay.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblNhacHomNay.ForeColor = Color.OrangeRed;
            lblNhacHomNay.Location = new Point(18, 71);
            lblNhacHomNay.Name = "lblNhacHomNay";
            lblNhacHomNay.Size = new Size(47, 31);
            lblNhacHomNay.TabIndex = 2;
            lblNhacHomNay.Text = "KH";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblBHSapHetHan);
            panel2.Controls.Add(label5);
            panel2.Font = new Font("Segoe UI", 12F);
            panel2.Location = new Point(360, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(255, 125);
            panel2.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(18, 11);
            label5.Name = "label5";
            label5.Size = new Size(152, 28);
            label5.TabIndex = 1;
            label5.Text = "BH sắp hết hạn";
            // 
            // lblBHSapHetHan
            // 
            lblBHSapHetHan.AutoSize = true;
            lblBHSapHetHan.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblBHSapHetHan.ForeColor = Color.SaddleBrown;
            lblBHSapHetHan.Location = new Point(18, 71);
            lblBHSapHetHan.Name = "lblBHSapHetHan";
            lblBHSapHetHan.Size = new Size(47, 31);
            lblBHSapHetHan.TabIndex = 2;
            lblBHSapHetHan.Text = "KH";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblChuaLienHe);
            panel3.Controls.Add(label7);
            panel3.Font = new Font("Segoe UI", 12F);
            panel3.Location = new Point(740, 6);
            panel3.Name = "panel3";
            panel3.Size = new Size(255, 125);
            panel3.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label7.Location = new Point(18, 11);
            label7.Name = "label7";
            label7.Size = new Size(152, 28);
            label7.TabIndex = 1;
            label7.Text = "Chưa liên hệ lại";
            // 
            // lblChuaLienHe
            // 
            lblChuaLienHe.AutoSize = true;
            lblChuaLienHe.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblChuaLienHe.ForeColor = Color.Olive;
            lblChuaLienHe.Location = new Point(18, 71);
            lblChuaLienHe.Name = "lblChuaLienHe";
            lblChuaLienHe.Size = new Size(47, 31);
            lblChuaLienHe.TabIndex = 2;
            lblChuaLienHe.Text = "KH";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblDaXuLyTuanNay);
            panel4.Controls.Add(label9);
            panel4.Font = new Font("Segoe UI", 12F);
            panel4.Location = new Point(1064, 6);
            panel4.Name = "panel4";
            panel4.Size = new Size(255, 125);
            panel4.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label9.Location = new Point(18, 11);
            label9.Name = "label9";
            label9.Size = new Size(170, 28);
            label9.TabIndex = 1;
            label9.Text = "Đã xử lý tuần này";
            // 
            // lblDaXuLyTuanNay
            // 
            lblDaXuLyTuanNay.AutoSize = true;
            lblDaXuLyTuanNay.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblDaXuLyTuanNay.ForeColor = Color.DarkOliveGreen;
            lblDaXuLyTuanNay.Location = new Point(18, 71);
            lblDaXuLyTuanNay.Name = "lblDaXuLyTuanNay";
            lblDaXuLyTuanNay.Size = new Size(47, 31);
            lblDaXuLyTuanNay.TabIndex = 2;
            lblDaXuLyTuanNay.Text = "KH";
            // 
            // panel10
            // 
            panel10.BackColor = Color.White;
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(btnTim);
            panel10.Controls.Add(cboTrangThaiLoc);
            panel10.Controls.Add(cboLoaiLoc);
            panel10.Controls.Add(txtTimKiem);
            panel10.Location = new Point(6, 149);
            panel10.Name = "panel10";
            panel10.Size = new Size(1313, 73);
            panel10.TabIndex = 4;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(773, 20);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(293, 31);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.Text = "Tìm tên KH, SĐT...";
            // 
            // cboLoaiLoc
            // 
            cboLoaiLoc.FormattingEnabled = true;
            cboLoaiLoc.Location = new Point(18, 25);
            cboLoaiLoc.Name = "cboLoaiLoc";
            cboLoaiLoc.Size = new Size(293, 33);
            cboLoaiLoc.TabIndex = 1;
            cboLoaiLoc.Text = "--Tất cả loại--";
            // 
            // cboTrangThaiLoc
            // 
            cboTrangThaiLoc.FormattingEnabled = true;
            cboTrangThaiLoc.Location = new Point(406, 23);
            cboTrangThaiLoc.Name = "cboTrangThaiLoc";
            cboTrangThaiLoc.Size = new Size(293, 33);
            cboTrangThaiLoc.TabIndex = 2;
            cboTrangThaiLoc.Text = "--Tất cả trạng thái--";
            // 
            // btnTim
            // 
            btnTim.BackColor = SystemColors.HotTrack;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnTim.ForeColor = Color.White;
            btnTim.Location = new Point(1162, 20);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(128, 38);
            btnTim.TabIndex = 9;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = false;
            // 
            // dgvDanhSachChamSoc
            // 
            dgvDanhSachChamSoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachChamSoc.BackgroundColor = Color.White;
            dgvDanhSachChamSoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachChamSoc.Columns.AddRange(new DataGridViewColumn[] { colMaKH, colTenKH, colLoaiChamSoc, colNoiDung, colNgayHen, colTrangThai, colGoi, colXong });
            dgvDanhSachChamSoc.Location = new Point(6, 228);
            dgvDanhSachChamSoc.Name = "dgvDanhSachChamSoc";
            dgvDanhSachChamSoc.RowHeadersWidth = 51;
            dgvDanhSachChamSoc.Size = new Size(1313, 548);
            dgvDanhSachChamSoc.TabIndex = 5;
            // 
            // colXong
            // 
            colXong.HeaderText = "Xong";
            colXong.MinimumWidth = 6;
            colXong.Name = "colXong";
            // 
            // colGoi
            // 
            colGoi.HeaderText = "Gọi";
            colGoi.MinimumWidth = 6;
            colGoi.Name = "colGoi";
            colGoi.Resizable = DataGridViewTriState.True;
            colGoi.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // colTrangThai
            // 
            colTrangThai.DataPropertyName = "TrangThai";
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 6;
            colTrangThai.Name = "colTrangThai";
            // 
            // colNgayHen
            // 
            colNgayHen.DataPropertyName = "NgayHen";
            colNgayHen.HeaderText = "Ngày hẹn";
            colNgayHen.MinimumWidth = 6;
            colNgayHen.Name = "colNgayHen";
            // 
            // colNoiDung
            // 
            colNoiDung.DataPropertyName = "NoiDung";
            colNoiDung.HeaderText = "Nội dung";
            colNoiDung.MinimumWidth = 6;
            colNoiDung.Name = "colNoiDung";
            // 
            // colLoaiChamSoc
            // 
            colLoaiChamSoc.DataPropertyName = "LoaiChamSoc";
            colLoaiChamSoc.HeaderText = "Loại chăm sóc";
            colLoaiChamSoc.MinimumWidth = 6;
            colLoaiChamSoc.Name = "colLoaiChamSoc";
            // 
            // colTenKH
            // 
            colTenKH.DataPropertyName = "TenKH";
            colTenKH.HeaderText = "Tên KH";
            colTenKH.MinimumWidth = 6;
            colTenKH.Name = "colTenKH";
            // 
            // colMaKH
            // 
            colMaKH.DataPropertyName = "MaKH";
            colMaKH.HeaderText = "Mã KH";
            colMaKH.MinimumWidth = 6;
            colMaKH.Name = "colMaKH";
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Font = new Font("Segoe UI", 10.8F);
            tabControl1.ItemSize = new Size(434, 40);
            tabControl1.Location = new Point(32, 51);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1335, 832);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 6;
            // 
            // UC_ChamSocKH
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.2F);
            Name = "UC_ChamSocKH";
            Size = new Size(1370, 886);
            Load += UC_ChamSocKH_Load;
            tabPage3.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichSuLienHe).EndInit();
            tabPage2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tabPage1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachChamSoc).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TabPage tabPage3;
        private DataGridView dgvLichSuLienHe;
        private DataGridViewTextBoxColumn colLSMaKH;
        private DataGridViewTextBoxColumn colLSTenKH;
        private DataGridViewTextBoxColumn colLSLoai;
        private DataGridViewTextBoxColumn colLSNoiDung;
        private DataGridViewTextBoxColumn colLSNgayLienHe;
        private DataGridViewTextBoxColumn colLSNhanVien;
        private Panel panel9;
        private Button btnLamTrongLichSu;
        private Button btnTimLichSu;
        private ComboBox cboLoaiLichSu;
        private TextBox txtTimLichSu;
        private TabPage tabPage2;
        private Panel panel5;
        private Button btnTaoLich;
        private Label label14;
        private TextBox txtNoiDungNhac;
        private DateTimePicker dtpNgayLienHe;
        private Label label13;
        private ComboBox cboLoaiChamSoc;
        private Label label12;
        private Button btnTimKH;
        private TextBox txtKhachHang;
        private Label label11;
        private Label label10;
        private TabPage tabPage1;
        private DataGridView dgvDanhSachChamSoc;
        private DataGridViewTextBoxColumn colMaKH;
        private DataGridViewTextBoxColumn colTenKH;
        private DataGridViewTextBoxColumn colLoaiChamSoc;
        private DataGridViewTextBoxColumn colNoiDung;
        private DataGridViewTextBoxColumn colNgayHen;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewButtonColumn colGoi;
        private DataGridViewButtonColumn colXong;
        private Panel panel10;
        private Button btnTim;
        private ComboBox cboTrangThaiLoc;
        private ComboBox cboLoaiLoc;
        private TextBox txtTimKiem;
        private Panel panel4;
        private Label lblDaXuLyTuanNay;
        private Label label9;
        private Panel panel3;
        private Label lblChuaLienHe;
        private Label label7;
        private Panel panel2;
        private Label lblBHSapHetHan;
        private Label label5;
        private Panel panel1;
        private Label lblNhacHomNay;
        private Label label2;
        private TabControl tabControl1;
    }
}
