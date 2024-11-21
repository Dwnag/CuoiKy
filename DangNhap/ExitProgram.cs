using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public static class FormEventHandler
    {
        public static void exitProgram(Form form)
        {
            form.FormClosing += (sender, e) =>
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát chương trình?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true; 
                }
                else
                {
                    Application.Exit(); 
                }
            };
        }
    }
}
