namespace GUI
{
    partial class UC_KhachHang
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
            dgvKhachHang = new DataGridView();
            colMaKH = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colSĐT = new DataGridViewTextBoxColumn();
            colDiaChi = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            txtMaKH = new TextBox();
            panel3 = new Panel();
            lblTongChiTieu = new Label();
            lblSoLanMua = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            btnLamTrong = new Button();
            btnLuu = new Button();
            txtDiaChi = new TextBox();
            label8 = new Label();
            txtSDT = new TextBox();
            label7 = new Label();
            txtHoTen = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnThemKH = new Button();
            panel1 = new Panel();
            btnLamMoi = new Button();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(36, 11);
            label1.Name = "label1";
            label1.Size = new Size(245, 35);
            label1.TabIndex = 2;
            label1.Text = "Quản lý khách hàng";
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(415, 191);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(126, 51);
            btnXoa.TabIndex = 24;
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
            btnSua.Location = new Point(246, 191);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(126, 51);
            btnSua.TabIndex = 23;
            btnSua.Text = "✎ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Columns.AddRange(new DataGridViewColumn[] { colMaKH, colHoTen, colSĐT, colDiaChi });
            dgvKhachHang.Location = new Point(15, 262);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.Size = new Size(602, 638);
            dgvKhachHang.TabIndex = 22;
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
            // 
            // colMaKH
            // 
            colMaKH.DataPropertyName = "MaKH";
            colMaKH.HeaderText = "Mã KH";
            colMaKH.MinimumWidth = 6;
            colMaKH.Name = "colMaKH";
            // 
            // colHoTen
            // 
            colHoTen.DataPropertyName = "HoTen";
            colHoTen.HeaderText = "Họ tên";
            colHoTen.MinimumWidth = 6;
            colHoTen.Name = "colHoTen";
            // 
            // colSĐT
            // 
            colSĐT.DataPropertyName = "SDT";
            colSĐT.HeaderText = "SĐT";
            colSĐT.MinimumWidth = 6;
            colSĐT.Name = "colSĐT";
            // 
            // colDiaChi
            // 
            colDiaChi.DataPropertyName = "DiaChi";
            colDiaChi.HeaderText = "Địa chỉ";
            colDiaChi.MinimumWidth = 6;
            colDiaChi.Name = "colDiaChi";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtMaKH);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(btnLamTrong);
            panel2.Controls.Add(btnLuu);
            panel2.Controls.Add(txtDiaChi);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtSDT);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtHoTen);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(642, 58);
            panel2.Name = "panel2";
            panel2.Size = new Size(428, 842);
            panel2.TabIndex = 21;
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(174, 42);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(146, 27);
            txtMaKH.TabIndex = 19;
            // 
            // panel3
            // 
            panel3.BackColor = Color.GhostWhite;
            panel3.Controls.Add(lblTongChiTieu);
            panel3.Controls.Add(lblSoLanMua);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label9);
            panel3.Location = new Point(19, 354);
            panel3.Name = "panel3";
            panel3.Size = new Size(390, 125);
            panel3.TabIndex = 18;
            // 
            // lblTongChiTieu
            // 
            lblTongChiTieu.AutoSize = true;
            lblTongChiTieu.Location = new Point(210, 93);
            lblTongChiTieu.Name = "lblTongChiTieu";
            lblTongChiTieu.Size = new Size(33, 20);
            lblTongChiTieu.TabIndex = 21;
            lblTongChiTieu.Text = "TCT";
            // 
            // lblSoLanMua
            // 
            lblSoLanMua.AutoSize = true;
            lblSoLanMua.Location = new Point(210, 53);
            lblSoLanMua.Name = "lblSoLanMua";
            lblSoLanMua.Size = new Size(24, 20);
            lblSoLanMua.TabIndex = 20;
            lblSoLanMua.Text = "SL";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F);
            label11.Location = new Point(12, 89);
            label11.Name = "label11";
            label11.Size = new Size(118, 25);
            label11.TabIndex = 20;
            label11.Text = "Tổng chi tiêu:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F);
            label10.Location = new Point(12, 53);
            label10.Name = "label10";
            label10.Size = new Size(105, 25);
            label10.TabIndex = 19;
            label10.Text = "Số lần mua:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label9.Location = new Point(12, 11);
            label9.Name = "label9";
            label9.Size = new Size(155, 25);
            label9.TabIndex = 19;
            label9.Text = "Lịch sử mua hàng";
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
            btnLamTrong.Click += btnLamTrong_Click;
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
            btnLuu.Click += btnLuu_Click;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10.8F);
            txtDiaChi.Location = new Point(19, 266);
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(390, 64);
            txtDiaChi.TabIndex = 17;
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
            // txtSDT
            // 
            txtSDT.Font = new Font("Segoe UI", 10.8F);
            txtSDT.Location = new Point(19, 193);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(390, 31);
            txtSDT.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F);
            label7.Location = new Point(19, 165);
            label7.Name = "label7";
            label7.Size = new Size(117, 25);
            label7.TabIndex = 12;
            label7.Text = "Số điện thoại";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 10.8F);
            txtHoTen.Location = new Point(19, 117);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(390, 31);
            txtHoTen.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F);
            label6.Location = new Point(19, 89);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 10;
            label6.Text = "Họ tên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F);
            label4.Location = new Point(19, 41);
            label4.Name = "label4";
            label4.Size = new Size(133, 25);
            label4.TabIndex = 8;
            label4.Text = "Mã khách hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label3.ForeColor = Color.MediumBlue;
            label3.Location = new Point(9, 6);
            label3.Name = "label3";
            label3.Size = new Size(199, 25);
            label3.TabIndex = 7;
            label3.Text = "Thông tin khách hàng";
            // 
            // btnThemKH
            // 
            btnThemKH.BackColor = SystemColors.HotTrack;
            btnThemKH.FlatStyle = FlatStyle.Flat;
            btnThemKH.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnThemKH.ForeColor = Color.White;
            btnThemKH.Location = new Point(66, 191);
            btnThemKH.Name = "btnThemKH";
            btnThemKH.Size = new Size(132, 51);
            btnThemKH.TabIndex = 20;
            btnThemKH.Text = "➕ Thêm KH";
            btnThemKH.UseVisualStyleBackColor = false;
            btnThemKH.Click += btnThemKH_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(btnTimKiem);
            panel1.Controls.Add(txtTimKiem);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(16, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(602, 115);
            panel1.TabIndex = 19;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Gainsboro;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.Black;
            btnLamMoi.Location = new Point(483, 48);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(114, 39);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.HotTrack;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(363, 48);
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
            txtTimKiem.Location = new Point(9, 52);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(348, 31);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.Text = "Tìm tên hoặc số điện thoại...";
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
            // UC_KhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(dgvKhachHang);
            Controls.Add(panel2);
            Controls.Add(btnThemKH);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UC_KhachHang";
            Size = new Size(1113, 938);
            Load += UC_KhachHang_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnXoa;
        private Button btnSua;
        private DataGridView dgvKhachHang;
        private Panel panel2;
        private Button btnLamTrong;
        private Button btnLuu;
        private TextBox txtDiaChi;
        private Label label8;
        private TextBox txtSDT;
        private Label label7;
        private TextBox txtHoTen;
        private Label label6;
        private Label label4;
        private Label label3;
        private Button btnThemKH;
        private Panel panel1;
        private Button btnLamMoi;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private Label label2;
        private Panel panel3;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox txtMaKH;
        private Label lblTongChiTieu;
        private Label lblSoLanMua;
        private DataGridViewTextBoxColumn colMaKH;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colSĐT;
        private DataGridViewTextBoxColumn colDiaChi;
    }
}
