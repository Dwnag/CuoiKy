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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DangNhap
{
    public partial class Form2 : Form
    {
        private SqlConnection connet = new SqlConnection(@"Data Source=D-LAP;Initial Catalog=ql1;Integrated Security=True");

        public Form2()
        {
            InitializeComponent();
            tendanhnhap.Enter += tendanhnhap_Enter;
            tendanhnhap.Leave += tendanhnhap_Leave;

            matkhau.Enter += matkhau_Enter;
            matkhau.Leave += matkhau_Leave;

            nhaplaimatkhau.Enter += nhaplaimatkhau_Enter;
            nhaplaimatkhau.Leave += nhaplaimatkhau_Leave;

            email.Enter += email_Enter;
            email.Leave += email_Leave;

            btnDangKy.KeyDown += btnDangKy_KeyDown;
        }

        // Sự kiện khi nhấn vào textbox
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
            if (email.Text == "Email")
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
                email.Text = "Email";
                email.ForeColor = Color.Silver;
            }
        }

        //Đăng Ký
        private void SignIn()
        {
            // Kiểm tra xem người dùng đã nhập đầy đủ thông tin chưa
            if (tendanhnhap.Text == "Tên đăng nhập" || matkhau.Text == "Mật khẩu" || nhaplaimatkhau.Text == "Nhập lại mật khẩu" || email.Text == "Email" || tendanhnhap.Text == "Tên đăng nhập" || matkhau.Text == "Mật khẩu" || nhaplaimatkhau.Text == "Nhập lại mật khẩu" || email.Text == "Email")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (matkhau.Text != nhaplaimatkhau.Text)
            {
                MessageBox.Show("Mật khẩu và nhập lại mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    connet.Open();

                    // Kiểm tra kết nối
                    MessageBox.Show("Đã kết nối thành công.");

                    //thêm dữ liệu
                    string query = $"INSERT INTO ThongTinDangNhap (TaiKhoan, Matkhau, Email) VALUES ('{tendanhnhap.Text}', '{matkhau.Text}', '{email.Text}')";

                    using (SqlCommand cmd = new SqlCommand(query, connet))
                    {
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BackToLogin();
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký không thành công. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connet.Close();
                }
            }
        }

        //Trở lại giao diện đăng nhập
        private void BackToLogin()
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BackToLogin();
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
           SignIn();
        }

        private void btnDangKy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SignIn();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void artanPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
