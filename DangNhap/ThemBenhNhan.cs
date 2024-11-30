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

namespace DangNhap
{
    public partial class ThemBenhNhan : Form
    {
        public ThemBenhNhan()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            backToMenu.back(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các điều khiển trong form
            string ho = Hotxt.Text.Trim();
            string ten = tentxt.Text.Trim();
            DateTime ngaySinh = Ngaysinh.Value;
            string gioiTinh = nam.Checked ? "Nam" : (nữ.Checked ? "Nữ" : string.Empty);
            string sdt = sdttxt.Text.Trim();
            string diaChi = diachitxt.Text.Trim();
            string gmail = gmailtxt.Text.Trim();
            string maKham = Makham.Text.Trim();
            string chuanDoan = chuandoantxt.Text.Trim();
            string phong = phongtxt.Text.Trim();
            string khoa = string.Empty;
            if (Nhachu.Checked)
                khoa = "Nha chu";
            else if (nhorang.Checked)
                khoa = "Nhổ răng và tiểu phẫu";
            else if (Chuarang.Checked)
                khoa = "Chữa răng và nội nha";
            else if (Rangtreem.Checked)
                khoa = "Răng trẻ em";
            else if (Phuchinh.Checked)
                khoa = "Phục hình";
            else if (Tongquat.Checked)
                khoa = "Tổng quát";

            // Kiểm tra dữ liệu trước khi lưu
            if (string.IsNullOrEmpty(ho) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(gioiTinh) ||
                string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(maKham))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Chuỗi kết nối SQL Server
                string connectionString = "Data Source=localhost;Initial Catalog=ql1;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO BenhNhan (Ho, Ten, NgaySinh, GioiTinh, SDT, DiaChi, Gmail, MaKham, 
                                                        ChuanDoan, phong, Khoa) 
                             VALUES (@Ho, @Ten, @NgaySinh, @GioiTinh, @SDT, @DiaChi, @Gmail, @MaKham, 
                                     @ChuanDoan, @phong, @Khoa)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số vào câu lệnh SQL
                        command.Parameters.AddWithValue("@Ho", ho);
                        command.Parameters.AddWithValue("@Ten", ten);
                        command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        command.Parameters.AddWithValue("@SDT", sdt);
                        command.Parameters.AddWithValue("@DiaChi", diaChi);
                        command.Parameters.AddWithValue("@Gmail", gmail);
                        command.Parameters.AddWithValue("@MaKham", maKham);
                        command.Parameters.AddWithValue("@ChuanDoan", chuanDoan);
                        command.Parameters.AddWithValue("@phong", phong);
                        command.Parameters.AddWithValue("@Khoa", khoa);
                        // Thực thi lệnh
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm hồ sơ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearInputs(); // Xóa trắng các trường sau khi thêm
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm hồ sơ, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hồ sơ: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm xóa trắng các điều khiển
        private void clearInputs()
        {
            Hotxt.Clear();
            tentxt.Clear();
            Ngaysinh.Value = DateTime.Now;
            nam.Checked = false;
            nữ.Checked = false;
            sdttxt.Clear();
            diachitxt.Clear();
            gmailtxt.Clear();
            Makham.Clear();
            chuandoantxt.Clear();
        }

        //Tạo mã khám tự động
        private string generateMaKham()
        {
            // Dựa trên số ngẫu nhiên
            Random random = new Random();
            int soNgauNhien = random.Next(100, 999); // Tạo số ngẫu nhiên từ 1 đến 99
            return $"NK-{soNgauNhien}";
        }

        private void themBenhNhan_Load(object sender, EventArgs e)
        {
            string maKham = generateMaKham();
            Makham.Text = maKham;

            //phòng
            List<string> phongkham = new List<string>
            {
                "PK.001",
                "PK.002",
                "PK.003",
                "PK.004"
            };

            // Thêm danh sách vào ComboBox
            foreach (string pk in phongkham)
            {
                phongtxt.Items.Add(pk);
            }

            // Tùy chọn: Đặt mục đầu tiên làm mục mặc định
            if (phongtxt.Items.Count > 0)
            {
                phongtxt.SelectedIndex = 0;
            }
        }
    }
}
