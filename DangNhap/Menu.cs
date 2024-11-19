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
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //PhanQuyen();
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

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

