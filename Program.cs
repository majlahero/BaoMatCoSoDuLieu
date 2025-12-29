using HTTT.QUAN_LY;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HTTT;
using CuaHangDiDong;
using HTTT.FORM_IN;

namespace HHTPRO
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new F_DangNhap());
        }
    }
}