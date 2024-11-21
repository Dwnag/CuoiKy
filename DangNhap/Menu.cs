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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            //khởi động giao diện tại vị trí xác định
            this.StartPosition = FormStartPosition.CenterScreen;
            //dừng chương trình khi nhấn x
            FormEventHandler.exitProgram(this);
        }

        private void menu_Load(object sender, EventArgs e)
        {
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn đăng xuất.", "Đăng xuất", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }


        //void PhanQuyen()
        //{
        //    // Đặt mặc định tất cả các quyền là false
        //    btnLeTan.Enabled = false;
        //    btnBacSi.Enabled = false;
        //    btnThongKe.Enabled = false;
        //    btnQuanLyKho.Enabled = false;
        //    btnChuPhongKham.Enabled = false;
        //    btnHeThong.Enabled = false;
        //    btnDangXuat.Enabled = true;

        //    // Phân quyền theo loại tài khoản
        //    switch (Const.TaiKhoan.LoaiTaiKhoan)
        //    {
        //        case TaiKhoan.loaiTK.letan:
        //            btnLeTan.Enabled = true;
        //            break;

        //        case TaiKhoan.loaiTK.bacsi:
        //            btnBacSi.Enabled = true;
        //            break;

        //        case TaiKhoan.loaiTK.quanlykho:
        //            btnQuanLyKho.Enabled = true;
        //            break;

        //        case TaiKhoan.loaiTK.chuphongkham:
        //            btnLeTan.Enabled = true;
        //            btnBacSi.Enabled = true;
        //            btnThongKe.Enabled = true;
        //            btnQuanLyKho.Enabled = true;
        //            btnHeThong.Enabled = true;
        //            btnChuPhongKham.Enabled = true;
        //            break;

        //        default:
        //            MessageBox.Show("Loại tài khoản không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            break;
        //    }
        //}

    }
}

