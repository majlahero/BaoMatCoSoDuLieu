using CuaHangDiDong;
using HTTT.FORM_IN;
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
    public partial class DashBoard_QL : Form
    {
        public DashBoard_QL()
        {
            InitializeComponent();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            F_BanHang f = new F_BanHang();
            f.ShowDialog();
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            Form_KhoHang f = new Form_KhoHang();
            f.ShowDialog();
        }

        private void btnHoaDonBan_Click(object sender, EventArgs e)
        {
            F_DanhSachHoaDon f = new F_DanhSachHoaDon();
            f.ShowDialog();
        }

        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            F_DanhSachPhieuNhap f = new F_DanhSachPhieuNhap();
            f.ShowDialog();
        }

        

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            F_KhachHang f = new F_KhachHang();
            f.ShowDialog();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            F_NhapHang f = new F_NhapHang();
            f.ShowDialog();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            F_ThongKe f = new F_ThongKe();
            f.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new DatabaseConnection().GetConnection())
                {
                    connection.Open();

                    string updateQuery = @"
                UPDATE ADMIN.LichSuDangNhap 
                SET ThoiGianDangXuat = SYSDATE 
                WHERE MaNhanVien = :ma 
                  AND ThoiGianDangXuat IS NULL";

                    using (OracleCommand cmd = new OracleCommand(updateQuery, connection))
                    {
                        cmd.Parameters.Add(":ma", MaNhanVien.Ma);
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


        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            F_NhanVien f = new F_NhanVien();
            f.ShowDialog();
        }

        private void btnTaoMaGiamGia_Click(object sender, EventArgs e)
        {
            F_MaGiamGia f = new F_MaGiamGia();
            f.ShowDialog();
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            F_TaiKhoan f = new F_TaiKhoan();
            f.ShowDialog();
        }
    }
}
