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
            backToMenu.back(this);
        }
    }
}
