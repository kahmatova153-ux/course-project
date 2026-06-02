using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WatchRepairApp.Forms
{
    public enum OrdersViewMode
    {
        All,           // Все заказы
        MyOnly,        // Только мои заказы
        MyAndUnassigned // Мои + неназначенные (для мастера при нажатии "Заказы")
    }

    public partial class OrdersForm : Form
    {
        private string userRole;
        private string userName;
        private int userID;
        private OrdersViewMode viewMode;

        public OrdersForm(string role, string name, int uid, OrdersViewMode mode = OrdersViewMode.All)
        {
            userRole = role;
            userName = name;
            userID = uid;
            viewMode = mode;
            InitializeComponent();
            LoadData();

            // Настройка прав доступа
            if (userRole == "Мастер")
            {
                btnDelete.Enabled = false;
                btnDelete.Visible = false;
            }
        }

        private void LoadData()
        {
            try
            {
                // Базовый SQL-запрос
                string query = @"
            SELECT 
                o.OrderID,
                o.OrderNumber,
                o.AcceptDate,
                c.FullName AS ClientName,
                c.Phone AS ClientPhone,
                wt.TypeName AS WatchType,
                mt.MechanismName AS MechanismType,
                o.Brand,
                o.Model,
                os.StatusName AS Status,
                o.RepairCost,
                u.FullName AS MasterName
            FROM Orders o
            JOIN Clients c ON o.ClientID = c.ClientID
            JOIN OrderStatuses os ON o.StatusID = os.StatusID
            LEFT JOIN WatchTypes wt ON o.WatchTypeID = wt.WatchTypeID
            LEFT JOIN MechanismTypes mt ON o.MechanismTypeID = mt.MechanismTypeID
            LEFT JOIN Users u ON o.MasterID = u.UserID
            WHERE CAST(o.AcceptDate AS DATE) BETWEEN @DateFrom AND @DateTo";

                // Добавляем фильтрацию в зависимости от режима просмотра
                switch (viewMode)
                {
                    case OrdersViewMode.MyOnly:
                        query += " AND o.MasterID = @UserID";
                        break;
                    case OrdersViewMode.MyAndUnassigned:
                        query += " AND (o.MasterID = @UserID OR o.MasterID IS NULL)";
                        break;
                    case OrdersViewMode.All:
                    default:
                        // Нет дополнительной фильтрации - видны все заказы
                        break;
                }

                // Поиск
                string searchText = txtSearch.Text.Trim();
                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@DateFrom", dtpFrom.Value.Date),
            new SqlParameter("@DateTo", dtpTo.Value.Date.AddDays(1).AddSeconds(-1)),
            new SqlParameter("@UserID", userID)  // ID текущего пользователя
        };

                if (!string.IsNullOrEmpty(searchText) && searchText != "Поиск по номеру, клиенту...")
                {
                    query += @" AND (o.OrderNumber LIKE @Search OR c.FullName LIKE @Search OR c.Phone LIKE @Search)";
                    parameters.Add(new SqlParameter("@Search", "%" + searchText + "%"));
                }

                query += " ORDER BY o.AcceptDate DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters.ToArray());

                dgvOrders.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int rowIndex = dgvOrders.Rows.Add(
                        row["OrderNumber"],
                        Convert.ToDateTime(row["AcceptDate"]).ToString("dd.MM.yyyy"),
                        row["ClientName"],
                        $"{row["WatchType"]} ({row["MechanismType"]})",
                        row["Brand"] + " " + row["Model"],
                        row["Status"],
                        Convert.ToDecimal(row["RepairCost"]).ToString("N2") + " ₽",
                        row["MasterName"] ?? "Не назначен"
                    );

                    // Цветовая индикация статусов
                    string status = row["Status"].ToString();
                    switch (status)
                    {
                        case "Готов":
                        case "Выдан":
                            dgvOrders.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "В работе":
                        case "В диагностике":
                            dgvOrders.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case "Принят":
                            dgvOrders.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                            break;
                        case "Отменен":
                            dgvOrders.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                            break;
                    }
                }

                lblTitle.Text = $"ЗАКАЗЫ НА РЕМОНТ ({dt.Rows.Count})";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Поиск по кнопке
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // Поиск при нажатии Enter в поле поиска
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadData();
                e.Handled = true; // Предотвращаем звук "бип"
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderEditForm form = new OrderEditForm(userRole, userName, userID);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                string orderNumber = dgvOrders.SelectedRows[0].Cells["colOrderNumber"].Value.ToString();
                OrderEditForm form = new OrderEditForm(userRole, userName, userID, orderNumber);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для редактирования!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                string orderNumber = dgvOrders.SelectedRows[0].Cells["colOrderNumber"].Value.ToString();

                if (MessageBox.Show($"Удалить заказ {orderNumber}?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = "DELETE FROM Orders WHERE OrderNumber = @OrderNumber";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@OrderNumber", orderNumber)
                    };

                    if (DatabaseHelper.ExecuteNonQuery(query, parameters) > 0)
                    {
                        MessageBox.Show("Заказ удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
        }

        private void dgvOrders_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        // Placeholder для поиска - очистка при входе
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Поиск по номеру, клиенту...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        // Placeholder для поиска - восстановление при выходе
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Поиск по номеру, клиенту...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}