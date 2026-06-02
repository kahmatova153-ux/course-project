using System;
using System.Windows.Forms;
using WatchRepairApp.Forms;  

namespace WatchRepairApp
{
    internal static class Program
    {
        [STAThread] 
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!DatabaseHelper.TestConnection())
            {
                MessageBox.Show(
                    "Не удалось подключиться к базе данных!\n\n" +
                    "Проверьте:\n" +
                    "1. Запущен ли SQL Server\n" +
                    "2. Правильность строки подключения в DatabaseHelper.cs\n" +
                    "3. Существует ли база данных WatchRepairDB\n\n" +
                    "Строка подключения: " + DatabaseHelper.GetConnection().ConnectionString,
                    "Ошибка подключения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return; 
            }

            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm(
                        loginForm.CurrentUserRole,      
                        loginForm.CurrentUserName,      
                        loginForm.CurrentUserID));     
                }
            }
        }
    }
}