namespace LHP
{
    partial class UC_ChamSocKH
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            colMaKH = new DataGridViewTextBoxColumn();
            colTenKH = new DataGridViewTextBoxColumn();
            colLoaiChamSoc = new DataGridViewTextBoxColumn();
            colNoiDung = new DataGridViewTextBoxColumn();
            colNgayHen = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colGoi = new DataGridViewButtonColumn();
            colXong = new DataGridViewButtonColumn();
            panel10 = new Panel();
            button1 = new Button();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            textBox2 = new TextBox();
            panel4 = new Panel();
            label8 = new Label();
            label9 = new Label();
            panel3 = new Panel();
            label6 = new Label();
            label7 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            tabPage2 = new TabPage();
            panel6 = new Panel();
            panel11 = new Panel();
            checkBox3 = new CheckBox();
            label24 = new Label();
            numericUpDown3 = new NumericUpDown();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            panel8 = new Panel();
            checkBox2 = new CheckBox();
            label20 = new Label();
            numericUpDown2 = new NumericUpDown();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            panel7 = new Panel();
            checkBox1 = new CheckBox();
            label18 = new Label();
            numericUpDown1 = new NumericUpDown();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            button3 = new Button();
            label19 = new Label();
            panel5 = new Panel();
            btnTaoPhieuBH = new Button();
            label14 = new Label();
            txtGhiChu = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label13 = new Label();
            comboBox5 = new ComboBox();
            label12 = new Label();
            button2 = new Button();
            txtMaPhieu = new TextBox();
            label11 = new Label();
            label10 = new Label();
            tabPage3 = new TabPage();
            panel9 = new Panel();
            btnTimLoHang = new Button();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel10.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel6.SuspendLayout();
            panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel5.SuspendLayout();
            tabPage3.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl1.ItemSize = new Size(384, 40);
            tabControl1.Location = new Point(32, 62);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1188, 1005);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.LightSteelBlue;
            tabPage1.BorderStyle = BorderStyle.FixedSingle;
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(panel10);
            tabPage1.Controls.Add(panel4);
            tabPage1.Controls.Add(panel3);
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 44);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1180, 957);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Danh sách chăm sóc";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colMaKH, colTenKH, colLoaiChamSoc, colNoiDung, colNgayHen, colTrangThai, colGoi, colXong });
            dataGridView1.Location = new Point(6, 239);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1166, 710);
            dataGridView1.TabIndex = 5;
            // 
            // colMaKH
            // 
            colMaKH.HeaderText = "Mã KH";
            colMaKH.MinimumWidth = 6;
            colMaKH.Name = "colMaKH";
            // 
            // colTenKH
            // 
            colTenKH.HeaderText = "Tên KH";
            colTenKH.MinimumWidth = 6;
            colTenKH.Name = "colTenKH";
            // 
            // colLoaiChamSoc
            // 
            colLoaiChamSoc.HeaderText = "Loại chăm sóc";
            colLoaiChamSoc.MinimumWidth = 6;
            colLoaiChamSoc.Name = "colLoaiChamSoc";
            // 
            // colNoiDung
            // 
            colNoiDung.HeaderText = "Nội dung";
            colNoiDung.MinimumWidth = 6;
            colNoiDung.Name = "colNoiDung";
            // 
            // colNgayHen
            // 
            colNgayHen.HeaderText = "Ngày hẹn";
            colNgayHen.MinimumWidth = 6;
            colNgayHen.Name = "colNgayHen";
            // 
            // colTrangThai
            // 
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 6;
            colTrangThai.Name = "colTrangThai";
            // 
            // colGoi
            // 
            colGoi.HeaderText = "Gọi";
            colGoi.MinimumWidth = 6;
            colGoi.Name = "colGoi";
            colGoi.Resizable = DataGridViewTriState.True;
            colGoi.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // colXong
            // 
            colXong.HeaderText = "Xong";
            colXong.MinimumWidth = 6;
            colXong.Name = "colXong";
            // 
            // panel10
            // 
            panel10.BackColor = Color.White;
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(button1);
            panel10.Controls.Add(comboBox3);
            panel10.Controls.Add(comboBox4);
            panel10.Controls.Add(textBox2);
            panel10.Location = new Point(6, 146);
            panel10.Name = "panel10";
            panel10.Size = new Size(1166, 73);
            panel10.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.HotTrack;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1010, 17);
            button1.Name = "button1";
            button1.Size = new Size(128, 38);
            button1.TabIndex = 9;
            button1.Text = "Tìm";
            button1.UseVisualStyleBackColor = false;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(343, 20);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(282, 33);
            comboBox3.TabIndex = 2;
            comboBox3.Text = "--Tất cả trạng thái--";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(18, 20);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(282, 33);
            comboBox4.TabIndex = 1;
            comboBox4.Text = "--Tất cả loại--";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(674, 20);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(282, 31);
            textBox2.TabIndex = 0;
            textBox2.Text = "Tìm tên KH, SĐT...";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label8);
            panel4.Controls.Add(label9);
            panel4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel4.Location = new Point(917, 6);
            panel4.Name = "panel4";
            panel4.Size = new Size(255, 125);
            panel4.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.DarkOliveGreen;
            label8.Location = new Point(18, 71);
            label8.Name = "label8";
            label8.Size = new Size(47, 31);
            label8.TabIndex = 2;
            label8.Text = "KH";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(18, 11);
            label9.Name = "label9";
            label9.Size = new Size(170, 28);
            label9.TabIndex = 1;
            label9.Text = "Đã xử lý tuần này";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label7);
            panel3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel3.Location = new Point(617, 6);
            panel3.Name = "panel3";
            panel3.Size = new Size(255, 125);
            panel3.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Olive;
            label6.Location = new Point(18, 71);
            label6.Name = "label6";
            label6.Size = new Size(47, 31);
            label6.TabIndex = 2;
            label6.Text = "KH";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(18, 11);
            label7.Name = "label7";
            label7.Size = new Size(152, 28);
            label7.TabIndex = 1;
            label7.Text = "Chưa liên hệ lại";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel2.Location = new Point(311, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(255, 125);
            panel2.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.SaddleBrown;
            label4.Location = new Point(18, 71);
            label4.Name = "label4";
            label4.Size = new Size(47, 31);
            label4.TabIndex = 2;
            label4.Text = "KH";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(18, 11);
            label5.Name = "label5";
            label5.Size = new Size(152, 28);
            label5.TabIndex = 1;
            label5.Text = "BH sắp hết hạn";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(255, 125);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.OrangeRed;
            label3.Location = new Point(18, 71);
            label3.Name = "label3";
            label3.Size = new Size(47, 31);
            label3.TabIndex = 2;
            label3.Text = "KH";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(18, 11);
            label2.Name = "label2";
            label2.Size = new Size(144, 28);
            label2.TabIndex = 1;
            label2.Text = "Nhắc hôm nay";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.LightSteelBlue;
            tabPage2.BorderStyle = BorderStyle.FixedSingle;
            tabPage2.Controls.Add(panel6);
            tabPage2.Controls.Add(panel5);
            tabPage2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            tabPage2.Location = new Point(4, 44);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1180, 957);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tạo lịch nhắc";
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(panel11);
            panel6.Controls.Add(panel8);
            panel6.Controls.Add(panel7);
            panel6.Controls.Add(button3);
            panel6.Controls.Add(label19);
            panel6.Location = new Point(607, 6);
            panel6.Name = "panel6";
            panel6.Size = new Size(556, 943);
            panel6.TabIndex = 34;
            // 
            // panel11
            // 
            panel11.BackColor = Color.WhiteSmoke;
            panel11.Controls.Add(checkBox3);
            panel11.Controls.Add(label24);
            panel11.Controls.Add(numericUpDown3);
            panel11.Controls.Add(label25);
            panel11.Controls.Add(label26);
            panel11.Controls.Add(label27);
            panel11.Location = new Point(43, 369);
            panel11.Name = "panel11";
            panel11.Size = new Size(467, 125);
            panel11.TabIndex = 39;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox3.Location = new Point(402, 48);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(18, 17);
            checkBox3.TabIndex = 38;
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label24.Location = new Point(231, 77);
            label24.Name = "label24";
            label24.Size = new Size(138, 28);
            label24.TabIndex = 37;
            label24.Text = "ngày trước SN";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown3.Location = new Point(121, 75);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(99, 34);
            numericUpDown3.TabIndex = 36;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label25.Location = new Point(16, 77);
            label25.Name = "label25";
            label25.Size = new Size(94, 28);
            label25.TabIndex = 34;
            label25.Text = "Nhắc vào";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label26.Location = new Point(16, 39);
            label26.Name = "label26";
            label26.Size = new Size(237, 23);
            label26.TabIndex = 35;
            label26.Text = "Gửi lời chúc + ưu đãi sinh nhật";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label27.Location = new Point(16, 10);
            label27.Name = "label27";
            label27.Size = new Size(187, 25);
            label27.TabIndex = 34;
            label27.Text = "Sinh nhật khách hàng";
            // 
            // panel8
            // 
            panel8.BackColor = Color.WhiteSmoke;
            panel8.Controls.Add(checkBox2);
            panel8.Controls.Add(label20);
            panel8.Controls.Add(numericUpDown2);
            panel8.Controls.Add(label21);
            panel8.Controls.Add(label22);
            panel8.Controls.Add(label23);
            panel8.Location = new Point(43, 221);
            panel8.Name = "panel8";
            panel8.Size = new Size(467, 125);
            panel8.TabIndex = 39;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox2.Location = new Point(402, 48);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(18, 17);
            checkBox2.TabIndex = 38;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label20.Location = new Point(199, 77);
            label20.Name = "label20";
            label20.Size = new Size(125, 28);
            label20.TabIndex = 37;
            label20.Text = "ngày hết hạn";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown2.Location = new Point(89, 75);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(99, 34);
            numericUpDown2.TabIndex = 36;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label21.Location = new Point(16, 77);
            label21.Name = "label21";
            label21.Size = new Size(60, 28);
            label21.TabIndex = 34;
            label21.Text = "Trước";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label22.Location = new Point(16, 39);
            label22.Name = "label22";
            label22.Size = new Size(240, 23);
            label22.TabIndex = 35;
            label22.Text = "Nhắc KH gia hạn hoặc đổi máy";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label23.Location = new Point(16, 10);
            label23.Name = "label23";
            label23.Size = new Size(188, 25);
            label23.TabIndex = 34;
            label23.Text = "Bảo hành sắp hết hạn";
            // 
            // panel7
            // 
            panel7.BackColor = Color.WhiteSmoke;
            panel7.Controls.Add(checkBox1);
            panel7.Controls.Add(label18);
            panel7.Controls.Add(numericUpDown1);
            panel7.Controls.Add(label17);
            panel7.Controls.Add(label16);
            panel7.Controls.Add(label15);
            panel7.Location = new Point(43, 75);
            panel7.Name = "panel7";
            panel7.Size = new Size(467, 125);
            panel7.TabIndex = 34;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.Location = new Point(402, 48);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 38;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(185, 77);
            label18.Name = "label18";
            label18.Size = new Size(55, 28);
            label18.TabIndex = 37;
            label18.Text = "ngày";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown1.Location = new Point(75, 75);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(99, 34);
            numericUpDown1.TabIndex = 36;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(16, 77);
            label17.Name = "label17";
            label17.Size = new Size(44, 28);
            label17.TabIndex = 34;
            label17.Text = "Sau";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(16, 39);
            label16.Name = "label16";
            label16.Size = new Size(224, 23);
            label16.TabIndex = 35;
            label16.Text = "Tự tạo lịch nhắc hỏi thăm KH";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(16, 10);
            label15.Name = "label15";
            label15.Size = new Size(158, 25);
            label15.TabIndex = 34;
            label15.Text = "Sau khi mua hàng";
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ControlDarkDark;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(150, 548);
            button3.Name = "button3";
            button3.Size = new Size(273, 42);
            button3.TabIndex = 33;
            button3.Text = "Lưu cài đăt";
            button3.UseVisualStyleBackColor = false;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label19.ForeColor = Color.MediumBlue;
            label19.Location = new Point(19, 20);
            label19.Name = "label19";
            label19.Size = new Size(190, 25);
            label19.TabIndex = 9;
            label19.Text = "Nhắc tự động (Auto)";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(btnTaoPhieuBH);
            panel5.Controls.Add(label14);
            panel5.Controls.Add(txtGhiChu);
            panel5.Controls.Add(dateTimePicker1);
            panel5.Controls.Add(label13);
            panel5.Controls.Add(comboBox5);
            panel5.Controls.Add(label12);
            panel5.Controls.Add(button2);
            panel5.Controls.Add(txtMaPhieu);
            panel5.Controls.Add(label11);
            panel5.Controls.Add(label10);
            panel5.Location = new Point(6, 6);
            panel5.Name = "panel5";
            panel5.Size = new Size(556, 943);
            panel5.TabIndex = 0;
            // 
            // btnTaoPhieuBH
            // 
            btnTaoPhieuBH.BackColor = SystemColors.HotTrack;
            btnTaoPhieuBH.FlatStyle = FlatStyle.Flat;
            btnTaoPhieuBH.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnTaoPhieuBH.ForeColor = Color.White;
            btnTaoPhieuBH.Location = new Point(118, 620);
            btnTaoPhieuBH.Name = "btnTaoPhieuBH";
            btnTaoPhieuBH.Size = new Size(273, 42);
            btnTaoPhieuBH.TabIndex = 33;
            btnTaoPhieuBH.Text = "Tạo lịch nhắc";
            btnTaoPhieuBH.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(19, 342);
            label14.Name = "label14";
            label14.Size = new Size(129, 25);
            label14.TabIndex = 22;
            label14.Text = "Nội dung nhắc";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtGhiChu.Location = new Point(19, 369);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(508, 189);
            txtGhiChu.TabIndex = 21;
            txtGhiChu.Text = "Nhập nội dung cần trao đổi với khách hàng...";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(19, 281);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(508, 30);
            dateTimePicker1.TabIndex = 17;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(19, 253);
            label13.Name = "label13";
            label13.Size = new Size(110, 25);
            label13.TabIndex = 16;
            label13.Text = "Ngày liên hệ";
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(19, 183);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(508, 31);
            comboBox5.TabIndex = 15;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(19, 155);
            label12.Name = "label12";
            label12.Size = new Size(124, 25);
            label12.TabIndex = 13;
            label12.Text = "Loại chăm sóc";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.HotTrack;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(399, 92);
            button2.Name = "button2";
            button2.Size = new Size(128, 31);
            button2.TabIndex = 12;
            button2.Text = "Tìm";
            button2.UseVisualStyleBackColor = false;
            // 
            // txtMaPhieu
            // 
            txtMaPhieu.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtMaPhieu.Location = new Point(19, 93);
            txtMaPhieu.Name = "txtMaPhieu";
            txtMaPhieu.Size = new Size(344, 31);
            txtMaPhieu.TabIndex = 11;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(19, 65);
            label11.Name = "label11";
            label11.Size = new Size(104, 25);
            label11.TabIndex = 10;
            label11.Text = "Khách hàng";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.MediumBlue;
            label10.Location = new Point(19, 20);
            label10.Name = "label10";
            label10.Size = new Size(206, 25);
            label10.TabIndex = 9;
            label10.Text = "Tạo lịch nhắc thủ công";
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.LightSteelBlue;
            tabPage3.BorderStyle = BorderStyle.FixedSingle;
            tabPage3.Controls.Add(panel9);
            tabPage3.Location = new Point(4, 44);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1180, 957);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Lịch sử liên hệ";
            // 
            // panel9
            // 
            panel9.BackColor = Color.White;
            panel9.Controls.Add(btnTimLoHang);
            panel9.Controls.Add(comboBox2);
            panel9.Controls.Add(comboBox1);
            panel9.Controls.Add(textBox1);
            panel9.Location = new Point(7, 7);
            panel9.Name = "panel9";
            panel9.Size = new Size(1163, 99);
            panel9.TabIndex = 0;
            // 
            // btnTimLoHang
            // 
            btnTimLoHang.BackColor = SystemColors.HotTrack;
            btnTimLoHang.FlatStyle = FlatStyle.Flat;
            btnTimLoHang.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnTimLoHang.ForeColor = Color.White;
            btnTimLoHang.Location = new Point(989, 29);
            btnTimLoHang.Name = "btnTimLoHang";
            btnTimLoHang.Size = new Size(128, 38);
            btnTimLoHang.TabIndex = 9;
            btnTimLoHang.Text = "Tìm";
            btnTimLoHang.UseVisualStyleBackColor = false;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(647, 29);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(282, 33);
            comboBox2.TabIndex = 2;
            comboBox2.Text = "--Tất cả trạng thái--";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(322, 29);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(282, 33);
            comboBox1.TabIndex = 1;
            comboBox1.Text = "--Tất cả sản phẩm--";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(20, 29);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(282, 31);
            textBox1.TabIndex = 0;
            textBox1.Text = "Tìm mã...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(32, 13);
            label1.Name = "label1";
            label1.Size = new Size(268, 35);
            label1.TabIndex = 5;
            label1.Text = "Chăm sóc khách hàng";
            // 
            // UC_ChamSocKH
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "UC_ChamSocKH";
            Size = new Size(1252, 1079);
            Load += UC_ChamSocKH_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tabPage3.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Panel panel9;
        private Button btnTimLoHang;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label1;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Panel panel10;
        private Button button1;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private Panel panel4;
        private Label label8;
        private Label label9;
        private Panel panel3;
        private Label label6;
        private Label label7;
        private Panel panel2;
        private Label label4;
        private Label label5;
        private DataGridView dataGridView1;
        private TextBox textBox2;
        private DataGridViewTextBoxColumn colMaKH;
        private DataGridViewTextBoxColumn colTenKH;
        private DataGridViewTextBoxColumn colLoaiChamSoc;
        private DataGridViewTextBoxColumn colNoiDung;
        private DataGridViewTextBoxColumn colNgayHen;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewButtonColumn colGoi;
        private DataGridViewButtonColumn colXong;
        private Panel panel5;
        private Label label10;
        private Label label13;
        private ComboBox comboBox5;
        private Label label12;
        private Button button2;
        private TextBox txtMaPhieu;
        private Label label11;
        private DateTimePicker dateTimePicker1;
        private Label label14;
        private TextBox txtGhiChu;
        private Button btnTaoPhieuBH;
        private Panel panel6;
        private Button button3;
        private Label label19;
        private Panel panel7;
        private Label label15;
        private Label label16;
        private CheckBox checkBox1;
        private Label label18;
        private NumericUpDown numericUpDown1;
        private Label label17;
        private Panel panel11;
        private CheckBox checkBox3;
        private Label label24;
        private NumericUpDown numericUpDown3;
        private Label label25;
        private Label label26;
        private Label label27;
        private Panel panel8;
        private CheckBox checkBox2;
        private Label label20;
        private NumericUpDown numericUpDown2;
        private Label label21;
        private Label label22;
        private Label label23;
    }
}
