namespace GUI
{
    partial class UC_TaoHoaDon
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
            label2 = new Label();
            lblMaHD = new Label();
            panel1 = new Panel();
            textBox2 = new TextBox();
            label5 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            btnTimKH = new Button();
            textBox3 = new TextBox();
            label6 = new Label();
            textBox4 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            panel3 = new Panel();
            label10 = new Label();
            label9 = new Label();
            btnThemSP = new Button();
            cboSanPham = new ComboBox();
            cboHang = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            panel4 = new Panel();
            label13 = new Label();
            lblSoSP = new Label();
            label12 = new Label();
            label11 = new Label();
            dataGridView1 = new DataGridView();
            colSTT = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colĐonGia = new DataGridViewTextBoxColumn();
            colSL = new DataGridViewTextBoxColumn();
            colThanhTien = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewButtonColumn();
            btnThanhToan = new Button();
            btnHuy = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(36, 11);
            label1.Name = "label1";
            label1.Size = new Size(215, 35);
            label1.TabIndex = 0;
            label1.Text = "Tạo hóa đơn mới";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(36, 61);
            label2.Name = "label2";
            label2.Size = new Size(153, 28);
            label2.TabIndex = 1;
            label2.Text = "Mã HD tự động:";
            // 
            // lblMaHD
            // 
            lblMaHD.AutoSize = true;
            lblMaHD.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblMaHD.Location = new Point(195, 61);
            lblMaHD.Name = "lblMaHD";
            lblMaHD.Size = new Size(40, 28);
            lblMaHD.TabIndex = 2;
            lblMaHD.Text = "HD";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(36, 107);
            panel1.Name = "panel1";
            panel1.Size = new Size(476, 174);
            panel1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(127, 122);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(290, 31);
            textBox2.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(15, 122);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 9;
            label5.Text = "Nhân viên";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(127, 58);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(290, 31);
            textBox1.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(15, 58);
            label4.Name = "label4";
            label4.Size = new Size(83, 25);
            label4.TabIndex = 7;
            label4.Text = "Ngày lập";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(15, 9);
            label3.Name = "label3";
            label3.Size = new Size(160, 25);
            label3.TabIndex = 6;
            label3.Text = "Thông tin hóa đơn";
            label3.Click += label3_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(btnTimKH);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(551, 107);
            panel2.Name = "panel2";
            panel2.Size = new Size(513, 174);
            panel2.TabIndex = 11;
            // 
            // btnTimKH
            // 
            btnTimKH.BackColor = SystemColors.HotTrack;
            btnTimKH.FlatStyle = FlatStyle.Flat;
            btnTimKH.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnTimKH.ForeColor = Color.White;
            btnTimKH.ImageAlign = ContentAlignment.MiddleRight;
            btnTimKH.Location = new Point(381, 56);
            btnTimKH.Name = "btnTimKH";
            btnTimKH.Size = new Size(93, 34);
            btnTimKH.TabIndex = 11;
            btnTimKH.Text = "Tìm";
            btnTimKH.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(127, 122);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(347, 31);
            textBox3.TabIndex = 10;
            textBox3.Text = "Khách vãng lai";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(15, 122);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 9;
            label6.Text = "Tên KH";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(127, 58);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(239, 31);
            textBox4.TabIndex = 8;
            textBox4.Text = "Nhập SĐT tìm KH...";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(15, 58);
            label7.Name = "label7";
            label7.Size = new Size(44, 25);
            label7.TabIndex = 7;
            label7.Text = "SĐT";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(15, 9);
            label8.Name = "label8";
            label8.Size = new Size(104, 25);
            label8.TabIndex = 6;
            label8.Text = "Khách hàng";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(btnThemSP);
            panel3.Controls.Add(cboSanPham);
            panel3.Controls.Add(cboHang);
            panel3.Controls.Add(numericUpDown1);
            panel3.Location = new Point(36, 307);
            panel3.Name = "panel3";
            panel3.Size = new Size(1028, 125);
            panel3.TabIndex = 12;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(15, 11);
            label10.Name = "label10";
            label10.Size = new Size(139, 25);
            label10.TabIndex = 11;
            label10.Text = "Thêm sản phẩm";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(688, 55);
            label9.Name = "label9";
            label9.Size = new Size(30, 25);
            label9.TabIndex = 11;
            label9.Text = "SL";
            // 
            // btnThemSP
            // 
            btnThemSP.BackColor = SystemColors.HotTrack;
            btnThemSP.FlatStyle = FlatStyle.Flat;
            btnThemSP.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnThemSP.ForeColor = Color.White;
            btnThemSP.Location = new Point(875, 51);
            btnThemSP.Name = "btnThemSP";
            btnThemSP.Size = new Size(113, 34);
            btnThemSP.TabIndex = 3;
            btnThemSP.Text = "+ Thêm";
            btnThemSP.UseVisualStyleBackColor = false;
            // 
            // cboSanPham
            // 
            cboSanPham.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            cboSanPham.FormattingEnabled = true;
            cboSanPham.Location = new Point(317, 52);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(344, 33);
            cboSanPham.TabIndex = 2;
            cboSanPham.Text = "--Chọn sản phẩm--";
            // 
            // cboHang
            // 
            cboHang.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            cboHang.FormattingEnabled = true;
            cboHang.Location = new Point(47, 52);
            cboHang.Name = "cboHang";
            cboHang.Size = new Size(229, 33);
            cboHang.TabIndex = 1;
            cboHang.Text = "--Chọn hãng--";
            // 
            // numericUpDown1
            // 
            numericUpDown1.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown1.Location = new Point(737, 54);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(96, 31);
            numericUpDown1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label13);
            panel4.Controls.Add(lblSoSP);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(label11);
            panel4.Location = new Point(639, 721);
            panel4.Name = "panel4";
            panel4.Size = new Size(425, 125);
            panel4.TabIndex = 15;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = SystemColors.HotTrack;
            label13.Location = new Point(268, 68);
            label13.Name = "label13";
            label13.Size = new Size(117, 31);
            label13.TabIndex = 20;
            label13.Text = "Tổng tiền";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSoSP
            // 
            lblSoSP.AutoSize = true;
            lblSoSP.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblSoSP.Location = new Point(241, 19);
            lblSoSP.Name = "lblSoSP";
            lblSoSP.Size = new Size(145, 31);
            lblSoSP.TabIndex = 19;
            lblSoSP.Text = "Số sản phẩm";
            lblSoSP.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(18, 68);
            label12.Name = "label12";
            label12.Size = new Size(117, 31);
            label12.TabIndex = 18;
            label12.Text = "Tổng tiền";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(18, 19);
            label11.Name = "label11";
            label11.Size = new Size(145, 31);
            label11.TabIndex = 17;
            label11.Text = "Số sản phẩm";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colSTT, colTenSP, colĐonGia, colSL, colThanhTien, Column1 });
            dataGridView1.Location = new Point(36, 454);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1028, 205);
            dataGridView1.TabIndex = 16;
            // 
            // colSTT
            // 
            colSTT.HeaderText = "STT";
            colSTT.MinimumWidth = 6;
            colSTT.Name = "colSTT";
            // 
            // colTenSP
            // 
            colTenSP.HeaderText = "Tên sản phẩm";
            colTenSP.MinimumWidth = 6;
            colTenSP.Name = "colTenSP";
            // 
            // colĐonGia
            // 
            colĐonGia.HeaderText = "Đơn giá";
            colĐonGia.MinimumWidth = 6;
            colĐonGia.Name = "colĐonGia";
            // 
            // colSL
            // 
            colSL.HeaderText = "SL";
            colSL.MinimumWidth = 6;
            colSL.Name = "colSL";
            // 
            // colThanhTien
            // 
            colThanhTien.HeaderText = "Thành tiền";
            colThanhTien.MinimumWidth = 6;
            colThanhTien.Name = "colThanhTien";
            // 
            // Column1
            // 
            Column1.HeaderText = "Xóa";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Text = "X";
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = SystemColors.HotTrack;
            btnThanhToan.FlatStyle = FlatStyle.Flat;
            btnThanhToan.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.ImageAlign = ContentAlignment.MiddleRight;
            btnThanhToan.Location = new Point(698, 31);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(168, 58);
            btnThanhToan.TabIndex = 12;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.White;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnHuy.ForeColor = Color.Red;
            btnHuy.ImageAlign = ContentAlignment.MiddleRight;
            btnHuy.Location = new Point(896, 31);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(168, 58);
            btnHuy.TabIndex = 17;
            btnHuy.Text = "Hủy đơn";
            btnHuy.UseVisualStyleBackColor = false;
            // 
            // UC_TaoHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(btnHuy);
            Controls.Add(btnThanhToan);
            Controls.Add(dataGridView1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblMaHD);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UC_TaoHoaDon";
            Size = new Size(1113, 938);
            Load += UC_TaoHoaDon_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lblMaHD;
        private Panel panel1;
        private Label label3;
        private TextBox textBox2;
        private Label label5;
        private TextBox textBox1;
        private Label label4;
        private Panel panel2;
        private Button btnTimKH;
        private TextBox textBox3;
        private Label label6;
        private TextBox textBox4;
        private Label label7;
        private Label label8;
        private Panel panel3;
        private NumericUpDown numericUpDown1;
        private Panel panel4;
        private Button btnThemSP;
        private ComboBox cboSanPham;
        private ComboBox cboHang;
        private Label label10;
        private Label label9;
        private DataGridView dataGridView1;
        private Label label12;
        private Label label11;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colĐonGia;
        private DataGridViewTextBoxColumn colSL;
        private DataGridViewTextBoxColumn colThanhTien;
        private DataGridViewButtonColumn Column1;
        private Label label13;
        private Label lblSoSP;
        private Button btnThanhToan;
        private Button btnHuy;
    }
}
