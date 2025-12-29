using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace HTTT
{
    public partial class F_NhapHang : Form
    {
        public F_NhapHang()
        {
            InitializeComponent();

            if (!CheckUserAccess())
            {
                MessageBox.Show("Bạn không có quyền truy cập dữ liệu nhập hàng. Form sẽ không mở.",
                    "Lỗi quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Đặt flag để ngăn form load
                this.Load += (s, e) => this.BeginInvoke(new Action(() => this.Close()));
                return;
            }

            LoadComboBoxHang();
            LoadData();
        }


        public class ChiTietPhieuNhap
        {
            public decimal MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public int SoLuong { get; set; }
            public decimal GiaNhap { get; set; }
            public decimal ThanhTien => SoLuong * GiaNhap;
        }

        private List<ChiTietPhieuNhap> danhSachNhapTam = new List<ChiTietPhieuNhap>();
        private bool CheckUserAccess()
        {
            try
            {
                using (var conn = new DatabaseConnection().GetConnection())
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(
                        "SELECT 1 FROM ADMIN.PhieuNhapHang WHERE ROWNUM = 1", conn))
                    {
                        cmd.ExecuteScalar();
                        return true;
                    }
                }
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1031) // ORA-01031: thiếu quyền
                {
                    MessageBox.Show("Bạn không có quyền truy cập dữ liệu nhập hàng.", "Lỗi quyền",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (ex.Number == 942) // ORA-00942: table/view không tồn tại
                {
                    MessageBox.Show("Bảng hoặc view không tồn tại: " + ex.Message, "Lỗi dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    throw; // các lỗi khác ném tiếp
                }
            }
        }

        private void HienThiDanhSachTam()
        {
            var dt = new DataTable();
            dt.Columns.Add("MaSanPham", typeof(decimal));
            dt.Columns.Add("TenSanPham", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("GiaNhap", typeof(decimal));
            dt.Columns.Add("ThanhTien", typeof(decimal));

            foreach (var item in danhSachNhapTam)
                dt.Rows.Add(item.MaSanPham, item.TenSanPham, item.SoLuong, item.GiaNhap, item.ThanhTien);

            if (dt.Rows.Count > 0)
            {
                decimal tong = danhSachNhapTam.Sum(x => x.ThanhTien);
                DataRow rowTong = dt.NewRow();
                rowTong["TenSanPham"] = "TỔNG CỘNG";
                rowTong["ThanhTien"] = tong;
                dt.Rows.Add(rowTong);
            }

            dataGridViewNhapHang.DataSource = dt;

            // Format dòng tổng
            int lastRow = dataGridViewNhapHang.Rows.Count - 1;
            if (lastRow >= 0)
            {
                var row = dataGridViewNhapHang.Rows[lastRow];
                row.ReadOnly = true;
                row.DefaultCellStyle.BackColor = Color.LightYellow;
                row.DefaultCellStyle.Font = new Font(dataGridViewNhapHang.Font, FontStyle.Bold);
            }
        }

        private void LoadData()
        {
            var dtNhap = new DataTable();
            using (OracleConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        pn.MaNhapHang,
                        pn.NhaCungCap,
                        pn.NgayNhap,
                        sp.TenSanPham,
                        ctpn.SoLuong,
                        ctpn.GiaNhap,
                        (ctpn.SoLuong * ctpn.GiaNhap) AS ThanhTien
                    FROM ADMIN.PhieuNhapHang pn
                    JOIN ADMIN.ChiTietPhieuNhapHang ctpn ON pn.MaNhapHang = ctpn.MaNhapHang
                    JOIN ADMIN.SanPham sp ON ctpn.MaSanPham = sp.MaSanPham
                    ORDER BY pn.MaNhapHang, ctpn.MaChiTietNhap";

                using (OracleDataAdapter da = new OracleDataAdapter(sql, conn))
                {
                    da.Fill(dtNhap);
                }
            }

            if (!dtNhap.Columns.Contains("GhiChu"))
                dtNhap.Columns.Add("GhiChu", typeof(string));

            if (dtNhap.Rows.Count > 0)
            {
                decimal tongTien = dtNhap.AsEnumerable().Sum(r => r.Field<decimal>("ThanhTien"));
                DataRow rowTong = dtNhap.NewRow();
                rowTong["GhiChu"] = "TỔNG CỘNG";
                rowTong["ThanhTien"] = tongTien;
                dtNhap.Rows.Add(rowTong);
            }

            dataGridViewNhapHang.DataSource = dtNhap;
            dataGridViewNhapHang.AllowUserToAddRows = false;

            int last = dataGridViewNhapHang.Rows.Count - 1;
            if (last >= 0)
            {
                var row = dataGridViewNhapHang.Rows[last];
                row.ReadOnly = true;
                row.DefaultCellStyle.BackColor = Color.LightYellow;
                row.DefaultCellStyle.Font = new Font(dataGridViewNhapHang.Font, FontStyle.Bold);
            }

            if (dataGridViewNhapHang.Columns.Contains("GhiChu"))
                dataGridViewNhapHang.Columns["GhiChu"].DisplayIndex = 0;
        }

        private void LoadComboBoxHang()
        {
            try
            {
                using (OracleConnection conn = new DatabaseConnection().GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT MaSanPham, TenSanPham FROM ADMIN.SanPham WHERE TrangThai = N'Còn bán'";
                    using (OracleDataAdapter da = new OracleDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        comboBox_tenHang.DataSource = dt;
                        comboBox_tenHang.DisplayMember = "TenSanPham";
                        comboBox_tenHang.ValueMember = "MaSanPham";
                        comboBox_tenHang.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message);
            }
        }

        private void CalcThanhTien(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_soLuong.Text, out int sl) &&
                decimal.TryParse(textBox_donGia.Text, out decimal dg))
            {
                textBox_thanhTien.Text = (sl * dg).ToString("N2");
            }
            else
            {
                textBox_thanhTien.Text = "0";
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (comboBox_tenHang.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(textBox_soLuong.Text) ||
                string.IsNullOrWhiteSpace(textBox_donGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm.");
                return;
            }

            try
            {
                if (comboBox_tenHang.SelectedItem is DataRowView selectedRow)
                {
                    if (!int.TryParse(textBox_soLuong.Text, out int soLuong))
                    {
                        MessageBox.Show("Số lượng không hợp lệ!");
                        return;
                    }
                    if (!decimal.TryParse(textBox_donGia.Text, out decimal giaNhap))
                    {
                        MessageBox.Show("Giá nhập không hợp lệ!");
                        return;
                    }

                    var sp = new ChiTietPhieuNhap
                    {
                        MaSanPham = Convert.ToDecimal(selectedRow["MaSanPham"]),
                        TenSanPham = selectedRow["TenSanPham"].ToString(),
                        SoLuong = soLuong,
                        GiaNhap = giaNhap
                    };

                    danhSachNhapTam.Add(sp);
                    HienThiDanhSachTam();

                    comboBox_tenHang.SelectedIndex = -1;
                    textBox_soLuong.Clear();
                    textBox_donGia.Clear();
                    textBox_thanhTien.Clear();
                }
                else
                {
                    MessageBox.Show("Không thể lấy thông tin sản phẩm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

        private void buttonVerify_Click(object sender, EventArgs e)
        {
            if (danhSachNhapTam.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào để lưu.");
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBox_NhaCungCap.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp.");
                return;
            }

            decimal maNhapMoi;
            using (OracleConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (OracleTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        using (OracleCommand cmd = new OracleCommand())
                        {
                            cmd.Connection = conn;
                            cmd.Transaction = tran;
                            cmd.CommandText = @"
                        INSERT INTO ADMIN.PhieuNhapHang (NhaCungCap, NgayNhap)
                        VALUES (:ncc, :ngay)
                        RETURNING MaNhapHang INTO :maMoi";
                            cmd.Parameters.Add(":ncc", OracleDbType.NVarchar2).Value = comboBox_NhaCungCap.Text.Trim();
                            cmd.Parameters.Add(":ngay", OracleDbType.Date).Value = dateTimePicker_ngayDat.Value;

                            OracleParameter pOut = new OracleParameter(":maMoi", OracleDbType.Decimal)
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmd.Parameters.Add(pOut);
                            cmd.ExecuteNonQuery();

                            if (pOut.Value is OracleDecimal oraDec)
                                maNhapMoi = oraDec.Value;
                            else
                                maNhapMoi = Convert.ToDecimal(pOut.Value.ToString());
                        }

                        foreach (var sp in danhSachNhapTam)
                        {
                            // Insert chi tiết phiếu nhập
                            using (OracleCommand cmd = new OracleCommand())
                            {
                                cmd.Connection = conn;
                                cmd.Transaction = tran;
                                cmd.CommandText = @"
                            INSERT INTO ADMIN.ChiTietPhieuNhapHang
                              (MaNhapHang, MaSanPham, SoLuong, GiaNhap)
                            VALUES
                              (:man, :masp, :sl, :gia)";
                                cmd.Parameters.Add(":man", OracleDbType.Decimal).Value = maNhapMoi;
                                cmd.Parameters.Add(":masp", OracleDbType.Decimal).Value = sp.MaSanPham;
                                cmd.Parameters.Add(":sl", OracleDbType.Int32).Value = sp.SoLuong;
                                cmd.Parameters.Add(":gia", OracleDbType.Decimal).Value = sp.GiaNhap;
                                cmd.ExecuteNonQuery();
                            }

                            // Cập nhật số lượng sản phẩm
                            using (OracleCommand cmd = new OracleCommand())
                            {
                                cmd.Connection = conn;
                                cmd.Transaction = tran;
                                cmd.CommandText = @"
                            UPDATE ADMIN.SanPham 
                            SET SoLuong = SoLuong + :sl 
                            WHERE MaSanPham = :masp";
                                cmd.Parameters.Add(":sl", OracleDbType.Int32).Value = sp.SoLuong;
                                cmd.Parameters.Add(":masp", OracleDbType.Decimal).Value = sp.MaSanPham;
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        LoadData();
                        danhSachNhapTam.Clear();
                        HienThiDanhSachTam();
                        MessageBox.Show($"Đã lưu phiếu nhập số {maNhapMoi} thành công.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        comboBox_NhaCungCap.SelectedIndex = -1;
                        dateTimePicker_ngayDat.Value = DateTime.Now;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
                    }
                }
            }
        }
    }
}
