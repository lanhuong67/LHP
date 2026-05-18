namespace GUI
{
    partial class UC_BaoHanh
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label1 = new Label();
            tabPage2 = new TabPage();
            dgvTraCuu = new DataGridView();
            colMaPhieuBH = new DataGridViewTextBoxColumn();
            colKhachHang = new DataGridViewTextBoxColumn();
            colSanPhamBH = new DataGridViewTextBoxColumn();
            colHetHan = new DataGridViewTextBoxColumn();
            colTrangThaiBH = new DataGridViewTextBoxColumn();
            colThaoTac = new DataGridViewButtonColumn();
            panel10 = new Panel();
            cboTrangThaiTraCuu = new ComboBox();
            txtTimKiemTraCuu = new TextBox();
            tabPage1 = new TabPage();
            panel5 = new Panel();
            btnInPhieu = new Button();
            btnTaoPhieu = new Button();
            panel7 = new Panel();
            panel6 = new Panel();
            label33 = new Label();
            panel9 = new Panel();
            lblPrevDieuKien = new Label();
            label32 = new Label();
            lblPrevHetHan = new Label();
            label30 = new Label();
            lblPrevBatDau = new Label();
            label28 = new Label();
            lblPrevNgayMua = new Label();
            label26 = new Label();
            lblPrevTenSP = new Label();
            label24 = new Label();
            panel8 = new Panel();
            lblPrevSDT = new Label();
            label22 = new Label();
            lblPrevTenKH = new Label();
            label20 = new Label();
            lblPrevMaBH = new Label();
            label17 = new Label();
            label16 = new Label();
            label14 = new Label();
            label13 = new Label();
            panel4 = new Panel();
            label12 = new Label();
            txtGhiChu = new TextBox();
            cboDieuKien = new ComboBox();
            label11 = new Label();
            dtpHetHan = new DateTimePicker();
            label10 = new Label();
            cboThoiHan = new ComboBox();
            label9 = new Label();
            dtpBatDau = new DateTimePicker();
            label8 = new Label();
            label7 = new Label();
            panel3 = new Panel();
            dgvSanPham = new DataGridView();
            colChon = new DataGridViewCheckBoxColumn();
            colImei = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            label15 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            lblNgayMua = new Label();
            lblKhachHang = new Label();
            lblSDT = new Label();
            lblMaHD = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            txtTimKiemHD = new TextBox();
            label3 = new Label();
            tabBaoHanh = new TabControl();
            picQRCode = new PictureBox();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTraCuu).BeginInit();
            panel10.SuspendLayout();
            tabPage1.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabBaoHanh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQRCode).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(28, 11);
            label1.Name = "label1";
            label1.Size = new Size(124, 35);
            label1.TabIndex = 5;
            label1.Text = "Bảo hành";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.LightSteelBlue;
            tabPage2.BorderStyle = BorderStyle.FixedSingle;
            tabPage2.Controls.Add(dgvTraCuu);
            tabPage2.Controls.Add(panel10);
            tabPage2.Font = new Font("Segoe UI", 10.8F);
            tabPage2.Location = new Point(4, 44);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1538, 938);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tra cứu / xử lý";
            // 
            // dgvTraCuu
            // 
            dgvTraCuu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTraCuu.BackgroundColor = Color.White;
            dgvTraCuu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTraCuu.Columns.AddRange(new DataGridViewColumn[] { colMaPhieuBH, colKhachHang, colSanPhamBH, colHetHan, colTrangThaiBH, colThaoTac });
            dgvTraCuu.Location = new Point(6, 85);
            dgvTraCuu.Name = "dgvTraCuu";
            dgvTraCuu.RowHeadersWidth = 51;
            dgvTraCuu.Size = new Size(1418, 849);
            dgvTraCuu.TabIndex = 2;
            dgvTraCuu.CellContentClick += dgvTraCuu_CellContentClick;
            // 
            // colMaPhieuBH
            // 
            colMaPhieuBH.DataPropertyName = "MaPhieuBH";
            colMaPhieuBH.HeaderText = "Mã phiếu BH";
            colMaPhieuBH.MinimumWidth = 6;
            colMaPhieuBH.Name = "colMaPhieuBH";
            // 
            // colKhachHang
            // 
            colKhachHang.DataPropertyName = "TenKhachHang";
            colKhachHang.HeaderText = "Khách hàng";
            colKhachHang.MinimumWidth = 6;
            colKhachHang.Name = "colKhachHang";
            // 
            // colSanPhamBH
            // 
            colSanPhamBH.DataPropertyName = "TenSP";
            colSanPhamBH.HeaderText = "Sản phẩm";
            colSanPhamBH.MinimumWidth = 6;
            colSanPhamBH.Name = "colSanPhamBH";
            // 
            // colHetHan
            // 
            colHetHan.DataPropertyName = "NgayHetHanBH";
            colHetHan.HeaderText = "Hết hạn BH";
            colHetHan.MinimumWidth = 6;
            colHetHan.Name = "colHetHan";
            // 
            // colTrangThaiBH
            // 
            colTrangThaiBH.DataPropertyName = "TrangThai";
            colTrangThaiBH.HeaderText = "Trạng thái";
            colTrangThaiBH.MinimumWidth = 6;
            colTrangThaiBH.Name = "colTrangThaiBH";
            // 
            // colThaoTac
            // 
            colThaoTac.HeaderText = "Thao tác";
            colThaoTac.MinimumWidth = 6;
            colThaoTac.Name = "colThaoTac";
            // 
            // panel10
            // 
            panel10.BackColor = Color.White;
            panel10.Controls.Add(cboTrangThaiTraCuu);
            panel10.Controls.Add(txtTimKiemTraCuu);
            panel10.Location = new Point(6, 6);
            panel10.Name = "panel10";
            panel10.Size = new Size(1418, 69);
            panel10.TabIndex = 1;
            // 
            // cboTrangThaiTraCuu
            // 
            cboTrangThaiTraCuu.Font = new Font("Segoe UI", 10.2F);
            cboTrangThaiTraCuu.FormattingEnabled = true;
            cboTrangThaiTraCuu.Location = new Point(675, 15);
            cboTrangThaiTraCuu.Name = "cboTrangThaiTraCuu";
            cboTrangThaiTraCuu.Size = new Size(387, 31);
            cboTrangThaiTraCuu.TabIndex = 1;
            cboTrangThaiTraCuu.Text = "--Tất cả trạng thái--";
            // 
            // txtTimKiemTraCuu
            // 
            txtTimKiemTraCuu.Font = new Font("Segoe UI", 10.2F);
            txtTimKiemTraCuu.Location = new Point(22, 16);
            txtTimKiemTraCuu.Name = "txtTimKiemTraCuu";
            txtTimKiemTraCuu.Size = new Size(527, 30);
            txtTimKiemTraCuu.TabIndex = 0;
            txtTimKiemTraCuu.Text = "Mã phiếu BH, tên KH, SĐT,..";
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.LightSteelBlue;
            tabPage1.BorderStyle = BorderStyle.FixedSingle;
            tabPage1.Controls.Add(panel5);
            tabPage1.Controls.Add(panel4);
            tabPage1.Controls.Add(panel3);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 44);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1538, 938);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Tạo phiếu bảo hành";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel5.BackColor = Color.White;
            panel5.BackgroundImageLayout = ImageLayout.None;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(btnInPhieu);
            panel5.Controls.Add(btnTaoPhieu);
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(label13);
            panel5.Location = new Point(938, 6);
            panel5.Name = "panel5";
            panel5.Size = new Size(571, 924);
            panel5.TabIndex = 11;
            // 
            // btnInPhieu
            // 
            btnInPhieu.BackColor = Color.Gainsboro;
            btnInPhieu.FlatStyle = FlatStyle.Flat;
            btnInPhieu.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnInPhieu.ForeColor = Color.Black;
            btnInPhieu.Location = new Point(171, 737);
            btnInPhieu.Name = "btnInPhieu";
            btnInPhieu.Size = new Size(273, 42);
            btnInPhieu.TabIndex = 31;
            btnInPhieu.Text = "In phiếu";
            btnInPhieu.UseVisualStyleBackColor = false;
            // 
            // btnTaoPhieu
            // 
            btnTaoPhieu.BackColor = SystemColors.HotTrack;
            btnTaoPhieu.FlatStyle = FlatStyle.Flat;
            btnTaoPhieu.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnTaoPhieu.ForeColor = Color.White;
            btnTaoPhieu.Location = new Point(171, 660);
            btnTaoPhieu.Name = "btnTaoPhieu";
            btnTaoPhieu.Size = new Size(273, 42);
            btnTaoPhieu.TabIndex = 32;
            btnTaoPhieu.Text = "Tạo phiếu bảo hành";
            btnTaoPhieu.UseVisualStyleBackColor = false;
            btnTaoPhieu.Click += btnTaoPhieu_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.DimGray;
            panel7.Location = new Point(16, 43);
            panel7.Name = "panel7";
            panel7.Size = new Size(486, 1);
            panel7.TabIndex = 25;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(picQRCode);
            panel6.Controls.Add(label33);
            panel6.Controls.Add(panel9);
            panel6.Controls.Add(lblPrevDieuKien);
            panel6.Controls.Add(label32);
            panel6.Controls.Add(lblPrevHetHan);
            panel6.Controls.Add(label30);
            panel6.Controls.Add(lblPrevBatDau);
            panel6.Controls.Add(label28);
            panel6.Controls.Add(lblPrevNgayMua);
            panel6.Controls.Add(label26);
            panel6.Controls.Add(lblPrevTenSP);
            panel6.Controls.Add(label24);
            panel6.Controls.Add(panel8);
            panel6.Controls.Add(lblPrevSDT);
            panel6.Controls.Add(label22);
            panel6.Controls.Add(lblPrevTenKH);
            panel6.Controls.Add(label20);
            panel6.Controls.Add(lblPrevMaBH);
            panel6.Controls.Add(label17);
            panel6.Controls.Add(label16);
            panel6.Controls.Add(label14);
            panel6.Location = new Point(26, 61);
            panel6.Name = "panel6";
            panel6.Size = new Size(523, 566);
            panel6.TabIndex = 30;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Segoe UI Semilight", 9F);
            label33.Location = new Point(209, 527);
            label33.Name = "label33";
            label33.Size = new Size(134, 20);
            label33.TabIndex = 37;
            label33.Text = "Quét để tra cứu BH";
            // 
            // panel9
            // 
            panel9.BackColor = Color.DimGray;
            panel9.Location = new Point(70, 392);
            panel9.Name = "panel9";
            panel9.Size = new Size(391, 1);
            panel9.TabIndex = 27;
            // 
            // lblPrevDieuKien
            // 
            lblPrevDieuKien.AutoSize = true;
            lblPrevDieuKien.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblPrevDieuKien.Location = new Point(287, 347);
            lblPrevDieuKien.Name = "lblPrevDieuKien";
            lblPrevDieuKien.Size = new Size(86, 23);
            lblPrevDieuKien.TabIndex = 36;
            lblPrevDieuKien.Text = "Điều kiện";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(67, 347);
            label32.Name = "label32";
            label32.Size = new Size(89, 25);
            label32.TabIndex = 35;
            label32.Text = "Điều kiện:";
            // 
            // lblPrevHetHan
            // 
            lblPrevHetHan.AutoSize = true;
            lblPrevHetHan.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblPrevHetHan.Location = new Point(287, 312);
            lblPrevHetHan.Name = "lblPrevHetHan";
            lblPrevHetHan.Size = new Size(34, 23);
            lblPrevHetHan.TabIndex = 34;
            lblPrevHetHan.Text = "///";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(67, 312);
            label30.Name = "label30";
            label30.Size = new Size(106, 25);
            label30.TabIndex = 33;
            label30.Text = "Hết hạn BH:";
            // 
            // lblPrevBatDau
            // 
            lblPrevBatDau.AutoSize = true;
            lblPrevBatDau.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblPrevBatDau.Location = new Point(287, 277);
            lblPrevBatDau.Name = "lblPrevBatDau";
            lblPrevBatDau.Size = new Size(34, 23);
            lblPrevBatDau.TabIndex = 32;
            lblPrevBatDau.Text = "///";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(67, 277);
            label28.Name = "label28";
            label28.Size = new Size(104, 25);
            label28.TabIndex = 31;
            label28.Text = "Bắt đầu BH:";
            // 
            // lblPrevNgayMua
            // 
            lblPrevNgayMua.AutoSize = true;
            lblPrevNgayMua.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblPrevNgayMua.Location = new Point(287, 242);
            lblPrevNgayMua.Name = "lblPrevNgayMua";
            lblPrevNgayMua.Size = new Size(34, 23);
            lblPrevNgayMua.TabIndex = 30;
            lblPrevNgayMua.Text = "///";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(67, 242);
            label26.Name = "label26";
            label26.Size = new Size(94, 25);
            label26.TabIndex = 29;
            label26.Text = "Ngày mua";
            // 
            // lblPrevTenSP
            // 
            lblPrevTenSP.AutoSize = true;
            lblPrevTenSP.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblPrevTenSP.Location = new Point(287, 209);
            lblPrevTenSP.Name = "lblPrevTenSP";
            lblPrevTenSP.Size = new Size(28, 23);
            lblPrevTenSP.TabIndex = 28;
            lblPrevTenSP.Text = "sp";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(67, 209);
            label24.Name = "label24";
            label24.Size = new Size(92, 25);
            label24.TabIndex = 27;
            label24.Text = "Sản phẩm";
            // 
            // panel8
            // 
            panel8.BackColor = Color.DimGray;
            panel8.Location = new Point(67, 194);
            panel8.Name = "panel8";
            panel8.Size = new Size(391, 1);
            panel8.TabIndex = 26;
            // 
            // lblPrevSDT
            // 
            lblPrevSDT.AutoSize = true;
            lblPrevSDT.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblPrevSDT.Location = new Point(287, 146);
            lblPrevSDT.Name = "lblPrevSDT";
            lblPrevSDT.Size = new Size(43, 23);
            lblPrevSDT.TabIndex = 9;
            lblPrevSDT.Text = "SĐT";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 10.2F);
            label22.Location = new Point(67, 146);
            label22.Name = "label22";
            label22.Size = new Size(44, 23);
            label22.TabIndex = 8;
            label22.Text = "SĐT:";
            // 
            // lblPrevTenKH
            // 
            lblPrevTenKH.AutoSize = true;
            lblPrevTenKH.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblPrevTenKH.Location = new Point(283, 113);
            lblPrevTenKH.Name = "lblPrevTenKH";
            lblPrevTenKH.Size = new Size(65, 23);
            lblPrevTenKH.TabIndex = 9;
            lblPrevTenKH.Text = "tên KH";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(67, 111);
            label20.Name = "label20";
            label20.Size = new Size(108, 25);
            label20.TabIndex = 8;
            label20.Text = "Khách hàng:";
            // 
            // lblPrevMaBH
            // 
            lblPrevMaBH.AutoSize = true;
            lblPrevMaBH.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblPrevMaBH.ForeColor = Color.MediumBlue;
            lblPrevMaBH.Location = new Point(287, 80);
            lblPrevMaBH.Name = "lblPrevMaBH";
            lblPrevMaBH.Size = new Size(34, 23);
            lblPrevMaBH.TabIndex = 23;
            lblPrevMaBH.Text = "BH";
            lblPrevMaBH.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 10.2F);
            label17.Location = new Point(67, 80);
            label17.Name = "label17";
            label17.Size = new Size(113, 23);
            label17.TabIndex = 8;
            label17.Text = "Mã phiếu BH:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semilight", 9F);
            label16.Location = new Point(179, 41);
            label16.Name = "label16";
            label16.Size = new Size(170, 20);
            label16.TabIndex = 8;
            label16.Text = "Cửa hàng điện thoại LHP";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label14.Location = new Point(187, 13);
            label14.Name = "label14";
            label14.Size = new Size(156, 23);
            label14.TabIndex = 8;
            label14.Text = "PHIẾU BẢO HÀNH";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label13.ForeColor = Color.MediumBlue;
            label13.Location = new Point(16, 14);
            label13.Name = "label13";
            label13.Size = new Size(202, 23);
            label13.TabIndex = 29;
            label13.Text = "Preview phiếu bảo hành";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel4.BackColor = Color.White;
            panel4.Controls.Add(label12);
            panel4.Controls.Add(txtGhiChu);
            panel4.Controls.Add(cboDieuKien);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(dtpHetHan);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(cboThoiHan);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(dtpBatDau);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label7);
            panel4.Font = new Font("Segoe UI", 9F);
            panel4.Location = new Point(6, 446);
            panel4.Name = "panel4";
            panel4.Size = new Size(893, 484);
            panel4.TabIndex = 10;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.2F);
            label12.Location = new Point(17, 256);
            label12.Name = "label12";
            label12.Size = new Size(69, 23);
            label12.TabIndex = 20;
            label12.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Font = new Font("Segoe UI", 10.8F);
            txtGhiChu.Location = new Point(17, 282);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(809, 177);
            txtGhiChu.TabIndex = 19;
            txtGhiChu.Text = "Tình trạng máy khi bàn giao...";
            // 
            // cboDieuKien
            // 
            cboDieuKien.Font = new Font("Segoe UI", 10.2F);
            cboDieuKien.FormattingEnabled = true;
            cboDieuKien.Location = new Point(475, 172);
            cboDieuKien.Name = "cboDieuKien";
            cboDieuKien.Size = new Size(243, 31);
            cboDieuKien.TabIndex = 18;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.2F);
            label11.Location = new Point(475, 147);
            label11.Name = "label11";
            label11.Size = new Size(159, 23);
            label11.TabIndex = 17;
            label11.Text = "Điều kiện bảo hành";
            // 
            // dtpHetHan
            // 
            dtpHetHan.Font = new Font("Segoe UI", 10.2F);
            dtpHetHan.Location = new Point(15, 176);
            dtpHetHan.Name = "dtpHetHan";
            dtpHetHan.Size = new Size(351, 30);
            dtpHetHan.TabIndex = 16;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F);
            label10.Location = new Point(15, 150);
            label10.Name = "label10";
            label10.Size = new Size(141, 23);
            label10.TabIndex = 15;
            label10.Text = "Ngày hết hạn BH";
            // 
            // cboThoiHan
            // 
            cboThoiHan.Font = new Font("Segoe UI", 10.2F);
            cboThoiHan.FormattingEnabled = true;
            cboThoiHan.Location = new Point(475, 78);
            cboThoiHan.Name = "cboThoiHan";
            cboThoiHan.Size = new Size(243, 31);
            cboThoiHan.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F);
            label9.Location = new Point(475, 49);
            label9.Name = "label9";
            label9.Size = new Size(155, 23);
            label9.TabIndex = 13;
            label9.Text = "Thời hạn bảo hành";
            // 
            // dtpBatDau
            // 
            dtpBatDau.Font = new Font("Segoe UI", 10.2F);
            dtpBatDau.Location = new Point(15, 75);
            dtpBatDau.Name = "dtpBatDau";
            dtpBatDau.Size = new Size(351, 30);
            dtpBatDau.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F);
            label8.Location = new Point(15, 49);
            label8.Name = "label8";
            label8.Size = new Size(141, 23);
            label8.TabIndex = 10;
            label8.Text = "Ngày bắt đầu BH";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label7.ForeColor = Color.MediumBlue;
            label7.Location = new Point(17, 14);
            label7.Name = "label7";
            label7.Size = new Size(205, 23);
            label7.TabIndex = 8;
            label7.Text = "B3 - Thông tin bảo hành";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(dgvSanPham);
            panel3.Controls.Add(label15);
            panel3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel3.Location = new Point(6, 226);
            panel3.Name = "panel3";
            panel3.Size = new Size(893, 214);
            panel3.TabIndex = 1;
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.BackgroundColor = Color.White;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Columns.AddRange(new DataGridViewColumn[] { colChon, colImei, colTenSP, colSoLuong, colDonGia });
            dgvSanPham.Location = new Point(17, 49);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.Size = new Size(701, 162);
            dgvSanPham.TabIndex = 9;
            dgvSanPham.CellContentClick += dgvSanPham_CellContentClick;
            // 
            // colChon
            // 
            colChon.DataPropertyName = "Chon";
            colChon.HeaderText = "";
            colChon.MinimumWidth = 6;
            colChon.Name = "colChon";
            // 
            // colImei
            // 
            colImei.DataPropertyName = "Imei";
            colImei.HeaderText = "Mã IMEI";
            colImei.MinimumWidth = 6;
            colImei.Name = "colImei";
            // 
            // colTenSP
            // 
            colTenSP.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTenSP.DataPropertyName = "TenSP";
            colTenSP.HeaderText = "Sản phẩm";
            colTenSP.MinimumWidth = 6;
            colTenSP.Name = "colTenSP";
            // 
            // colSoLuong
            // 
            colSoLuong.DataPropertyName = "SoLuong";
            colSoLuong.HeaderText = "SL";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            // 
            // colDonGia
            // 
            colDonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle1.Format = "N0";
            colDonGia.DefaultCellStyle = dataGridViewCellStyle1;
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.MinimumWidth = 6;
            colDonGia.Name = "colDonGia";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label15.ForeColor = Color.MediumBlue;
            label15.Location = new Point(17, 14);
            label15.Name = "label15";
            label15.Size = new Size(250, 23);
            label15.TabIndex = 8;
            label15.Text = "B2 - Chọn sản phẩm bảo hành";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(txtTimKiemHD);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(893, 214);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblNgayMua);
            panel2.Controls.Add(lblKhachHang);
            panel2.Controls.Add(lblSDT);
            panel2.Controls.Add(lblMaHD);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(17, 76);
            panel2.Name = "panel2";
            panel2.Size = new Size(840, 120);
            panel2.TabIndex = 28;
            // 
            // lblNgayMua
            // 
            lblNgayMua.AutoSize = true;
            lblNgayMua.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblNgayMua.Location = new Point(387, 66);
            lblNgayMua.Name = "lblNgayMua";
            lblNgayMua.Size = new Size(92, 23);
            lblNgayMua.TabIndex = 7;
            lblNgayMua.Text = "Ngày mua";
            // 
            // lblKhachHang
            // 
            lblKhachHang.AutoSize = true;
            lblKhachHang.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblKhachHang.Location = new Point(401, 24);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(65, 23);
            lblKhachHang.TabIndex = 6;
            lblKhachHang.Text = "tên KH";
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblSDT.Location = new Point(80, 66);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(43, 23);
            lblSDT.TabIndex = 5;
            lblSDT.Text = "SĐT";
            // 
            // lblMaHD
            // 
            lblMaHD.AutoSize = true;
            lblMaHD.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblMaHD.Location = new Point(98, 24);
            lblMaHD.Name = "lblMaHD";
            lblMaHD.Size = new Size(36, 23);
            lblMaHD.TabIndex = 4;
            lblMaHD.Text = "HD";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F);
            label6.Location = new Point(288, 66);
            label6.Name = "label6";
            label6.Size = new Size(93, 23);
            label6.TabIndex = 3;
            label6.Text = "Ngày mua:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F);
            label5.Location = new Point(30, 66);
            label5.Name = "label5";
            label5.Size = new Size(44, 23);
            label5.TabIndex = 2;
            label5.Text = "SĐT:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(287, 22);
            label4.Name = "label4";
            label4.Size = new Size(108, 25);
            label4.TabIndex = 1;
            label4.Text = "Khách hàng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(25, 24);
            label2.Name = "label2";
            label2.Size = new Size(67, 23);
            label2.TabIndex = 0;
            label2.Text = "Mã HD:";
            // 
            // txtTimKiemHD
            // 
            txtTimKiemHD.Font = new Font("Segoe UI", 10.2F);
            txtTimKiemHD.Location = new Point(17, 40);
            txtTimKiemHD.Name = "txtTimKiemHD";
            txtTimKiemHD.Size = new Size(467, 30);
            txtTimKiemHD.TabIndex = 9;
            txtTimKiemHD.Text = "Nhập mã HD hoặc SĐT khách hàng...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.MediumBlue;
            label3.Location = new Point(17, 14);
            label3.Name = "label3";
            label3.Size = new Size(184, 23);
            label3.TabIndex = 8;
            label3.Text = "B1 - Tìm hóa đơn gốc";
            // 
            // tabBaoHanh
            // 
            tabBaoHanh.Appearance = TabAppearance.FlatButtons;
            tabBaoHanh.Controls.Add(tabPage1);
            tabBaoHanh.Controls.Add(tabPage2);
            tabBaoHanh.Dock = DockStyle.Fill;
            tabBaoHanh.Font = new Font("Segoe UI", 10.8F);
            tabBaoHanh.ItemSize = new Size(760, 40);
            tabBaoHanh.Location = new Point(0, 0);
            tabBaoHanh.Name = "tabBaoHanh";
            tabBaoHanh.SelectedIndex = 0;
            tabBaoHanh.Size = new Size(1546, 986);
            tabBaoHanh.SizeMode = TabSizeMode.Fixed;
            tabBaoHanh.TabIndex = 6;
            // 
            // picQRCode
            // 
            picQRCode.Location = new Point(156, 399);
            picQRCode.Name = "picQRCode";
            picQRCode.Size = new Size(217, 111);
            picQRCode.SizeMode = PictureBoxSizeMode.Zoom;
            picQRCode.TabIndex = 38;
            picQRCode.TabStop = false;
            // 
            // UC_BaoHanh
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(tabBaoHanh);
            Controls.Add(label1);
            Name = "UC_BaoHanh";
            Size = new Size(1546, 986);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTraCuu).EndInit();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            tabPage1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabBaoHanh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picQRCode).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private TabControl tabBaoHanh;
        private Panel panel1;
        private TextBox txtTimKiemHD;
        private Label label3;
        private Panel panel2;
        private Label label2;
        private Label lblSDT;
        private Label lblMaHD;
        private Label label6;
        private Label label5;
        private Label label4;
        private Panel panel4;
        private Label label7;
        private Panel panel3;
        private DataGridView dgvSanPham;
        private Label label15;
        private Label lblNgayMua;
        private Label lblKhachHang;
        private DateTimePicker dtpHetHan;
        private Label label10;
        private ComboBox cboThoiHan;
        private Label label9;
        private DateTimePicker dtpBatDau;
        private Label label8;
        private ComboBox cboDieuKien;
        private Label label11;
        private Label label12;
        private TextBox txtGhiChu;
        private Panel panel5;
        private Label label13;
        private Panel panel6;
        private Panel panel7;
        private Label label16;
        private Label label14;
        private Label label17;
        private Panel panel8;
        private Label lblPrevSDT;
        private Label label22;
        private Label lblPrevTenKH;
        private Label label20;
        private Label lblPrevMaBH;
        private Label label33;
        private Panel panel9;
        private Label lblPrevDieuKien;
        private Label label32;
        private Label lblPrevHetHan;
        private Label label30;
        private Label lblPrevBatDau;
        private Label label28;
        private Label lblPrevNgayMua;
        private Label label26;
        private Label lblPrevTenSP;
        private Label label24;
        private Button btnInPhieu;
        private Button btnTaoPhieu;
        private Panel panel10;
        private TextBox txtTimKiemTraCuu;
        private ComboBox cboTrangThaiTraCuu;
        private DataGridView dgvTraCuu;
        private DataGridViewCheckBoxColumn colChon;
        private DataGridViewTextBoxColumn colImei;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colMaPhieuBH;
        private DataGridViewTextBoxColumn colKhachHang;
        private DataGridViewTextBoxColumn colSanPhamBH;
        private DataGridViewTextBoxColumn colHetHan;
        private DataGridViewTextBoxColumn colTrangThaiBH;
        private DataGridViewButtonColumn colThaoTac;
        private PictureBox picQRCode;
    }
}
