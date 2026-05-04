namespace GUI
{
    partial class UC_NhapHangLo
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnHuyPhieu = new Button();
            btnLuuNhap = new Button();
            btnXacNhan = new Button();
            dgvChiTietNhap = new DataGridView();
            colNhap_STT = new DataGridViewTextBoxColumn();
            colNhap_SanPham = new DataGridViewTextBoxColumn();
            colNhap_SoLuong = new DataGridViewTextBoxColumn();
            colNhap_GiaNhap = new DataGridViewTextBoxColumn();
            colNhap_ThanhTien = new DataGridViewTextBoxColumn();
            colNhap_Xoa = new DataGridViewButtonColumn();
            panel3 = new Panel();
            btnThem = new Button();
            txtGiaNhap = new TextBox();
            numSoLuong = new NumericUpDown();
            label11 = new Label();
            label10 = new Label();
            cboSanPham = new ComboBox();
            cboHangSX_Loc = new ComboBox();
            label9 = new Label();
            panel2 = new Panel();
            lblTongSoLuong = new Label();
            lblSoLoaiSP = new Label();
            lblTongTienNhap = new Label();
            label15 = new Label();
            panel4 = new Panel();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            panel1 = new Panel();
            txtGhiChu = new TextBox();
            label8 = new Label();
            txtSoHoaDonNCC = new TextBox();
            label7 = new Label();
            cboNhaCungCap = new ComboBox();
            label6 = new Label();
            cboChiNhanh = new ComboBox();
            dtpNgayNhap = new DateTimePicker();
            label5 = new Label();
            label4 = new Label();
            txtMaPhieu = new TextBox();
            label3 = new Label();
            label2 = new Label();
            tabPage2 = new TabPage();
            dgvLichSuNhapHang = new DataGridView();
            colMaPhieu = new DataGridViewTextBoxColumn();
            colNgayNhap = new DataGridViewTextBoxColumn();
            colNCC = new DataGridViewTextBoxColumn();
            colNhanVien = new DataGridViewTextBoxColumn();
            colSoSp = new DataGridViewTextBoxColumn();
            colTongTien = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colChiTiet = new DataGridViewButtonColumn();
            panel8 = new Panel();
            label23 = new Label();
            label22 = new Label();
            panel7 = new Panel();
            lblTongSpDaNhap = new Label();
            label21 = new Label();
            panel6 = new Panel();
            lblTongPhieuNhap = new Label();
            label20 = new Label();
            panel5 = new Panel();
            cboNcc = new ComboBox();
            btnLamMoi = new Button();
            btnTimKiem = new Button();
            cboTrangThai = new ComboBox();
            label19 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            tabPage3 = new TabPage();
            dgvTheoDoiLoHang = new DataGridView();
            colMaLo = new DataGridViewTextBoxColumn();
            colSanPham = new DataGridViewTextBoxColumn();
            colPhieuNhap = new DataGridViewTextBoxColumn();
            colNgayNhapLoHang = new DataGridViewTextBoxColumn();
            colSoLuongNhap = new DataGridViewTextBoxColumn();
            colDaBan = new DataGridViewTextBoxColumn();
            colConLai = new DataGridViewTextBoxColumn();
            colTrangThaiLoHang = new DataGridViewTextBoxColumn();
            panel9 = new Panel();
            btnTimLoHang = new Button();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichSuNhapHang).BeginInit();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTheoDoiLoHang).BeginInit();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(36, 11);
            label1.Name = "label1";
            label1.Size = new Size(191, 35);
            label1.TabIndex = 3;
            label1.Text = "Nhập hàng / lô";
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Font = new Font("Segoe UI", 10.8F);
            tabControl1.ItemSize = new Size(341, 40);
            tabControl1.Location = new Point(36, 54);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1056, 874);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.LightSteelBlue;
            tabPage1.BorderStyle = BorderStyle.FixedSingle;
            tabPage1.Controls.Add(btnHuyPhieu);
            tabPage1.Controls.Add(btnLuuNhap);
            tabPage1.Controls.Add(btnXacNhan);
            tabPage1.Controls.Add(dgvChiTietNhap);
            tabPage1.Controls.Add(panel3);
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 44);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1048, 826);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Tạo phiếu nhập";
            // 
            // btnHuyPhieu
            // 
            btnHuyPhieu.BackColor = Color.White;
            btnHuyPhieu.FlatStyle = FlatStyle.Flat;
            btnHuyPhieu.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnHuyPhieu.ForeColor = Color.Red;
            btnHuyPhieu.Location = new Point(637, 282);
            btnHuyPhieu.Name = "btnHuyPhieu";
            btnHuyPhieu.Size = new Size(380, 48);
            btnHuyPhieu.TabIndex = 29;
            btnHuyPhieu.Text = "Hủy phiếu";
            btnHuyPhieu.UseVisualStyleBackColor = false;
            btnHuyPhieu.Click += btnHuyPhieu_Click;
            // 
            // btnLuuNhap
            // 
            btnLuuNhap.BackColor = Color.White;
            btnLuuNhap.FlatStyle = FlatStyle.Flat;
            btnLuuNhap.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLuuNhap.ForeColor = Color.Black;
            btnLuuNhap.Location = new Point(637, 226);
            btnLuuNhap.Name = "btnLuuNhap";
            btnLuuNhap.Size = new Size(380, 48);
            btnLuuNhap.TabIndex = 28;
            btnLuuNhap.Text = "Lưu nháp";
            btnLuuNhap.UseVisualStyleBackColor = false;
            btnLuuNhap.Click += btnLuuNhap_Click;
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = SystemColors.HotTrack;
            btnXacNhan.FlatStyle = FlatStyle.Flat;
            btnXacNhan.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnXacNhan.ForeColor = Color.White;
            btnXacNhan.Location = new Point(637, 171);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(380, 48);
            btnXacNhan.TabIndex = 27;
            btnXacNhan.Text = "Xác nhận nhập kho";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // dgvChiTietNhap
            // 
            dgvChiTietNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietNhap.BackgroundColor = Color.White;
            dgvChiTietNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietNhap.Columns.AddRange(new DataGridViewColumn[] { colNhap_STT, colNhap_SanPham, colNhap_SoLuong, colNhap_GiaNhap, colNhap_ThanhTien, colNhap_Xoa });
            dgvChiTietNhap.Location = new Point(6, 341);
            dgvChiTietNhap.Name = "dgvChiTietNhap";
            dgvChiTietNhap.RowHeadersWidth = 51;
            dgvChiTietNhap.Size = new Size(1034, 477);
            dgvChiTietNhap.TabIndex = 3;
            dgvChiTietNhap.CellClick += dgvChiTietNhap_CellContentClick;
            // 
            // colNhap_STT
            // 
            colNhap_STT.HeaderText = "STT";
            colNhap_STT.MinimumWidth = 6;
            colNhap_STT.Name = "colNhap_STT";
            // 
            // colNhap_SanPham
            // 
            colNhap_SanPham.DataPropertyName = "TenSP";
            colNhap_SanPham.HeaderText = "Sản phẩm";
            colNhap_SanPham.MinimumWidth = 6;
            colNhap_SanPham.Name = "colNhap_SanPham";
            // 
            // colNhap_SoLuong
            // 
            colNhap_SoLuong.DataPropertyName = "SoLuong";
            colNhap_SoLuong.HeaderText = "Số lượng";
            colNhap_SoLuong.MinimumWidth = 6;
            colNhap_SoLuong.Name = "colNhap_SoLuong";
            // 
            // colNhap_GiaNhap
            // 
            colNhap_GiaNhap.DataPropertyName = "GiaNhap";
            colNhap_GiaNhap.HeaderText = "Giá nhập";
            colNhap_GiaNhap.MinimumWidth = 6;
            colNhap_GiaNhap.Name = "colNhap_GiaNhap";
            // 
            // colNhap_ThanhTien
            // 
            colNhap_ThanhTien.DataPropertyName = "ThanhTien";
            colNhap_ThanhTien.HeaderText = "Thành tiền";
            colNhap_ThanhTien.MinimumWidth = 6;
            colNhap_ThanhTien.Name = "colNhap_ThanhTien";
            // 
            // colNhap_Xoa
            // 
            colNhap_Xoa.HeaderText = "Xóa";
            colNhap_Xoa.MinimumWidth = 6;
            colNhap_Xoa.Name = "colNhap_Xoa";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(btnThem);
            panel3.Controls.Add(txtGiaNhap);
            panel3.Controls.Add(numSoLuong);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(cboSanPham);
            panel3.Controls.Add(cboHangSX_Loc);
            panel3.Controls.Add(label9);
            panel3.Location = new Point(6, 187);
            panel3.Name = "panel3";
            panel3.Size = new Size(589, 148);
            panel3.TabIndex = 2;
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.HotTrack;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(338, 87);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(142, 36);
            btnThem.TabIndex = 26;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtGiaNhap
            // 
            txtGiaNhap.Font = new Font("Segoe UI", 9F);
            txtGiaNhap.Location = new Point(124, 92);
            txtGiaNhap.Name = "txtGiaNhap";
            txtGiaNhap.Size = new Size(167, 27);
            txtGiaNhap.TabIndex = 23;
            // 
            // numSoLuong
            // 
            numSoLuong.Font = new Font("Segoe UI", 9F);
            numSoLuong.Location = new Point(475, 49);
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(98, 27);
            numSoLuong.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F);
            label11.Location = new Point(50, 95);
            label11.Name = "label11";
            label11.Size = new Size(68, 20);
            label11.TabIndex = 22;
            label11.Text = "Giá nhập";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F);
            label10.Location = new Point(396, 53);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 22;
            label10.Text = "Số lượng";
            // 
            // cboSanPham
            // 
            cboSanPham.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSanPham.Font = new Font("Segoe UI", 9F);
            cboSanPham.FormattingEnabled = true;
            cboSanPham.Location = new Point(176, 49);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(214, 28);
            cboSanPham.TabIndex = 24;
            cboSanPham.SelectedIndexChanged += cboSanPham_SelectedIndexChanged;
            // 
            // cboHangSX_Loc
            // 
            cboHangSX_Loc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHangSX_Loc.Font = new Font("Segoe UI", 9F);
            cboHangSX_Loc.FormattingEnabled = true;
            cboHangSX_Loc.Location = new Point(3, 48);
            cboHangSX_Loc.Name = "cboHangSX_Loc";
            cboHangSX_Loc.Size = new Size(167, 28);
            cboHangSX_Loc.TabIndex = 23;
            cboHangSX_Loc.SelectedIndexChanged += cboHangSX_Loc_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label9.ForeColor = Color.MediumBlue;
            label9.Location = new Point(17, 14);
            label9.Name = "label9";
            label9.Size = new Size(190, 23);
            label9.TabIndex = 22;
            label9.Text = "Thêm sản phẩm vào lô";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblTongSoLuong);
            panel2.Controls.Add(lblSoLoaiSP);
            panel2.Controls.Add(lblTongTienNhap);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label12);
            panel2.Location = new Point(611, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(429, 148);
            panel2.TabIndex = 1;
            // 
            // lblTongSoLuong
            // 
            lblTongSoLuong.AutoSize = true;
            lblTongSoLuong.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongSoLuong.Location = new Point(308, 76);
            lblTongSoLuong.Name = "lblTongSoLuong";
            lblTongSoLuong.Size = new Size(120, 23);
            lblTongSoLuong.TabIndex = 27;
            lblTongSoLuong.Text = "Tổng số lượng";
            lblTongSoLuong.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSoLoaiSP
            // 
            lblSoLoaiSP.AutoSize = true;
            lblSoLoaiSP.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSoLoaiSP.Location = new Point(308, 46);
            lblSoLoaiSP.Name = "lblSoLoaiSP";
            lblSoLoaiSP.Size = new Size(85, 23);
            lblSoLoaiSP.TabIndex = 26;
            lblSoLoaiSP.Text = "Số loại SP";
            lblSoLoaiSP.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTongTienNhap
            // 
            lblTongTienNhap.AutoSize = true;
            lblTongTienNhap.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblTongTienNhap.ForeColor = Color.MediumBlue;
            lblTongTienNhap.Location = new Point(268, 113);
            lblTongTienNhap.Name = "lblTongTienNhap";
            lblTongTienNhap.Size = new Size(21, 23);
            lblTongTienNhap.TabIndex = 22;
            lblTongTienNhap.Text = "đ";
            lblTongTienNhap.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label15.Location = new Point(20, 113);
            label15.Name = "label15";
            label15.Size = new Size(132, 23);
            label15.TabIndex = 25;
            label15.Text = "Tổng tiền nhập";
            // 
            // panel4
            // 
            panel4.BackColor = Color.DimGray;
            panel4.Location = new Point(20, 100);
            panel4.Name = "panel4";
            panel4.Size = new Size(393, 2);
            panel4.TabIndex = 24;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F);
            label14.Location = new Point(20, 76);
            label14.Name = "label14";
            label14.Size = new Size(105, 20);
            label14.TabIndex = 23;
            label14.Text = "Tổng số lượng";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F);
            label13.Location = new Point(20, 46);
            label13.Name = "label13";
            label13.Size = new Size(75, 20);
            label13.TabIndex = 22;
            label13.Text = "Số loại SP";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label12.ForeColor = SystemColors.ControlDarkDark;
            label12.Location = new Point(20, 14);
            label12.Name = "label12";
            label12.Size = new Size(147, 23);
            label12.TabIndex = 22;
            label12.Text = "Tổng kết lô nhập";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtGhiChu);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtSoHoaDonNCC);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(cboNhaCungCap);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cboChiNhanh);
            panel1.Controls.Add(dtpNgayNhap);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtMaPhieu);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(589, 175);
            panel1.TabIndex = 0;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Font = new Font("Segoe UI", 9F);
            txtGhiChu.Location = new Point(406, 129);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(167, 27);
            txtGhiChu.TabIndex = 21;
            txtGhiChu.Text = "Không bắt buộc";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F);
            label8.Location = new Point(406, 106);
            label8.Name = "label8";
            label8.Size = new Size(58, 20);
            label8.TabIndex = 20;
            label8.Text = "Ghi chú";
            // 
            // txtSoHoaDonNCC
            // 
            txtSoHoaDonNCC.Font = new Font("Segoe UI", 9F);
            txtSoHoaDonNCC.Location = new Point(210, 129);
            txtSoHoaDonNCC.Name = "txtSoHoaDonNCC";
            txtSoHoaDonNCC.Size = new Size(167, 27);
            txtSoHoaDonNCC.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F);
            label7.Location = new Point(210, 106);
            label7.Name = "label7";
            label7.Size = new Size(118, 20);
            label7.TabIndex = 18;
            label7.Text = "Số hóa đơn NCC";
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhaCungCap.Font = new Font("Segoe UI", 9F);
            cboNhaCungCap.FormattingEnabled = true;
            cboNhaCungCap.Location = new Point(17, 128);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(167, 28);
            cboNhaCungCap.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(17, 106);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 16;
            label6.Text = "Nhà cung cấp";
            // 
            // cboChiNhanh
            // 
            cboChiNhanh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChiNhanh.Font = new Font("Segoe UI", 9F);
            cboChiNhanh.FormattingEnabled = true;
            cboChiNhanh.Location = new Point(406, 68);
            cboChiNhanh.Name = "cboChiNhanh";
            cboChiNhanh.Size = new Size(167, 28);
            cboChiNhanh.TabIndex = 15;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            dtpNgayNhap.Font = new Font("Segoe UI", 9F);
            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.Location = new Point(210, 69);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(167, 27);
            dtpNgayNhap.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(406, 46);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 12;
            label5.Text = "Chi nhánh";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(210, 46);
            label4.Name = "label4";
            label4.Size = new Size(81, 20);
            label4.TabIndex = 10;
            label4.Text = "Ngày nhập";
            // 
            // txtMaPhieu
            // 
            txtMaPhieu.Font = new Font("Segoe UI", 9F);
            txtMaPhieu.Location = new Point(17, 69);
            txtMaPhieu.Name = "txtMaPhieu";
            txtMaPhieu.Size = new Size(167, 27);
            txtMaPhieu.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.MediumBlue;
            label3.Location = new Point(17, 14);
            label3.Name = "label3";
            label3.Size = new Size(183, 23);
            label3.TabIndex = 8;
            label3.Text = "Thông tin phiếu nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(17, 46);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã phiếu";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.LightSteelBlue;
            tabPage2.BorderStyle = BorderStyle.FixedSingle;
            tabPage2.Controls.Add(dgvLichSuNhapHang);
            tabPage2.Controls.Add(panel8);
            tabPage2.Controls.Add(panel7);
            tabPage2.Controls.Add(panel6);
            tabPage2.Controls.Add(panel5);
            tabPage2.Font = new Font("Segoe UI", 9F);
            tabPage2.Location = new Point(4, 44);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1048, 826);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Lịch sử nhập hàng";
            // 
            // dgvLichSuNhapHang
            // 
            dgvLichSuNhapHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichSuNhapHang.BackgroundColor = Color.White;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvLichSuNhapHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvLichSuNhapHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichSuNhapHang.Columns.AddRange(new DataGridViewColumn[] { colMaPhieu, colNgayNhap, colNCC, colNhanVien, colSoSp, colTongTien, colTrangThai, colChiTiet });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvLichSuNhapHang.DefaultCellStyle = dataGridViewCellStyle5;
            dgvLichSuNhapHang.Location = new Point(7, 320);
            dgvLichSuNhapHang.Name = "dgvLichSuNhapHang";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvLichSuNhapHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvLichSuNhapHang.RowHeadersWidth = 51;
            dgvLichSuNhapHang.Size = new Size(1033, 489);
            dgvLichSuNhapHang.TabIndex = 7;
            // 
            // colMaPhieu
            // 
            colMaPhieu.HeaderText = "Mã phiếu";
            colMaPhieu.MinimumWidth = 6;
            colMaPhieu.Name = "colMaPhieu";
            // 
            // colNgayNhap
            // 
            colNgayNhap.HeaderText = "Ngày nhập";
            colNgayNhap.MinimumWidth = 6;
            colNgayNhap.Name = "colNgayNhap";
            // 
            // colNCC
            // 
            colNCC.HeaderText = "Nhà cung cấp";
            colNCC.MinimumWidth = 6;
            colNCC.Name = "colNCC";
            // 
            // colNhanVien
            // 
            colNhanVien.HeaderText = "Nhân viên";
            colNhanVien.MinimumWidth = 6;
            colNhanVien.Name = "colNhanVien";
            // 
            // colSoSp
            // 
            colSoSp.HeaderText = "Số sản phẩm";
            colSoSp.MinimumWidth = 6;
            colSoSp.Name = "colSoSp";
            // 
            // colTongTien
            // 
            colTongTien.HeaderText = "Tổng tiền";
            colTongTien.MinimumWidth = 6;
            colTongTien.Name = "colTongTien";
            // 
            // colTrangThai
            // 
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 6;
            colTrangThai.Name = "colTrangThai";
            // 
            // colChiTiet
            // 
            colChiTiet.HeaderText = "Chi tiết";
            colChiTiet.MinimumWidth = 6;
            colChiTiet.Name = "colChiTiet";
            colChiTiet.Resizable = DataGridViewTriState.True;
            colChiTiet.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.Controls.Add(label23);
            panel8.Controls.Add(label22);
            panel8.Location = new Point(638, 212);
            panel8.Name = "panel8";
            panel8.Size = new Size(402, 91);
            panel8.TabIndex = 6;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label23.ForeColor = Color.DarkBlue;
            label23.Location = new Point(17, 52);
            label23.Name = "label23";
            label23.Size = new Size(23, 25);
            label23.TabIndex = 26;
            label23.Text = "đ";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label22.ForeColor = SystemColors.ControlDarkDark;
            label22.Location = new Point(17, 17);
            label22.Name = "label22";
            label22.Size = new Size(169, 23);
            label22.TabIndex = 25;
            label22.Text = "Tổng chi nhập hàng";
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.Controls.Add(lblTongSpDaNhap);
            panel7.Controls.Add(label21);
            panel7.Location = new Point(639, 109);
            panel7.Name = "panel7";
            panel7.Size = new Size(402, 91);
            panel7.TabIndex = 6;
            // 
            // lblTongSpDaNhap
            // 
            lblTongSpDaNhap.AutoSize = true;
            lblTongSpDaNhap.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblTongSpDaNhap.ForeColor = Color.Black;
            lblTongSpDaNhap.Location = new Point(16, 55);
            lblTongSpDaNhap.Name = "lblTongSpDaNhap";
            lblTongSpDaNhap.Size = new Size(48, 25);
            lblTongSpDaNhap.TabIndex = 25;
            lblTongSpDaNhap.Text = "máy";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label21.ForeColor = SystemColors.ControlDarkDark;
            label21.Location = new Point(16, 15);
            label21.Name = "label21";
            label21.Size = new Size(146, 23);
            label21.TabIndex = 24;
            label21.Text = "Tổng SP đã nhập";
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(lblTongPhieuNhap);
            panel6.Controls.Add(label20);
            panel6.Location = new Point(638, 6);
            panel6.Name = "panel6";
            panel6.Size = new Size(402, 91);
            panel6.TabIndex = 5;
            // 
            // lblTongPhieuNhap
            // 
            lblTongPhieuNhap.AutoSize = true;
            lblTongPhieuNhap.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            lblTongPhieuNhap.ForeColor = Color.Black;
            lblTongPhieuNhap.Location = new Point(17, 54);
            lblTongPhieuNhap.Name = "lblTongPhieuNhap";
            lblTongPhieuNhap.Size = new Size(60, 25);
            lblTongPhieuNhap.TabIndex = 24;
            lblTongPhieuNhap.Text = "phiếu";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label20.ForeColor = SystemColors.ControlDarkDark;
            label20.Location = new Point(17, 17);
            label20.Name = "label20";
            label20.Size = new Size(146, 23);
            label20.TabIndex = 23;
            label20.Text = "Tổng phiếu nhập";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(cboNcc);
            panel5.Controls.Add(btnLamMoi);
            panel5.Controls.Add(btnTimKiem);
            panel5.Controls.Add(cboTrangThai);
            panel5.Controls.Add(label19);
            panel5.Controls.Add(dateTimePicker2);
            panel5.Controls.Add(dtpTuNgay);
            panel5.Font = new Font("Segoe UI", 9F);
            panel5.Location = new Point(7, 6);
            panel5.Name = "panel5";
            panel5.Size = new Size(609, 297);
            panel5.TabIndex = 4;
            // 
            // cboNcc
            // 
            cboNcc.Font = new Font("Segoe UI", 10.2F);
            cboNcc.FormattingEnabled = true;
            cboNcc.Location = new Point(34, 134);
            cboNcc.Name = "cboNcc";
            cboNcc.Size = new Size(546, 31);
            cboNcc.TabIndex = 9;
            cboNcc.Text = "--Tất cả Nhà cung cấp--";
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Gainsboro;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.Black;
            btnLamMoi.Location = new Point(382, 232);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(114, 39);
            btnLamMoi.TabIndex = 7;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.HotTrack;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(157, 232);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(114, 39);
            btnTimKiem.TabIndex = 8;
            btnTimKiem.Text = "Lọc";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // cboTrangThai
            // 
            cboTrangThai.Font = new Font("Segoe UI", 10.2F);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(34, 184);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(546, 31);
            cboTrangThai.TabIndex = 3;
            cboTrangThai.Text = "--Tất cả trạng thái--";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 10.2F);
            label19.Location = new Point(45, 56);
            label19.Name = "label19";
            label19.Size = new Size(39, 23);
            label19.TabIndex = 2;
            label19.Text = "đến";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Font = new Font("Segoe UI", 10.2F);
            dateTimePicker2.Location = new Point(34, 85);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(546, 30);
            dateTimePicker2.TabIndex = 1;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Font = new Font("Segoe UI", 10.2F);
            dtpTuNgay.Location = new Point(34, 20);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(546, 30);
            dtpTuNgay.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.LightSteelBlue;
            tabPage3.BorderStyle = BorderStyle.FixedSingle;
            tabPage3.Controls.Add(dgvTheoDoiLoHang);
            tabPage3.Controls.Add(panel9);
            tabPage3.Location = new Point(4, 44);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1048, 826);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Theo dõi lô hàng";
            // 
            // dgvTheoDoiLoHang
            // 
            dgvTheoDoiLoHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTheoDoiLoHang.BackgroundColor = Color.White;
            dgvTheoDoiLoHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheoDoiLoHang.Columns.AddRange(new DataGridViewColumn[] { colMaLo, colSanPham, colPhieuNhap, colNgayNhapLoHang, colSoLuongNhap, colDaBan, colConLai, colTrangThaiLoHang });
            dgvTheoDoiLoHang.Location = new Point(6, 98);
            dgvTheoDoiLoHang.Name = "dgvTheoDoiLoHang";
            dgvTheoDoiLoHang.RowHeadersWidth = 51;
            dgvTheoDoiLoHang.Size = new Size(1038, 720);
            dgvTheoDoiLoHang.TabIndex = 1;
            // 
            // colMaLo
            // 
            colMaLo.HeaderText = "Mã lô";
            colMaLo.MinimumWidth = 6;
            colMaLo.Name = "colMaLo";
            // 
            // colSanPham
            // 
            colSanPham.HeaderText = "Sản phẩm";
            colSanPham.MinimumWidth = 6;
            colSanPham.Name = "colSanPham";
            // 
            // colPhieuNhap
            // 
            colPhieuNhap.HeaderText = "Phiếu nhập";
            colPhieuNhap.MinimumWidth = 6;
            colPhieuNhap.Name = "colPhieuNhap";
            // 
            // colNgayNhapLoHang
            // 
            colNgayNhapLoHang.HeaderText = "Ngày nhập";
            colNgayNhapLoHang.MinimumWidth = 6;
            colNgayNhapLoHang.Name = "colNgayNhapLoHang";
            // 
            // colSoLuongNhap
            // 
            colSoLuongNhap.HeaderText = "SL nhập";
            colSoLuongNhap.MinimumWidth = 6;
            colSoLuongNhap.Name = "colSoLuongNhap";
            // 
            // colDaBan
            // 
            colDaBan.HeaderText = "Đã bán";
            colDaBan.MinimumWidth = 6;
            colDaBan.Name = "colDaBan";
            // 
            // colConLai
            // 
            colConLai.HeaderText = "Còn lại";
            colConLai.MinimumWidth = 6;
            colConLai.Name = "colConLai";
            // 
            // colTrangThaiLoHang
            // 
            colTrangThaiLoHang.HeaderText = "Trạng thái";
            colTrangThaiLoHang.MinimumWidth = 6;
            colTrangThaiLoHang.Name = "colTrangThaiLoHang";
            // 
            // panel9
            // 
            panel9.BackColor = Color.White;
            panel9.Controls.Add(btnTimLoHang);
            panel9.Controls.Add(comboBox2);
            panel9.Controls.Add(comboBox1);
            panel9.Controls.Add(textBox1);
            panel9.Location = new Point(6, 6);
            panel9.Name = "panel9";
            panel9.Size = new Size(1034, 86);
            panel9.TabIndex = 0;
            // 
            // btnTimLoHang
            // 
            btnTimLoHang.BackColor = SystemColors.HotTrack;
            btnTimLoHang.FlatStyle = FlatStyle.Flat;
            btnTimLoHang.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnTimLoHang.ForeColor = Color.White;
            btnTimLoHang.Location = new Point(879, 25);
            btnTimLoHang.Name = "btnTimLoHang";
            btnTimLoHang.Size = new Size(114, 33);
            btnTimLoHang.TabIndex = 9;
            btnTimLoHang.Text = "Tìm";
            btnTimLoHang.UseVisualStyleBackColor = false;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(575, 25);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(251, 33);
            comboBox2.TabIndex = 2;
            comboBox2.Text = "--Tất cả trạng thái--";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(286, 25);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(251, 33);
            comboBox1.TabIndex = 1;
            comboBox1.Text = "--Tất cả sản phẩm--";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(18, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(251, 31);
            textBox1.TabIndex = 0;
            textBox1.Text = "Tìm mã...";
            // 
            // UC_NhapHangLo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F);
            Name = "UC_NhapHangLo";
            Size = new Size(1100, 938);
            Load += UC_NhapHangLo_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLichSuNhapHang).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTheoDoiLoHang).EndInit();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Panel panel2;
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtMaPhieu;
        private DateTimePicker dtpNgayNhap;
        private Label label5;
        private TextBox txtGhiChu;
        private Label label8;
        private TextBox txtSoHoaDonNCC;
        private Label label7;
        private ComboBox cboNhaCungCap;
        private Label label6;
        private ComboBox cboChiNhanh;
        private Panel panel3;
        private ComboBox cboSanPham;
        private ComboBox cboHangSX_Loc;
        private Label label9;
        private TextBox txtGiaNhap;
        private NumericUpDown numSoLuong;
        private Label label11;
        private Label label10;
        private Button btnThem;
        private Label label14;
        private Label label13;
        private Label label12;
        private Panel panel4;
        private Button btnHuyPhieu;
        private Button btnLuuNhap;
        private Button btnXacNhan;
        private DataGridView dgvChiTietNhap;
        private Label lblTongSoLuong;
        private Label lblSoLoaiSP;
        private Label lblTongTienNhap;
        private Label label15;
        private Panel panel5;
        private Button btnLamMoi;
        private Button btnTimKiem;
        private ComboBox cboTrangThai;
        private Label label19;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dtpTuNgay;
        private ComboBox cboNcc;
        private Panel panel6;
        private Panel panel8;
        private Panel panel7;
        private Label label20;
        private Label label22;
        private Label label21;
        private DataGridView dgvLichSuNhapHang;
        private DataGridViewTextBoxColumn colMaPhieu;
        private DataGridViewTextBoxColumn colNgayNhap;
        private DataGridViewTextBoxColumn colNCC;
        private DataGridViewTextBoxColumn colNhanVien;
        private DataGridViewTextBoxColumn colSoSp;
        private DataGridViewTextBoxColumn colTongTien;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewButtonColumn colChiTiet;
        private Label label23;
        private Label lblTongSpDaNhap;
        private Label lblTongPhieuNhap;
        private Panel panel9;
        private DataGridView dgvTheoDoiLoHang;
        private DataGridViewTextBoxColumn colMaLo;
        private DataGridViewTextBoxColumn colSanPham;
        private DataGridViewTextBoxColumn colPhieuNhap;
        private DataGridViewTextBoxColumn colNgayNhapLoHang;
        private DataGridViewTextBoxColumn colSoLuongNhap;
        private DataGridViewTextBoxColumn colDaBan;
        private DataGridViewTextBoxColumn colConLai;
        private DataGridViewTextBoxColumn colTrangThaiLoHang;
        private Button btnTimLoHang;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private DataGridViewTextBoxColumn colNhap_STT;
        private DataGridViewTextBoxColumn colNhap_SanPham;
        private DataGridViewTextBoxColumn colNhap_SoLuong;
        private DataGridViewTextBoxColumn colNhap_GiaNhap;
        private DataGridViewTextBoxColumn colNhap_ThanhTien;
        private DataGridViewButtonColumn colNhap_Xoa;
    }
}
