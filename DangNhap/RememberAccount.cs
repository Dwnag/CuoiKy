using System;
using System.IO;
using System.Windows.Forms;

namespace DangNhap
{
    public static class AccountManager
    {
        public static void saveAccountInfo(string username, string password)
        {
            Properties.Settings.Default.User = username;
            Properties.Settings.Default.Password = password;
            Properties.Settings.Default.Save();
        }

        public static void clearAccountInfo()
        {
            Properties.Settings.Default.User = string.Empty;
            Properties.Settings.Default.Password = string.Empty;
            Properties.Settings.Default.Save();
        }

        public static bool isAccountSaved()
        {
            return !string.IsNullOrEmpty(Properties.Settings.Default.User) &&
                   !string.IsNullOrEmpty(Properties.Settings.Default.Password);
        }

        public static (string Username, string Password) getSavedAccountInfo()
        {
            return (Properties.Settings.Default.User, Properties.Settings.Default.Password);
        }
    }

}
