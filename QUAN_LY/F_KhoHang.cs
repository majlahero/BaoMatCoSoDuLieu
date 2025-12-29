using HTTT;
using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace CuaHangDiDong
{
    public partial class Form_KhoHang : Form
    {
        private DataTable khoHangTable;
        private decimal selectedMaSP = -1;

        public Form_KhoHang()
        {
            InitializeComponent();
            InitKhoHangTable();

            // Kiểm tra quyền truy cập bảng SanPham
            if (!CheckUserAccess())
            {
                MessageBox.Show("❌ Bạn không có quyền truy cập dữ liệu. Chương trình sẽ đóng.",
                    "Lỗi quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            LoadProductsFromDatabase();
            dataGridViewKho.SelectionChanged += DataGridViewKho_SelectionChanged;
        }

        private void InitKhoHangTable()
        {
            khoHangTable = new DataTable();
            khoHangTable.Columns.Add("Mã SP", typeof(decimal));
            khoHangTable.Columns.Add("Tên SP");
            khoHangTable.Columns.Add("Số lượng", typeof(int));
            khoHangTable.Columns.Add("Đơn giá", typeof(decimal));
            khoHangTable.Columns.Add("Trạng thái");
            dataGridViewKho.DataSource = khoHangTable;
        }

        private bool CheckUserAccess()
        {
            try
            {
                using (var conn = new DatabaseConnection().GetConnection())
                {
                    conn.Open();
                    using (var cmd = new OracleCommand("SELECT 1 FROM ADMIN.SanPham WHERE ROWNUM = 1", conn))
                    {
                        cmd.ExecuteScalar();
                        return true;
                    }
                }
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1031)
                    return false;
                else
                    throw;
            }
        }
        

        private void LoadProductsFromDatabase()
        {
            try
            {
                var dt = new DataTable();
                using (OracleConnection conn = new DatabaseConnection().GetConnection())
                {
                    conn.Open();
                    using (OracleDataAdapter da = new OracleDataAdapter(
                        "SELECT MaSanPham, TenSanPham, SoLuong, Gia, TrangThai FROM ADMIN.SanPham", conn))
                    {
                        da.Fill(dt);
                    }
                }

                khoHangTable.Clear();
                foreach (DataRow r in dt.Rows)
                {
                    khoHangTable.Rows.Add(
                        Convert.ToDecimal(r["MaSanPham"]),
                        r["TenSanPham"].ToString(),
                        Convert.ToInt32(r["SoLuong"]),
                        Convert.ToDecimal(r["Gia"]),
                        r["TrangThai"].ToString()
                    );
                }

                selectedMaSP = -1;
                if (dataGridViewKho.Rows.Count > 0)
                    dataGridViewKho.ClearSelection();
            }
            catch (OracleException ex) when (ex.Number == 1031)
            {
                MessageBox.Show("❌ Bạn không có quyền truy cập dữ liệu. Chương trình sẽ đóng.",
                    "Lỗi quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void DataGridViewKho_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewKho.SelectedRows.Count == 0)
            {
                selectedMaSP = -1;
                return;
            }

            var row = dataGridViewKho.SelectedRows[0];
            selectedMaSP = Convert.ToDecimal(row.Cells["Mã SP"].Value);
            textBox_tenSP.Text = row.Cells["Tên SP"].Value.ToString();
            textBox_donGia.Text = row.Cells["Đơn giá"].Value.ToString();
            textBox_soLuong.Text = row.Cells["Số lượng"].Value.ToString();
        }

        private void ButtonThemSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_tenSP.Text) ||
                !decimal.TryParse(textBox_donGia.Text, out decimal gia) ||
                !int.TryParse(textBox_soLuong.Text, out int soLuong))
            {
                MessageBox.Show("Nhập thiếu hoặc sai định dạng.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OracleConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();

                bool exists;
                using (OracleCommand chk = new OracleCommand(
                    "SELECT COUNT(*) FROM ADMIN.SanPham WHERE TenSanPham = :ten", conn))
                {
                    chk.Parameters.Add(":ten", OracleDbType.NVarchar2).Value = textBox_tenSP.Text.Trim();
                    exists = Convert.ToInt32(chk.ExecuteScalar()) > 0;
                }

                if (!exists)
                {
                    using (OracleCommand cmd = new OracleCommand(
                        "INSERT INTO ADMIN.SanPham (TenSanPham, Gia, SoLuong, TrangThai) " +
                        "VALUES (:ten, :gia, :soLuong, N'Còn bán') RETURNING MaSanPham INTO :maMoi", conn))
                    {
                        cmd.Parameters.Add(":ten", OracleDbType.NVarchar2).Value = textBox_tenSP.Text.Trim();
                        cmd.Parameters.Add(":gia", OracleDbType.Decimal).Value = gia;
                        cmd.Parameters.Add(":soLuong", OracleDbType.Int32).Value = soLuong;
                        OracleParameter paramMaMoi = new OracleParameter(":maMoi", OracleDbType.Decimal)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(paramMaMoi);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Thêm sản phẩm mới thành công! Mã SP: " + paramMaMoi.Value,
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    using (OracleCommand updateCmd = new OracleCommand(
                        "UPDATE ADMIN.SanPham SET Gia = :gia, SoLuong = :soLuong, TrangThai = N'Còn bán' " +
                        "WHERE TenSanPham = :ten", conn))
                    {
                        updateCmd.Parameters.Add(":gia", OracleDbType.Decimal).Value = gia;
                        updateCmd.Parameters.Add(":soLuong", OracleDbType.Int32).Value = soLuong;
                        updateCmd.Parameters.Add(":ten", OracleDbType.NVarchar2).Value = textBox_tenSP.Text.Trim();
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Sản phẩm đã tồn tại. Thông tin đã được cập nhật.",
                            "Cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            LoadProductsFromDatabase();
        }

        private void ButtonStopSP_Click(object sender, EventArgs e)
        {
            if (selectedMaSP < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OracleConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(
                    "UPDATE ADMIN.SanPham SET TrangThai = N'Ngừng kinh doanh' WHERE MaSanPham = :ma", conn))
                {
                    cmd.Parameters.Add(":ma", OracleDbType.Decimal).Value = selectedMaSP;
                    cmd.ExecuteNonQuery();
                }
            }

            LoadProductsFromDatabase();
        }
    }
}
