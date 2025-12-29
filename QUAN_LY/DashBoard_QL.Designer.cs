namespace HTTT.QUAN_LY
{
    partial class DashBoard_QL
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.btnBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHoaDonBan = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHoaDonNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKhoHang = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNhapHang = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMaGiamGia = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTaoMaGiamGia = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.menu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBanHang,
            this.btnHoaDon,
            this.btnKhoHang,
            this.btnKhachHang,
            this.btnNhanVien,
            this.btnNhapHang,
            this.btnDoanhThu,
            this.btnMaGiamGia,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.btnExit});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1537, 76);
            this.menu.TabIndex = 6;
            this.menu.Text = "menuStrip1";
            // 
            // btnBanHang
            // 
            this.btnBanHang.Checked = true;
            this.btnBanHang.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnBanHang.ForeColor = System.Drawing.Color.White;
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(129, 72);
            this.btnBanHang.Text = "BÁN HÀNG";
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHoaDonBan,
            this.btnHoaDonNhap});
            this.btnHoaDon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(117, 72);
            this.btnHoaDon.Text = "HÓA ĐƠN";
            // 
            // btnHoaDonBan
            // 
            this.btnHoaDonBan.Name = "btnHoaDonBan";
            this.btnHoaDonBan.Size = new System.Drawing.Size(310, 28);
            this.btnHoaDonBan.Text = "HÓA ĐƠN BÁN HÀNG";
            this.btnHoaDonBan.Click += new System.EventHandler(this.btnHoaDonBan_Click);
            // 
            // btnHoaDonNhap
            // 
            this.btnHoaDonNhap.Name = "btnHoaDonNhap";
            this.btnHoaDonNhap.Size = new System.Drawing.Size(310, 28);
            this.btnHoaDonNhap.Text = "HÓA ĐƠN NHẬP HÀNG";
            this.btnHoaDonNhap.Click += new System.EventHandler(this.btnHoaDonNhap_Click);
            // 
            // btnKhoHang
            // 
            this.btnKhoHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoHang.ForeColor = System.Drawing.Color.White;
            this.btnKhoHang.Name = "btnKhoHang";
            this.btnKhoHang.Size = new System.Drawing.Size(133, 72);
            this.btnKhoHang.Text = "KHO HÀNG";
            this.btnKhoHang.Click += new System.EventHandler(this.btnKhoHang_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(160, 72);
            this.btnKhachHang.Text = "KHÁCH HÀNG";
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(134, 72);
            this.btnNhanVien.Text = "NHÂN VIÊN";
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapHang.ForeColor = System.Drawing.Color.White;
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(142, 72);
            this.btnNhapHang.Text = "NHẬP HÀNG";
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(144, 72);
            this.btnDoanhThu.Text = "DOANH THU";
            this.btnDoanhThu.Click += new System.EventHandler(this.btnDoanhThu_Click);
            // 
            // btnMaGiamGia
            // 
            this.btnMaGiamGia.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTaoMaGiamGia});
            this.btnMaGiamGia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaGiamGia.ForeColor = System.Drawing.Color.White;
            this.btnMaGiamGia.Name = "btnMaGiamGia";
            this.btnMaGiamGia.Size = new System.Drawing.Size(158, 72);
            this.btnMaGiamGia.Text = "MÃ GIẢM GIÁ";
            // 
            // btnTaoMaGiamGia
            // 
            this.btnTaoMaGiamGia.Name = "btnTaoMaGiamGia";
            this.btnTaoMaGiamGia.Size = new System.Drawing.Size(276, 28);
            this.btnTaoMaGiamGia.Text = "TẠO MÃ GIẢM GIÁ";
            this.btnTaoMaGiamGia.Click += new System.EventHandler(this.btnTaoMaGiamGia_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 72);
            this.toolStripMenuItem1.Text = "TÀI KHOẢN";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.toolStripMenuItem2.Size = new System.Drawing.Size(53, 72);
            this.toolStripMenuItem2.Text = ".";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(84, 72);
            this.btnExit.Text = "ĐÓNG";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // DashBoard_QL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HTTT.Properties.Resources.hinhNen;
            this.ClientSize = new System.Drawing.Size(1537, 953);
            this.ControlBox = false;
            this.Controls.Add(this.menu);
            this.Name = "DashBoard_QL";
            this.Text = "DashBoard_QL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem btnMaGiamGia;
        private System.Windows.Forms.ToolStripMenuItem btnKhoHang;
        private System.Windows.Forms.ToolStripMenuItem btnKhachHang;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem btnBanHang;
        private System.Windows.Forms.ToolStripMenuItem btnHoaDon;
        private System.Windows.Forms.ToolStripMenuItem btnNhapHang;
        private System.Windows.Forms.ToolStripMenuItem btnHoaDonBan;
        private System.Windows.Forms.ToolStripMenuItem btnHoaDonNhap;
        private System.Windows.Forms.ToolStripMenuItem btnDoanhThu;
        private System.Windows.Forms.ToolStripMenuItem btnNhanVien;
        private System.Windows.Forms.ToolStripMenuItem btnTaoMaGiamGia;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}