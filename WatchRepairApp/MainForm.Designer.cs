namespace WatchRepairApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // === ВЕРХНЯЯ ПАНЕЛЬ ===
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblRoleInfo;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnExit;

        // === ЛЕВАЯ ПАНЕЛЬ (БЫСТРЫЕ ДЕЙСТВИЯ) ===
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblQuickActions;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnNewClient;
        private System.Windows.Forms.Button btnSearchOrder;
        private System.Windows.Forms.Button btnMyOrders;

        // === ПАНЕЛЬ СТАТИСТИКИ ===
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label lblNewOrders;
        private System.Windows.Forms.Label lblInWork;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Button btnRefresh;

        // === ЦЕНТРАЛЬНАЯ ПАНЕЛЬ ===
        private System.Windows.Forms.Panel panelContent;

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
            panelTop = new Panel();
            lblRoleInfo = new Label();
            btnExit = new Button();
            btnSettings = new Button();
            btnReports = new Button();
            btnWarehouse = new Button();
            btnClients = new Button();
            btnOrders = new Button();
            lblLogo = new Label();
            panelLeft = new Panel();
            btnRefresh = new Button();
            lblReady = new Label();
            lblInWork = new Label();
            lblNewOrders = new Label();
            lblStats = new Label();
            btnMyOrders = new Button();
            btnSearchOrder = new Button();
            btnNewClient = new Button();
            btnNewOrder = new Button();
            lblQuickActions = new Label();
            panelContent = new Panel();
            panelTop.SuspendLayout();
            panelLeft.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.DarkBlue;
            panelTop.Controls.Add(lblRoleInfo);
            panelTop.Controls.Add(btnExit);
            panelTop.Controls.Add(btnSettings);
            panelTop.Controls.Add(btnReports);
            panelTop.Controls.Add(btnWarehouse);
            panelTop.Controls.Add(btnClients);
            panelTop.Controls.Add(btnOrders);
            panelTop.Controls.Add(lblLogo);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1200, 80);
            panelTop.TabIndex = 0;
            // 
            // lblRoleInfo
            // 
            lblRoleInfo.AutoSize = true;
            lblRoleInfo.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblRoleInfo.ForeColor = Color.LightBlue;
            lblRoleInfo.Location = new Point(25, 50);
            lblRoleInfo.Name = "lblRoleInfo";
            lblRoleInfo.Size = new Size(119, 20);
            lblRoleInfo.TabIndex = 7;
            lblRoleInfo.Text = "Доступ: полный";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Crimson;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(1074, 23);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(114, 40);
            btnExit.TabIndex = 6;
            btnExit.Text = "🚪 Выход";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnSettings
            // 
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(876, 25);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(182, 34);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "⚙️ Настройки";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnReports
            // 
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(750, 20);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(120, 45);
            btnReports.TabIndex = 4;
            btnReports.Text = "📊 Отчёты";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnWarehouse
            // 
            btnWarehouse.FlatAppearance.BorderSize = 0;
            btnWarehouse.FlatStyle = FlatStyle.Flat;
            btnWarehouse.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnWarehouse.ForeColor = Color.White;
            btnWarehouse.Location = new Point(624, 20);
            btnWarehouse.Name = "btnWarehouse";
            btnWarehouse.Size = new Size(120, 45);
            btnWarehouse.TabIndex = 3;
            btnWarehouse.Text = "📦 Склад";
            btnWarehouse.UseVisualStyleBackColor = true;
            btnWarehouse.Click += btnWarehouse_Click;
            // 
            // btnClients
            // 
            btnClients.FlatAppearance.BorderSize = 0;
            btnClients.FlatStyle = FlatStyle.Flat;
            btnClients.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnClients.ForeColor = Color.White;
            btnClients.Location = new Point(476, 20);
            btnClients.Name = "btnClients";
            btnClients.Size = new Size(142, 45);
            btnClients.TabIndex = 2;
            btnClients.Text = "👥 Клиенты";
            btnClients.UseVisualStyleBackColor = true;
            btnClients.Click += btnClients_Click;
            // 
            // btnOrders
            // 
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnOrders.ForeColor = Color.White;
            btnOrders.Location = new Point(350, 20);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(120, 45);
            btnOrders.TabIndex = 1;
            btnOrders.Text = "📋 Заказы";
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += btnOrders_Click;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(20, 10);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(301, 41);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "⌚ ТОЧНОЕ ВРЕМЯ";
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.White;
            panelLeft.Controls.Add(btnRefresh);
            panelLeft.Controls.Add(lblReady);
            panelLeft.Controls.Add(lblInWork);
            panelLeft.Controls.Add(lblNewOrders);
            panelLeft.Controls.Add(lblStats);
            panelLeft.Controls.Add(btnMyOrders);
            panelLeft.Controls.Add(btnSearchOrder);
            panelLeft.Controls.Add(btnNewClient);
            panelLeft.Controls.Add(btnNewOrder);
            panelLeft.Controls.Add(lblQuickActions);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 80);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(15);
            panelLeft.Size = new Size(280, 720);
            panelLeft.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.DodgerBlue;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(15, 440);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(250, 35);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "🔄 Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblReady
            // 
            lblReady.AutoSize = true;
            lblReady.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblReady.Location = new Point(15, 400);
            lblReady.Name = "lblReady";
            lblReady.Size = new Size(211, 25);
            lblReady.TabIndex = 8;
            lblReady.Text = "✅ Готовых к выдаче: 0";
            // 
            // lblInWork
            // 
            lblInWork.AutoSize = true;
            lblInWork.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblInWork.Location = new Point(15, 370);
            lblInWork.Name = "lblInWork";
            lblInWork.Size = new Size(134, 25);
            lblInWork.TabIndex = 7;
            lblInWork.Text = "🔧 В работе: 0";
            // 
            // lblNewOrders
            // 
            lblNewOrders.AutoSize = true;
            lblNewOrders.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblNewOrders.Location = new Point(15, 340);
            lblNewOrders.Name = "lblNewOrders";
            lblNewOrders.Size = new Size(186, 25);
            lblNewOrders.TabIndex = 6;
            lblNewOrders.Text = "📥 Новых сегодня: 0";
            // 
            // lblStats
            // 
            lblStats.AutoSize = true;
            lblStats.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblStats.ForeColor = Color.DarkBlue;
            lblStats.Location = new Point(15, 300);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(193, 30);
            lblStats.TabIndex = 5;
            lblStats.Text = "📈 СТАТИСТИКА";
            // 
            // btnMyOrders
            // 
            btnMyOrders.BackColor = Color.FromArgb(240, 240, 240);
            btnMyOrders.FlatAppearance.BorderColor = Color.LightGray;
            btnMyOrders.FlatStyle = FlatStyle.Flat;
            btnMyOrders.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnMyOrders.Location = new Point(15, 225);
            btnMyOrders.Name = "btnMyOrders";
            btnMyOrders.Size = new Size(250, 45);
            btnMyOrders.TabIndex = 4;
            btnMyOrders.Text = "📋 Мои заказы";
            btnMyOrders.TextAlign = ContentAlignment.MiddleLeft;
            btnMyOrders.UseVisualStyleBackColor = false;
            btnMyOrders.Click += btnMyOrders_Click;
            // 
            // btnSearchOrder
            // 
            btnSearchOrder.BackColor = Color.FromArgb(240, 240, 240);
            btnSearchOrder.FlatAppearance.BorderColor = Color.LightGray;
            btnSearchOrder.FlatStyle = FlatStyle.Flat;
            btnSearchOrder.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSearchOrder.Location = new Point(15, 170);
            btnSearchOrder.Name = "btnSearchOrder";
            btnSearchOrder.Size = new Size(250, 45);
            btnSearchOrder.TabIndex = 3;
            btnSearchOrder.Text = "🔍 Поиск заказа";
            btnSearchOrder.TextAlign = ContentAlignment.MiddleLeft;
            btnSearchOrder.UseVisualStyleBackColor = false;
            btnSearchOrder.Click += btnSearchOrder_Click;
            // 
            // btnNewClient
            // 
            btnNewClient.BackColor = Color.FromArgb(240, 240, 240);
            btnNewClient.FlatAppearance.BorderColor = Color.LightGray;
            btnNewClient.FlatStyle = FlatStyle.Flat;
            btnNewClient.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnNewClient.Location = new Point(15, 115);
            btnNewClient.Name = "btnNewClient";
            btnNewClient.Size = new Size(250, 45);
            btnNewClient.TabIndex = 2;
            btnNewClient.Text = "👤 Новый клиент";
            btnNewClient.TextAlign = ContentAlignment.MiddleLeft;
            btnNewClient.UseVisualStyleBackColor = false;
            btnNewClient.Click += btnNewClient_Click;
            // 
            // btnNewOrder
            // 
            btnNewOrder.BackColor = Color.DarkGreen;
            btnNewOrder.FlatAppearance.BorderSize = 0;
            btnNewOrder.FlatStyle = FlatStyle.Flat;
            btnNewOrder.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnNewOrder.ForeColor = Color.White;
            btnNewOrder.Location = new Point(15, 55);
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.Size = new Size(250, 50);
            btnNewOrder.TabIndex = 1;
            btnNewOrder.Text = "➕ Новый заказ";
            btnNewOrder.UseVisualStyleBackColor = false;
            btnNewOrder.Click += btnNewOrder_Click;
            // 
            // lblQuickActions
            // 
            lblQuickActions.AutoSize = true;
            lblQuickActions.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblQuickActions.ForeColor = Color.DarkBlue;
            lblQuickActions.Location = new Point(15, 15);
            lblQuickActions.Name = "lblQuickActions";
            lblQuickActions.Size = new Size(281, 30);
            lblQuickActions.TabIndex = 0;
            lblQuickActions.Text = "⚡ БЫСТРЫЕ ДЕЙСТВИЯ";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(245, 245, 245);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(280, 80);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(20);
            panelContent.Size = new Size(920, 720);
            panelContent.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(panelContent);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Мастерская «Точное время»";
            WindowState = FormWindowState.Maximized;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ResumeLayout(false);
        }
    }
}