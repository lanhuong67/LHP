namespace GUI
{
    partial class UC_HangSanXuat
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
            dgvHangSanXuat = new DataGridView();
            colMaHang = new DataGridViewTextBoxColumn();
            colTenHang = new DataGridViewTextBoxColumn();
            colQuocGia = new DataGridViewTextBoxColumn();
            colMota = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            txtMoTa = new TextBox();
            txtQuocGia = new TextBox();
            cboTrangThai = new ComboBox();
            label5 = new Label();
            txtMaHang = new TextBox();
            btnLamTrong = new Button();
            btnLuu = new Button();
            label8 = new Label();
            label7 = new Label();
            txtTenHang = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnThem = new Button();
            panel1 = new Panel();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHangSanXuat).BeginInit();
            panel2.SuspendLayout();
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
            label1.Size = new Size(182, 35);
            label1.TabIndex = 3;
            label1.Text = "Hãng sản xuất";
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(641, 238);
            btnXoa.Margin = new Padding(4, 4, 4, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(158, 64);
            btnXoa.TabIndex = 30;
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
            btnSua.Location = new Point(364, 238);
            btnSua.Margin = new Padding(4, 4, 4, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(158, 64);
            btnSua.TabIndex = 29;
            btnSua.Text = "✎ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // dgvHangSanXuat
            // 
            dgvHangSanXuat.AllowUserToAddRows = false;
            dgvHangSanXuat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHangSanXuat.BackgroundColor = Color.White;
            dgvHangSanXuat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHangSanXuat.Columns.AddRange(new DataGridViewColumn[] { colMaHang, colTenHang, colQuocGia, colMota, Column1 });
            dgvHangSanXuat.Location = new Point(45, 327);
            dgvHangSanXuat.Margin = new Padding(4, 4, 4, 4);
            dgvHangSanXuat.Name = "dgvHangSanXuat";
            dgvHangSanXuat.RowHeadersWidth = 51;
            dgvHangSanXuat.Size = new Size(868, 644);
            dgvHangSanXuat.TabIndex = 28;
            dgvHangSanXuat.CellClick += dgvHangSanXuat_CellClick;
            // 
            // colMaHang
            // 
            colMaHang.DataPropertyName = "MaHang";
            colMaHang.HeaderText = "Mã hãng";
            colMaHang.MinimumWidth = 6;
            colMaHang.Name = "colMaHang";
            // 
            // colTenHang
            // 
            colTenHang.DataPropertyName = "TenHang";
            colTenHang.HeaderText = "Tên hãng";
            colTenHang.MinimumWidth = 6;
            colTenHang.Name = "colTenHang";
            // 
            // colQuocGia
            // 
            colQuocGia.DataPropertyName = "QuocGia";
            colQuocGia.HeaderText = "Quốc gia";
            colQuocGia.MinimumWidth = 6;
            colQuocGia.Name = "colQuocGia";
            // 
            // colMota
            // 
            colMota.DataPropertyName = "MoTa";
            colMota.HeaderText = "Mô tả";
            colMota.MinimumWidth = 6;
            colMota.Name = "colMota";
            // 
            // Column1
            // 
            Column1.DataPropertyName = "TrangThai";
            Column1.HeaderText = "Trạng Thái";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtMoTa);
            panel2.Controls.Add(txtQuocGia);
            panel2.Controls.Add(cboTrangThai);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtMaHang);
            panel2.Controls.Add(btnLamTrong);
            panel2.Controls.Add(btnLuu);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtTenHang);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(939, 14);
            panel2.Margin = new Padding(4, 4, 4, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(589, 957);
            panel2.TabIndex = 27;
            // 
            // txtMoTa
            // 
            txtMoTa.Font = new Font("Segoe UI", 10.8F);
            txtMoTa.Location = new Point(26, 419);
            txtMoTa.Margin = new Padding(4, 4, 4, 4);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(528, 133);
            txtMoTa.TabIndex = 23;
            // 
            // txtQuocGia
            // 
            txtQuocGia.Location = new Point(34, 312);
            txtQuocGia.Margin = new Padding(4, 4, 4, 4);
            txtQuocGia.Name = "txtQuocGia";
            txtQuocGia.Size = new Size(520, 31);
            txtQuocGia.TabIndex = 22;
            // 
            // cboTrangThai
            // 
            cboTrangThai.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(26, 624);
            cboTrangThai.Margin = new Padding(4, 4, 4, 4);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(528, 33);
            cboTrangThai.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F);
            label5.Location = new Point(26, 589);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(89, 25);
            label5.TabIndex = 20;
            label5.Text = "Trạng thái";
            // 
            // txtMaHang
            // 
            txtMaHang.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaHang.Location = new Point(234, 63);
            txtMaHang.Margin = new Padding(4, 4, 4, 4);
            txtMaHang.Name = "txtMaHang";
            txtMaHang.Size = new Size(320, 31);
            txtMaHang.TabIndex = 19;
            // 
            // btnLamTrong
            // 
            btnLamTrong.BackColor = Color.Gainsboro;
            btnLamTrong.FlatStyle = FlatStyle.Flat;
            btnLamTrong.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamTrong.ForeColor = Color.Black;
            btnLamTrong.Location = new Point(328, 715);
            btnLamTrong.Margin = new Padding(4, 4, 4, 4);
            btnLamTrong.Name = "btnLamTrong";
            btnLamTrong.Size = new Size(178, 50);
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
            btnLuu.Location = new Point(106, 715);
            btnLuu.Margin = new Padding(4, 4, 4, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(178, 50);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F);
            label8.Location = new Point(26, 369);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(59, 25);
            label8.TabIndex = 14;
            label8.Text = "Mô tả";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F);
            label7.Location = new Point(26, 261);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(84, 25);
            label7.TabIndex = 12;
            label7.Text = "Quốc gia";
            // 
            // txtTenHang
            // 
            txtTenHang.Font = new Font("Segoe UI", 10.8F);
            txtTenHang.Location = new Point(26, 177);
            txtTenHang.Margin = new Padding(4, 4, 4, 4);
            txtTenHang.Name = "txtTenHang";
            txtTenHang.Size = new Size(528, 31);
            txtTenHang.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F);
            label6.Location = new Point(26, 142);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(83, 25);
            label6.TabIndex = 10;
            label6.Text = "Tên hãng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F);
            label4.Location = new Point(26, 62);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(152, 25);
            label4.TabIndex = 8;
            label4.Text = "Mã hãng sản xuất";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label3.ForeColor = Color.MediumBlue;
            label3.Location = new Point(14, 9);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(220, 25);
            label3.TabIndex = 7;
            label3.Text = "Thông tin hãng sản xuất";
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.HotTrack;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(87, 241);
            btnThem.Margin = new Padding(4, 4, 4, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(165, 61);
            btnThem.TabIndex = 26;
            btnThem.Text = "➕ Thêm Hãng";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(txtTimKiem);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(38, 76);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(875, 129);
            panel1.TabIndex = 25;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Gainsboro;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.Black;
            btnLamMoi.Location = new Point(703, 56);
            btnLamMoi.Margin = new Padding(4, 4, 4, 4);
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
            txtTimKiem.Location = new Point(48, 65);
            txtTimKiem.Margin = new Padding(4, 4, 4, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(584, 31);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.Text = "Tìm hãng sản xuất...";
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
            // UC_HangSanXuat
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(dgvHangSanXuat);
            Controls.Add(panel2);
            Controls.Add(btnThem);
            Controls.Add(panel1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "UC_HangSanXuat";
            Size = new Size(1546, 986);
            Load += UC_HangSanXuat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHangSanXuat).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnXoa;
        private Button btnSua;
        private DataGridView dgvHangSanXuat;
        private Panel panel2;
        private TextBox txtMaHang;
        private Button btnLamTrong;
        private Button btnLuu;
        private TextBox txtMoTa;
        private Label label8;
        private Label label7;
        private TextBox txtTenHang;
        private Label label6;
        private Label label4;
        private Label label3;
        private Button btnThem;
        private Panel panel1;
        private Button btnLamMoi;
        private TextBox txtTimKiem;
        private Label label2;
        private ComboBox cboTrangThai;
        private Label label5;
        private TextBox txtQuocGia;
        private DataGridViewTextBoxColumn colMaHang;
        private DataGridViewTextBoxColumn colTenHang;
        private DataGridViewTextBoxColumn colQuocGia;
        private DataGridViewTextBoxColumn colMota;
        private DataGridViewTextBoxColumn Column1;
    }
}
