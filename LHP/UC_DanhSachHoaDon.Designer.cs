namespace GUI
{
    partial class UC_DanhSachHoaDon
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
            btnLamMoiDsHd = new Button();
            btnLocDsHd = new Button();
            cboTrangThai = new ComboBox();
            label2 = new Label();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            dgvDsHd = new DataGridView();
            colMaHD = new DataGridViewTextBoxColumn();
            colNgayLap = new DataGridViewTextBoxColumn();
            colNhanVien = new DataGridViewTextBoxColumn();
            colKhachHang = new DataGridViewTextBoxColumn();
            colTongTien = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colChiTiet = new DataGridViewButtonColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDsHd).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(36, 11);
            label1.Name = "label1";
            label1.Size = new Size(238, 35);
            label1.TabIndex = 2;
            label1.Text = "Danh sách hóa đơn";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnLamMoiDsHd);
            panel1.Controls.Add(btnLocDsHd);
            panel1.Controls.Add(cboTrangThai);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dtpDenNgay);
            panel1.Controls.Add(dtpTuNgay);
            panel1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(36, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(1033, 278);
            panel1.TabIndex = 3;
            // 
            // btnLamMoiDsHd
            // 
            btnLamMoiDsHd.BackColor = Color.Gainsboro;
            btnLamMoiDsHd.FlatStyle = FlatStyle.Flat;
            btnLamMoiDsHd.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnLamMoiDsHd.ForeColor = Color.Black;
            btnLamMoiDsHd.Location = new Point(154, 213);
            btnLamMoiDsHd.Name = "btnLamMoiDsHd";
            btnLamMoiDsHd.Size = new Size(114, 39);
            btnLamMoiDsHd.TabIndex = 7;
            btnLamMoiDsHd.Text = "Làm mới";
            btnLamMoiDsHd.UseVisualStyleBackColor = false;
            // 
            // btnLocDsHd
            // 
            btnLocDsHd.BackColor = SystemColors.HotTrack;
            btnLocDsHd.FlatStyle = FlatStyle.Flat;
            btnLocDsHd.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnLocDsHd.ForeColor = Color.White;
            btnLocDsHd.Location = new Point(34, 213);
            btnLocDsHd.Name = "btnLocDsHd";
            btnLocDsHd.Size = new Size(114, 39);
            btnLocDsHd.TabIndex = 8;
            btnLocDsHd.Text = "Lọc";
            btnLocDsHd.UseVisualStyleBackColor = false;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(34, 157);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(941, 33);
            cboTrangThai.TabIndex = 3;
            cboTrangThai.Text = "--Tất cả trạng thái--";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 64);
            label2.Name = "label2";
            label2.Size = new Size(42, 25);
            label2.TabIndex = 2;
            label2.Text = "đến";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(34, 98);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(941, 31);
            dtpDenNgay.TabIndex = 1;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(34, 20);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(941, 31);
            dtpTuNgay.TabIndex = 0;
            // 
            // dgvDsHd
            // 
            dgvDsHd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDsHd.BackgroundColor = Color.White;
            dgvDsHd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDsHd.Columns.AddRange(new DataGridViewColumn[] { colMaHD, colNgayLap, colNhanVien, colKhachHang, colTongTien, colTrangThai, colChiTiet });
            dgvDsHd.Location = new Point(36, 377);
            dgvDsHd.Name = "dgvDsHd";
            dgvDsHd.RowHeadersWidth = 51;
            dgvDsHd.RowTemplate.Height = 29;
            dgvDsHd.Size = new Size(1033, 528);
            dgvDsHd.TabIndex = 4;
            // 
            // colMaHD
            // 
            colMaHD.HeaderText = "Mã HD";
            colMaHD.MinimumWidth = 6;
            colMaHD.Name = "colMaHD";
            // 
            // colNgayLap
            // 
            colNgayLap.HeaderText = "Ngày lập";
            colNgayLap.MinimumWidth = 6;
            colNgayLap.Name = "colNgayLap";
            // 
            // colNhanVien
            // 
            colNhanVien.HeaderText = "Nhân viên";
            colNhanVien.MinimumWidth = 6;
            colNhanVien.Name = "colNhanVien";
            // 
            // colKhachHang
            // 
            colKhachHang.HeaderText = "Khách hàng";
            colKhachHang.MinimumWidth = 6;
            colKhachHang.Name = "colKhachHang";
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
            // UC_DanhSachHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(dgvDsHd);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UC_DanhSachHoaDon";
            Size = new Size(1113, 938);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDsHd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private ComboBox cboTrangThai;
        private Label label2;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtpTuNgay;
        private Button btnLamMoiDsHd;
        private Button btnLocDsHd;
        private DataGridView dgvDsHd;
        private DataGridViewTextBoxColumn colMaHD;
        private DataGridViewTextBoxColumn colNgayLap;
        private DataGridViewTextBoxColumn colNhanVien;
        private DataGridViewTextBoxColumn colKhachHang;
        private DataGridViewTextBoxColumn colTongTien;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewButtonColumn colChiTiet;
    }
}
