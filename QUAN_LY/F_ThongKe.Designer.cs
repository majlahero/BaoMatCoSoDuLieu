namespace HTTT
{
    partial class F_ThongKe
    {
        private System.ComponentModel.IContainer components = null;

        // 📅 Bộ lọc thời gian
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnThongKe;

        // 📊 Hiển thị dữ liệu
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label lblTongSanPham;
        private System.Windows.Forms.DataGridView dgvThongKe;

        // 🧾 Giao diện
        private System.Windows.Forms.Label lblTitle;

        // Guna2 labels nếu bạn dùng Guna2
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFromDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblToDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.lblTongSanPham = new System.Windows.Forms.Label();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFromDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblToDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSoDonHang = new System.Windows.Forms.Label();
            this.chartDoanhThuThang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbNam = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnThongKeTheoNam = new Guna.UI2.WinForms.Guna2Button();
            this.btnXuatFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuThang)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(130, 80);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 22);
            this.dtpFromDate.TabIndex = 2;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(460, 80);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 22);
            this.dtpToDate.TabIndex = 4;
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.LawnGreen;
            this.btnThongKe.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(680, 75);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(90, 30);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(46, 120);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(197, 22);
            this.lblTongDoanhThu.TabIndex = 6;
            this.lblTongDoanhThu.Text = "Tổng doanh thu: 0 VNĐ";
            // 
            // lblTongSanPham
            // 
            this.lblTongSanPham.AutoSize = true;
            this.lblTongSanPham.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblTongSanPham.Location = new System.Drawing.Point(366, 120);
            this.lblTongSanPham.Name = "lblTongSanPham";
            this.lblTongSanPham.Size = new System.Drawing.Size(196, 22);
            this.lblTongSanPham.TabIndex = 7;
            this.lblTongSanPham.Text = "Tổng sản phẩm: 0 chiếc";
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(50, 160);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.Size = new System.Drawing.Size(596, 370);
            this.dgvThongKe.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(280, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(279, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO THỐNG KÊ";
            // 
            // lblFromDate
            // 
            this.lblFromDate.BackColor = System.Drawing.Color.Transparent;
            this.lblFromDate.Location = new System.Drawing.Point(50, 80);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(55, 18);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "Từ ngày:";
            // 
            // lblToDate
            // 
            this.lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToDate.Location = new System.Drawing.Point(370, 80);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(63, 18);
            this.lblToDate.TabIndex = 3;
            this.lblToDate.Text = "Đến ngày:";
            // 
            // lblSoDonHang
            // 
            this.lblSoDonHang.AutoSize = true;
            this.lblSoDonHang.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblSoDonHang.Location = new System.Drawing.Point(676, 120);
            this.lblSoDonHang.Name = "lblSoDonHang";
            this.lblSoDonHang.Size = new System.Drawing.Size(172, 22);
            this.lblSoDonHang.TabIndex = 9;
            this.lblSoDonHang.Text = "Số Đơn Hàng: 0 đơn";
            // 
            // chartDoanhThuThang
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThuThang.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDoanhThuThang.Legends.Add(legend1);
            this.chartDoanhThuThang.Location = new System.Drawing.Point(668, 160);
            this.chartDoanhThuThang.Name = "chartDoanhThuThang";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThuThang.Series.Add(series1);
            this.chartDoanhThuThang.Size = new System.Drawing.Size(629, 432);
            this.chartDoanhThuThang.TabIndex = 10;
            this.chartDoanhThuThang.Text = "chart1";
            // 
            // cbNam
            // 
            this.cbNam.BackColor = System.Drawing.Color.Transparent;
            this.cbNam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNam.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbNam.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbNam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbNam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbNam.ItemHeight = 30;
            this.cbNam.Location = new System.Drawing.Point(804, 69);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(140, 36);
            this.cbNam.TabIndex = 11;
            // 
            // btnThongKeTheoNam
            // 
            this.btnThongKeTheoNam.BackColor = System.Drawing.Color.LawnGreen;
            this.btnThongKeTheoNam.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKeTheoNam.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKeTheoNam.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongKeTheoNam.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongKeTheoNam.FillColor = System.Drawing.Color.LightGreen;
            this.btnThongKeTheoNam.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKeTheoNam.ForeColor = System.Drawing.Color.Black;
            this.btnThongKeTheoNam.Location = new System.Drawing.Point(990, 69);
            this.btnThongKeTheoNam.Name = "btnThongKeTheoNam";
            this.btnThongKeTheoNam.Size = new System.Drawing.Size(222, 36);
            this.btnThongKeTheoNam.TabIndex = 12;
            this.btnThongKeTheoNam.Text = "Thống kê theo năm";
            this.btnThongKeTheoNam.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.BackColor = System.Drawing.Color.LawnGreen;
            this.btnXuatFile.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatFile.Location = new System.Drawing.Point(460, 536);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(186, 40);
            this.btnXuatFile.TabIndex = 13;
            this.btnXuatFile.Text = "Xuất file excel";
            this.btnXuatFile.UseVisualStyleBackColor = false;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // F_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(1324, 604);
            this.Controls.Add(this.btnXuatFile);
            this.Controls.Add(this.btnThongKeTheoNam);
            this.Controls.Add(this.cbNam);
            this.Controls.Add(this.chartDoanhThuThang);
            this.Controls.Add(this.lblSoDonHang);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.lblTongDoanhThu);
            this.Controls.Add(this.lblTongSanPham);
            this.Controls.Add(this.dgvThongKe);
            this.Name = "F_ThongKe";
            this.Text = "Báo cáo thống kê";
            this.Load += new System.EventHandler(this.FormAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuThang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSoDonHang;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThuThang;
        private Guna.UI2.WinForms.Guna2ComboBox cbNam;
        private Guna.UI2.WinForms.Guna2Button btnThongKeTheoNam;
        private System.Windows.Forms.Button btnXuatFile;
    }
}
