using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WatchRepairApp.Forms
{
    public partial class SearchOrderDialog : Form
    {
        public string SearchText { get; private set; }
        public int FoundOrderID { get; private set; }
        public bool OrderFound { get; private set; }

        public SearchOrderDialog()
        {
            InitializeComponent();
            OrderFound = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(SearchText))
            {
                MessageBox.Show("Введите номер заказа или телефон клиента!",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ищем заказ по номеру или телефону клиента
            if (SearchOrder())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool SearchOrder()
        {
            // Поиск по номеру заказа (поддержка форматов: "З-001" или "1")
            string searchNumber = SearchText.Trim();

            // Если ввели только цифры - добавляем префикс З-
            if (System.Text.RegularExpressions.Regex.IsMatch(searchNumber, @"^\d+$"))
            {
                searchNumber = $"З-{int.Parse(searchNumber):D3}";
            }

            string queryByNumber = @"SELECT o.OrderID, o.OrderNumber, c.FullName, c.Phone
                            FROM Orders o
                            JOIN Clients c ON o.ClientID = c.ClientID
                            WHERE o.OrderNumber = @Search";

            DataTable dt = DatabaseHelper.ExecuteQuery(queryByNumber,
                new SqlParameter("@Search", searchNumber));

            if (dt.Rows.Count > 0)
            {
                FoundOrderID = Convert.ToInt32(dt.Rows[0]["OrderID"]);
                OrderFound = true;
                return true;
            }

            // Поиск по телефону клиента
            string queryByPhone = @"SELECT TOP 1 o.OrderID, o.OrderNumber, c.FullName, c.Phone
                           FROM Orders o
                           JOIN Clients c ON o.ClientID = c.ClientID
                           WHERE c.Phone LIKE @Search
                           ORDER BY o.AcceptDate DESC";

            dt = DatabaseHelper.ExecuteQuery(queryByPhone,
                new SqlParameter("@Search", "%" + SearchText + "%"));

            if (dt.Rows.Count > 0)
            {
                FoundOrderID = Convert.ToInt32(dt.Rows[0]["OrderID"]);
                string orderNumber = dt.Rows[0]["OrderNumber"].ToString();
                string clientName = dt.Rows[0]["FullName"].ToString();

                DialogResult result = MessageBox.Show(
                    $"Найден заказ {orderNumber}\nКлиент: {clientName}\n\nОткрыть этот заказ?",
                    "Заказ найден", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    OrderFound = true;
                    return true;
                }
                return false;
            }

            MessageBox.Show("Заказ не найден!\n\nПроверьте:\n- Номер заказа (например: З-001 или просто 1)\n- Телефон клиента",
                "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}