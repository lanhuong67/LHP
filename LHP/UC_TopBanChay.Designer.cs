namespace GUI
{
    partial class UC_TopBanChay
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
            dgvTopBanChay = new DataGridView();
            colHang = new DataGridViewTextBoxColumn();
            colSanPham = new DataGridViewTextBoxColumn();
            colTenHang = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDoanhThu = new DataGridViewTextBoxColumn();
            label1 = new Label();
            cboThoiGian = new ComboBox();
            btnXem = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTopBanChay).BeginInit();
            SuspendLayout();
            // 
            // dgvTopBanChay
            // 
            dgvTopBanChay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopBanChay.BackgroundColor = Color.White;
            dgvTopBanChay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopBanChay.Columns.AddRange(new DataGridViewColumn[] { colHang, colSanPham, colTenHang, colSoLuong, colDoanhThu });
            dgvTopBanChay.Location = new Point(43, 146);
            dgvTopBanChay.Name = "dgvTopBanChay";
            dgvTopBanChay.RowHeadersWidth = 51;
            dgvTopBanChay.Size = new Size(1297, 723);
            dgvTopBanChay.TabIndex = 0;
            // 
            // colHang
            // 
            colHang.HeaderText = "Hạng";
            colHang.MinimumWidth = 6;
            colHang.Name = "colHang";
            // 
            // colSanPham
            // 
            colSanPham.HeaderText = "Sản Phẩm";
            colSanPham.MinimumWidth = 6;
            colSanPham.Name = "colSanPham";
            // 
            // colTenHang
            // 
            colTenHang.HeaderText = "Hãng";
            colTenHang.MinimumWidth = 6;
            colTenHang.Name = "colTenHang";
            // 
            // colSoLuong
            // 
            colSoLuong.HeaderText = "Số lượng bán";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            // 
            // colDoanhThu
            // 
            colDoanhThu.HeaderText = "Doanh Thu";
            colDoanhThu.MinimumWidth = 6;
            colDoanhThu.Name = "colDoanhThu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(43, 14);
            label1.Name = "label1";
            label1.Size = new Size(290, 35);
            label1.TabIndex = 2;
            label1.Text = "Top sản phẩm bán chạy";
            // 
            // cboThoiGian
            // 
            cboThoiGian.Font = new Font("Segoe UI", 12F);
            cboThoiGian.FormattingEnabled = true;
            cboThoiGian.Location = new Point(748, 81);
            cboThoiGian.Name = "cboThoiGian";
            cboThoiGian.Size = new Size(327, 36);
            cboThoiGian.TabIndex = 3;
            // 
            // btnXem
            // 
            btnXem.BackColor = SystemColors.HotTrack;
            btnXem.FlatStyle = FlatStyle.Flat;
            btnXem.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnXem.ForeColor = Color.White;
            btnXem.Location = new Point(1134, 76);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(178, 45);
            btnXem.TabIndex = 9;
            btnXem.Text = "Xem";
            btnXem.UseVisualStyleBackColor = false;
            // 
            // UC_TopBanChay
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(btnXem);
            Controls.Add(cboThoiGian);
            Controls.Add(label1);
            Controls.Add(dgvTopBanChay);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "UC_TopBanChay";
            Size = new Size(1370, 886);
            ((System.ComponentModel.ISupportInitialize)dgvTopBanChay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTopBanChay;
        private Label label1;
        private ComboBox cboThoiGian;
        private Button btnXem;
        private DataGridViewTextBoxColumn colHang;
        private DataGridViewTextBoxColumn colSanPham;
        private DataGridViewTextBoxColumn colTenHang;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDoanhThu;
    }
}
