using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace HTTT.QUAN_LY
{
    public partial class F_DanhSachHoaDon : Form
    {
        public F_DanhSachHoaDon()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("STT", "STT");
            dataGridView.Columns["STT"].Width = 50;
            dataGridView.Columns["STT"].ReadOnly = true;

            dataGridView.Columns.Add("MaHoaDon", "Mã Hóa Đơn");
            dataGridView.Columns["MaHoaDon"].Width = 150;
            dataGridView.Columns["MaHoaDon"].ReadOnly = true;

            dataGridView.Columns.Add("ThoiGian", "Thời Gian");
            dataGridView.Columns["ThoiGian"].Width = 200;
            dataGridView.Columns["ThoiGian"].ReadOnly = true;

        }

        private void LoadData()
        {
            dataGridView.Rows.Clear();
            int stt = 1;

            using (var connection = new DatabaseConnection().GetConnection())
            {
                connection.Open();
                string query = "SELECT MaDonHang, NgayDatHang FROM ADMIN.DonHang";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int maDonHang = Convert.ToInt32(reader["MaDonHang"]);
                            DateTime ngayDatHang = Convert.ToDateTime(reader["NgayDatHang"]);

                            dataGridView.Rows.Add(stt++, maDonHang, ngayDatHang);
                        }
                    }
                }
            }
        }

       
        private void F_DanhSachHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
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
                    string query = "SELECT MaDonHang, NgayDatHang FROM ADMIN.DonHang " +
                                   "WHERE NgayDatHang BETWEEN :StartDate AND :EndDate " +
                                   "ORDER BY NgayDatHang";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":StartDate", OracleDbType.Date)).Value = startDate;
                        command.Parameters.Add(new OracleParameter(":EndDate", OracleDbType.Date)).Value = endDate;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int maDonHang = Convert.ToInt32(reader["MaDonHang"]);
                                DateTime ngayDatHang = Convert.ToDateTime(reader["NgayDatHang"]);

                                dataGridView.Rows.Add(dataGridView.Rows.Count + 1, maDonHang, ngayDatHang);
                            }
                        }
                    }
                }

                MessageBox.Show($"Đã lọc {dataGridView.Rows.Count} đơn hàng từ {startDate:dd/MM/yyyy} đến {endDate:dd/MM/yyyy}");
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
