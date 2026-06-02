using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WatchRepairApp.Forms
{
    public partial class ClientEditForm : Form
    {
        private int? clientID = null;  // null = новый клиент
        private bool isEditMode = false;

        // Конструктор для нового клиента
        public ClientEditForm()
        {
            InitializeComponent();
            isEditMode = false;
            this.Text = "Новый клиент";
        }

        // Конструктор для редактирования
        public ClientEditForm(int id)
        {
            InitializeComponent();
            clientID = id;
            isEditMode = true;
            this.Text = "Редактирование клиента";
            LoadClientData();
        }

        private void LoadClientData()
        {
            string query = "SELECT * FROM Clients WHERE ClientID = @ClientID";
            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new SqlParameter("@ClientID", clientID));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtFullName.Text = row["FullName"].ToString();
                txtPhone.Text = row["Phone"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtAddress.Text = row["Address"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Введите телефон!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            try
            {
                if (isEditMode)
                {
                    // Обновление
                    string query = @"UPDATE Clients SET 
                        FullName = @FullName,
                        Phone = @Phone,
                        Email = @Email,
                        Address = @Address
                    WHERE ClientID = @ClientID";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@FullName", txtFullName.Text.Trim()),
                        new SqlParameter("@Phone", txtPhone.Text.Trim()),
                        new SqlParameter("@Email", txtEmail.Text.Trim()),
                        new SqlParameter("@Address", txtAddress.Text.Trim()),
                        new SqlParameter("@ClientID", clientID)
                    };

                    DatabaseHelper.ExecuteNonQuery(query, parameters);
                    MessageBox.Show("Клиент обновлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Создание
                    string query = @"INSERT INTO Clients (FullName, Phone, Email, Address)
                        VALUES (@FullName, @Phone, @Email, @Address);
                        SELECT SCOPE_IDENTITY();";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@FullName", txtFullName.Text.Trim()),
                        new SqlParameter("@Phone", txtPhone.Text.Trim()),
                        new SqlParameter("@Email", txtEmail.Text.Trim()),
                        new SqlParameter("@Address", txtAddress.Text.Trim())
                    };

                    object result = DatabaseHelper.ExecuteScalar(query, parameters);
                    if (result != null)
                    {
                        clientID = Convert.ToInt32(result);
                        MessageBox.Show("Клиент добавлен!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Разрешаем только буквы, пробелы и дефисы (для двойных фамилий)
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '-')
            {
                e.Handled = true; // Запрещаем ввод
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string email = txtEmail.Text.Trim();

            // Если поле пустое - не проверяем (email необязателен)
            if (string.IsNullOrEmpty(email))
            {
                txtEmail.BackColor = Color.White;
                return;
            }

            // Проверка формата email
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Введите корректный email адрес!\n\nПример: example@mail.ru",
                    "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.BackColor = Color.LightYellow;
                e.Cancel = true;  // Не даем уйти с поля
            }
            else
            {
                txtEmail.BackColor = Color.White;
            }
        }
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
    }
}