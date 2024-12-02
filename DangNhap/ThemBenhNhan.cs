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

namespace DangNhap
{
    public partial class ThemBenhNhan : Form
    {
        public ThemBenhNhan()
        {
            InitializeComponent();
            this.FormClosing += (sender, e) => FormCloseHandler.exitProgram(this, e);
        }

        private void exit_Click(object sender, EventArgs e)
        {
           LeTan leTan = new LeTan();
           leTan.Show();
           this.Hide();
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
                string connectionString = "Data Source=localhost;Initial Catalog=ql1;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Kiểm tra sự tồn tại của MaKham trong bảng LichSuKham
                    string checkQuery = @"SELECT COUNT(1) FROM LichSuKham WHERE MaKham = @MaKham";

                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MaKham", maKham);
                        int recordCount = (int)checkCommand.ExecuteScalar();

                        if (recordCount == 0)
                        {
                            // Nếu MaKham chưa tồn tại trong bảng LichSuKham, thực hiện chèn dữ liệu vào BenhNhan và LichSuKham
                            string insertQuery = @"
                    INSERT INTO BenhNhan (Ho, Ten, NgaySinh, GioiTinh, SDT, DiaChi, Gmail, MaKham, ChuanDoan, Phong, Khoa) 
                    VALUES (@Ho, @Ten, @NgaySinh, @GioiTinh, @SDT, @DiaChi, @Gmail, @MaKham, @ChuanDoan, @Phong, @Khoa);

                    INSERT INTO LichSuKham ( Lan,  Khoa, ChuanDoan, MaKham) 
                    VALUES (1, @Khoa, @ChuanDoan, @MaKham)"; // Set initial SoLanKham = 1

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                // Thêm các tham số cho bảng BenhNhan và LichSuKham
                                insertCommand.Parameters.AddWithValue("@Ho", ho);
                                insertCommand.Parameters.AddWithValue("@Ten", ten);
                                insertCommand.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                                insertCommand.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                                insertCommand.Parameters.AddWithValue("@SDT", sdt);
                                insertCommand.Parameters.AddWithValue("@DiaChi", diaChi);
                                insertCommand.Parameters.AddWithValue("@Gmail", gmail);
                                insertCommand.Parameters.AddWithValue("@MaKham", maKham);
                                insertCommand.Parameters.AddWithValue("@ChuanDoan", chuanDoan);
                                insertCommand.Parameters.AddWithValue("@Phong", phong);
                                insertCommand.Parameters.AddWithValue("@Khoa", khoa);


                                // Thực thi lệnh
                                int rowsAffected = insertCommand.ExecuteNonQuery();

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
                        else
                        {
                            // Nếu MaKham đã tồn tại, cập nhật số lần khám
                            string updateQuery = @"
                                UPDATE LichSuKham 
                                SET SoLanKham = SoLanKham + 1
                                WHERE MaKham = @MaKham";

                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@MaKham", maKham);

                                int rowsAffected = updateCommand.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Cập nhật số lần khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Không thể cập nhật số lần khám, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
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
            int soNgauNhien = random.Next(001, 999); // Tạo số ngẫu nhiên từ 1 đến 999
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
