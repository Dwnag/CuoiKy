using System;
using System.Windows.Forms;

namespace DangNhap
{
    internal class BackToMenu
    {
        public static void back(Form currentForm)
        {
            Menu1 menu = new Menu1();
            menu.Show();
            currentForm.Hide();
        }
    }
}
