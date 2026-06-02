namespace WatchRepairApp.Forms
{
    partial class PartEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPartCode;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.Label lblPartName;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.NumericUpDown numPurchasePrice;
        private System.Windows.Forms.Label lblSellingPrice;
        private System.Windows.Forms.NumericUpDown numSellingPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblMinLevel;
        private System.Windows.Forms.NumericUpDown numMinLevel;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;
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
            lblPartCode = new Label();
            txtPartCode = new TextBox();
            lblPartName = new Label();
            txtPartName = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblSupplier = new Label();
            txtSupplier = new TextBox();
            lblPurchasePrice = new Label();
            numPurchasePrice = new NumericUpDown();
            lblSellingPrice = new Label();
            numSellingPrice = new NumericUpDown();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblMinLevel = new Label();
            numMinLevel = new NumericUpDown();
            lblUnit = new Label();
            txtUnit = new TextBox();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)numPurchasePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSellingPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMinLevel).BeginInit();
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
            lblTitle.Size = new Size(161, 37);
            lblTitle.TabIndex = 19;
            lblTitle.Text = "ЗАПЧАСТЬ";
            // 
            // lblPartCode
            // 
            lblPartCode.AutoSize = true;
            lblPartCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPartCode.Location = new Point(20, 70);
            lblPartCode.Name = "lblPartCode";
            lblPartCode.Size = new Size(55, 23);
            lblPartCode.TabIndex = 17;
            lblPartCode.Text = "Код *";
            // 
            // txtPartCode
            // 
            txtPartCode.Font = new Font("Segoe UI", 10F);
            txtPartCode.Location = new Point(20, 95);
            txtPartCode.Name = "txtPartCode";
            txtPartCode.Size = new Size(200, 30);
            txtPartCode.TabIndex = 16;
            // 
            // lblPartName
            // 
            lblPartName.AutoSize = true;
            lblPartName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPartName.Location = new Point(240, 70);
            lblPartName.Name = "lblPartName";
            lblPartName.Size = new Size(102, 23);
            lblPartName.TabIndex = 15;
            lblPartName.Text = "Название *";
            // 
            // txtPartName
            // 
            txtPartName.Font = new Font("Segoe UI", 10F);
            txtPartName.Location = new Point(240, 95);
            txtPartName.Name = "txtPartName";
            txtPartName.Size = new Size(320, 30);
            txtPartName.TabIndex = 14;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCategory.Location = new Point(20, 135);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(96, 23);
            lblCategory.TabIndex = 13;
            lblCategory.Text = "Категория";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.Location = new Point(20, 160);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(250, 31);
            cmbCategory.TabIndex = 12;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSupplier.Location = new Point(290, 135);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(104, 23);
            lblSupplier.TabIndex = 11;
            lblSupplier.Text = "Поставщик";
            // 
            // txtSupplier
            // 
            txtSupplier.Font = new Font("Segoe UI", 10F);
            txtSupplier.Location = new Point(290, 160);
            txtSupplier.Name = "txtSupplier";
            txtSupplier.Size = new Size(270, 30);
            txtSupplier.TabIndex = 10;
            // 
            // lblPurchasePrice
            // 
            lblPurchasePrice.AutoSize = true;
            lblPurchasePrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPurchasePrice.Location = new Point(20, 205);
            lblPurchasePrice.Name = "lblPurchasePrice";
            lblPurchasePrice.Size = new Size(124, 23);
            lblPurchasePrice.TabIndex = 9;
            lblPurchasePrice.Text = "Цена закупки";
            // 
            // numPurchasePrice
            // 
            numPurchasePrice.DecimalPlaces = 2;
            numPurchasePrice.Font = new Font("Segoe UI", 10F);
            numPurchasePrice.Location = new Point(20, 230);
            numPurchasePrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPurchasePrice.Name = "numPurchasePrice";
            numPurchasePrice.Size = new Size(150, 30);
            numPurchasePrice.TabIndex = 8;
            numPurchasePrice.ThousandsSeparator = true;
            // 
            // lblSellingPrice
            // 
            lblSellingPrice.AutoSize = true;
            lblSellingPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSellingPrice.Location = new Point(176, 205);
            lblSellingPrice.Name = "lblSellingPrice";
            lblSellingPrice.Size = new Size(133, 23);
            lblSellingPrice.TabIndex = 7;
            lblSellingPrice.Text = "Цена продажи";
            // 
            // numSellingPrice
            // 
            numSellingPrice.DecimalPlaces = 2;
            numSellingPrice.Font = new Font("Segoe UI", 10F);
            numSellingPrice.Location = new Point(176, 231);
            numSellingPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numSellingPrice.Name = "numSellingPrice";
            numSellingPrice.Size = new Size(150, 30);
            numSellingPrice.TabIndex = 6;
            numSellingPrice.ThousandsSeparator = true;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQuantity.Location = new Point(332, 205);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(94, 23);
            lblQuantity.TabIndex = 5;
            lblQuantity.Text = "На складе";
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Segoe UI", 10F);
            numQuantity.Location = new Point(332, 230);
            numQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(100, 30);
            numQuantity.TabIndex = 4;
            // 
            // lblMinLevel
            // 
            lblMinLevel.AutoSize = true;
            lblMinLevel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMinLevel.Location = new Point(432, 205);
            lblMinLevel.Name = "lblMinLevel";
            lblMinLevel.Size = new Size(126, 23);
            lblMinLevel.TabIndex = 3;
            lblMinLevel.Text = "Мин. уровень";
            // 
            // numMinLevel
            // 
            numMinLevel.Font = new Font("Segoe UI", 10F);
            numMinLevel.Location = new Point(438, 230);
            numMinLevel.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numMinLevel.Name = "numMinLevel";
            numMinLevel.Size = new Size(100, 30);
            numMinLevel.TabIndex = 2;
            numMinLevel.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUnit.Location = new Point(20, 275);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(132, 23);
            lblUnit.TabIndex = 1;
            lblUnit.Text = "Ед. измерения";
            // 
            // txtUnit
            // 
            txtUnit.Font = new Font("Segoe UI", 10F);
            txtUnit.Location = new Point(20, 300);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(150, 30);
            txtUnit.TabIndex = 0;
            txtUnit.Text = "шт.";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Location = new Point(20, 350);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(540, 50);
            panelButtons.TabIndex = 18;
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
            btnSave.BackColor = Color.DarkBlue;
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
            // PartEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(570, 420);
            Controls.Add(txtUnit);
            Controls.Add(lblUnit);
            Controls.Add(numMinLevel);
            Controls.Add(lblMinLevel);
            Controls.Add(numQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(numSellingPrice);
            Controls.Add(lblSellingPrice);
            Controls.Add(numPurchasePrice);
            Controls.Add(lblPurchasePrice);
            Controls.Add(txtSupplier);
            Controls.Add(lblSupplier);
            Controls.Add(cmbCategory);
            Controls.Add(lblCategory);
            Controls.Add(txtPartName);
            Controls.Add(lblPartName);
            Controls.Add(txtPartCode);
            Controls.Add(lblPartCode);
            Controls.Add(panelButtons);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PartEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Запчасть";
            ((System.ComponentModel.ISupportInitialize)numPurchasePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSellingPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMinLevel).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}