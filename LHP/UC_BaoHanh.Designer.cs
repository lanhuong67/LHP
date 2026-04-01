namespace LHP
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
            label1 = new Label();
            tabPage2 = new TabPage();
            dgvTraCuu = new DataGridView();
            panel10 = new Panel();
            button2 = new Button();
            cboTraCuu = new ComboBox();
            txtTracCuu = new TextBox();
            tabPage1 = new TabPage();
            panel5 = new Panel();
            btnInPhieu = new Button();
            btnTaoPhieuBH = new Button();
            panel7 = new Panel();
            panel6 = new Panel();
            label33 = new Label();
            panel9 = new Panel();
            lblDieuKien = new Label();
            label32 = new Label();
            lblNgayHhBh = new Label();
            label30 = new Label();
            lblNgayBdBh = new Label();
            label28 = new Label();
            lblNgayMuaSp = new Label();
            label26 = new Label();
            lblTenSP = new Label();
            label24 = new Label();
            panel8 = new Panel();
            lblSDTPhieu = new Label();
            label22 = new Label();
            lblTenPhieuKH = new Label();
            label20 = new Label();
            lblMaPhieuBH = new Label();
            label17 = new Label();
            label16 = new Label();
            label14 = new Label();
            label13 = new Label();
            panel4 = new Panel();
            label12 = new Label();
            txtGhiChu = new TextBox();
            cboDieuKien = new ComboBox();
            label11 = new Label();
            dtpNgayHhBh = new DateTimePicker();
            label10 = new Label();
            cboThoiHan = new ComboBox();
            label9 = new Label();
            dtpNgayBdBH = new DateTimePicker();
            label8 = new Label();
            label7 = new Label();
            panel3 = new Panel();
            dgvChonSpBaoHanh = new DataGridView();
            colChon = new DataGridViewCheckBoxColumn();
            colSanPham = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            label15 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            lblNgayMua = new Label();
            lblTenKh = new Label();
            lblSĐT = new Label();
            lblMaHD = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            button1 = new Button();
            txtMaPhieu = new TextBox();
            label3 = new Label();
            tabBaoHanh = new TabControl();
            colMaPhieuBH = new DataGridViewTextBoxColumn();
            colKhachHang = new DataGridViewTextBoxColumn();
            colSanPhamBH = new DataGridViewTextBoxColumn();
            colHetHan = new DataGridViewTextBoxColumn();
            colTrangThaiBH = new DataGridViewTextBoxColumn();
            colThaoTac = new DataGridViewButtonColumn();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTraCuu).BeginInit();
            panel10.SuspendLayout();
            tabPage1.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChonSpBaoHanh).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabBaoHanh.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
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
            tabPage2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            tabPage2.Location = new Point(4, 44);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1048, 826);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tra cứu / xử lý";
            // 
            // dgvTraCuu
            // 
            dgvTraCuu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTraCuu.BackgroundColor = Color.White;
            dgvTraCuu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTraCuu.Columns.AddRange(new DataGridViewColumn[] { colMaPhieuBH, colKhachHang, colSanPhamBH, colHetHan, colTrangThaiBH, colThaoTac });
            dgvTraCuu.Location = new Point(6, 81);
            dgvTraCuu.Name = "dgvTraCuu";
            dgvTraCuu.RowHeadersWidth = 51;
            dgvTraCuu.RowTemplate.Height = 29;
            dgvTraCuu.Size = new Size(1034, 737);
            dgvTraCuu.TabIndex = 2;
            // 
            // panel10
            // 
            panel10.BackColor = Color.White;
            panel10.Controls.Add(button2);
            panel10.Controls.Add(cboTraCuu);
            panel10.Controls.Add(txtTracCuu);
            panel10.Location = new Point(6, 6);
            panel10.Name = "panel10";
            panel10.Size = new Size(1034, 69);
            panel10.TabIndex = 1;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.HotTrack;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(839, 16);
            button2.Name = "button2";
            button2.Size = new Size(180, 31);
            button2.TabIndex = 33;
            button2.Text = "Tra cứu";
            button2.UseVisualStyleBackColor = false;
            // 
            // cboTraCuu
            // 
            cboTraCuu.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            cboTraCuu.FormattingEnabled = true;
            cboTraCuu.Location = new Point(496, 16);
            cboTraCuu.Name = "cboTraCuu";
            cboTraCuu.Size = new Size(305, 31);
            cboTraCuu.TabIndex = 1;
            cboTraCuu.Text = "--Tất cả trạng thái--";
            // 
            // txtTracCuu
            // 
            txtTracCuu.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtTracCuu.Location = new Point(22, 16);
            txtTracCuu.Name = "txtTracCuu";
            txtTracCuu.Size = new Size(445, 30);
            txtTracCuu.TabIndex = 0;
            txtTracCuu.Text = "Mã phiếu BH, tên KH, SĐT,..";
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
            tabPage1.Size = new Size(1048, 826);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Tạo phiếu bảo hành";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.BackgroundImageLayout = ImageLayout.None;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(btnInPhieu);
            panel5.Controls.Add(btnTaoPhieuBH);
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(label13);
            panel5.Location = new Point(524, 6);
            panel5.Name = "panel5";
            panel5.Size = new Size(516, 812);
            panel5.TabIndex = 11;
            // 
            // btnInPhieu
            // 
            btnInPhieu.BackColor = Color.Gainsboro;
            btnInPhieu.FlatStyle = FlatStyle.Flat;
            btnInPhieu.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnInPhieu.ForeColor = Color.Black;
            btnInPhieu.Location = new Point(122, 717);
            btnInPhieu.Name = "btnInPhieu";
            btnInPhieu.Size = new Size(273, 42);
            btnInPhieu.TabIndex = 31;
            btnInPhieu.Text = "In phiếu";
            btnInPhieu.UseVisualStyleBackColor = false;
            // 
            // btnTaoPhieuBH
            // 
            btnTaoPhieuBH.BackColor = SystemColors.HotTrack;
            btnTaoPhieuBH.FlatStyle = FlatStyle.Flat;
            btnTaoPhieuBH.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnTaoPhieuBH.ForeColor = Color.White;
            btnTaoPhieuBH.Location = new Point(122, 640);
            btnTaoPhieuBH.Name = "btnTaoPhieuBH";
            btnTaoPhieuBH.Size = new Size(273, 42);
            btnTaoPhieuBH.TabIndex = 32;
            btnTaoPhieuBH.Text = "Tạo phiếu bảo hành";
            btnTaoPhieuBH.UseVisualStyleBackColor = false;
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
            panel6.Controls.Add(label33);
            panel6.Controls.Add(panel9);
            panel6.Controls.Add(lblDieuKien);
            panel6.Controls.Add(label32);
            panel6.Controls.Add(lblNgayHhBh);
            panel6.Controls.Add(label30);
            panel6.Controls.Add(lblNgayBdBh);
            panel6.Controls.Add(label28);
            panel6.Controls.Add(lblNgayMuaSp);
            panel6.Controls.Add(label26);
            panel6.Controls.Add(lblTenSP);
            panel6.Controls.Add(label24);
            panel6.Controls.Add(panel8);
            panel6.Controls.Add(lblSDTPhieu);
            panel6.Controls.Add(label22);
            panel6.Controls.Add(lblTenPhieuKH);
            panel6.Controls.Add(label20);
            panel6.Controls.Add(lblMaPhieuBH);
            panel6.Controls.Add(label17);
            panel6.Controls.Add(label16);
            panel6.Controls.Add(label14);
            panel6.Location = new Point(41, 60);
            panel6.Name = "panel6";
            panel6.Size = new Size(432, 548);
            panel6.TabIndex = 30;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label33.Location = new Point(144, 517);
            label33.Name = "label33";
            label33.Size = new Size(134, 20);
            label33.TabIndex = 37;
            label33.Text = "Quét để tra cứu BH";
            // 
            // panel9
            // 
            panel9.BackColor = Color.DimGray;
            panel9.Location = new Point(17, 392);
            panel9.Name = "panel9";
            panel9.Size = new Size(391, 1);
            panel9.TabIndex = 27;
            // 
            // lblDieuKien
            // 
            lblDieuKien.AutoSize = true;
            lblDieuKien.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblDieuKien.Location = new Point(317, 347);
            lblDieuKien.Name = "lblDieuKien";
            lblDieuKien.Size = new Size(86, 23);
            lblDieuKien.TabIndex = 36;
            lblDieuKien.Text = "Điều kiện";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(14, 347);
            label32.Name = "label32";
            label32.Size = new Size(89, 25);
            label32.TabIndex = 35;
            label32.Text = "Điều kiện:";
            // 
            // lblNgayHhBh
            // 
            lblNgayHhBh.AutoSize = true;
            lblNgayHhBh.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblNgayHhBh.Location = new Point(368, 312);
            lblNgayHhBh.Name = "lblNgayHhBh";
            lblNgayHhBh.Size = new Size(34, 23);
            lblNgayHhBh.TabIndex = 34;
            lblNgayHhBh.Text = "///";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(14, 312);
            label30.Name = "label30";
            label30.Size = new Size(106, 25);
            label30.TabIndex = 33;
            label30.Text = "Hết hạn BH:";
            // 
            // lblNgayBdBh
            // 
            lblNgayBdBh.AutoSize = true;
            lblNgayBdBh.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblNgayBdBh.Location = new Point(368, 277);
            lblNgayBdBh.Name = "lblNgayBdBh";
            lblNgayBdBh.Size = new Size(34, 23);
            lblNgayBdBh.TabIndex = 32;
            lblNgayBdBh.Text = "///";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(14, 277);
            label28.Name = "label28";
            label28.Size = new Size(104, 25);
            label28.TabIndex = 31;
            label28.Text = "Bắt đầu BH:";
            // 
            // lblNgayMuaSp
            // 
            lblNgayMuaSp.AutoSize = true;
            lblNgayMuaSp.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblNgayMuaSp.Location = new Point(368, 242);
            lblNgayMuaSp.Name = "lblNgayMuaSp";
            lblNgayMuaSp.Size = new Size(34, 23);
            lblNgayMuaSp.TabIndex = 30;
            lblNgayMuaSp.Text = "///";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(14, 242);
            label26.Name = "label26";
            label26.Size = new Size(94, 25);
            label26.TabIndex = 29;
            label26.Text = "Ngày mua";
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblTenSP.Location = new Point(374, 209);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(28, 23);
            lblTenSP.TabIndex = 28;
            lblTenSP.Text = "sp";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(14, 209);
            label24.Name = "label24";
            label24.Size = new Size(92, 25);
            label24.TabIndex = 27;
            label24.Text = "Sản phẩm";
            // 
            // panel8
            // 
            panel8.BackColor = Color.DimGray;
            panel8.Location = new Point(14, 194);
            panel8.Name = "panel8";
            panel8.Size = new Size(391, 1);
            panel8.TabIndex = 26;
            // 
            // lblSDTPhieu
            // 
            lblSDTPhieu.AutoSize = true;
            lblSDTPhieu.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblSDTPhieu.Location = new Point(365, 146);
            lblSDTPhieu.Name = "lblSDTPhieu";
            lblSDTPhieu.Size = new Size(43, 23);
            lblSDTPhieu.TabIndex = 9;
            lblSDTPhieu.Text = "SĐT";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label22.Location = new Point(14, 146);
            label22.Name = "label22";
            label22.Size = new Size(44, 23);
            label22.TabIndex = 8;
            label22.Text = "SĐT:";
            // 
            // lblTenPhieuKH
            // 
            lblTenPhieuKH.AutoSize = true;
            lblTenPhieuKH.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblTenPhieuKH.Location = new Point(343, 111);
            lblTenPhieuKH.Name = "lblTenPhieuKH";
            lblTenPhieuKH.Size = new Size(65, 23);
            lblTenPhieuKH.TabIndex = 9;
            lblTenPhieuKH.Text = "tên KH";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(14, 111);
            label20.Name = "label20";
            label20.Size = new Size(108, 25);
            label20.TabIndex = 8;
            label20.Text = "Khách hàng:";
            // 
            // lblMaPhieuBH
            // 
            lblMaPhieuBH.AutoSize = true;
            lblMaPhieuBH.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblMaPhieuBH.ForeColor = Color.MediumBlue;
            lblMaPhieuBH.Location = new Point(374, 77);
            lblMaPhieuBH.Name = "lblMaPhieuBH";
            lblMaPhieuBH.Size = new Size(34, 23);
            lblMaPhieuBH.TabIndex = 23;
            lblMaPhieuBH.Text = "BH";
            lblMaPhieuBH.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(14, 80);
            label17.Name = "label17";
            label17.Size = new Size(113, 23);
            label17.TabIndex = 8;
            label17.Text = "Mã phiếu BH:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(126, 41);
            label16.Name = "label16";
            label16.Size = new Size(170, 20);
            label16.TabIndex = 8;
            label16.Text = "Cửa hàng điện thoại LHP";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(134, 13);
            label14.Name = "label14";
            label14.Size = new Size(156, 23);
            label14.TabIndex = 8;
            label14.Text = "PHIẾU BẢO HÀNH";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.MediumBlue;
            label13.Location = new Point(16, 14);
            label13.Name = "label13";
            label13.Size = new Size(202, 23);
            label13.TabIndex = 29;
            label13.Text = "Preview phiếu bảo hành";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(label12);
            panel4.Controls.Add(txtGhiChu);
            panel4.Controls.Add(cboDieuKien);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(dtpNgayHhBh);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(cboThoiHan);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(dtpNgayBdBH);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label7);
            panel4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panel4.Location = new Point(6, 446);
            panel4.Name = "panel4";
            panel4.Size = new Size(512, 372);
            panel4.TabIndex = 10;
            panel4.Paint += panel4_Paint;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(17, 201);
            label12.Name = "label12";
            label12.Size = new Size(69, 23);
            label12.TabIndex = 20;
            label12.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtGhiChu.Location = new Point(17, 227);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(480, 121);
            txtGhiChu.TabIndex = 19;
            txtGhiChu.Text = "Tình trạng máy khi bàn giao...";
            // 
            // cboDieuKien
            // 
            cboDieuKien.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            cboDieuKien.FormattingEnabled = true;
            cboDieuKien.Location = new Point(260, 150);
            cboDieuKien.Name = "cboDieuKien";
            cboDieuKien.Size = new Size(237, 31);
            cboDieuKien.TabIndex = 18;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(260, 125);
            label11.Name = "label11";
            label11.Size = new Size(159, 23);
            label11.TabIndex = 17;
            label11.Text = "Điều kiện bảo hành";
            // 
            // dtpNgayHhBh
            // 
            dtpNgayHhBh.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            dtpNgayHhBh.Location = new Point(15, 151);
            dtpNgayHhBh.Name = "dtpNgayHhBh";
            dtpNgayHhBh.Size = new Size(237, 30);
            dtpNgayHhBh.TabIndex = 16;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(15, 125);
            label10.Name = "label10";
            label10.Size = new Size(141, 23);
            label10.TabIndex = 15;
            label10.Text = "Ngày hết hạn BH";
            // 
            // cboThoiHan
            // 
            cboThoiHan.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            cboThoiHan.FormattingEnabled = true;
            cboThoiHan.Location = new Point(260, 74);
            cboThoiHan.Name = "cboThoiHan";
            cboThoiHan.Size = new Size(237, 31);
            cboThoiHan.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(260, 49);
            label9.Name = "label9";
            label9.Size = new Size(155, 23);
            label9.TabIndex = 13;
            label9.Text = "Thời hạn bảo hành";
            // 
            // dtpNgayBdBH
            // 
            dtpNgayBdBH.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            dtpNgayBdBH.Location = new Point(15, 75);
            dtpNgayBdBH.Name = "dtpNgayBdBH";
            dtpNgayBdBH.Size = new Size(237, 30);
            dtpNgayBdBH.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(15, 49);
            label8.Name = "label8";
            label8.Size = new Size(141, 23);
            label8.TabIndex = 10;
            label8.Text = "Ngày bắt đầu BH";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
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
            panel3.Controls.Add(dgvChonSpBaoHanh);
            panel3.Controls.Add(label15);
            panel3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            panel3.Location = new Point(6, 226);
            panel3.Name = "panel3";
            panel3.Size = new Size(512, 214);
            panel3.TabIndex = 1;
            // 
            // dgvChonSpBaoHanh
            // 
            dgvChonSpBaoHanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChonSpBaoHanh.BackgroundColor = Color.White;
            dgvChonSpBaoHanh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChonSpBaoHanh.Columns.AddRange(new DataGridViewColumn[] { colChon, colSanPham, colSoLuong, colDonGia });
            dgvChonSpBaoHanh.Location = new Point(17, 40);
            dgvChonSpBaoHanh.Name = "dgvChonSpBaoHanh";
            dgvChonSpBaoHanh.RowHeadersWidth = 51;
            dgvChonSpBaoHanh.RowTemplate.Height = 29;
            dgvChonSpBaoHanh.Size = new Size(480, 162);
            dgvChonSpBaoHanh.TabIndex = 9;
            // 
            // colChon
            // 
            colChon.HeaderText = "";
            colChon.MinimumWidth = 6;
            colChon.Name = "colChon";
            // 
            // colSanPham
            // 
            colSanPham.HeaderText = "Sản phẩm";
            colSanPham.MinimumWidth = 6;
            colSanPham.Name = "colSanPham";
            // 
            // colSoLuong
            // 
            colSoLuong.HeaderText = "SL";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            // 
            // colDonGia
            // 
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.MinimumWidth = 6;
            colDonGia.Name = "colDonGia";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
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
            panel1.Controls.Add(button1);
            panel1.Controls.Add(txtMaPhieu);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(512, 214);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblNgayMua);
            panel2.Controls.Add(lblTenKh);
            panel2.Controls.Add(lblSĐT);
            panel2.Controls.Add(lblMaHD);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(17, 76);
            panel2.Name = "panel2";
            panel2.Size = new Size(480, 120);
            panel2.TabIndex = 28;
            // 
            // lblNgayMua
            // 
            lblNgayMua.AutoSize = true;
            lblNgayMua.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblNgayMua.Location = new Point(111, 80);
            lblNgayMua.Name = "lblNgayMua";
            lblNgayMua.Size = new Size(92, 23);
            lblNgayMua.TabIndex = 7;
            lblNgayMua.Text = "Ngày mua";
            // 
            // lblTenKh
            // 
            lblTenKh.AutoSize = true;
            lblTenKh.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblTenKh.Location = new Point(126, 45);
            lblTenKh.Name = "lblTenKh";
            lblTenKh.Size = new Size(65, 23);
            lblTenKh.TabIndex = 6;
            lblTenKh.Text = "tên KH";
            // 
            // lblSĐT
            // 
            lblSĐT.AutoSize = true;
            lblSĐT.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblSĐT.Location = new Point(273, 9);
            lblSĐT.Name = "lblSĐT";
            lblSĐT.Size = new Size(43, 23);
            lblSĐT.TabIndex = 5;
            lblSĐT.Text = "SĐT";
            // 
            // lblMaHD
            // 
            lblMaHD.AutoSize = true;
            lblMaHD.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblMaHD.Location = new Point(85, 9);
            lblMaHD.Name = "lblMaHD";
            lblMaHD.Size = new Size(36, 23);
            lblMaHD.TabIndex = 4;
            lblMaHD.Text = "HD";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(12, 80);
            label6.Name = "label6";
            label6.Size = new Size(93, 23);
            label6.TabIndex = 3;
            label6.Text = "Ngày mua:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(223, 9);
            label5.Name = "label5";
            label5.Size = new Size(44, 23);
            label5.TabIndex = 2;
            label5.Text = "SĐT:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 43);
            label4.Name = "label4";
            label4.Size = new Size(108, 25);
            label4.TabIndex = 1;
            label4.Text = "Khách hàng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(67, 23);
            label2.TabIndex = 0;
            label2.Text = "Mã HD:";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.HotTrack;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(376, 40);
            button1.Name = "button1";
            button1.Size = new Size(121, 30);
            button1.TabIndex = 27;
            button1.Text = "Tìm";
            button1.UseVisualStyleBackColor = false;
            // 
            // txtMaPhieu
            // 
            txtMaPhieu.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtMaPhieu.Location = new Point(17, 40);
            txtMaPhieu.Name = "txtMaPhieu";
            txtMaPhieu.Size = new Size(343, 30);
            txtMaPhieu.TabIndex = 9;
            txtMaPhieu.Text = "Nhập mã HD hoặc SĐT khách hàng...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
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
            tabBaoHanh.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            tabBaoHanh.ItemSize = new Size(516, 40);
            tabBaoHanh.Location = new Point(28, 54);
            tabBaoHanh.Name = "tabBaoHanh";
            tabBaoHanh.SelectedIndex = 0;
            tabBaoHanh.Size = new Size(1056, 874);
            tabBaoHanh.SizeMode = TabSizeMode.Fixed;
            tabBaoHanh.TabIndex = 6;
            // 
            // colMaPhieuBH
            // 
            colMaPhieuBH.HeaderText = "Mã phiếu BH";
            colMaPhieuBH.MinimumWidth = 6;
            colMaPhieuBH.Name = "colMaPhieuBH";
            // 
            // colKhachHang
            // 
            colKhachHang.HeaderText = "Khách hàng";
            colKhachHang.MinimumWidth = 6;
            colKhachHang.Name = "colKhachHang";
            // 
            // colSanPhamBH
            // 
            colSanPhamBH.HeaderText = "Sản phẩm";
            colSanPhamBH.MinimumWidth = 6;
            colSanPhamBH.Name = "colSanPhamBH";
            // 
            // colHetHan
            // 
            colHetHan.HeaderText = "Hết hạn BH";
            colHetHan.MinimumWidth = 6;
            colHetHan.Name = "colHetHan";
            // 
            // colTrangThaiBH
            // 
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
            // UC_BaoHanh
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(tabBaoHanh);
            Controls.Add(label1);
            Name = "UC_BaoHanh";
            Size = new Size(1113, 938);
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
            ((System.ComponentModel.ISupportInitialize)dgvChonSpBaoHanh).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabBaoHanh.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private TabControl tabBaoHanh;
        private Panel panel1;
        private Button button1;
        private TextBox txtMaPhieu;
        private Label label3;
        private Panel panel2;
        private Label label2;
        private Label lblSĐT;
        private Label lblMaHD;
        private Label label6;
        private Label label5;
        private Label label4;
        private Panel panel4;
        private Label label7;
        private Panel panel3;
        private DataGridView dgvChonSpBaoHanh;
        private DataGridViewCheckBoxColumn colChon;
        private DataGridViewTextBoxColumn colSanPham;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDonGia;
        private Label label15;
        private Label lblNgayMua;
        private Label lblTenKh;
        private DateTimePicker dtpNgayHhBh;
        private Label label10;
        private ComboBox cboThoiHan;
        private Label label9;
        private DateTimePicker dtpNgayBdBH;
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
        private Label lblSDTPhieu;
        private Label label22;
        private Label lblTenPhieuKH;
        private Label label20;
        private Label lblMaPhieuBH;
        private Label label33;
        private Panel panel9;
        private Label lblDieuKien;
        private Label label32;
        private Label lblNgayHhBh;
        private Label label30;
        private Label lblNgayBdBh;
        private Label label28;
        private Label lblNgayMuaSp;
        private Label label26;
        private Label lblTenSP;
        private Label label24;
        private Button btnInPhieu;
        private Button btnTaoPhieuBH;
        private Panel panel10;
        private TextBox txtTracCuu;
        private ComboBox cboTraCuu;
        private Button button2;
        private DataGridView dgvTraCuu;
        private DataGridViewTextBoxColumn colMaPhieuBH;
        private DataGridViewTextBoxColumn colKhachHang;
        private DataGridViewTextBoxColumn colSanPhamBH;
        private DataGridViewTextBoxColumn colHetHan;
        private DataGridViewTextBoxColumn colTrangThaiBH;
        private DataGridViewButtonColumn colThaoTac;
    }
}
