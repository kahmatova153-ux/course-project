using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WatchRepairApp.Forms
{
    public partial class MainForm : Form
    {
        // === ДАННЫЕ ТЕКУЩЕГО ПОЛЬЗОВАТЕЛЯ ===
        private string userRole;
        private string userName;
        private int userID;

        // === КОНСТРУКТОР ===
        public MainForm(string role, string name, int uid)
        {
            userRole = role;
            userName = name;
            userID = uid;

            InitializeComponent();
            ApplyRolePermissions();
        }

        // === НАСТРОЙКА ПРАВ ДОСТУПА ===
        private void ApplyRolePermissions()
        {
            // Устанавливаем заголовок окна
            this.Text = $"Мастерская «Точное время» - {userRole}: {userName}";

            // Настройка доступа по ролям
            switch (userRole)
            {
                case "Менеджер":
                    // Менеджер: прием заказов, работа с клиентами, просмотр отчетов
                    btnSettings.Visible = false;
                    btnMyOrders.Visible = false;
                    lblRoleInfo.Text = "Доступ: приём заказов, клиенты, отчёты";
                    break;

                case "Мастер":
                    // Мастер: только свои заказы и склад
                    btnClients.Visible = false;
                    btnReports.Visible = false;
                    btnSettings.Visible = false;
                    btnNewOrder.Visible = false;
                    btnNewClient.Visible = false;
                    btnSearchOrder.Visible = false;
                    lblQuickActions.Visible = false;
                    lblRoleInfo.Text = "Доступ: мои заказы, склад запчастей";
                    break;

                case "Администратор":
                    // Админ: полный доступ
                    btnMyOrders.Visible = false;
                    lblRoleInfo.Text = "Доступ: полный (администрирование)";
                    break;
            }

            // Загружаем статистику
            UpdateStats();
        }

        // === ОБНОВЛЕНИЕ СТАТИСТИКИ ===
        private void UpdateStats()
        {
            try
            {
                // Новые заказы за сегодня (статус "Принят" и дата сегодня)
                string queryNew = @"SELECT COUNT(*) FROM Orders o
                    JOIN OrderStatuses os ON o.StatusID = os.StatusID
                    WHERE os.StatusName = 'Принят' 
                    AND CAST(o.AcceptDate AS DATE) = CAST(GETDATE() AS DATE)";

                // Заказы в работе (статусы "В работе", "В диагностике")
                string queryInWork = @"SELECT COUNT(*) FROM Orders o
                       JOIN OrderStatuses os ON o.StatusID = os.StatusID
                       WHERE os.StatusName IN ('В работе', 'В диагностике')";

                // Готовые к выдаче (статус "Готов")
                string queryReady = @"SELECT COUNT(*) FROM Orders o
                      JOIN OrderStatuses os ON o.StatusID = os.StatusID
                      WHERE os.StatusName = 'Готов'";

                int newOrders = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryNew) ?? 0);
                int inWork = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryInWork) ?? 0);
                int ready = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryReady) ?? 0);

                lblNewOrders.Text = $"📥 Новых сегодня: {newOrders}";
                lblInWork.Text = $"🔧 В работе: {inWork}";
                lblReady.Text = $"✅ Готовых к выдаче: {ready}";

                // Цветовая индикация
                lblNewOrders.ForeColor = newOrders > 0 ? Color.DarkBlue : Color.Gray;
                lblInWork.ForeColor = inWork > 0 ? Color.DarkOrange : Color.Gray;
                lblReady.ForeColor = ready > 0 ? Color.DarkGreen : Color.Gray;
            }
            catch
            {
                lblNewOrders.Text = "📥 Новых сегодня: --";
                lblInWork.Text = "🔧 В работе: --";
                lblReady.Text = "✅ Готовых к выдаче: --";
            }
        }

        // === ОБРАБОТЧИКИ КНОПОК ===

        private void btnOrders_Click(object sender, EventArgs e)
        {
            // Все пользователи(включая мастера) видят все заказы при нажатии на "Заказы"
    OrdersForm ordersForm = new OrdersForm(userRole, userName, userID, OrdersViewMode.All);
            OpenForm(ordersForm);
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm();
            OpenForm(clientsForm);
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            WarehouseForm warehouseForm = new WarehouseForm();
            OpenForm(warehouseForm);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            OpenForm(reportsForm);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            OrderEditForm form = new OrderEditForm(userRole, userName, userID);
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateStats();
            }
        }

        private void btnNewClient_Click(object sender, EventArgs e)
        {
            ClientEditForm form = new ClientEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // Можно обновить статистику если нужно
            }
        }

        // УЛУЧШЕННЫЙ ПОИСК ЗАКАЗА
        private void btnSearchOrder_Click(object sender, EventArgs e)
        {
            using (SearchOrderDialog dialog = new SearchOrderDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK && dialog.OrderFound)
                {
                    // Открываем найденный заказ для редактирования
                    string query = "SELECT OrderNumber FROM Orders WHERE OrderID = @OrderID";
                    object result = DatabaseHelper.ExecuteScalar(query,
                        new SqlParameter("@OrderID", dialog.FoundOrderID));

                    if (result != null)
                    {
                        string orderNumber = result.ToString();
                        OrderEditForm form = new OrderEditForm(userRole, userName, userID, orderNumber);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            UpdateStats();
                        }
                    }
                }
            }
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            // При нажатии на "Мои заказы" показываем только заказы текущего мастера
            OrdersForm ordersForm = new OrdersForm(userRole, userName, userID, OrdersViewMode.MyOnly);
            OpenForm(ordersForm);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из программы?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateStats();
            MessageBox.Show("Статистика обновлена!", "Обновление",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // === ВСПОМОГАТЕЛЬНЫЙ МЕТОД ===
        private void OpenForm(Form form)
        {
            panelContent.Controls.Clear();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;

            panelContent.Controls.Add(form);
            form.Show();
        }
    }
}