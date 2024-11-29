using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class Nhap : Form
    {
        private string connectionString = "Data Source=LAPTOP-B36E7179\\SQLEXPRESS;Initial Catalog=qlpk;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public Nhap()
        {
            InitializeComponent();
            LoadData();  // Load dữ liệu ban đầu cho các DataGridView
            ConfigureComboBoxColumns();
            ConfigureComboBoxColumnsThuoc();  // Gọi để thêm ComboBox cho thuốc

            dataGridView_Nhap_VatTuDungCu.CellValueChanged += DataGridView_CellValueChanged;
            dataGridView_Nhap_VatTuThuoc.CellValueChanged += DataGridView_Nhap_VatTuThuoc_CellValueChanged;

            dataGridView_Nhap_VatTuDungCu.EditingControlShowing += DataGridView_Nhap_VatTuDungCu_EditingControlShowing;
            dataGridView_Nhap_VatTuThuoc.EditingControlShowing += DataGridView_Nhap_VatTuThuoc_EditingControlShowing;
        }


        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewCell currentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            // Kiểm tra ô "TriGia" hoặc "GiaBan"
            if (currentCell.OwningColumn.Name == "TriGia" || currentCell.OwningColumn.Name == "GiaBan")
            {
                if (!decimal.TryParse(currentCell.Value?.ToString(), out decimal _))
                {
                    MessageBox.Show("Chỉ được nhập số cho trường này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    currentCell.Value = null;
                }
            }
            // Kiểm tra ô "SoLuong"
            else if (currentCell.OwningColumn.Name == "SoLuong")
            {
                if (!int.TryParse(currentCell.Value?.ToString(), out int _))
                {
                    MessageBox.Show("Chỉ được nhập số nguyên cho trường này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    currentCell.Value = null;
                }
            }

            // Sau khi thay đổi giá trị, tính lại tổng chi phí
            CalculateTotalCost();
        }


        private void CalculateTotalCost()
        {
            decimal totalCost = 0;

            // Tính tổng chi phí từ vật liệu
            foreach (DataGridViewRow row in dataGridView_Nhap_VatTuDungCu.Rows)
            {
                if (decimal.TryParse(row.Cells["TriGia"].Value?.ToString(), out decimal triGia) &&
                    int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out int soLuong))
                {
                    totalCost += triGia * soLuong;
                }
            }

            // Tính tổng chi phí từ thuốc
            foreach (DataGridViewRow row in dataGridView_Nhap_VatTuThuoc.Rows)
            {
                if (decimal.TryParse(row.Cells["GiaBan"].Value?.ToString(), out decimal giaBan) &&
                    int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out int soLuong))
                {
                    totalCost += giaBan * soLuong;
                }
            }

            // Hiển thị tổng chi phí lên textbox
            txtTongChi.Text = totalCost.ToString("N2");
        }




        private void LoadData()
        {
            DataTable dtVatLieu = CreateVatLieuTable();
            dataGridView_Nhap_VatTuDungCu.DataSource = dtVatLieu;
            dataGridView_Nhap_VatTuDungCu.Columns["MaVatLieu"].Visible = false;

            DataTable dtThuoc = CreateThuocTable();
            dataGridView_Nhap_VatTuThuoc.DataSource = dtThuoc;
            dataGridView_Nhap_VatTuThuoc.Columns["MaThuoc"].Visible = false;

            txtTongChi.Text = "0";
        }

        private DataTable CreateVatLieuTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaVatLieu", typeof(string));
            dt.Columns.Add("TenVatLieu", typeof(string));
            dt.Columns.Add("MauSac", typeof(string));
            dt.Columns.Add("KichCo", typeof(string));
            dt.Columns.Add("DVT", typeof(string));
            dt.Columns.Add("TriGia", typeof(decimal));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("GhiChu", typeof(string));
            dt.Columns.Add("LoaiVatLieu", typeof(string));
            dt.Columns.Add("HanSuDung", typeof(DateTime));
            return dt;
        }

        private DataTable CreateThuocTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaThuoc", typeof(string));
            dt.Columns.Add("TenThuoc", typeof(string));
            dt.Columns.Add("DVT", typeof(string));
            dt.Columns.Add("GiaBan", typeof(decimal));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("HamLuong", typeof(string));
            dt.Columns.Add("GhiChu", typeof(string));
            dt.Columns.Add("LoaiThuoc", typeof(string));
            dt.Columns.Add("HanSuDung", typeof(DateTime));
            return dt;
        }

        private void ConfigureComboBoxColumns()
        {
            // Remove existing ComboBox column if it exists
            if (dataGridView_Nhap_VatTuDungCu.Columns["ChonVatLieu"] != null)
                dataGridView_Nhap_VatTuDungCu.Columns.Remove("ChonVatLieu");

            // Add ComboBox column
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn
            {
                Name = "ChonVatLieu",
                HeaderText = "Chọn Vật Liệu",
                DataSource = GetVatLieuListFromDatabase(), // Load material names
                DisplayMember = "TenVatLieu",
                ValueMember = "TenVatLieu",
                FlatStyle = FlatStyle.Flat
            };

            dataGridView_Nhap_VatTuDungCu.Columns.Insert(0, comboBoxColumn); // Insert at the first position
        }



        private void ConfigureDataGridViewColumns()
        {
            // Cột Tên Vật Liệu (TextBoxColumn)
            DataGridViewTextBoxColumn tenVatLieuColumn = new DataGridViewTextBoxColumn
            {
                Name = "TenVatLieu",
                HeaderText = "Tên Vật Liệu",
                ReadOnly = false
            };

            // Cột Chọn Vật Liệu (ComboBoxColumn)
            DataGridViewComboBoxColumn chonVatLieuColumn = new DataGridViewComboBoxColumn
            {
                Name = "ChonVatLieu",
                HeaderText = "Chọn Vật Liệu",
                DataSource = GetVatLieuListFromDatabase(),
                DisplayMember = "TenVatLieu",
                ValueMember = "TenVatLieu",
                FlatStyle = FlatStyle.Flat
            };

            // Thêm các cột vào DataGridView
            dataGridView_Nhap_VatTuDungCu.Columns.AddRange(tenVatLieuColumn, chonVatLieuColumn);

            // Gắn sự kiện thay đổi giá trị của ComboBox
            dataGridView_Nhap_VatTuDungCu.CellValueChanged += DataGridView_Nhap_VatTuDungCu_CellValueChanged;
            dataGridView_Nhap_VatTuDungCu.EditingControlShowing += DataGridView_Nhap_VatTuDungCu_EditingControlShowing;
        }

        private void DataGridView_Nhap_VatTuDungCu_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView_Nhap_VatTuDungCu.CurrentCell.OwningColumn.Name == "ChonVatLieu" && e.Control is ComboBox comboBox)
            {
                // Remove any previously added event handlers
                comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu sender là ComboBox và đảm bảo rằng có item được chọn
            if (sender is ComboBox comboBox && comboBox.SelectedItem != null)
            {
                string selectedValue = comboBox.SelectedValue?.ToString();
                int rowIndex = dataGridView_Nhap_VatTuDungCu.CurrentCell.RowIndex;

                // Cập nhật dữ liệu cho vật liệu (nếu có)
                if (!string.IsNullOrEmpty(selectedValue) && rowIndex >= 0)
                {
                    UpdateVatLieuRow(dataGridView_Nhap_VatTuDungCu.Rows[rowIndex], selectedValue);
                }

                // Lấy thông tin thuốc từ cơ sở dữ liệu
                string selectedThuoc = comboBox.SelectedItem.ToString();
                DataRow thuocInfo = GetThuocInfo(selectedThuoc);

                // Cập nhật thông tin thuốc vào dòng hiện tại của DataGridView Thuoc
                if (thuocInfo != null)
                {
                    DataGridViewRow currentRow = dataGridView_Nhap_VatTuThuoc.CurrentRow;
                    if (currentRow != null)
                    {
                        currentRow.Cells["DVT"].Value = thuocInfo["DVT"].ToString();
                        currentRow.Cells["GiaBan"].Value = thuocInfo["GiaBan"];
                        currentRow.Cells["HamLuong"].Value = thuocInfo["HamLuong"].ToString();
                        currentRow.Cells["LoaiThuoc"].Value = thuocInfo["LoaiThuoc"].ToString();
                        currentRow.Cells["HanSuDung"].Value = thuocInfo["HanSuDung"];
                    }
                }

                // Làm mới lại giao diện DataGridView Thuoc
                dataGridView_Nhap_VatTuThuoc.Invalidate();  // Yêu cầu vẽ lại DataGridView Thuoc
            }
        }




        private DataTable GetVatLieuListFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TenVatLieu FROM VatLieu";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Thêm tùy chọn "Vật liệu mới" vào đầu danh sách
                DataRow newRow = dataTable.NewRow();
                newRow["TenVatLieu"] = "Vật liệu mới";
                dataTable.Rows.InsertAt(newRow, 0);

                return dataTable;
            }
        }

        private void DataGridView_Nhap_VatTuDungCu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView_Nhap_VatTuDungCu.Columns[e.ColumnIndex].Name == "ChonVatLieu")
            {
                var selectedValue = dataGridView_Nhap_VatTuDungCu.Rows[e.RowIndex].Cells["ChonVatLieu"].Value?.ToString();
                var currentRow = dataGridView_Nhap_VatTuDungCu.Rows[e.RowIndex];

                if (!string.IsNullOrEmpty(selectedValue))
                {
                    // Lấy thông tin vật liệu từ cơ sở dữ liệu hoặc danh sách
                    var vatLieuInfo = GetVatLieuInfo(selectedValue);

                    if (vatLieuInfo != null)
                    {
                        currentRow.Cells["TenVatLieu"].Value = vatLieuInfo.TenVatLieu;
                        currentRow.Cells["MauSac"].Value = vatLieuInfo.MauSac;
                        currentRow.Cells["KichCo"].Value = vatLieuInfo.KichCo;
                        currentRow.Cells["DVT"].Value = vatLieuInfo.DVT;
                        currentRow.Cells["TriGia"].Value = vatLieuInfo.TriGia;
                        currentRow.Cells["SoLuong"].Value = vatLieuInfo.SoLuong;
                        currentRow.Cells["GhiChu"].Value = vatLieuInfo.GhiChu;
                        currentRow.Cells["LoaiVatLieu"].Value = vatLieuInfo.LoaiVatLieu;
                        currentRow.Cells["HanSuDung"].Value = vatLieuInfo.HanSuDung;
                    }
                }
            }
        }

        private void UpdateVatLieuRow(DataGridViewRow row, string tenVatLieu)
        {
            var vatLieu = GetVatLieuInfo(tenVatLieu);
            if (vatLieu != null)
            {
                row.Cells["TenVatLieu"].Value = vatLieu.TenVatLieu;
                row.Cells["MauSac"].Value = vatLieu.MauSac;
                row.Cells["KichCo"].Value = vatLieu.KichCo;
                row.Cells["DVT"].Value = vatLieu.DVT;
                row.Cells["GhiChu"].Value = vatLieu.GhiChu;
                row.Cells["LoaiVatLieu"].Value = vatLieu.LoaiVatLieu;
                row.Cells["HanSuDung"].Value = vatLieu.HanSuDung;
                row.Cells["TriGia"].Value = vatLieu.TriGia; // Example: Price
                row.Cells["SoLuong"].Value = vatLieu.SoLuong; // Example: Quantity
            }
        }

        private dynamic GetVatLieuInfo(string tenVatLieu)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM VatLieu WHERE TenVatLieu = @TenVatLieu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenVatLieu", tenVatLieu);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new
                    {
                        TenVatLieu = reader["TenVatLieu"], // Fetch auto-generated ID
                        MauSac = reader["MauSac"],
                        KichCo = reader["KichCo"],
                        DVT = reader["DVT"],
                        GhiChu = reader["GhiChu"],
                        LoaiVatLieu = reader["LoaiVatLieu"],
                        HanSuDung = reader["HanSuDung"],
                        TriGia = reader["TriGia"], // Price
                        SoLuong = reader["SoLuong"] // Quantity
                    };
                }
                return null;
            }
        }


        private void UpdateThuocRow(DataGridViewRow row, string tenThuoc)
        {
            DataRow thuoc = GetThuocInfo(tenThuoc);
            if (thuoc != null)
            {
                row.Cells["TenThuoc"].Value = thuoc["TenThuoc"].ToString();
                row.Cells["DVT"].Value = thuoc["DVT"].ToString();
                row.Cells["GiaBan"].Value = Convert.ToDecimal(thuoc["GiaBan"]);
                row.Cells["HamLuong"].Value = thuoc["HamLuong"].ToString();
                row.Cells["GhiChu"].Value = thuoc["GhiChu"].ToString();
                row.Cells["LoaiThuoc"].Value = thuoc["LoaiThuoc"].ToString();
                row.Cells["HanSuDung"].Value = Convert.ToDateTime(thuoc["HanSuDung"]);
            }
        }


        private DataRow GetThuocInfo(string tenThuoc)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Thuoc WHERE TenThuoc = @TenThuoc";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@TenThuoc", tenThuoc);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
            }
            return null; // Không có dữ liệu
        }


        private void DataGridView_Nhap_VatTuThuoc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView_Nhap_VatTuThuoc.Columns[e.ColumnIndex].Name == "ChonThuoc")
            {
                var selectedValue = dataGridView_Nhap_VatTuThuoc.Rows[e.RowIndex].Cells["ChonThuoc"].Value?.ToString();
                var currentRow = dataGridView_Nhap_VatTuThuoc.Rows[e.RowIndex];

                if (!string.IsNullOrEmpty(selectedValue))
                {
                    UpdateThuocRow(currentRow, selectedValue);
                }
            }
        }

        private void DataGridView_Nhap_VatTuThuoc_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView_Nhap_VatTuThuoc.CurrentCell.OwningColumn.Name == "ChonThuoc" && e.Control is ComboBox comboBox)
            {
                comboBox.SelectedIndexChanged -= ComboBoxThuoc_SelectedIndexChanged;
                comboBox.SelectedIndexChanged += ComboBoxThuoc_SelectedIndexChanged;
            }
        }

        private void ComboBoxThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                string selectedValue = comboBox.SelectedItem?.ToString();
                int rowIndex = dataGridView_Nhap_VatTuThuoc.CurrentCell.RowIndex;

                if (!string.IsNullOrEmpty(selectedValue) && rowIndex >= 0)
                {
                    UpdateThuocRow(dataGridView_Nhap_VatTuThuoc.Rows[rowIndex], selectedValue);
                }
            }
        }

        private void ConfigureComboBoxColumnsThuoc()
        {
            if (dataGridView_Nhap_VatTuThuoc.Columns["ChonThuoc"] != null)
                dataGridView_Nhap_VatTuThuoc.Columns.Remove("ChonThuoc");

            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn
            {
                Name = "ChonThuoc",
                HeaderText = "Chọn Thuốc",
                DataSource = GetThuocListFromDatabase(),
                DisplayMember = "TenThuoc",
                ValueMember = "TenThuoc",
                FlatStyle = FlatStyle.Flat
            };

            dataGridView_Nhap_VatTuThuoc.Columns.Insert(0, comboBoxColumn); // Thêm ComboBox cột vào đầu tiên
        }

        private DataTable GetThuocListFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TenThuoc FROM Thuoc";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Thêm tùy chọn "Thuốc mới"
                DataRow newRow = dataTable.NewRow();
                newRow["TenThuoc"] = "Thuốc mới";
                dataTable.Rows.InsertAt(newRow, 0);

                return dataTable;
            }
        }


        private void UpdateVatLieu(string tenVatLieu, string mauSac, string kichCo, string dvt, decimal triGia, int soLuong, string ghiChu, string loaiVatLieu, DateTime hanSuDung)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Câu truy vấn để cộng dồn số lượng
                string query = @"
            UPDATE VatLieu 
            SET 
                MauSac = @MauSac, 
                KichCo = @KichCo, 
                DVT = @DVT, 
                TriGia = @TriGia, 
                SoLuong = SoLuong + @SoLuong, -- Cộng dồn số lượng
                GhiChu = @GhiChu, 
                LoaiVatLieu = @LoaiVatLieu, 
                HanSuDung = @HanSuDung
            WHERE TenVatLieu = @TenVatLieu";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@TenVatLieu", tenVatLieu);
                cmd.Parameters.AddWithValue("@MauSac", (object)mauSac ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@KichCo", (object)kichCo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DVT", (object)dvt ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TriGia", triGia);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong); // Số lượng nhập vào
                cmd.Parameters.AddWithValue("@GhiChu", (object)ghiChu ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LoaiVatLieu", (object)loaiVatLieu ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HanSuDung", hanSuDung);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateThuoc(string tenThuoc, string dvt, int soLuong, decimal giaBan, string hamLuong, string ghiChu, string loaiThuoc, DateTime hanSuDung)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Câu truy vấn để cộng dồn số lượng khi cập nhật thuốc
                string query = @"
            UPDATE Thuoc 
            SET 
                TenThuoc = @TenThuoc, 
                DVT = @DVT, 
                SoLuong = @SoLuong + @SoLuong, 
                GiaBan = @GiaBan, 
                HamLuong = @HamLuong, 
                GhiChu = @GhiChu, 
                LoaiThuoc = @LoaiThuoc, 
                HanSuDung = @HanSuDung 
            WHERE TenThuoc = @TenThuoc";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@TenThuoc", tenThuoc);
                cmd.Parameters.AddWithValue("@DVT", (object)dvt ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                cmd.Parameters.AddWithValue("@HamLuong", (object)hamLuong ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@GhiChu", (object)ghiChu ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LoaiThuoc", (object)loaiThuoc ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HanSuDung", hanSuDung);

                // Mở kết nối và thực thi câu lệnh
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Hàm thêm mới vật liệu
        private void AddNewVatLieu(string tenVatLieu, string mauSac, string kichCo, string dvt, decimal triGia, int soLuong, string ghiChu, string loaiVatLieu, DateTime hanSuDung)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // SQL query to call the GenerateMaVatLieu function and insert a new record
                string query = @"
        INSERT INTO VatLieu (MaVatLieu, TenVatLieu, MauSac, KichCo, DVT, TriGia, SoLuong, GhiChu, LoaiVatLieu, HanSuDung)
        VALUES (dbo.GenerateMaVatLieu(), @TenVatLieu, @MauSac, @KichCo, @DVT, @TriGia, @SoLuong, @GhiChu, @LoaiVatLieu, @HanSuDung)";

                // Creating SqlCommand and adding parameters
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenVatLieu", tenVatLieu);
                cmd.Parameters.AddWithValue("@MauSac", mauSac ?? (object)DBNull.Value);  // Handle null values
                cmd.Parameters.AddWithValue("@KichCo", kichCo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DVT", dvt ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TriGia", triGia);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@LoaiVatLieu", loaiVatLieu ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@HanSuDung", hanSuDung);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void AddNewThuoc(string tenThuoc, string dvt, int soLuong, decimal giaBan, string hamLuong, string ghiChu, string loaiThuoc, DateTime hanSuDung)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
INSERT INTO Thuoc (MaThuoc, TenThuoc, DVT, SoLuong, GiaBan, HamLuong, GhiChu, LoaiThuoc, HanSuDung) 
VALUES (dbo.GenerateMaVatLieu(), @TenThuoc, @DVT, @SoLuong, @GiaBan, @HamLuong, @GhiChu, @LoaiThuoc, @HanSuDung)";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@TenThuoc", tenThuoc);
                cmd.Parameters.AddWithValue("@DVT", (object)dvt ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                cmd.Parameters.AddWithValue("@HamLuong", (object)hamLuong ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@GhiChu", (object)ghiChu ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LoaiThuoc", (object)loaiThuoc ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HanSuDung", hanSuDung);

                // Mở kết nối và thực thi câu lệnh
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView_Nhap_VatTuDungCu.Rows)
                {
                    if (row.IsNewRow) continue;

                    string tenVatLieu = row.Cells["TenVatLieu"].Value?.ToString();
                    string mauSac = row.Cells["MauSac"].Value?.ToString();
                    string kichCo = row.Cells["KichCo"].Value?.ToString();
                    string dvt = row.Cells["DVT"].Value?.ToString();
                    decimal triGia = row.Cells["TriGia"].Value != null ? Convert.ToDecimal(row.Cells["TriGia"].Value) : 0;
                    int soLuong = row.Cells["SoLuong"].Value != null ? Convert.ToInt32(row.Cells["SoLuong"].Value) : 0;
                    string ghiChu = row.Cells["GhiChu"].Value?.ToString();
                    string loaiVatLieu = row.Cells["LoaiVatLieu"].Value?.ToString();
                    DateTime hanSuDung = row.Cells["HanSuDung"].Value != null ? Convert.ToDateTime(row.Cells["HanSuDung"].Value) : DateTime.Now;

                    if (tenVatLieu == "Vật liệu mới" || string.IsNullOrWhiteSpace(tenVatLieu))
                    {
                        MessageBox.Show("Hãy nhập tên vật liệu mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!IsNameExistsInDatabase("VatLieu", "TenVatLieu", tenVatLieu))
                    {
                        AddNewVatLieu(tenVatLieu, mauSac, kichCo, dvt, triGia, soLuong, ghiChu, loaiVatLieu, hanSuDung);
                    }
                    else
                    {
                        UpdateVatLieu(tenVatLieu, mauSac, kichCo, dvt, triGia, soLuong, ghiChu, loaiVatLieu, hanSuDung);
                    }
                }

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVatLieuDataIntoComboBox();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadVatLieuDataIntoComboBox()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT TenVatLieu FROM VatLieu"; // Lấy tên vật liệu từ bảng

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        List<string> vatLieuList = new List<string>();

                        while (reader.Read())
                        {
                            vatLieuList.Add(reader["TenVatLieu"].ToString());
                        }

                        if (dataGridView_Nhap_VatTuDungCu.Columns["TenVatLieu"] is DataGridViewComboBoxColumn comboBoxColumn)
                        {
                            comboBoxColumn.DataSource = vatLieuList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                foreach (DataGridViewRow row in dataGridView_Nhap_VatTuThuoc.Rows)
                {
                    if (row.IsNewRow) continue;

                    string tenThuoc = row.Cells["TenThuoc"].Value?.ToString();
                    string dvt = row.Cells["DVT"].Value?.ToString();
                    int soLuong = row.Cells["SoLuong"].Value != null ? Convert.ToInt32(row.Cells["SoLuong"].Value) : 0;
                    decimal giaBan = row.Cells["GiaBan"].Value != null ? Convert.ToDecimal(row.Cells["GiaBan"].Value) : 0;
                    string hamLuong = row.Cells["HamLuong"].Value?.ToString();
                    string ghiChu = row.Cells["GhiChu"].Value?.ToString();
                    string loaiThuoc = row.Cells["LoaiThuoc"].Value?.ToString();
                    DateTime hanSuDung = row.Cells["HanSuDung"].Value != null ? Convert.ToDateTime(row.Cells["HanSuDung"].Value) : DateTime.Now;

                    if (string.IsNullOrWhiteSpace(tenThuoc))
                    {
                        MessageBox.Show("Hãy chọn hoặc nhập tên thuốc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!IsNameExistsInDatabase("Thuoc", "TenThuoc", tenThuoc))
                    {
                        AddNewThuoc(tenThuoc, dvt, soLuong, giaBan, hamLuong, ghiChu, loaiThuoc, hanSuDung);
                    }
                    else
                    {
                        UpdateThuoc(tenThuoc, dvt, soLuong, giaBan, hamLuong, ghiChu, loaiThuoc, hanSuDung);
                    }
                }

                MessageBox.Show("Cập nhật thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kiểm tra tên có tồn tại trong cơ sở dữ liệu
        private bool IsNameExistsInDatabase(string tableName, string columnName, string name)
        {
            // Ensure tableName and columnName are not null or empty
            if (string.IsNullOrWhiteSpace(tableName))
                throw new ArgumentException("Table name cannot be null or empty.", nameof(tableName));
            if (string.IsNullOrWhiteSpace(columnName))
                throw new ArgumentException("Column name cannot be null or empty.", nameof(columnName));

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @Name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
