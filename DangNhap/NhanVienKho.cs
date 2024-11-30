using MyApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class NhanVienKho : Form
    {
        public NhanVienKho()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //dừng chương trình khi nhấn x
            this.FormClosing += (sender, e) => FormCloseHandler.exitProgram(this, e);
        }

        private void btnNhapXuatVatTu_Click(object sender, EventArgs e)
        {
            NhapXuatVatTu nhap = new NhapXuatVatTu();
            nhap.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Menu1 menu = new Menu1();
            menu.Show();
            this.Hide();
        }

        //private void btnNhapXuatVatTu_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    //NhapXuatVatTu formNhapXuatVatTu = new NhapXuatVatTu();
        //    formNhapXuatVatTu.FormClosed += (s, args) => this.Show();
        //    formNhapXuatVatTu.Show();
        //}
    }
}
