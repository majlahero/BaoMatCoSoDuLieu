namespace HHTPRO
{
    partial class DashBoard_NhanVien
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
            this.btnKhoHang = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKhachHang = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripMenuItem2,
            this.btnExit});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1330, 76);
            this.menu.TabIndex = 5;
            this.menu.Text = "menuStrip1";
            // 
            // btnBanHang
            // 
            this.btnBanHang.Checked = true;
            this.btnBanHang.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnBanHang.ForeColor = System.Drawing.Color.White;
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Padding = new System.Windows.Forms.Padding(5, 0, 40, 0);
            this.btnBanHang.Size = new System.Drawing.Size(164, 72);
            this.btnBanHang.Text = "BÁN HÀNG";
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(117, 72);
            this.btnHoaDon.Text = "HÓA ĐƠN";
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
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
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Padding = new System.Windows.Forms.Padding(485, 0, 0, 0);
            this.toolStripMenuItem2.Size = new System.Drawing.Size(533, 72);
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
            // DashBoard_NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HTTT.Properties.Resources.hinhNen;
            this.ClientSize = new System.Drawing.Size(1330, 953);
            this.ControlBox = false;
            this.Controls.Add(this.menu);
            this.Name = "DashBoard_NhanVien";
            this.Text = "DashBoard";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem btnBanHang;
        private System.Windows.Forms.ToolStripMenuItem btnHoaDon;
        private System.Windows.Forms.ToolStripMenuItem btnKhoHang;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem btnKhachHang;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}