namespace GUI
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
            dgvCanhBaoKho = new DataGridView();
            Column1 = new DataGridViewCheckBoxColumn();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colHang = new DataGridViewTextBoxColumn();
            colTonKho = new DataGridViewTextBoxColumn();
            colMucCanhBao = new DataGridViewTextBoxColumn();
            colThaoTac = new DataGridViewButtonColumn();
            panel1 = new Panel();
            lblNguyHiem = new Label();
            label4 = new Label();
            panel2 = new Panel();
            lblBinhThuong = new Label();
            label6 = new Label();
            panel3 = new Panel();
            lblSapHet = new Label();
            label5 = new Label();
            label2 = new Label();
            label3 = new Label();
            cboLocCanhBao = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvCanhBaoKho).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(45, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(223, 35);
            label1.TabIndex = 2;
            label1.Text = "Cảnh báo tồn kho";
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.WhiteSmoke;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.Black;
            btnLamMoi.Location = new Point(48, 323);
            btnLamMoi.Margin = new Padding(4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(220, 58);
            btnLamMoi.TabIndex = 6;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvCanhBaoKho
            // 
            dgvCanhBaoKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCanhBaoKho.BackgroundColor = Color.White;
            dgvCanhBaoKho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCanhBaoKho.Columns.AddRange(new DataGridViewColumn[] { Column1, colMaSP, colTenSP, colHang, colTonKho, colMucCanhBao, colThaoTac });
            dgvCanhBaoKho.Location = new Point(45, 402);
            dgvCanhBaoKho.Margin = new Padding(4);
            dgvCanhBaoKho.Name = "dgvCanhBaoKho";
            dgvCanhBaoKho.RowHeadersWidth = 51;
            dgvCanhBaoKho.Size = new Size(1304, 480);
            dgvCanhBaoKho.TabIndex = 7;
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
            panel1.Controls.Add(lblNguyHiem);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(133, 99);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(317, 125);
            panel1.TabIndex = 8;
            // 
            // lblNguyHiem
            // 
            lblNguyHiem.AutoSize = true;
            lblNguyHiem.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblNguyHiem.ForeColor = Color.DarkRed;
            lblNguyHiem.Location = new Point(28, 69);
            lblNguyHiem.Margin = new Padding(4, 0, 4, 0);
            lblNguyHiem.Name = "lblNguyHiem";
            lblNguyHiem.Size = new Size(41, 31);
            lblNguyHiem.TabIndex = 15;
            lblNguyHiem.Text = "SP";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label4.ForeColor = Color.DarkRed;
            label4.Location = new Point(28, 16);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(182, 25);
            label4.TabIndex = 14;
            label4.Text = "Nguy hiểm (tồn ≤ 2)";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Honeydew;
            panel2.Controls.Add(lblBinhThuong);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(912, 99);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(317, 125);
            panel2.TabIndex = 9;
            // 
            // lblBinhThuong
            // 
            lblBinhThuong.AutoSize = true;
            lblBinhThuong.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblBinhThuong.ForeColor = Color.DarkGreen;
            lblBinhThuong.Location = new Point(21, 69);
            lblBinhThuong.Margin = new Padding(4, 0, 4, 0);
            lblBinhThuong.Name = "lblBinhThuong";
            lblBinhThuong.Size = new Size(41, 31);
            lblBinhThuong.TabIndex = 17;
            lblBinhThuong.Text = "SP";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label6.ForeColor = Color.DarkGreen;
            label6.Location = new Point(21, 16);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(199, 25);
            label6.TabIndex = 16;
            label6.Text = "Còn hàng bình thường";
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightYellow;
            panel3.Controls.Add(lblSapHet);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(527, 99);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(317, 125);
            panel3.TabIndex = 9;
            // 
            // lblSapHet
            // 
            lblSapHet.AutoSize = true;
            lblSapHet.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblSapHet.ForeColor = Color.DarkGoldenrod;
            lblSapHet.Location = new Point(25, 69);
            lblSapHet.Margin = new Padding(4, 0, 4, 0);
            lblSapHet.Name = "lblSapHet";
            lblSapHet.Size = new Size(41, 31);
            lblSapHet.TabIndex = 16;
            lblSapHet.Text = "SP";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label5.ForeColor = Color.DarkGoldenrod;
            label5.Location = new Point(25, 16);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(154, 25);
            label5.TabIndex = 15;
            label5.Text = "Sắp hết (tồn 3–4)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(511, 14);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(308, 28);
            label2.TabIndex = 11;
            label2.Text = "Kiểm tra lại thông tin và nhập kho";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(1043, 353);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(42, 28);
            label3.TabIndex = 12;
            label3.Text = "Lọc";
            // 
            // cboLocCanhBao
            // 
            cboLocCanhBao.Font = new Font("Segoe UI", 12F);
            cboLocCanhBao.FormattingEnabled = true;
            cboLocCanhBao.Location = new Point(1103, 349);
            cboLocCanhBao.Margin = new Padding(4);
            cboLocCanhBao.Name = "cboLocCanhBao";
            cboLocCanhBao.Size = new Size(188, 36);
            cboLocCanhBao.TabIndex = 13;
            cboLocCanhBao.Text = "Tất cả";
            // 
            // UC_CanhBaoKho
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(cboLocCanhBao);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dgvCanhBaoKho);
            Controls.Add(btnLamMoi);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "UC_CanhBaoKho";
            Size = new Size(1370, 886);
            Load += UC_CanhBaoKho_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCanhBaoKho).EndInit();
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
        private DataGridView dgvCanhBaoKho;
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
        private Label label2;
        private Label label3;
        private ComboBox cboLocCanhBao;
        private Label label4;
        private Label label5;
        private Label lblNguyHiem;
        private Label lblBinhThuong;
        private Label label6;
        private Label lblSapHet;
    }
}
