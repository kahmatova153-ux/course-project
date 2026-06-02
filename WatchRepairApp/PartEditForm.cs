using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WatchRepairApp.Forms
{
    public partial class PartEditForm : Form
    {
        private int? partID = null;
        private bool isEditMode = false;

        // Конструктор для новой запчасти
        public PartEditForm()
        {
            InitializeComponent();
            isEditMode = false;
            this.Text = "Новая запчасть";
            LoadCategories();
        }

        // Конструктор для редактирования
        public PartEditForm(int id)
        {
            InitializeComponent();
            partID = id;
            isEditMode = true;
            this.Text = "Редактирование запчасти";
            LoadCategories();
            LoadPartData();
        }

        private void LoadCategories()
        {
            // Загрузка категорий из БД
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT CategoryName FROM PartCategories ORDER BY CategoryName");
            cmbCategory.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cmbCategory.Items.Add(row["CategoryName"].ToString());
            }
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
        }

        private void LoadPartData()
        {
            string query = "SELECT * FROM Parts WHERE PartID = @PartID";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@PartID", partID));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtPartCode.Text = row["PartCode"].ToString();
                txtPartName.Text = row["PartName"].ToString();
                cmbCategory.SelectedItem = GetCategoryName(Convert.ToInt32(row["CategoryID"]));
                txtSupplier.Text = row["Supplier"].ToString();
                numPurchasePrice.Value = Convert.ToDecimal(row["PurchasePrice"]);
                numSellingPrice.Value = Convert.ToDecimal(row["SellingPrice"]);
                numQuantity.Value = Convert.ToInt32(row["QuantityInStock"]);
                numMinLevel.Value = Convert.ToInt32(row["MinStockLevel"]);
                txtUnit.Text = row["Unit"].ToString();
            }
        }

        private string GetCategoryName(int categoryID)
        {
            DataTable dt = DatabaseHelper.ExecuteQuery(
                "SELECT CategoryName FROM PartCategories WHERE CategoryID = @ID",
                new SqlParameter("@ID", categoryID));
            return dt.Rows.Count > 0 ? dt.Rows[0]["CategoryName"].ToString() : "";
        }

        private int GetCategoryID(string categoryName)
        {
            DataTable dt = DatabaseHelper.ExecuteQuery(
                "SELECT CategoryID FROM PartCategories WHERE CategoryName = @Name",
                new SqlParameter("@Name", categoryName));
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["CategoryID"]) : 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(txtPartCode.Text))
            {
                MessageBox.Show("Введите код запчасти!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPartCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPartName.Text))
            {
                MessageBox.Show("Введите название запчасти!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPartName.Focus();
                return;
            }

            try
            {
                int categoryID = GetCategoryID(cmbCategory.SelectedItem.ToString());

                if (isEditMode)
                {
                    // Обновление
                    string query = @"UPDATE Parts SET
                        PartCode = @PartCode,
                        PartName = @PartName,
                        CategoryID = @CategoryID,
                        Supplier = @Supplier,
                        PurchasePrice = @PurchasePrice,
                        SellingPrice = @SellingPrice,
                        QuantityInStock = @Quantity,
                        MinStockLevel = @MinLevel,
                        Unit = @Unit
                    WHERE PartID = @PartID";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@PartCode", txtPartCode.Text.Trim()),
                        new SqlParameter("@PartName", txtPartName.Text.Trim()),
                        new SqlParameter("@CategoryID", categoryID),
                        new SqlParameter("@Supplier", txtSupplier.Text.Trim()),
                        new SqlParameter("@PurchasePrice", numPurchasePrice.Value),
                        new SqlParameter("@SellingPrice", numSellingPrice.Value),
                        new SqlParameter("@Quantity", (int)numQuantity.Value),
                        new SqlParameter("@MinLevel", (int)numMinLevel.Value),
                        new SqlParameter("@Unit", txtUnit.Text.Trim()),
                        new SqlParameter("@PartID", partID)
                    };

                    DatabaseHelper.ExecuteNonQuery(query, parameters);
                    MessageBox.Show("Запчасть обновлена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Создание
                    string query = @"INSERT INTO Parts (PartCode, PartName, CategoryID, Supplier,
                        PurchasePrice, SellingPrice, QuantityInStock, MinStockLevel, Unit)
                    VALUES (@PartCode, @PartName, @CategoryID, @Supplier, @PurchasePrice,
                        @SellingPrice, @Quantity, @MinLevel, @Unit);
                    SELECT SCOPE_IDENTITY();";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@PartCode", txtPartCode.Text.Trim()),
                        new SqlParameter("@PartName", txtPartName.Text.Trim()),
                        new SqlParameter("@CategoryID", categoryID),
                        new SqlParameter("@Supplier", txtSupplier.Text.Trim()),
                        new SqlParameter("@PurchasePrice", numPurchasePrice.Value),
                        new SqlParameter("@SellingPrice", numSellingPrice.Value),
                        new SqlParameter("@Quantity", (int)numQuantity.Value),
                        new SqlParameter("@MinLevel", (int)numMinLevel.Value),
                        new SqlParameter("@Unit", txtUnit.Text.Trim())
                    };

                    object result = DatabaseHelper.ExecuteScalar(query, parameters);
                    if (result != null)
                    {
                        partID = Convert.ToInt32(result);
                        MessageBox.Show("Запчасть добавлена!", "Успех",
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
    }
}