using System.Windows.Forms;

namespace HTTT
{
    partial class F_NhapHang
    {
        private System.ComponentModel.IContainer components = null;

        // input controls
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.Label labelNgayDat;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ngayDat;
        private System.Windows.Forms.Label labelNCC;
        private System.Windows.Forms.Label labelTenHang;
        private System.Windows.Forms.ComboBox comboBox_tenHang;
        private System.Windows.Forms.Label labelSoLuong;
        private System.Windows.Forms.TextBox textBox_soLuong;
        private System.Windows.Forms.Label labelDonGia;
        private System.Windows.Forms.TextBox textBox_donGia;
        private System.Windows.Forms.Label labelThanhTien;
        private System.Windows.Forms.TextBox textBox_thanhTien;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonVerify;

        // display
        private System.Windows.Forms.GroupBox groupBoxDisplay;
        private System.Windows.Forms.DataGridView dataGridViewNhapHang;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.labelNgayDat = new System.Windows.Forms.Label();
            this.dateTimePicker_ngayDat = new System.Windows.Forms.DateTimePicker();
            this.labelNCC = new System.Windows.Forms.Label();
            this.labelTenHang = new System.Windows.Forms.Label();
            this.comboBox_tenHang = new System.Windows.Forms.ComboBox();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.textBox_soLuong = new System.Windows.Forms.TextBox();
            this.labelDonGia = new System.Windows.Forms.Label();
            this.textBox_donGia = new System.Windows.Forms.TextBox();
            this.labelThanhTien = new System.Windows.Forms.Label();
            this.textBox_thanhTien = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonVerify = new System.Windows.Forms.Button();
            this.groupBoxDisplay = new System.Windows.Forms.GroupBox();
            this.dataGridViewNhapHang = new System.Windows.Forms.DataGridView();
            this.comboBox_NhaCungCap = new System.Windows.Forms.ComboBox();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNhapHang)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBoxInput.Controls.Add(this.comboBox_NhaCungCap);
            this.groupBoxInput.Controls.Add(this.labelNgayDat);
            this.groupBoxInput.Controls.Add(this.dateTimePicker_ngayDat);
            this.groupBoxInput.Controls.Add(this.labelNCC);
            this.groupBoxInput.Controls.Add(this.labelTenHang);
            this.groupBoxInput.Controls.Add(this.comboBox_tenHang);
            this.groupBoxInput.Controls.Add(this.labelSoLuong);
            this.groupBoxInput.Controls.Add(this.textBox_soLuong);
            this.groupBoxInput.Controls.Add(this.labelDonGia);
            this.groupBoxInput.Controls.Add(this.textBox_donGia);
            this.groupBoxInput.Controls.Add(this.labelThanhTien);
            this.groupBoxInput.Controls.Add(this.textBox_thanhTien);
            this.groupBoxInput.Controls.Add(this.buttonSubmit);
            this.groupBoxInput.Controls.Add(this.buttonVerify);
            this.groupBoxInput.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.groupBoxInput.Location = new System.Drawing.Point(20, 20);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(860, 180);
            this.groupBoxInput.TabIndex = 0;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Thông tin nhập hàng";
            // 
            // labelNgayDat
            // 
            this.labelNgayDat.Location = new System.Drawing.Point(20, 30);
            this.labelNgayDat.Name = "labelNgayDat";
            this.labelNgayDat.Size = new System.Drawing.Size(110, 20);
            this.labelNgayDat.TabIndex = 2;
            this.labelNgayDat.Text = "Ngày nhập hàng";
            // 
            // dateTimePicker_ngayDat
            // 
            this.dateTimePicker_ngayDat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_ngayDat.Location = new System.Drawing.Point(140, 27);
            this.dateTimePicker_ngayDat.Name = "dateTimePicker_ngayDat";
            this.dateTimePicker_ngayDat.Size = new System.Drawing.Size(120, 30);
            this.dateTimePicker_ngayDat.TabIndex = 3;
            // 
            // labelNCC
            // 
            this.labelNCC.Location = new System.Drawing.Point(20, 70);
            this.labelNCC.Name = "labelNCC";
            this.labelNCC.Size = new System.Drawing.Size(110, 27);
            this.labelNCC.TabIndex = 4;
            this.labelNCC.Text = "Nhà cung cấp";
            // 
            // labelTenHang
            // 
            this.labelTenHang.Location = new System.Drawing.Point(20, 113);
            this.labelTenHang.Name = "labelTenHang";
            this.labelTenHang.Size = new System.Drawing.Size(114, 20);
            this.labelTenHang.TabIndex = 6;
            this.labelTenHang.Text = "Tên mặt hàng";
            // 
            // comboBox_tenHang
            // 
            this.comboBox_tenHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tenHang.Location = new System.Drawing.Point(140, 110);
            this.comboBox_tenHang.Name = "comboBox_tenHang";
            this.comboBox_tenHang.Size = new System.Drawing.Size(335, 30);
            this.comboBox_tenHang.TabIndex = 7;
            // 
            // labelSoLuong
            // 
            this.labelSoLuong.Location = new System.Drawing.Point(548, 70);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(88, 20);
            this.labelSoLuong.TabIndex = 8;
            this.labelSoLuong.Text = "Số lượng";
            // 
            // textBox_soLuong
            // 
            this.textBox_soLuong.Location = new System.Drawing.Point(658, 60);
            this.textBox_soLuong.Name = "textBox_soLuong";
            this.textBox_soLuong.Size = new System.Drawing.Size(100, 30);
            this.textBox_soLuong.TabIndex = 9;
            this.textBox_soLuong.TextChanged += new System.EventHandler(this.CalcThanhTien);
            // 
            // labelDonGia
            // 
            this.labelDonGia.Location = new System.Drawing.Point(548, 113);
            this.labelDonGia.Name = "labelDonGia";
            this.labelDonGia.Size = new System.Drawing.Size(80, 27);
            this.labelDonGia.TabIndex = 10;
            this.labelDonGia.Text = "Đơn giá";
            // 
            // textBox_donGia
            // 
            this.textBox_donGia.Location = new System.Drawing.Point(658, 103);
            this.textBox_donGia.Name = "textBox_donGia";
            this.textBox_donGia.Size = new System.Drawing.Size(100, 30);
            this.textBox_donGia.TabIndex = 11;
            this.textBox_donGia.TextChanged += new System.EventHandler(this.CalcThanhTien);
            // 
            // labelThanhTien
            // 
            this.labelThanhTien.Location = new System.Drawing.Point(20, 150);
            this.labelThanhTien.Name = "labelThanhTien";
            this.labelThanhTien.Size = new System.Drawing.Size(110, 20);
            this.labelThanhTien.TabIndex = 12;
            this.labelThanhTien.Text = "Thành tiền";
            // 
            // textBox_thanhTien
            // 
            this.textBox_thanhTien.Location = new System.Drawing.Point(140, 147);
            this.textBox_thanhTien.Name = "textBox_thanhTien";
            this.textBox_thanhTien.ReadOnly = true;
            this.textBox_thanhTien.Size = new System.Drawing.Size(249, 30);
            this.textBox_thanhTien.TabIndex = 13;
            this.textBox_thanhTien.Text = "0";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.buttonSubmit.Location = new System.Drawing.Point(425, 146);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(146, 30);
            this.buttonSubmit.TabIndex = 14;
            this.buttonSubmit.Text = "Đồng ý";
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonVerify
            // 
            this.buttonVerify.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.buttonVerify.Location = new System.Drawing.Point(617, 146);
            this.buttonVerify.Name = "buttonVerify";
            this.buttonVerify.Size = new System.Drawing.Size(141, 30);
            this.buttonVerify.TabIndex = 15;
            this.buttonVerify.Text = "Xác nhận về";
            this.buttonVerify.Click += new System.EventHandler(this.buttonVerify_Click);
            // 
            // groupBoxDisplay
            // 
            this.groupBoxDisplay.Controls.Add(this.dataGridViewNhapHang);
            this.groupBoxDisplay.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.groupBoxDisplay.Location = new System.Drawing.Point(20, 220);
            this.groupBoxDisplay.Name = "groupBoxDisplay";
            this.groupBoxDisplay.Size = new System.Drawing.Size(860, 350);
            this.groupBoxDisplay.TabIndex = 1;
            this.groupBoxDisplay.TabStop = false;
            this.groupBoxDisplay.Text = "Danh sách nhập hàng";
            // 
            // dataGridViewNhapHang
            // 
            this.dataGridViewNhapHang.AllowUserToAddRows = false;
            this.dataGridViewNhapHang.AllowUserToDeleteRows = false;
            this.dataGridViewNhapHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewNhapHang.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewNhapHang.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewNhapHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNhapHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewNhapHang.Location = new System.Drawing.Point(3, 26);
            this.dataGridViewNhapHang.Name = "dataGridViewNhapHang";
            this.dataGridViewNhapHang.ReadOnly = true;
            this.dataGridViewNhapHang.RowHeadersWidth = 51;
            this.dataGridViewNhapHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewNhapHang.Size = new System.Drawing.Size(854, 321);
            this.dataGridViewNhapHang.TabIndex = 0;
            // 
            // comboBox_NhaCungCap
            // 
            this.comboBox_NhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_NhaCungCap.Items.AddRange(new object[] {
            "FPT",
            "24hStore",
            "Siêu Thị Điện Máy Chợ Lớn",
            "2T Mobile",
            "Clickbuy"});
            this.comboBox_NhaCungCap.Location = new System.Drawing.Point(140, 70);
            this.comboBox_NhaCungCap.Name = "comboBox_NhaCungCap";
            this.comboBox_NhaCungCap.Size = new System.Drawing.Size(335, 30);
            this.comboBox_NhaCungCap.TabIndex = 16;
            // 
            // F_NhapHang
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(900, 667);
            this.Controls.Add(this.groupBoxInput);
            this.Controls.Add(this.groupBoxDisplay);
            this.Name = "F_NhapHang";
            this.Text = "QUẢN LÝ NHẬP HÀNG";
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNhapHang)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private ComboBox comboBox_NhaCungCap;
    }
}
