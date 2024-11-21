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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DangNhap
{
    public partial class Form1 : Form
    {
        private readonly SqlConnection connet = new SqlConnection(@"Data Source=D-LAP;Initial Catalog=ql1;Integrated Security=True");
        
        public Form1()
        {
            InitializeComponent();
            matkhau.KeyDown += matkhau_KeyDown;
            taikhoan.KeyDown += taiKhoan_KeyDown;
            matkhau.TextChanged += matkhau_TextChanged;
        }

        //Nhan tabs de xuong dong
        private void taiKhoan_KeyDown(object sender, KeyEventArgs e)
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
            string TenTaiKhoan = taikhoan.Text;
            string MatKhau = matkhau.Text;
            try
            {
                String querry = "Select * FROM ThongTinDangNhap WHERE TaiKhoan = '" + taikhoan.Text + "' AND MatKhau = '" + matkhau.Text + "' ";
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

        private void form1_Load(object sender, EventArgs e)
        {
           
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void matkhau_TextChanged(object sender, EventArgs e)
        {
            matkhau.PasswordChar = Hienmatkhau.Checked ? '\0' : '*';
        }



        private void hienmatkhau_CheckedChanged(object sender, EventArgs e)
        {
            // Đồng bộ trạng thái hiển thị mật khẩu khi checkbox thay đổi
            matkhau.PasswordChar = Hienmatkhau.Checked ? '\0' : '*';
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

        private void taikhoan_Enter(object sender, EventArgs e)
        {
            if (taikhoan.Text == "Tên đăng nhập")
            {
                taikhoan.Text = "";
                taikhoan.ForeColor = Color.Black;
            }
        }

        private void taikhoan_Leave(object sender, EventArgs e)
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

                // Kiểm tra trạng thái của checkbox để quyết định PasswordChar
                matkhau.PasswordChar = Hienmatkhau.Checked ? '\0' : '*';
            }
        }

        private void matkhau_Leave(object sender, EventArgs e)
        {
            if (matkhau.Text == "")
            {
                matkhau.Text = "Mật khẩu";
                matkhau.ForeColor = Color.Silver;

                // Reset PasswordChar về trạng thái mặc định khi rời khỏi TextBox
                matkhau.PasswordChar = '\0';
            }
        }

        private void taikhoan_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true; // Ngừng hành vi mặc định của phím Tab
                taikhoan.Focus(); // Di chuyển con trỏ đến textBox1
            }
        }
    }
}
