using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace HTTT.QUAN_LY
{
    public partial class F_DoiMatKhau : Form
    {
        public F_DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string mkCu = txtMatKhauCu.Text.Trim();
            string mkMoi = txtMkMoi.Text.Trim();
            string mkXacNhan = txtXacNhanMkMoi.Text.Trim();

            if (string.IsNullOrEmpty(mkCu) || string.IsNullOrEmpty(mkMoi) || string.IsNullOrEmpty(mkXacNhan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (mkMoi != mkXacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OracleConnection conn = new DatabaseConnection().GetConnection())
                {
                    conn.Open();

                    // 1️⃣ Kiểm tra mật khẩu cũ trong bảng TaiKhoan
                    string queryCheck = "SELECT MatKhau FROM ADMIN.TaiKhoan WHERE MaNhanVien = :MaNV";
                    using (OracleCommand cmdCheck = new OracleCommand(queryCheck, conn))
                    {
                        cmdCheck.Parameters.Add(new OracleParameter(":MaNV", MaNhanVien.Ma));
                        object result = cmdCheck.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Không tìm thấy tài khoản!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string mkCuDB = result.ToString();
                        string mkCuHash = mkCu; //Hash.MD5Hash(mkCu);

                        if (mkCuDB != mkCuHash)
                        {
                            MessageBox.Show("Mật khẩu cũ không chính xác.", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // 2️⃣ Cập nhật mật khẩu mới trong bảng TaiKhoan
                    string queryUpdate = "UPDATE ADMIN.TaiKhoan SET MatKhau = :MatKhauMoi WHERE MaNhanVien = :MaNV";
                    using (OracleCommand cmdUpdate = new OracleCommand(queryUpdate, conn))
                    {
                        cmdUpdate.Parameters.Add(new OracleParameter(":MatKhauMoi", Hash.MD5Hash(mkMoi)));
                        cmdUpdate.Parameters.Add(new OracleParameter(":MaNV", MaNhanVien.Ma));
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // 3️⃣ Đổi mật khẩu thật trong Oracle (chỉ khi user tồn tại trong DB)
                    try
                    {
                        string sqlAlter = $"ALTER USER {MaNhanVien.Ma} IDENTIFIED BY \"{mkMoi}\"";
                        using (OracleCommand cmdAlter = new OracleCommand(sqlAlter, conn))
                        {
                            cmdAlter.ExecuteNonQuery();
                        }
                    }
                    catch (OracleException exAlter)
                    {
                        // Nếu user không tồn tại, chỉ cảnh báo chứ không dừng tiến trình
                        if (exAlter.Number == 1918) // ORA-01918: user does not exist
                        {
                            MessageBox.Show("Tài khoản Oracle chưa được tạo, chỉ đổi mật khẩu trong hệ thống.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            throw;
                        }
                    }

                    MessageBox.Show("✅ Đổi mật khẩu thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtMatKhauCu.Clear();
                    txtMkMoi.Clear();
                    txtXacNhanMkMoi.Clear();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Lỗi Oracle: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
