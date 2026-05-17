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
            btnLamMoi = new Button();
            cboTrangThai = new ComboBox();
            label2 = new Label();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            dgvDanhSachHoaDon = new DataGridView();
            colMaHD = new DataGridViewTextBoxColumn();
            colNgayLap = new DataGridViewTextBoxColumn();
            colTenNhanVien = new DataGridViewTextBoxColumn();
            colTenKhachHang = new DataGridViewTextBoxColumn();
            colTongTien = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colChiTiet = new DataGridViewButtonColumn();
            colHuyDon = new DataGridViewButtonColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachHoaDon).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(45, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(238, 35);
            label1.TabIndex = 2;
            label1.Text = "Danh sách hóa đơn";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(cboTrangThai);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dtpDenNgay);
            panel1.Controls.Add(dtpTuNgay);
            panel1.Font = new Font("Segoe UI", 10.8F);
            panel1.Location = new Point(45, 53);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1291, 283);
            panel1.TabIndex = 3;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Gainsboro;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.Black;
            btnLamMoi.Location = new Point(42, 216);
            btnLamMoi.Margin = new Padding(4, 4, 4, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(201, 46);
            btnLamMoi.TabIndex = 7;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(42, 154);
            cboTrangThai.Margin = new Padding(4, 4, 4, 4);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(1175, 33);
            cboTrangThai.TabIndex = 3;
            cboTrangThai.Text = "--Tất cả trạng thái--";
            cboTrangThai.SelectedIndexChanged += Cbo_AutoDropDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 64);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(42, 25);
            label2.TabIndex = 2;
            label2.Text = "đến";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(42, 93);
            dtpDenNgay.Margin = new Padding(4, 4, 4, 4);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(1175, 31);
            dtpDenNgay.TabIndex = 1;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(42, 25);
            dtpTuNgay.Margin = new Padding(4, 4, 4, 4);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(1175, 31);
            dtpTuNgay.TabIndex = 0;
            // 
            // dgvDanhSachHoaDon
            // 
            dgvDanhSachHoaDon.AllowUserToAddRows = false;
            dgvDanhSachHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachHoaDon.BackgroundColor = Color.White;
            dgvDanhSachHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachHoaDon.Columns.AddRange(new DataGridViewColumn[] { colMaHD, colNgayLap, colTenNhanVien, colTenKhachHang, colTongTien, colTrangThai, colChiTiet, colHuyDon });
            dgvDanhSachHoaDon.Location = new Point(67, 371);
            dgvDanhSachHoaDon.Margin = new Padding(4, 4, 4, 4);
            dgvDanhSachHoaDon.Name = "dgvDanhSachHoaDon";
            dgvDanhSachHoaDon.RowHeadersVisible = false;
            dgvDanhSachHoaDon.RowHeadersWidth = 51;
            dgvDanhSachHoaDon.Size = new Size(1460, 595);
            dgvDanhSachHoaDon.TabIndex = 4;
            dgvDanhSachHoaDon.CellContentClick += dgvDanhSachHoaDon_CellContentClick;
            dgvDanhSachHoaDon.CellFormatting += dgvDanhSachHoaDon_CellFormatting;
            // 
            // colMaHD
            // 
            colMaHD.DataPropertyName = "MaHD";
            colMaHD.HeaderText = "Mã HD";
            colMaHD.MinimumWidth = 6;
            colMaHD.Name = "colMaHD";
            // 
            // colNgayLap
            // 
            colNgayLap.DataPropertyName = "NgayLap";
            colNgayLap.HeaderText = "Ngày lập";
            colNgayLap.MinimumWidth = 6;
            colNgayLap.Name = "colNgayLap";
            // 
            // colTenNhanVien
            // 
            colTenNhanVien.DataPropertyName = "TenNhanVien";
            colTenNhanVien.HeaderText = "Nhân viên";
            colTenNhanVien.MinimumWidth = 6;
            colTenNhanVien.Name = "colTenNhanVien";
            // 
            // colTenKhachHang
            // 
            colTenKhachHang.DataPropertyName = "TenKhachHang";
            colTenKhachHang.HeaderText = "Khách hàng";
            colTenKhachHang.MinimumWidth = 6;
            colTenKhachHang.Name = "colTenKhachHang";
            // 
            // colTongTien
            // 
            colTongTien.DataPropertyName = "TongTien";
            colTongTien.HeaderText = "Tổng tiền";
            colTongTien.MinimumWidth = 6;
            colTongTien.Name = "colTongTien";
            // 
            // colTrangThai
            // 
            colTrangThai.DataPropertyName = "TrangThai";
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
            // colHuyDon
            // 
            colHuyDon.HeaderText = "Hủy đơn";
            colHuyDon.MinimumWidth = 6;
            colHuyDon.Name = "colHuyDon";
            colHuyDon.Text = "Hủy";
            colHuyDon.UseColumnTextForButtonValue = true;
            // 
            // UC_DanhSachHoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(dgvDanhSachHoaDon);
            Controls.Add(panel1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "UC_DanhSachHoaDon";
            Size = new Size(1546, 986);
            Load += UC_DanhSachHoaDon_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachHoaDon).EndInit();
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
        private Button btnLamMoi;
        private DataGridView dgvDanhSachHoaDon;
        private DataGridViewTextBoxColumn colMaHD;
        private DataGridViewTextBoxColumn colNgayLap;
        private DataGridViewTextBoxColumn colTenNhanVien;
        private DataGridViewTextBoxColumn colTenKhachHang;
        private DataGridViewTextBoxColumn colTongTien;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewButtonColumn colChiTiet;
        private DataGridViewButtonColumn colHuyDon;
    }
}
