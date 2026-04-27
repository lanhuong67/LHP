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
            panel2 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            panel9 = new Panel();
            label3 = new Label();
            panel4 = new Panel();
            label4 = new Label();
            panel10 = new Panel();
            dgvDoanhThu = new DataGridView();
            colNgay = new DataGridViewTextBoxColumn();
            colSoHoaDon = new DataGridViewTextBoxColumn();
            colDoanhThu = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThu).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(36, 11);
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
            panel1.Location = new Point(36, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(309, 238);
            panel1.TabIndex = 2;
            // 
            // btnXem
            // 
            btnXem.BackColor = SystemColors.HotTrack;
            btnXem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnXem.ForeColor = Color.White;
            btnXem.Location = new Point(53, 183);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(191, 39);
            btnXem.TabIndex = 7;
            btnXem.Text = "Xem báo cáo";
            btnXem.UseVisualStyleBackColor = false;
            // 
            // cboNam
            // 
            cboNam.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            cboNam.FormattingEnabled = true;
            cboNam.Location = new Point(17, 135);
            cboNam.Name = "cboNam";
            cboNam.Size = new Size(274, 33);
            cboNam.TabIndex = 2;
            cboNam.Text = "Theo năm";
            // 
            // cboThang
            // 
            cboThang.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            cboThang.FormattingEnabled = true;
            cboThang.Location = new Point(17, 76);
            cboThang.Name = "cboThang";
            cboThang.Size = new Size(274, 33);
            cboThang.TabIndex = 1;
            cboThang.Text = "Theo Tháng";
            // 
            // cboNgay
            // 
            cboNgay.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            cboNgay.FormattingEnabled = true;
            cboNgay.Location = new Point(17, 16);
            cboNgay.Name = "cboNgay";
            cboNgay.Size = new Size(274, 33);
            cboNgay.TabIndex = 0;
            cboNgay.Text = "Theo ngày";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label2);
            panel3.Location = new Point(36, 327);
            panel3.Name = "panel3";
            panel3.Size = new Size(309, 125);
            panel3.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(17, 14);
            label2.Name = "label2";
            label2.Size = new Size(160, 28);
            label2.TabIndex = 0;
            label2.Text = "Tổng doanh thu";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(panel5);
            panel2.Location = new Point(391, 327);
            panel2.Name = "panel2";
            panel2.Size = new Size(309, 125);
            panel2.TabIndex = 5;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(panel6);
            panel5.Location = new Point(-1, -1);
            panel5.Name = "panel5";
            panel5.Size = new Size(309, 125);
            panel5.TabIndex = 6;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(panel7);
            panel6.Location = new Point(-1, -1);
            panel6.Name = "panel6";
            panel6.Size = new Size(309, 125);
            panel6.TabIndex = 7;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(panel8);
            panel7.Location = new Point(-1, -1);
            panel7.Name = "panel7";
            panel7.Size = new Size(309, 125);
            panel7.TabIndex = 8;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(panel9);
            panel8.Location = new Point(-1, -1);
            panel8.Name = "panel8";
            panel8.Size = new Size(309, 125);
            panel8.TabIndex = 9;
            // 
            // panel9
            // 
            panel9.BackColor = Color.White;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(label3);
            panel9.Location = new Point(-1, -1);
            panel9.Name = "panel9";
            panel9.Size = new Size(309, 125);
            panel9.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(26, 14);
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
            panel4.Location = new Point(748, 327);
            panel4.Name = "panel4";
            panel4.Size = new Size(309, 125);
            panel4.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(22, 14);
            label4.Name = "label4";
            label4.Size = new Size(207, 28);
            label4.TabIndex = 2;
            label4.Text = "Trung bình / hóa đơn";
            // 
            // panel10
            // 
            panel10.BackColor = Color.White;
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Location = new Point(391, 64);
            panel10.Name = "panel10";
            panel10.Size = new Size(666, 238);
            panel10.TabIndex = 11;
            // 
            // dgvDoanhThu
            // 
            dgvDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoanhThu.BackgroundColor = Color.White;
            dgvDoanhThu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoanhThu.Columns.AddRange(new DataGridViewColumn[] { colNgay, colSoHoaDon, colDoanhThu });
            dgvDoanhThu.Location = new Point(36, 483);
            dgvDoanhThu.Name = "dgvDoanhThu";
            dgvDoanhThu.RowHeadersWidth = 51;
            dgvDoanhThu.RowTemplate.Height = 29;
            dgvDoanhThu.Size = new Size(1021, 282);
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
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(dgvDoanhThu);
            Controls.Add(panel10);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UC_DoanhThu";
            Size = new Size(1113, 938);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
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
        private Panel panel2;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
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
    }
}
