namespace GUI
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
            dgvDsChamSoc = new DataGridView();
            colMaKH = new DataGridViewTextBoxColumn();
            colTenKH = new DataGridViewTextBoxColumn();
            colLoaiChamSoc = new DataGridViewTextBoxColumn();
            colNoiDung = new DataGridViewTextBoxColumn();
            colNgayHen = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colGoi = new DataGridViewButtonColumn();
            colXong = new DataGridViewButtonColumn();
            panel10 = new Panel();
            btnTim = new Button();
            cboTrangThai = new ComboBox();
            cboLoai = new ComboBox();
            txtTimKiem = new TextBox();
            panel4 = new Panel();
            lblDaXuLy = new Label();
            label9 = new Label();
            panel3 = new Panel();
            lblChuaLienHe = new Label();
            label7 = new Label();
            panel2 = new Panel();
            lblSapHetHan = new Label();
            label5 = new Label();
            panel1 = new Panel();
            lblNhac = new Label();
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
            btnLuu = new Button();
            label19 = new Label();
            panel5 = new Panel();
            btnTaoLichNhac = new Button();
            label14 = new Label();
            txtGhiChu = new TextBox();
            dtpNgayLH = new DateTimePicker();
            label13 = new Label();
            cboLoaiCS = new ComboBox();
            label12 = new Label();
            button2 = new Button();
            txtMaPhieu = new TextBox();
            label11 = new Label();
            label10 = new Label();
            tabPage3 = new TabPage();
            dataGridView2 = new DataGridView();
            colMaKhCS = new DataGridViewTextBoxColumn();
            colTenKhCs = new DataGridViewTextBoxColumn();
            colLoaiCs = new DataGridViewTextBoxColumn();
            colNoiDungGhiCHu = new DataGridViewTextBoxColumn();
            colNgayLienHe = new DataGridViewTextBoxColumn();
            colNhanVien = new DataGridViewTextBoxColumn();
            panel9 = new Panel();
            btnLamTrong = new Button();
            btnTimKH = new Button();
            cboLoaiKH = new ComboBox();
            txtTimKH = new TextBox();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDsChamSoc).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Font = new Font("Segoe UI", 10.8F);
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
            tabPage1.Controls.Add(dgvDsChamSoc);
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
            // dgvDsChamSoc
            // 
            dgvDsChamSoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDsChamSoc.BackgroundColor = Color.White;
            dgvDsChamSoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDsChamSoc.Columns.AddRange(new DataGridViewColumn[] { colMaKH, colTenKH, colLoaiChamSoc, colNoiDung, colNgayHen, colTrangThai, colGoi, colXong });
            dgvDsChamSoc.Location = new Point(6, 239);
            dgvDsChamSoc.Name = "dgvDsChamSoc";
            dgvDsChamSoc.RowHeadersWidth = 51;
            dgvDsChamSoc.Size = new Size(1166, 710);
            dgvDsChamSoc.TabIndex = 5;
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
            panel10.Controls.Add(btnTim);
            panel10.Controls.Add(cboTrangThai);
            panel10.Controls.Add(cboLoai);
            panel10.Controls.Add(txtTimKiem);
            panel10.Location = new Point(6, 146);
            panel10.Name = "panel10";
            panel10.Size = new Size(1166, 73);
            panel10.TabIndex = 4;
            // 
            // btnTim
            // 
            btnTim.BackColor = SystemColors.HotTrack;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnTim.ForeColor = Color.White;
            btnTim.Location = new Point(1010, 17);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(128, 38);
            btnTim.TabIndex = 9;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = false;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(343, 20);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(282, 33);
            cboTrangThai.TabIndex = 2;
            cboTrangThai.Text = "--Tất cả trạng thái--";
            // 
            // cboLoai
            // 
            cboLoai.FormattingEnabled = true;
            cboLoai.Location = new Point(18, 20);
            cboLoai.Name = "cboLoai";
            cboLoai.Size = new Size(282, 33);
            cboLoai.TabIndex = 1;
            cboLoai.Text = "--Tất cả loại--";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(674, 20);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(282, 31);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.Text = "Tìm tên KH, SĐT...";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblDaXuLy);
            panel4.Controls.Add(label9);
            panel4.Font = new Font("Segoe UI", 12F);
            panel4.Location = new Point(917, 6);
            panel4.Name = "panel4";
            panel4.Size = new Size(255, 125);
            panel4.TabIndex = 3;
            // 
            // lblDaXuLy
            // 
            lblDaXuLy.AutoSize = true;
            lblDaXuLy.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblDaXuLy.ForeColor = Color.DarkOliveGreen;
            lblDaXuLy.Location = new Point(18, 71);
            lblDaXuLy.Name = "lblDaXuLy";
            lblDaXuLy.Size = new Size(47, 31);
            lblDaXuLy.TabIndex = 2;
            lblDaXuLy.Text = "KH";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
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
            panel3.Controls.Add(lblChuaLienHe);
            panel3.Controls.Add(label7);
            panel3.Font = new Font("Segoe UI", 12F);
            panel3.Location = new Point(617, 6);
            panel3.Name = "panel3";
            panel3.Size = new Size(255, 125);
            panel3.TabIndex = 3;
            // 
            // lblChuaLienHe
            // 
            lblChuaLienHe.AutoSize = true;
            lblChuaLienHe.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblChuaLienHe.ForeColor = Color.Olive;
            lblChuaLienHe.Location = new Point(18, 71);
            lblChuaLienHe.Name = "lblChuaLienHe";
            lblChuaLienHe.Size = new Size(47, 31);
            lblChuaLienHe.TabIndex = 2;
            lblChuaLienHe.Text = "KH";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
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
            panel2.Controls.Add(lblSapHetHan);
            panel2.Controls.Add(label5);
            panel2.Font = new Font("Segoe UI", 12F);
            panel2.Location = new Point(311, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(255, 125);
            panel2.TabIndex = 3;
            // 
            // lblSapHetHan
            // 
            lblSapHetHan.AutoSize = true;
            lblSapHetHan.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblSapHetHan.ForeColor = Color.SaddleBrown;
            lblSapHetHan.Location = new Point(18, 71);
            lblSapHetHan.Name = "lblSapHetHan";
            lblSapHetHan.Size = new Size(47, 31);
            lblSapHetHan.TabIndex = 2;
            lblSapHetHan.Text = "KH";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
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
            panel1.Controls.Add(lblNhac);
            panel1.Controls.Add(label2);
            panel1.Font = new Font("Segoe UI", 12F);
            panel1.Location = new Point(6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(255, 125);
            panel1.TabIndex = 0;
            // 
            // lblNhac
            // 
            lblNhac.AutoSize = true;
            lblNhac.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblNhac.ForeColor = Color.OrangeRed;
            lblNhac.Location = new Point(18, 71);
            lblNhac.Name = "lblNhac";
            lblNhac.Size = new Size(47, 31);
            lblNhac.TabIndex = 2;
            lblNhac.Text = "KH";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
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
            tabPage2.Font = new Font("Segoe UI", 10.2F);
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
            panel6.Controls.Add(btnLuu);
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
            checkBox3.Font = new Font("Segoe UI", 12F);
            checkBox3.Location = new Point(402, 48);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(18, 17);
            checkBox3.TabIndex = 38;
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 12F);
            label24.Location = new Point(231, 77);
            label24.Name = "label24";
            label24.Size = new Size(138, 28);
            label24.TabIndex = 37;
            label24.Text = "ngày trước SN";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Font = new Font("Segoe UI", 12F);
            numericUpDown3.Location = new Point(121, 75);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(99, 34);
            numericUpDown3.TabIndex = 36;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 12F);
            label25.Location = new Point(16, 77);
            label25.Name = "label25";
            label25.Size = new Size(94, 28);
            label25.TabIndex = 34;
            label25.Text = "Nhắc vào";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI Semilight", 10.2F);
            label26.Location = new Point(16, 39);
            label26.Name = "label26";
            label26.Size = new Size(237, 23);
            label26.TabIndex = 35;
            label26.Text = "Gửi lời chúc + ưu đãi sinh nhật";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
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
            checkBox2.Font = new Font("Segoe UI", 12F);
            checkBox2.Location = new Point(402, 48);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(18, 17);
            checkBox2.TabIndex = 38;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F);
            label20.Location = new Point(199, 77);
            label20.Name = "label20";
            label20.Size = new Size(125, 28);
            label20.TabIndex = 37;
            label20.Text = "ngày hết hạn";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Font = new Font("Segoe UI", 12F);
            numericUpDown2.Location = new Point(89, 75);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(99, 34);
            numericUpDown2.TabIndex = 36;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 12F);
            label21.Location = new Point(16, 77);
            label21.Name = "label21";
            label21.Size = new Size(60, 28);
            label21.TabIndex = 34;
            label21.Text = "Trước";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI Semilight", 10.2F);
            label22.Location = new Point(16, 39);
            label22.Name = "label22";
            label22.Size = new Size(240, 23);
            label22.TabIndex = 35;
            label22.Text = "Nhắc KH gia hạn hoặc đổi máy";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
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
            checkBox1.Font = new Font("Segoe UI", 12F);
            checkBox1.Location = new Point(402, 48);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 38;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F);
            label18.Location = new Point(185, 77);
            label18.Name = "label18";
            label18.Size = new Size(55, 28);
            label18.TabIndex = 37;
            label18.Text = "ngày";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 12F);
            numericUpDown1.Location = new Point(75, 75);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(99, 34);
            numericUpDown1.TabIndex = 36;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F);
            label17.Location = new Point(16, 77);
            label17.Name = "label17";
            label17.Size = new Size(44, 28);
            label17.TabIndex = 34;
            label17.Text = "Sau";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semilight", 10.2F);
            label16.Location = new Point(16, 39);
            label16.Name = "label16";
            label16.Size = new Size(224, 23);
            label16.TabIndex = 35;
            label16.Text = "Tự tạo lịch nhắc hỏi thăm KH";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label15.Location = new Point(16, 10);
            label15.Name = "label15";
            label15.Size = new Size(158, 25);
            label15.TabIndex = 34;
            label15.Text = "Sau khi mua hàng";
            // 
            // btnLuu
            // 
            btnLuu.BackColor = SystemColors.ControlDarkDark;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(150, 548);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(273, 42);
            btnLuu.TabIndex = 33;
            btnLuu.Text = "Lưu cài đặt";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
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
            panel5.Controls.Add(btnTaoLichNhac);
            panel5.Controls.Add(label14);
            panel5.Controls.Add(txtGhiChu);
            panel5.Controls.Add(dtpNgayLH);
            panel5.Controls.Add(label13);
            panel5.Controls.Add(cboLoaiCS);
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
            // btnTaoLichNhac
            // 
            btnTaoLichNhac.BackColor = SystemColors.HotTrack;
            btnTaoLichNhac.FlatStyle = FlatStyle.Flat;
            btnTaoLichNhac.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnTaoLichNhac.ForeColor = Color.White;
            btnTaoLichNhac.Location = new Point(118, 620);
            btnTaoLichNhac.Name = "btnTaoLichNhac";
            btnTaoLichNhac.Size = new Size(273, 42);
            btnTaoLichNhac.TabIndex = 33;
            btnTaoLichNhac.Text = "Tạo lịch nhắc";
            btnTaoLichNhac.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10.8F);
            label14.Location = new Point(19, 342);
            label14.Name = "label14";
            label14.Size = new Size(129, 25);
            label14.TabIndex = 22;
            label14.Text = "Nội dung nhắc";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Font = new Font("Segoe UI", 10.8F);
            txtGhiChu.Location = new Point(19, 369);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(508, 189);
            txtGhiChu.TabIndex = 21;
            txtGhiChu.Text = "Nhập nội dung cần trao đổi với khách hàng...";
            // 
            // dtpNgayLH
            // 
            dtpNgayLH.Location = new Point(19, 281);
            dtpNgayLH.Name = "dtpNgayLH";
            dtpNgayLH.Size = new Size(508, 30);
            dtpNgayLH.TabIndex = 17;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.8F);
            label13.Location = new Point(19, 253);
            label13.Name = "label13";
            label13.Size = new Size(110, 25);
            label13.TabIndex = 16;
            label13.Text = "Ngày liên hệ";
            // 
            // cboLoaiCS
            // 
            cboLoaiCS.FormattingEnabled = true;
            cboLoaiCS.Location = new Point(19, 183);
            cboLoaiCS.Name = "cboLoaiCS";
            cboLoaiCS.Size = new Size(508, 31);
            cboLoaiCS.TabIndex = 15;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.8F);
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
            button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
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
            txtMaPhieu.Font = new Font("Segoe UI", 10.8F);
            txtMaPhieu.Location = new Point(19, 93);
            txtMaPhieu.Name = "txtMaPhieu";
            txtMaPhieu.Size = new Size(344, 31);
            txtMaPhieu.TabIndex = 11;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.8F);
            label11.Location = new Point(19, 65);
            label11.Name = "label11";
            label11.Size = new Size(104, 25);
            label11.TabIndex = 10;
            label11.Text = "Khách hàng";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
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
            tabPage3.Controls.Add(dataGridView2);
            tabPage3.Controls.Add(panel9);
            tabPage3.Location = new Point(4, 44);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1180, 957);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Lịch sử liên hệ";
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { colMaKhCS, colTenKhCs, colLoaiCs, colNoiDungGhiCHu, colNgayLienHe, colNhanVien });
            dataGridView2.Location = new Point(7, 100);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1163, 849);
            dataGridView2.TabIndex = 1;
            // 
            // colMaKhCS
            // 
            colMaKhCS.HeaderText = "Mã KH";
            colMaKhCS.MinimumWidth = 6;
            colMaKhCS.Name = "colMaKhCS";
            // 
            // colTenKhCs
            // 
            colTenKhCs.HeaderText = "Tên KH";
            colTenKhCs.MinimumWidth = 6;
            colTenKhCs.Name = "colTenKhCs";
            // 
            // colLoaiCs
            // 
            colLoaiCs.HeaderText = "Loại chăm sóc";
            colLoaiCs.MinimumWidth = 6;
            colLoaiCs.Name = "colLoaiCs";
            // 
            // colNoiDungGhiCHu
            // 
            colNoiDungGhiCHu.HeaderText = "Nội dung ghi chú";
            colNoiDungGhiCHu.MinimumWidth = 6;
            colNoiDungGhiCHu.Name = "colNoiDungGhiCHu";
            // 
            // colNgayLienHe
            // 
            colNgayLienHe.HeaderText = "Ngày liên hệ";
            colNgayLienHe.MinimumWidth = 6;
            colNgayLienHe.Name = "colNgayLienHe";
            // 
            // colNhanVien
            // 
            colNhanVien.HeaderText = "Nhân viên";
            colNhanVien.MinimumWidth = 6;
            colNhanVien.Name = "colNhanVien";
            // 
            // panel9
            // 
            panel9.BackColor = Color.White;
            panel9.Controls.Add(btnLamTrong);
            panel9.Controls.Add(btnTimKH);
            panel9.Controls.Add(cboLoaiKH);
            panel9.Controls.Add(txtTimKH);
            panel9.Location = new Point(7, 7);
            panel9.Name = "panel9";
            panel9.Size = new Size(1163, 87);
            panel9.TabIndex = 0;
            // 
            // btnLamTrong
            // 
            btnLamTrong.BackColor = Color.Gainsboro;
            btnLamTrong.FlatStyle = FlatStyle.Flat;
            btnLamTrong.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamTrong.ForeColor = Color.Black;
            btnLamTrong.Location = new Point(991, 21);
            btnLamTrong.Name = "btnLamTrong";
            btnLamTrong.Size = new Size(128, 38);
            btnLamTrong.TabIndex = 10;
            btnLamTrong.Text = "Làm trống";
            btnLamTrong.UseVisualStyleBackColor = false;
            btnLamTrong.Click += button4_Click;
            // 
            // btnTimKH
            // 
            btnTimKH.BackColor = SystemColors.HotTrack;
            btnTimKH.FlatStyle = FlatStyle.Flat;
            btnTimKH.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnTimKH.ForeColor = Color.White;
            btnTimKH.Location = new Point(795, 20);
            btnTimKH.Name = "btnTimKH";
            btnTimKH.Size = new Size(128, 38);
            btnTimKH.TabIndex = 9;
            btnTimKH.Text = "Tìm";
            btnTimKH.UseVisualStyleBackColor = false;
            // 
            // cboLoaiKH
            // 
            cboLoaiKH.FormattingEnabled = true;
            cboLoaiKH.Location = new Point(459, 23);
            cboLoaiKH.Name = "cboLoaiKH";
            cboLoaiKH.Size = new Size(282, 33);
            cboLoaiKH.TabIndex = 1;
            cboLoaiKH.Text = "--Tất cả loại--";
            // 
            // txtTimKH
            // 
            txtTimKH.Location = new Point(36, 25);
            txtTimKH.Name = "txtTimKH";
            txtTimKH.Size = new Size(377, 31);
            txtTimKH.TabIndex = 0;
            txtTimKH.Text = "Tìm tên KH, SĐT......";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
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
            Font = new Font("Segoe UI", 10.2F);
            Name = "UC_ChamSocKH";
            Size = new Size(1252, 1079);
            Load += UC_ChamSocKH_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDsChamSoc).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
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
        private Button btnTimKH;
        private ComboBox cboLoaiKH;
        private TextBox txtTimKH;
        private Label label1;
        private Panel panel1;
        private Label lblNhac;
        private Label label2;
        private Panel panel10;
        private Button btnTim;
        private ComboBox cboTrangThai;
        private ComboBox cboLoai;
        private Panel panel4;
        private Label lblDaXuLy;
        private Label label9;
        private Panel panel3;
        private Label lblChuaLienHe;
        private Label label7;
        private Panel panel2;
        private Label lblSapHetHan;
        private Label label5;
        private DataGridView dgvDsChamSoc;
        private TextBox txtTimKiem;
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
        private ComboBox cboLoaiCS;
        private Label label12;
        private Button button2;
        private TextBox txtMaPhieu;
        private Label label11;
        private DateTimePicker dtpNgayLH;
        private Label label14;
        private TextBox txtGhiChu;
        private Button btnTaoLichNhac;
        private Panel panel6;
        private Button btnLuu;
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
        private DataGridView dataGridView2;
        private Button btnLamTrong;
        private DataGridViewTextBoxColumn colMaKhCS;
        private DataGridViewTextBoxColumn colTenKhCs;
        private DataGridViewTextBoxColumn colLoaiCs;
        private DataGridViewTextBoxColumn colNoiDungGhiCHu;
        private DataGridViewTextBoxColumn colNgayLienHe;
        private DataGridViewTextBoxColumn colNhanVien;
    }
}
