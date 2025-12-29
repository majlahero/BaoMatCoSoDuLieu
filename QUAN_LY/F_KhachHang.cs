using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace HTTT
{
    public partial class F_KhachHang : Form
    {
        public F_KhachHang()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                using (OracleConnection conn = new DatabaseConnection().GetConnection())
                {
                    string query = "SELECT * FROM ADMIN.KhachHang";
                    OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvCustomer.DataSource = dt;
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Lỗi Oracle: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new DatabaseConnection().GetConnection())
            {
                string query = @"INSERT INTO ADMIN.KhachHang (TenKhachHang, SoDienThoai, DiaChi, Email)
                                 VALUES (:TenKhachHang, :SoDienThoai, :DiaChi, :Email)";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter(":TenKhachHang", txtCustomerName.Text));
                    cmd.Parameters.Add(new OracleParameter(":SoDienThoai", txtPhone.Text));
                    cmd.Parameters.Add(new OracleParameter(":DiaChi", txtAddress.Text));
                    cmd.Parameters.Add(new OracleParameter(":Email", txtEmail.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                LoadCustomers();
                MessageBox.Show("✅ Thêm khách hàng thành công!");
                ClearFields();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!");
                return;
            }

            using (OracleConnection conn = new DatabaseConnection().GetConnection())
            {
                string query = @"UPDATE ADMIN.KhachHang
                                 SET TenKhachHang = :TenKhachHang,
                                     SoDienThoai = :SoDienThoai,
                                     DiaChi = :DiaChi,
                                     Email = :Email
                                 WHERE MaKhachHang = :MaKhachHang";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter(":TenKhachHang", txtCustomerName.Text));
                    cmd.Parameters.Add(new OracleParameter(":SoDienThoai", txtPhone.Text));
                    cmd.Parameters.Add(new OracleParameter(":DiaChi", txtAddress.Text));
                    cmd.Parameters.Add(new OracleParameter(":Email", txtEmail.Text));
                    cmd.Parameters.Add(new OracleParameter(":MaKhachHang", txtCustomerID.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                LoadCustomers();
                MessageBox.Show("✅ Cập nhật khách hàng thành công!");
                ClearFields();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!");
                return;
            }

            using (OracleConnection conn = new DatabaseConnection().GetConnection())
            {
                string query = "DELETE FROM ADMIN.KhachHang WHERE MaKhachHang = :MaKhachHang";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter(":MaKhachHang", txtCustomerID.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                LoadCustomers();
                MessageBox.Show("🗑️ Xóa khách hàng thành công!");
                ClearFields();
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];
                txtCustomerID.Text = row.Cells["MaKhachHang"].Value.ToString();
                txtCustomerName.Text = row.Cells["TenKhachHang"].Value.ToString();
                txtPhone.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtAddress.Text = row.Cells["DiaChi"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            }
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCustomer_CellClick(sender, e);
        }

        private void ClearFields()
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
        }
    }
}
