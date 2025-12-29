using HTTT.FORM_IN;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace HTTT.FORM_IN
{
    public partial class F_DanhSachPhieuNhap : Form
    {
        public F_DanhSachPhieuNhap()
        {
            InitializeComponent();
            this.Load += F_DanhSachPhieuNhap_Load;
        }

        private void F_DanhSachPhieuNhap_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadData();
        }

        private void SetupDataGridView()
        {
            dataGridView.Columns.Clear();
            dataGridView.AutoGenerateColumns = false;
            dataGridView.AllowUserToAddRows = false;

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "STT",
                HeaderText = "STT",
                Width = 50,
                ReadOnly = true
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaNhapHang",
                HeaderText = "Mã Nhập Hàng",
                Width = 150,
                ReadOnly = true
            });

            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayNhap",
                HeaderText = "Ngày Nhập",
                Width = 200,
                ReadOnly = true
            });

        }

        private void LoadData()
        {
            dataGridView.Rows.Clear();

            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();

                    string query = "SELECT MaNhapHang, NgayNhap FROM ADMIN.PhieuNhapHang ORDER BY MaNhapHang DESC";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            int stt = 1;
                            while (reader.Read())
                            {
                                int maNhapHang = Convert.ToInt32(reader["MaNhapHang"]);
                                DateTime ngayNhap = Convert.ToDateTime(reader["NgayNhap"]);

                                dataGridView.Rows.Add(stt++, maNhapHang, ngayNhap.ToString("dd/MM/yyyy HH:mm"));
                            }
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1031) // ORA-01031: insufficient privileges
                {
                    MessageBox.Show("❌ Bạn không có quyền truy cập dữ liệu. Chương trình sẽ đóng.", "Lỗi quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit(); // đóng chương trình
                }
                else
                {
                    MessageBox.Show("Lỗi Oracle: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        
       
        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);

            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!");
                return;
            }

            dataGridView.Rows.Clear();

            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();
                    string query = "SELECT MaNhapHang, NgayNhap FROM ADMIN.PhieuNhapHang " +
                                   "WHERE NgayNhap BETWEEN :StartDate AND :EndDate " +
                                   "ORDER BY NgayNhap DESC";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":StartDate", OracleDbType.Date)).Value = startDate;
                        command.Parameters.Add(new OracleParameter(":EndDate", OracleDbType.Date)).Value = endDate;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            int stt = 1;
                            while (reader.Read())
                            {
                                int maNhapHang = Convert.ToInt32(reader["MaNhapHang"]);
                                DateTime ngayNhap = Convert.ToDateTime(reader["NgayNhap"]);

                                dataGridView.Rows.Add(stt++, maNhapHang, ngayNhap.ToString("dd/MM/yyyy HH:mm"));
                            }
                        }
                    }
                }

                MessageBox.Show($"Đã lọc {dataGridView.Rows.Count} phiếu nhập hàng từ {startDate:dd/MM/yyyy} đến {endDate:dd/MM/yyyy}");
            }
            catch (OracleException oraEx)
            {
                MessageBox.Show("Lỗi Oracle: " + oraEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message);
            }
        }
    }
}
