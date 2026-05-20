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
            btnXoaCN = new Button();
            btnSuaCN = new Button();
            panel2 = new Panel();
            cboTrangThai = new ComboBox();
            txtEmail = new TextBox();
            label12 = new Label();
            cboQuanLy = new ComboBox();
            label5 = new Label();
            cboThanhPho = new ComboBox();
            txtMaCN = new TextBox();
            label9 = new Label();
            txtSDT = new TextBox();
            btnLamTrong = new Button();
            btnLuu = new Button();
            label11 = new Label();
            label10 = new Label();
            txtDiaChi = new TextBox();
            label8 = new Label();
            label7 = new Label();
            txtTenCN = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnThemCN = new Button();
            panel1 = new Panel();
            btnLamMoiTimKiem = new Button();
            txtTimKiem = new TextBox();
            label2 = new Label();
            dgvChiNhanh = new DataGridView();
            MaChiNhanh = new DataGridViewTextBoxColumn();
            TenChiNhanh = new DataGridViewTextBoxColumn();
            ThanhPho = new DataGridViewTextBoxColumn();
            DiaChi = new DataGridViewTextBoxColumn();
            QuanLy = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            panel4 = new Panel();
            lblNgungHoatDong = new Label();
            label14 = new Label();
            panel3 = new Panel();
            lblDangHoatDong = new Label();
            label16 = new Label();
            panel5 = new Panel();
            lblTongNV = new Label();
            label18 = new Label();
            panel6 = new Panel();
            lblTongCN = new Label();
            label20 = new Label();
            cboQuanHuyen = new ComboBox();
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
            label1.Location = new Point(45, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(225, 35);
            label1.TabIndex = 3;
            label1.Text = "Quản lý chi nhánh";
            // 
            // btnXoaCN
            // 
            btnXoaCN.BackColor = Color.White;
            btnXoaCN.FlatStyle = FlatStyle.Flat;
            btnXoaCN.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnXoaCN.ForeColor = Color.Red;
            btnXoaCN.Location = new Point(618, 334);
            btnXoaCN.Margin = new Padding(4);
            btnXoaCN.Name = "btnXoaCN";
            btnXoaCN.Size = new Size(145, 46);
            btnXoaCN.TabIndex = 24;
            btnXoaCN.Text = "✖ Xóa";
            btnXoaCN.UseVisualStyleBackColor = false;
            // 
            // btnSuaCN
            // 
            btnSuaCN.BackColor = Color.White;
            btnSuaCN.FlatStyle = FlatStyle.Flat;
            btnSuaCN.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnSuaCN.ForeColor = Color.Black;
            btnSuaCN.Location = new Point(383, 334);
            btnSuaCN.Margin = new Padding(4);
            btnSuaCN.Name = "btnSuaCN";
            btnSuaCN.Size = new Size(145, 46);
            btnSuaCN.TabIndex = 23;
            btnSuaCN.Text = "✎ Sửa";
            btnSuaCN.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(cboQuanHuyen);
            panel2.Controls.Add(cboTrangThai);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(cboQuanLy);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(cboThanhPho);
            panel2.Controls.Add(txtMaCN);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txtSDT);
            panel2.Controls.Add(btnLamTrong);
            panel2.Controls.Add(btnLuu);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(txtDiaChi);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtTenCN);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(825, 226);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(531, 652);
            panel2.TabIndex = 19;
            // 
            // cboTrangThai
            // 
            cboTrangThai.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(26, 526);
            cboTrangThai.Margin = new Padding(4);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(486, 33);
            cboTrangThai.TabIndex = 29;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10.8F);
            txtEmail.Location = new Point(265, 444);
            txtEmail.Margin = new Padding(4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 31);
            txtEmail.TabIndex = 27;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F);
            label12.Location = new Point(265, 410);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(54, 25);
            label12.TabIndex = 28;
            label12.Text = "Email";
            // 
            // cboQuanLy
            // 
            cboQuanLy.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboQuanLy.FormattingEnabled = true;
            cboQuanLy.Location = new Point(27, 363);
            cboQuanLy.Margin = new Padding(4);
            cboQuanLy.Name = "cboQuanLy";
            cboQuanLy.Size = new Size(488, 33);
            cboQuanLy.TabIndex = 26;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F);
            label5.Location = new Point(295, 166);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(110, 25);
            label5.TabIndex = 25;
            label5.Text = "Quận/huyện";
            // 
            // cboThanhPho
            // 
            cboThanhPho.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboThanhPho.FormattingEnabled = true;
            cboThanhPho.Location = new Point(27, 201);
            cboThanhPho.Margin = new Padding(4);
            cboThanhPho.Name = "cboThanhPho";
            cboThanhPho.Size = new Size(238, 33);
            cboThanhPho.TabIndex = 24;
            // 
            // txtMaCN
            // 
            txtMaCN.Location = new Point(202, 43);
            txtMaCN.Margin = new Padding(4);
            txtMaCN.Name = "txtMaCN";
            txtMaCN.ReadOnly = true;
            txtMaCN.Size = new Size(164, 31);
            txtMaCN.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F);
            label9.Location = new Point(26, 490);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(89, 25);
            label9.TabIndex = 23;
            label9.Text = "Trạng thái";
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Segoe UI", 10.8F);
            txtSDT.Location = new Point(29, 444);
            txtSDT.Margin = new Padding(4);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(216, 31);
            txtSDT.TabIndex = 12;
            // 
            // btnLamTrong
            // 
            btnLamTrong.BackColor = Color.Gainsboro;
            btnLamTrong.FlatStyle = FlatStyle.Flat;
            btnLamTrong.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamTrong.ForeColor = Color.Black;
            btnLamTrong.Location = new Point(277, 581);
            btnLamTrong.Margin = new Padding(4);
            btnLamTrong.Name = "btnLamTrong";
            btnLamTrong.Size = new Size(178, 45);
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
            btnLuu.Location = new Point(55, 581);
            btnLuu.Margin = new Padding(4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(178, 45);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F);
            label11.Location = new Point(29, 410);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(117, 25);
            label11.TabIndex = 20;
            label11.Text = "Số điện thoại";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F);
            label10.Location = new Point(27, 327);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(154, 25);
            label10.TabIndex = 18;
            label10.Text = "Quản lý chi nhánh";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10.8F);
            txtDiaChi.Location = new Point(28, 278);
            txtDiaChi.Margin = new Padding(4);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(486, 31);
            txtDiaChi.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F);
            label8.Location = new Point(28, 244);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(65, 25);
            label8.TabIndex = 14;
            label8.Text = "Địa chỉ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F);
            label7.Location = new Point(27, 166);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(97, 25);
            label7.TabIndex = 12;
            label7.Text = "Thành phố";
            // 
            // txtTenCN
            // 
            txtTenCN.Font = new Font("Segoe UI", 10.8F);
            txtTenCN.Location = new Point(26, 122);
            txtTenCN.Margin = new Padding(4);
            txtTenCN.Name = "txtTenCN";
            txtTenCN.Size = new Size(486, 31);
            txtTenCN.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F);
            label6.Location = new Point(26, 87);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(119, 25);
            label6.TabIndex = 5;
            label6.Text = "Tên chi nhánh";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F);
            label4.Location = new Point(26, 42);
            label4.Margin = new Padding(4, 0, 4, 0);
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
            label3.Location = new Point(26, 10);
            label3.Margin = new Padding(4, 0, 4, 0);
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
            btnThemCN.Location = new Point(73, 330);
            btnThemCN.Margin = new Padding(4);
            btnThemCN.Name = "btnThemCN";
            btnThemCN.Size = new Size(218, 46);
            btnThemCN.TabIndex = 21;
            btnThemCN.Text = "➕ Thêm CN";
            btnThemCN.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnLamMoiTimKiem);
            panel1.Controls.Add(txtTimKiem);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(32, 226);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(772, 96);
            panel1.TabIndex = 20;
            // 
            // btnLamMoiTimKiem
            // 
            btnLamMoiTimKiem.BackColor = Color.Gainsboro;
            btnLamMoiTimKiem.FlatStyle = FlatStyle.Flat;
            btnLamMoiTimKiem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamMoiTimKiem.ForeColor = Color.Black;
            btnLamMoiTimKiem.Location = new Point(568, 35);
            btnLamMoiTimKiem.Margin = new Padding(4);
            btnLamMoiTimKiem.Name = "btnLamMoiTimKiem";
            btnLamMoiTimKiem.Size = new Size(142, 39);
            btnLamMoiTimKiem.TabIndex = 5;
            btnLamMoiTimKiem.Text = "Làm mới";
            btnLamMoiTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10.8F);
            txtTimKiem.Location = new Point(54, 39);
            txtTimKiem.Margin = new Padding(4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(482, 31);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.Text = "Tìm tên hoặc mã chi nhánh...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label2.Location = new Point(54, 10);
            label2.Margin = new Padding(4, 0, 4, 0);
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
            dgvChiNhanh.Columns.AddRange(new DataGridViewColumn[] { MaChiNhanh, TenChiNhanh, ThanhPho, DiaChi, QuanLy, TrangThai });
            dgvChiNhanh.Location = new Point(32, 388);
            dgvChiNhanh.Margin = new Padding(4);
            dgvChiNhanh.Name = "dgvChiNhanh";
            dgvChiNhanh.RowHeadersWidth = 51;
            dgvChiNhanh.Size = new Size(772, 490);
            dgvChiNhanh.TabIndex = 25;
            // 
            // MaChiNhanh
            // 
            MaChiNhanh.DataPropertyName = "MaChiNhanh";
            MaChiNhanh.HeaderText = "Mã CN";
            MaChiNhanh.MinimumWidth = 6;
            MaChiNhanh.Name = "MaChiNhanh";
            // 
            // TenChiNhanh
            // 
            TenChiNhanh.DataPropertyName = "TenChiNhanh";
            TenChiNhanh.HeaderText = "Tên chi nhánh";
            TenChiNhanh.MinimumWidth = 6;
            TenChiNhanh.Name = "TenChiNhanh";
            // 
            // ThanhPho
            // 
            ThanhPho.DataPropertyName = "ThanhPho";
            ThanhPho.HeaderText = "Thành phố";
            ThanhPho.MinimumWidth = 6;
            ThanhPho.Name = "ThanhPho";
            // 
            // DiaChi
            // 
            DiaChi.DataPropertyName = "DiaChi";
            DiaChi.HeaderText = "Địa chỉ";
            DiaChi.MinimumWidth = 6;
            DiaChi.Name = "DiaChi";
            // 
            // QuanLy
            // 
            QuanLy.DataPropertyName = "QuanLy";
            QuanLy.HeaderText = "Quản lý";
            QuanLy.MinimumWidth = 6;
            QuanLy.Name = "QuanLy";
            // 
            // TrangThai
            // 
            TrangThai.DataPropertyName = "TrangThai";
            TrangThai.HeaderText = "Trạng thái";
            TrangThai.MinimumWidth = 6;
            TrangThai.Name = "TrangThai";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblNgungHoatDong);
            panel4.Controls.Add(label14);
            panel4.Font = new Font("Segoe UI", 12F);
            panel4.Location = new Point(1084, 71);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new Size(272, 133);
            panel4.TabIndex = 27;
            // 
            // lblNgungHoatDong
            // 
            lblNgungHoatDong.AutoSize = true;
            lblNgungHoatDong.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblNgungHoatDong.ForeColor = Color.DarkRed;
            lblNgungHoatDong.Location = new Point(22, 89);
            lblNgungHoatDong.Margin = new Padding(4, 0, 4, 0);
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
            label14.Location = new Point(22, 14);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(210, 28);
            label14.TabIndex = 1;
            label14.Text = "⛔ Ngưng hoạt động";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblDangHoatDong);
            panel3.Controls.Add(label16);
            panel3.Font = new Font("Segoe UI", 12F);
            panel3.Location = new Point(735, 71);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(272, 133);
            panel3.TabIndex = 28;
            // 
            // lblDangHoatDong
            // 
            lblDangHoatDong.AutoSize = true;
            lblDangHoatDong.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblDangHoatDong.ForeColor = Color.DarkGreen;
            lblDangHoatDong.Location = new Point(22, 89);
            lblDangHoatDong.Margin = new Padding(4, 0, 4, 0);
            lblDangHoatDong.Name = "lblDangHoatDong";
            lblDangHoatDong.Size = new Size(46, 31);
            lblDangHoatDong.TabIndex = 2;
            lblDangHoatDong.Text = "CN";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label16.ForeColor = Color.DarkGreen;
            label16.Location = new Point(22, 14);
            label16.Margin = new Padding(4, 0, 4, 0);
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
            panel5.Location = new Point(372, 71);
            panel5.Margin = new Padding(4);
            panel5.Name = "panel5";
            panel5.Size = new Size(272, 133);
            panel5.TabIndex = 29;
            // 
            // lblTongNV
            // 
            lblTongNV.AutoSize = true;
            lblTongNV.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTongNV.ForeColor = Color.DarkSlateGray;
            lblTongNV.Location = new Point(22, 89);
            lblTongNV.Margin = new Padding(4, 0, 4, 0);
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
            label18.Location = new Point(22, 14);
            label18.Margin = new Padding(4, 0, 4, 0);
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
            panel6.Location = new Point(35, 71);
            panel6.Margin = new Padding(4);
            panel6.Name = "panel6";
            panel6.Size = new Size(272, 133);
            panel6.TabIndex = 26;
            // 
            // lblTongCN
            // 
            lblTongCN.AutoSize = true;
            lblTongCN.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblTongCN.ForeColor = Color.MidnightBlue;
            lblTongCN.Location = new Point(22, 89);
            lblTongCN.Margin = new Padding(4, 0, 4, 0);
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
            label20.Location = new Point(22, 14);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(180, 28);
            label20.TabIndex = 1;
            label20.Text = "☰ Tổng chi nhánh";
            // 
            // cboQuanHuyen
            // 
            cboQuanHuyen.FormattingEnabled = true;
            cboQuanHuyen.Location = new Point(295, 201);
            cboQuanHuyen.Name = "cboQuanHuyen";
            cboQuanHuyen.Size = new Size(151, 33);
            cboQuanHuyen.TabIndex = 30;
            // 
            // UC_ChiNhanh
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel5);
            Controls.Add(panel6);
            Controls.Add(dgvChiNhanh);
            Controls.Add(btnXoaCN);
            Controls.Add(btnSuaCN);
            Controls.Add(btnThemCN);
            Controls.Add(panel1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "UC_ChiNhanh";
            Size = new Size(1370, 886);
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
        private Button btnXoaCN;
        private Button btnSuaCN;
        private Panel panel2;
        private TextBox txtMaCN;
        private TextBox txtMatKhau;
        private Label label9;
        private TextBox txtSDT;
        private Button btnLamTrong;
        private Button btnLuu;
        private Label label11;
        private Label label10;
        private TextBox txtDiaChi;
        private Label label8;
        private Label label7;
        private TextBox txtTenCN;
        private Label label6;
        private Label label4;
        private Label label3;
        private Button btnThemCN;
        private Panel panel1;
        private Button btnLamMoiTimKiem;
        private TextBox txtTimKiem;
        private Label label2;
        private DataGridView dgvChiNhanh;
        private Label label5;
        private ComboBox cboThanhPho;
        private ComboBox cboQuanLy;
        private TextBox txtEmail;
        private Label label12;
        private ComboBox cboTrangThai;
        private Panel panel4;
        private Label lblNgungHoatDong;
        private Label label14;
        private Panel panel3;
        private Label lblDangHoatDong;
        private Label label16;
        private Panel panel5;
        private Label lblTongNV;
        private Label label18;
        private Panel panel6;
        private Label lblTongCN;
        private Label label20;
        private DataGridViewTextBoxColumn MaChiNhanh;
        private DataGridViewTextBoxColumn TenChiNhanh;
        private DataGridViewTextBoxColumn ThanhPho;
        private DataGridViewTextBoxColumn DiaChi;
        private DataGridViewTextBoxColumn QuanLy;
        private DataGridViewTextBoxColumn TrangThai;
        private ComboBox cboQuanHuyen;
    }
}
