using System;
using System.Windows.Forms;

namespace WatchRepairApp.Forms
{
    public partial class AddWorkForm : Form
    {
        public string WorkDescription { get; private set; }
        public decimal WorkCost { get; private set; }

        public AddWorkForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Введите описание работы!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return;
            }

            if (numCost.Value < 0)
            {
                MessageBox.Show("Стоимость не может быть отрицательной!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCost.Focus();
                return;
            }

            WorkDescription = txtDescription.Text.Trim();
            WorkCost = numCost.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}