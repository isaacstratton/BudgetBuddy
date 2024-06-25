using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetBuddy
{
    public partial class AddTransactionForm : Form
    {
        private Controller controller;

        private string username;

        public AddTransactionForm(string username, Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
            this.username = username;
            LoadIncomeCategories();
        }
        private void LoadIncomeCategories()
        {
            DataTable categories = controller.LoadCategories("Income");
            if (categories != null)
            {
                cmbCategory.DataSource = categories;
                cmbCategory.DisplayMember = "category_name";
                cmbCategory.ValueMember = "category_id";
            }
            else
            {
                MessageBox.Show("Failed to load categories.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime transactionDate = dateTimePicker1.Value;
            int categoryId = (int)cmbCategory.SelectedValue;
            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }
            string description = txtDescription.Text;

            bool success = controller.AddIncome(transactionDate, categoryId, amount, description, username);
            if (success)
            {
                MessageBox.Show("Income added successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error adding income. Please try again.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
