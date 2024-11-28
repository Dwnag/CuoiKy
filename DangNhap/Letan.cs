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
            this.FormClosing += (sender, e) => FormCloseHandler.exitProgram(this, e);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.show();
            this.Hide();
        }
    }
}
