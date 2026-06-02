namespace WatchRepairApp.Forms
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelPeriod;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnOrdersReport;
        private System.Windows.Forms.Button btnFinanceReport;
        private System.Windows.Forms.Button btnStockReport;
        private System.Windows.Forms.Button btnMasterReport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label lblSummary;

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
            panelPeriod = new Panel();
            dtpTo = new DateTimePicker();
            lblTo = new Label();
            dtpFrom = new DateTimePicker();
            lblFrom = new Label();
            panelButtons = new Panel();
            btnExport = new Button();
            btnMasterReport = new Button();
            btnStockReport = new Button();
            btnFinanceReport = new Button();
            btnOrdersReport = new Button();
            dgvReport = new DataGridView();
            lblSummary = new Label();
            panelPeriod.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(171, 37);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "📊 ОТЧЁТЫ";
            // 
            // panelPeriod
            // 
            panelPeriod.BackColor = Color.White;
            panelPeriod.Controls.Add(dtpTo);
            panelPeriod.Controls.Add(lblTo);
            panelPeriod.Controls.Add(dtpFrom);
            panelPeriod.Controls.Add(lblFrom);
            panelPeriod.Location = new Point(20, 70);
            panelPeriod.Name = "panelPeriod";
            panelPeriod.Size = new Size(364, 60);
            panelPeriod.TabIndex = 3;
            // 
            // dtpTo
            // 
            dtpTo.Font = new Font("Segoe UI", 11F);
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(219, 12);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(130, 32);
            dtpTo.TabIndex = 0;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTo.Location = new Point(175, 20);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(38, 23);
            lblTo.TabIndex = 1;
            lblTo.Text = "По:";
            // 
            // dtpFrom
            // 
            dtpFrom.Font = new Font("Segoe UI", 11F);
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(39, 12);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(130, 32);
            dtpFrom.TabIndex = 2;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFrom.Location = new Point(10, 20);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(26, 23);
            lblFrom.TabIndex = 3;
            lblFrom.Text = "С:";
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnExport);
            panelButtons.Controls.Add(btnMasterReport);
            panelButtons.Controls.Add(btnStockReport);
            panelButtons.Controls.Add(btnFinanceReport);
            panelButtons.Controls.Add(btnOrdersReport);
            panelButtons.Location = new Point(20, 140);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1017, 70);
            panelButtons.TabIndex = 2;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExport.BackColor = Color.Gray;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(867, 10);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(140, 50);
            btnExport.TabIndex = 0;
            btnExport.Text = "📥 Экспорт";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnMasterReport
            // 
            btnMasterReport.BackColor = Color.Purple;
            btnMasterReport.FlatAppearance.BorderSize = 0;
            btnMasterReport.FlatStyle = FlatStyle.Flat;
            btnMasterReport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMasterReport.ForeColor = Color.White;
            btnMasterReport.Location = new Point(460, 10);
            btnMasterReport.Name = "btnMasterReport";
            btnMasterReport.Size = new Size(140, 50);
            btnMasterReport.TabIndex = 1;
            btnMasterReport.Text = "👨‍🔧 Мастера";
            btnMasterReport.UseVisualStyleBackColor = false;
            btnMasterReport.Click += btnMasterReport_Click;
            // 
            // btnStockReport
            // 
            btnStockReport.BackColor = Color.DarkOrange;
            btnStockReport.FlatAppearance.BorderSize = 0;
            btnStockReport.FlatStyle = FlatStyle.Flat;
            btnStockReport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnStockReport.ForeColor = Color.White;
            btnStockReport.Location = new Point(310, 10);
            btnStockReport.Name = "btnStockReport";
            btnStockReport.Size = new Size(140, 50);
            btnStockReport.TabIndex = 2;
            btnStockReport.Text = "📦 Склад";
            btnStockReport.UseVisualStyleBackColor = false;
            btnStockReport.Click += btnStockReport_Click;
            // 
            // btnFinanceReport
            // 
            btnFinanceReport.BackColor = Color.DarkGreen;
            btnFinanceReport.FlatAppearance.BorderSize = 0;
            btnFinanceReport.FlatStyle = FlatStyle.Flat;
            btnFinanceReport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnFinanceReport.ForeColor = Color.White;
            btnFinanceReport.Location = new Point(160, 10);
            btnFinanceReport.Name = "btnFinanceReport";
            btnFinanceReport.Size = new Size(140, 50);
            btnFinanceReport.TabIndex = 3;
            btnFinanceReport.Text = "💰 Финансы";
            btnFinanceReport.UseVisualStyleBackColor = false;
            btnFinanceReport.Click += btnFinanceReport_Click;
            // 
            // btnOrdersReport
            // 
            btnOrdersReport.BackColor = Color.DarkBlue;
            btnOrdersReport.FlatAppearance.BorderSize = 0;
            btnOrdersReport.FlatStyle = FlatStyle.Flat;
            btnOrdersReport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnOrdersReport.ForeColor = Color.White;
            btnOrdersReport.Location = new Point(10, 10);
            btnOrdersReport.Name = "btnOrdersReport";
            btnOrdersReport.Size = new Size(140, 50);
            btnOrdersReport.TabIndex = 4;
            btnOrdersReport.Text = "📋 Заказы";
            btnOrdersReport.UseVisualStyleBackColor = false;
            btnOrdersReport.Click += btnOrdersReport_Click;
            // 
            // dgvReport
            // 
            dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.BorderStyle = BorderStyle.None;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Font = new Font("Segoe UI", 10F);
            dgvReport.Location = new Point(20, 230);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersVisible = false;
            dgvReport.RowHeadersWidth = 51;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(1017, 380);
            dgvReport.TabIndex = 1;
            // 
            // lblSummary
            // 
            lblSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSummary.Location = new Point(20, 620);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(219, 28);
            lblSummary.TabIndex = 0;
            lblSummary.Text = "Выберите тип отчета";
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(1057, 680);
            Controls.Add(lblSummary);
            Controls.Add(dgvReport);
            Controls.Add(panelButtons);
            Controls.Add(panelPeriod);
            Controls.Add(lblTitle);
            MinimumSize = new Size(900, 500);
            Name = "ReportsForm";
            Text = "Отчёты";
            Resize += ReportsForm_Resize;
            panelPeriod.ResumeLayout(false);
            panelPeriod.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}