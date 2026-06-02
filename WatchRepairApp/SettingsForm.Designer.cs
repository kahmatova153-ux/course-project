namespace WatchRepairApp.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbCompany;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.GroupBox gbDatabase;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnArchiveOldOrders;
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
            gbCompany = new GroupBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtCompanyName = new TextBox();
            lblCompanyName = new Label();
            gbDatabase = new GroupBox();
            lblConnectionStatus = new Label();
            btnTestConnection = new Button();
            btnArchiveOldOrders = new Button();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            gbCompany.SuspendLayout();
            gbDatabase.SuspendLayout();
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
            lblTitle.Size = new Size(187, 37);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "НАСТРОЙКИ";
            // 
            // gbCompany
            // 
            gbCompany.Controls.Add(txtEmail);
            gbCompany.Controls.Add(lblEmail);
            gbCompany.Controls.Add(txtPhone);
            gbCompany.Controls.Add(lblPhone);
            gbCompany.Controls.Add(txtAddress);
            gbCompany.Controls.Add(lblAddress);
            gbCompany.Controls.Add(txtCompanyName);
            gbCompany.Controls.Add(lblCompanyName);
            gbCompany.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            gbCompany.Location = new Point(20, 70);
            gbCompany.Name = "gbCompany";
            gbCompany.Size = new Size(540, 280);
            gbCompany.TabIndex = 2;
            gbCompany.TabStop = false;
            gbCompany.Text = "О компании";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(275, 210);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 30);
            txtEmail.TabIndex = 0;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.Location = new Point(275, 185);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(59, 23);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(15, 210);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(250, 30);
            txtPhone.TabIndex = 2;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPhone.Location = new Point(15, 185);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(85, 23);
            lblPhone.TabIndex = 3;
            lblPhone.Text = "Телефон:";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(15, 125);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(510, 50);
            txtAddress.TabIndex = 4;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAddress.Location = new Point(15, 100);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(67, 23);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Адрес:";
            // 
            // txtCompanyName
            // 
            txtCompanyName.Font = new Font("Segoe UI", 10F);
            txtCompanyName.Location = new Point(15, 60);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(510, 30);
            txtCompanyName.TabIndex = 6;
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCompanyName.Location = new Point(15, 35);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(94, 23);
            lblCompanyName.TabIndex = 7;
            lblCompanyName.Text = "Название:";
            // 
            // gbDatabase
            // 
            gbDatabase.Controls.Add(lblConnectionStatus);
            gbDatabase.Controls.Add(btnTestConnection);
            gbDatabase.Controls.Add(btnArchiveOldOrders);
            gbDatabase.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            gbDatabase.Location = new Point(20, 360);
            gbDatabase.Name = "gbDatabase";
            gbDatabase.Size = new Size(540, 131);
            gbDatabase.TabIndex = 1;
            gbDatabase.TabStop = false;
            gbDatabase.Text = "База данных";
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.AutoSize = true;
            lblConnectionStatus.Font = new Font("Segoe UI", 10F);
            lblConnectionStatus.Location = new Point(230, 42);
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(195, 23);
            lblConnectionStatus.TabIndex = 0;
            lblConnectionStatus.Text = "Нажмите для проверки";
            // 
            // btnTestConnection
            // 
            btnTestConnection.BackColor = Color.DarkBlue;
            btnTestConnection.FlatStyle = FlatStyle.Flat;
            btnTestConnection.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTestConnection.ForeColor = Color.White;
            btnTestConnection.Location = new Point(15, 35);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(200, 35);
            btnTestConnection.TabIndex = 1;
            btnTestConnection.Text = "Проверить подключение";
            btnTestConnection.UseVisualStyleBackColor = false;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // btnArchiveOldOrders
            // 
            btnArchiveOldOrders.BackColor = Color.Crimson;
            btnArchiveOldOrders.FlatStyle = FlatStyle.Flat;
            btnArchiveOldOrders.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnArchiveOldOrders.ForeColor = Color.White;
            btnArchiveOldOrders.Location = new Point(15, 80);
            btnArchiveOldOrders.Name = "btnArchiveOldOrders";
            btnArchiveOldOrders.Size = new Size(510, 35);
            btnArchiveOldOrders.TabIndex = 2;
            btnArchiveOldOrders.Text = "🗑️ Очистить старые заказы";
            btnArchiveOldOrders.UseVisualStyleBackColor = false;
            btnArchiveOldOrders.Click += btnArchiveOldOrders_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Location = new Point(20, 497);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(540, 50);
            panelButtons.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(170, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 40);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "❌ Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(10, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 1;
            btnSave.Text = "💾 Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(580, 554);
            Controls.Add(panelButtons);
            Controls.Add(gbDatabase);
            Controls.Add(gbCompany);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Настройки";
            gbCompany.ResumeLayout(false);
            gbCompany.PerformLayout();
            gbDatabase.ResumeLayout(false);
            gbDatabase.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}