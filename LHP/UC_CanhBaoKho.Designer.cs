namespace LHP
{
    partial class UC_CanhBaoKho
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
            btnLamMoi = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewCheckBoxColumn();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colHang = new DataGridViewTextBoxColumn();
            colTonKho = new DataGridViewTextBoxColumn();
            colMucCanhBao = new DataGridViewTextBoxColumn();
            colThaoTac = new DataGridViewButtonColumn();
            panel1 = new Panel();
            label7 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            label9 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            label8 = new Label();
            label5 = new Label();
            button5 = new Button();
            label2 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(36, 11);
            label1.Name = "label1";
            label1.Size = new Size(223, 35);
            label1.TabIndex = 2;
            label1.Text = "Cảnh báo tồn kho";
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.WhiteSmoke;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnLamMoi.ForeColor = Color.Black;
            btnLamMoi.Location = new Point(890, 11);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(163, 57);
            btnLamMoi.TabIndex = 6;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, colMaSP, colTenSP, colHang, colTonKho, colMucCanhBao, colThaoTac });
            dataGridView1.Location = new Point(36, 346);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1017, 552);
            dataGridView1.TabIndex = 7;
            // 
            // Column1
            // 
            Column1.HeaderText = "";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // colMaSP
            // 
            colMaSP.HeaderText = "Mã SP";
            colMaSP.MinimumWidth = 6;
            colMaSP.Name = "colMaSP";
            // 
            // colTenSP
            // 
            colTenSP.HeaderText = "Tên SP";
            colTenSP.MinimumWidth = 6;
            colTenSP.Name = "colTenSP";
            // 
            // colHang
            // 
            colHang.HeaderText = "Hãng";
            colHang.MinimumWidth = 6;
            colHang.Name = "colHang";
            // 
            // colTonKho
            // 
            colTonKho.HeaderText = "Tồn kho";
            colTonKho.MinimumWidth = 6;
            colTonKho.Name = "colTonKho";
            // 
            // colMucCanhBao
            // 
            colMucCanhBao.HeaderText = "Mức cảnh báo";
            colMucCanhBao.MinimumWidth = 6;
            colMucCanhBao.Name = "colMucCanhBao";
            // 
            // colThaoTac
            // 
            colThaoTac.HeaderText = "Thao tác";
            colThaoTac.MinimumWidth = 6;
            colThaoTac.Name = "colThaoTac";
            colThaoTac.Resizable = DataGridViewTriState.True;
            colThaoTac.SortMode = DataGridViewColumnSortMode.Automatic;
            colThaoTac.Text = "Nhập kho";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LavenderBlush;
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(36, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(316, 100);
            panel1.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.DarkRed;
            label7.Location = new Point(22, 55);
            label7.Name = "label7";
            label7.Size = new Size(41, 31);
            label7.TabIndex = 15;
            label7.Text = "SP";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.DarkRed;
            label4.Location = new Point(22, 13);
            label4.Name = "label4";
            label4.Size = new Size(182, 25);
            label4.TabIndex = 14;
            label4.Text = "Nguy hiểm (tồn ≤ 2)";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Honeydew;
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(737, 88);
            panel2.Name = "panel2";
            panel2.Size = new Size(316, 100);
            panel2.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.DarkGreen;
            label9.Location = new Point(17, 55);
            label9.Name = "label9";
            label9.Size = new Size(41, 31);
            label9.TabIndex = 17;
            label9.Text = "SP";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.DarkGreen;
            label6.Location = new Point(17, 13);
            label6.Name = "label6";
            label6.Size = new Size(199, 25);
            label6.TabIndex = 16;
            label6.Text = "Còn hàng bình thường";
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightYellow;
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(388, 88);
            panel3.Name = "panel3";
            panel3.Size = new Size(316, 100);
            panel3.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.DarkGoldenrod;
            label8.Location = new Point(20, 55);
            label8.Name = "label8";
            label8.Size = new Size(41, 31);
            label8.TabIndex = 16;
            label8.Text = "SP";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.DarkGoldenrod;
            label5.Location = new Point(20, 13);
            label5.Name = "label5";
            label5.Size = new Size(154, 25);
            label5.TabIndex = 15;
            label5.Text = "Sắp hết (tồn 3–4)";
            // 
            // button5
            // 
            button5.BackColor = SystemColors.HotTrack;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.White;
            button5.Location = new Point(69, 267);
            button5.Name = "button5";
            button5.Size = new Size(263, 53);
            button5.TabIndex = 10;
            button5.Text = "Nhập kho hàng loạt";
            button5.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(58, 219);
            label2.Name = "label2";
            label2.Size = new Size(820, 28);
            label2.TabIndex = 11;
            label2.Text = "Nhấn nút Nhập kho trên từng dòng hoặc chọn nhiều sản phẩm rồi nhấn Nhập kho hàng loạt.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(832, 278);
            label3.Name = "label3";
            label3.Size = new Size(42, 28);
            label3.TabIndex = 12;
            label3.Text = "Lọc";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(880, 275);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 36);
            comboBox1.TabIndex = 13;
            comboBox1.Text = "Tất cả";
            // 
            // UC_CanhBaoKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(btnLamMoi);
            Controls.Add(label1);
            Name = "UC_CanhBaoKho";
            Size = new Size(1113, 938);
            Load += UC_CanhBaoKho_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnLamMoi;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridViewCheckBoxColumn Column1;
        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colHang;
        private DataGridViewTextBoxColumn colTonKho;
        private DataGridViewTextBoxColumn colMucCanhBao;
        private DataGridViewButtonColumn colThaoTac;
        private Button button5;
        private Label label2;
        private Label label3;
        private ComboBox comboBox1;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label9;
        private Label label6;
        private Label label8;
    }
}
