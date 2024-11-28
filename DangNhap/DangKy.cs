using MyApp.Utilities;
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
using System.Text.RegularExpressions;
namespace DangNhap
{
    public partial class DangKy : Form
    {
        private readonly SqlConnection connet = new SqlConnection(@"Data Source=D-LAP;Initial Catalog=ql1;Integrated Security=True");
        private bool isSignInInProgress = false;
        public DangKy()
        {
            InitializeComponent();
            //enter
            tendanhnhap.Enter += tendanhnhap_Enter;
            tendanhnhap.Leave += tendanhnhap_Leave;

            matkhau.Enter += matkhau_Enter;
            matkhau.Leave += matkhau_Leave;

            nhaplaimatkhau.Enter += nhaplaimatkhau_Enter;
            nhaplaimatkhau.Leave += nhaplaimatkhau_Leave;

            email.Enter += email_Enter;
            email.Leave += email_Leave;

            //keydown
            this.KeyPreview = true;  // Đảm bảo form nhận được sự kiện KeyDown
            this.KeyDown += form_KeyDown;

            //khởi động giao diện tại vị trí xác định
            this.StartPosition = FormStartPosition.CenterScreen;
            //dừng chương trình khi nhấn x
            this.FormClosing += (sender, e) => FormCloseHandler.exitProgram(this, e);
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

        //keydown
        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấn Enter
            if (e.KeyCode == Keys.Enter && !isSignInInProgress)
            {
                isSignInInProgress = true;  // Đánh dấu là đang xử lý đăng nhập
                signIn();  // Gọi phương thức đăng ký
                e.Handled = true;  // Ngừng sự kiện
            }
        }
        //MouseClick
        private void tendanhnhap_MouseClick(object sender, MouseEventArgs e)
        {
            lblError2.Visible=false;
        }

        private void matkhau_MouseClick(object sender, MouseEventArgs e)
        {
            lblError2.Visible = false;
        }

        private void nhaplaimatkhau_MouseClick(object sender, MouseEventArgs e)
        {
            lblError2.Visible = false;
        }

        private void email_MouseClick(object sender, MouseEventArgs e)
        {
            lblError2.Visible = false;
        }

        private bool isValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$"; // Kiểm tra chỉ email Gmail
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        //Đăng Ký
        private void signIn()
        {
            // Kiểm tra xem người dùng đã nhập đầy đủ thông tin chưa
            if (tendanhnhap.Text == "Tên đăng nhập" || matkhau.Text == "Mật khẩu" || nhaplaimatkhau.Text == "Nhập lại mật khẩu" || email.Text == "Email" || tendanhnhap.Text == "Tên đăng nhập" || matkhau.Text == "Mật khẩu" || nhaplaimatkhau.Text == "Nhập lại mật khẩu" || email.Text == "Email")
            {
                lblError2.Text = "Vui lòng điền đầy đủ thông tin.";
                lblError2.Visible = true;
                //MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (matkhau.Text != nhaplaimatkhau.Text)
            {
                lblError2.Text = "Mật khẩu và nhập lại mật khẩu không khớp!.";
                lblError2.Visible = true;
                //MessageBox.Show("Mật khẩu và nhập lại mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if ( isValidEmail(email.Text) == false ){
                lblError2.Text = "Vui lòng nhập email theo đúng định dạng.";
                lblError2.Visible = true;
                return;
            }
            else
            {
                try
                {
                    connet.Open();
                    //thêm dữ liệu
                    string query = $"INSERT INTO ThongTinDangNhap (TaiKhoan, Matkhau, Email) VALUES ('{tendanhnhap.Text}', '{matkhau.Text}', '{email.Text}')";

                    using (SqlCommand cmd = new SqlCommand(query, connet))
                    {
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            backToLogin();
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
        private void backToLogin()
        {
            DangNhap form1 = new DangNhap();
            form1.Show();
            this.Hide();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            backToLogin();
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
           signIn();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void artanPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Controls.Add(lblError2);
        }


    }
}
