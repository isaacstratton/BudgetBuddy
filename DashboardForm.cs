using System;
using System.Windows.Forms;

namespace BudgetBuddy
{
    public partial class DashboardForm : Form
    {
        private Controller controller;
        private string username;

        public DashboardForm(string username, Controller controller)
        {
            InitializeComponent();
            this.controller = controller; // Use the passed Controller instance
            this.username = username;
            LoadData();
        }


        private void LoadData()
        {
            decimal income = controller.LoadIncome();
            decimal expenses = controller.LoadExpenses();
            decimal netBalance = controller.CalculateNetBalance(income, expenses);

            txtIncome.Text = income.ToString("C");
            txtExpenses.Text = expenses.ToString("C");
            txtNetBalance.Text = netBalance.ToString("C");
        }
        private void btnAddIncome_Click(object sender, EventArgs e)
        {
            AddTransactionForm addTransactionForm = new AddTransactionForm(username, controller);
            addTransactionForm.FormClosed += AddTransactionForm_FormClosed;
            addTransactionForm.ShowDialog();
        }

        private void AddTransactionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private void btnAddExpenses_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm(username, controller);
            expenseForm.FormClosed += ExpenseForm_FormClosed;
            expenseForm.ShowDialog();
        }

        private void ExpenseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Close the entire application
        }
    }
}
