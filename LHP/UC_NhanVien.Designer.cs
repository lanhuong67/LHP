namespace LHP
{
    partial class UC_NhanVien
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
            colMaNV = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colSĐT = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colChucVu = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            textBox3 = new TextBox();
            label9 = new Label();
            textBox5 = new TextBox();
            button4 = new Button();
            button5 = new Button();
            label11 = new Label();
            textBox4 = new TextBox();
            label10 = new Label();
            textBox2 = new TextBox();
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
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(36, 11);
            label1.Name = "label1";
            label1.Size = new Size(226, 35);
            label1.TabIndex = 2;
            label1.Text = "Quản lý nhân viên";
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.Red;
            button2.Location = new Point(416, 191);
            button2.Name = "button2";
            button2.Size = new Size(126, 51);
            button2.TabIndex = 18;
            button2.Text = "✖ Xóa";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(247, 191);
            button1.Name = "button1";
            button1.Size = new Size(126, 51);
            button1.TabIndex = 17;
            button1.Text = "✎ Sửa";
            button1.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colMaNV, colHoTen, colSĐT, colEmail, colChucVu });
            dataGridView1.Location = new Point(16, 262);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(632, 648);
            dataGridView1.TabIndex = 16;
            // 
            // colMaNV
            // 
            colMaNV.HeaderText = "Mã NV";
            colMaNV.MinimumWidth = 6;
            colMaNV.Name = "colMaNV";
            // 
            // colHoTen
            // 
            colHoTen.HeaderText = "Họ Tên";
            colHoTen.MinimumWidth = 6;
            colHoTen.Name = "colHoTen";
            // 
            // colSĐT
            // 
            colSĐT.HeaderText = "SĐT";
            colSĐT.MinimumWidth = 6;
            colSĐT.Name = "colSĐT";
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            // 
            // colChucVu
            // 
            colChucVu.HeaderText = "Chức vụ";
            colChucVu.MinimumWidth = 6;
            colChucVu.Name = "colChucVu";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtThemTenSP);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(668, 58);
            panel2.Name = "panel2";
            panel2.Size = new Size(428, 852);
            panel2.TabIndex = 15;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(19, 494);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(390, 31);
            textBox3.TabIndex = 22;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(19, 466);
            label9.Name = "label9";
            label9.Size = new Size(86, 25);
            label9.TabIndex = 23;
            label9.Text = "Mật khẩu";
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox5.Location = new Point(19, 418);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(390, 31);
            textBox5.TabIndex = 21;
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
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(19, 390);
            label11.Name = "label11";
            label11.Size = new Size(86, 25);
            label11.TabIndex = 20;
            label11.Text = "Tài khoản";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(19, 342);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(390, 31);
            textBox4.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(19, 314);
            label10.Name = "label10";
            label10.Size = new Size(76, 25);
            label10.TabIndex = 18;
            label10.Text = "Chức vụ";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(19, 266);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(390, 31);
            textBox2.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(19, 238);
            label8.Name = "label8";
            label8.Size = new Size(54, 25);
            label8.TabIndex = 14;
            label8.Text = "Email";
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
            label5.Size = new Size(118, 25);
            label5.TabIndex = 9;
            label5.Text = "Mã nhân viên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(19, 41);
            label4.Name = "label4";
            label4.Size = new Size(118, 25);
            label4.TabIndex = 8;
            label4.Text = "Mã nhân viên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.MediumBlue;
            label3.Location = new Point(9, 6);
            label3.Name = "label3";
            label3.Size = new Size(184, 25);
            label3.TabIndex = 7;
            label3.Text = "Thông tin nhân viên";
            // 
            // btnThemSP
            // 
            btnThemSP.BackColor = SystemColors.HotTrack;
            btnThemSP.FlatStyle = FlatStyle.Flat;
            btnThemSP.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnThemSP.ForeColor = Color.White;
            btnThemSP.Location = new Point(67, 191);
            btnThemSP.Name = "btnThemSP";
            btnThemSP.Size = new Size(131, 51);
            btnThemSP.TabIndex = 14;
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
            panel1.Location = new Point(17, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(631, 115);
            panel1.TabIndex = 13;
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
            // UC_NhanVien
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
            Name = "UC_NhanVien";
            Size = new Size(1113, 938);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Label label11;
        private TextBox textBox4;
        private Label label10;
        private TextBox textBox2;
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
        private DataGridViewTextBoxColumn colMaNV;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colSĐT;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colChucVu;
        private TextBox textBox3;
        private Label label9;
        private TextBox textBox5;
    }
}
