namespace LHP
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
            button2 = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            colMaKH = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colSĐT = new DataGridViewTextBoxColumn();
            colDiaChi = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            panel3 = new Panel();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            button4 = new Button();
            button5 = new Button();
            textBox4 = new TextBox();
            label8 = new Label();
            textBox1 = new TextBox();
            label7 = new Label();
            txtThemTenSP = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnThemSP = new Button();
            panel1 = new Panel();
            btnLamMoi = new Button();
            btnTimKiem = new Button();
            txtTenSP = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(36, 11);
            label1.Name = "label1";
            label1.Size = new Size(245, 35);
            label1.TabIndex = 2;
            label1.Text = "Quản lý khách hàng";
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.Red;
            button2.Location = new Point(415, 191);
            button2.Name = "button2";
            button2.Size = new Size(126, 51);
            button2.TabIndex = 24;
            button2.Text = "✖ Xóa";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(246, 191);
            button1.Name = "button1";
            button1.Size = new Size(126, 51);
            button1.TabIndex = 23;
            button1.Text = "✎ Sửa";
            button1.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colMaKH, colHoTen, colSĐT, colDiaChi });
            dataGridView1.Location = new Point(15, 262);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(602, 638);
            dataGridView1.TabIndex = 22;
            // 
            // colMaKH
            // 
            colMaKH.HeaderText = "Mã KH";
            colMaKH.MinimumWidth = 6;
            colMaKH.Name = "colMaKH";
            // 
            // colHoTen
            // 
            colHoTen.HeaderText = "Họ tên";
            colHoTen.MinimumWidth = 6;
            colHoTen.Name = "colHoTen";
            // 
            // colSĐT
            // 
            colSĐT.HeaderText = "SĐT";
            colSĐT.MinimumWidth = 6;
            colSĐT.Name = "colSĐT";
            // 
            // colDiaChi
            // 
            colDiaChi.HeaderText = "Địa chỉ";
            colDiaChi.MinimumWidth = 6;
            colDiaChi.Name = "colDiaChi";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtThemTenSP);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(642, 58);
            panel2.Name = "panel2";
            panel2.Size = new Size(428, 842);
            panel2.TabIndex = 21;
            // 
            // panel3
            // 
            panel3.BackColor = Color.GhostWhite;
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label9);
            panel3.Location = new Point(19, 354);
            panel3.Name = "panel3";
            panel3.Size = new Size(390, 125);
            panel3.TabIndex = 18;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = SystemColors.HotTrack;
            label13.Location = new Point(250, 89);
            label13.Name = "label13";
            label13.Size = new Size(124, 25);
            label13.TabIndex = 22;
            label13.Text = "Tổng chi tiêu";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(273, 53);
            label12.Name = "label12";
            label12.Size = new Size(101, 25);
            label12.TabIndex = 21;
            label12.Text = "Số lần mua";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(12, 89);
            label11.Name = "label11";
            label11.Size = new Size(114, 25);
            label11.TabIndex = 20;
            label11.Text = "Tổng chi tiểu";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(12, 53);
            label10.Name = "label10";
            label10.Size = new Size(101, 25);
            label10.TabIndex = 19;
            label10.Text = "Số lần mua";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(12, 11);
            label9.Name = "label9";
            label9.Size = new Size(155, 25);
            label9.TabIndex = 19;
            label9.Text = "Lịch sử mua hàng";
            // 
            // button4
            // 
            button4.BackColor = Color.Gainsboro;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.Black;
            button4.Location = new Point(234, 575);
            button4.Name = "button4";
            button4.Size = new Size(142, 64);
            button4.TabIndex = 7;
            button4.Text = "Làm trống";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.HotTrack;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.White;
            button5.Location = new Point(56, 575);
            button5.Name = "button5";
            button5.Size = new Size(142, 64);
            button5.TabIndex = 8;
            button5.Text = "Lưu";
            button5.UseVisualStyleBackColor = false;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(19, 266);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(390, 64);
            textBox4.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(19, 238);
            label8.Name = "label8";
            label8.Size = new Size(65, 25);
            label8.TabIndex = 14;
            label8.Text = "Địa chỉ";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(19, 193);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(390, 31);
            textBox1.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(19, 165);
            label7.Name = "label7";
            label7.Size = new Size(117, 25);
            label7.TabIndex = 12;
            label7.Text = "Số điện thoại";
            // 
            // txtThemTenSP
            // 
            txtThemTenSP.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtThemTenSP.Location = new Point(19, 117);
            txtThemTenSP.Name = "txtThemTenSP";
            txtThemTenSP.Size = new Size(390, 31);
            txtThemTenSP.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(19, 89);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 10;
            label6.Text = "Họ tên";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(158, 41);
            label5.Name = "label5";
            label5.Size = new Size(133, 25);
            label5.TabIndex = 9;
            label5.Text = "Mã khách hàng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(19, 41);
            label4.Name = "label4";
            label4.Size = new Size(133, 25);
            label4.TabIndex = 8;
            label4.Text = "Mã khách hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.MediumBlue;
            label3.Location = new Point(9, 6);
            label3.Name = "label3";
            label3.Size = new Size(199, 25);
            label3.TabIndex = 7;
            label3.Text = "Thông tin khách hàng";
            // 
            // btnThemSP
            // 
            btnThemSP.BackColor = SystemColors.HotTrack;
            btnThemSP.FlatStyle = FlatStyle.Flat;
            btnThemSP.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnThemSP.ForeColor = Color.White;
            btnThemSP.Location = new Point(66, 191);
            btnThemSP.Name = "btnThemSP";
            btnThemSP.Size = new Size(132, 51);
            btnThemSP.TabIndex = 20;
            btnThemSP.Text = "➕ Thêm SP";
            btnThemSP.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(btnTimKiem);
            panel1.Controls.Add(txtTenSP);
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
            btnLamMoi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnLamMoi.ForeColor = Color.Black;
            btnLamMoi.Location = new Point(483, 48);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(114, 39);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = SystemColors.HotTrack;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(363, 48);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(114, 39);
            btnTimKiem.TabIndex = 6;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtTenSP
            // 
            txtTenSP.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtTenSP.Location = new Point(9, 52);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(348, 31);
            txtTenSP.TabIndex = 1;
            txtTenSP.Text = "Tìm tên hoặc số điện thoại...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
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
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(btnThemSP);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "UC_KhachHang";
            Size = new Size(1113, 938);
            Load += UC_KhachHang_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private Button button2;
        private Button button1;
        private DataGridView dataGridView1;
        private Panel panel2;
        private Button button4;
        private Button button5;
        private TextBox textBox4;
        private Label label8;
        private TextBox textBox1;
        private Label label7;
        private TextBox txtThemTenSP;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button btnThemSP;
        private Panel panel1;
        private Button btnLamMoi;
        private Button btnTimKiem;
        private TextBox txtTenSP;
        private Label label2;
        private DataGridViewTextBoxColumn colMaKH;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colSĐT;
        private DataGridViewTextBoxColumn colDiaChi;
        private Panel panel3;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
    }
}
