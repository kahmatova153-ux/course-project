using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WatchRepairApp.Forms
{
    public partial class WarehouseForm : Form
    {
        public WarehouseForm()
        {
            InitializeComponent();
            LoadParts();
        }

        // Загрузка запчастей из БД
        private void LoadParts()
        {
            string query = @"SELECT 
                p.PartID,
                p.PartCode as 'Код',
                p.PartName as 'Название',
                pc.CategoryName as 'Категория',
                p.QuantityInStock as 'На складе',
                p.MinStockLevel as 'Мин. уровень',
                p.SellingPrice as 'Цена продажи',
                CASE 
                    WHEN p.QuantityInStock <= p.MinStockLevel THEN 'КРИТИЧЕСКИЙ'
                    WHEN p.QuantityInStock <= p.MinStockLevel * 1.5 THEN 'НИЗКИЙ'
                    ELSE 'НОРМА'
                END as 'Статус'
            FROM Parts p
            JOIN PartCategories pc ON p.CategoryID = pc.CategoryID
            ORDER BY p.PartName";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            dgvParts.DataSource = dt;

            // Скрываем ID
            if (dgvParts.Columns["PartID"] != null)
                dgvParts.Columns["PartID"].Visible = false;

            // Автоширина колонок
            dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Цвета применяются в событии CellFormatting для гарантированного отображения
        }

        // Обработчик события CellFormatting для цветовой индикации
        private void dgvParts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvParts.Columns["Статус"].Index && e.Value != null)
            {
                string status = e.Value.ToString();
                DataGridViewRow row = dgvParts.Rows[e.RowIndex];

                switch (status)
                {
                    case "КРИТИЧЕСКИЙ":
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                        break;
                    case "НИЗКИЙ":
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                        row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                        break;
                    default:
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                }
            }
        }

        // Поиск запчастей
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            if (search == "Поиск...") return;

            string query = @"SELECT 
                p.PartID,
                p.PartCode as 'Код',
                p.PartName as 'Название',
                pc.CategoryName as 'Категория',
                p.QuantityInStock as 'На складе',
                p.MinStockLevel as 'Мин. уровень',
                p.SellingPrice as 'Цена продажи',
                CASE 
                    WHEN p.QuantityInStock <= p.MinStockLevel THEN 'КРИТИЧЕСКИЙ'
                    WHEN p.QuantityInStock <= p.MinStockLevel * 1.5 THEN 'НИЗКИЙ'
                    ELSE 'НОРМА'
                END as 'Статус'
            FROM Parts p
            JOIN PartCategories pc ON p.CategoryID = pc.CategoryID
            WHERE p.PartName LIKE @Search OR p.PartCode LIKE @Search
            ORDER BY p.PartName";

            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new SqlParameter("@Search", "%" + search + "%"));

            dgvParts.DataSource = dt;
            // Цвета применяются автоматически через CellFormatting
        }

        // Кнопка "Добавить"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            PartEditForm form = new PartEditForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadParts();
        }

        // Кнопка "Изменить"
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvParts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запчасть!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int partID = Convert.ToInt32(dgvParts.SelectedRows[0].Cells["PartID"].Value);
            PartEditForm form = new PartEditForm(partID);

            if (form.ShowDialog() == DialogResult.OK)
                LoadParts();
        }

        // Кнопка "Удалить"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvParts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запчасть!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int partID = Convert.ToInt32(dgvParts.SelectedRows[0].Cells["PartID"].Value);
            string partName = dgvParts.SelectedRows[0].Cells["Название"].Value.ToString();

            // Проверяем, используется ли запчасть в заказах
            string checkQuery = "SELECT COUNT(*) FROM OrderParts WHERE PartID = @PartID";
            int usageCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery,
                new SqlParameter("@PartID", partID)));

            if (usageCount > 0)
            {
                MessageBox.Show($"Нельзя удалить {partName}!\\nОна используется в {usageCount} заказах.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Удалить запчасть {partName}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE FROM Parts WHERE PartID = @PartID";
                DatabaseHelper.ExecuteNonQuery(query, new SqlParameter("@PartID", partID));
                LoadParts();
            }
        }

        // Кнопка "Приход" (увеличение количества)
        private void btnAddStock_Click(object sender, EventArgs e)
        {
            if (dgvParts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запчасть!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int partID = Convert.ToInt32(dgvParts.SelectedRows[0].Cells["PartID"].Value);
            string partName = dgvParts.SelectedRows[0].Cells["Название"].Value.ToString();
            int currentQty = Convert.ToInt32(dgvParts.SelectedRows[0].Cells["На складе"].Value);

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Текущее количество: {currentQty}\n\nВведите количество для добавления:",
                $"Приход - {partName}", "0");

            if (!int.TryParse(input, out int addQty) || addQty <= 0)
            {
                MessageBox.Show("Введите корректное положительное число!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "UPDATE Parts SET QuantityInStock = QuantityInStock + @Qty WHERE PartID = @PartID";
            DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@Qty", addQty),
                new SqlParameter("@PartID", partID));

            LoadParts();
            MessageBox.Show($"Добавлено {addQty} шт. на склад!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Placeholder для поиска
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Поиск...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "Поиск...";
                txtSearch.ForeColor = Color.Gray;
            }
        }
    }
}