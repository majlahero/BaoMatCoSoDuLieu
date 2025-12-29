using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTTT.QUAN_LY
{
    public partial class F_TaiKhoan : Form
    {
        public F_TaiKhoan()
        {
            InitializeComponent();
        }
        private void F_TaiKhoan_Load(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new DatabaseConnection().GetConnection())
                {
                    conn.Open();

                    string currentEmployeeID = MaNhanVien.Ma; 

                    string query = "SELECT TenNhanVien, SoDienThoai, Email, DiaChi FROM ADMIN.NhanVien WHERE MaNhanVien = :MaNhanVien";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter(":MaNhanVien", currentEmployeeID));

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtEmployeeName.Text = reader["TenNhanVien"].ToString();
                                txtPhone.Text = reader["SoDienThoai"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                txtAddress.Text = reader["DiaChi"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin tài khoản: " + ex.Message);
            }
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string currentEmployeeID = MaNhanVien.Ma; // Mã nhân viên đang đăng nhập

            if (string.IsNullOrEmpty(txtEmployeeName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OracleConnection conn = new DatabaseConnection().GetConnection())
                {
                    conn.Open();

                    string query = @"
                UPDATE ADMIN.NhanVien
                SET 
                    TenNhanVien = :TenNhanVien,
                    SoDienThoai = :SoDienThoai,
                    Email = :Email,
                    DiaChi = :DiaChi
                WHERE MaNhanVien = :MaNhanVien";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Thêm đầy đủ các tham số
                        cmd.Parameters.Add(new OracleParameter(":TenNhanVien", txtEmployeeName.Text.Trim()));
                        cmd.Parameters.Add(new OracleParameter(":SoDienThoai", string.IsNullOrEmpty(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text.Trim()));
                        cmd.Parameters.Add(new OracleParameter(":Email", string.IsNullOrEmpty(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim()));
                        cmd.Parameters.Add(new OracleParameter(":DiaChi", string.IsNullOrEmpty(txtAddress.Text) ? (object)DBNull.Value : txtAddress.Text.Trim()));
                        cmd.Parameters.Add(new OracleParameter(":MaNhanVien", currentEmployeeID)); // ⚠️ thêm dòng này

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("✅ Cập nhật thông tin nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("⚠️ Không tìm thấy mã nhân viên cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Lỗi Oracle: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            F_DoiMatKhau f = new F_DoiMatKhau();
            f.ShowDialog();
        }
    }
}
