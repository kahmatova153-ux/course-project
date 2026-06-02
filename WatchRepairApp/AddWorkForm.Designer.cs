namespace WatchRepairApp.Forms
{
    partial class AddWorkForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.NumericUpDown numCost;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;

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
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblCost = new Label();
            numCost = new NumericUpDown();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();

            ((System.ComponentModel.ISupportInitialize)numCost).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();

            // Заголовок
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Text = "ДОБАВЛЕНИЕ РАБОТЫ";

            // Описание
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescription.Location = new Point(20, 70);
            lblDescription.Text = "Описание работы *";

            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(20, 95);
            txtDescription.Multiline = true;
            txtDescription.Size = new Size(440, 80);
            txtDescription.ScrollBars = ScrollBars.Vertical;

            // Стоимость
            lblCost.AutoSize = true;
            lblCost.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCost.Location = new Point(20, 185);
            lblCost.Text = "Стоимость (₽) *";

            numCost.DecimalPlaces = 2;
            numCost.Font = new Font("Segoe UI", 10F);
            numCost.Location = new Point(20, 210);
            numCost.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numCost.Size = new Size(200, 30);
            numCost.ThousandsSeparator = true;

            // Панель кнопок
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Location = new Point(20, 260);
            panelButtons.Size = new Size(440, 50);

            btnSave.BackColor = Color.DarkBlue;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(10, 5);
            btnSave.Size = new Size(150, 40);
            btnSave.Text = "💾 Добавить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;

            btnCancel.BackColor = Color.Gray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(170, 5);
            btnCancel.Size = new Size(150, 40);
            btnCancel.Text = "❌ Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;

            // Настройка формы
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(480, 330);
            Controls.Add(panelButtons);
            Controls.Add(numCost);
            Controls.Add(lblCost);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddWorkForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление работы";

            ((System.ComponentModel.ISupportInitialize)numCost).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}