﻿using MyApp.Utilities;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DangNhap
{
    public partial class DangNhap : Form
    {
        private readonly SqlConnection connet = new SqlConnection(@"Data Source=localhost;Initial Catalog=ql1;Integrated Security=True");

        public DangNhap()
        {
            InitializeComponent();
            // Giữ  nút Close, tắt nút Maximize và Minimize

            matkhau.KeyDown += matkhau_KeyDown;
            taikhoan.KeyDown += taiKhoan_KeyDown;
            matkhau.TextChanged += matkhau_TextChanged;
            taikhoan.MouseClick += taikhoan_MouseClick;
            matkhau.MouseClick += matkhau_MouseClick;
            //dừng chương trình khi nhấn x
            this.FormClosing += (sender, e) => FormCloseHandler.exitProgram(this, e);
        }

        //Nhan tabs de xuong dong
        private void taiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                lblError.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                login();
                e.Handled = true;
                e.SuppressKeyPress = false;
            }
        }

        //Nhan enter de dang nhap
        private void matkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
                e.Handled = true;
                e.SuppressKeyPress = false;
            }
        }

        private void taikhoan_MouseClick(object sender, MouseEventArgs e)
        {
            lblError.Visible = false;
        }

        private void matkhau_MouseClick(object sender, MouseEventArgs e)
        {
            lblError.Visible = false;
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
                string query = "SELECT * FROM ThongTinDangNhap WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau";
                SqlCommand cmd = new SqlCommand(query, connet);
                cmd.Parameters.AddWithValue("@TaiKhoan", TenTaiKhoan);
                cmd.Parameters.AddWithValue("@MatKhau", MatKhau);

                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    // Khởi tạo thông tin tài khoản hiện tại
                    string loaiTaiKhoan = dt.Rows[0]["LoaiTaiKhoan"].ToString();
                    Const.TaiKhoan = new TaiKhoan(
                        TenTaiKhoan,
                        MatKhau,
                        (TaiKhoan.loaiTK)Enum.Parse(typeof(TaiKhoan.loaiTK), loaiTaiKhoan)
                    );

                    // Chuyển đến Menu1
                    Menu1 menu = new Menu1();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    lblError.Text = "Thông tin đăng nhập không chính xác!";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối đến cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (AccountManager.isAccountSaved()) // Kiểm tra nếu tài khoản đã được lưu
            {
                var account = AccountManager.getSavedAccountInfo();
                taikhoan.Text = account.Username;
                matkhau.Text = account.Password;
                ghiNho.Checked = true;  // Tích chọn checkbox "Ghi nhớ"
                taikhoan.ForeColor = Color.Black;
                matkhau.ForeColor = Color.Black;
            }
        }
        //ghi nhớ
        private void ghiNho_CheckedChanged(object sender, EventArgs e)
        {
            if (ghiNho.Checked)
            {
                // Nếu người dùng đã chọn ghi nhớ và có thông tin, lưu thông tin tài khoản và mật khẩu
                if (!string.IsNullOrEmpty(taikhoan.Text) && !string.IsNullOrEmpty(matkhau.Text) &&
                    taikhoan.Text != "Tên đăng nhập" && matkhau.Text != "Mật khẩu")
                {
                    AccountManager.saveAccountInfo(taikhoan.Text, matkhau.Text);
                }
                else
                {
                    taikhoan.ForeColor = Color.Silver;
                    matkhau.ForeColor = Color.Silver;
                }
            }
            else
            {
                AccountManager.clearAccountInfo();
                if (taikhoan.Text == "Tên đăng nhập" || taikhoan.Text == "" || matkhau.Text == "Mật khẩu" || matkhau.Text == "")
                {
                    taikhoan.ForeColor = Color.Silver;
                    matkhau.ForeColor = Color.Silver;
                }
            }
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy form2 = new DangKy();
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
                e.IsInputKey = true;
                matkhau.Focus();
            }
        }

        private void matkhau_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                taikhoan.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau form3 = new QuenMatKhau();
            form3.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Controls.Add(lblError);
        }
    }
}