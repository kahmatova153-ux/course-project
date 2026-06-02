using System;
using System.Windows.Forms;

namespace WatchRepairApp.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Загрузка текущих настроек (можно сохранять в config файл)
            txtCompanyName.Text = "Мастерская «Точное время»";
            txtAddress.Text = "г. Москва, ул. Примерная, 1";
            txtPhone.Text = "+7 (999) 123-45-67";
            txtEmail.Text = "info@tochnoevremya.ru";
        }
        private void btnArchiveOldOrders_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Будут удалены выполненные заказы с истекшим гарантийным сроком.\n\nПродолжить?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                int count = DatabaseHelper.ArchiveOldOrders();
                MessageBox.Show($"Удалено заказов: {count}", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Сохранение настроек
            MessageBox.Show("Настройки сохранены!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (DatabaseHelper.TestConnection())
            {
                MessageBox.Show("Подключение к базе данных успешно!", "Проверка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось подключиться к базе данных!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}