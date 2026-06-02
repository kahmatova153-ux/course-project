namespace WatchRepairApp.Forms
{
    partial class OrderEditForm
    {
        private System.ComponentModel.IContainer components = null;

        // === ЗАГОЛОВОК И СТАТУС ===
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;

        // === ГРУППА КЛИЕНТ ===
        private System.Windows.Forms.GroupBox gbClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClientPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClientEmail;

        // === ГРУППА ЧАСЫ ===
        private System.Windows.Forms.GroupBox gbWatch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbWatchType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMechanism;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbMaster;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpEstimated;

        // === ГРУППА НЕИСПРАВНОСТЬ ===
        private System.Windows.Forms.GroupBox gbDefect;
        private System.Windows.Forms.TextBox txtDefect;

        // === ГРУППА РАБОТЫ И ЗАПЧАСТИ ===
        private System.Windows.Forms.GroupBox gbWorks;
        private System.Windows.Forms.DataGridView dgvWorks;
        private System.Windows.Forms.Button btnAddWork;
        private System.Windows.Forms.Button btnAddPart;

        // === ИТОГО И КНОПКИ ===
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        // btnPrint УДАЛЕН - не требуется по ТЗ

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
            lblStatus = new Label();
            gbClient = new GroupBox();
            ClientPhone = new MaskedTextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtClientEmail = new TextBox();
            txtClientName = new TextBox();
            gbWatch = new GroupBox();
            cmbStatus = new ComboBox();
            label9 = new Label();
            cmbMaster = new ComboBox();
            dtpEstimated = new DateTimePicker();
            label11 = new Label();
            label10 = new Label();
            txtSerial = new TextBox();
            label8 = new Label();
            txtModel = new TextBox();
            label7 = new Label();
            txtBrand = new TextBox();
            label6 = new Label();
            cmbMechanism = new ComboBox();
            label5 = new Label();
            cmbWatchType = new ComboBox();
            label4 = new Label();
            gbDefect = new GroupBox();
            txtDefect = new TextBox();
            gbWorks = new GroupBox();
            dgvWorks = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            btnAddPart = new Button();
            btnAddWork = new Button();
            lblTotal = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            gbClient.SuspendLayout();
            gbWatch.SuspendLayout();
            gbDefect.SuspendLayout();
            gbWorks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWorks).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(325, 41);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "ЗАКАЗ № З-2024-001";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblStatus.ForeColor = Color.DarkOrange;
            lblStatus.Location = new Point(600, 25);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(189, 28);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "СТАТУС: В РАБОТЕ";
            // 
            // gbClient
            // 
            gbClient.Controls.Add(ClientPhone);
            gbClient.Controls.Add(label3);
            gbClient.Controls.Add(label2);
            gbClient.Controls.Add(label1);
            gbClient.Controls.Add(txtClientEmail);
            gbClient.Controls.Add(txtClientName);
            gbClient.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            gbClient.Location = new Point(20, 70);
            gbClient.Name = "gbClient";
            gbClient.Size = new Size(420, 150);
            gbClient.TabIndex = 6;
            gbClient.TabStop = false;
            gbClient.Text = "Клиент";
            gbClient.Enter += gbClient_Enter;
            // 
            // ClientPhone
            // 
            ClientPhone.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ClientPhone.Location = new Point(96, 63);
            ClientPhone.Mask = "+7 (999) 000-0000";
            ClientPhone.Name = "ClientPhone";
            ClientPhone.Size = new Size(314, 31);
            ClientPhone.TabIndex = 6;
            ClientPhone.Validating += ClientPhone_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(14, 110);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 0;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(14, 70);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 1;
            label2.Text = "Телефон:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(14, 30);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 2;
            label1.Text = "ФИО:";
            // 
            // txtClientEmail
            // 
            txtClientEmail.Font = new Font("Segoe UI", 10F);
            txtClientEmail.Location = new Point(96, 105);
            txtClientEmail.Name = "txtClientEmail";
            txtClientEmail.Size = new Size(314, 30);
            txtClientEmail.TabIndex = 3;
            txtClientEmail.Validating += txtClientEmail_Validating;
            // 
            // txtClientName
            // 
            txtClientName.Font = new Font("Segoe UI", 10F);
            txtClientName.Location = new Point(96, 25);
            txtClientName.Name = "txtClientName";
            txtClientName.Size = new Size(314, 30);
            txtClientName.TabIndex = 5;
            txtClientName.KeyPress += txtClientName_KeyPress;
            // 
            // gbWatch
            // 
            gbWatch.Controls.Add(cmbStatus);
            gbWatch.Controls.Add(label9);
            gbWatch.Controls.Add(cmbMaster);
            gbWatch.Controls.Add(dtpEstimated);
            gbWatch.Controls.Add(label11);
            gbWatch.Controls.Add(label10);
            gbWatch.Controls.Add(txtSerial);
            gbWatch.Controls.Add(label8);
            gbWatch.Controls.Add(txtModel);
            gbWatch.Controls.Add(label7);
            gbWatch.Controls.Add(txtBrand);
            gbWatch.Controls.Add(label6);
            gbWatch.Controls.Add(cmbMechanism);
            gbWatch.Controls.Add(label5);
            gbWatch.Controls.Add(cmbWatchType);
            gbWatch.Controls.Add(label4);
            gbWatch.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            gbWatch.Location = new Point(460, 70);
            gbWatch.Name = "gbWatch";
            gbWatch.Size = new Size(400, 330);
            gbWatch.TabIndex = 5;
            gbWatch.TabStop = false;
            gbWatch.Text = "Часы";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.Location = new Point(123, 19);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(270, 31);
            cmbStatus.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label9.ForeColor = Color.Gray;
            label9.Location = new Point(6, 24);
            label9.Name = "label9";
            label9.Size = new Size(59, 20);
            label9.TabIndex = 1;
            label9.Text = "Статус:";
            // 
            // cmbMaster
            // 
            cmbMaster.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaster.Font = new Font("Segoe UI", 10F);
            cmbMaster.Location = new Point(123, 255);
            cmbMaster.Name = "cmbMaster";
            cmbMaster.Size = new Size(270, 31);
            cmbMaster.TabIndex = 2;
            // 
            // dtpEstimated
            // 
            dtpEstimated.Font = new Font("Segoe UI", 10F);
            dtpEstimated.Format = DateTimePickerFormat.Short;
            dtpEstimated.Location = new Point(200, 294);
            dtpEstimated.Name = "dtpEstimated";
            dtpEstimated.Size = new Size(193, 30);
            dtpEstimated.TabIndex = 3;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label11.ForeColor = Color.Gray;
            label11.Location = new Point(6, 302);
            label11.Name = "label11";
            label11.Size = new Size(184, 20);
            label11.TabIndex = 4;
            label11.Text = "Предв. дата готовности:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label10.ForeColor = Color.Gray;
            label10.Location = new Point(6, 260);
            label10.Name = "label10";
            label10.Size = new Size(66, 20);
            label10.TabIndex = 5;
            label10.Text = "Мастер:";
            // 
            // txtSerial
            // 
            txtSerial.Font = new Font("Segoe UI", 10F);
            txtSerial.Location = new Point(123, 216);
            txtSerial.Name = "txtSerial";
            txtSerial.Size = new Size(270, 30);
            txtSerial.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label8.ForeColor = Color.Gray;
            label8.Location = new Point(6, 221);
            label8.Name = "label8";
            label8.Size = new Size(111, 20);
            label8.TabIndex = 7;
            label8.Text = "Заводской №:";
            // 
            // txtModel
            // 
            txtModel.Font = new Font("Segoe UI", 10F);
            txtModel.Location = new Point(123, 177);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(270, 30);
            txtModel.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.ForeColor = Color.Gray;
            label7.Location = new Point(6, 182);
            label7.Name = "label7";
            label7.Size = new Size(70, 20);
            label7.TabIndex = 9;
            label7.Text = "Модель:";
            // 
            // txtBrand
            // 
            txtBrand.Font = new Font("Segoe UI", 10F);
            txtBrand.Location = new Point(123, 138);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(270, 30);
            txtBrand.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(6, 143);
            label6.Name = "label6";
            label6.Size = new Size(60, 20);
            label6.TabIndex = 11;
            label6.Text = "Марка:";
            // 
            // cmbMechanism
            // 
            cmbMechanism.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMechanism.Font = new Font("Segoe UI", 10F);
            cmbMechanism.Location = new Point(123, 99);
            cmbMechanism.Name = "cmbMechanism";
            cmbMechanism.Size = new Size(270, 31);
            cmbMechanism.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.Gray;
            label5.Location = new Point(6, 104);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 13;
            label5.Text = "Механизм:";
            // 
            // cmbWatchType
            // 
            cmbWatchType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWatchType.Font = new Font("Segoe UI", 10F);
            cmbWatchType.Location = new Point(123, 60);
            cmbWatchType.Name = "cmbWatchType";
            cmbWatchType.Size = new Size(270, 31);
            cmbWatchType.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(6, 65);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 15;
            label4.Text = "Тип:";
            // 
            // gbDefect
            // 
            gbDefect.Controls.Add(txtDefect);
            gbDefect.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            gbDefect.Location = new Point(20, 230);
            gbDefect.Name = "gbDefect";
            gbDefect.Size = new Size(420, 170);
            gbDefect.TabIndex = 4;
            gbDefect.TabStop = false;
            gbDefect.Text = "Неисправность";
            // 
            // txtDefect
            // 
            txtDefect.Dock = DockStyle.Fill;
            txtDefect.Font = new Font("Segoe UI", 10F);
            txtDefect.Location = new Point(3, 28);
            txtDefect.Multiline = true;
            txtDefect.Name = "txtDefect";
            txtDefect.Size = new Size(414, 139);
            txtDefect.TabIndex = 0;
            // 
            // gbWorks
            // 
            gbWorks.Controls.Add(dgvWorks);
            gbWorks.Controls.Add(btnAddPart);
            gbWorks.Controls.Add(btnAddWork);
            gbWorks.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            gbWorks.Location = new Point(20, 406);
            gbWorks.Name = "gbWorks";
            gbWorks.Size = new Size(840, 194);
            gbWorks.TabIndex = 3;
            gbWorks.TabStop = false;
            gbWorks.Text = "Выполненные работы и запчасти";
            // 
            // dgvWorks
            // 
            dgvWorks.AllowUserToAddRows = false;
            dgvWorks.AllowUserToDeleteRows = false;
            dgvWorks.BackgroundColor = Color.White;
            dgvWorks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWorks.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dgvWorks.Location = new Point(14, 31);
            dgvWorks.Name = "dgvWorks";
            dgvWorks.ReadOnly = true;
            dgvWorks.RowHeadersVisible = false;
            dgvWorks.RowHeadersWidth = 51;
            dgvWorks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWorks.Size = new Size(700, 160);
            dgvWorks.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Название";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Стоимость";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Тип";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Кол-во";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // btnAddPart
            // 
            btnAddPart.BackColor = Color.DarkGreen;
            btnAddPart.FlatStyle = FlatStyle.Flat;
            btnAddPart.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAddPart.ForeColor = Color.White;
            btnAddPart.Location = new Point(720, 75);
            btnAddPart.Name = "btnAddPart";
            btnAddPart.Size = new Size(110, 35);
            btnAddPart.TabIndex = 1;
            btnAddPart.Text = "➕ Запчасть";
            btnAddPart.UseVisualStyleBackColor = false;
            btnAddPart.Click += btnAddPart_Click;
            // 
            // btnAddWork
            // 
            btnAddWork.BackColor = Color.DarkBlue;
            btnAddWork.FlatStyle = FlatStyle.Flat;
            btnAddWork.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAddWork.ForeColor = Color.White;
            btnAddWork.Location = new Point(720, 30);
            btnAddWork.Name = "btnAddWork";
            btnAddWork.Size = new Size(110, 35);
            btnAddWork.TabIndex = 2;
            btnAddWork.Text = "➕ Работа";
            btnAddWork.UseVisualStyleBackColor = false;
            btnAddWork.Click += btnAddWork_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTotal.ForeColor = Color.DarkGreen;
            lblTotal.Location = new Point(20, 610);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(198, 37);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "ИТОГО: 0.00 ₽";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkBlue;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(20, 650);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 45);
            btnSave.TabIndex = 1;
            btnSave.Text = "💾 Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(180, 650);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 45);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "❌ Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // OrderEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(884, 709);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblTotal);
            Controls.Add(gbWorks);
            Controls.Add(gbDefect);
            Controls.Add(gbWatch);
            Controls.Add(gbClient);
            Controls.Add(lblStatus);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OrderEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Карточка заказа";
            gbClient.ResumeLayout(false);
            gbClient.PerformLayout();
            gbWatch.ResumeLayout(false);
            gbWatch.PerformLayout();
            gbDefect.ResumeLayout(false);
            gbDefect.PerformLayout();
            gbWorks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvWorks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private MaskedTextBox ClientPhone;
    }
}