using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace HTTT
{
    public partial class F_NhanVien : Form
    {
        public F_NhanVien()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                using (OracleConnection conn = new DatabaseConnection().GetConnection())
                {
                    string query = "SELECT MaNhanVien, TenNhanVien, SoDienThoai, Email, DiaChi " +
                                   "FROM ADMIN.NhanVien WHERE TrangThaiNhanVien = 1";

                    OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvEmployee.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtEmployeeID.Clear();
            txtEmployeeName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtEmployeeName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtEmployeeName.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên.");
                return;
            }

            try
            {
                using (OracleConnection conn = new DatabaseConnection().GetConnection())
                {
                    conn.Open();

                    // 1. Kiểm tra trùng MaNhanVien
                    if (!string.IsNullOrEmpty(txtEmployeeID.Text))
                    {
                        string checkIdQuery = "SELECT COUNT(*) FROM ADMIN.NhanVien WHERE MaNhanVien = :Ma";
                        using (OracleCommand checkIdCmd = new OracleCommand(checkIdQuery, conn))
                        {
                            checkIdCmd.Parameters.Add(new OracleParameter(":Ma", txtEmployeeID.Text));
                            int idExists = Convert.ToInt32(checkIdCmd.ExecuteScalar());
                            if (idExists > 0)
                            {
                                MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng chọn mã khác hoặc để trống.");
                                return;
                            }
                        }
                    }

                    // 2. Kiểm tra trùng số điện thoại
                    string checkPhoneQuery = "SELECT COUNT(*) FROM ADMIN.NhanVien WHERE SoDienThoai = :SDT";
                    using (OracleCommand checkPhoneCmd = new OracleCommand(checkPhoneQuery, conn))
                    {
                        checkPhoneCmd.Parameters.Add(new OracleParameter(":SDT", txtPhone.Text));
                        int phoneExists = Convert.ToInt32(checkPhoneCmd.ExecuteScalar());
                        if (phoneExists > 0)
                        {
                            MessageBox.Show("Số điện thoại đã tồn tại. Vui lòng nhập số khác.");
                            return;
                        }
                    }

                    // 3. Tạo MaNhanVien nếu để trống
                    if (string.IsNullOrEmpty(txtEmployeeID.Text))
                    {
                        string getMaxIdQuery = @"SELECT MAX(MaNhanVien) FROM ADMIN.NhanVien WHERE MaNhanVien LIKE 'NV%'";
                        using (OracleCommand getMaxIdCmd = new OracleCommand(getMaxIdQuery, conn))
                        {
                            object result = getMaxIdCmd.ExecuteScalar();
                            if (result == DBNull.Value)
                                txtEmployeeID.Text = "NV001";
                            else
                            {
                                string lastId = result.ToString(); // NV005
                                int num = int.Parse(lastId.Substring(2)) + 1;
                                txtEmployeeID.Text = "NV" + num.ToString("D3"); // NV006
                            }
                        }
                    }

                    string employeeId = txtEmployeeID.Text;

                    // 4. Thêm vào bảng NhanVien
                    string insertNhanVien = @"INSERT INTO ADMIN.NhanVien 
                (MaNhanVien, TenNhanVien, SoDienThoai, Email, DiaChi, TrangThaiNhanVien)
                VALUES (:Ma, :Ten, :SDT, :Email, :DiaChi, 1)";
                    using (OracleCommand cmd = new OracleCommand(insertNhanVien, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter(":Ma", employeeId));
                        cmd.Parameters.Add(new OracleParameter(":Ten", txtEmployeeName.Text));
                        cmd.Parameters.Add(new OracleParameter(":SDT", txtPhone.Text));
                        cmd.Parameters.Add(new OracleParameter(":Email", txtEmail.Text));
                        cmd.Parameters.Add(new OracleParameter(":DiaChi", txtAddress.Text));
                        cmd.ExecuteNonQuery();
                    }

                    // 5. Tạo user Oracle
                    string createUserSql = $"CREATE USER {employeeId} IDENTIFIED BY 1 " +
                                           "DEFAULT TABLESPACE users TEMPORARY TABLESPACE temp QUOTA UNLIMITED ON users";
                    using (OracleCommand createUserCmd = new OracleCommand(createUserSql, conn))
                    {
                        createUserCmd.ExecuteNonQuery();
                    }

                    // 6. Gán profile
                    string alterProfileSql = $"ALTER USER {employeeId} PROFILE MyPassword";
                    using (OracleCommand alterProfileCmd = new OracleCommand(alterProfileSql, conn))
                    {
                        alterProfileCmd.ExecuteNonQuery();
                    }

                    // 7. Gán role
                    string grantRoleSql = $"GRANT ROLE_NHANVIEN TO {employeeId}";
                    using (OracleCommand grantRoleCmd = new OracleCommand(grantRoleSql, conn))
                    {
                        grantRoleCmd.ExecuteNonQuery();
                    }

                    string grantLoginSql = $"GRANT CREATE SESSION TO {employeeId}";
                    using (OracleCommand grantLoginCmd = new OracleCommand(grantLoginSql, conn))
                    {
                        grantLoginCmd.ExecuteNonQuery();
                    }

                    // 8. Thêm vào bảng TaiKhoan
                    string insertTaiKhoanSql = @"INSERT INTO ADMIN.TaiKhoan (MaNhanVien, MatKhau, VaiTro) 
                                         VALUES (:Ma, :MatKhau, 2)"; // 2 = nhân viên
                    using (OracleCommand taiKhoanCmd = new OracleCommand(insertTaiKhoanSql, conn))
                    {
                        taiKhoanCmd.Parameters.Add(new OracleParameter(":Ma", employeeId));
                        taiKhoanCmd.Parameters.Add(new OracleParameter(":MatKhau", "1"));
                        taiKhoanCmd.ExecuteNonQuery();
                    }

                    conn.Close();
                    

                    LoadEmployees();
                    MessageBox.Show("✅ Thêm nhân viên, tạo user Oracle, gán profile và role thành công.");
                    ClearFields();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Lỗi Oracle khi thêm nhân viên: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }




        
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployee.Rows[e.RowIndex];
                txtEmployeeID.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtEmployeeName.Text = row.Cells["TenNhanVien"].Value.ToString();
                txtPhone.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtAddress.Text = row.Cells["DiaChi"].Value.ToString();
            }
        }

        private void dgvEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvEmployee_CellClick(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F_QLDangNhap loginHistory = new F_QLDangNhap();
            loginHistory.ShowDialog();
        }
    }
}
