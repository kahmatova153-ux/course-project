using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WatchRepairApp
{
    public partial class LoginForm : Form
    {
        public string CurrentUserRole { get; private set; }    
        public string CurrentUserName { get; private set; }    
        public int CurrentUserID { get; private set; }        

        public LoginForm()
        {
            InitializeComponent();  
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();        
            string password = txtPassword.Text;          

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            string query = @"SELECT u.UserID, u.FullName, r.RoleName 
                             FROM Users u 
                             JOIN Roles r ON u.RoleID = r.RoleID 
                             WHERE u.Login = @Login 
                             AND u.PasswordHash = @Password 
                             AND u.IsActive = 1";  

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Login", login),
                new SqlParameter("@Password", password) 
            };

            DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow user = result.Rows[0]; 

                CurrentUserID = Convert.ToInt32(user["UserID"]);
                CurrentUserName = user["FullName"].ToString();
                CurrentUserRole = user["RoleName"].ToString();

                this.DialogResult = DialogResult.OK;
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtPassword.Clear();
                txtPassword.Focus(); 
            }
        }

        // === ОБРАБОТЧИК НАЖАТИЯ ENTER В ПОЛЕ ПАРОЛЯ ===
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если нажат Enter - вызываем вход
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }
    }
}