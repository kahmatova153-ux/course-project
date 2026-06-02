using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WatchRepairApp.Forms
{
    public partial class SelectPartForm : Form
    {
        public int SelectedPartID { get; private set; }
        public int Quantity { get; private set; }

        public SelectPartForm()
        {
            InitializeComponent();
            LoadParts();
        }

        private void LoadParts()
        {
            // Загружаем только доступные запчасти (количество > 0)
            string query = @"SELECT 
                PartID,
                PartCode as 'Код',
                PartName as 'Название',
                QuantityInStock as 'На складе',
                SellingPrice as 'Цена'
            FROM Parts
            WHERE QuantityInStock > 0
            ORDER BY PartName";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            dgvParts.DataSource = dt;

            if (dgvParts.Columns["PartID"] != null)
                dgvParts.Columns["PartID"].Visible = false;

            dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            if (search == "Поиск...") return;

            string query = @"SELECT 
                PartID,
                PartCode as 'Код',
                PartName as 'Название',
                QuantityInStock as 'На складе',
                SellingPrice as 'Цена'
            FROM Parts
            WHERE QuantityInStock > 0
            AND (PartName LIKE @Search OR PartCode LIKE @Search)
            ORDER BY PartName";

            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new SqlParameter("@Search", "%" + search + "%"));
            dgvParts.DataSource = dt;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvParts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запчасть!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedPartID = Convert.ToInt32(dgvParts.SelectedRows[0].Cells["PartID"].Value);
            int maxQty = Convert.ToInt32(dgvParts.SelectedRows[0].Cells["На складе"].Value);

            // Проверяем количество
            int qty = (int)numQuantity.Value;
            if (qty <= 0)
            {
                MessageBox.Show("Введите количество!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (qty > maxQty)
            {
                MessageBox.Show($"На складе только {maxQty} шт.!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Quantity = qty;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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