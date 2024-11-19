using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DangNhap
{
    public partial class Form1 : Form
    {
        SqlConnection connet = new SqlConnection(@"Data Source=D-LAP;Initial Catalog=ql1;Integrated Security=True");
        
        public Form1()
        {
            InitializeComponent();
            matkhau.KeyDown += matkhau_KeyDown;
            taikhoan.KeyDown += TaiKhoan_KeyDown;
        }

        //Nhan enter de xuong dong
        private void TaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);                     
            }
        }

        //Nhan enter de dang nhap
        private void matkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
                e.Handled = true; 
                e.SuppressKeyPress = true; 
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            string tenTaiKhoan = taikhoan.Text;
            string matKhau = matkhau.Text;
            try
            {
                String querry = "Select * FROM Login WHERE TaiKhoan = '" + taikhoan.Text + "' AND MatKhau = '" + matkhau.Text + "' ";
                SqlDataAdapter adt = new SqlDataAdapter(querry, connet);

                DataTable dt = new DataTable();
                adt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    tenTaiKhoan = taikhoan.Text;
                    matKhau = matkhau.Text;

                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Loi", "loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    taikhoan.Clear();
                    matkhau.Clear();

                    taikhoan.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi");
            }
            finally
            {
                connet.Close();
            }
        }


        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Bạn muốn thoát khỏi ứng dụng?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void artanPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void roundPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
