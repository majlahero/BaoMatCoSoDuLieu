using CuaHangDiDong;
using HTTT;
using HTTT.QUAN_LY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HHTPRO
{
    public partial class DashBoard_NhanVien : Form
    {
        public DashBoard_NhanVien()
        {
            InitializeComponent();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            F_BanHang f = new F_BanHang();
            f.ShowDialog();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            F_DanhSachHoaDon f = new F_DanhSachHoaDon();
            f.ShowDialog();
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            Form_KhoHang f = new Form_KhoHang();
            f.ShowDialog();
        }

        private void btnBaoHanh_Click(object sender, EventArgs e)
        {
            //F_BaoHanh f = new F_BaoHanh();
          //  f.ShowDialog();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            F_KhachHang f = new F_KhachHang();
            f.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();

                    // 🔹 Oracle dùng SYSDATE thay cho GETDATE()
                    string updateQuery = @"UPDATE ADMIN.LichSuDangNhap 
                                           SET ThoiGianDangXuat = SYSDATE 
                                           WHERE ThoiGianDangXuat IS NULL";

                    using (OracleCommand cmd = new OracleCommand(updateQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                Application.Exit();
            }
            catch (OracleException oraEx)
            {
                MessageBox.Show("Lỗi Oracle khi đăng xuất: " + oraEx.Message);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng xuất: " + ex.Message);
                Application.Exit();
            }
        }
    }
}
