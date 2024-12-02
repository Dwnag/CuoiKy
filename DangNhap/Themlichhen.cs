using MyApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class Themlichhen : Form
    {
        public Themlichhen()
        {
            InitializeComponent();
            this.FormClosing += (sender, e) => FormCloseHandler.exitProgram(this, e);
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
            Ngayhen.Value = DateTime.Now;
            dichvutxt.Clear();
            if (khunggio.Items.Count > 0) khunggio.SelectedIndex = -1;
            if (Bacsi.Items.Count > 0) Bacsi.SelectedIndex = -1;
        }

        //Tạo mã khám tự động
        private string generateMaKham()
        {
            // Dựa trên số ngẫu nhiên
            Random random = new Random();
            int soNgauNhien = random.Next(001, 999); // Tạo số ngẫu nhiên từ 1 đến 999
            return $"NK-{soNgauNhien}";
        }

        private void themlichhen_Load(object sender, EventArgs e)
        {

            string maKham = generateMaKham();
            Makham.Text = maKham;

            List<string> danhSachBacSi = new List<string>
            {
                "Nguyễn Văn Sáng",
                "Trần Thị Huyền",
                "Lê Văn Khánh",
                "Phạm Thị Diệu   "
            };

            // Thêm danh sách vào ComboBox
            foreach (string bacSi in danhSachBacSi)
            {
                Bacsi.Items.Add(bacSi);
            }

            // Tùy chọn: Đặt mục đầu tiên làm mục mặc định
            if (Bacsi.Items.Count > 0)
            {
                Bacsi.SelectedIndex = 0;
            }

            // Khung Giờ
            List<string> khunggiolamviec = new List<string>
            {
                "08:00 - 12:00",
                "13:00 - 17:00",
                "10:00 - 14:00",
                "14:00 - 18:00"
            };

            // Thêm danh sách vào ComboBox
            foreach (string time in khunggiolamviec)
            {
                khunggio.Items.Add(time);
            }

            // Tùy chọn: Đặt mục đầu tiên làm mục mặc định
            if (khunggio.Items.Count > 0)
            {
                khunggio.SelectedIndex = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
            DateTime ngayHen = DateTime.Parse(Ngayhen.Text.Trim());
            string dichVu = dichvutxt.Text.Trim();
            string khungGio = khunggio.Text.Trim();
            string bacSi = Bacsi.SelectedItem?.ToString() ?? string.Empty;

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

                    // Kiểm tra sự tồn tại của MaKham trong bảng BenhNhan
                    string checkQuery = @"SELECT COUNT(1) FROM BenhNhan WHERE MaKham = @MaKham";

                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MaKham", maKham);
                        int recordCount = (int)checkCommand.ExecuteScalar();

                        if (recordCount == 0)
                        {
                            // Nếu MaKham chưa tồn tại trong bảng BenhNhan, thực hiện thêm mới
                            string insertQuery = @"
                            INSERT INTO BenhNhan (Ho, Ten, NgaySinh, GioiTinh, SDT, DiaChi, Gmail, MaKham, ChuanDoan) 
                            VALUES (@Ho, @Ten, @NgaySinh, @GioiTinh, @SDT, @DiaChi, @Gmail, @MaKham, @ChuanDoan);

                            INSERT INTO LichSuKham (Lan, Dieutri, Bacsi, Chuandoan, MaKham) 
                            VALUES (1, @dichVu, @BacSi, @ChuanDoan, @MaKham)";

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

                                // Các tham số cho bảng LichSuKham
                                insertCommand.Parameters.AddWithValue("@BacSi", bacSi);
                                insertCommand.Parameters.AddWithValue("@dichVu", dichVu); // Các thông tin về dịch vụ

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
                            // Nếu MaKham đã tồn tại trong bảng BenhNhan, thực hiện cập nhật
                            string updateQuery = @"
                            UPDATE BenhNhan 
                            SET Ho = @Ho, Ten = @Ten, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, SDT = @SDT, 
                                DiaChi = @DiaChi, Gmail = @Gmail, ChuanDoan = @ChuanDoan
                            WHERE MaKham = @MaKham;

                            INSERT INTO LichSuKham (Lan, Dieutri, Bacsi, Chuandoan, MaKham) 
                            VALUES (1, @dichVu, @BacSi, @ChuanDoan, @MaKham);

                            UPDATE LichSuKham
                            SET Lan = Lan + 1
                            WHERE MaKham = @MaKham"; // Cập nhật số lần khám

                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                // Thêm các tham số cho bảng BenhNhan và LichSuKham
                                updateCommand.Parameters.AddWithValue("@Ho", ho);
                                updateCommand.Parameters.AddWithValue("@Ten", ten);
                                updateCommand.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                                updateCommand.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                                updateCommand.Parameters.AddWithValue("@SDT", sdt);
                                updateCommand.Parameters.AddWithValue("@DiaChi", diaChi);
                                updateCommand.Parameters.AddWithValue("@Gmail", gmail);
                                updateCommand.Parameters.AddWithValue("@MaKham", maKham);
                                updateCommand.Parameters.AddWithValue("@ChuanDoan", chuanDoan);
                                updateCommand.Parameters.AddWithValue("@BacSi", bacSi);
                                updateCommand.Parameters.AddWithValue("@DichVu", dichVu); // Các thông tin về dịch vụ

                                // Thực thi lệnh
                                int rowsAffected = updateCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Cập nhật hồ sơ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    clearInputs();
                                }
                                else
                                {
                                    MessageBox.Show("Không thể cập nhật hồ sơ, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hoặc cập nhật hồ sơ: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
