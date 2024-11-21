using System;
using System.IO;

namespace DangNhap
{
    public static class AccountManager
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "account.txt");

        public static bool IsAccountSaved()
        {
            return File.Exists(filePath);
        }

        public static (string Username, string Password) GetSavedAccountInfo()
        {
            if (IsAccountSaved())
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length == 2)
                {
                    return (lines[0], lines[1]);
                }
            }
            return (string.Empty, string.Empty);
        }

        public static void SaveAccountInfo(string username, string password)
        {
            File.WriteAllLines(filePath, new[] { username, password });
        }

        public static void ClearAccountInfo()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
