using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WatchRepairApp.Forms
{
    public partial class ReportsForm : Form
    {
        
        public ReportsForm()
        {
            InitializeComponent();
            // Устанавливаем период по умолчанию - последние 30 дней
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            dtpTo.Value = DateTime.Now;
        }

        // Добавьте этот метод в класс ReportsForm
        private void ReportsForm_Resize(object sender, EventArgs e)
        {
            // Корректируем позицию итоговой строки
            lblSummary.Location = new Point(20, this.ClientSize.Height - 50);

            // Корректируем размеры таблицы
            dgvReport.Width = this.ClientSize.Width - 60;
            dgvReport.Height = this.ClientSize.Height - 310;

            // Корректируем ширину панели кнопок
            panelButtons.Width = this.ClientSize.Width - 60;

            // Позиция кнопки экспорта - всегда справа
            btnExport.Left = panelButtons.Width - btnExport.Width - 10;
        }

        // Отчет по заказам за период
        private void btnOrdersReport_Click(object sender, EventArgs e)
        {
            string query = @"SELECT 
                os.StatusName as 'Статус',
                COUNT(*) as 'Количество',
                SUM(ISNULL(o.RepairCost, 0)) as 'Сумма'
            FROM Orders o
            JOIN OrderStatuses os ON o.StatusID = os.StatusID
            WHERE CAST(o.AcceptDate AS DATE) BETWEEN @From AND @To
            GROUP BY os.StatusName
            ORDER BY COUNT(*) DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@From", dtpFrom.Value.Date),
                new SqlParameter("@To", dtpTo.Value.Date)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            dgvReport.DataSource = dt;

            // Подсчет итогов
            int totalCount = 0;
            decimal totalSum = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalCount += Convert.ToInt32(row["Количество"]);
                totalSum += Convert.ToDecimal(row["Сумма"]);
            }

            lblSummary.Text = $"Итого заказов: {totalCount}, на сумму: {totalSum:N2} ₽";
        }

        // Финансовый отчет (доходы и расходы)
        private void btnFinanceReport_Click(object sender, EventArgs e)
        {
            // Доходы от выполненных заказов (статусы 4-Готов, 5-Выдан)
            string incomeQuery = @"SELECT SUM(ISNULL(RepairCost, 0)) 
                FROM Orders 
                WHERE StatusID IN (4, 5) 
                AND CAST(AcceptDate AS DATE) BETWEEN @From AND @To";

            object incomeObj = DatabaseHelper.ExecuteScalar(incomeQuery,
                new SqlParameter("@From", dtpFrom.Value.Date),
                new SqlParameter("@To", dtpTo.Value.Date));

            decimal income = incomeObj != DBNull.Value && incomeObj != null
                ? Convert.ToDecimal(incomeObj) : 0;

            // Расходы
            string expenseQuery = @"SELECT SUM(ISNULL(Amount, 0)) 
                FROM Expenses 
                WHERE CAST(ExpenseDate AS DATE) BETWEEN @From AND @To";

            object expenseObj = DatabaseHelper.ExecuteScalar(expenseQuery,
                new SqlParameter("@From", dtpFrom.Value.Date),
                new SqlParameter("@To", dtpTo.Value.Date));

            decimal expenses = expenseObj != DBNull.Value && expenseObj != null
                ? Convert.ToDecimal(expenseObj) : 0;

            decimal profit = income - expenses;

            // Создаем таблицу для отображения
            DataTable dt = new DataTable();
            dt.Columns.Add("Показатель", typeof(string));
            dt.Columns.Add("Сумма", typeof(string));

            dt.Rows.Add("Доходы от заказов", $"{income:N2} ₽");
            dt.Rows.Add("Расходы", $"{expenses:N2} ₽");
            dt.Rows.Add("Прибыль", $"{profit:N2} ₽");

            dgvReport.DataSource = dt;

            // Цветовая индикация прибыли
            lblSummary.Text = profit >= 0
                ? $"Прибыль: {profit:N2} ₽"
                : $"Убыток: {Math.Abs(profit):N2} ₽";
            lblSummary.ForeColor = profit >= 0 ? System.Drawing.Color.DarkGreen : System.Drawing.Color.Crimson;
        }

        // Отчет по складу (критические остатки)
        private void btnStockReport_Click(object sender, EventArgs e)
        {
            string query = @"SELECT 
                p.PartName as 'Название',
                p.QuantityInStock as 'На складе',
                p.MinStockLevel as 'Мин. уровень',
                CASE 
                    WHEN p.QuantityInStock <= p.MinStockLevel THEN 'КРИТИЧЕСКИЙ'
                    WHEN p.QuantityInStock <= p.MinStockLevel * 1.5 THEN 'НИЗКИЙ'
                    ELSE 'НОРМА'
                END as 'Статус'
            FROM Parts p
            ORDER BY p.QuantityInStock";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            dgvReport.DataSource = dt;

            // Подсчет критических
            int critical = 0, low = 0, normal = 0;
            foreach (DataRow row in dt.Rows)
            {
                string status = row["Статус"].ToString();
                if (status == "КРИТИЧЕСКИЙ") critical++;
                else if (status == "НИЗКИЙ") low++;
                else normal++;
            }

            lblSummary.Text = $"Критических: {critical}, низких: {low}, норма: {normal}";
            lblSummary.ForeColor = System.Drawing.Color.Black;
        }

        // Отчет по мастерам (эффективность)
        private void btnMasterReport_Click(object sender, EventArgs e)
        {
            // Используем хранимую процедуру sp_GetMasterPerformanceReport
            // Используем простую процедуру
            DataTable dt = DatabaseHelper.GetOrderCounts(dtpFrom.Value, dtpTo.Value);
            dgvReport.DataSource = dt;

            // Подсчёт итого
            int total = 0;
            foreach (DataRow row in dt.Rows)
                total += Convert.ToInt32(row["OrderCount"]);

            lblSummary.Text = $"Всего заказов: {total}";
        }

        // Экспорт в CSV
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV files (*.csv)|*.csv";
            saveDialog.FileName = $"Report_{DateTime.Now:yyyyMMdd}.csv";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(saveDialog.FileName, false, System.Text.Encoding.UTF8))
                    {
                        // Заголовки
                        for (int i = 0; i < dgvReport.Columns.Count; i++)
                        {
                            writer.Write(dgvReport.Columns[i].HeaderText);
                            if (i < dgvReport.Columns.Count - 1) writer.Write(";");
                        }
                        writer.WriteLine();

                        // Данные
                        foreach (DataGridViewRow row in dgvReport.Rows)
                        {
                            for (int i = 0; i < dgvReport.Columns.Count; i++)
                            {
                                writer.Write(row.Cells[i].Value?.ToString() ?? "");
                                if (i < dgvReport.Columns.Count - 1) writer.Write(";");
                            }
                            writer.WriteLine();
                        }
                    }

                    MessageBox.Show($"Отчет сохранен: {saveDialog.FileName}", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка экспорта: " + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}