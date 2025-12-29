namespace CuaHangDiDong
{
    partial class Form_KhoHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.Label labelTenSP;
        private System.Windows.Forms.TextBox textBox_tenSP;
        private System.Windows.Forms.Label labelSoLuong;
        private System.Windows.Forms.Label labelDonGia;
        private System.Windows.Forms.TextBox textBox_donGia;
        private System.Windows.Forms.Button buttonThemSP;
        private System.Windows.Forms.Button buttonStopSP;
        private System.Windows.Forms.GroupBox groupBoxDisplay;
        private System.Windows.Forms.DataGridView dataGridViewKho;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.labelTenSP = new System.Windows.Forms.Label();
            this.textBox_tenSP = new System.Windows.Forms.TextBox();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.labelDonGia = new System.Windows.Forms.Label();
            this.textBox_donGia = new System.Windows.Forms.TextBox();
            this.buttonThemSP = new System.Windows.Forms.Button();
            this.buttonStopSP = new System.Windows.Forms.Button();
            this.groupBoxDisplay = new System.Windows.Forms.GroupBox();
            this.dataGridViewKho = new System.Windows.Forms.DataGridView();
            this.textBox_soLuong = new System.Windows.Forms.TextBox();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKho)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBoxInput.Controls.Add(this.textBox_soLuong);
            this.groupBoxInput.Controls.Add(this.labelTenSP);
            this.groupBoxInput.Controls.Add(this.textBox_tenSP);
            this.groupBoxInput.Controls.Add(this.labelSoLuong);
            this.groupBoxInput.Controls.Add(this.labelDonGia);
            this.groupBoxInput.Controls.Add(this.textBox_donGia);
            this.groupBoxInput.Controls.Add(this.buttonThemSP);
            this.groupBoxInput.Controls.Add(this.buttonStopSP);
            this.groupBoxInput.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.groupBoxInput.Location = new System.Drawing.Point(20, 20);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(860, 160);
            this.groupBoxInput.TabIndex = 1;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Quản lý sản phẩm";
            // 
            // labelTenSP
            // 
            this.labelTenSP.AutoSize = true;
            this.labelTenSP.Location = new System.Drawing.Point(20, 30);
            this.labelTenSP.Name = "labelTenSP";
            this.labelTenSP.Size = new System.Drawing.Size(118, 22);
            this.labelTenSP.TabIndex = 0;
            this.labelTenSP.Text = "Tên sản phẩm";
            // 
            // textBox_tenSP
            // 
            this.textBox_tenSP.Location = new System.Drawing.Point(144, 22);
            this.textBox_tenSP.Name = "textBox_tenSP";
            this.textBox_tenSP.Size = new System.Drawing.Size(200, 30);
            this.textBox_tenSP.TabIndex = 1;
            // 
            // labelSoLuong
            // 
            this.labelSoLuong.AutoSize = true;
            this.labelSoLuong.Location = new System.Drawing.Point(381, 72);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(174, 22);
            this.labelSoLuong.TabIndex = 2;
            this.labelSoLuong.Text = "Số lượng tồn hiện tại";
            // 
            // labelDonGia
            // 
            this.labelDonGia.AutoSize = true;
            this.labelDonGia.Location = new System.Drawing.Point(20, 68);
            this.labelDonGia.Name = "labelDonGia";
            this.labelDonGia.Size = new System.Drawing.Size(73, 22);
            this.labelDonGia.TabIndex = 3;
            this.labelDonGia.Text = "Đơn giá";
            // 
            // textBox_donGia
            // 
            this.textBox_donGia.Location = new System.Drawing.Point(144, 64);
            this.textBox_donGia.Name = "textBox_donGia";
            this.textBox_donGia.Size = new System.Drawing.Size(200, 30);
            this.textBox_donGia.TabIndex = 2;
            // 
            // buttonThemSP
            // 
            this.buttonThemSP.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonThemSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.buttonThemSP.ForeColor = System.Drawing.Color.White;
            this.buttonThemSP.Location = new System.Drawing.Point(24, 109);
            this.buttonThemSP.Name = "buttonThemSP";
            this.buttonThemSP.Size = new System.Drawing.Size(155, 45);
            this.buttonThemSP.TabIndex = 3;
            this.buttonThemSP.Text = "Tạo mới";
            this.buttonThemSP.UseVisualStyleBackColor = false;
            this.buttonThemSP.Click += new System.EventHandler(this.ButtonThemSP_Click);
            // 
            // buttonStopSP
            // 
            this.buttonStopSP.BackColor = System.Drawing.Color.Red;
            this.buttonStopSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.buttonStopSP.ForeColor = System.Drawing.Color.White;
            this.buttonStopSP.Location = new System.Drawing.Point(198, 109);
            this.buttonStopSP.Name = "buttonStopSP";
            this.buttonStopSP.Size = new System.Drawing.Size(194, 45);
            this.buttonStopSP.TabIndex = 4;
            this.buttonStopSP.Text = "Ngừng kinh doanh";
            this.buttonStopSP.UseVisualStyleBackColor = false;
            this.buttonStopSP.Click += new System.EventHandler(this.ButtonStopSP_Click);
            // 
            // groupBoxDisplay
            // 
            this.groupBoxDisplay.Controls.Add(this.dataGridViewKho);
            this.groupBoxDisplay.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.groupBoxDisplay.Location = new System.Drawing.Point(20, 200);
            this.groupBoxDisplay.Name = "groupBoxDisplay";
            this.groupBoxDisplay.Size = new System.Drawing.Size(860, 360);
            this.groupBoxDisplay.TabIndex = 0;
            this.groupBoxDisplay.TabStop = false;
            this.groupBoxDisplay.Text = "Danh sách sản phẩm trong kho";
            // 
            // dataGridViewKho
            // 
            this.dataGridViewKho.AllowUserToAddRows = false;
            this.dataGridViewKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewKho.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewKho.ColumnHeadersHeight = 29;
            this.dataGridViewKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewKho.Location = new System.Drawing.Point(3, 26);
            this.dataGridViewKho.Name = "dataGridViewKho";
            this.dataGridViewKho.ReadOnly = true;
            this.dataGridViewKho.RowHeadersWidth = 51;
            this.dataGridViewKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewKho.Size = new System.Drawing.Size(854, 331);
            this.dataGridViewKho.TabIndex = 0;
            // 
            // textBox_soLuong
            // 
            this.textBox_soLuong.Location = new System.Drawing.Point(561, 65);
            this.textBox_soLuong.Name = "textBox_soLuong";
            this.textBox_soLuong.Size = new System.Drawing.Size(200, 30);
            this.textBox_soLuong.TabIndex = 5;
            // 
            // Form_KhoHang
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.groupBoxDisplay);
            this.Controls.Add(this.groupBoxInput);
            this.Name = "Form_KhoHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KHO HÀNG";
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKho)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TextBox textBox_soLuong;
    }
}
