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

namespace DangNhap
{
    public partial class Themlichhen : Form
    {
        public Themlichhen()
        {
            InitializeComponent();
            this.FormClosing += (sender, e) => FormCloseHandler.exitProgram(this, e);
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
            string ngayHen = ngayhentxt.Text.Trim();
            string dichVu = dichvutxt.Text.Trim();
            string khungGio = khunggiotxt.Text.Trim();
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
                // Chuỗi kết nối SQL Server
                string connectionString = "Data Source=localhost;Initial Catalog=ql1;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Appointments (Ho, Ten, NgaySinh, GioiTinh, SDT, DiaChi, Gmail, MaKham, 
                                                        ChuanDoan, NgayHen, DichVu, KhungGio, BacSi) 
                             VALUES (@Ho, @Ten, @NgaySinh, @GioiTinh, @SDT, @DiaChi, @Gmail, @MaKham, 
                                     @ChuanDoan, @NgayHen, @DichVu, @KhungGio, @BacSi)";

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
                        command.Parameters.AddWithValue("@NgayHen", ngayHen);
                        command.Parameters.AddWithValue("@DichVu", dichVu);
                        command.Parameters.AddWithValue("@KhungGio", khungGio);
                        command.Parameters.AddWithValue("@BacSi", bacSi);

                        // Thực thi lệnh
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm hồ sơ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs(); // Xóa trắng các trường sau khi thêm
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
        private void ClearInputs()
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
            ngayhentxt.Clear();
            dichvutxt.Clear();
            khunggiotxt.Clear();
            if (Bacsi.Items.Count > 0) Bacsi.SelectedIndex = -1;
        }

        private void Themlichhen_Load(object sender, EventArgs e)
        {
            List<string> danhSachBacSi = new List<string>
            {
                "Bác sĩ Nguyễn Văn Sáng",
                "Bác sĩ Trần Thị Huyền",
                "Bác sĩ Lê Văn Khánh",
                "Bác sĩ Phạm Thị Diệu   "
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
        }
    }
}
