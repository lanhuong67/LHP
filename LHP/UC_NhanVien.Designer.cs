namespace GUI
{
    partial class UC_NhanVien
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
            dgvNhanVien = new DataGridView();
            colMaNV = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colSDT = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colVaiTro = new DataGridViewTextBoxColumn();
            MaChiNhanh = new DataGridViewTextBoxColumn();
            panelThongTin = new Panel();
            label5 = new Label();
            cboChiNhanh = new ComboBox();
            txtMaNV = new TextBox();
            txtMatKhau = new TextBox();
            label9 = new Label();
            txtTaiKhoan = new TextBox();
            btnLamTrong = new Button();
            btnLuu = new Button();
            label11 = new Label();
            txtVaiTro = new TextBox();
            label10 = new Label();
            txtEmail = new TextBox();
            label8 = new Label();
            txtSDT = new TextBox();
            label7 = new Label();
            txtHoTen = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnThemNV = new Button();
            panel1 = new Panel();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            panelThongTin.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(45, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(226, 35);
            label1.TabIndex = 2;
            label1.Text = "Quản lý nhân viên";
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(555, 222);
            btnXoa.Margin = new Padding(4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(158, 50);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "✖ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnSua.ForeColor = Color.Black;
            btnSua.Location = new Point(365, 226);
            btnSua.Margin = new Padding(4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(158, 50);
            btnSua.TabIndex = 17;
            btnSua.Text = "✎ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Columns.AddRange(new DataGridViewColumn[] { colMaNV, colHoTen, colSDT, colEmail, colVaiTro, MaChiNhanh });
            dgvNhanVien.Location = new Point(21, 303);
            dgvNhanVien.Margin = new Padding(4);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.Size = new Size(817, 559);
            dgvNhanVien.TabIndex = 16;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            // 
            // colMaNV
            // 
            colMaNV.DataPropertyName = "MaNV";
            colMaNV.HeaderText = "Mã NV";
            colMaNV.MinimumWidth = 6;
            colMaNV.Name = "colMaNV";
            // 
            // colHoTen
            // 
            colHoTen.DataPropertyName = "HoTen";
            colHoTen.HeaderText = "Họ Tên";
            colHoTen.MinimumWidth = 6;
            colHoTen.Name = "colHoTen";
            // 
            // colSDT
            // 
            colSDT.DataPropertyName = "SDT";
            colSDT.HeaderText = "SĐT";
            colSDT.MinimumWidth = 6;
            colSDT.Name = "colSDT";
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            // 
            // colVaiTro
            // 
            colVaiTro.DataPropertyName = "VaiTro";
            colVaiTro.HeaderText = "Vai Trò";
            colVaiTro.MinimumWidth = 6;
            colVaiTro.Name = "colVaiTro";
            // 
            // MaChiNhanh
            // 
            MaChiNhanh.DataPropertyName = "MaChiNhanh";
            MaChiNhanh.HeaderText = "Chi Nhánh";
            MaChiNhanh.MinimumWidth = 6;
            MaChiNhanh.Name = "MaChiNhanh";
            // 
            // panelThongTin
            // 
            panelThongTin.BackColor = Color.White;
            panelThongTin.BorderStyle = BorderStyle.FixedSingle;
            panelThongTin.Controls.Add(label5);
            panelThongTin.Controls.Add(cboChiNhanh);
            panelThongTin.Controls.Add(txtMaNV);
            panelThongTin.Controls.Add(txtMatKhau);
            panelThongTin.Controls.Add(label9);
            panelThongTin.Controls.Add(txtTaiKhoan);
            panelThongTin.Controls.Add(btnLamTrong);
            panelThongTin.Controls.Add(btnLuu);
            panelThongTin.Controls.Add(label11);
            panelThongTin.Controls.Add(txtVaiTro);
            panelThongTin.Controls.Add(label10);
            panelThongTin.Controls.Add(txtEmail);
            panelThongTin.Controls.Add(label8);
            panelThongTin.Controls.Add(txtSDT);
            panelThongTin.Controls.Add(label7);
            panelThongTin.Controls.Add(txtHoTen);
            panelThongTin.Controls.Add(label6);
            panelThongTin.Controls.Add(label4);
            panelThongTin.Controls.Add(label3);
            panelThongTin.Location = new Point(866, 59);
            panelThongTin.Margin = new Padding(4);
            panelThongTin.Name = "panelThongTin";
            panelThongTin.Size = new Size(482, 803);
            panelThongTin.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F);
            label5.Location = new Point(29, 87);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 25;
            label5.Text = "Chi nhánh";
            // 
            // cboChiNhanh
            // 
            cboChiNhanh.FormattingEnabled = true;
            cboChiNhanh.Location = new Point(177, 87);
            cboChiNhanh.Name = "cboChiNhanh";
            cboChiNhanh.Size = new Size(164, 33);
            cboChiNhanh.TabIndex = 24;
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(177, 43);
            txtMaNV.Margin = new Padding(4);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(164, 31);
            txtMaNV.TabIndex = 0;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 10.8F);
            txtMatKhau.Location = new Point(29, 622);
            txtMatKhau.Margin = new Padding(4);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(426, 31);
            txtMatKhau.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F);
            label9.Location = new Point(29, 586);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(86, 25);
            label9.TabIndex = 23;
            label9.Text = "Mật khẩu";
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.Font = new Font("Segoe UI", 10.8F);
            txtTaiKhoan.Location = new Point(29, 526);
            txtTaiKhoan.Margin = new Padding(4);
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new Size(426, 31);
            txtTaiKhoan.TabIndex = 12;
            // 
            // btnLamTrong
            // 
            btnLamTrong.BackColor = Color.Gainsboro;
            btnLamTrong.FlatStyle = FlatStyle.Flat;
            btnLamTrong.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamTrong.ForeColor = Color.Black;
            btnLamTrong.Location = new Point(277, 709);
            btnLamTrong.Margin = new Padding(4);
            btnLamTrong.Name = "btnLamTrong";
            btnLamTrong.Size = new Size(178, 46);
            btnLamTrong.TabIndex = 7;
            btnLamTrong.Text = "Làm trống";
            btnLamTrong.UseVisualStyleBackColor = false;
            btnLamTrong.Click += btnLamTrong_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = SystemColors.HotTrack;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(50, 709);
            btnLuu.Margin = new Padding(4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(178, 46);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F);
            label11.Location = new Point(29, 492);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(86, 25);
            label11.TabIndex = 20;
            label11.Text = "Tài khoản";
            // 
            // txtVaiTro
            // 
            txtVaiTro.Font = new Font("Segoe UI", 10.8F);
            txtVaiTro.Location = new Point(29, 432);
            txtVaiTro.Margin = new Padding(4);
            txtVaiTro.Name = "txtVaiTro";
            txtVaiTro.Size = new Size(426, 31);
            txtVaiTro.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F);
            label10.Location = new Point(29, 396);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(63, 25);
            label10.TabIndex = 18;
            label10.Text = "Vai trò";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10.8F);
            txtEmail.Location = new Point(29, 336);
            txtEmail.Margin = new Padding(4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(426, 31);
            txtEmail.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F);
            label8.Location = new Point(29, 302);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(54, 25);
            label8.TabIndex = 14;
            label8.Text = "Email";
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Segoe UI", 10.8F);
            txtSDT.Location = new Point(29, 245);
            txtSDT.Margin = new Padding(4);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(426, 31);
            txtSDT.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F);
            label7.Location = new Point(29, 210);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(117, 25);
            label7.TabIndex = 12;
            label7.Text = "Số điện thoại";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 10.8F);
            txtHoTen.Location = new Point(29, 162);
            txtHoTen.Margin = new Padding(4);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(426, 31);
            txtHoTen.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F);
            label6.Location = new Point(29, 124);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 5;
            label6.Text = "Họ tên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F);
            label4.Location = new Point(28, 49);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(118, 25);
            label4.TabIndex = 8;
            label4.Text = "Mã nhân viên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label3.ForeColor = Color.MediumBlue;
            label3.Location = new Point(29, 14);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(184, 25);
            label3.TabIndex = 7;
            label3.Text = "Thông tin nhân viên";
            // 
            // btnThemNV
            // 
            btnThemNV.BackColor = SystemColors.HotTrack;
            btnThemNV.FlatStyle = FlatStyle.Flat;
            btnThemNV.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnThemNV.ForeColor = Color.White;
            btnThemNV.Location = new Point(63, 222);
            btnThemNV.Margin = new Padding(4);
            btnThemNV.Name = "btnThemNV";
            btnThemNV.Size = new Size(231, 50);
            btnThemNV.TabIndex = 14;
            btnThemNV.Text = "➕ Thêm NV";
            btnThemNV.UseVisualStyleBackColor = false;
            btnThemNV.Click += btnThemNV_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(txtTimKiem);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(21, 72);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(817, 124);
            panel1.TabIndex = 13;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Gainsboro;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.Black;
            btnLamMoi.Location = new Point(648, 58);
            btnLamMoi.Margin = new Padding(4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(142, 49);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10.8F);
            txtTimKiem.Location = new Point(38, 67);
            txtTimKiem.Margin = new Padding(4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(568, 31);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.Text = "Tìm tên hoặc số điện thoại...";
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            txtTimKiem.Enter += txtTimKiem_Enter;
            txtTimKiem.Leave += txtTimKiem_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label2.Location = new Point(11, 14);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(90, 25);
            label2.TabIndex = 0;
            label2.Text = "Tìm kiếm";
            // 
            // UC_NhanVien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(dgvNhanVien);
            Controls.Add(panelThongTin);
            Controls.Add(btnThemNV);
            Controls.Add(panel1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "UC_NhanVien";
            Size = new Size(1370, 886);
            Load += UC_NhanVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            panelThongTin.ResumeLayout(false);
            panelThongTin.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnXoa;
        private Button btnSua;
        private DataGridView dgvNhanVien;
        private Panel panelThongTin;
        private Button btnLamTrong;
        private Button btnLuu;
        private Label label11;
        private TextBox txtVaiTro;
        private Label label10;
        private TextBox txtEmail;
        private Label label8;
        private TextBox txtSDT;
        private Label label7;
        private TextBox txtHoTen;
        private Label label6;
        private Label label4;
        private Label label3;
        private Button btnThemNV;
        private Panel panel1;
        private Button btnLamMoi;
        private TextBox txtTimKiem;
        private Label label2;
        private TextBox txtMatKhau;
        private Label label9;
        private TextBox txtTaiKhoan;
        private TextBox txtMaNV;
        private Label label5;
        private ComboBox cboChiNhanh;
        private DataGridViewTextBoxColumn colMaNV;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colSDT;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colVaiTro;
        private DataGridViewTextBoxColumn MaChiNhanh;
    }
}
