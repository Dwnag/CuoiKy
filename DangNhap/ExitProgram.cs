using System;
using System.Windows.Forms;

namespace MyApp.Utilities
{
    public static class FormCloseHandler
    {
        private static bool isMessageBoxShown = false;

        public static void exitProgram(Form form, FormClosingEventArgs e)
        {
            if (!isMessageBoxShown)
            {
                isMessageBoxShown = true;

                DialogResult result = MessageBox.Show(
                    "Bạn muốn đóng phần mềm?",
                    "Xác nhận đóng",
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
            }
        }
    }
}
