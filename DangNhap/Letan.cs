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
    public partial class LeTan : Form
    {
        public LeTan()
        {
            InitializeComponent();
            //dừng chương trình khi nhấn x
            this.FormClosing += (sender, e) => FormCloseHandler.exitProgram(this, e);
            //chạy chương trình ở cùng 1 vị trí
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            backToMenu.back(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Themlichhen themlichhen = new Themlichhen();
            themlichhen.Show();
            this.Hide();
        }
    }
}
