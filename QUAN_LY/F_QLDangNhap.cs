using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace HTTT
{
    public partial class F_QLDangNhap : Form
    {
        public F_QLDangNhap()
        {
            InitializeComponent();
        }

        // ✅ Hàm tải lịch sử đăng nhập từ Oracle - ĐÃ SỬA LỖI CAST
        private void LoadLoginHistory()
        {
            try
            {
                using (OracleConnection conn = new DatabaseConnection().GetConnection())
                {
                    string query = @"
                        SELECT 
                            lsdn.MaNhanVien,
                            nv.TenNhanVien,
                            lsdn.ThoiGianDangNhap,
                            lsdn.ThoiGianDangXuat,
                            (CASE 
                                WHEN lsdn.ThoiGianDangXuat IS NOT NULL THEN 
                                    ROUND((lsdn.ThoiGianDangXuat - lsdn.ThoiGianDangNhap) * 24 * 60 * 60)
                                ELSE NULL
                            END) AS TongThoiGianGiay
                        FROM 
                            ADMIN.LichSuDangNhap lsdn
                        LEFT JOIN 
                            ADMIN.NhanVien nv ON lsdn.MaNhanVien = nv.MaNhanVien
                        ORDER BY
                            lsdn.ThoiGianDangNhap DESC";

                    OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Tính toán cột hiển thị "Tổng thời gian đăng nhập" - ĐÃ SỬA LỖI CAST
                    dt.Columns.Add("TongThoiGianDangNhap", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TongThoiGianGiay"] != DBNull.Value)
                        {
                            // Sửa lỗi cast: chuyển đổi an toàn sang double trước
                            double secondsValue;
                            if (double.TryParse(row["TongThoiGianGiay"].ToString(), out secondsValue))
                            {
                                int seconds = (int)Math.Round(secondsValue);
                                TimeSpan ts = TimeSpan.FromSeconds(seconds);
                                row["TongThoiGianDangNhap"] = ts.ToString(@"hh\:mm\:ss");
                            }
                            else
                            {
                                row["TongThoiGianDangNhap"] = "Lỗi tính toán";
                            }
                        }
                        else
                        {
                            row["TongThoiGianDangNhap"] = "Chưa đăng xuất";
                        }
                    }

                    dt.Columns.Remove("TongThoiGianGiay");
                    dgvLoginHistoy.DataSource = dt;

                    // Đặt tên cột cho đẹp (tuỳ chọn)
                    if (dgvLoginHistoy.Columns.Count > 0)
                    {
                        dgvLoginHistoy.Columns["MaNhanVien"].HeaderText = "Mã NV";
                        dgvLoginHistoy.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
                        dgvLoginHistoy.Columns["ThoiGianDangNhap"].HeaderText = "Thời Gian Đăng Nhập";
                        dgvLoginHistoy.Columns["ThoiGianDangXuat"].HeaderText = "Thời Gian Đăng Xuất";
                        dgvLoginHistoy.Columns["TongThoiGianDangNhap"].HeaderText = "Tổng Thời Gian";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử đăng nhập: " + ex.Message);
            }
        }

        // ✅ Hàm tải danh sách nhân viên đang hoạt động
        private void LoadEmployeesToComboBox()
        {
            try
            {
                using (OracleConnection conn = new DatabaseConnection().GetConnection())
                {
                    string query = "SELECT MaNhanVien, TenNhanVien FROM ADMIN.NhanVien WHERE TrangThaiNhanVien = 1";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    conn.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    Dictionary<string, string> employees = new Dictionary<string, string>();
                    while (reader.Read())
                    {
                        string ma = reader["MaNhanVien"].ToString();
                        string ten = reader["TenNhanVien"].ToString();
                        employees.Add(ma, ten);
                    }

                    cbEmployee.DataSource = new BindingSource(employees, null);
                    cbEmployee.DisplayMember = "Value";
                    cbEmployee.ValueMember = "Key";

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }
        }

        // ✅ Tính tổng thời gian đăng nhập trong ngày của nhân viên - ĐÃ SỬA LỖI CAST
        private void btCheck_Click(object sender, EventArgs e)
        {
            if (cbEmployee.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.");
                return;
            }

            string maNhanVien = ((KeyValuePair<string, string>)cbEmployee.SelectedItem).Key;
            DateTime selectedDate = dtpDate.Value.Date;

            try
            {
                using (OracleConnection conn = new DatabaseConnection().GetConnection())
                {
                    string query = @"
                        SELECT 
                            SUM(CASE 
                                WHEN ThoiGianDangXuat IS NOT NULL THEN 
                                    ROUND((ThoiGianDangXuat - ThoiGianDangNhap) * 24 * 60 * 60)
                                ELSE 0
                            END) AS TongThoiGianGiay
                        FROM 
                            ADMIN.LichSuDangNhap
                        WHERE 
                            MaNhanVien = :MaNhanVien
                            AND TRUNC(ThoiGianDangNhap) = :Ngay";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(new OracleParameter(":MaNhanVien", maNhanVien));
                    cmd.Parameters.Add(new OracleParameter(":Ngay", selectedDate));

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    conn.Close();

                    // Sửa lỗi cast: xử lý an toàn kiểu dữ liệu
                    if (result != DBNull.Value && result != null)
                    {
                        double totalSecondsValue;
                        if (double.TryParse(result.ToString(), out totalSecondsValue))
                        {
                            int totalSeconds = (int)Math.Round(totalSecondsValue);
                            TimeSpan ts = TimeSpan.FromSeconds(totalSeconds);
                            lbInform.Text = $"Nhân viên đã đăng nhập {ts.Hours} giờ {ts.Minutes} phút {ts.Seconds} giây trong ngày {selectedDate:dd/MM/yyyy}.";
                        }
                        else
                        {
                            lbInform.Text = $"Lỗi tính toán thời gian cho ngày {selectedDate:dd/MM/yyyy}.";
                        }
                    }
                    else
                    {
                        lbInform.Text = $"Nhân viên không có lượt đăng nhập nào trong ngày {selectedDate:dd/MM/yyyy}.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra thời gian đăng nhập: " + ex.Message);
            }
        }

        private void F_QLDangNhap_Load(object sender, EventArgs e)
        {
            LoadEmployeesToComboBox();
            LoadLoginHistory();
        }

        // ✅ Thêm nút làm mới dữ liệu (tuỳ chọn)
        private void btRefresh_Click(object sender, EventArgs e)
        {
            LoadLoginHistory();
        }
    }
}