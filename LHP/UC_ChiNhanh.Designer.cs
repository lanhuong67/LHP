namespace GUI
{
    partial class UC_ChiNhanh
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
            btnXoa = new Button();
            btnSua = new Button();
            panel2 = new Panel();
            txtMaCN = new TextBox();
            label9 = new Label();
            txtTaiKhoan = new TextBox();
            btnLamTrong = new Button();
            btnLuu = new Button();
            label11 = new Label();
            label10 = new Label();
            txtDiaChi = new TextBox();
            label8 = new Label();
            txtQuanHuyen = new TextBox();
            label7 = new Label();
            txtTenCN = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnThemCN = new Button();
            panel1 = new Panel();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            label2 = new Label();
            dgvChiNhanh = new DataGridView();
            colMaCN = new DataGridViewTextBoxColumn();
            colTenCN = new DataGridViewTextBoxColumn();
            colThanhPho = new DataGridViewTextBoxColumn();
            colDiaChi = new DataGridViewTextBoxColumn();
            colQuanLy = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            cboThanhPho = new ComboBox();
            label5 = new Label();
            comboBox1 = new ComboBox();
            txtEmailCN = new TextBox();
            label12 = new Label();
            cboTrangThai = new ComboBox();
            panel4 = new Panel();
            lblNgungHoatDong = new Label();
            label14 = new Label();
            panel3 = new Panel();
            lblHoatDong = new Label();
            label16 = new Label();
            panel5 = new Panel();
            lblTongNV = new Label();
            label18 = new Label();
            panel6 = new Panel();
            lblTongCN = new Label();
            label20 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiNhanh).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(36, 11);
            label1.Name = "label1";
            label1.Size = new Size(225, 35);
            label1.TabIndex = 3;
            label1.Text = "Quản lý chi nhánh";
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(525, 339);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(126, 51);
            btnXoa.TabIndex = 24;
            btnXoa.Text = "✖ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnSua.ForeColor = Color.Black;
            btnSua.Location = new Point(337, 339);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(126, 51);
            btnSua.TabIndex = 23;
            btnSua.Text = "✎ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(cboTrangThai);
            panel2.Controls.Add(txtEmailCN);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(cboThanhPho);
            panel2.Controls.Add(txtMaCN);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txtTaiKhoan);
            panel2.Controls.Add(btnLamTrong);
            panel2.Controls.Add(btnLuu);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(txtDiaChi);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtQuanHuyen);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtTenCN);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(742, 206);
            panel2.Name = "panel2";
            panel2.Size = new Size(477, 846);
            panel2.TabIndex = 19;
            // 
            // txtMaCN
            // 
            txtMaCN.Location = new Point(160, 42);
            txtMaCN.Name = "txtMaCN";
            txtMaCN.Size = new Size(132, 27);
            txtMaCN.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F);
            label9.Location = new Point(19, 466);
            label9.Name = "label9";
            label9.Size = new Size(89, 25);
            label9.TabIndex = 23;
            label9.Text = "Trạng thái";
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.Font = new Font("Segoe UI", 10.8F);
            txtTaiKhoan.Location = new Point(19, 418);
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new Size(174, 31);
            txtTaiKhoan.TabIndex = 12;
            // 
            // btnLamTrong
            // 
            btnLamTrong.BackColor = Color.Gainsboro;
            btnLamTrong.FlatStyle = FlatStyle.Flat;
            btnLamTrong.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamTrong.ForeColor = Color.Black;
            btnLamTrong.Location = new Point(234, 575);
            btnLamTrong.Name = "btnLamTrong";
            btnLamTrong.Size = new Size(142, 64);
            btnLamTrong.TabIndex = 7;
            btnLamTrong.Text = "Làm trống";
            btnLamTrong.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = SystemColors.HotTrack;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(56, 575);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(142, 64);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F);
            label11.Location = new Point(19, 390);
            label11.Name = "label11";
            label11.Size = new Size(117, 25);
            label11.TabIndex = 20;
            label11.Text = "Số điện thoại";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F);
            label10.Location = new Point(19, 314);
            label10.Name = "label10";
            label10.Size = new Size(154, 25);
            label10.TabIndex = 18;
            label10.Text = "Quản lý chi nhánh";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10.8F);
            txtDiaChi.Location = new Point(19, 266);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(390, 31);
            txtDiaChi.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F);
            label8.Location = new Point(19, 238);
            label8.Name = "label8";
            label8.Size = new Size(65, 25);
            label8.TabIndex = 14;
            label8.Text = "Địa chỉ";
            // 
            // txtQuanHuyen
            // 
            txtQuanHuyen.Font = new Font("Segoe UI", 10.8F);
            txtQuanHuyen.Location = new Point(235, 193);
            txtQuanHuyen.Name = "txtQuanHuyen";
            txtQuanHuyen.Size = new Size(175, 31);
            txtQuanHuyen.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F);
            label7.Location = new Point(19, 165);
            label7.Name = "label7";
            label7.Size = new Size(97, 25);
            label7.TabIndex = 12;
            label7.Text = "Thành phố";
            // 
            // txtTenCN
            // 
            txtTenCN.Font = new Font("Segoe UI", 10.8F);
            txtTenCN.Location = new Point(19, 117);
            txtTenCN.Name = "txtTenCN";
            txtTenCN.Size = new Size(390, 31);
            txtTenCN.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F);
            label6.Location = new Point(19, 89);
            label6.Name = "label6";
            label6.Size = new Size(119, 25);
            label6.TabIndex = 5;
            label6.Text = "Tên chi nhánh";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F);
            label4.Location = new Point(19, 41);
            label4.Name = "label4";
            label4.Size = new Size(118, 25);
            label4.TabIndex = 8;
            label4.Text = "Mã chi nhánh";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label3.ForeColor = Color.MediumBlue;
            label3.Location = new Point(9, 6);
            label3.Name = "label3";
            label3.Size = new Size(184, 25);
            label3.TabIndex = 7;
            label3.Text = "Thông tin chi nhánh";
            // 
            // btnThemCN
            // 
            btnThemCN.BackColor = SystemColors.HotTrack;
            btnThemCN.FlatStyle = FlatStyle.Flat;
            btnThemCN.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnThemCN.ForeColor = Color.White;
            btnThemCN.Location = new Point(89, 336);
            btnThemCN.Name = "btnThemCN";
            btnThemCN.Size = new Size(185, 51);
            btnThemCN.TabIndex = 21;
            btnThemCN.Text = "➕ Thêm CN";
            btnThemCN.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(txtTimKiem);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(18, 206);
            panel1.Name = "panel1";
            panel1.Size = new Size(691, 115);
            panel1.TabIndex = 20;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Gainsboro;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.Black;
            btnLamMoi.Location = new Point(558, 48);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(114, 39);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10.8F);
            txtTimKiem.Location = new Point(9, 52);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(515, 31);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.Text = "Tìm tên hoặc mã chi nhánh...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label2.Location = new Point(9, 11);
            label2.Name = "label2";
            label2.Size = new Size(90, 25);
            label2.TabIndex = 0;
            label2.Text = "Tìm kiếm";
            // 
            // dgvChiNhanh
            // 
            dgvChiNhanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiNhanh.BackgroundColor = Color.White;
            dgvChiNhanh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiNhanh.Columns.AddRange(new DataGridViewColumn[] { colMaCN, colTenCN, colThanhPho, colDiaChi, colQuanLy, colTrangThai });
            dgvChiNhanh.Location = new Point(18, 414);
            dgvChiNhanh.Name = "dgvChiNhanh";
            dgvChiNhanh.RowHeadersWidth = 51;
            dgvChiNhanh.Size = new Size(691, 638);
            dgvChiNhanh.TabIndex = 25;
            // 
            // colMaCN
            // 
            colMaCN.HeaderText = "Mã CN";
            colMaCN.MinimumWidth = 6;
            colMaCN.Name = "colMaCN";
            // 
            // colTenCN
            // 
            colTenCN.HeaderText = "Tên chi nhánh";
            colTenCN.MinimumWidth = 6;
            colTenCN.Name = "colTenCN";
            // 
            // colThanhPho
            // 
            colThanhPho.HeaderText = "Thành phố";
            colThanhPho.MinimumWidth = 6;
            colThanhPho.Name = "colThanhPho";
            // 
            // colDiaChi
            // 
            colDiaChi.HeaderText = "Địa chỉ";
            colDiaChi.MinimumWidth = 6;
            colDiaChi.Name = "colDiaChi";
            // 
            // colQuanLy
            // 
            colQuanLy.HeaderText = "Quản lý";
            colQuanLy.MinimumWidth = 6;
            colQuanLy.Name = "colQuanLy";
            // 
            // colTrangThai
            // 
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 6;
            colTrangThai.Name = "colTrangThai";
            // 
            // cboThanhPho
            // 
            cboThanhPho.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboThanhPho.FormattingEnabled = true;
            cboThanhPho.Location = new Point(19, 193);
            cboThanhPho.Name = "cboThanhPho";
            cboThanhPho.Size = new Size(191, 33);
            cboThanhPho.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F);
            label5.Location = new Point(234, 165);
            label5.Name = "label5";
            label5.Size = new Size(110, 25);
            label5.TabIndex = 25;
            label5.Text = "Quận/huyện";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(19, 342);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(391, 33);
            comboBox1.TabIndex = 26;
            // 
            // txtEmailCN
            // 
            txtEmailCN.Font = new Font("Segoe UI", 10.8F);
            txtEmailCN.Location = new Point(208, 418);
            txtEmailCN.Name = "txtEmailCN";
            txtEmailCN.Size = new Size(201, 31);
            txtEmailCN.TabIndex = 27;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F);
            label12.Location = new Point(208, 390);
            label12.Name = "label12";
            label12.Size = new Size(54, 25);
            label12.TabIndex = 28;
            label12.Text = "Email";
            // 
            // cboTrangThai
            // 
            cboTrangThai.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(19, 494);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(390, 33);
            cboTrangThai.TabIndex = 29;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblNgungHoatDong);
            panel4.Controls.Add(label14);
            panel4.Font = new Font("Segoe UI", 12F);
            panel4.Location = new Point(943, 59);
            panel4.Name = "panel4";
            panel4.Size = new Size(255, 125);
            panel4.TabIndex = 27;
            // 
            // lblNgungHoatDong
            // 
            lblNgungHoatDong.AutoSize = true;
            lblNgungHoatDong.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblNgungHoatDong.ForeColor = Color.DarkRed;
            lblNgungHoatDong.Location = new Point(18, 71);
            lblNgungHoatDong.Name = "lblNgungHoatDong";
            lblNgungHoatDong.Size = new Size(46, 31);
            lblNgungHoatDong.TabIndex = 2;
            lblNgungHoatDong.Text = "CN";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label14.ForeColor = Color.DarkRed;
            label14.Location = new Point(18, 11);
            label14.Name = "label14";
            label14.Size = new Size(210, 28);
            label14.TabIndex = 1;
            label14.Text = "⛔ Ngưng hoạt động";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblHoatDong);
            panel3.Controls.Add(label16);
            panel3.Font = new Font("Segoe UI", 12F);
            panel3.Location = new Point(643, 59);
            panel3.Name = "panel3";
            panel3.Size = new Size(255, 125);
            panel3.TabIndex = 28;
            // 
            // lblHoatDong
            // 
            lblHoatDong.AutoSize = true;
            lblHoatDong.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblHoatDong.ForeColor = Color.DarkGreen;
            lblHoatDong.Location = new Point(18, 71);
            lblHoatDong.Name = "lblHoatDong";
            lblHoatDong.Size = new Size(46, 31);
            lblHoatDong.TabIndex = 2;
            lblHoatDong.Text = "CN";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label16.ForeColor = Color.DarkGreen;
            label16.Location = new Point(18, 11);
            label16.Name = "label16";
            label16.Size = new Size(195, 28);
            label16.TabIndex = 1;
            label16.Text = "\U0001f7e2 Đang hoạt động";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(lblTongNV);
            panel5.Controls.Add(label18);
            panel5.Font = new Font("Segoe UI", 12F);
            panel5.Location = new Point(337, 59);
            panel5.Name = "panel5";
            panel5.Size = new Size(255, 125);
            panel5.TabIndex = 29;
            // 
            // lblTongNV
            // 
            lblTongNV.AutoSize = true;
            lblTongNV.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTongNV.ForeColor = Color.DarkSlateGray;
            lblTongNV.Location = new Point(18, 71);
            lblTongNV.Name = "lblTongNV";
            lblTongNV.Size = new Size(46, 31);
            lblTongNV.TabIndex = 2;
            lblTongNV.Text = "CN";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label18.ForeColor = Color.DarkSlateGray;
            label18.Location = new Point(18, 11);
            label18.Name = "label18";
            label18.Size = new Size(189, 28);
            label18.TabIndex = 1;
            label18.Text = "👥 Tổng nhân viên";
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(lblTongCN);
            panel6.Controls.Add(label20);
            panel6.Font = new Font("Segoe UI", 12F);
            panel6.Location = new Point(32, 59);
            panel6.Name = "panel6";
            panel6.Size = new Size(255, 125);
            panel6.TabIndex = 26;
            // 
            // lblTongCN
            // 
            lblTongCN.AutoSize = true;
            lblTongCN.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTongCN.ForeColor = Color.MidnightBlue;
            lblTongCN.Location = new Point(18, 71);
            lblTongCN.Name = "lblTongCN";
            lblTongCN.Size = new Size(46, 31);
            lblTongCN.TabIndex = 2;
            lblTongCN.Text = "CN";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label20.ForeColor = Color.MidnightBlue;
            label20.Location = new Point(18, 11);
            label20.Name = "label20";
            label20.Size = new Size(180, 28);
            label20.TabIndex = 1;
            label20.Text = "☰ Tổng chi nhánh";
            // 
            // UC_ChiNhanh
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel5);
            Controls.Add(panel6);
            Controls.Add(dgvChiNhanh);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(panel2);
            Controls.Add(btnThemCN);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UC_ChiNhanh";
            Size = new Size(1252, 1079);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiNhanh).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnXoa;
        private Button btnSua;
        private Panel panel2;
        private TextBox txtMaCN;
        private TextBox txtMatKhau;
        private Label label9;
        private TextBox txtTaiKhoan;
        private Button btnLamTrong;
        private Button btnLuu;
        private Label label11;
        private Label label10;
        private TextBox txtDiaChi;
        private Label label8;
        private TextBox txtQuanHuyen;
        private Label label7;
        private TextBox txtTenCN;
        private Label label6;
        private Label label4;
        private Label label3;
        private Button btnThemCN;
        private Panel panel1;
        private Button btnLamMoi;
        private TextBox txtTimKiem;
        private Label label2;
        private DataGridView dgvChiNhanh;
        private DataGridViewTextBoxColumn colMaCN;
        private DataGridViewTextBoxColumn colTenCN;
        private DataGridViewTextBoxColumn colThanhPho;
        private DataGridViewTextBoxColumn colDiaChi;
        private DataGridViewTextBoxColumn colQuanLy;
        private DataGridViewTextBoxColumn colTrangThai;
        private Label label5;
        private ComboBox cboThanhPho;
        private ComboBox comboBox1;
        private TextBox txtEmailCN;
        private Label label12;
        private ComboBox cboTrangThai;
        private Panel panel4;
        private Label lblNgungHoatDong;
        private Label label14;
        private Panel panel3;
        private Label lblHoatDong;
        private Label label16;
        private Panel panel5;
        private Label lblTongNV;
        private Label label18;
        private Panel panel6;
        private Label lblTongCN;
        private Label label20;
    }
}
