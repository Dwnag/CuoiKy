using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DangNhap
{
    public class TaiKhoan
    {
        private string tenTaiKhoan;
        private string matKhau;
        private loaiTK loaiTaiKhoan;

        public enum loaiTK
        {
            LT,
            QLK,
            CPK,
            BS
        }

        public TaiKhoan(string tenTaiKhoan, string matKhau, loaiTK loaiTaiKhoan)
        {
            this.tenTaiKhoan = tenTaiKhoan;
            this.matKhau = matKhau;
            this.loaiTaiKhoan = loaiTaiKhoan;
        }


        public string TenTaiKhoan
        {
            get => tenTaiKhoan;
            set => tenTaiKhoan = value;
        }
        public string MatKhau
        {
            get => matKhau;
            set => matKhau = value;
        }
        public loaiTK LoaiTaiKhoan
        {
            get => loaiTaiKhoan;
            set => loaiTaiKhoan = value;
        }
    }
}
