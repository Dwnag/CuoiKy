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
    public partial class Menu1 : Form
    {
        public Menu1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //dừng chương trình khi nhấn x
            this.FormClosing += (sender, e) => FormCloseHandler.exitProgram(this, e);
        }
        private void quanly_Click(object sender, EventArgs e)
        {

        }

        private void dangxuat_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn đăng xuất", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                DangNhap f1 = new DangNhap();
                f1.Show();
                this.Hide();
            }
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menu1_Load(object sender, EventArgs e)
        {

        }

        private void roundPictureBox8_Click(object sender, EventArgs e)
        {
            LeTan lt = new LeTan();
            lt.Show();
            this.Hide();
        }

        private void menu_Click(object sender, EventArgs e)
        {

        }

        private void roundPictureBox6_Click(object sender, EventArgs e)
        {
            NhanVienKho nvk = new NhanVienKho();
            nvk.Show();
            this.Hide();
        }

        private void btnNhapXuatVatTu_Click(object sender, EventArgs e)
        {
            LeTan leTan = new LeTan();
            leTan.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NhanVienKho nvk = new NhanVienKho();
            nvk.Show();
            this.Hide();
        }
    }
}
