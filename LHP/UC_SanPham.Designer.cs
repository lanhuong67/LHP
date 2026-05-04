namespace GUI
{
    partial class UC_SanPham
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
            panel1 = new Panel();
            btnLamMoi = new Button();
            cboTimKiemHang = new ComboBox();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            label2 = new Label();
            btnThem = new Button();
            panel2 = new Panel();
            txtCauHinh = new TextBox();
            cboHangSanXuat = new ComboBox();
            txtMaSP = new TextBox();
            cboTrangThai = new ComboBox();
            btnLamTrong = new Button();
            btnLuu = new Button();
            label11 = new Label();
            txtTonKho = new TextBox();
            label10 = new Label();
            txtGiaBan = new TextBox();
            label9 = new Label();
            txtGiaNhap = new TextBox();
            label8 = new Label();
            label7 = new Label();
            txtTenSP = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            dgvSanPham = new DataGridView();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenHang = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colTonKho = new DataGridViewTextBoxColumn();
            colGiaNhap = new DataGridViewTextBoxColumn();
            colGiaBan = new DataGridViewTextBoxColumn();
            btnSua = new Button();
            btnXoa = new Button();
            btnNhapKho = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(36, 11);
            label1.Name = "label1";
            label1.Size = new Size(224, 35);
            label1.TabIndex = 0;
            label1.Text = "Quản lý sản phẩm";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(cboTimKiemHang);
            panel1.Controls.Add(btnTimKiem);
            panel1.Controls.Add(txtTimKiem);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(18, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(627, 144);
            panel1.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Gainsboro;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.Black;
            btnLamMoi.Location = new Point(329, 91);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(114, 39);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // cboTimKiemHang
            // 
            cboTimKiemHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTimKiemHang.Font = new Font("Segoe UI", 10.8F);
            cboTimKiemHang.FormattingEnabled = true;
            cboTimKiemHang.Location = new Point(317, 52);
            cboTimKiemHang.Name = "cboTimKiemHang";
            cboTimKiemHang.Size = new Size(279, 33);
            cboTimKiemHang.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.HotTrack;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(126, 89);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(114, 39);
            btnTimKiem.TabIndex = 6;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10.8F);
            txtTimKiem.Location = new Point(17, 52);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(279, 31);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.Text = "Tên sản phẩm...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label2.Location = new Point(17, 11);
            label2.Name = "label2";
            label2.Size = new Size(90, 25);
            label2.TabIndex = 0;
            label2.Text = "Tìm kiếm";
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.HotTrack;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(34, 221);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(139, 51);
            btnThem.TabIndex = 7;
            btnThem.Text = "➕ Thêm SP";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtCauHinh);
            panel2.Controls.Add(cboHangSanXuat);
            panel2.Controls.Add(txtMaSP);
            panel2.Controls.Add(cboTrangThai);
            panel2.Controls.Add(btnLamTrong);
            panel2.Controls.Add(btnLuu);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(txtTonKho);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(txtGiaBan);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txtGiaNhap);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtTenSP);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(663, 65);
            panel2.Name = "panel2";
            panel2.Size = new Size(428, 836);
            panel2.TabIndex = 8;
            // 
            // txtCauHinh
            // 
            txtCauHinh.Location = new Point(19, 418);
            txtCauHinh.Multiline = true;
            txtCauHinh.Name = "txtCauHinh";
            txtCauHinh.Size = new Size(390, 62);
            txtCauHinh.TabIndex = 26;
            // 
            // cboHangSanXuat
            // 
            cboHangSanXuat.FormattingEnabled = true;
            cboHangSanXuat.Location = new Point(157, 166);
            cboHangSanXuat.Name = "cboHangSanXuat";
            cboHangSanXuat.Size = new Size(227, 28);
            cboHangSanXuat.TabIndex = 25;
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(157, 41);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.ReadOnly = true;
            txtMaSP.Size = new Size(125, 27);
            txtMaSP.TabIndex = 24;
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(145, 522);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(151, 28);
            cboTrangThai.TabIndex = 22;
            // 
            // btnLamTrong
            // 
            btnLamTrong.BackColor = Color.Gainsboro;
            btnLamTrong.FlatStyle = FlatStyle.Flat;
            btnLamTrong.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamTrong.ForeColor = Color.Black;
            btnLamTrong.Location = new Point(233, 606);
            btnLamTrong.Name = "btnLamTrong";
            btnLamTrong.Size = new Size(142, 64);
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
            btnLuu.Location = new Point(19, 606);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(142, 64);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F);
            label11.Location = new Point(19, 390);
            label11.Name = "label11";
            label11.Size = new Size(81, 25);
            label11.TabIndex = 20;
            label11.Text = "Cấu hình";
            // 
            // txtTonKho
            // 
            txtTonKho.Font = new Font("Segoe UI", 10.8F);
            txtTonKho.Location = new Point(19, 342);
            txtTonKho.Name = "txtTonKho";
            txtTonKho.ReadOnly = true;
            txtTonKho.Size = new Size(390, 31);
            txtTonKho.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F);
            label10.Location = new Point(19, 314);
            label10.Name = "label10";
            label10.Size = new Size(152, 25);
            label10.TabIndex = 18;
            label10.Text = "Số lượng tồn kho";
            // 
            // txtGiaBan
            // 
            txtGiaBan.Font = new Font("Segoe UI", 10.8F);
            txtGiaBan.Location = new Point(224, 266);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(172, 31);
            txtGiaBan.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F);
            label9.Location = new Point(224, 238);
            label9.Name = "label9";
            label9.Size = new Size(72, 25);
            label9.TabIndex = 16;
            label9.Text = "Giá bán";
            // 
            // txtGiaNhap
            // 
            txtGiaNhap.Font = new Font("Segoe UI", 10.8F);
            txtGiaNhap.Location = new Point(19, 266);
            txtGiaNhap.Name = "txtGiaNhap";
            txtGiaNhap.Size = new Size(172, 31);
            txtGiaNhap.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F);
            label8.Location = new Point(19, 238);
            label8.Name = "label8";
            label8.Size = new Size(82, 25);
            label8.TabIndex = 14;
            label8.Text = "Giá nhập";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F);
            label7.Location = new Point(19, 165);
            label7.Name = "label7";
            label7.Size = new Size(125, 25);
            label7.TabIndex = 12;
            label7.Text = "Hãng sản xuất";
            // 
            // txtTenSP
            // 
            txtTenSP.Font = new Font("Segoe UI", 10.8F);
            txtTenSP.Location = new Point(19, 117);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(390, 31);
            txtTenSP.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F);
            label6.Location = new Point(19, 89);
            label6.Name = "label6";
            label6.Size = new Size(121, 25);
            label6.TabIndex = 10;
            label6.Text = "Tên sản phẩm";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F);
            label5.Location = new Point(19, 522);
            label5.Name = "label5";
            label5.Size = new Size(89, 25);
            label5.TabIndex = 9;
            label5.Text = "Trạng thái";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F);
            label4.Location = new Point(19, 41);
            label4.Name = "label4";
            label4.Size = new Size(120, 25);
            label4.TabIndex = 8;
            label4.Text = "Mã sản phẩm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label3.ForeColor = Color.MediumBlue;
            label3.Location = new Point(9, 6);
            label3.Name = "label3";
            label3.Size = new Size(182, 25);
            label3.TabIndex = 7;
            label3.Text = "Thông tin sản phẩm";
            // 
            // dgvSanPham
            // 
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.BackgroundColor = Color.White;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Columns.AddRange(new DataGridViewColumn[] { colMaSP, colTenHang, Column2, Column1, colTrangThai, colTonKho, colGiaNhap, colGiaBan });
            dgvSanPham.Location = new Point(18, 285);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.Size = new Size(627, 616);
            dgvSanPham.TabIndex = 9;
            dgvSanPham.CellClick += dgvSanPham_CellClick;
            // 
            // colMaSP
            // 
            colMaSP.DataPropertyName = "MaSP";
            colMaSP.HeaderText = "Mã SP";
            colMaSP.MinimumWidth = 6;
            colMaSP.Name = "colMaSP";
            // 
            // colTenHang
            // 
            colTenHang.DataPropertyName = "TenSP";
            colTenHang.HeaderText = "Tên SP";
            colTenHang.MinimumWidth = 6;
            colTenHang.Name = "colTenHang";
            // 
            // Column2
            // 
            Column2.DataPropertyName = "MaHang";
            Column2.HeaderText = "Hãng SX";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column1
            // 
            Column1.DataPropertyName = "CauHinh";
            Column1.HeaderText = "Cấu hình";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // colTrangThai
            // 
            colTrangThai.DataPropertyName = "TrangThai";
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 6;
            colTrangThai.Name = "colTrangThai";
            // 
            // colTonKho
            // 
            colTonKho.DataPropertyName = "TonKho";
            colTonKho.HeaderText = "Tồn Kho";
            colTonKho.MinimumWidth = 6;
            colTonKho.Name = "colTonKho";
            // 
            // colGiaNhap
            // 
            colGiaNhap.DataPropertyName = "GiaNhap";
            colGiaNhap.HeaderText = "Giá Nhập";
            colGiaNhap.MinimumWidth = 6;
            colGiaNhap.Name = "colGiaNhap";
            // 
            // colGiaBan
            // 
            colGiaBan.DataPropertyName = "GiaBan";
            colGiaBan.HeaderText = "Giá Bán";
            colGiaBan.MinimumWidth = 6;
            colGiaBan.Name = "colGiaBan";
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnSua.ForeColor = Color.Black;
            btnSua.Location = new Point(187, 221);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(126, 51);
            btnSua.TabIndex = 10;
            btnSua.Text = "✎ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(334, 221);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(126, 51);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "✖ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnNhapKho
            // 
            btnNhapKho.BackColor = Color.White;
            btnNhapKho.FlatStyle = FlatStyle.Flat;
            btnNhapKho.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnNhapKho.ForeColor = Color.Black;
            btnNhapKho.Location = new Point(483, 221);
            btnNhapKho.Name = "btnNhapKho";
            btnNhapKho.Size = new Size(132, 51);
            btnNhapKho.TabIndex = 12;
            btnNhapKho.Text = "➜ Nhập kho";
            btnNhapKho.UseVisualStyleBackColor = false;
            btnNhapKho.Click += btnNhapKho_Click;
            // 
            // UC_SanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(btnNhapKho);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(dgvSanPham);
            Controls.Add(panel2);
            Controls.Add(btnThem);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UC_SanPham";
            Size = new Size(1113, 938);
            Load += UC_SanPham_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private ComboBox cboTimKiemHang;
        private TextBox txtTimKiem;
        private Button btnLamMoi;
        private Button btnThem;
        private Button btnTimKiem;
        private Panel panel2;
        private DataGridView dgvSanPham;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label6;
        private Button btnSua;
        private Button btnXoa;
        private Button btnNhapKho;
        private TextBox txtTenSP;
        private Button btnLamTrong;
        private Button btnLuu;
        private Label label11;
        private TextBox txtTonKho;
        private Label label10;
        private TextBox txtGiaBan;
        private Label label9;
        private TextBox txtGiaNhap;
        private Label label8;
        private Label label7;
        private ComboBox cboTrangThai;
        private TextBox txtMaSP;
        private ComboBox cboHangSanXuat;
        private TextBox txtCauHinh;
        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenHang;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewTextBoxColumn colTonKho;
        private DataGridViewTextBoxColumn colGiaNhap;
        private DataGridViewTextBoxColumn colGiaBan;
    }
}
