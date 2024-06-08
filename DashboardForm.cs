using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetBuddy
{
    public partial class DashboardForm : Form
    {
        private string connectionString;

        public DashboardForm(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadFinancialData();
        }

        private void LoadFinancialData()
        {
            decimal income = 0, expenses = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Fetch income
                string incomeQuery = "SELECT SUM(Amount) FROM Transactions WHERE Type = 'Income'";
                SqlCommand incomeCommand = new SqlCommand(incomeQuery, connection);
                var incomeResult = incomeCommand.ExecuteScalar();
                if (incomeResult != DBNull.Value)
                {
                    income = Convert.ToDecimal(incomeResult);
                }

                // Fetch expenses
                string expensesQuery = "SELECT SUM(Amount) FROM Transactions WHERE Type = 'Expense'";
                SqlCommand expensesCommand = new SqlCommand(expensesQuery, connection);
                var expensesResult = expensesCommand.ExecuteScalar();
                if (expensesResult != DBNull.Value)
                {
                    expenses = Convert.ToDecimal(expensesResult);
                }
            }

            decimal netBalance = income - expenses;

            lblIncome.Text = $"Total Income: ${income}";
            lblExpenses.Text = $"Total Expenses: ${expenses}";
            txtNetBalance.Text = $"Net Balance: ${netBalance}";
        }
        private void lblIncome_Click(object sender, EventArgs e)
        {

        }

        private void txtNetBalance_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddIncome_Click(object sender, EventArgs e)
        {
            AddTransaction("Income", txtIncome.Text);
        }

        private void btnAddExpenses_Click(object sender, EventArgs e)
        {
            AddTransaction("Expense", txtExpenses.Text);
        }
        private void AddTransaction(string type, string amountText)
        {
            if (decimal.TryParse(amountText, out decimal amount))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Transactions (Amount, Type, Date) VALUES (@Amount, @Type, @Date)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@Date", DateTime.Now);

                    command.ExecuteNonQuery();
                }
                MessageBox.Show($"{type} added successfully.");
                LoadFinancialData();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please enter a valid amount.");
            }
        }

        private void ClearInputFields()
        {
            txtIncome.Clear();
            txtExpenses.Clear();
        }

        private void txtIncome_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys, digits, and one decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtExpenses_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys, digits, and one decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}


