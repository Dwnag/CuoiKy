using MyApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class Menu1 : Form
    {
        public Menu1()
        {
            InitializeComponent();
            //dừng chương trình khi nhấn x
            this.FormClosing += (sender, e) => FormCloseHandler.exitProgram(this, e);
        }
        private void quanly_Click(object sender, EventArgs e)
        {

        }

        void PhanQuyen()
        {
            if (Const.TaiKhoan == null)
            {
                MessageBox.Show("Không xác định được tài khoản hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Đóng form nếu không có thông tin tài khoản
                return;
            }

            // Từ điển ánh xạ loại tài khoản với các nút được phép sử dụng
            Dictionary<TaiKhoan.loaiTK, List<Button>> phanQuyenMap = new Dictionary<TaiKhoan.loaiTK, List<Button>>()
    {
        { TaiKhoan.loaiTK.LT, new List<Button> { btnLetan } },
        { TaiKhoan.loaiTK.BS, new List<Button> { btnBacsi } },
        { TaiKhoan.loaiTK.QLK, new List<Button> { btnNhapxuatvattu } },
        { TaiKhoan.loaiTK.CPK, new List<Button> { btnLetan, btnBacsi, btnNhapxuatvattu, btnChuphongkham, btnThongke } }
    };

            // Đặt mặc định tất cả các nút là không hoạt động
            var allButtons = new List<Button> { btnLetan, btnBacsi, btnNhapxuatvattu, btnChuphongkham, btnMenu, btnQuanly, btnThongke, btnDangxuat };
            foreach (var button in allButtons)
            {
                button.Enabled = false;
            }

            // Luôn bật các nút mặc định như Menu và Đăng xuất
            btnMenu.Enabled = true;
            btnDangxuat.Enabled = true;

            // Kích hoạt các nút dựa trên loại tài khoản
            if (phanQuyenMap.ContainsKey(Const.TaiKhoan.LoaiTaiKhoan))
            {
                foreach (var button in phanQuyenMap[Const.TaiKhoan.LoaiTaiKhoan])
                {
                    button.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Loại tài khoản không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn đăng xuất", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                DangNhap f1 = new DangNhap();
                f1.Show();
                this.Hide();
            }

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menu1_Load(object sender, EventArgs e)
        {
            updateButtonColors(btnMenu);
            PhanQuyen();
        }
        private void menu_Click(object sender, EventArgs e)
        {

        }

        private void btnBacsi_Click(object sender, EventArgs e)
        {
            Bacsi bacsi = new Bacsi();
            bacsi.Show();
            this.Hide();
        }

        private void btnChuphongkham_Click(object sender, EventArgs e)
        {
            ChuPhongKham chuPhongKham = new ChuPhongKham();
            chuPhongKham.Show();
            this.Hide();
        }

        private void btnNhapxuatvattu_Click_1(object sender, EventArgs e)
        {
            NhanVienKho nhanVienKho = new NhanVienKho();
            nhanVienKho.Show();
            this.Hide();
        }

        private void btnLetan_Click(object sender, EventArgs e)
        {
            LeTan leTan = new LeTan();
            leTan.Show();
            this.Hide();
        }
        private void updateButtonColors(Button activeButton)
        {
            foreach (var button in new List<Button> { btnMenu, btnQuanly, btnThongke })
            {
                // Màu mặc định
                button.BackColor = Color.White;
                button.ForeColor = Color.Black;
            }

            // Đổi màu cho nút hiện tại
            activeButton.BackColor = Color.Gray;
            activeButton.ForeColor = Color.Black;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            updateButtonColors(btnMenu);
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            updateButtonColors(btnQuanly);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            updateButtonColors(btnThongke);
        }

    }
}
