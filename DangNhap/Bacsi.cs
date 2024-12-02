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
    public partial class Bacsi : Form
    {
        public Bacsi()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            BackToMenu.back(this);
        }

        private void btnXemlichlam_Click(object sender, EventArgs e)
        {
            XemLichHen xemLichHen = new XemLichHen();
            xemLichHen.Show();
            this.Hide();
        }

        private void btnXemBenhAn_Click(object sender, EventArgs e)
        {
            XemBenhAn xemBenhAn = new XemBenhAn();
            xemBenhAn.Show();
            this.Hide();
        }
    }
}
