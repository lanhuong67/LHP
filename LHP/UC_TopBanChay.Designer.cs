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
            dataGridView1 = new DataGridView();
            colHang = new DataGridViewTextBoxColumn();
            colSanPham = new DataGridViewTextBoxColumn();
            colTenHang = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDoanhThu = new DataGridViewTextBoxColumn();
            label1 = new Label();
            comboBox1 = new ComboBox();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colHang, colSanPham, colTenHang, colSoLuong, colDoanhThu });
            dataGridView1.Location = new Point(57, 146);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1009, 722);
            dataGridView1.TabIndex = 0;
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
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(39, 13);
            label1.Name = "label1";
            label1.Size = new Size(290, 35);
            label1.TabIndex = 2;
            label1.Text = "Top sản phẩm bán chạy";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(674, 70);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(205, 36);
            comboBox1.TabIndex = 3;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.HotTrack;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.White;
            button5.Location = new Point(906, 70);
            button5.Name = "button5";
            button5.Size = new Size(160, 41);
            button5.TabIndex = 9;
            button5.Text = "Xem";
            button5.UseVisualStyleBackColor = false;
            // 
            // UC_TopBanChay
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(button5);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "UC_TopBanChay";
            Size = new Size(1113, 938);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private ComboBox comboBox1;
        private Button button5;
        private DataGridViewTextBoxColumn colHang;
        private DataGridViewTextBoxColumn colSanPham;
        private DataGridViewTextBoxColumn colTenHang;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDoanhThu;
    }
}
