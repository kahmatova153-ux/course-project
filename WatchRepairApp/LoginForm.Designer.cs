// ============================================
// LoginForm.Designer.cs - РАЗМЕТКА ФОРМЫ
// Создает все элементы управления (поля, кнопки, надписи)
// ============================================

namespace WatchRepairApp
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // === ОБЪЯВЛЕНИЕ ЭЛЕМЕНТОВ УПРАВЛЕНИЯ ===
        // Эти поля должны совпадать с именами в коде выше
        private System.Windows.Forms.Label lblTitle;        // Заголовок "ТОЧНОЕ ВРЕМЯ"
        private System.Windows.Forms.Label lblSubtitle;     // Подзаголовок
        private System.Windows.Forms.Label lblLogin;        // Надпись "Логин:"
        private System.Windows.Forms.TextBox txtLogin;      // Поле ввода логина
        private System.Windows.Forms.Label lblPassword;     // Надпись "Пароль:"
        private System.Windows.Forms.TextBox txtPassword;   // Поле ввода пароля
        private System.Windows.Forms.Button btnLogin;       // Кнопка "ВОЙТИ"

        /// <summary>
        /// Освободить все используемые ресурсы
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Метод инициализации формы (вызывается из конструктора)
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblLogin = new Label();
            txtLogin = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(12, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(444, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "МАСТЕРСКАЯ «ТОЧНОЕ ВРЕМЯ»";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(88, 56);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(247, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Система учёта ремонта часов";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(73, 89);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(55, 20);
            lblLogin.TabIndex = 2;
            lblLogin.Text = "Логин:";
            // 
            // txtLogin
            // 
            txtLogin.Font = new Font("Segoe UI", 10F);
            txtLogin.Location = new Point(73, 109);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(280, 30);
            txtLogin.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(73, 155);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(65, 20);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(73, 175);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(280, 30);
            txtPassword.TabIndex = 5;
            txtPassword.KeyPress += txtPassword_KeyPress;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DarkBlue;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(73, 215);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(280, 40);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "ВОЙТИ";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 301);
            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);
            Controls.Add(lblLogin);
            Controls.Add(txtLogin);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход в систему - Точное время";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}