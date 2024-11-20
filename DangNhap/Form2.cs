using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DangNhap
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void tendanhnhap_Enter(object sender, EventArgs e)
        {
            if (tendanhnhap.Text == "Tên đăng nhập")
            {
                tendanhnhap.Text = "";
                tendanhnhap.ForeColor = Color.Black;
            }
        }
        private void matkhau_Enter(object sender, EventArgs e)
        {
            if (matkhau.Text == "Mật khẩu")
            {
                matkhau.Text = "";
                matkhau.ForeColor = Color.Black;
            }
        }
        private void nhaplaimatkhau_Enter(object sender, EventArgs e)
        {
            if (nhaplaimatkhau.Text == "Nhập lại mật khẩu")
            {
                nhaplaimatkhau.Text = "";
                nhaplaimatkhau.ForeColor = Color.Black;
            }
        }
        private void email_Enter(object sender, EventArgs e)
        {
            if(email.Text == "Email")
            {
                email.Text = "";
                email.ForeColor = Color.Black;
            }
        }

       private void tendanhnhap_Leave(object sender, EventArgs e)
        {
            if (tendanhnhap.Text == "")
            {
                tendanhnhap.Text = "Tên đăng nhập";
                tendanhnhap.ForeColor = Color.Silver;
            }
        }

        private void matkhau_Leave(object sender, EventArgs e)
        {
            if (matkhau.Text == "")
            {
                matkhau.Text = "Mật khẩu";
                matkhau.ForeColor = Color.Silver;
            }
        }
        private void nhaplaimatkhau_Leave(object sender, EventArgs e)
        {
            if (nhaplaimatkhau.Text == "")
            {
                nhaplaimatkhau.Text = "Nhập lại mật khẩu";
                nhaplaimatkhau.ForeColor = Color.Silver;
            }
        }
        private void email_Leave(object sender, EventArgs e)
        {
            if (email.Text == "")
            {
                email.Text = "email";
                email.ForeColor = Color.Silver;
            }
        }

        private void roundPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1= new Form1();
            form1.Show();
            this.Hide();
        }
    }

}
