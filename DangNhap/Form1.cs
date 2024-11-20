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
        private SqlConnection connet = new SqlConnection(@"Data Source=D-LAP;Initial Catalog=ql1;Integrated Security=True");
        
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
                Login();
                e.Handled = true; 
                e.SuppressKeyPress = true; 
            }
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            string TenTaiKhoan = taikhoan.Text;
            string MatKhau = matkhau.Text;
            try
            {
                String querry = "Select * FROM Login WHERE TaiKhoan = '" + taikhoan.Text + "' AND MatKhau = '" + matkhau.Text + "' ";
                SqlDataAdapter adt = new SqlDataAdapter(querry, connet);

                DataTable dt = new DataTable();
                adt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    TenTaiKhoan = taikhoan.Text;
                    MatKhau = matkhau.Text;

                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không chính xác!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    taikhoan.Clear();
                    matkhau.Clear();

                    taikhoan.Focus();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
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
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Hienmatkhau_CheckedChanged(object sender, EventArgs e)
        {
            if (Hienmatkhau.Checked)
            {
                matkhau.PasswordChar = '\0';
            }
            else
            {
                matkhau.PasswordChar = '*';
            }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Taikhoan_Enter(object sender, EventArgs e)
        {
            if (taikhoan.Text == "Tên đăng nhập")
            {
                taikhoan.Text = "";
                taikhoan.ForeColor = Color.Black;
            }
        }

        private void Taikhoan_Leave(object sender, EventArgs e)
        {
            if (taikhoan.Text == "")
            {
                taikhoan.Text = "Tên đăng nhập";
                taikhoan.ForeColor = Color.Silver;
            }
        }

        private void matkhau_Enter(object sender, EventArgs e)
        {
            if (matkhau.Text == "Mật khẩu")
            {
                matkhau.Text = "";
                matkhau.ForeColor = Color.Black;
                matkhau.PasswordChar = '*';
            }
        }

        private void matkhau_Leave(object sender, EventArgs e)
        {
            if (matkhau.Text == "")
            {
                matkhau.Text = "Mật khẩu";  
                matkhau.ForeColor = Color.Silver;
                matkhau.PasswordChar = '\0';
            }
        }
    }
}
