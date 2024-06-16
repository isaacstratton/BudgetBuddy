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
            // ToDo: add income button click
        }

        private void btnAddExpenses_Click(object sender, EventArgs e)
        {
            // ToDo: add expenses button click
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Close the entire application
        }
    }
}