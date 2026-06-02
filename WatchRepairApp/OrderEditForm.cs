using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace WatchRepairApp.Forms
{
    public partial class OrderEditForm : Form
    {
        private string userRole;
        private string userName;
        private int userID;
        private string orderNumber;
        private bool isEditMode = false;
        private int currentOrderID = 0;

        // Конструктор для нового заказа
        public OrderEditForm(string role, string name, int uid)
        {
            userRole = role;
            userName = name;
            userID = uid;
            isEditMode = false;
            InitializeComponent();
            LoadDictionaries();
            GenerateOrderNumber();
            lblStatus.Text = "СТАТУС: НОВЫЙ";
            cmbStatus.SelectedItem = "Принят";
            dtpEstimated.Value = DateTime.Now.AddDays(7);
            lblTotal.Text = "ИТОГО: 0.00 ₽";
        }

        // Конструктор для редактирования
        public OrderEditForm(string role, string name, int uid, string orderNum)
        {
            userRole = role;
            userName = name;
            userID = uid;
            orderNumber = orderNum;
            isEditMode = true;
            InitializeComponent();
            LoadDictionaries();
            LoadOrderData();
        }

        private void LoadDictionaries()
        {
            // Типы часов
            DataTable watchTypes = DatabaseHelper.ExecuteQuery("SELECT TypeName FROM WatchTypes");
            cmbWatchType.Items.Clear();
            foreach (DataRow row in watchTypes.Rows)
                cmbWatchType.Items.Add(row["TypeName"]);
            if (cmbWatchType.Items.Count > 0) cmbWatchType.SelectedIndex = 0;

            // Типы механизмов
            DataTable mechTypes = DatabaseHelper.ExecuteQuery("SELECT MechanismName FROM MechanismTypes");
            cmbMechanism.Items.Clear();
            foreach (DataRow row in mechTypes.Rows)
                cmbMechanism.Items.Add(row["MechanismName"]);
            if (cmbMechanism.Items.Count > 0) cmbMechanism.SelectedIndex = 0;

            // Статусы
            DataTable statuses = DatabaseHelper.ExecuteQuery("SELECT StatusName FROM OrderStatuses");
            cmbStatus.Items.Clear();
            foreach (DataRow row in statuses.Rows)
                cmbStatus.Items.Add(row["StatusName"]);

            // Мастера
            DataTable masters = DatabaseHelper.ExecuteQuery("SELECT UserID, FullName FROM Users WHERE RoleID = 3 AND IsActive = 1");
            cmbMaster.Items.Clear();
            cmbMaster.Items.Add("Не назначен");
            foreach (DataRow row in masters.Rows)
                cmbMaster.Items.Add(row["FullName"]);
        }

        private void GenerateOrderNumber()
        {
            // Очень простой номер: 1, 2, 3...
            string query = "SELECT ISNULL(MAX(OrderID), 0) + 1 FROM Orders";
            object result = DatabaseHelper.ExecuteScalar(query);
            int nextNumber = result != null ? Convert.ToInt32(result) : 1;
            orderNumber = nextNumber.ToString();
            lblTitle.Text = $"ЗАКАЗ № {orderNumber}";
        }

        private void LoadOrderData()
        {
            string query = @"SELECT o.*, c.FullName as ClientName, c.Phone as ClientPhone, c.Email as ClientEmail,
                                     wt.TypeName, mt.MechanismName, u.FullName as MasterName, os.StatusName
                              FROM Orders o
                              JOIN Clients c ON o.ClientID = c.ClientID
                              JOIN WatchTypes wt ON o.WatchTypeID = wt.WatchTypeID
                              JOIN MechanismTypes mt ON o.MechanismTypeID = mt.MechanismTypeID
                              JOIN OrderStatuses os ON o.StatusID = os.StatusID
                              LEFT JOIN Users u ON o.MasterID = u.UserID
                              WHERE o.OrderNumber = @OrderNumber";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderNumber", orderNumber)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                currentOrderID = Convert.ToInt32(row["OrderID"]);

                // Клиент
                txtClientName.Text = row["ClientName"].ToString();
                ClientPhone.Text = row["ClientPhone"].ToString();
                txtClientEmail.Text = row["ClientEmail"].ToString();

                // Часы
                cmbWatchType.SelectedItem = row["TypeName"].ToString();
                cmbMechanism.SelectedItem = row["MechanismName"].ToString();
                txtBrand.Text = row["Brand"].ToString();
                txtModel.Text = row["Model"].ToString();
                txtSerial.Text = row["SerialNumber"].ToString();

                // Заказ
                txtDefect.Text = row["DefectDescription"].ToString();
                cmbStatus.SelectedItem = row["StatusName"].ToString();
                cmbMaster.SelectedItem = row["MasterName"] ?? "Не назначен";
                dtpEstimated.Value = row["EstimatedCompletionDate"] != DBNull.Value ?
                    Convert.ToDateTime(row["EstimatedCompletionDate"]) : DateTime.Now.AddDays(7);

                lblTitle.Text = $"ЗАКАЗ № {orderNumber}";
                lblStatus.Text = $"СТАТУС: {cmbStatus.SelectedItem}";
                lblTotal.Text = $"ИТОГО: {Convert.ToDecimal(row["RepairCost"]):N2} ₽";

                // Загрузка работ и запчастей из БД
                LoadOrderWorksAndParts();

                // Настройка прав доступа
                if (userRole == "Мастер")
                {
                    txtClientName.Enabled = false;
                    ClientPhone.Enabled = false;
                    txtClientEmail.Enabled = false;
                }
            }
        }

        // Загрузка работ и запчастей из БД
        private void LoadOrderWorksAndParts()
        {
            dgvWorks.Rows.Clear();
            decimal total = 0;

            // Загрузка работ
            string worksQuery = "SELECT WorkDescription, WorkCost FROM OrderWorks WHERE OrderID = @OrderID";
            DataTable worksDt = DatabaseHelper.ExecuteQuery(worksQuery, new SqlParameter("@OrderID", currentOrderID));

            foreach (DataRow row in worksDt.Rows)
            {
                decimal cost = Convert.ToDecimal(row["WorkCost"]);
                dgvWorks.Rows.Add(row["WorkDescription"], cost, "Работа", 1);
                total += cost;
            }

            // Загрузка запчастей
            string partsQuery = @"SELECT p.PartName, op.PriceAtTime, op.Quantity 
                                   FROM OrderParts op 
                                   JOIN Parts p ON op.PartID = p.PartID 
                                   WHERE op.OrderID = @OrderID";
            DataTable partsDt = DatabaseHelper.ExecuteQuery(partsQuery, new SqlParameter("@OrderID", currentOrderID));

            foreach (DataRow row in partsDt.Rows)
            {
                decimal price = Convert.ToDecimal(row["PriceAtTime"]);
                int qty = Convert.ToInt32(row["Quantity"]);
                decimal totalPrice = price * qty;
                dgvWorks.Rows.Add(row["PartName"], totalPrice, "Запчасть", qty);
                total += totalPrice;
            }

            UpdateTotal(total);
        }

        private void UpdateTotal(decimal amount)
        {
            lblTotal.Text = $"ИТОГО: {amount:N2} ₽";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClientName.Text))
            {
                MessageBox.Show("Укажите ФИО клиента!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbWatchType.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип часов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Получаем или создаем клиента
                int clientID = GetOrCreateClient();

                // Получаем ID типов
                int watchTypeID = GetID("WatchTypes", "TypeName", cmbWatchType.SelectedItem.ToString());
                int mechTypeID = GetID("MechanismTypes", "MechanismName", cmbMechanism.SelectedItem.ToString());
                int statusID = GetID("OrderStatuses", "StatusName", cmbStatus.SelectedItem.ToString());

                // Получаем ID мастера
                int? masterID = null;
                if (cmbMaster.SelectedItem != null && cmbMaster.SelectedItem.ToString() != "Не назначен")
                {
                    masterID = GetMasterID(cmbMaster.SelectedItem.ToString());
                }

                // Стоимость из таблицы работ
                decimal totalCost = CalculateTotal();

                if (isEditMode)
                {
                    // Обновление заказа
                    string updateQuery = @"UPDATE Orders SET 
                        ClientID = @ClientID, MasterID = @MasterID, WatchTypeID = @WatchTypeID,
                        MechanismTypeID = @MechanismTypeID, Brand = @Brand, Model = @Model,
                        SerialNumber = @Serial, DefectDescription = @Defect, StatusID = @StatusID,
                        EstimatedCompletionDate = @EstDate, RepairCost = @Cost, Notes = @Notes
                        WHERE OrderID = @OrderID";

                    SqlParameter[] updateParams = new SqlParameter[]
                    {
                        new SqlParameter("@ClientID", clientID),
                        new SqlParameter("@MasterID", (object)masterID ?? DBNull.Value),
                        new SqlParameter("@WatchTypeID", watchTypeID),
                        new SqlParameter("@MechanismTypeID", mechTypeID),
                        new SqlParameter("@Brand", txtBrand.Text),
                        new SqlParameter("@Model", txtModel.Text),
                        new SqlParameter("@Serial", txtSerial.Text),
                        new SqlParameter("@Defect", txtDefect.Text),
                        new SqlParameter("@StatusID", statusID),
                        new SqlParameter("@EstDate", dtpEstimated.Value),
                        new SqlParameter("@Cost", totalCost),
                        new SqlParameter("@Notes", ""),
                        new SqlParameter("@OrderID", currentOrderID)
                    };

                    DatabaseHelper.ExecuteNonQuery(updateQuery, updateParams);

                    // Сохраняем работы и запчасти в БД
                    SaveWorksAndParts(currentOrderID);

                    MessageBox.Show("Заказ обновлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Новый заказ
                    string insertQuery = @"INSERT INTO Orders (OrderNumber, ClientID, MasterID, WatchTypeID, 
                        MechanismTypeID, Brand, Model, SerialNumber, DefectDescription, StatusID, 
                        EstimatedCompletionDate, RepairCost, Notes)
                        VALUES (@OrderNumber, @ClientID, @MasterID, @WatchTypeID, @MechanismTypeID, 
                        @Brand, @Model, @Serial, @Defect, @StatusID, @EstDate, @Cost, @Notes);
                        SELECT SCOPE_IDENTITY();";

                    SqlParameter[] insertParams = new SqlParameter[]
                    {
                        new SqlParameter("@OrderNumber", orderNumber),
                        new SqlParameter("@ClientID", clientID),
                        new SqlParameter("@MasterID", (object)masterID ?? DBNull.Value),
                        new SqlParameter("@WatchTypeID", watchTypeID),
                        new SqlParameter("@MechanismTypeID", mechTypeID),
                        new SqlParameter("@Brand", txtBrand.Text),
                        new SqlParameter("@Model", txtModel.Text),
                        new SqlParameter("@Serial", txtSerial.Text),
                        new SqlParameter("@Defect", txtDefect.Text),
                        new SqlParameter("@StatusID", statusID),
                        new SqlParameter("@EstDate", dtpEstimated.Value),
                        new SqlParameter("@Cost", totalCost),
                        new SqlParameter("@Notes", "")
                    };

                    object newID = DatabaseHelper.ExecuteScalar(insertQuery, insertParams);
                    if (newID != null)
                    {
                        currentOrderID = Convert.ToInt32(newID);
                        // Сохраняем работы и запчасти
                        SaveWorksAndParts(currentOrderID);
                        MessageBox.Show($"Заказ {orderNumber} создан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Сохранение работ и запчастей в БД
        private void SaveWorksAndParts(int orderID)
        {
            // Удаляем старые записи
            DatabaseHelper.ExecuteNonQuery("DELETE FROM OrderWorks WHERE OrderID = @OrderID",
                new SqlParameter("@OrderID", orderID));
            DatabaseHelper.ExecuteNonQuery("DELETE FROM OrderParts WHERE OrderID = @OrderID",
                new SqlParameter("@OrderID", orderID));

            bool hasWorks = false;

            // Сохраняем новые
            foreach (DataGridViewRow row in dgvWorks.Rows)
            {
                if (row.Cells[0].Value == null) continue;

                string name = row.Cells[0].Value.ToString();
                decimal cost = Convert.ToDecimal(row.Cells[1].Value);
                string type = row.Cells[2].Value.ToString();
                int qty = row.Cells[3].Value != null ? Convert.ToInt32(row.Cells[3].Value) : 1;

                if (type == "Работа")
                {
                    hasWorks = true;
                    // Сохраняем работу - ТРИГГЕР сработает здесь!
                    string query = "INSERT INTO OrderWorks (OrderID, WorkDescription, WorkCost) VALUES (@OrderID, @Desc, @Cost)";
                    DatabaseHelper.ExecuteNonQuery(query,
                        new SqlParameter("@OrderID", orderID),
                        new SqlParameter("@Desc", name),
                        new SqlParameter("@Cost", cost));
                }
                else if (type == "Запчасть")
                {
                    // Ищем PartID по названию
                    DataTable dt = DatabaseHelper.ExecuteQuery("SELECT PartID FROM Parts WHERE PartName = @Name",
                        new SqlParameter("@Name", name));

                    if (dt.Rows.Count > 0)
                    {
                        int partID = Convert.ToInt32(dt.Rows[0]["PartID"]);
                        decimal unitPrice = cost / qty;

                        string query = "INSERT INTO OrderParts (OrderID, PartID, Quantity, PriceAtTime) VALUES (@OrderID, @PartID, @Qty, @Price)";
                        DatabaseHelper.ExecuteNonQuery(query,
                            new SqlParameter("@OrderID", orderID),
                            new SqlParameter("@PartID", partID),
                            new SqlParameter("@Qty", qty),
                            new SqlParameter("@Price", unitPrice));
                    }
                }
            }

            // Примечание: Триггер trg_UpdateOrderStatusOnWorkComplete уже сработал при вставке в OrderWorks
            // и автоматически обновил статус заказа если это был первый статус
        }


        // Вспомогательные методы
        private int GetOrCreateClient()
        {
            string findQuery = "SELECT ClientID FROM Clients WHERE Phone = @Phone";
            DataTable dt = DatabaseHelper.ExecuteQuery(findQuery, new SqlParameter("@Phone", ClientPhone.Text));

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["ClientID"]);

            string insertQuery = @"INSERT INTO Clients (FullName, Phone, Email, Address) 
                                   VALUES (@FullName, @Phone, @Email, @Address);
                                   SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FullName", txtClientName.Text),
                new SqlParameter("@Phone", ClientPhone.Text),
                new SqlParameter("@Email", txtClientEmail.Text),
                new SqlParameter("@Address", "")
            };

            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(insertQuery, parameters));
        }

        private int GetID(string table, string column, string value)
        {
            string query = $"SELECT * FROM {table} WHERE {column} = @Value";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@Value", value));
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0][0]);
            throw new Exception($"Не найдено значение '{value}' в таблице {table}");
        }

        private int GetMasterID(string fullName)
        {
            string query = "SELECT UserID FROM Users WHERE FullName = @Name AND RoleID = 3";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@Name", fullName));
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["UserID"]);
            return 0;
        }

        private decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvWorks.Rows)
            {
                if (row.Cells[1].Value != null)
                    total += Convert.ToDecimal(row.Cells[1].Value);
            }
            return total;
        }

        // === ОБРАБОТЧИКИ КНОПОК ===

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ИСПРАВЛЕННОЕ добавление работы - через нормальную форму
        private void btnAddWork_Click(object sender, EventArgs e)
        {
            // Открываем форму добавления работы
            using (AddWorkForm form = new AddWorkForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Добавляем в DataGridView
                    dgvWorks.Rows.Add(form.WorkDescription, form.WorkCost, "Работа", 1);
                    UpdateTotal(CalculateTotal());

                    // ВАЖНО: Триггер trg_UpdateOrderStatusOnWorkComplete сработает автоматически
                    // при сохранении заказа, когда мы добавим запись в OrderWorks
                    // Но мы можем предупредить пользователя о смене статуса

                    if (cmbStatus.SelectedItem?.ToString() == "Принят" || cmbStatus.SelectedItem?.ToString() == "В диагностике")
                    {
                        lblStatus.Text = "СТАТУС: БУДЕТ ИЗМЕНЁН НА 'В РАБОТЕ' (автоматически)";
                        lblStatus.ForeColor = Color.DarkOrange;
                    }
                }
            }
        }

        // ИСПРАВЛЕННОЕ добавление запчасти - выбор из склада
        private void btnAddPart_Click(object sender, EventArgs e)
        {
            // Открываем форму выбора запчасти со склада
            using (SelectPartForm form = new SelectPartForm())
            {
                if (form.ShowDialog() == DialogResult.OK && form.SelectedPartID > 0)
                {
                    // Получаем данные о запчасти
                    DataTable dt = DatabaseHelper.ExecuteQuery(
                        "SELECT PartName, SellingPrice FROM Parts WHERE PartID = @PartID",
                        new SqlParameter("@PartID", form.SelectedPartID));

                    if (dt.Rows.Count > 0)
                    {
                        string partName = dt.Rows[0]["PartName"].ToString();
                        decimal price = Convert.ToDecimal(dt.Rows[0]["SellingPrice"]);
                        int qty = form.Quantity;
                        decimal total = price * qty;

                        dgvWorks.Rows.Add(partName, total, "Запчасть", qty);
                        UpdateTotal(CalculateTotal());
                    }
                }
            }
        }


        private void txtClientEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string email = txtClientEmail.Text.Trim();

            // Если поле пустое - не проверяем (email необязателен)
            if (string.IsNullOrEmpty(email))
            {
                txtClientEmail.BackColor = Color.White;
                return;
            }

            // Проверка формата email
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Введите корректный email адрес!\n\nПример: example@mail.ru",
                    "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClientEmail.BackColor = Color.LightYellow;
                e.Cancel = true;  // Не даем уйти с поля
            }
            else
            {
                txtClientEmail.BackColor = Color.White;
            }
        }

        // Проверка формата email
        private bool IsValidEmail(string email)
        {
            try
            {
                // Простая проверка через регулярное выражение
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private void ClientPhone_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string phone = ClientPhone.Text.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

            // Проверка: телефон должен содержать 11 цифр (начиная с +7 или 8)
            if (phone.Length < 11)
            {
                MessageBox.Show("Введите полный номер телефона!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void gbClient_Enter(object sender, EventArgs e)
        {

        }

        private void txtClientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            // Только буквы, пробелы и дефисы для ФИО
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
    }
}