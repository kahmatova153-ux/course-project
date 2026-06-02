namespace WatchRepairApp.Forms
{
    partial class WarehouseForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvParts;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtSearch = new TextBox();
            dgvParts = new DataGridView();
            panelButtons = new Panel();
            btnAddStock = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvParts).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(283, 37);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "СКЛАД ЗАПЧАСТЕЙ";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(20, 60);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(400, 30);
            txtSearch.TabIndex = 2;
            txtSearch.Text = "Поиск...";
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // dgvParts
            // 
            dgvParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvParts.BackgroundColor = Color.White;
            dgvParts.BorderStyle = BorderStyle.None;
            dgvParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParts.Location = new Point(20, 100);
            dgvParts.Name = "dgvParts";
            dgvParts.ReadOnly = true;
            dgvParts.RowHeadersVisible = false;
            dgvParts.RowHeadersWidth = 51;
            dgvParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParts.Size = new Size(1017, 450);
            dgvParts.TabIndex = 1;
            dgvParts.CellFormatting += dgvParts_CellFormatting;
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelButtons.Controls.Add(btnAddStock);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Location = new Point(20, 560);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1017, 50);
            panelButtons.TabIndex = 0;
            // 
            // btnAddStock
            // 
            btnAddStock.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddStock.BackColor = Color.DodgerBlue;
            btnAddStock.FlatAppearance.BorderSize = 0;
            btnAddStock.FlatStyle = FlatStyle.Flat;
            btnAddStock.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAddStock.ForeColor = Color.White;
            btnAddStock.Location = new Point(414, 5);
            btnAddStock.Name = "btnAddStock";
            btnAddStock.Size = new Size(140, 40);
            btnAddStock.TabIndex = 0;
            btnAddStock.Text = "📦 Приход";
            btnAddStock.UseVisualStyleBackColor = false;
            btnAddStock.Click += btnAddStock_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.BackColor = Color.Crimson;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(290, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(118, 40);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "🗑️ Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEdit.BackColor = Color.DarkOrange;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(150, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(134, 40);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "✏️ Изменить";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.BackColor = Color.DarkGreen;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(10, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(134, 40);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "➕ Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // WarehouseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(1053, 650);
            Controls.Add(panelButtons);
            Controls.Add(dgvParts);
            Controls.Add(txtSearch);
            Controls.Add(lblTitle);
            MinimumSize = new Size(800, 500);
            Name = "WarehouseForm";
            Text = "WarehouseForm";
            ((System.ComponentModel.ISupportInitialize)dgvParts).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}