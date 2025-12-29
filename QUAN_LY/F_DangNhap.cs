    using System;
    using System.Windows.Forms;
    using HHTPRO;
    using Oracle.ManagedDataAccess.Client;

    namespace HTTT.QUAN_LY
    {
        public partial class F_DangNhap : Form
        {
            public F_DangNhap()
            {
                InitializeComponent();
                txtMatKhau.PasswordChar = '*';
            }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtTenDangnhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string userConnStr = $"User Id={maNhanVien};Password={matKhau};Data Source=localhost:1521/ORCLPDB;";

            DatabaseConnection.SetConnectionString(userConnStr);
            try
            {
                using (var userConn = new OracleConnection(userConnStr))
                {
                    userConn.Open(); 

                    MaNhanVien.Ma = maNhanVien;
                    MaNhanVien.Connection = userConn;

                    string mainConnStr = "User Id=admin;Password=admin;Data Source=localhost:1521/ORCLPDB;";    
                    using (var connAdmin = new OracleConnection(mainConnStr))
                    {
                        connAdmin.Open();

                        string query = "SELECT VaiTro FROM ADMIN.TaiKhoan WHERE MaNhanVien = :ma";
                        using (var cmd = new OracleCommand(query, connAdmin))
                        {
                            cmd.Parameters.Add(":ma", maNhanVien);
                            var vaiTroObj = cmd.ExecuteScalar();

                            if (vaiTroObj == null)
                            {
                                MessageBox.Show("Tài khoản Oracle hợp lệ nhưng chưa được khai báo trong hệ thống ứng dụng!",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            bool isQuanLy = Convert.ToInt32(vaiTroObj) == 1;

                            GhiLichSuDangNhap(maNhanVien);

                            if (isQuanLy)
                            {
                                DashBoard_QL menuQL = new DashBoard_QL();
                                menuQL.Show();
                            }
                            else
                            {
                                DashBoard_QL menuNV = new DashBoard_QL();
                                menuNV.Show();
                            }

                            this.Hide();
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                // ⚠️ Bắt các lỗi Oracle phổ biến
                switch (ex.Number)
                {
                    case 1017: // ORA-01017: invalid username/password
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Đăng nhập thất bại",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case 28000: // ORA-28000: account is locked
                        MessageBox.Show("Tài khoản của bạn đã bị khóa do nhập sai quá số lần cho phép.\nVui lòng liên hệ quản trị viên để mở khóa.",
                            "Tài khoản bị khóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 28001: // ORA-28001: password expired
                        MessageBox.Show("Mật khẩu đã hết hạn. Vui lòng đổi mật khẩu để tiếp tục.",
                            "Mật khẩu hết hạn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case 28002: // ORA-28002: password will expire soon
                        MessageBox.Show("Mật khẩu của bạn sắp hết hạn. Hãy đổi mật khẩu sớm!",
                            "Cảnh báo mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    default:
                        MessageBox.Show($"Lỗi Oracle (Mã {ex.Number}): {ex.Message}", "Lỗi kết nối Oracle",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GhiLichSuDangNhap(string maNhanVien)
            {
                try
                {
                    var db = new DatabaseConnection();
                    using (var conn = db.GetConnection())
                    {
                        conn.Open();
                    string sql = "INSERT INTO ADMIN.LichSuDangNhap (MaNhanVien, ThoiGianDangNhap) VALUES (:ma, SYSDATE)";
                    using (var cmd = new OracleCommand(sql, conn))
                        {
                            cmd.Parameters.Add(":ma", maNhanVien);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể ghi lịch sử đăng nhập: " + ex.Message);
                }
            }
        }

        public static class MaNhanVien
        {
            public static string Ma { get; set; }
            public static OracleConnection Connection { get; set; }
        }
    }
