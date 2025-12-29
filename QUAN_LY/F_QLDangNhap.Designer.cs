namespace HTTT
{
    partial class F_QLDangNhap
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
            this.dgvLoginHistoy = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbEmployee = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lbInform = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btCheck = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginHistoy)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLoginHistoy
            // 
            this.dgvLoginHistoy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoginHistoy.Location = new System.Drawing.Point(27, 190);
            this.dgvLoginHistoy.Name = "dgvLoginHistoy";
            this.dgvLoginHistoy.RowHeadersWidth = 51;
            this.dgvLoginHistoy.Size = new System.Drawing.Size(1018, 477);
            this.dgvLoginHistoy.TabIndex = 28;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(303, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(450, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LỊCH SỬ ĐĂNG NHẬP NHÂN VIÊN";
            // 
            // cbEmployee
            // 
            this.cbEmployee.BackColor = System.Drawing.Color.Transparent;
            this.cbEmployee.BorderRadius = 15;
            this.cbEmployee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmployee.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbEmployee.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbEmployee.ItemHeight = 30;
            this.cbEmployee.Location = new System.Drawing.Point(342, 83);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(275, 36);
            this.cbEmployee.TabIndex = 31;
            // 
            // dtpDate
            // 
            this.dtpDate.BorderRadius = 15;
            this.dtpDate.Checked = true;
            this.dtpDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(196)))), ((int)(((byte)(73)))));
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDate.Location = new System.Drawing.Point(27, 80);
            this.dtpDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(240, 36);
            this.dtpDate.TabIndex = 32;
            this.dtpDate.Value = new System.DateTime(2025, 4, 21, 23, 11, 29, 640);
            // 
            // lbInform
            // 
            this.lbInform.BackColor = System.Drawing.Color.Transparent;
            this.lbInform.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInform.Location = new System.Drawing.Point(27, 140);
            this.lbInform.Name = "lbInform";
            this.lbInform.Size = new System.Drawing.Size(263, 25);
            this.lbInform.TabIndex = 33;
            this.lbInform.Text = "Nhân viên đã hoạt động 8 tiếng";
            // 
            // btCheck
            // 
            this.btCheck.BorderRadius = 10;
            this.btCheck.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btCheck.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btCheck.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btCheck.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btCheck.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(227)))), ((int)(((byte)(206)))));
            this.btCheck.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btCheck.ForeColor = System.Drawing.Color.White;
            this.btCheck.Location = new System.Drawing.Point(643, 83);
            this.btCheck.Name = "btCheck";
            this.btCheck.Size = new System.Drawing.Size(151, 33);
            this.btCheck.TabIndex = 34;
            this.btCheck.Text = "Check";
            this.btCheck.Click += new System.EventHandler(this.btCheck_Click);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.lblTitle);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(76)))), ((int)(((byte)(173)))));
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(76)))), ((int)(((byte)(173)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(67)))), ((int)(((byte)(147)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.SystemColors.Window;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(1075, 64);
            this.guna2CustomGradientPanel1.TabIndex = 35;
            // 
            // F_QLDangNhap
            // 
            this.AcceptButton = this.btCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1075, 679);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.btCheck);
            this.Controls.Add(this.lbInform);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cbEmployee);
            this.Controls.Add(this.dgvLoginHistoy);
            this.Name = "F_QLDangNhap";
            this.Text = "LoginHistory";
            this.Load += new System.EventHandler(this.F_QLDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginHistoy)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoginHistoy;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ComboBox cbEmployee;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbInform;
        private Guna.UI2.WinForms.Guna2Button btCheck;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
    }
}