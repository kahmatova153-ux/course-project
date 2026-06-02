namespace WatchRepairApp.Forms
{
    partial class OrdersForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaster;
        private System.Windows.Forms.Panel panelButtons;
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
            panelFilters = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dtpTo = new DateTimePicker();
            dtpFrom = new DateTimePicker();
            cmbStatus = new ComboBox();
            dgvOrders = new DataGridView();
            colOrderNumber = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colClient = new DataGridViewTextBoxColumn();
            colWatch = new DataGridViewTextBoxColumn();
            colDefect = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colCost = new DataGridViewTextBoxColumn();
            colMaster = new DataGridViewTextBoxColumn();
            panelButtons = new Panel();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
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
            lblTitle.Size = new Size(295, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ЗАКАЗЫ НА РЕМОНТ";
            // 
            // panelFilters
            // 
            panelFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelFilters.BackColor = Color.White;
            panelFilters.Controls.Add(txtSearch);
            panelFilters.Controls.Add(btnSearch);
            panelFilters.Controls.Add(dtpTo);
            panelFilters.Controls.Add(dtpFrom);
            panelFilters.Controls.Add(cmbStatus);
            panelFilters.Location = new Point(20, 60);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(1017, 50);
            panelFilters.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtSearch.ForeColor = SystemColors.WindowFrame;
            txtSearch.Location = new Point(485, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(413, 30);
            txtSearch.TabIndex = 3;
            txtSearch.Text = "Поиск по номеру, клиенту...";
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.DarkBlue;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(904, 7);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 35);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "🔍 Поиск";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dtpTo
            // 
            dtpTo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(335, 12);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(144, 30);
            dtpTo.TabIndex = 2;
            // 
            // dtpFrom
            // 
            dtpFrom.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(185, 12);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(144, 30);
            dtpFrom.TabIndex = 1;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Все статусы", "Принят", "В диагностике", "В работе", "Готов", "Выдан" });
            cmbStatus.Location = new Point(10, 12);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(169, 31);
            cmbStatus.TabIndex = 0;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.BorderStyle = BorderStyle.None;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { colOrderNumber, colDate, colClient, colWatch, colDefect, colStatus, colCost, colMaster });
            dgvOrders.Location = new Point(20, 120);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(1017, 450);
            dgvOrders.TabIndex = 2;
            dgvOrders.DoubleClick += dgvOrders_DoubleClick;
            // 
            // colOrderNumber
            // 
            colOrderNumber.HeaderText = "№ заказа";
            colOrderNumber.MinimumWidth = 6;
            colOrderNumber.Name = "colOrderNumber";
            colOrderNumber.ReadOnly = true;
            colOrderNumber.Width = 125;
            // 
            // colDate
            // 
            colDate.HeaderText = "Дата приёма";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            colDate.Width = 125;
            // 
            // colClient
            // 
            colClient.HeaderText = "Клиент";
            colClient.MinimumWidth = 6;
            colClient.Name = "colClient";
            colClient.ReadOnly = true;
            colClient.Width = 120;
            // 
            // colWatch
            // 
            colWatch.HeaderText = "Часы";
            colWatch.MinimumWidth = 6;
            colWatch.Name = "colWatch";
            colWatch.ReadOnly = true;
            colWatch.Width = 120;
            // 
            // colDefect
            // 
            colDefect.HeaderText = "Неисправность";
            colDefect.MinimumWidth = 6;
            colDefect.Name = "colDefect";
            colDefect.ReadOnly = true;
            colDefect.Width = 150;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Статус";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 125;
            // 
            // colCost
            // 
            colCost.HeaderText = "Стоимость";
            colCost.MinimumWidth = 6;
            colCost.Name = "colCost";
            colCost.ReadOnly = true;
            colCost.Width = 125;
            // 
            // colMaster
            // 
            colMaster.HeaderText = "Мастер";
            colMaster.MinimumWidth = 6;
            colMaster.Name = "colMaster";
            colMaster.ReadOnly = true;
            colMaster.Width = 125;
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Location = new Point(20, 580);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1014, 50);
            panelButtons.TabIndex = 3;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.BackColor = Color.Crimson;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(292, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(124, 40);
            btnDelete.TabIndex = 2;
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
            btnEdit.Location = new Point(148, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(138, 40);
            btnEdit.TabIndex = 1;
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
            btnAdd.Size = new Size(132, 40);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "➕ Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // OrdersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(1053, 650);
            Controls.Add(panelButtons);
            Controls.Add(dgvOrders);
            Controls.Add(panelFilters);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            MinimumSize = new Size(900, 500);
            Name = "OrdersForm";
            Text = "OrdersForm";
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }
    }
}