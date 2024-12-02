using MyApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DangNhap
{
    public partial class XemLichHen : Form
    {
        public XemLichHen()
        {
            InitializeComponent();
            btnFind.Click += btnFind_Click;
            btnFind.KeyDown += btnFind_KeyDown;
            Findtxt.KeyDown += btnFind_KeyDown;

            this.FormClosing += (sender, e) => FormCloseHandler.exitProgram(this, e);

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string tenBacSi = Findtxt.Text.Trim();

            // Kiểm tra nếu tên bác sĩ rỗng
            if (string.IsNullOrEmpty(tenBacSi))
            {
                MessageBox.Show("Vui lòng nhập tên bác sĩ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("HoTen", "Họ và Tên");
                dataGridView1.Columns.Add("MaKham", "Mã Khám");
                dataGridView1.Columns.Add("ChuanDoan", "Chuẩn Đoán");
                dataGridView1.Columns.Add("GioHen", "Giờ Hẹn");

                // Xóa các hàng cũ nếu có
                dataGridView1.Rows.Clear();
                string connectionString = "Data Source=localhost;Initial Catalog=ql1;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn để lấy thông tin liên quan đến tên bác sĩ
                    string query = @"
                    SELECT 
                        TenBS, 
                        Khoa, 
                        Phong, 
                        CONCAT(Ho, ' ', Ten) AS HoTenBenhNhan, 
                        MaKham, 
                        Chuandoan, 
                        GioHen 
                    FROM LichHen 
                    WHERE TenBS LIKE @TenBS";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TenBS", "%" + tenBacSi + "%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Kiểm tra nếu có dữ liệu
                            if (reader.HasRows)
                            {
                                // Xóa dữ liệu cũ trên DataGridView
                                dataGridView1.Rows.Clear();

                                // Biến để lưu tên bác sĩ, khoa và phòng
                                string bacSi = string.Empty;
                                string khoa = string.Empty;
                                string phong = string.Empty;

                                while (reader.Read())
                                {
                                    // Đọc thông tin bác sĩ (chỉ lấy 1 lần)
                                    if (string.IsNullOrEmpty(bacSi))
                                    {
                                        bacSi = reader["TenBS"].ToString();
                                        khoa = reader["Khoa"].ToString();
                                        phong = reader["Phong"].ToString();
                                    }

                                    // Thêm thông tin bệnh nhân vào DataGridView
                                    dataGridView1.Rows.Add(
                                        reader["HoTenBenhNhan"].ToString(),
                                        reader["MaKham"].ToString(),
                                        reader["Chuandoan"].ToString(),
                                        reader["GioHen"].ToString()
                                    );
                                }

                                // Hiển thị thông tin bác sĩ, khoa và phòng trên Label
                                lblhoten.Text = $"{bacSi}";
                                lblKhoa.Text = $"{khoa}";
                                lblPhong.Text = $"{phong}";
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin cho bác sĩ này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = false;
            }
        }

        private void error_Click(object sender, EventArgs e)
        {
            this.Controls.Add(error);
        }

        private void Findtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = false;
            }
        }
    }
}
