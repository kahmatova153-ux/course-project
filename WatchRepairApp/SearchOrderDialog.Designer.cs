namespace WatchRepairApp.Forms
{
    partial class SearchOrderDialog
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;

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
            lblTitle = new System.Windows.Forms.Label();
            lblDescription = new System.Windows.Forms.Label();
            txtSearch = new System.Windows.Forms.TextBox();
            panelButtons = new System.Windows.Forms.Panel();
            btnCancel = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            panelButtons.SuspendLayout();
            this.SuspendLayout();

            // Заголовок
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(280, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔍 ПОИСК ЗАКАЗА";

            // Описание
            lblDescription.AutoSize = true;
            lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblDescription.ForeColor = System.Drawing.Color.Gray;
            lblDescription.Location = new System.Drawing.Point(20, 70);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new System.Drawing.Size(350, 23);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Введите номер заказа или телефон:";

            // Поле поиска
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            txtSearch.Location = new System.Drawing.Point(20, 100);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(400, 34);
            txtSearch.TabIndex = 2;
            txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);

            // Панель кнопок
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSearch);
            panelButtons.Location = new System.Drawing.Point(20, 150);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new System.Drawing.Size(400, 50);

            // Кнопка Поиск
            btnSearch.BackColor = System.Drawing.Color.DarkBlue;
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(10, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(150, 40);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "🔍 Найти";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // Кнопка Отмена
            btnCancel.BackColor = System.Drawing.Color.Gray;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(170, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(150, 40);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "❌ Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Настройка формы
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 220);
            this.Controls.Add(panelButtons);
            this.Controls.Add(txtSearch);
            this.Controls.Add(lblDescription);
            this.Controls.Add(lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchOrderDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск заказа";
            panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}