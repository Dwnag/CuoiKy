using MyApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class XemBenhAn : Form
    {

        string connet = @"Data Source=localhost;Initial Catalog=ql1;Integrated Security=True";

        public XemBenhAn()
        {
            InitializeComponent();
            this.FormClosing += (sender, e) => FormCloseHandler.exitProgram(this, e);

            Findtxt.KeyDown += btnFind_KeyDown;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Bacsi bacsi = new Bacsi();
            bacsi.Show();
            this.Hide();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            findInformation();
        }


        private void findInformation()
        {
            string maKham = Findtxt.Text; // Lấy giá trị từ textbox (ô tìm kiếm)

            if (string.IsNullOrEmpty(maKham))
            {
                error.Text = "Vui lòng điền thông tin mã khám";
                error.Visible = true;
                resetLabels(); // Đặt lại các label về N/A
                return;
            }
                using (SqlConnection conn = new SqlConnection(connet))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Ho, Ten, NgaySinh, GioiTinh, SDT, DiaChi, Gmail, MaKham FROM BenhNhan WHERE MaKham = @MaKham";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKham", maKham);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Hiển thị thông tin lấy được từ SQL lên các label
                        lblHo.Text = reader["Ho"].ToString();
                        lblTen.Text = reader["Ten"].ToString();
                        lblNgaysinh.Text = reader["NgaySinh"].ToString();
                        lblGioitinh.Text = reader["GioiTinh"].ToString();
                        lblsdt.Text = reader["SDT"].ToString();
                        lblDiachi.Text = reader["DiaChi"].ToString();
                        lblgmail.Text = reader["Gmail"].ToString();
                        lblMakham.Text = reader["Makham"].ToString();

                        reader.Close();

                        // Truy vấn lịch sử khám bệnh
                        string queryLichSuKham = "SELECT Lan, DieuTri, BacSi, ChuanDoan FROM Lichsukham WHERE MaKham = @MaKham";
                        SqlDataAdapter adapter = new SqlDataAdapter(queryLichSuKham, conn);
                        adapter.SelectCommand.Parameters.AddWithValue("@MaKham", maKham);

                        DataTable dt = new DataTable();

                        // Điền dữ liệu vào DataTable
                        adapter.Fill(dt);

                        // Gán DataTable vào DataGridView
                        lichsu.DataSource = dt;

                        // Đặt tiêu đề cho các cột
                        lichsu.Columns[0].HeaderText = "Lần";
                        lichsu.Columns[1].HeaderText = "Điều trị";
                        lichsu.Columns[2].HeaderText = "Bác sĩ";
                        lichsu.Columns[3].HeaderText = "Chuẩn đoán";

                    }
                    else
                    {
                        error.Text = "Không tìm thấy bệnh án với mã khám này.";
                        error.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void resetLabels()
        {
            lblHo.Text = "N/A";
            lblTen.Text = "N/A";
            lblNgaysinh.Text = "N/A";
            lblGioitinh.Text = "N/A";
            lblsdt.Text = "N/A";
            lblDiachi.Text = "N/A";
            lblgmail.Text = "N/A";
            lblMakham.Text = "N/A";
            lichsu = null;
        }



        private void btnFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                findInformation();
                e.Handled = true;
                e.SuppressKeyPress = false;
            }
        }

        private void error_Click(object sender, EventArgs e)
        {
            this.Controls.Add(error);
        }

    }
}
