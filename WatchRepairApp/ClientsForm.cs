using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WatchRepairApp.Forms
{
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
            SetupGrid();
            LoadClients();
        }

        // Настройка таблицы
        private void SetupGrid()
        {
            dgvClients.Columns.Clear();
            dgvClients.Columns.Add("ClientID", "ID");
            dgvClients.Columns.Add("FullName", "ФИО");
            dgvClients.Columns.Add("Phone", "Телефон");
            dgvClients.Columns.Add("Email", "Email");
            dgvClients.Columns.Add("Address", "Адрес");
            dgvClients.Columns.Add("RegistrationDate", "Дата регистрации");

            dgvClients.Columns["ClientID"].Visible = false;  // Скрываем ID
            dgvClients.Columns["FullName"].Width = 150;
            dgvClients.Columns["Phone"].Width = 120;
            dgvClients.Columns["Email"].Width = 150;
            dgvClients.Columns["Address"].Width = 200;
            dgvClients.Columns["RegistrationDate"].Width = 150;

            dgvClients.ReadOnly = true;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Загрузка клиентов из БД
        private void LoadClients()
        {
            string query = "SELECT * FROM Clients ORDER BY RegistrationDate DESC";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            RefreshGrid(dt);
            lblTitle.Text = $"КЛИЕНТЫ ({dt.Rows.Count})";
        }

        // Обновление таблицы данными
        private void RefreshGrid(DataTable dt)
        {
            dgvClients.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dgvClients.Rows.Add(
                    row["ClientID"],
                    row["FullName"],
                    row["Phone"],
                    row["Email"],
                    row["Address"],
                    Convert.ToDateTime(row["RegistrationDate"]).ToString("dd.MM.yyyy HH:mm")
                );
            }
        }

        // Поиск клиентов - ИСПРАВЛЕННЫЙ
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();

            // Если поле пустое или placeholder - показываем всех клиентов
            if (string.IsNullOrEmpty(search) || search == "Поиск...")
            {
                LoadClients();
                return;
            }

            string query = @"SELECT * FROM Clients 
                            WHERE FullName LIKE @Search 
                            OR Phone LIKE @Search 
                            OR Email LIKE @Search
                            ORDER BY FullName";

            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new SqlParameter("@Search", "%" + search + "%"));

            RefreshGrid(dt);
            lblTitle.Text = $"КЛИЕНТЫ (найдено: {dt.Rows.Count})";
        }

        // Кнопка "Добавить"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClientEditForm form = new ClientEditForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadClients();
        }

        // Кнопка "Изменить"
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clientID = Convert.ToInt32(dgvClients.SelectedRows[0].Cells["ClientID"].Value);
            ClientEditForm form = new ClientEditForm(clientID);

            if (form.ShowDialog() == DialogResult.OK)
                LoadClients();
        }

        // Кнопка "Удалить"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clientID = Convert.ToInt32(dgvClients.SelectedRows[0].Cells["ClientID"].Value);
            string clientName = dgvClients.SelectedRows[0].Cells["FullName"].Value.ToString();

            // Проверяем, есть ли заказы у клиента
            string checkQuery = "SELECT COUNT(*) FROM Orders WHERE ClientID = @ClientID";
            int orderCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery,
                new SqlParameter("@ClientID", clientID)));

            if (orderCount > 0)
            {
                MessageBox.Show($"Нельзя удалить клиента {clientName}!\nУ него есть {orderCount} заказов.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Удалить клиента {clientName}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE FROM Clients WHERE ClientID = @ClientID";
                DatabaseHelper.ExecuteNonQuery(query, new SqlParameter("@ClientID", clientID));
                LoadClients();
            }
        }

        // Двойной клик - редактирование
        private void dgvClients_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        // Placeholder для поиска
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Поиск...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "Поиск...";
                txtSearch.ForeColor = System.Drawing.Color.Gray;
                // При уходе из поля возвращаем полный список
                LoadClients();
            }
        }
    }
}