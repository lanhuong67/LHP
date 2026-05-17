namespace GUI
{
    partial class UC_DoanhThu
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
            btnXem = new Button();
            cboNam = new ComboBox();
            cboThang = new ComboBox();
            cboNgay = new ComboBox();
            panel3 = new Panel();
            label2 = new Label();
            panel9 = new Panel();
            label3 = new Label();
            panel4 = new Panel();
            label4 = new Label();
            panel10 = new Panel();
            label6 = new Label();
            dgvDoanhThu = new DataGridView();
            colNgay = new DataGridViewTextBoxColumn();
            colSoHoaDon = new DataGridViewTextBoxColumn();
            colDoanhThu = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel9.SuspendLayout();
            panel4.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThu).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(45, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(233, 35);
            label1.TabIndex = 1;
            label1.Text = "Báo cáo doanh thu";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnXem);
            panel1.Controls.Add(cboNam);
            panel1.Controls.Add(cboThang);
            panel1.Controls.Add(cboNgay);
            panel1.Location = new Point(45, 80);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(386, 249);
            panel1.TabIndex = 2;
            // 
            // btnXem
            // 
            btnXem.BackColor = SystemColors.HotTrack;
            btnXem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnXem.ForeColor = Color.White;
            btnXem.Location = new Point(71, 181);
            btnXem.Margin = new Padding(4);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(239, 49);
            btnXem.TabIndex = 7;
            btnXem.Text = "Xem báo cáo";
            btnXem.UseVisualStyleBackColor = false;
            // 
            // cboNam
            // 
            cboNam.Font = new Font("Segoe UI", 10.8F);
            cboNam.FormattingEnabled = true;
            cboNam.Location = new Point(21, 125);
            cboNam.Margin = new Padding(4);
            cboNam.Name = "cboNam";
            cboNam.Size = new Size(342, 33);
            cboNam.TabIndex = 2;
            cboNam.Text = "Theo năm";
            // 
            // cboThang
            // 
            cboThang.Font = new Font("Segoe UI", 10.8F);
            cboThang.FormattingEnabled = true;
            cboThang.Location = new Point(21, 71);
            cboThang.Margin = new Padding(4);
            cboThang.Name = "cboThang";
            cboThang.Size = new Size(342, 33);
            cboThang.TabIndex = 1;
            cboThang.Text = "Theo Tháng";
            cboThang.SelectedIndexChanged += cboThang_SelectedIndexChanged;
            // 
            // cboNgay
            // 
            cboNgay.Font = new Font("Segoe UI", 10.8F);
            cboNgay.FormattingEnabled = true;
            cboNgay.Location = new Point(21, 20);
            cboNgay.Margin = new Padding(4);
            cboNgay.Name = "cboNgay";
            cboNgay.Size = new Size(342, 33);
            cboNgay.TabIndex = 0;
            cboNgay.Text = "Theo ngày";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label2);
            panel3.Location = new Point(45, 359);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(386, 156);
            panel3.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(21, 18);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(160, 28);
            label2.TabIndex = 0;
            label2.Text = "Tổng doanh thu";
            // 
            // panel9
            // 
            panel9.BackColor = Color.White;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(label3);
            panel9.Location = new Point(489, 359);
            panel9.Margin = new Padding(4);
            panel9.Name = "panel9";
            panel9.Size = new Size(386, 156);
            panel9.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(32, 18);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(117, 28);
            label3.TabIndex = 1;
            label3.Text = "Số hóa đơn";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label4);
            panel4.Location = new Point(958, 359);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new Size(386, 156);
            panel4.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(28, 18);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(207, 28);
            label4.TabIndex = 2;
            label4.Text = "Trung bình / hóa đơn";
            // 
            // panel10
            // 
            panel10.BackColor = Color.White;
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(label6);
            panel10.Location = new Point(489, 80);
            panel10.Margin = new Padding(4);
            panel10.Name = "panel10";
            panel10.Size = new Size(855, 256);
            panel10.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(255, 130);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(264, 28);
            label6.TabIndex = 2;
            label6.Text = "//này là dashboard á nha ;))";
            // 
            // dgvDoanhThu
            // 
            dgvDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoanhThu.BackgroundColor = Color.White;
            dgvDoanhThu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoanhThu.Columns.AddRange(new DataGridViewColumn[] { colNgay, colSoHoaDon, colDoanhThu });
            dgvDoanhThu.Location = new Point(45, 537);
            dgvDoanhThu.Margin = new Padding(4);
            dgvDoanhThu.Name = "dgvDoanhThu";
            dgvDoanhThu.RowHeadersWidth = 51;
            dgvDoanhThu.Size = new Size(1299, 345);
            dgvDoanhThu.TabIndex = 12;
            // 
            // colNgay
            // 
            colNgay.HeaderText = "Ngày";
            colNgay.MinimumWidth = 6;
            colNgay.Name = "colNgay";
            // 
            // colSoHoaDon
            // 
            colSoHoaDon.HeaderText = "Số hóa đơn";
            colSoHoaDon.MinimumWidth = 6;
            colSoHoaDon.Name = "colSoHoaDon";
            // 
            // colDoanhThu
            // 
            colDoanhThu.HeaderText = "Doanh thu";
            colDoanhThu.MinimumWidth = 6;
            colDoanhThu.Name = "colDoanhThu";
            // 
            // UC_DoanhThu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(panel9);
            Controls.Add(dgvDoanhThu);
            Controls.Add(panel10);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "UC_DoanhThu";
            Size = new Size(1370, 886);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private ComboBox cboNam;
        private ComboBox cboThang;
        private ComboBox cboNgay;
        private Button btnXem;
        private Panel panel3;
        private Panel panel9;
        private Panel panel4;
        private Panel panel10;
        private DataGridView dgvDoanhThu;
        private DataGridViewTextBoxColumn colNgay;
        private DataGridViewTextBoxColumn colSoHoaDon;
        private DataGridViewTextBoxColumn colDoanhThu;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
    }
}
