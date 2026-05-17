namespace GUI
{
    partial class UC_TaoHoaDon
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            dtpNgayLap = new DateTimePicker();
            txtNhanVien = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            btnTimKhachHang = new Button();
            txtTenKhachHang = new TextBox();
            label6 = new Label();
            txtSDTKhachHang = new TextBox();
            label7 = new Label();
            label8 = new Label();
            panel3 = new Panel();
            label10 = new Label();
            label9 = new Label();
            btnThemSP = new Button();
            cboSanPham = new ComboBox();
            cboHangSX = new ComboBox();
            numSoLuong = new NumericUpDown();
            panel4 = new Panel();
            lblTongTien = new Label();
            lblTongSoSP = new Label();
            label12 = new Label();
            label11 = new Label();
            dgvGioHang = new DataGridView();
            colSTT = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colĐonGia = new DataGridViewTextBoxColumn();
            colSL = new DataGridViewTextBoxColumn();
            colThanhTien = new DataGridViewTextBoxColumn();
            colXoa = new DataGridViewButtonColumn();
            btnThanhToan = new Button();
            btnHuyDon = new Button();
            txtMaHD = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(45, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(215, 35);
            label1.TabIndex = 0;
            label1.Text = "Tạo hóa đơn mới";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(76, 80);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(153, 28);
            label2.TabIndex = 1;
            label2.Text = "Mã HD tự động:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(dtpNgayLap);
            panel1.Controls.Add(txtNhanVien);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(76, 137);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(594, 183);
            panel1.TabIndex = 5;
            // 
            // dtpNgayLap
            // 
            dtpNgayLap.CustomFormat = "dd/MM/yyyy";
            dtpNgayLap.Format = DateTimePickerFormat.Custom;
            dtpNgayLap.Location = new Point(179, 54);
            dtpNgayLap.Margin = new Padding(4, 4, 4, 4);
            dtpNgayLap.Name = "dtpNgayLap";
            dtpNgayLap.Size = new Size(390, 31);
            dtpNgayLap.TabIndex = 11;
            // 
            // txtNhanVien
            // 
            txtNhanVien.Font = new Font("Segoe UI", 10.8F);
            txtNhanVien.Location = new Point(179, 116);
            txtNhanVien.Margin = new Padding(4, 4, 4, 4);
            txtNhanVien.Name = "txtNhanVien";
            txtNhanVien.Size = new Size(390, 31);
            txtNhanVien.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F);
            label5.Location = new Point(39, 116);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 9;
            label5.Text = "Nhân viên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F);
            label4.Location = new Point(39, 56);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(83, 25);
            label4.TabIndex = 7;
            label4.Text = "Ngày lập";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(19, 11);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(170, 25);
            label3.TabIndex = 6;
            label3.Text = "Thông tin hóa đơn";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnTimKhachHang);
            panel2.Controls.Add(txtTenKhachHang);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txtSDTKhachHang);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(769, 137);
            panel2.Margin = new Padding(4, 4, 4, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(641, 183);
            panel2.TabIndex = 11;
            // 
            // btnTimKhachHang
            // 
            btnTimKhachHang.BackColor = SystemColors.HotTrack;
            btnTimKhachHang.FlatStyle = FlatStyle.Flat;
            btnTimKhachHang.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnTimKhachHang.ForeColor = Color.White;
            btnTimKhachHang.ImageAlign = ContentAlignment.MiddleRight;
            btnTimKhachHang.Location = new Point(495, 56);
            btnTimKhachHang.Margin = new Padding(4, 4, 4, 4);
            btnTimKhachHang.Name = "btnTimKhachHang";
            btnTimKhachHang.Size = new Size(116, 42);
            btnTimKhachHang.TabIndex = 11;
            btnTimKhachHang.Text = "Tìm";
            btnTimKhachHang.UseVisualStyleBackColor = false;
            // 
            // txtTenKhachHang
            // 
            txtTenKhachHang.Font = new Font("Segoe UI", 10.8F);
            txtTenKhachHang.Location = new Point(178, 118);
            txtTenKhachHang.Margin = new Padding(4, 4, 4, 4);
            txtTenKhachHang.Name = "txtTenKhachHang";
            txtTenKhachHang.Size = new Size(433, 31);
            txtTenKhachHang.TabIndex = 10;
            txtTenKhachHang.Text = "Khách vãng lai";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F);
            label6.Location = new Point(38, 118);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 9;
            label6.Text = "Tên KH";
            // 
            // txtSDTKhachHang
            // 
            txtSDTKhachHang.Font = new Font("Segoe UI", 10.8F);
            txtSDTKhachHang.Location = new Point(178, 58);
            txtSDTKhachHang.Margin = new Padding(4, 4, 4, 4);
            txtSDTKhachHang.Name = "txtSDTKhachHang";
            txtSDTKhachHang.Size = new Size(298, 31);
            txtSDTKhachHang.TabIndex = 8;
            txtSDTKhachHang.Text = "Nhập SĐT tìm KH...";
            txtSDTKhachHang.TextChanged += TxtSDTKhachHang_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F);
            label7.Location = new Point(38, 58);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(44, 25);
            label7.TabIndex = 7;
            label7.Text = "SĐT";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(19, 11);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(113, 25);
            label8.TabIndex = 6;
            label8.Text = "Khách hàng";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(btnThemSP);
            panel3.Controls.Add(cboSanPham);
            panel3.Controls.Add(cboHangSX);
            panel3.Controls.Add(numSoLuong);
            panel3.Location = new Point(76, 339);
            panel3.Margin = new Padding(4, 4, 4, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(1334, 156);
            panel3.TabIndex = 12;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(19, 14);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(147, 25);
            label10.TabIndex = 11;
            label10.Text = "Thêm sản phẩm";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F);
            label9.Location = new Point(860, 69);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(30, 25);
            label9.TabIndex = 11;
            label9.Text = "SL";
            // 
            // btnThemSP
            // 
            btnThemSP.BackColor = SystemColors.HotTrack;
            btnThemSP.FlatStyle = FlatStyle.Flat;
            btnThemSP.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnThemSP.ForeColor = Color.White;
            btnThemSP.Location = new Point(1094, 64);
            btnThemSP.Margin = new Padding(4, 4, 4, 4);
            btnThemSP.Name = "btnThemSP";
            btnThemSP.Size = new Size(141, 42);
            btnThemSP.TabIndex = 3;
            btnThemSP.Text = "+ Thêm";
            btnThemSP.UseVisualStyleBackColor = false;
            btnThemSP.Click += btnThemSanPham_Click;
            // 
            // cboSanPham
            // 
            cboSanPham.Font = new Font("Segoe UI", 10.8F);
            cboSanPham.FormattingEnabled = true;
            cboSanPham.Location = new Point(396, 65);
            cboSanPham.Margin = new Padding(4, 4, 4, 4);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(429, 33);
            cboSanPham.TabIndex = 2;
            cboSanPham.Text = "--Chọn sản phẩm--";
            // 
            // cboHangSX
            // 
            cboHangSX.Font = new Font("Segoe UI", 10.8F);
            cboHangSX.FormattingEnabled = true;
            cboHangSX.Location = new Point(59, 65);
            cboHangSX.Margin = new Padding(4, 4, 4, 4);
            cboHangSX.Name = "cboHangSX";
            cboHangSX.Size = new Size(285, 33);
            cboHangSX.TabIndex = 1;
            cboHangSX.Text = "--Chọn hãng--";
            cboHangSX.SelectedIndexChanged += cboHangSX_SelectedIndexChanged;
            // 
            // numSoLuong
            // 
            numSoLuong.BorderStyle = BorderStyle.FixedSingle;
            numSoLuong.Font = new Font("Segoe UI", 10.8F);
            numSoLuong.Location = new Point(912, 65);
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(96, 31);
            numSoLuong.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblTongTien);
            panel4.Controls.Add(lblTongSoSP);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(label11);
            panel4.Location = new Point(905, 824);
            panel4.Margin = new Padding(4, 4, 4, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(474, 141);
            panel4.TabIndex = 15;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTongTien.ForeColor = SystemColors.HotTrack;
            lblTongTien.Location = new Point(335, 85);
            lblTongTien.Margin = new Padding(4, 0, 4, 0);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(117, 31);
            lblTongTien.TabIndex = 20;
            lblTongTien.Text = "Tổng tiền";
            lblTongTien.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTongSoSP
            // 
            lblTongSoSP.AutoSize = true;
            lblTongSoSP.Font = new Font("Segoe UI", 13.8F);
            lblTongSoSP.Location = new Point(301, 24);
            lblTongSoSP.Margin = new Padding(4, 0, 4, 0);
            lblTongSoSP.Name = "lblTongSoSP";
            lblTongSoSP.Size = new Size(145, 31);
            lblTongSoSP.TabIndex = 19;
            lblTongSoSP.Text = "Số sản phẩm";
            lblTongSoSP.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            label12.Location = new Point(22, 85);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(117, 31);
            label12.TabIndex = 18;
            label12.Text = "Tổng tiền";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F);
            label11.Location = new Point(22, 24);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(145, 31);
            label11.TabIndex = 17;
            label11.Text = "Số sản phẩm";
            // 
            // dgvGioHang
            // 
            dgvGioHang.AllowUserToAddRows = false;
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGioHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvGioHang.BackgroundColor = Color.White;
            dgvGioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGioHang.Columns.AddRange(new DataGridViewColumn[] { colSTT, colTenSP, colĐonGia, colSL, colThanhTien, colXoa });
            dgvGioHang.Location = new Point(76, 513);
            dgvGioHang.Margin = new Padding(4, 4, 4, 4);
            dgvGioHang.Name = "dgvGioHang";
            dgvGioHang.RowHeadersWidth = 51;
            dgvGioHang.Size = new Size(1334, 256);
            dgvGioHang.TabIndex = 16;
            dgvGioHang.CellContentClick += dgvGioHang_CellContentClick;
            dgvGioHang.CellFormatting += dgvGioHang_CellFormatting;
            // 
            // colSTT
            // 
            colSTT.HeaderText = "STT";
            colSTT.MinimumWidth = 6;
            colSTT.Name = "colSTT";
            // 
            // colTenSP
            // 
            colTenSP.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTenSP.DataPropertyName = "TenSP";
            colTenSP.HeaderText = "Tên sản phẩm";
            colTenSP.MinimumWidth = 6;
            colTenSP.Name = "colTenSP";
            // 
            // colĐonGia
            // 
            colĐonGia.DataPropertyName = "DonGiaBan";
            dataGridViewCellStyle1.Format = "N0";
            colĐonGia.DefaultCellStyle = dataGridViewCellStyle1;
            colĐonGia.HeaderText = "Đơn giá";
            colĐonGia.MinimumWidth = 6;
            colĐonGia.Name = "colĐonGia";
            // 
            // colSL
            // 
            colSL.DataPropertyName = "SoLuong";
            colSL.HeaderText = "SL";
            colSL.MinimumWidth = 6;
            colSL.Name = "colSL";
            // 
            // colThanhTien
            // 
            colThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle2.Format = "N0";
            colThanhTien.DefaultCellStyle = dataGridViewCellStyle2;
            colThanhTien.HeaderText = "Thành tiền";
            colThanhTien.MinimumWidth = 6;
            colThanhTien.Name = "colThanhTien";
            // 
            // colXoa
            // 
            colXoa.HeaderText = "Xóa";
            colXoa.MinimumWidth = 6;
            colXoa.Name = "colXoa";
            colXoa.Text = "Xóa";
            colXoa.UseColumnTextForButtonValue = true;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = SystemColors.HotTrack;
            btnThanhToan.FlatStyle = FlatStyle.Flat;
            btnThanhToan.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.ImageAlign = ContentAlignment.MiddleRight;
            btnThanhToan.Location = new Point(903, 43);
            btnThanhToan.Margin = new Padding(4, 4, 4, 4);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(210, 72);
            btnThanhToan.TabIndex = 12;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // btnHuyDon
            // 
            btnHuyDon.BackColor = Color.White;
            btnHuyDon.FlatStyle = FlatStyle.Flat;
            btnHuyDon.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnHuyDon.ForeColor = Color.Red;
            btnHuyDon.ImageAlign = ContentAlignment.MiddleRight;
            btnHuyDon.Location = new Point(1151, 43);
            btnHuyDon.Margin = new Padding(4, 4, 4, 4);
            btnHuyDon.Name = "btnHuyDon";
            btnHuyDon.Size = new Size(210, 72);
            btnHuyDon.TabIndex = 17;
            btnHuyDon.Text = "Hủy đơn";
            btnHuyDon.UseVisualStyleBackColor = false;
            btnHuyDon.Click += btnHuyDon_Click;
            // 
            // txtMaHD
            // 
            txtMaHD.Location = new Point(275, 85);
            txtMaHD.Margin = new Padding(4, 4, 4, 4);
            txtMaHD.Name = "txtMaHD";
            txtMaHD.Size = new Size(223, 31);
            txtMaHD.TabIndex = 18;
            // 
            // UC_TaoHoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(txtMaHD);
            Controls.Add(btnHuyDon);
            Controls.Add(btnThanhToan);
            Controls.Add(dgvGioHang);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "UC_TaoHoaDon";
            Size = new Size(1546, 986);
            Load += UC_TaoHoaDon_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Panel panel1;
        private Label label3;
        private TextBox txtNhanVien;
        private Label label5;
        private Label label4;
        private Panel panel2;
        private Button btnTimKhachHang;
        private TextBox txtTenKhachHang;
        private Label label6;
        private TextBox txtSDTKhachHang;
        private Label label7;
        private Label label8;
        private Panel panel3;
        private NumericUpDown numSoLuong;
        private Panel panel4;
        private Button btnThemSP;
        private ComboBox cboSanPham;
        private ComboBox cboHangSX;
        private Label label10;
        private Label label9;
        private DataGridView dgvGioHang;
        private Label label12;
        private Label label11;
        private Label lblTongTien;
        private Label lblTongSoSP;
        private Button btnThanhToan;
        private Button btnHuyDon;
        private TextBox txtMaHD;
        private DateTimePicker dtpNgayLap;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colĐonGia;
        private DataGridViewTextBoxColumn colSL;
        private DataGridViewTextBoxColumn colThanhTien;
        private DataGridViewButtonColumn colXoa;
    }
}
