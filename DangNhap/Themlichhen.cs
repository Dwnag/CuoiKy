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
            DateTime ngayHen = Ngayhen.Value;
            string dichVu = dichvutxt.Text.Trim();
            string khungGio = khunggio.Text.Trim();
            string bacSi = Bacsi.SelectedItem?.ToString() ?? string.Empty;

            // Kiểm tra dữ liệu đầu vào
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

                    // Kiểm tra sự tồn tại của MaKham trong bảng LichHen
                    string checkQuery = "SELECT COUNT(1) FROM LichHen WHERE MaKham = @MaKham";

                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MaKham", maKham);
                        int recordCount = (int)checkCommand.ExecuteScalar();

                        if (recordCount == 0)
                        {
                            // Nếu MaKham chưa tồn tại, thêm mới
                            string insertQuery = @"
                        INSERT INTO LichHen 
                        (TenBS, Khoa, Ngayhen, Phong, MaKham, GioHen, Chuandoan, Ho, Ten, NgaySinh, GioiTinh, SDT, DiaChi, Gmail) 
                        VALUES 
                        (@TenBS, @Khoa, @NgayHen, @Phong, @MaKham, @GioHen, @Chuandoan, @Ho, @Ten, @NgaySinh, @GioiTinh, @SDT, @DiaChi, @Gmail)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@TenBS", bacSi);
                                insertCommand.Parameters.AddWithValue("@Khoa", dichVu);
                                insertCommand.Parameters.AddWithValue("@NgayHen", ngayHen);
                                insertCommand.Parameters.AddWithValue("@Phong", "P001"); // Phòng giả định
                                insertCommand.Parameters.AddWithValue("@MaKham", maKham);
                                insertCommand.Parameters.AddWithValue("@GioHen", khungGio);
                                insertCommand.Parameters.AddWithValue("@Chuandoan", chuanDoan);
                                insertCommand.Parameters.AddWithValue("@Ho", ho);
                                insertCommand.Parameters.AddWithValue("@Ten", ten);
                                insertCommand.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                                insertCommand.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                                insertCommand.Parameters.AddWithValue("@SDT", sdt);
                                insertCommand.Parameters.AddWithValue("@DiaChi", diaChi);
                                insertCommand.Parameters.AddWithValue("@Gmail", gmail);

                                int rowsAffected = insertCommand.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Thêm lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    clearInputs();
                                }
                                else
                                {
                                    MessageBox.Show("Không thể thêm lịch hẹn, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            // Nếu MaKham đã tồn tại, cập nhật
                            string updateQuery = @"
                        UPDATE LichHen 
                        SET TenBS = @TenBS, Khoa = @Khoa, Ngayhen = @NgayHen, Phong = @Phong, GioHen = @GioHen, Chuandoan = @Chuandoan,
                            Ho = @Ho, Ten = @Ten, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, SDT = @SDT, DiaChi = @DiaChi, Gmail = @Gmail
                        WHERE MaKham = @MaKham";

                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@TenBS", bacSi);
                                updateCommand.Parameters.AddWithValue("@Khoa", dichVu);
                                updateCommand.Parameters.AddWithValue("@NgayHen", ngayHen);
                                updateCommand.Parameters.AddWithValue("@Phong", "P001"); // Phòng giả định
                                updateCommand.Parameters.AddWithValue("@MaKham", maKham);
                                updateCommand.Parameters.AddWithValue("@GioHen", khungGio);
                                updateCommand.Parameters.AddWithValue("@Chuandoan", chuanDoan);
                                updateCommand.Parameters.AddWithValue("@Ho", ho);
                                updateCommand.Parameters.AddWithValue("@Ten", ten);
                                updateCommand.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                                updateCommand.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                                updateCommand.Parameters.AddWithValue("@SDT", sdt);
                                updateCommand.Parameters.AddWithValue("@DiaChi", diaChi);
                                updateCommand.Parameters.AddWithValue("@Gmail", gmail);

                                int rowsAffected = updateCommand.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Cập nhật lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    clearInputs();
                                }
                                else
                                {
                                    MessageBox.Show("Không thể cập nhật lịch hẹn, vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hoặc cập nhật lịch hẹn: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //tự động điền
        private void autowrite()
        {
            string maKham = Makham.Text.Trim();

            // Nếu ô nhập mã khám trống thì không làm gì
            if (string.IsNullOrEmpty(maKham))
            {
                return;
            }

            try
            {
                string connectionString = "Data Source=localhost;Initial Catalog=ql1;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Kiểm tra nếu MaKham đã tồn tại trong bảng BenhNhan
                    string query = @"
                    SELECT Ho, Ten, NgaySinh, GioiTinh, SDT, DiaChi, Gmail 
                    FROM BenhNhan 
                    WHERE MaKham = @MaKham";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaKham", maKham);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Điền dữ liệu từ kết quả truy vấn
                                Hotxt.Text = reader["Ho"].ToString();
                                tentxt.Text = reader["Ten"].ToString();
                                Ngaysinh.Value = Convert.ToDateTime(reader["NgaySinh"]);
                                string gioiTinh = reader["GioiTinh"].ToString();
                                nam.Checked = gioiTinh == "Nam";
                                nữ.Checked = gioiTinh == "Nữ";
                                sdttxt.Text = reader["SDT"].ToString();
                                diachitxt.Text = reader["DiaChi"].ToString();
                                gmailtxt.Text = reader["Gmail"].ToString();

                             
                            }
                            else
                            {
                                // Nếu không tìm thấy MaKham, xóa trắng các trường
                                clearInputs();
                                MessageBox.Show("Không tìm thấy thông tin mã khám, vui lòng nhập mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra mã khám: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Makham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                autowrite();
                e.Handled = true;
                e.SuppressKeyPress = false;
            }
        }
    }
}
