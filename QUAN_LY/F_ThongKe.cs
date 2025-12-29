using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using ClosedXML.Excel;

namespace HTTT
{
    public partial class F_ThongKe : Form
    {
        public F_ThongKe()
        {
            InitializeComponent();
            if (!CheckDatabaseAccess())
            {
                // Nếu không có quyền hoặc bảng/view không tồn tại → thông báo và đóng form
                MessageBox.Show("Bạn không có quyền truy cập báo cáo hoặc bảng dữ liệu không tồn tại.",
                                "Lỗi quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Đóng form an toàn sau khi đã khởi tạo xong
                this.Load += (s, e) => this.BeginInvoke(new Action(() => this.Close()));
                return;
            }

            // Nếu có quyền thì load dữ liệu bình thường
            FormAnalysis_Load(null, null);
        }
        private bool CheckDatabaseAccess()
        {
            try
            {
                using (OracleConnection conn = new DatabaseConnection().GetConnection())
                {
                    conn.Open();
                    // Thử truy vấn 1 bản ghi đơn giản từ view hoặc bảng
                    using (OracleCommand cmd = new OracleCommand("SELECT 1 FROM ADMIN.vw_HoaDon WHERE ROWNUM = 1", conn))
                    {
                        cmd.ExecuteScalar();
                    }
                    return true;
                }
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1031) // ORA-01031: thiếu quyền
                    return false;
                else if (ex.Number == 942) // ORA-00942: bảng/view không tồn tại
                    return false;
                else
                    throw; // các lỗi khác ném tiếp
            }
            catch
            {
                return false;
            }
        }



        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1);

            using (OracleConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();

                // 1️⃣ Tổng quan doanh thu
                string querySummary = @"
                    SELECT 
                        NVL(SUM(TongTien), 0) AS TongDoanhThu,
                        NVL(SUM(SoLuong), 0) AS TongSoSanPham,
                        COUNT(DISTINCT MaDonHang) AS SoDonHang
                    FROM ADMIN.vw_HoaDon
                    WHERE NgayDatHang BETWEEN :FromDate AND :ToDate";

                using (OracleCommand cmdSummary = new OracleCommand(querySummary, conn))
                {
                    cmdSummary.Parameters.Add(new OracleParameter(":FromDate", OracleDbType.Date)).Value = fromDate;
                    cmdSummary.Parameters.Add(new OracleParameter(":ToDate", OracleDbType.Date)).Value = toDate;

                    using (OracleDataReader reader = cmdSummary.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTongDoanhThu.Text = "Tổng doanh thu: " + reader["TongDoanhThu"].ToString() + " VNĐ";
                            lblTongSanPham.Text = "Tổng sản phẩm bán: " + reader["TongSoSanPham"].ToString();
                            lblSoDonHang.Text = "Số đơn hàng: " + reader["SoDonHang"].ToString() + " đơn";
                        }
                    }
                }

                // 2️⃣ Doanh thu theo sản phẩm
                string queryDetail = @"
                    SELECT 
                        TenSanPham,
                        SUM(SoLuong) AS SoLuongBan,
                        SUM(TongTien) AS DoanhThu
                    FROM ADMIN.vw_HoaDon
                    WHERE NgayDatHang BETWEEN :FromDate AND :ToDate
                    GROUP BY TenSanPham
                    ORDER BY DoanhThu DESC";

                OracleDataAdapter adapter = new OracleDataAdapter(queryDetail, conn);
                adapter.SelectCommand.Parameters.Add(new OracleParameter(":FromDate", OracleDbType.Date)).Value = fromDate;
                adapter.SelectCommand.Parameters.Add(new OracleParameter(":ToDate", OracleDbType.Date)).Value = toDate;

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvThongKe.DataSource = dt;
            }
        }

        private void FormAnalysis_Load(object sender, EventArgs e)
        {
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear - 10; year <= currentYear + 1; year++)
            {
                cbNam.Items.Add(year);
            }
            cbNam.SelectedItem = currentYear;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (cbNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn năm cần thống kê!");
                return;
            }

            int selectedYear = Convert.ToInt32(cbNam.SelectedItem);

            using (OracleConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        EXTRACT(MONTH FROM NgayDatHang) AS Thang,
                        SUM(TongTien) AS DoanhThu
                    FROM ADMIN.vw_HoaDon
                    WHERE EXTRACT(YEAR FROM NgayDatHang) = :Year
                    GROUP BY EXTRACT(MONTH FROM NgayDatHang)
                    ORDER BY Thang";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter(":Year", OracleDbType.Int32)).Value = selectedYear;

                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    chartDoanhThuThang.Series.Clear();
                    chartDoanhThuThang.Titles.Clear();

                    var series = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh thu");
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                    for (int i = 1; i <= 12; i++)
                    {
                        var row = dt.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["Thang"]) == i);
                        decimal doanhThu = row != null ? Convert.ToDecimal(row["DoanhThu"]) : 0;

                        series.Points.AddXY("Tháng " + i, doanhThu);
                        series.Points[series.Points.Count - 1].Label = doanhThu > 0 ? doanhThu.ToString("N0") + " VNĐ" : "";
                    }

                    chartDoanhThuThang.Series.Add(series);
                    chartDoanhThuThang.Titles.Add("Doanh thu theo từng tháng - Năm " + selectedYear);
                }
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            if (dgvThongKe.DataSource == null)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu báo cáo doanh thu",
                FileName = "BaoCaoDoanhThu.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Báo cáo doanh thu");

                        int row = 1;

                        worksheet.Cell(row, 1).Value = "BÁO CÁO DOANH THU CỬA HÀNG KINH DOANH ĐIỆN THOẠI";
                        worksheet.Range(row, 1, row, 3).Merge().AddToNamed("Titles");
                        worksheet.Row(row).Style.Font.SetBold().Font.FontSize = 14;
                        row += 2;

                        worksheet.Cell(row, 1).Value = "Thống kê từ ngày:";
                        worksheet.Cell(row, 2).Value = dtpFromDate.Value.ToShortDateString();
                        row++;
                        worksheet.Cell(row, 1).Value = "Đến ngày:";
                        worksheet.Cell(row, 2).Value = dtpToDate.Value.ToShortDateString();
                        row++;

                        worksheet.Cell(row, 1).Value = lblTongDoanhThu.Text;
                        row++;
                        worksheet.Cell(row, 1).Value = lblTongSanPham.Text;
                        row++;
                        worksheet.Cell(row, 1).Value = lblSoDonHang.Text;
                        row += 2;

                        DataTable dt = (DataTable)dgvThongKe.DataSource;
                        worksheet.Cell(row, 1).InsertTable(dt, "ChiTietSanPham", true);
                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Xuất file Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
