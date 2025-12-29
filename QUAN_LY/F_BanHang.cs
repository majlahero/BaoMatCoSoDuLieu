using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace HTTT.QUAN_LY
{
    public partial class F_BanHang : Form
    {
        public F_BanHang()
        {
            InitializeComponent();
        }

        private void Form_banhang_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MaNhanVien.Ma))
            {
                LoadNhanVienInfo();
            }
            else
            {
                MessageBox.Show("Mã nhân viên không hợp lệ.");
            }

            SetupDataGridView();
        }

        private void LoadNhanVienInfo()
        {
            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    string query = @"SELECT TenNhanVien, DiaChi, SoDienThoai, Email 
                                     FROM  ADMIN.NhanVien 
                                     WHERE MaNhanVien = :MaNhanVien";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":MaNhanVien", MaNhanVien.Ma));

                        connection.Open();

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTenNhanVien.Text = reader["TenNhanVien"]?.ToString();
                                txtDiaChiNV.Text = reader["DiaChi"]?.ToString();
                                txtSDTNV.Text = reader["SoDienThoai"]?.ToString();
                                txtEmail.Text = reader["Email"]?.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (OracleException oraEx)
            {
                MessageBox.Show("Lỗi Oracle: " + oraEx.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void TimKiemSanPham()
        {
            string tenSanPham = txtTimKiemSP.Text.Trim();
            lstSanPham.Items.Clear();

            if (!string.IsNullOrEmpty(tenSanPham))
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    string query = "SELECT TenSanPham FROM ADMIN.SanPham WHERE TenSanPham LIKE :TenSanPham AND TrangThai = 'Còn bán' AND SoLuong > 0";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(":TenSanPham", "%" + tenSanPham + "%"));

                        try
                        {
                            connection.Open();
                            using (OracleDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string tenSP = reader["TenSanPham"].ToString();
                                    lstSanPham.Items.Add(tenSP);
                                }
                            }

                            lstSanPham.Visible = lstSanPham.Items.Count > 0;
                        }
                        catch (OracleException oraEx)
                        {
                            MessageBox.Show("Lỗi Oracle: " + oraEx.Message);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                lstSanPham.Visible = false;
            }
        }

        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            TimKiemSanPham();
        }

        private void txtTimKiemSP_TextChanged(object sender, EventArgs e)
        {
            TimKiemSanPham();
        }

        private SanPham GetSanPhamByTen(string tenSanPham)
        {
            SanPham sanPham = null;

            using (var connection = new DatabaseConnection().GetConnection())
            {
                string query = "SELECT MaSanPham, TenSanPham, Gia FROM ADMIN.SanPham WHERE TenSanPham = :TenSanPham";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter(":TenSanPham", tenSanPham));

                    try
                    {
                        connection.Open();
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                sanPham = new SanPham
                                {
                                    MaSanPham = Convert.ToInt32(reader["MaSanPham"]),
                                    TenSanPham = reader["TenSanPham"].ToString(),
                                    Gia = Convert.ToDecimal(reader["Gia"])
                                };
                            }
                        }
                    }
                    catch (OracleException oraEx)
                    {
                        MessageBox.Show("Lỗi Oracle: " + oraEx.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi lấy thông tin sản phẩm: " + ex.Message);
                    }
                }
            }

            return sanPham;
        }

        private void SetupDataGridView()
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("STT", "STT");
            dataGridView.Columns["STT"].Width = 50;
            dataGridView.Columns["STT"].ReadOnly = true;

            dataGridView.Columns.Add("TenSanPham", "Tên sản phẩm");
            dataGridView.Columns["TenSanPham"].Width = 400;
            dataGridView.Columns["TenSanPham"].ReadOnly = true;

            dataGridView.Columns.Add("GiaBan", "Giá bán");
            dataGridView.Columns["GiaBan"].Width = 120;
            dataGridView.Columns["GiaBan"].ReadOnly = true;

            dataGridView.Columns.Add("SoLuong", "Số lượng");
            dataGridView.Columns["SoLuong"].Width = 100;

            dataGridView.Columns.Add("ThanhTien", "Thành tiền");
            dataGridView.Columns["ThanhTien"].Width = 130;
            dataGridView.Columns["ThanhTien"].ReadOnly = true;

            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = "Hành động";
            btnColumn.HeaderText = "Hành động";
            btnColumn.Text = "Xóa";
            btnColumn.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(btnColumn);

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
            dataGridView.CellValidating += dataGridView_CellValidating;
        }

        private void dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView.Columns["SoLuong"].Index)
            {
                if (!int.TryParse(e.FormattedValue.ToString(), out int soLuong) || soLuong < 0)
                {
                    e.Cancel = true;
                    return;
                }

                // Lấy tên sản phẩm từ ô tương ứng
                string tenSanPham = dataGridView.Rows[e.RowIndex].Cells["TenSanPham"].Value?.ToString();

                if (!string.IsNullOrEmpty(tenSanPham))
                {
                    // Kiểm tra số lượng trong cơ sở dữ liệu
                    int soLuongTrongDB = GetSoLuongSanPham(tenSanPham); // Hàm lấy số lượng từ database

                    if (soLuong > soLuongTrongDB)
                    {
                        MessageBox.Show($"Số lượng không được lớn hơn {soLuongTrongDB} cho sản phẩm {tenSanPham}.");
                        e.Cancel = true; // Hủy thao tác nhập
                    }
                }
            }
        }

        // Hàm để lấy số lượng sản phẩm từ database (Oracle)
        private int GetSoLuongSanPham(string tenSanPham)
        {
            using (var connection = new DatabaseConnection().GetConnection()) // OracleConnection
            {
                string query = "SELECT SoLuong FROM ADMIN.SanPham WHERE TenSanPham = :TenSanPham";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter(":TenSanPham", tenSanPham));
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView.Columns["SoLuong"].Index && e.RowIndex >= 0)
            {
                var row = dataGridView.Rows[e.RowIndex];
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                decimal giaBan = Convert.ToDecimal(row.Cells["GiaBan"].Value);

                if (soLuong == 0)
                {
                    row.Cells["SoLuong"].Value = 1;
                    soLuong = 1;
                }

                row.Cells["ThanhTien"].Value = soLuong * giaBan;
                UpdateTongTien();
            }
        }

        private void UpdateThanhTien(DataGridViewRow row)
        {
            int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
            decimal giaBan = Convert.ToDecimal(row.Cells["GiaBan"].Value);
            row.Cells["ThanhTien"].Value = soLuong * giaBan;
            UpdateTongTien();
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            string sdt = txtTimKiemKH.Text.Trim();

            using (var connection = new DatabaseConnection().GetConnection())
            {
                connection.Open();
                string query = "SELECT TenKhachHang, DiaChi, SoDienThoai FROM ADMIN.KhachHang WHERE SoDienThoai = :sdt";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter(":sdt", sdt));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTenKH.Text = reader["TenKhachHang"].ToString();
                            txtDiaChiKH.Text = reader["DiaChi"].ToString();
                            txtSDTKH.Text = reader["SoDienThoai"].ToString();
                        }
                        else
                        {
                            txtTenKH.Clear();
                            txtDiaChiKH.Clear();
                            txtSDTKH.Clear();
                            MessageBox.Show("Không tìm thấy khách hàng với số điện thoại này.");
                        }
                    }
                }
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView.Columns["Hành động"].Index && e.RowIndex >= 0)
            {
                dataGridView.Rows.RemoveAt(e.RowIndex);
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    dataGridView.Rows[i].Cells["STT"].Value = i + 1;
                }
                UpdateTongTien();
            }
        }

        private void lstSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSanPham.SelectedItem is string tenSanPham)
            {
                var sanPham = GetSanPhamByTen(tenSanPham);

                if (sanPham != null)
                {
                    bool productExists = false;

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.Cells["TenSanPham"].Value.ToString() == sanPham.TenSanPham)
                        {
                            int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                            row.Cells["SoLuong"].Value = soLuong + 1;
                            UpdateThanhTien(row);
                            productExists = true;
                            break;
                        }
                    }

                    if (!productExists)
                    {
                        int rowIndex = dataGridView.Rows.Add();
                        var row = dataGridView.Rows[rowIndex];
                        row.Cells["STT"].Value = rowIndex + 1;
                        row.Cells["TenSanPham"].Value = sanPham.TenSanPham;
                        row.Cells["GiaBan"].Value = sanPham.Gia;
                        row.Cells["SoLuong"].Value = 1;
                        row.Cells["ThanhTien"].Value = sanPham.Gia;
                    }

                    UpdateTongTien();
                    txtTimKiemSP.Clear();
                }
            }
        }

        private decimal GetSoTienGiam(string maKhuyenMai)
        {
            decimal soTienGiam = 0;

            using (var connection = new DatabaseConnection().GetConnection())
            {
                connection.Open();
                string query = "SELECT SoTienGiam FROM ADMIN.KhuyenMai WHERE MaKhuyenMai = :maKhuyenMai";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter(":maKhuyenMai", maKhuyenMai));
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        soTienGiam = Convert.ToDecimal(result);
                    }
                }
            }

            return soTienGiam;
        }

        private void UpdateTongTien()
        {
            decimal tongTien = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                }
            }

            string maKhuyenMai = txtKhuyenMai.Text.Trim();
            decimal soTienGiam = GetSoTienGiam(maKhuyenMai);
            tongTien -= soTienGiam;

            if (tongTien < 0) tongTien = 0;

            btnTongTien.Text = $"{tongTien}";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // 🔹 Kiểm tra dữ liệu đầu vào
            if (dataGridView.Rows.Count == 0 || string.IsNullOrEmpty(cmboxThanhToan.SelectedItem?.ToString()))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đơn hàng và hình thức thanh toán!");
                return;
            }

            // 🔹 Lấy thông tin thanh toán
            var paymentInfo = new
            {
                MaNhanVien = MaNhanVien.Ma,
                MaKhuyenMai = string.IsNullOrEmpty(txtKhuyenMai.Text) ? null : txtKhuyenMai.Text.Trim(),
                ThanhToan = cmboxThanhToan.SelectedItem.ToString(),
                MaKhachHang = GetKhachHangMaByPhone(txtSDTKH.Text.Trim())
            };

            // 🔹 Kiểm tra mã khuyến mãi
            if (paymentInfo.MaKhuyenMai != null && !IsKhuyenMaiValid(paymentInfo.MaKhuyenMai))
            {
                MessageBox.Show("Mã khuyến mãi không hợp lệ!");
                return;
            }

            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 1️⃣ Tạo đơn hàng
                            string maDonHang = CreateOrder(connection, transaction, paymentInfo);
                            if (string.IsNullOrEmpty(maDonHang))
                            {
                                transaction.Rollback();
                                MessageBox.Show("Lỗi khi tạo đơn hàng!");
                                return;
                            }

                            // 2️⃣ Thêm chi tiết đơn hàng và cập nhật tồn kho
                            if (!ProcessOrderItems(connection, transaction, maDonHang))
                            {
                                transaction.Rollback();
                                DeleteOrder(connection, maDonHang);
                                MessageBox.Show("Lỗi khi thêm chi tiết đơn hàng!");
                                return;
                            }

                            // ✅ Thành công: commit transaction
                            transaction.Commit();

                            MessageBox.Show("Da tao don hang thanh cong.");
                            dataGridView.Rows.Clear();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Lỗi xử lý đơn hàng: {ex.Message}");
                        }
                    }
                }
            }
            catch (OracleException oex)
            {
                MessageBox.Show($"Lỗi Oracle: {oex.Message}");  
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        // 🔸 Tạo đơn hàng
        private string CreateOrder(OracleConnection connection, OracleTransaction transaction, dynamic paymentInfo)
        {
            string query = @"
                INSERT INTO ADMIN.DonHang (MaNhanVien, MaKhachHang, MaKhuyenMai, ThanhToan)
                VALUES (:MaNhanVien, :MaKhachHang, :MaKhuyenMai, :ThanhToan)
                RETURNING MaDonHang INTO :NewId";

            using (var cmd = new OracleCommand(query, connection))
            {
                cmd.Transaction = transaction;
                cmd.Parameters.Add(":MaNhanVien", paymentInfo.MaNhanVien);
                cmd.Parameters.Add(":MaKhachHang", paymentInfo.MaKhachHang ?? (object)DBNull.Value);
                cmd.Parameters.Add(":MaKhuyenMai", paymentInfo.MaKhuyenMai ?? (object)DBNull.Value);
                cmd.Parameters.Add(":ThanhToan", paymentInfo.ThanhToan);
                cmd.Parameters.Add(":NewId", OracleDbType.Decimal, ParameterDirection.Output);

                cmd.ExecuteNonQuery();
                return cmd.Parameters[":NewId"].Value.ToString();
            }
        }

        // 🔸 Thêm chi tiết đơn hàng và trừ tồn kho
        private bool ProcessOrderItems(OracleConnection connection, OracleTransaction transaction, string maDonHang)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.IsNewRow) continue;

                    string tenSanPham = row.Cells["TenSanPham"].Value.ToString();
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    int maSanPham = GetSanPhamMaByTen(tenSanPham);

                    // Thêm chi tiết đơn hàng
                    string insertDetail = @"
                        INSERT INTO ADMIN.ChiTietDonHang (MaDonHang, MaSanPham, SoLuong)
                        VALUES (:MaDonHang, :MaSanPham, :SoLuong)";

                    using (var cmd = new OracleCommand(insertDetail, connection))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.Add(":MaDonHang", Convert.ToInt32(maDonHang));
                        cmd.Parameters.Add(":MaSanPham", maSanPham);
                        cmd.Parameters.Add(":SoLuong", soLuong);
                        cmd.ExecuteNonQuery();
                    }

                    // Cập nhật tồn kho
                    string updateStock = "UPDATE ADMIN.SanPham SET SoLuong = SoLuong - :SoLuong WHERE MaSanPham = :MaSanPham";
                    using (var cmd = new OracleCommand(updateStock, connection))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.Add(":SoLuong", soLuong);
                        cmd.Parameters.Add(":MaSanPham", maSanPham);
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        // 🔸 Xóa đơn hàng nếu lỗi
        private void DeleteOrder(OracleConnection connection, string maDonHang)
        {
            using (var cmd = new OracleCommand("DELETE FROM ADMIN.DonHang WHERE MaDonHang = :MaDonHang", connection))
            {
                cmd.Parameters.Add(":MaDonHang", maDonHang);
                cmd.ExecuteNonQuery();
            }
        }

        // 🔸 Kiểm tra mã khuyến mãi
        private bool IsKhuyenMaiValid(string maKhuyenMai)
        {
            using (var connection = new DatabaseConnection().GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM ADMIN.KhuyenMai WHERE MaKhuyenMai = :MaKhuyenMai";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":MaKhuyenMai", maKhuyenMai);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        // 🔸 Lấy mã khách hàng theo số điện thoại
        private int? GetKhachHangMaByPhone(string soDienThoai)
        {
            using (var connection = new DatabaseConnection().GetConnection())
            {
                string query = "SELECT MaKhachHang FROM ADMIN.KhachHang WHERE SoDienThoai = :SoDienThoai";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":SoDienThoai", soDienThoai);
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : (int?)null;
                }
            }
        }

        // 🔸 Lấy mã sản phẩm theo tên
        private int GetSanPhamMaByTen(string tenSanPham)
        {
            using (var connection = new DatabaseConnection().GetConnection())
            {
                string query = "SELECT MaSanPham FROM ADMIN.SanPham WHERE TenSanPham = :TenSanPham";
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(":TenSanPham", tenSanPham);
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            string maKhuyenMai = txtKhuyenMai.Text.Trim();
            decimal soTienGiam = GetSoTienGiam(maKhuyenMai);

            if (soTienGiam > 0)
            {
                MessageBox.Show($"Áp dụng mã khuyến mãi thành công! Giảm: {soTienGiam}");
                UpdateTongTien();
            }
            else
            {
                MessageBox.Show("Mã không hợp lệ!!");
            }
        }
    }

}

public class SanPham
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public decimal Gia { get; set; }
     }
