using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class NhapXuatVatTu : Form
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=ql1;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public NhapXuatVatTu()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Load dữ liệu cho bảng Vật liệu
                SqlDataAdapter vatTuAdapter = new SqlDataAdapter("SELECT * FROM VatLieu", connection);
                DataTable vatTuTable = new DataTable();
                vatTuAdapter.Fill(vatTuTable);
                dataGridView_VatTuDungCu.DataSource = vatTuTable;

                // Thêm cột checkbox và khóa cột MaVatLieu
                AddCheckboxColumn(dataGridView_VatTuDungCu);
                dataGridView_VatTuDungCu.Columns["MaVatLieu"].ReadOnly = true;

                // Load dữ liệu cho bảng Thuốc
                SqlDataAdapter thuocAdapter = new SqlDataAdapter("SELECT * FROM Thuoc", connection);
                DataTable thuocTable = new DataTable();
                thuocAdapter.Fill(thuocTable);
                dataGridView_VatTuThuoc.DataSource = thuocTable;

                // Thêm cột checkbox và khóa cột MaThuoc
                AddCheckboxColumn(dataGridView_VatTuThuoc);
                dataGridView_VatTuThuoc.Columns["MaThuoc"].ReadOnly = true;
            }
        }

        private void AddCheckboxColumn(DataGridView dgv)
        {
            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Select",
                HeaderText = "Chọn",
                Width = 50
            };
            dgv.Columns.Insert(0, checkboxColumn);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Cập nhật bảng Vật liệu
                    SqlCommand updateVatLieuCmd = new SqlCommand(GenerateUpdateQuery("VatLieu"), connection);
                    foreach (DataGridViewRow row in dataGridView_VatTuDungCu.Rows)
                    {
                        if (row.IsNewRow) continue;

                        updateVatLieuCmd.Parameters.Clear();
                        updateVatLieuCmd.Parameters.AddWithValue("@MaVatLieu", row.Cells["MaVatLieu"].Value);
                        updateVatLieuCmd.Parameters.AddWithValue("@TenVatLieu", row.Cells["TenVatLieu"].Value ?? DBNull.Value);
                        updateVatLieuCmd.Parameters.AddWithValue("@MauSac", row.Cells["MauSac"].Value ?? DBNull.Value);
                        updateVatLieuCmd.Parameters.AddWithValue("@KichCo", row.Cells["KichCo"].Value ?? DBNull.Value);
                        updateVatLieuCmd.Parameters.AddWithValue("@DVT", row.Cells["DVT"].Value ?? DBNull.Value);
                        updateVatLieuCmd.Parameters.AddWithValue("@TriGia", row.Cells["TriGia"].Value ?? DBNull.Value);
                        updateVatLieuCmd.Parameters.AddWithValue("@SoLuong", row.Cells["SoLuong"].Value ?? DBNull.Value);
                        updateVatLieuCmd.Parameters.AddWithValue("@GhiChu", row.Cells["GhiChu"].Value ?? DBNull.Value);
                        updateVatLieuCmd.Parameters.AddWithValue("@LoaiVatLieu", row.Cells["LoaiVatLieu"].Value ?? DBNull.Value);
                        updateVatLieuCmd.Parameters.AddWithValue("@HanSuDung", row.Cells["HanSuDung"].Value ?? DBNull.Value);

                        updateVatLieuCmd.ExecuteNonQuery();
                    }

                    // Cập nhật bảng Thuốc
                    SqlCommand updateThuocCmd = new SqlCommand(GenerateUpdateQuery("Thuoc"), connection);
                    foreach (DataGridViewRow row in dataGridView_VatTuThuoc.Rows)
                    {
                        if (row.IsNewRow) continue;

                        updateThuocCmd.Parameters.Clear();
                        updateThuocCmd.Parameters.AddWithValue("@MaThuoc", row.Cells["MaThuoc"].Value);
                        updateThuocCmd.Parameters.AddWithValue("@TenThuoc", row.Cells["TenThuoc"].Value ?? DBNull.Value);
                        updateThuocCmd.Parameters.AddWithValue("@DVT", row.Cells["DVT"].Value ?? DBNull.Value);
                        updateThuocCmd.Parameters.AddWithValue("@SoLuong", row.Cells["SoLuong"].Value ?? DBNull.Value);
                        updateThuocCmd.Parameters.AddWithValue("@GiaBan", row.Cells["GiaBan"].Value ?? DBNull.Value);
                        updateThuocCmd.Parameters.AddWithValue("@HamLuong", row.Cells["HamLuong"].Value ?? DBNull.Value);
                        updateThuocCmd.Parameters.AddWithValue("@GhiChu", row.Cells["GhiChu"].Value ?? DBNull.Value);
                        updateThuocCmd.Parameters.AddWithValue("@LoaiThuoc", row.Cells["LoaiThuoc"].Value ?? DBNull.Value);
                        updateThuocCmd.Parameters.AddWithValue("@HanSuDung", row.Cells["HanSuDung"].Value ?? DBNull.Value);

                        updateThuocCmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Bắt đầu giao dịch (Transaction) để đảm bảo tính nhất quán
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Tạo danh sách để lưu các dòng cần xóa trong bảng Vật liệu
                        List<DataGridViewRow> rowsToDeleteVatLieu = new List<DataGridViewRow>();
                        foreach (DataGridViewRow row in dataGridView_VatTuDungCu.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                            {
                                rowsToDeleteVatLieu.Add(row);
                            }
                        }

                        // Xóa các dòng đã chọn trong bảng Vật liệu
                        foreach (var row in rowsToDeleteVatLieu)
                        {
                            SqlCommand deleteCmd = new SqlCommand("DELETE FROM VatLieu WHERE MaVatLieu = @MaVatLieu", connection, transaction);
                            deleteCmd.Parameters.AddWithValue("@MaVatLieu", row.Cells["MaVatLieu"].Value);
                            deleteCmd.ExecuteNonQuery();
                            dataGridView_VatTuDungCu.Rows.Remove(row);
                        }

                        // Tạo danh sách để lưu các dòng cần xóa trong bảng Thuốc
                        List<DataGridViewRow> rowsToDeleteThuoc = new List<DataGridViewRow>();
                        foreach (DataGridViewRow row in dataGridView_VatTuThuoc.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                            {
                                rowsToDeleteThuoc.Add(row);
                            }
                        }

                        // Xóa các dòng đã chọn trong bảng Thuốc
                        foreach (var row in rowsToDeleteThuoc)
                        {
                            SqlCommand deleteCmd = new SqlCommand("DELETE FROM Thuoc WHERE MaThuoc = @MaThuoc", connection, transaction);
                            deleteCmd.Parameters.AddWithValue("@MaThuoc", row.Cells["MaThuoc"].Value);
                            deleteCmd.ExecuteNonQuery();
                            dataGridView_VatTuThuoc.Rows.Remove(row);
                        }

                        // Commit giao dịch
                        transaction.Commit();
                        MessageBox.Show("Xóa thành công!");
                    }
                    catch (Exception ex)
                    {
                        // Rollback nếu có lỗi
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private string GenerateUpdateQuery(string tableName)
        {
            if (tableName == "VatLieu")
            {
                return @"UPDATE VatLieu
                         SET TenVatLieu = @TenVatLieu, MauSac = @MauSac, KichCo = @KichCo, DVT = @DVT, 
                             TriGia = @TriGia, SoLuong = @SoLuong, GhiChu = @GhiChu, LoaiVatLieu = @LoaiVatLieu, HanSuDung = @HanSuDung
                         WHERE MaVatLieu = @MaVatLieu";
            }
            else if (tableName == "Thuoc")
            {
                return @"UPDATE Thuoc
                         SET TenThuoc = @TenThuoc, DVT = @DVT, SoLuong = @SoLuong, GiaBan = @GiaBan, 
                             HamLuong = @HamLuong, GhiChu = @GhiChu, LoaiThuoc = @LoaiThuoc, HanSuDung = @HanSuDung
                         WHERE MaThuoc = @MaThuoc";
            }
            return string.Empty;
        }

        // Phương thức để tải lại dữ liệu
        public void ReloadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM VatLieu"; // Hoặc câu lệnh SQL phù hợp
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView_VatTuDungCu.DataSource = dataTable; // dataGridView_VatTu là DataGridView của form NhapXuatVatTu

                    string query2 = "SELECT * FROM Thuoc"; // Hoặc câu lệnh SQL phù hợp
                    SqlDataAdapter adapter2 = new SqlDataAdapter(query2, conn);
                    DataTable dataTable2 = new DataTable();
                    adapter2.Fill(dataTable2);
                    dataGridView_VatTuThuoc.DataSource = dataTable2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nhap formNhap = new Nhap();
            formNhap.FormClosed += (s, args) =>
            {
                this.Show();
                ReloadData(); // Gọi lại phương thức ReloadData khi form Nhap đóng
            };
            formNhap.Show();
        }
    }
}
