﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static DangNhap.EmailHelper;
using MyApp.Utilities;

namespace DangNhap
{
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
            //khởi động chương trình ở 1 vị trí nhất định
            this.StartPosition = FormStartPosition.CenterScreen;
            //dừng chương trình khi nhấn x
            this.FormClosing += (sender, e) => FormCloseHandler.exitProgram(this, e);
        }


        //gửi mail       

        private void btn_laylaimatkhau_Click(object sender, EventArgs e)
        {
            EmailHelper emailHelper = new EmailHelper();
   
            string emailInput = textBox1.Text;    
            // Gọi phương thức phục hồi mật khẩu
            emailHelper.recoverPassword(emailInput, lblError3);
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy form2 = new DangKy();
            form2.Show();
            this.Hide();
        }

        private void backToLogin_Click(object sender, EventArgs e)
        {
            DangNhap f1 = new DangNhap();
            f1.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                EmailHelper emailHelper = new EmailHelper();
                string emailInput = textBox1.Text;
                emailHelper.recoverPassword(emailInput, lblError3);
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            lblError3.Visible = false;
        }
    }
}
